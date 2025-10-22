using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmTimKhachThue : Form
    {
        private DataTable dtKhachThue;

        public frmTimKhachThue()
        {
            InitializeComponent();

            // Thiết lập ComboBox tìm kiếm
            cboTimTheo.Items.Clear();
            cboTimTheo.Items.Add("Mã khách thuê");
            cboTimTheo.Items.Add("Tên khách thuê");
            cboTimTheo.Items.Add("Số điện thoại");
            cboTimTheo.Items.Add("CMND/CCCD");
            cboTimTheo.SelectedIndex = 0;

            KhoiTaoDuLieu();
        }

        // 📌 Tạo dữ liệu tạm trong bộ nhớ (DataTable)
        private void KhoiTaoDuLieu()
        {
            dtKhachThue = new DataTable();
            dtKhachThue.Columns.Add("MaKhachThue");
            dtKhachThue.Columns.Add("TenKhachThue");
            dtKhachThue.Columns.Add("SoDienThoai");
            dtKhachThue.Columns.Add("CMND");

            // Bạn có thể thêm dữ liệu mẫu hoặc để trống
            // dtKhachThue.Rows.Add("KH01", "Nguyen Van A", "0901234567", "123456789");
        }

        // 📌 Nút Tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            string timTheo = cboTimTheo.Text;
            string noiDung = txtNoiDung.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ketQua = dtKhachThue.AsEnumerable();

            switch (timTheo)
            {
                case "Mã khách thuê":
                    ketQua = ketQua.Where(r => r["MaKhachThue"].ToString().ToLower().Contains(noiDung));
                    break;
                case "Tên khách thuê":
                    ketQua = ketQua.Where(r => r["TenKhachThue"].ToString().ToLower().Contains(noiDung));
                    break;
                case "Số điện thoại":
                    ketQua = ketQua.Where(r => r["SoDienThoai"].ToString().ToLower().Contains(noiDung));
                    break;
                case "CMND/CCCD":
                    ketQua = ketQua.Where(r => r["CMND"].ToString().ToLower().Contains(noiDung));
                    break;
            }

            dgvKetQua.DataSource = ketQua.CopyToDataTableOrNull();

            if (dgvKetQua.DataSource == null)
            {
                dgvKetQua.DataSource = null;
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 📌 Nút Xóa (làm mới)
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

    // 🔹 Extension method để xử lý trường hợp kết quả LINQ rỗng
    public static class DataTableExtensions
    {
        public static DataTable CopyToDataTableOrNull(this IEnumerable<DataRow> rows)
        {
            return rows.Any() ? rows.CopyToDataTable() : null;
        }
    }
}
