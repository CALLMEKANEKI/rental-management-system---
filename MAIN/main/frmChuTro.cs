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
using System.Runtime.Remoting.Contexts;
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
        private ContextDB contextDB = new ContextDB();

        public frmChuTro()
        {
            InitializeComponent();

            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            this.currentChuTro = _chutroSerVice.LayChuTroById(id_chutrohientai);

            // ĐĂNG KÝ SỰ KIỆN FORM CLOSING
            this.FormClosing += frmChuTro_FormClosing;

            LoadDataChuTro();
            LoadImages();
        }

        private void frmChuTro_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeAllImages();
        }

        private void LoadImages()
        {
            if (currentChuTro == null) return;

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Load Avatar
            if (!string.IsNullOrEmpty(currentChuTro.avatar_url))
            {
                string avatarPath = Path.Combine(appDirectory, currentChuTro.avatar_url);
                LoadSingleImage(picAvatar, avatarPath);
            }

            // Load CCCD Mặt trước
            if (!string.IsNullOrEmpty(currentChuTro.anh_cccd_truoc_url))
            {
                string cccdTruocPath = Path.Combine(appDirectory, currentChuTro.anh_cccd_truoc_url);
                LoadSingleImage(picCCCDTruoc, cccdTruocPath);
            }

            // Load CCCD Mặt sau
            if (!string.IsNullOrEmpty(currentChuTro.anh_cccd_sau_url))
            {
                string cccdSauPath = Path.Combine(appDirectory, currentChuTro.anh_cccd_sau_url);
                LoadSingleImage(picCCCDSau, cccdSauPath);
            }
        }

        private void LoadSingleImage(PictureBox picBox, string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    // Giải phóng ảnh cũ trước
                    picBox.Image?.Dispose();

                    using (var tempImage = Image.FromFile(imagePath))
                    {
                        picBox.Image = new Bitmap(tempImage);
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || btn.Tag == null) return;

            string tagValue = btn.Tag.ToString();
            PictureBox targetPicBox = null;
            string currentImagePath = null;

            switch (tagValue)
            {
                case "Avatar":
                    targetPicBox = picAvatar;
                    currentImagePath = currentChuTro?.avatar_url;
                    break;
                case "CCCD_Truoc":
                    targetPicBox = picCCCDTruoc;
                    currentImagePath = currentChuTro?.anh_cccd_truoc_url;
                    break;
                case "CCCD_Sau":
                    targetPicBox = picCCCDSau;
                    currentImagePath = currentChuTro?.anh_cccd_sau_url;
                    break;
            }

            if (targetPicBox == null) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UploadAndSaveImage(tagValue, targetPicBox, currentImagePath, openFileDialog.FileName);
                }
            }
        }

        private void UploadAndSaveImage(string tagValue, PictureBox targetPicBox, string currentImagePath, string sourceFilePath)
        {
            try
            {
                Console.WriteLine($"Starting upload for: {tagValue}");

                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string targetDirectory = Path.Combine(appDirectory, IMAGES_FOLDER_NAME);

                Console.WriteLine($"Target directory: {targetDirectory}");

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                    Console.WriteLine("Created directory");
                }

                string fileExtension = Path.GetExtension(sourceFilePath);
                string newFileName = $"{tagValue}_{Guid.NewGuid():N}{fileExtension}";
                string targetFilePath = Path.Combine(targetDirectory, newFileName);

                Console.WriteLine($"New file: {newFileName}");

                // Xóa ảnh cũ
                if (!string.IsNullOrEmpty(currentImagePath))
                {
                    string oldImageFullPath = Path.Combine(appDirectory, currentImagePath);
                    Console.WriteLine($"Old image to delete: {oldImageFullPath}");

                    if (File.Exists(oldImageFullPath))
                    {
                        File.Delete(oldImageFullPath);
                        Console.WriteLine("Old image deleted");
                    }
                }

                // Copy ảnh mới
                File.Copy(sourceFilePath, targetFilePath, false);
                Console.WriteLine("File copied successfully");

                // Cập nhật đường dẫn
                string relativePath = Path.Combine(IMAGES_FOLDER_NAME, newFileName).Replace("\\", "/");
                Console.WriteLine($"Relative path: {relativePath}");

                UpdateImagePath(tagValue, relativePath);
                Console.WriteLine("Image path updated in object");

                // Hiển thị ảnh mới
                LoadSingleImage(targetPicBox, targetFilePath);
                Console.WriteLine("Image loaded to PictureBox");

                // Lưu database - KHÔNG HIỂN THỊ MESSAGE Ở ĐÂY NỮA
                SaveToDatabase(); // Message sẽ được hiển thị trong SaveToDatabase

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Upload error: {ex.Message}");
                MessageBox.Show($"Lỗi khi upload ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateImagePath(string tagValue, string relativePath)
        {
            if (currentChuTro == null) return;

            switch (tagValue)
            {
                case "Avatar":
                    currentChuTro.avatar_url = relativePath;
                    break;
                case "CCCD_Truoc":
                    currentChuTro.anh_cccd_truoc_url = relativePath;
                    break;
                case "CCCD_Sau":
                    currentChuTro.anh_cccd_sau_url = relativePath;
                    break;
            }
        }

        private void SaveToDatabase()
        {
            try
            {
                // KIỂM TRA PHƯƠNG THỨC NÀY CÓ THỰC SỰ ĐƯỢC GỌI KHÔNG
                Console.WriteLine("SaveToDatabase called");

                if (currentChuTro == null)
                {
                    Console.WriteLine("currentChuTro is null");
                    MessageBox.Show("Lỗi: Không có thông tin chủ trọ để lưu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // KIỂM TRA GIÁ TRỊ TRƯỚC KHI LƯU
                Console.WriteLine($"Avatar URL: {currentChuTro.avatar_url}");
                Console.WriteLine($"CCCD Truoc URL: {currentChuTro.anh_cccd_truoc_url}");
                Console.WriteLine($"CCCD Sau URL: {currentChuTro.anh_cccd_sau_url}");

                string result = _chutroSerVice.CapNhat(currentChuTro, id_chutrohientai.ToString());

                Console.WriteLine($"Update result: {result}");

                if (result.Contains("thành công"))
                {
                    MessageBox.Show("Lưu thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi khi lưu: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database save error: {ex.Message}");
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisposeAllImages()
        {
            try
            {
                picAvatar.Image?.Dispose();
                picCCCDTruoc.Image?.Dispose();
                picCCCDSau.Image?.Dispose();

                picAvatar.Image = null;
                picCCCDTruoc.Image = null;
                picCCCDSau.Image = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disposing images: {ex.Message}");
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
