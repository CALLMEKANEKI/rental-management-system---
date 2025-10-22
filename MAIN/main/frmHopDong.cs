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
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
        }

        // Khi form mở ra
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            // Khởi tạo các combo box
            cboChuTro.Items.AddRange(new string[] { "Nguyễn Văn A", "Trần Thị B", "Lê Văn C" });
            cboPhong.Items.AddRange(new string[] { "Phòng 101", "Phòng 102", "Phòng 103" });
            cboNguoiThue.Items.AddRange(new string[] { "Nguyễn Văn Nam", "Phạm Thị Hoa", "Trần Văn Long" });

            // Tạo cột cho DataGridView
            dgvHopDong.Columns.Add("IDHopDong", "Mã Hợp Đồng");
            dgvHopDong.Columns.Add("ChuTro", "Chủ Trọ");
            dgvHopDong.Columns.Add("Phong", "Phòng Trọ");
            dgvHopDong.Columns.Add("NguoiThue", "Người Thuê");
            dgvHopDong.Columns.Add("NgayBatDau", "Ngày Bắt Đầu");
            dgvHopDong.Columns.Add("NgayKetThuc", "Ngày Kết Thúc");
            dgvHopDong.Columns.Add("TienCoc", "Tiền Cọc");
        }

        // Nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDHopDong.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng!", "Thông báo");
                return;
            }

            dgvHopDong.Rows.Add(
                txtIDHopDong.Text,
                cboChuTro.Text,
                cboPhong.Text,
                cboNguoiThue.Text,
                dtpNgayBatDau.Value.ToShortDateString(),
                dtpNgayKetThuc.Value.ToShortDateString(),
                txtTienCoc.Text
            );

            MessageBox.Show("Thêm hợp đồng thành công!");
        }

        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow != null)
            {
                DataGridViewRow row = dgvHopDong.CurrentRow;
                row.Cells["IDHopDong"].Value = txtIDHopDong.Text;
                row.Cells["ChuTro"].Value = cboChuTro.Text;
                row.Cells["Phong"].Value = cboPhong.Text;
                row.Cells["NguoiThue"].Value = cboNguoiThue.Text;
                row.Cells["NgayBatDau"].Value = dtpNgayBatDau.Value.ToShortDateString();
                row.Cells["NgayKetThuc"].Value = dtpNgayKetThuc.Value.ToShortDateString();
                row.Cells["TienCoc"].Value = txtTienCoc.Text;

                MessageBox.Show("Cập nhật hợp đồng thành công!");
            }
        }

        // Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow != null)
            {
                dgvHopDong.Rows.RemoveAt(dgvHopDong.CurrentRow.Index);
                MessageBox.Show("Xóa hợp đồng thành công!");
            }
        }

        // Nút làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtIDHopDong.Clear();
            cboChuTro.SelectedIndex = -1;
            cboPhong.SelectedIndex = -1;
            cboNguoiThue.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            txtTienCoc.Clear();
        }
    }
}
