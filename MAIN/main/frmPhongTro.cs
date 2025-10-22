using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmPhongTro : Form
    {
        private DataTable dtPhong;

        public frmPhongTro()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            LoadData();
        }

        // 📌 Khởi tạo dữ liệu trong bộ nhớ
        private void KhoiTaoDuLieu()
        {
            dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong");
            dtPhong.Columns.Add("TenPhong");
            dtPhong.Columns.Add("GiaThue");
            dtPhong.Columns.Add("TinhTrang");

            // Ví dụ dữ liệu
            dtPhong.Rows.Add("P01", "Phòng 101", "1500000", "Trống");
            dtPhong.Rows.Add("P02", "Phòng 102", "1200000", "Đã thuê");
            dtPhong.Rows.Add("P03", "Phòng 103", "1800000", "Trống");
        }

        // 📌 Load dữ liệu lên DataGridView
        private void LoadData()
        {
            dgvPhongTro.DataSource = dtPhong.Copy();
        }

        // 📌 Thêm phòng
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenPhong.Text == "" || txtGiaThue.Text == "" || cboTinhTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Tạo mã phòng tự động
            string maPhong = "P" + (dtPhong.Rows.Count + 1).ToString("00");
            dtPhong.Rows.Add(maPhong, txtTenPhong.Text, txtGiaThue.Text, cboTinhTrang.Text);

            MessageBox.Show("Thêm phòng thành công!");
            LoadData();
            LamMoi();
        }

        // 📌 Sửa phòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!");
                return;
            }

            DataRow row = dtPhong.AsEnumerable().FirstOrDefault(r => r["MaPhong"].ToString() == txtMaPhong.Text);
            if (row != null)
            {
                row["TenPhong"] = txtTenPhong.Text;
                row["GiaThue"] = txtGiaThue.Text;
                row["TinhTrang"] = cboTinhTrang.Text;

                MessageBox.Show("Cập nhật phòng thành công!");
                LoadData();
                LamMoi();
            }
        }

        // 📌 Xóa phòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow row = dtPhong.AsEnumerable().FirstOrDefault(r => r["MaPhong"].ToString() == txtMaPhong.Text);
                if (row != null)
                    dtPhong.Rows.Remove(row);

                MessageBox.Show("Xóa phòng thành công!");
                LoadData();
                LamMoi();
            }
        }

        // 📌 Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtGiaThue.Clear();
            cboTinhTrang.SelectedIndex = -1;
            txtTenPhong.Focus();
        }

        // 📌 Khi click vào DataGridView
        private void dgvPhongTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhongTro.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();
                txtGiaThue.Text = row.Cells["GiaThue"].Value.ToString();
                cboTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
            }
        }
    }
}
