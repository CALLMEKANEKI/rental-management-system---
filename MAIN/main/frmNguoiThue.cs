using BLL.Services;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmNguoiThue : Form
    {
        private nguoithueService _nguoithueSerVice = new nguoithueService();
        private string id_chutrohientai;

        public frmNguoiThue()
        {
            InitializeComponent();
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            LoadDGVNguoiThue();
        }

        public void LoadDGVNguoiThue()
        {
            try
            {
                List<nguoithueViewModel> ListNguoiThue = _nguoithueSerVice.LayTatCaNguoiThueViewModel(id_chutrohientai);
                dgvNguoiThue.DataSource = ListNguoiThue;
                EditDGVNguoiThue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void EditDGVNguoiThue()
        {
            // Tùy chỉnh tên cột thân thiện hơn
            dgvNguoiThue.Columns["IDNguoiThue"].HeaderText = "ID Người Thuê";
            dgvNguoiThue.Columns["IDNguoiThue"].DisplayIndex = 0;
            dgvNguoiThue.Columns["HoTenNguoiThue"].HeaderText = "Họ tên";
            dgvNguoiThue.Columns["HoTenNguoiThue"].DisplayIndex = 1;
            dgvNguoiThue.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvNguoiThue.Columns["SoDienThoai"].DisplayIndex = 2;
            dgvNguoiThue.Columns["CCCD"].HeaderText = "CCCD";
            dgvNguoiThue.Columns["CCCD"].DisplayIndex = 3;
            dgvNguoiThue.Columns["Email"].HeaderText = "Email";
            dgvNguoiThue.Columns["Email"].DisplayIndex = 4;
            dgvNguoiThue.Columns["TenPhong"].HeaderText = "Phòng";
            dgvNguoiThue.Columns["TenPhong"].DisplayIndex = 5;

            // Cho phép chọn toàn bộ hàng
            dgvNguoiThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DGVNguoiThue_CellCLick (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row = dgvNguoiThue.Rows[e.RowIndex];

                
                string selectedID = row.Cells["IDNguoiThue"].Value?.ToString();
                string selectedIDPhong = row.Cells["IDPhong"].Value?.ToString();
                txtID.Text = selectedID;
                txtHoTen.Text = row.Cells["HoTenNguoiThue"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                cboPhong.Text = row.Cells["TenPhong"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDGVNguoiThue();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        /*
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
        */
    }
}
