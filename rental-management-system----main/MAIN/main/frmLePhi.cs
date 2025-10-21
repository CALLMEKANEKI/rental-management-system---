using System;
using System.Data;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmLePhi : Form
    {
        private DataTable dtLePhi;   // bảng tạm lưu dữ liệu lệ phí
        private DataTable dtPhong;   // bảng tạm lưu danh sách phòng

        public frmLePhi()
        {
            InitializeComponent();
            this.Load += frmLePhi_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTinhTien.Click += btnTinhTien_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvLePhi.SelectionChanged += dgvLePhi_SelectionChanged;
        }

        // Khi form mở
        private void frmLePhi_Load(object sender, EventArgs e)
        {
            // Khởi tạo bảng Lệ phí (rỗng)
            dtLePhi = new DataTable();
            dtLePhi.Columns.Add("MaLePhi");
            dtLePhi.Columns.Add("Phong");
            dtLePhi.Columns.Add("TienDV", typeof(decimal));
            dtLePhi.Columns.Add("ThanhTien", typeof(decimal));
            dgvLePhi.DataSource = dtLePhi;

            // Khởi tạo bảng phòng (rỗng)
            dtPhong = new DataTable();
            dtPhong.Columns.Add("TenPhong");
            dtPhong.Columns.Add("GiaPhong", typeof(decimal));

            // Xóa combobox cũ
            cboPhong.Items.Clear();
        }

        // Nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLePhi.Text) || string.IsNullOrWhiteSpace(cboPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            DataRow newRow = dtLePhi.NewRow();
            newRow["MaLePhi"] = txtMaLePhi.Text;
            newRow["Phong"] = cboPhong.Text;
            newRow["TienDV"] = string.IsNullOrWhiteSpace(txtTienDV.Text) ? 0 : Convert.ToDecimal(txtTienDV.Text);
            newRow["ThanhTien"] = string.IsNullOrWhiteSpace(txtThanhTien.Text) ? 0 : Convert.ToDecimal(txtThanhTien.Text);
            dtLePhi.Rows.Add(newRow);

            MessageBox.Show("Thêm lệ phí thành công!");
        }

        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLePhi.CurrentRow == null)
            {
                MessageBox.Show("Chọn dòng cần sửa!");
                return;
            }

            dgvLePhi.CurrentRow.Cells["MaLePhi"].Value = txtMaLePhi.Text;
            dgvLePhi.CurrentRow.Cells["Phong"].Value = cboPhong.Text;
            dgvLePhi.CurrentRow.Cells["TienDV"].Value = txtTienDV.Text;
            dgvLePhi.CurrentRow.Cells["ThanhTien"].Value = txtThanhTien.Text;

            MessageBox.Show("Sửa thành công!");
        }

        // Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLePhi.CurrentRow == null)
            {
                MessageBox.Show("Chọn dòng cần xóa!");
                return;
            }

            dgvLePhi.Rows.RemoveAt(dgvLePhi.CurrentRow.Index);
            MessageBox.Show("Xóa thành công!");
        }

        // Nút tính tiền
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên phòng!");
                return;
            }

            decimal tienDV = 0;
            decimal.TryParse(txtTienDV.Text, out tienDV);

            // Tìm giá phòng nếu có trong bảng phòng
            decimal giaPhong = 0;
            DataRow[] rows = dtPhong.Select($"TenPhong = '{cboPhong.Text}'");
            if (rows.Length > 0)
                giaPhong = Convert.ToDecimal(rows[0]["GiaPhong"]);

            decimal thanhTien = tienDV + giaPhong;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        // Nút làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLePhi.Clear();
            cboPhong.SelectedIndex = -1;
            txtTienDV.Clear();
            txtThanhTien.Clear();
        }

        // Khi chọn dòng trong DataGridView
        private void dgvLePhi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLePhi.CurrentRow != null)
            {
                txtMaLePhi.Text = dgvLePhi.CurrentRow.Cells["MaLePhi"].Value?.ToString();
                cboPhong.Text = dgvLePhi.CurrentRow.Cells["Phong"].Value?.ToString();
                txtTienDV.Text = dgvLePhi.CurrentRow.Cells["TienDV"].Value?.ToString();
                txtThanhTien.Text = dgvLePhi.CurrentRow.Cells["ThanhTien"].Value?.ToString();
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }
    }
}
