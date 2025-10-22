using System;
using System.Data;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmNguoiThue : Form
    {
        private DataTable dtNguoiThue;   // Lưu tạm danh sách người thuê
        private DataTable dtPhong;       // Lưu danh sách phòng

        public frmNguoiThue()
        {
            InitializeComponent();
            this.Load += frmNguoiThue_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvNguoiThue.CellClick += dgvNguoiThue_CellClick;
        }

        // Khi form mở ra
        private void frmNguoiThue_Load(object sender, EventArgs e)
        {
            // 🔹 Khởi tạo bảng người thuê
            dtNguoiThue = new DataTable();
            dtNguoiThue.Columns.Add("ID");
            dtNguoiThue.Columns.Add("HoTen");
            dtNguoiThue.Columns.Add("CCCD");
            dtNguoiThue.Columns.Add("SDT");
            dtNguoiThue.Columns.Add("Email");
            dtNguoiThue.Columns.Add("MaPhong");
            dgvNguoiThue.DataSource = dtNguoiThue;

            // 🔹 Khởi tạo bảng phòng (trống)
            dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong");
            dtPhong.Columns.Add("TenPhong");

            // Combobox phòng (rỗng, cho phép tự nhập nếu muốn)
            cboPhong.DataSource = null;
            cboPhong.Items.Clear();
        }

        // 🔹 Thêm người thuê
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(cboPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            DataRow newRow = dtNguoiThue.NewRow();
            newRow["ID"] = string.IsNullOrWhiteSpace(txtID.Text) ? (dtNguoiThue.Rows.Count + 1).ToString() : txtID.Text;
            newRow["HoTen"] = txtHoTen.Text;
            newRow["CCCD"] = txtCCCD.Text;
            newRow["SDT"] = txtSDT.Text;
            newRow["Email"] = txtEmail.Text;
            newRow["MaPhong"] = cboPhong.Text;
            dtNguoiThue.Rows.Add(newRow);

            MessageBox.Show("Thêm người thuê thành công!");
        }

        // 🔹 Sửa người thuê
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNguoiThue.CurrentRow == null)
            {
                MessageBox.Show("Chọn dòng cần sửa!");
                return;
            }

            dgvNguoiThue.CurrentRow.Cells["HoTen"].Value = txtHoTen.Text;
            dgvNguoiThue.CurrentRow.Cells["CCCD"].Value = txtCCCD.Text;
            dgvNguoiThue.CurrentRow.Cells["SDT"].Value = txtSDT.Text;
            dgvNguoiThue.CurrentRow.Cells["Email"].Value = txtEmail.Text;
            dgvNguoiThue.CurrentRow.Cells["MaPhong"].Value = cboPhong.Text;

            MessageBox.Show("Cập nhật thành công!");
        }

        // 🔹 Xóa người thuê
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNguoiThue.CurrentRow == null)
            {
                MessageBox.Show("Chọn dòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgvNguoiThue.Rows.RemoveAt(dgvNguoiThue.CurrentRow.Index);
                MessageBox.Show("Xóa thành công!");
            }
        }

        // 🔹 Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            cboPhong.SelectedIndex = -1;
        }

        // 🔹 Khi click vào dòng → hiển thị thông tin
        private void dgvNguoiThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiThue.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                cboPhong.Text = row.Cells["MaPhong"].Value?.ToString();
            }
        }
    }
}
