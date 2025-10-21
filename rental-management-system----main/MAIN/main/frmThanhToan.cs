using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmThanhToan : Form
    {
        private DataTable dtThanhToan;
        private DataTable dtNguoiThue;
        private DataTable dtHoaDon;

        public frmThanhToan()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            LoadData();
            LoadNguoiThue();
            LoadHoaDon();
        }

        // 🔹 Tạo dữ liệu trống ban đầu (không SQL)
        private void KhoiTaoDuLieu()
        {
            // Bảng ThanhToan
            dtThanhToan = new DataTable();
            dtThanhToan.Columns.Add("MaThanhToan");
            dtThanhToan.Columns.Add("MaNguoiThue");
            dtThanhToan.Columns.Add("MaHoaDon");
            dtThanhToan.Columns.Add("NgayThanhToan", typeof(DateTime));
            dtThanhToan.Columns.Add("SoTien");
            dtThanhToan.Columns.Add("TrangThai");

            // Bảng NguoiThue
            dtNguoiThue = new DataTable();
            dtNguoiThue.Columns.Add("MaNguoiThue");
            dtNguoiThue.Columns.Add("HoTen");

            // Bảng HoaDon
            dtHoaDon = new DataTable();
            dtHoaDon.Columns.Add("MaHoaDon");
        }

        private void LoadData()
        {
            dgvThanhToan.DataSource = dtThanhToan;
        }

        private void LoadNguoiThue()
        {
            cboNguoiThue.DataSource = dtNguoiThue;
            cboNguoiThue.DisplayMember = "HoTen";
            cboNguoiThue.ValueMember = "MaNguoiThue";
            cboNguoiThue.SelectedIndex = -1;
        }

        private void LoadHoaDon()
        {
            cboHoaDon.DataSource = dtHoaDon;
            cboHoaDon.DisplayMember = "MaHoaDon";
            cboHoaDon.ValueMember = "MaHoaDon";
            cboHoaDon.SelectedIndex = -1;
        }

        // 🔹 Thêm người thuê (tùy chọn, vì không có SQL)
        private void btnThemNguoiThue_Click(object sender, EventArgs e)
        {
            string ma = "NT" + (dtNguoiThue.Rows.Count + 1).ToString("00");
            string ten = "Người thuê " + (dtNguoiThue.Rows.Count + 1);
            dtNguoiThue.Rows.Add(ma, ten);
            LoadNguoiThue();
            MessageBox.Show("Đã thêm người thuê mẫu!");
        }

        // 🔹 Thêm hóa đơn (tùy chọn)
        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = "HD" + (dtHoaDon.Rows.Count + 1).ToString("00");
            dtHoaDon.Rows.Add(maHD);
            LoadHoaDon();
            MessageBox.Show("Đã thêm hóa đơn mẫu!");
        }

        // 🔹 Thêm thanh toán
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboNguoiThue.SelectedIndex == -1 || cboHoaDon.SelectedIndex == -1 || txtSoTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string maTT = "TT" + (dtThanhToan.Rows.Count + 1).ToString("00");
            dtThanhToan.Rows.Add(
                maTT,
                cboNguoiThue.SelectedValue.ToString(),
                cboHoaDon.SelectedValue.ToString(),
                dtpNgayThanhToan.Value,
                txtSoTien.Text,
                cboTrangThai.Text
            );

            MessageBox.Show("Thêm thanh toán thành công!");
            LoadData();
            LamMoi();
        }

        // 🔹 Sửa thanh toán
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaThanhToan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần sửa!");
                return;
            }

            DataRow row = dtThanhToan.Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => r["MaThanhToan"].ToString() == txtMaThanhToan.Text);

            if (row != null)
            {
                row["MaNguoiThue"] = cboNguoiThue.SelectedValue?.ToString();
                row["MaHoaDon"] = cboHoaDon.SelectedValue?.ToString();
                row["NgayThanhToan"] = dtpNgayThanhToan.Value;
                row["SoTien"] = txtSoTien.Text;
                row["TrangThai"] = cboTrangThai.Text;

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
                LamMoi();
            }
        }

        // 🔹 Xóa thanh toán
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaThanhToan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa!");
                return;
            }

            DataRow row = dtThanhToan.Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => r["MaThanhToan"].ToString() == txtMaThanhToan.Text);

            if (row != null)
            {
                dtThanhToan.Rows.Remove(row);
                MessageBox.Show("Xóa thành công!");
                LoadData();
                LamMoi();
            }
        }

        // 🔹 Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaThanhToan.Clear();
            cboNguoiThue.SelectedIndex = -1;
            cboHoaDon.SelectedIndex = -1;
            txtSoTien.Clear();
            cboTrangThai.SelectedIndex = -1;
            dtpNgayThanhToan.Value = DateTime.Now;
        }

        // 🔹 Click dòng dgv → đổ dữ liệu lên control
        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThanhToan.Rows[e.RowIndex];
                txtMaThanhToan.Text = row.Cells["MaThanhToan"].Value.ToString();
                cboNguoiThue.SelectedValue = row.Cells["MaNguoiThue"].Value.ToString();
                cboHoaDon.SelectedValue = row.Cells["MaHoaDon"].Value.ToString();
                dtpNgayThanhToan.Value = Convert.ToDateTime(row.Cells["NgayThanhToan"].Value);
                txtSoTien.Text = row.Cells["SoTien"].Value.ToString();
                cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }
    }
}
