using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmThuePhong : Form
    {
        // 🔹 Tạo các bảng dữ liệu trong bộ nhớ
        private DataTable dtPhong;
        private DataTable dtKhachHang;
        private DataTable dtThuePhong;

        public frmThuePhong()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            LoadPhongChuaThue();
            LoadKhachHang();
            LoadDanhSachThue();
        }

        // 📌 Khởi tạo dữ liệu mẫu trong bộ nhớ
        private void KhoiTaoDuLieu()
        {
            // Bảng Phòng
            dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong");
            dtPhong.Columns.Add("TenPhong");
            dtPhong.Columns.Add("TrangThai");

            // Thêm vài phòng mẫu
            dtPhong.Rows.Add("P01", "Phòng 101", "Chưa thuê");
            dtPhong.Rows.Add("P02", "Phòng 102", "Chưa thuê");
            dtPhong.Rows.Add("P03", "Phòng 103", "Đã thuê");

            // Bảng Khách Hàng
            dtKhachHang = new DataTable();
            dtKhachHang.Columns.Add("MaKhach");
            dtKhachHang.Columns.Add("TenKhach");

            dtKhachHang.Rows.Add("KH01", "Nguyễn Văn A");
            dtKhachHang.Rows.Add("KH02", "Trần Thị B");
            dtKhachHang.Rows.Add("KH03", "Lê Văn C");

            // Bảng Thuê Phòng
            dtThuePhong = new DataTable();
            dtThuePhong.Columns.Add("MaThue");
            dtThuePhong.Columns.Add("MaPhong");
            dtThuePhong.Columns.Add("MaKhach");
            dtThuePhong.Columns.Add("NgayDen", typeof(DateTime));
        }

        // 📌 Load danh sách phòng chưa thuê
        private void LoadPhongChuaThue()
        {
            var dsPhong = dtPhong.AsEnumerable()
                .Where(row => row["TrangThai"].ToString() == "Chưa thuê");

            if (dsPhong.Any())
            {
                cboPhong.DataSource = dsPhong.CopyToDataTable();
                cboPhong.DisplayMember = "TenPhong";
                cboPhong.ValueMember = "MaPhong";
            }
            else
            {
                cboPhong.DataSource = null;
            }
        }

        // 📌 Load danh sách khách hàng
        private void LoadKhachHang()
        {
            cboKhach.DataSource = dtKhachHang;
            cboKhach.DisplayMember = "TenKhach";
            cboKhach.ValueMember = "MaKhach";
        }

        // 📌 Load danh sách thuê phòng vào DataGridView
        private void LoadDanhSachThue()
        {
            // Gộp 3 bảng bằng LINQ
            var query = from tp in dtThuePhong.AsEnumerable()
                        join p in dtPhong.AsEnumerable() on tp["MaPhong"] equals p["MaPhong"]
                        join kh in dtKhachHang.AsEnumerable() on tp["MaKhach"] equals kh["MaKhach"]
                        select new
                        {
                            MaThue = tp["MaThue"],
                            TenPhong = p["TenPhong"],
                            TenKhach = kh["TenKhach"],
                            NgayDen = tp["NgayDen"]
                        };

            dgvThuePhong.DataSource = query.ToList();
        }

        // 📌 Nút Thêm phòng thuê
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboPhong.SelectedIndex == -1 || cboKhach.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng và khách hàng!");
                return;
            }

            // Sinh mã thuê tự động
            string maThue = "TP" + (dtThuePhong.Rows.Count + 1).ToString("00");
            string maPhong = cboPhong.SelectedValue.ToString();
            string maKhach = cboKhach.SelectedValue.ToString();

            // Thêm vào danh sách thuê
            dtThuePhong.Rows.Add(maThue, maPhong, maKhach, dtpNgayDen.Value);

            // Cập nhật trạng thái phòng
            DataRow phong = dtPhong.AsEnumerable()
                .FirstOrDefault(p => p["MaPhong"].ToString() == maPhong);
            if (phong != null)
                phong["TrangThai"] = "Đã thuê";

            MessageBox.Show("Thêm phòng thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadPhongChuaThue();
            LoadDanhSachThue();
        }

        // 📌 Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
