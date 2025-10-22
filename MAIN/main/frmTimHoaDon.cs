using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmTimHoaDon : Form
    {
        private DataTable dtHoaDon;
        private DataTable dtPhong;
        private DataTable dtKhachHang;

        public frmTimHoaDon()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            cboTimTheo.SelectedIndex = 0; // Mặc định tìm theo Mã hóa đơn
        }

        // 📌 Tạo dữ liệu mẫu trong bộ nhớ (không cần SQL)
        private void KhoiTaoDuLieu()
        {
            // Bảng Phòng
            dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong");
            dtPhong.Columns.Add("TenPhong");
            dtPhong.Rows.Add("P01", "Phòng 101");
            dtPhong.Rows.Add("P02", "Phòng 102");
            dtPhong.Rows.Add("P03", "Phòng 103");

            // Bảng Khách Hàng
            dtKhachHang = new DataTable();
            dtKhachHang.Columns.Add("MaKhach");
            dtKhachHang.Columns.Add("TenKhach");
            dtKhachHang.Rows.Add("KH01", "Nguyễn Văn A");
            dtKhachHang.Rows.Add("KH02", "Trần Thị B");
            dtKhachHang.Rows.Add("KH03", "Lê Văn C");

            // Bảng Hóa Đơn
            dtHoaDon = new DataTable();
            dtHoaDon.Columns.Add("MaHoaDon");
            dtHoaDon.Columns.Add("MaPhong");
            dtHoaDon.Columns.Add("MaKhach");
            dtHoaDon.Columns.Add("NgayLap", typeof(DateTime));
            dtHoaDon.Columns.Add("TongTien", typeof(double));

            // Dữ liệu ví dụ
            dtHoaDon.Rows.Add("HD01", "P01", "KH01", DateTime.Now.AddDays(-5), 1200000);
            dtHoaDon.Rows.Add("HD02", "P02", "KH02", DateTime.Now.AddDays(-3), 950000);
            dtHoaDon.Rows.Add("HD03", "P03", "KH03", DateTime.Now.AddDays(-1), 1350000);
        }

        // 📌 Nút Tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            string timTheo = cboTimTheo.Text;
            string noiDung = txtNoiDung.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gộp dữ liệu 3 bảng bằng LINQ
            var query = from hd in dtHoaDon.AsEnumerable()
                        join p in dtPhong.AsEnumerable() on hd["MaPhong"] equals p["MaPhong"]
                        join kh in dtKhachHang.AsEnumerable() on hd["MaKhach"] equals kh["MaKhach"]
                        select new
                        {
                            MaHoaDon = hd["MaHoaDon"].ToString(),
                            TenPhong = p["TenPhong"].ToString(),
                            TenKhach = kh["TenKhach"].ToString(),
                            NgayLap = ((DateTime)hd["NgayLap"]).ToString("dd/MM/yyyy"),
                            TongTien = ((double)hd["TongTien"]).ToString("N0")
                        };

            // Lọc theo nội dung tìm kiếm
            if (timTheo == "Mã hóa đơn")
            {
                query = query.Where(hd => hd.MaHoaDon.ToLower().Contains(noiDung));
            }
            else if (timTheo == "Tên phòng")
            {
                query = query.Where(hd => hd.TenPhong.ToLower().Contains(noiDung));
            }

            var ketQua = query.ToList();

            dgvKetQua.DataSource = ketQua;

            if (ketQua.Count == 0)
                MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 📌 Nút Xóa hóa đơn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKetQua.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHD = dgvKetQua.CurrentRow.Cells["MaHoaDon"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa hóa đơn {maHD} không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa trong bảng gốc
                var row = dtHoaDon.AsEnumerable().FirstOrDefault(r => r["MaHoaDon"].ToString() == maHD);
                if (row != null)
                    dtHoaDon.Rows.Remove(row);

                MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới kết quả tìm kiếm
                btnTim.PerformClick();
            }
        }

        // 📌 Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
