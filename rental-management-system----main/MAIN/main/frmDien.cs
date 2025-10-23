using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmDien : Form
    {
        private DataTable dtDien;

        public frmDien()
        {
            InitializeComponent();
            KhoiTaoBang();
        }

        private void KhoiTaoBang()
        {
            // Tạo bảng dữ liệu tiền điện
            dtDien = new DataTable();
            dtDien.Columns.Add("Mã điện");
            dtDien.Columns.Add("Phòng trọ");
            dtDien.Columns.Add("Chỉ số cũ");
            dtDien.Columns.Add("Chỉ số mới");
            dtDien.Columns.Add("Điện tiêu thụ");
            dtDien.Columns.Add("Tiền điện");
            dtDien.Columns.Add("Tháng");

            dgvDien.DataSource = dtDien;

            // Giả sử có sẵn danh sách phòng
            cboPhong.Items.AddRange(new string[] { "P101", "P102", "P103", "P104" });

            // Gán sự kiện
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTinhTien.Click += btnTinhTien_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvDien.CellClick += dgvDien_CellClick;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDien.Text) || cboPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập mã điện và chọn phòng trọ!", "Thông báo");
                return;
            }

            // Thêm dữ liệu vào DataTable
            dtDien.Rows.Add(
                txtMaDien.Text,
                cboPhong.SelectedItem.ToString(),
                txtChiSoCu.Text,
                txtChiSoMoi.Text,
                txtSoDienTieuThu.Text,
                txtTienDien.Text,
                dtpThang.Value.ToString("MM/yyyy")
            );

            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            int index = dgvDien.CurrentRow.Index;
            dtDien.Rows[index]["Mã điện"] = txtMaDien.Text;
            dtDien.Rows[index]["Phòng trọ"] = cboPhong.SelectedItem?.ToString();
            dtDien.Rows[index]["Chỉ số cũ"] = txtChiSoCu.Text;
            dtDien.Rows[index]["Chỉ số mới"] = txtChiSoMoi.Text;
            dtDien.Rows[index]["Điện tiêu thụ"] = txtSoDienTieuThu.Text;
            dtDien.Rows[index]["Tiền điện"] = txtTienDien.Text;
            dtDien.Rows[index]["Tháng"] = dtpThang.Value.ToString("MM/yyyy");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            int index = dgvDien.CurrentRow.Index;
            dtDien.Rows.RemoveAt(index);
            LamMoi();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtChiSoCu.Text, out double chiSoCu) ||
                !double.TryParse(txtChiSoMoi.Text, out double chiSoMoi))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng chỉ số!", "Lỗi");
                return;
            }

            if (chiSoMoi < chiSoCu)
            {
                MessageBox.Show("Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ!", "Lỗi");
                return;
            }

            double soDien = chiSoMoi - chiSoCu;
            txtSoDienTieuThu.Text = soDien.ToString();

            // Tính tiền điện theo bậc (đơn giản)
            double donGia = 3500; // 1 kWh = 3500 VNĐ
            double tienDien = soDien * donGia;

            txtTienDien.Text = tienDien.ToString("N0");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaDien.Clear();
            cboPhong.SelectedIndex = -1;
            txtChiSoCu.Clear();
            txtChiSoMoi.Clear();
            txtSoDienTieuThu.Clear();
            txtTienDien.Clear();
            dtpThang.Value = DateTime.Now;
        }

        private void dgvDien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDien.Rows[e.RowIndex];
                txtMaDien.Text = row.Cells["Mã điện"].Value?.ToString();
                cboPhong.Text = row.Cells["Phòng trọ"].Value?.ToString();
                txtChiSoCu.Text = row.Cells["Chỉ số cũ"].Value?.ToString();
                txtChiSoMoi.Text = row.Cells["Chỉ số mới"].Value?.ToString();
                txtSoDienTieuThu.Text = row.Cells["Điện tiêu thụ"].Value?.ToString();
                txtTienDien.Text = row.Cells["Tiền điện"].Value?.ToString();

                string thang = row.Cells["Tháng"].Value?.ToString();
                if (DateTime.TryParse("01/" + thang, out DateTime dt))
                    dtpThang.Value = dt;
            }
        }
    }
}
