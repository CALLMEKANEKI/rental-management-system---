using BLL.BLL;
using BLL.Services;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmChuTro : Form
    {
        private const string IMAGES_FOLDER_NAME = "Images";
        private chutroService _chutroSerVice = new chutroService();
        private string id_chutrohientai;
        private chutro currentChuTro;

        public frmChuTro()
        {
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            this.currentChuTro = _chutroSerVice.LayChuTroById(id_chutrohientai);
            InitializeComponent();
            LoadDataChuTro();

        }

        // Hàm chọn ảnh chung
        private void btnUpload_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || btn.Tag == null)
                return;


            string tagValue = btn.Tag.ToString();

            // Tìm PictureBox có cùng Tag
            PictureBox targetPicBox = null;
            foreach (Control ctrl in grbPic.Controls)
            {
                if (ctrl is PictureBox pic && pic.Tag?.ToString() == tagValue)
                {
                    targetPicBox = pic;
                    break;
                }
            }

            //Tiến hành upload ảnh
            // Tiến hành upload ảnh và Copy
            if (targetPicBox != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName; // Đường dẫn file gốc người dùng chọn
                    string newFileName = Path.GetFileName(sourceFilePath); 

                    // TẠO THƯ MỤC NẾU CHƯA CÓ
                    string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string targetDirectory = Path.Combine(appDirectory, IMAGES_FOLDER_NAME);

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    // XÂY DỰNG ĐƯỜNG DẪN ĐÍCH VÀ ĐẢM BẢO TÊN FILE DUY NHẤT
                    // Thêm mã thời gian hoặc GUID vào tên file để tránh trùng lặp nếu người dùng upload nhiều ảnh trùng tên
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + newFileName;
                    string targetFilePath = Path.Combine(targetDirectory, uniqueFileName);

                    try
                    {
                        // 1. THỰC HIỆN COPY FILE
                        File.Copy(sourceFilePath, targetFilePath, true); // true: cho phép ghi đè nếu trùng tên

                        // 2. HIỂN THỊ ẢNH MỚI
                        targetPicBox.Image = Image.FromFile(targetFilePath);
                        targetPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

                        // 3. LƯU ĐƯỜNG DẪN VÀO ĐỐI TƯỢNG CHUTRO
                        // Chỉ lưu tên file tương đối (uniqueFileName) hoặc đường dẫn tương đối (Images/uniqueFileName)
                        string relativePath = IMAGES_FOLDER_NAME + "/" + uniqueFileName;

                        // Gán đường dẫn vào thuộc tính tương ứng của đối tượng currentChuTro
                        switch (tagValue)
                        {
                            case "Avatar": currentChuTro.avatar_url = relativePath; break;
                            case "CCCD_Truoc": currentChuTro.anh_cccd_truoc_url = relativePath; break;
                            case "CCCD_Sau": currentChuTro.anh_cccd_sau_url = relativePath; break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void LoadDataChuTro()
        {
            currentChuTro = _chutroSerVice.LayChuTroById(id_chutrohientai);
            txtHoTen.Text = currentChuTro.hoten;
            txtSDT.Text = currentChuTro.sdt;
            txtDiaChi.Text = currentChuTro.diachi;
            txtEmail.Text = currentChuTro.email;
            txtTaiKhoan.Text = currentChuTro.taikhoan;
            txtMatKhau.Text = currentChuTro.matkhau;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataChuTro();
        }

        private void isChuTroEditing(bool mode)
        {
            txtHoTen.ReadOnly = !mode;
            txtSDT.ReadOnly = !mode;
            txtDiaChi.ReadOnly = !mode;
            txtEmail.ReadOnly = !mode;
            txtTaiKhoan.ReadOnly = !mode;
            txtMatKhau.ReadOnly = !mode;
        }

        private void clearChuTro()
        {
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Sửa")
            {
                if (currentChuTro == null || string.IsNullOrEmpty(currentChuTro.id_chutro))
                {
                    MessageBox.Show("Chưa tải được thông tin chủ trọ để chỉnh sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Bây giờ bạn đã có thể chỉnh sửa !!! \nNhấn vào nút Lưu để lưu thông tin ");
                isChuTroEditing(true);
                ((Button)sender).Text = "Lưu";
            }
            else if (btn.Text == "Lưu")
            {
                chutro chutroUpdated = new chutro
                {
                    id_chutro = currentChuTro.id_chutro,
                    hoten = txtHoTen.Text.Trim(),
                    sdt = txtSDT.Text.Trim(),
                    diachi = txtDiaChi.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    taikhoan = txtTaiKhoan.Text.Trim(),
                    matkhau = txtMatKhau.Text.Trim(),
                };
                string mess = _chutroSerVice.CapNhat(chutroUpdated, id_chutrohientai);
                if (mess == "cập nhật thành công.")
                {
                    clearChuTro();
                    isChuTroEditing(false);
                    btn.Text = "Sửa";
                    LoadDataChuTro();
                }
                MessageBox.Show(mess);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "LƯU Ý: HÀNH ĐỘNG SAU ĐÂY KHÔNG THỂ HOÀN TÁC!!!\n BẠN CHẮC CHẮN MUỐN XÓA?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 1. Dọn dẹp session trước khi xóa
                if (currentChuTro == null || string.IsNullOrEmpty(currentChuTro.id_chutro))
                {
                    MessageBox.Show("Không có thông tin chủ trọ để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Thực hiện Xóa 
                string mess = _chutroSerVice.Xoa(currentChuTro.id_chutro);

                if (mess == "Xóa thành công.")
                {
                    MessageBox.Show(mess, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. XÓA DỮ LIỆU SESSION
                    MAIN.main.LOGIN.id_chutrohientai = null;
                    // 4. ĐÓNG CÁC FORM LIÊN QUAN VÀ CHUYỂN VỀ LOGIN
                    DongTatCaVaMoLaiLogin();
                }
                else
                {
                    MessageBox.Show(mess, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DongTatCaVaMoLaiLogin()
        {
            // Tạo một danh sách để chứa các Form cần đóng an toàn
            List<Form> formsToClose = new List<Form>();

            // Tìm Form LOGIN để hiển thị nó (nếu nó đang ẩn)
            Form loginForm = null;

            // Lặp qua tất cả các Form đang mở
            foreach (Form f in Application.OpenForms)
            {
                if (f is LOGIN)
                {
                    loginForm = f;
                    // Không thêm Form LOGIN vào danh sách đóng
                }
                else
                {
                    // Thêm tất cả các Form khác (frmQuanLy, frmChuTro, v.v.) vào danh sách đóng
                    formsToClose.Add(f);
                }
            }

            // 1. Đóng tất cả các Form ngoại trừ Form LOGIN
            foreach (Form f in formsToClose)
            {
                f.Close();
            }

            // 2. Hiển thị Form LOGIN
            if (loginForm != null)
            {
                loginForm.Show();
                // Tùy chọn: Đảm bảo Form LOGIN không bị thu nhỏ
                loginForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                // Trường hợp Form LOGIN đã bị đóng hoàn toàn, mở lại một instance mới
                LOGIN newLoginForm = new LOGIN();
                newLoginForm.Show();
            }
        }

        private void frmChuTro_Load(object sender, EventArgs e)
        {

        }
    }
}
