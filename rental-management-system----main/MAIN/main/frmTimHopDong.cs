using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmTimHopDong : Form
    {
        private DataTable dtHopDong;
        private DataTable dtPhong;

        public frmTimHopDong()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            cboTimTheo.SelectedIndex = 0; // mặc định tìm theo Mã hợp đồng
        }

        // 📌 Khởi tạo dữ liệu bộ nhớ
        private void KhoiTaoDuLieu()
        {
            // Bảng Phòng
            dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong");
            dtPhong.Columns.Add("TenPhong");
            dtPhong.Rows.Add("P01", "Phòng 101");
            dtPhong.Rows.Add("P02", "Phòng 102");
            dtPhong.Rows.Add("P03", "Phòng 103");

            // Bảng Hợp Đồng
            dtHopDong = new DataTable();
            dtHopDong.Columns.Add("MaHopDong");
            dtHopDong.Columns.Add("MaPhong");
            dtHopDong.Columns.Add("TenPhong");
            dtHopDong.Columns.Add("NgayLap", typeof(DateTime));
            dtHopDong.Columns.Add("GiaPhong", typeof(double));

            // Thêm dữ liệu ví dụ
            dtHopDong.Rows.Add("HD01", "P01", "Phòng 101", DateTime.Now.AddDays(-10), 1500000);
            dtHopDong.Rows.Add("HD02", "P02", "Phòng 102", DateTime.Now.AddDays(-5), 1200000);
            dtHopDong.Rows.Add("HD03", "P03", "Phòng 103", DateTime.Now.AddDays(-2), 1800000);
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

            // Tìm kiếm trực tiếp trên DataTable
            DataRow[] ketQua = null;

            if (timTheo == "Mã hợp đồng")
            {
                ketQua = dtHopDong.Select($"MaHopDong LIKE '%{noiDung}%'");
            }
            else if (timTheo == "Tên phòng")
            {
                ketQua = dtHopDong.Select($"TenPhong LIKE '%{noiDung}%'");
            }

            // Chuyển kết quả về DataTable để hiển thị
            DataTable dtKetQua = ketQua.Length > 0 ? ketQua.CopyToDataTable() : new DataTable();
            dgvKetQua.DataSource = dtKetQua;

            if (ketQua.Length == 0)
                MessageBox.Show("Không tìm thấy hợp đồng phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 📌 Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNoiDung.Clear();
            dgvKetQua.DataSource = null;
        }

        // 📌 Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
