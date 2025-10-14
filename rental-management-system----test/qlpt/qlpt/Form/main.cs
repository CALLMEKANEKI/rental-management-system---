using qlpt_BLL.BLL;
using qlpt_DTO.Models;
using qlpt_DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlpt
{
    public partial class main : Form
    {
        private ChuTroBLL chuTroBLL = new ChuTroBLL();
        private PhongTroBLL phongTroBLL = new PhongTroBLL();
        private NguoiThueBLL NguoiThueBLL = new NguoiThueBLL();
        private HopDongBLL HopDongBLL = new HopDongBLL();
        private HoaDonBLL HoaDonBLL = new HoaDonBLL();  
        private int idChuTroHienTai;


        // Biến để lưu trữ đối tượng sau khi lấy từ DB
        private ChuTro currentChuTro;

        // Constructor nhận ID của người dùng đã đăng nhập
        public main(int idUser)
        {
            InitializeComponent();
            this.idChuTroHienTai = idUser;

            // Gọi hàm để đổ dữ liệu khi Form được tải
            LoadDataChuTro();
            LoadListPhongTro();
            LoadListNguoiThue();
            LoadListHopDong();
            LoadListHoaDon();
        }


        ///-----Tad 1: Thông tin cá nhân
        private void LoadDataChuTro()
        {
            // 1. GỌI BLL ĐỂ LẤY DỮ LIỆU TỪ DATABASE
            currentChuTro = chuTroBLL.GetChuTroById(idChuTroHienTai);

            if (currentChuTro != null)
            {
                // 2. ĐỔ DỮ LIỆU VÀO CÁC TEXTBOX
                txtNameAd.Text = currentChuTro.HoTen;
                txtAddressAd.Text = currentChuTro.Sdt;
                txtPhoneNumberAd.Text = currentChuTro.Sdt;
                txtAddressAd.Text = currentChuTro.DiaChi;
                txtEmailAd.Text = currentChuTro.Email;
            }
            else
            {
                MessageBox.Show("Không thể tải thông tin người dùng từ CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            if (targetPicBox != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    targetPicBox.Image = Image.FromFile(openFileDialog.FileName);
                    targetPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        //Hàm bổ trợ
        private void ControlAdMode(bool mode)
        {
            txtNameAd.ReadOnly = !mode;
            txtAddressAd.ReadOnly = !mode;
            txtPhoneNumberAd.ReadOnly = !mode;
            txtEmailAd.ReadOnly = !mode;
        }

        //Nút cập nhật thông tin chủ trọ
        private bool isEditing = false;

        private void btnUpdateAd_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // Chế độ 1: Bật Chỉnh sửa (Giữ nguyên)
                MessageBox.Show("Bạn giờ đã có thể cập nhật được thông tin cá nhân! \nNhấn nút LƯU sau khi hoàn tất chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ControlAdMode(true); // 
                isEditing = true;
                ((Button)sender).Text = "Lưu"; 
            }
            else
            {
                // Chế độ 2: LƯU DỮ LIỆU
                int resultCode = SaveDataChuTro(); 

                if (resultCode == 1)
                {
                    // THÀNH CÔNG
                    MessageBox.Show("Cập nhật thông tin Chủ trọ thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isEditing = false;
                    ControlAdMode(false); 
                    ((Button)sender).Text = "Cập Nhật";
                    LoadDataChuTro(); 
                }
                else if (resultCode != 0) // resultCode < 0 là mã lỗi Validation
                {
                    string errorMessage = "Lỗi không xác định.";

                    // Xử lý các mã lỗi Validation
                    switch (resultCode)
                    {
                        case -1:
                            errorMessage = "Tên quá dài! KHÔNG HỢP LỆ";
                            break;
                        case -2:
                            errorMessage = "Số điện thoại KHÔNG HỢP LỆ (Sai định dạng hoặc quá dài)!";
                            break;
                        case -3:
                            errorMessage = "Email KHÔNG HỢP LỆ (Sai định dạng hoặc quá dài)!";
                            break;
                        case -4:
                            errorMessage = "Địa chỉ quá dài! KHÔNG HỢP LỆ";
                            break;
                    }
                    // Hiển thị lỗi Validation
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int SaveDataChuTro()
        {
            // Kiểm tra currentChuTro
            if (currentChuTro == null)
            {
                // Thường xảy ra khi người dùng chưa đăng nhập hoặc ID chưa được load
                MessageBox.Show("Lỗi hệ thống: Không xác định được thông tin Chủ trọ hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            // 1. Tạo đối tượng ChuTro mới từ dữ liệu Form
            ChuTro updatedChuTro = new ChuTro
            {
                Id_ChuTro = currentChuTro.Id_ChuTro, 
                HoTen = txtNameAd.Text,
                DiaChi = txtAddressAd.Text,
                Sdt = txtPhoneNumberAd.Text,
                Email = txtEmailAd.Text,
                TaiKhoan = currentChuTro.TaiKhoan, 
                MatKhau = currentChuTro.MatKhau    
            };

            // LƯU Ý: Validation cơ bản tại UI (bạn nên chuyển cái này vào BLL)
            if (string.IsNullOrEmpty(updatedChuTro.HoTen) || string.IsNullOrEmpty(updatedChuTro.Sdt) || string.IsNullOrEmpty(updatedChuTro.DiaChi) || string.IsNullOrEmpty(updatedChuTro.Email))
            {
                MessageBox.Show("Dữ liệu không được để trống.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0; // Trả về 0 nếu validation UI thất bại
            }

            // 2. GỌI BLL: Gọi BLL chỉ một lần
            int resultCode = chuTroBLL.UpdateChuTro(updatedChuTro);

            // 3. Xử lý sự kiện nếu Update thất bại do lỗi SQL hoặc lỗi không mong muốn
            if (resultCode <= 0 && resultCode > -100) // Kiểm tra nếu là lỗi DAL/SQL (không phải mã lỗi Validation)
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra kết nối CSDL hoặc dữ liệu không hợp lệ.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // Trả về 0 cho lỗi không rõ
            }

            return resultCode; // Trả về 1 (Thành công) hoặc mã lỗi Validation (< 0)
        }

        //Nút xóa tài khoản
        private void btnDeleteAd_Click(object sender, EventArgs e)
        {
            // 1. Hiển thị hộp thoại cảnh báo và yêu cầu xác nhận ban đầu
            DialogResult confirmResult = MessageBox.Show(
                "LƯU Ý: HÀNH ĐỘNG NÀY SẼ KHÔNG THỂ HOÀN LẠI ĐƯỢC. \nBẠN THẬT SỰ MUỐN XÓA TÀI KHOẢN?",
                "Xác Nhận Xóa Tài Khoản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // 2. Nếu người dùng chọn "Có" (Yes)
            if (confirmResult == DialogResult.Yes)
            {
                if (chuTroBLL.DeleteChuTro(idChuTroHienTai))
                {
                    MessageBox.Show("Tài khoản đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Thoát khỏi Form chính và mở Form Đăng nhập
                    this.Close();
                    // Hoặc gọi hàm để mở Form đăng nhập
                    // new LoginForm().Show(); 
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } 

        ///-----Tad 2: Phòng trọ
        private void LoadListPhongTro()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<PhongTro>)
                List<PhongTro> danhSachPhong = phongTroBLL.GetAllPhong(idChuTroHienTai);

                // 2. Gán danh sách trực tiếp vào DataSource
                dgvRoomList.DataSource = danhSachPhong;

                // 3. Tùy chỉnh hiển thị (Tùy chọn)
                EditGridViewRoomList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phòng trọ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditGridViewRoomList()
        {
            // Tùy chỉnh tên cột thân thiện hơn
            dgvRoomList.Columns["Id_Phong"].HeaderText = "ID Phòng";
            dgvRoomList.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvRoomList.Columns["GiaPhong"].HeaderText = "Giá Thuê";
            dgvRoomList.Columns["TinhTrang"].HeaderText = "Tình Trạng";

            // Ẩn cột khóa ngoại không cần thiết
            dgvRoomList.Columns["Id_ChuTro"].Visible = false;
            dgvRoomList.Columns["ChuTro"].Visible = false;

            // Cho phép chọn toàn bộ hàng
            dgvRoomList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Hàm hỗ trợ
        // Hàm hỗ trợ để xóa nội dung
        private void ClearRoomInputs()
        {
            txtIdRoom.Text = "";
            txtRoomName.Text = "";
            txtRoomPrice.Text = "";
            txtRoomStatus.Text = "";
        }

        private void ControlRoomMode(bool mode)
        {
            txtRoomName.ReadOnly = !mode;
            txtRoomPrice.ReadOnly = !mode;
            txtRoomStatus.ReadOnly = !mode;
        }

        private bool isRoomEditing = false; //Biến trạng thái chỉnh sửa


        //Đổ data vào textbox khi nhấn vào hàng ở DGV
        private void dgvRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo không nhấp vào tiêu đề cột và có hàng được chọn
            if (e.RowIndex >= 0 && dgvRoomList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRoomList.Rows[e.RowIndex];

                try
                {
                    // Lấy dữ liệu từ hàng được chọn và đổ vào TextBox
                    txtIdRoom.Text = row.Cells["Id_Phong"].Value.ToString();
                    txtRoomName.Text = row.Cells["TenPhong"].Value.ToString();
                    txtRoomPrice.Text = row.Cells["GiaPhong"].Value.ToString();
                    txtRoomStatus.Text = row.Cells["TinhTrang"].Value.ToString();
                    // Định dạng giá phòng nếu cần
                    if (row.Cells["GiaPhong"].Value != DBNull.Value)
                    {
                        txtRoomPrice.Text = Convert.ToDecimal(row.Cells["GiaPhong"].Value).ToString("F0"); // Định dạng không có số thập phân
                    }
                    else
                    {
                        txtRoomPrice.Text = string.Empty;
                    }
                    txtRoomStatus.Text = row.Cells["TinhTrang"].Value.ToString();

                    // Đặt lại các TextBox về ReadOnly sau khi đổ dữ liệu (trừ khi đang ở chế độ chỉnh sửa)
                    if (!isRoomEditing)
                    {
                        ControlRoomMode(!isRoomEditing);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi đổ dữ liệu phòng trọ: " + ex.Message);
                    // Xử lý lỗi nếu tên cột không khớp hoặc lỗi chuyển đổi kiểu dữ liệu
                }
            }
        }

        //Nút cập nhật phòng
        private void btnInsertAndUpdateRoom_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (!isRoomEditing)
            {
                // CHẾ ĐỘ 1: CHUẨN BỊ CHỈNH SỬA / THÊM MỚI

                // Hàm này (ControlRoomMode) có nhiệm vụ bật/tắt ReadOnly cho các TextBox
                ControlRoomMode(true);

                if (string.IsNullOrEmpty(txtIdRoom.Text)) // Mode: Insert
                {
                    MessageBox.Show("THÊM MỚI đã được kích hoạt. Vui lòng nhập thông tin và nhấn nút LƯU.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearRoomInputs();
                }
                else // Mode: Update
                {
                    MessageBox.Show("CHỈNH SỬA đã được kích hoạt. Nhấn nút LƯU sau khi hoàn tất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isRoomEditing = true;
                btn.Text = "LƯU";
            }
            else
            {
                // CHẾ ĐỘ 2: LƯU DỮ LIỆU (INSERT hoặc UPDATE)
                int resultCode = SaveRoomData();

                if (resultCode == 1)
                {
                    // THÀNH CÔNG
                    MessageBox.Show("Lưu dữ liệu Phòng trọ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đặt lại trạng thái
                    isRoomEditing = false;
                    ControlRoomMode(false); // Tắt chế độ chỉnh sửa
                    LoadListPhongTro();
                    ClearRoomInputs();
                    btn.Text = "Thêm/Cập nhật";
                }
                else // Thất bại (resultCode <= 0)
                {
                    string errorMessage = "Lỗi không xác định trong quá trình lưu dữ liệu.";

                    // Xử lý mã lỗi cụ thể từ Validation BLL
                    switch (resultCode)
                    {
                        case -99:
                            errorMessage = "Lỗi hệ thống: Không xác định được ID Chủ trọ.";
                            break;
                        case -10:
                            errorMessage = "Tên phòng không được để trống!";
                            break;
                        case -11:
                            errorMessage = "Tên phòng quá dài! (Giới hạn 50 ký tự)";
                            break;
                        case -20:
                            errorMessage = "Giá phòng không được để trống!";
                            break;
                        case -21:
                            errorMessage = "Giá phòng phải là một số nguyên hợp lệ!";
                            break;
                        case -22:
                            errorMessage = "Giá phòng không hợp lệ (Không được là số âm)!";
                            break;
                        case -30:
                            errorMessage = "Tình trạng phòng không được để trống!";
                            break;
                        case -31:
                            errorMessage = "Tình trạng phòng quá dài! (Giới hạn 255 ký tự)";
                            break;
                        case 0:
                            errorMessage = "Thao tác thất bại. Vui lòng kiểm tra dữ liệu hoặc lỗi kết nối CSDL.";
                            break;
                            // Thêm các mã lỗi khác(update)
                    }

                    MessageBox.Show(errorMessage, "Lỗi Lưu Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // GIỮ NGUYÊN isRoomEditing = true để người dùng sửa lỗi
                }
            }
        }

        private int SaveRoomData()
        {
            if (idChuTroHienTai <= 0)
            {
                return -99; // Mã lỗi: Không xác định được ID Chủ trọ
            }
            if (string.IsNullOrEmpty(txtRoomPrice.Text))
                return -20; //Lỗi giá phòng để trống
            decimal giaPhong;
            if (!decimal.TryParse(txtRoomPrice.Text, out giaPhong))
                return -21; //Lỗi giá phòng không phải số

            // 1. Tạo đối tượng PhongTro từ UI
            PhongTro objPhongTro = new PhongTro
            {
                TenPhong = txtRoomName.Text,
                GiaPhong = giaPhong,
                TinhTrang = txtRoomStatus.Text,
                Id_ChuTro = idChuTroHienTai
            };
            // 2. GỌI HÀM VALIDATION BLL
            int validationCode = phongTroBLL.PhongTroValidationCode(objPhongTro);
            if (validationCode != 1)
            {
                return validationCode; // Trả về mã lỗi validation
            }
          
            int result;
            if (string.IsNullOrEmpty(txtIdRoom.Text))
            {
                // MODE INSERT
                // Giả sử InsertPhongTro trả về ID mới (> 0 thành công, 0 thất bại)
                result = phongTroBLL.InsertPhongTro(objPhongTro);
                return result > 0 ? 1 : 0;
            }
            else
            {
                // MODE UPDATE
                objPhongTro.Id_Phong = int.Parse(txtIdRoom.Text);

                // Giả sử UpdatePhong trả về bool (true/false)
                return phongTroBLL.UpdatePhong(objPhongTro) ? 1 : 0;
            }
        }

        // Nút xóa
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdRoom.Text))
            {
                MessageBox.Show("Vui lòng chọn Phòng trọ cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtIdRoom.Text, out int idPhongToDelete))
            {
                MessageBox.Show("ID phòng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng có ID: {idPhongToDelete} không? Việc này có thể ảnh hưởng đến các bản ghi Hợp đồng/Hóa đơn liên quan.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if ((phongTroBLL.DeletePhong(idChuTroHienTai,idPhongToDelete)) == 1)
                {
                    MessageBox.Show("Xóa phòng trọ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListPhongTro(); // Tải lại DataGridView
                    ClearRoomInputs();
                }
                else if ((phongTroBLL.DeletePhong(idChuTroHienTai, idPhongToDelete)) == -2)
                {
                    MessageBox.Show("Xóa phòng trọ thất bại. Phòng này đang có Người thuê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Nút tìm kiếm
        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm
            string tenPhongCanTim = txtSearchRoom.Text.Trim();
            try
            {
                List<PhongTro> danhSachKetQua;
                if (string.IsNullOrEmpty(tenPhongCanTim))
                {
                    // Nếu TextBox tìm kiếm rỗng, tải lại toàn bộ danh sách
                    LoadListPhongTro();
                    return;
                }
                else
                {
                    // 1. Gọi BLL để tìm kiếm theo tên và ID Chủ trọ hiện tại
                    danhSachKetQua = phongTroBLL.GetPhongByName(idChuTroHienTai, tenPhongCanTim);
                }

                // 2. Cập nhật DataGridView với kết quả tìm kiếm
                dgvRoomList.DataSource = danhSachKetQua;

                // 3. Tùy chỉnh hiển thị lại (nếu cần)
                EditGridViewRoomList();

                if (danhSachKetQua.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy phòng trọ nào có tên chứa '{tenPhongCanTim}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện tìm kiếm phòng trọ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///-----Tad 3: Người thuê 

        private void LoadListNguoiThue()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<NguoiThueViewModel>)
                List<NguoiThueViewModel> danhsachNguoiThue = NguoiThueBLL.GetAllNguoiThueViewModel(idChuTroHienTai);

                // 2. Gán danh sách trực tiếp vào DataSource
                dgvGuestList.DataSource = danhsachNguoiThue;

                // 3. Tùy chỉnh hiển thị (Tùy chọn)
                EditGridViewGuestList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu người thuê : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditGridViewGuestList()
        {
            // Tùy chỉnh tên cột thân thiện hơn
            dgvGuestList.Columns["Id_NguoiThue"].HeaderText = "ID Người Thuê";
            dgvGuestList.Columns["Id_NguoiThue"].DisplayIndex = 0;
            dgvGuestList.Columns["HoTen"].HeaderText = "Họ tên";
            dgvGuestList.Columns["HoTen"].DisplayIndex = 1;
            dgvGuestList.Columns["TenPhongHienThi"].HeaderText = "Phòng";
            dgvGuestList.Columns["TenPhongHienThi"].DisplayIndex = 2;
            dgvGuestList.Columns["Cccd"].HeaderText = "CCCD";
            dgvGuestList.Columns["Cccd"].DisplayIndex = 3;
            dgvGuestList.Columns["Sdt"].HeaderText = "Số điện thoại";
            dgvGuestList.Columns["Sdt"].DisplayIndex = 4;
            dgvGuestList.Columns["Email"].HeaderText = "Email";
            dgvGuestList.Columns["Email"].DisplayIndex = 5;
            dgvGuestList.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvGuestList.Columns["TaiKhoan"].DisplayIndex = 6;

            // Ẩn cột khóa ngoại không cần thiết
            dgvGuestList.Columns["PhongTro"].Visible = false;
            dgvGuestList.Columns["Id_Phong"].Visible = false;
            dgvGuestList.Columns["MatKhau"].Visible = false;

            // Cho phép chọn toàn bộ hàng
            dgvGuestList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Hàm bổ trợ 
        private void ClearGuestInputs()
        {
            txtIdGuest.Text = "";
            txtGuestName.Text = "";
            txtGuestCCCD.Text = "";
            txtGuestPhoneNumber.Text = "";
            txtGuestEmail.Text = "";
            txtGuestUsername.Text = "";
            txtGuestPass.Text = "";
        }

        private void ControlGuestMode (bool mode)
        {
            txtGuestName.ReadOnly = !mode;
            txtGuestCCCD.ReadOnly = !mode;
            txtGuestPhoneNumber.ReadOnly = !mode;
            txtGuestEmail.ReadOnly = !mode;
            txtGuestRoomName.ReadOnly = !mode;
            txtGuestUsername.ReadOnly = !mode;
            txtGuestPass.ReadOnly = !mode;
        }

        //Hàm đổ data vào textbox khi chọn hàng trên DGV
        private bool isGuestEditing = false;
        private void dgvGuestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGuestList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvGuestList.Rows[e.RowIndex];

                try
                {
                    // Đổ dữ liệu lên TextBox
                    txtIdGuest.Text = row.Cells["Id_NguoiThue"].Value.ToString();
                    txtGuestName.Text = row.Cells["HoTen"].Value.ToString();
                    txtGuestRoomName.Text = row.Cells["TenPhongHienThi"].Value.ToString();
                    txtGuestCCCD.Text = row.Cells["Cccd"].Value.ToString();
                    txtGuestPhoneNumber.Text = row.Cells["Sdt"].Value.ToString();
                    txtGuestEmail.Text = row.Cells["Email"].Value.ToString();
                    txtGuestUsername.Text = row.Cells["TaiKhoan"].Value.ToString();
                    txtGuestPass.Text = row.Cells["MatKhau"].Value.ToString();
                    // Đặt lại các TextBox về ReadOnly
                    if (!isGuestEditing)
                    {
                        ControlGuestMode(!isGuestEditing);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi đổ dữ liệu Người thuê: " + ex.Message);
                }
            }
        }
        /*
                //Nút thêm/cập nhật người thuê
                private bool isGuestEdit = false;

                // Nút Thêm/Cập nhật Người thuê
                private void btnInsertAndUpdateTenant_Click(object sender, EventArgs e)
                {
                    Button btn = (Button)sender;

                    if (!isGuestEdit)
                    {
                        // CHẾ ĐỘ 1: CHUẨN BỊ CHỈNH SỬA / THÊM MỚI
                        ControlTenantMode(true);

                        if (string.IsNullOrEmpty(txtIdGuest.Text)) // Mode: Insert
                        {
                            MessageBox.Show("THÊM MỚI Người thuê đã được kích hoạt. Vui lòng nhập thông tin và nhấn nút LƯU.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTenantInputs();
                        }
                        else // Mode: Update
                        {
                            MessageBox.Show("CHỈNH SỬA thông tin Người thuê đã được kích hoạt. Nhấn nút LƯU sau khi hoàn tất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        isTenantEditing = true;
                        btn.Text = "LƯU";
                    }
                    else
                    {
                        // CHẾ ĐỘ 2: LƯU DỮ LIỆU (INSERT hoặc UPDATE)
                        // GỌI HÀM LƯU CHỈ MỘT LẦN VÀ LẤY MÃ LỖI
                        int resultCode = SaveNguoiThueData();

                        if (resultCode == 1)
                        {
                            // THÀNH CÔNG
                            MessageBox.Show("Lưu dữ liệu Người thuê thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Đặt lại trạng thái
                            isTenantEditing = false;
                            ControlTenantMode(false); // Tắt chế độ chỉnh sửa
                            LoadListNguoiThue();
                            ClearTenantInputs();
                            btn.Text = "Thêm/Cập nhật";
                        }
                        else // Thất bại (resultCode <= 0)
                        {
                            string errorMessage = "Lỗi không xác định trong quá trình lưu dữ liệu.";

                            // Xử lý mã lỗi cụ thể
                            switch (resultCode)
                            {
                                case -10:
                                    errorMessage = "Họ tên người thuê không được để trống!";
                                    break;
                                case -11:
                                    errorMessage = "Họ tên người thuê quá dài! (Giới hạn 50 ký tự)";
                                    break;
                                case -20:
                                    errorMessage = "Số CCCD/CMND không được để trống!";
                                    break;
                                case -21:
                                    errorMessage = "Số CCCD/CMND không hợp lệ (Phải là số và đúng độ dài).";
                                    break;
                                case -30:
                                    errorMessage = "Số điện thoại không được để trống!";
                                    break;
                                case -31:
                                    errorMessage = "Số điện thoại không hợp lệ (Sai định dạng).";
                                    break;
                                case -40:
                                    errorMessage = "Địa chỉ người thuê quá dài!";
                                    break;
                                case -50:
                                    errorMessage = "Email không hợp lệ/quá dài!";
                                    break;
                                case 0:
                                    errorMessage = "Thao tác thất bại. Lỗi từ tầng DAL/CSDL.";
                                    break;
                                default:
                                    // Lỗi hệ thống khác
                                    break;
                            }

                            MessageBox.Show(errorMessage, "Lỗi Lưu Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Giữ nguyên isTenantEditing = true để người dùng sửa lỗi
                        }
                    }
                }

                private int SaveNguoiThueData()
                {
                    // 1. Tạo đối tượng NguoiThue từ dữ liệu Form
                    NguoiThue objNguoiThue = new NguoiThue
                    {
                        HoTen = txtGuestName.Text,
                        Cccd = txtGuestCCCD.Text, // Giả sử là string
                        Sdt = txtGuestPhoneNumber.Text,
                        DiaChi = txtGuestAddress.Text,
                        Email = txtGuestEmail.Text
                        // Không cần Id_ChuTro nếu NguoiThue không liên quan trực tiếp đến ChuTro
                        // Nếu NguoiThue cần Id_ChuTro, bạn cần thêm nó vào đây
                    };

                    // 2. GỌI HÀM VALIDATION BLL
                    int validationCode = nguoiThueBLL.NguoiThueValidationCode(objNguoiThue);
                    if (validationCode != 1)
                    {
                        return validationCode; // Trả về mã lỗi validation
                    }

                    // 3. Tiến hành gọi DAL (Insert/Update)
                    if (string.IsNullOrEmpty(txtIdGuest.Text))
                    {
                        // MODE INSERT
                        // Giả sử InsertNguoiThue trả về ID mới (> 0 thành công, 0 thất bại)
                        int result = nguoiThueBLL.InsertNguoiThue(objNguoiThue);
                        return result > 0 ? 1 : 0;
                    }
                    else
                    {
                        // MODE UPDATE
                        if (!int.TryParse(txtIdGuest.Text, out int idNguoiThue))
                            return 0; // Lỗi: ID không phải số

                        objNguoiThue.Id_NguoiThue = idNguoiThue;

                        // Giả sử UpdateNguoiThue trả về bool (true/false)
                        return nguoiThueBLL.UpdateNguoiThue(objNguoiThue) ? 1 : 0;
                    }
                }

                //Nút xóa khách thuê
                private void btnDeleteGuest_Click(object sender, EventArgs e)
                {
                    if (string.IsNullOrEmpty(txtIdGuest.Text))
                    {
                        MessageBox.Show("Vui lòng chọn Người thuê cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtIdGuest.Text, out int idGuestToDelete))
                    {
                        MessageBox.Show("ID người thuê không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa Người thuê có ID: {idGuestToDelete} không? Việc này có thể ảnh hưởng đến các bản ghi Hợp đồng/Hóa đơn liên quan.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        if (NguoiThueBLL.DeleteNguoiThue(idGuestToDelete))
                        {
                            MessageBox.Show("Xóa người thuê thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadListNguoiThue(); // Tải lại DataGridView
                            ClearGuestInputs();
                        }
                        else
                        {
                            MessageBox.Show("Xóa người thuê thất bại. Có thể Người thuê này đang liên kết với Hợp đồng/Hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
        */
        //Nút tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Button tempBtn = sender as Button;
            if (tempBtn == null) return; // Bảo vệ khỏi lỗi NullReference

            string keyword = null;
            string tag = tempBtn.Tag.ToString();
            object searchResult = null; // Dùng object để lưu trữ danh sách có kiểu khác nhau
            DataGridView targetDgv = null;
            try
            {
                // 1. GỌI BLL VÀ XÁC ĐỊNH DGV MỤC TIÊU
                switch (tag)
                {
                    case "Room":
                        keyword = txtSearchRoom.Text.Trim();
                        searchResult = phongTroBLL.GetAllPhongTroByKeyWord(idChuTroHienTai, keyword);
                        targetDgv = dgvRoomList; 
                        break;
                    case "Guest":
                        keyword = txtSearchGuest.Text.Trim();
                        searchResult = NguoiThueBLL.GetAllNguoiThueVewModelByKeyWord(idChuTroHienTai, keyword);
                        targetDgv = dgvGuestList; 
                        break;
                    case "Contract":
                        keyword = txtSearchContract.Text.Trim();
                        searchResult = HopDongBLL.GetAllHopDongViewModelByKeyWord(idChuTroHienTai, keyword);
                        targetDgv = dgvContractList; 
                        break;
                    case "Bill":
                        keyword = txtSearchBill.Text.Trim();
                        searchResult = HoaDonBLL.GetAllHoaDonViewModelByKeyWord(idChuTroHienTai, keyword);
                        targetDgv = dgvBillList; 
                        break;
                    default:
                        MessageBox.Show("Tag tìm kiếm không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // 2. GÁN KẾT QUẢ VÀ HIỂN THỊ THÔNG BÁO CHUNG

                if (searchResult != null && targetDgv != null)
                {
                    // Gán Data Source (Dù là kiểu List<T> nào, nó vẫn là IEnumerable)
                    targetDgv.DataSource = searchResult;

                    // Gọi hàm Edit GridView tương ứng
                    switch (tag)
                    {
                        case "Guest": EditGridViewGuestList(); break;
                        case "Room": EditGridViewRoomList(); break; 
                        case "Contract": EditGridViewContractList(); break; 
                        case "Bill": EditGridViewBillList(); break;
                    }

                    // Kiểm tra kết quả tìm kiếm (sử dụng Reflection hoặc Cast nếu cần count)
                    var listCount = ((System.Collections.ICollection)searchResult).Count;

                    if (listCount == 0 && !string.IsNullOrEmpty(keyword))
                    {
                        MessageBox.Show($"Không tìm thấy {tag} nào có thông tin chứa '{keyword}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực hiện tìm kiếm {tag ?? "dữ liệu"}: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///-----Tad 4: Hợp đồng 
        private void LoadListHopDong()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<HopDongViewModel>)
                List<HopDongViewModel> danhsachHopDong = HopDongBLL.GetAllHopDongViewModel(idChuTroHienTai);

                // 2. Gán danh sách trực tiếp vào DataSource
                dgvContractList.DataSource = danhsachHopDong;

                // 3. Tùy chỉnh hiển thị (Tùy chọn)
                EditGridViewContractList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hợp đồng : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditGridViewContractList()
        {
            // Tùy chỉnh tên cột thân thiện hơn
            dgvContractList.Columns["Id_HopDong"].HeaderText = "ID Hợp đồng";
            dgvContractList.Columns["Id_HopDong"].DisplayIndex = 0;
            dgvContractList.Columns["TenChuTroHienThi"].HeaderText = "Chủ trọ";
            dgvContractList.Columns["TenChuTroHienThi"].DisplayIndex = 1;
            dgvContractList.Columns["TenPhongHienThi"].HeaderText = "Tên phòng";
            dgvContractList.Columns["TenPhongHienThi"].DisplayIndex = 2;
            dgvContractList.Columns["TenNguoiThueHienThi"].HeaderText = "Tên người thuê";
            dgvContractList.Columns["TenNguoiThueHienThi"].DisplayIndex = 3;
            dgvContractList.Columns["CccdHienThi"].HeaderText = "Căn cước công dân";
            dgvContractList.Columns["CccdHienThi"].DisplayIndex = 4;
            dgvContractList.Columns["SdtHienThi"].HeaderText = "Số điện thoại";
            dgvContractList.Columns["SdtHienThi"].DisplayIndex = 5;
            dgvContractList.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            dgvContractList.Columns["NgayBatDau"].DisplayIndex = 6;
            dgvContractList.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            dgvContractList.Columns["NgayKetThuc"].DisplayIndex = 7;
            dgvContractList.Columns["TienCoc"].HeaderText = "Tiền cọc";
            dgvContractList.Columns["TienCoc"].DisplayIndex = 8;

            // Ẩn cột khóa ngoại không cần thiết
            dgvContractList.Columns["Id_Phong"].Visible = false;
            dgvContractList.Columns["PhongTro"].Visible = false;
            dgvContractList.Columns["Id_ChuTro"].Visible = false;
            dgvContractList.Columns["ChuTro"].Visible = false;
            dgvContractList.Columns["Id_NguoiThue"].Visible = false;
            dgvContractList.Columns["NguoiThue"].Visible = false;

            // Cho phép chọn toàn bộ hàng
            dgvContractList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Hàm hỗ trợ xóa nội dung ô nhập liệu
        private void ClearContractInputs()
        {
            txtIdContract.Text = "";
            txtNameAdContract.Text = "";
            txtNameGuestContract.Text = "";
            txtGuestCCCDContract.Text = "";
            txtGuestPhoneNumberContract.Text = "";
            txtNameRoomContract.Text = "";
            dateTimeStart.Value = DateTime.Now;
            dateTimeEnd.Value = DateTime.Now.AddYears(1);
            txtDepositContract.Text = "";
        }

        private void ControlContractMode(bool mode)
        {
            txtIdContract.ReadOnly = !mode;
            txtNameAdContract.ReadOnly = !mode;
            txtNameGuestContract.ReadOnly = !mode;
            txtGuestCCCDContract.ReadOnly = !mode;
            txtGuestPhoneNumberContract.ReadOnly = !mode;
            txtNameRoomContract.ReadOnly = !mode;
            dateTimeStart.Enabled = mode;
            dateTimeEnd.Enabled = mode;
            txtDepositContract.ReadOnly = !mode;
        }

        private void dgvContractList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cần đảm bảo sử dụng dgvContractList
            if (e.RowIndex >= 0 && dgvContractList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvContractList.Rows[e.RowIndex];

                try
                {
                    // Đổ dữ liệu lên TextBox và DateTimePicker
                    txtIdContract.Text = row.Cells["Id_HopDong"].Value.ToString();
                    txtNameAdContract.Text = row.Cells["TenChuTroHienThi"].Value.ToString(); 
                    txtNameRoomContract.Text = row.Cells["TenPhongHienThi"].Value.ToString(); 
                    txtNameGuestContract.Text = row.Cells["TenNguoiThueHienThi"].Value.ToString(); 
                    txtGuestCCCDContract.Text = row.Cells["CccdHienThi"].Value.ToString(); 
                    txtGuestPhoneNumberContract.Text = row.Cells["SdtHienThi"].Value.ToString(); 
                    txtDepositContract.Text = row.Cells["TienCoc"].Value.ToString(); 
                    dateTimeStart.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                    dateTimeEnd.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);

                    // Gán Tiền cọc
                    txtDepositContract.Text = Convert.ToDecimal(row.Cells["TienCoc"].Value).ToString("F0");

                    // Đặt lại các Controls về ReadOnly/Enabled
                    if (!isContractEditing)
                    {
                        ControlContractMode(!isContractEditing);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đổ dữ liệu Hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Nút thêm/chỉnh sửa hợp đồng

        private bool isContractEditing = false;

        private bool SaveContractData()
        {
            // 1. Validation
            if (string.IsNullOrEmpty(txtNameAdContract.Text) || string.IsNullOrEmpty(txtNameGuestContract.Text) || string.IsNullOrEmpty(txtGuestCCCDContract.Text)  || string.IsNullOrEmpty(txtGuestPhoneNumberContract.Text) || string.IsNullOrEmpty(txtDepositContract.Text))
            {
                MessageBox.Show("Không được để trống thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtDepositContract.Text, out decimal tienCoc))
            {
                MessageBox.Show("Tiền cọc phải là một số hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateTimeStart.Value <= dateTimeEnd.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau Ngày bắt đầu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Tạo đối tượng HopDong
            HopDong objHopDong = new HopDong
            {
                Id_ChuTro = idChuTroHienTai, // Key chính để lọc

                NgayBatDau = dateTimeStart.Value,
                NgayKetThuc = dateTimeEnd.Value,
                TienCoc = tienCoc
            };

            // 3. Xử lý Thêm mới / Cập nhật
            if (string.IsNullOrEmpty(txtIdContract.Text))
            {
                // THÊM MỚI
                int newId = HopDongBLL.InsertHopDong(objHopDong);
                return newId > 0;
            }
            else
            {
                // CẬP NHẬT
                if (!int.TryParse(txtIdContract.Text, out int idHopDong))
                {
                    MessageBox.Show("ID Hợp đồng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                objHopDong.Id_HopDong = idHopDong;
                return HopDongBLL.UpdateHopDong(objHopDong);
            }
        }

        //-----Tad 5: Hóa đơn 
        private void LoadListHoaDon()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<HoaDonViewModel>)
                List<HoaDonViewModel> danhsachHoaDon = HoaDonBLL.GetAllHoaDonViewModel(idChuTroHienTai);
                // 2. Gán danh sách trực tiếp vào DataSource
                dgvBillList.DataSource = danhsachHoaDon;

                // 3. Tùy chỉnh hiển thị (Tùy chọn)
                EditGridViewBillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditGridViewBillList()
        {
            this.dgvBillList.AutoGenerateColumns = false;
            // Tùy chỉnh tên cột thân thiện hơn
            dgvBillList.Columns["Id_HoaDon"].HeaderText = "Số hóa đơn";
            dgvBillList.Columns["Id_HoaDon"].DisplayIndex = 0;

            dgvBillList.Columns["TenPhongHienThi"].HeaderText = "Tên phòng";
            dgvBillList.Columns["TenPhongHienThi"].DisplayIndex = 1;

            dgvBillList.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvBillList.Columns["NgayTao"].DisplayIndex = 2;

            dgvBillList.Columns["TienDichVu_HienThi"].HeaderText = "Tiền dịch vụ";
            dgvBillList.Columns["TienDichVu_HienThi"].DisplayIndex = 3;

            dgvBillList.Columns["TienPhong_HienThi"].HeaderText = "Tiền Phòng";
            dgvBillList.Columns["TienPhong_HienThi"].DisplayIndex = 4;


            dgvBillList.Columns["TongTienDien_HienThi"].HeaderText = "Tiền điện";
            dgvBillList.Columns["TongTienDien_HienThi"].DisplayIndex = 5;

            dgvBillList.Columns["TongTienNuoc_HienThi"].HeaderText = "Tiền nước";
            dgvBillList.Columns["TongTienNuoc_HienThi"].DisplayIndex = 6;

            dgvBillList.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvBillList.Columns["ThanhTien"].DisplayIndex = 7;

            dgvBillList.Columns["NoiDung"].HeaderText = "Nội dung";
            dgvBillList.Columns["NoiDung"].DisplayIndex = 8;

            dgvBillList.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvBillList.Columns["TrangThai"].DisplayIndex = 9;

            // Ẩn cột khóa ngoại không cần thiết
            dgvBillList.Columns["Id_Phong"].Visible = false;
            dgvBillList.Columns["PhongTro"].Visible = false;

            dgvBillList.Columns["Nuoc"].Visible = false;
            dgvBillList.Columns["Id_Nuoc"].Visible = false;
            dgvBillList.Columns["ChiSo_Nuoc_Cu_HienThi"].Visible = false;
            dgvBillList.Columns["ChiSo_Nuoc_Moi_HienThi"].Visible = false;

            dgvBillList.Columns["Dien"].Visible = false;
            dgvBillList.Columns["Id_Dien"].Visible = false;
            dgvBillList.Columns["ChiSo_Dien_Cu_HienThi"].Visible = false;
            dgvBillList.Columns["ChiSo_Dien_Moi_HienThi"].Visible = false;

            dgvBillList.Columns["LePhi"].Visible = false;
            dgvBillList.Columns["TongTienLePhi_HienThi"].Visible = false;
            dgvBillList.Columns["Id_LePhi"].Visible = false;

            // Cho phép chọn toàn bộ hàng
            dgvBillList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private bool isBillEditing = false;

        private void ClearDataBill()
        {
            txtIdBill.Text = "";
            txtRoomNameBill.Text = "";
            txtPriceBill.Text = "";
            txtServiceFeeBill.Text = "";
            txtElectricOldReading.Text = "";
            txtElectricNewReading.Text = "";
            txtElectricFee.Text = "";
            txtWaterOldReading.Text = "";
            txtWaterNewReading.Text = "";
            txtWaterFee.Text = "";
            txtTotal.Text = "";
            dateTimeCreate.Value = DateTime.Now;
            txtDetail.Text = "";
            txtBillStatus.Text = "";
        }

        private void ControlDataBill(bool mode)
        {
            txtIdBill.ReadOnly = !mode;
            txtRoomNameBill.ReadOnly = !mode;
            txtPriceBill.ReadOnly = !mode;
            txtServiceFeeBill.ReadOnly = !mode;
            txtElectricOldReading.ReadOnly = !mode;
            txtElectricNewReading.ReadOnly = !mode;
            txtElectricFee.ReadOnly = !mode;
            txtWaterOldReading.ReadOnly = !mode;
            txtWaterNewReading.ReadOnly = !mode;
            txtWaterFee.ReadOnly = !mode;
            txtTotal.ReadOnly = !mode;
            dateTimeCreate.Enabled = mode;
            txtDetail.ReadOnly = !mode;
            txtBillStatus.ReadOnly = !mode;
        }

        private void dgvBillList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo sử dụng DataGridView chính xác (dgvBillList)
            if (e.RowIndex >= 0 && e.RowIndex < dgvBillList.Rows.Count)
            {
                // Chú ý: Chỉ lấy hàng nếu nó được chọn, hoặc đơn giản hơn là lấy theo e.RowIndex
                DataGridViewRow row = dgvBillList.Rows[e.RowIndex];

                try
                {
                    // Kiểm tra giá trị NgayTao có tồn tại trước khi ép kiểu
                    object ngayTaoValue = row.Cells["NgayTao"].Value;

                    // Đổ dữ liệu lên TextBox và DateTimePicker
                    txtIdBill.Text = row.Cells["Id_HoaDon"].Value?.ToString() ?? "";
                    txtRoomNameBill.Text = row.Cells["TenPhongHienThi"].Value?.ToString() ?? "";
                    txtPriceBill.Text = row.Cells["TienPhong_HienThi"].Value?.ToString() ?? "";
                    txtServiceFeeBill.Text = row.Cells["TienDichVu_HienThi"].Value?.ToString() ?? "";
                    txtElectricOldReading.Text = row.Cells["ChiSo_Dien_Cu_HienThi"].Value?.ToString() ?? "";
                    txtElectricNewReading.Text = row.Cells["ChiSo_Dien_Moi_HienThi"].Value?.ToString() ?? "";
                    txtElectricFee.Text = row.Cells["TongTienDien_HienThi"].Value?.ToString() ?? "";
                    txtWaterOldReading.Text = row.Cells["ChiSo_Nuoc_Cu_HienThi"].Value?.ToString() ?? "";
                    txtWaterNewReading.Text = row.Cells["ChiSo_Nuoc_Moi_HienThi"].Value?.ToString() ?? "";
                    txtWaterFee.Text = row.Cells["TongTienNuoc_HienThi"].Value?.ToString() ?? "";

                    txtTotal.Text = row.Cells["ThanhTien"].Value?.ToString() ?? "";
                    txtDetail.Text = row.Cells["NoiDung"].Value?.ToString() ?? "";
                    txtBillStatus.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";

                    // Ép kiểu và gán ngày tháng (Sửa lỗi: NgayTao thay vì NgayBatDau)
                    if (ngayTaoValue != null && ngayTaoValue != DBNull.Value)
                    {
                        dateTimeCreate.Value = Convert.ToDateTime(ngayTaoValue);
                    }
                    else
                    {
                        dateTimeCreate.Value = DateTime.Now; // Gán giá trị mặc định nếu null
                    }
                    ControlDataBill(isBillEditing); 
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đổ dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Hàm sự lý sự kiện ô tìm kiếm
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && txt.Tag != null && txt.Text == txt.Tag.ToString())
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && txt.Tag != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = Color.Gray;
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            // Gán placeholder cho từng TextBox
            txtSearchRoom.Tag = "Nhập tên phòng cần tìm";
            txtSearchGuest.Tag = "Nhập họ tên cần tìm";
            txtSearchContract.Tag = "Nhập mã hợp đồng cần tìm";
            txtSearchBill.Tag = "Nhập số hóa đơn cần tìm";

            // Gán sự kiện dùng chung
            txtSearchRoom.Enter += TextBox_Enter;
            txtSearchRoom.Leave += TextBox_Leave;

            txtSearchGuest.Enter += TextBox_Enter;
            txtSearchGuest.Leave += TextBox_Leave;

            txtSearchContract.Enter += TextBox_Enter;
            txtSearchContract.Leave += TextBox_Leave;

            txtSearchBill.Enter += TextBox_Enter;
            txtSearchBill.Leave += TextBox_Leave;

            // Khởi tạo placeholder ban đầu
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt && txt.Tag != null)
                {
                    txt.Text = txt.Tag.ToString();
                    txt.ForeColor = Color.Gray;
                }
            }

        }
    }
}

