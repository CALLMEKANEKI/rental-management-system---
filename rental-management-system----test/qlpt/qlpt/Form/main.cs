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

        ///-----Tad 2: Phòng trọ
        private void LoadListPhongTro()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<PhongTro>)
                List<PhongTro> danhSachPhong = phongTroBLL.GetALlPhong();

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

        ///-----Tad 3: Người thuê 

        private void LoadListNguoiThue()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<NguoiThueViewModel>)
                List<NguoiThueViewModel> danhsachNguoiThue = NguoiThueBLL.GetAllNguoiThueViewModel();

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


        ///-----Tad 4: Hợp đồng 
        private void LoadListHopDong()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<HopDongViewModel>)
                List<HopDongViewModel> danhsachHopDong = HopDongBLL.GetAllHopDongViewModel();

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
            dgvContractList.Columns["CccdHienThi"].DisplayIndex = 2;
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

        //-----Tad 5: Hóa đơn - Need Update
        private void LoadListHoaDon()
        {
            try
            {
                // 1. Gọi BLL để lấy danh sách (List<HoaDonViewModel>)
                List<HoaDonViewModel> danhsachHoaDon = HoaDonBLL.GetAllHoaDonViewModel();

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


        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}

