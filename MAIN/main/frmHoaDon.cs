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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tienPhong = decimal.Parse(txtTienPhong.Text);
                decimal tienDien = decimal.Parse(txtTienDien.Text);
                decimal tienNuoc = decimal.Parse(txtTienNuoc.Text);
                decimal lePhi = decimal.Parse(txtLePhi.Text);

                decimal tong = tienPhong + tienDien + tienNuoc + lePhi;
                txtTongTien.Text = tong.ToString("N0"); // format tiền tệ
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Clear();
            cboPhong.SelectedIndex = -1;
            dtpThang.Value = DateTime.Now;
            txtTienPhong.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtLePhi.Clear();
            txtTongTien.Clear();
        }

        // Thêm hóa đơn (ví dụ lưu vào DataGridView)
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                MessageBox.Show("Mã hóa đơn không được để trống!");
                return;
            }

            dgvHoaDon.Rows.Add(
                txtMaHoaDon.Text,
                cboPhong.Text,
                dtpThang.Text,
                txtTienPhong.Text,
                txtTienDien.Text,
                txtTienNuoc.Text,
                txtLePhi.Text,
                txtTongTien.Text
            );

            MessageBox.Show("Thêm hóa đơn thành công!");
        }

        // Xóa hóa đơn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                dgvHoaDon.Rows.RemoveAt(dgvHoaDon.CurrentRow.Index);
            }
        }

        // Sửa thông tin hóa đơn
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                DataGridViewRow row = dgvHoaDon.CurrentRow;
                row.Cells[0].Value = txtMaHoaDon.Text;
                row.Cells[1].Value = cboPhong.Text;
                row.Cells[2].Value = dtpThang.Text;
                row.Cells[3].Value = txtTienPhong.Text;
                row.Cells[4].Value = txtTienDien.Text;
                row.Cells[5].Value = txtTienNuoc.Text;
                row.Cells[6].Value = txtLePhi.Text;
                row.Cells[7].Value = txtTongTien.Text;

                MessageBox.Show("Cập nhật thành công!");
            }
        }
    }
}
