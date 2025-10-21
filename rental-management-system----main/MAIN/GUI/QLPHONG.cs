using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlpt.GUI
{
    public partial class QLPHONG : Form
    {
        private DataTable dtPhong;
        public QLPHONG()
        {
            InitializeComponent();
            InitTable();
            dgvPhong.DataSource = dtPhong;
        }
        private void InitTable()
        {
            dtPhong = new DataTable();
            dtPhong.Columns.Add("Mã phòng");
            dtPhong.Columns.Add("Tên phòng");
            dtPhong.Columns.Add("Giá phòng");
            dtPhong.Columns.Add("Tình trạng");
        }

        private void ClearFields()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtGiaPhong.Text = "";
            cbTinhTrang.SelectedIndex = -1;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "" || txtTenPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng!");
                return;
            }

            dtPhong.Rows.Add(txtMaPhong.Text, txtTenPhong.Text, txtGiaPhong.Text, cbTinhTrang.Text);
            ClearFields();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow != null)
            {
                var row = dgvPhong.CurrentRow;
                row.Cells["Mã phòng"].Value = txtMaPhong.Text;
                row.Cells["Tên phòng"].Value = txtTenPhong.Text;
                row.Cells["Giá phòng"].Value = txtGiaPhong.Text;
                row.Cells["Tình trạng"].Value = cbTinhTrang.Text;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow != null)
            {
                dgvPhong.Rows.RemoveAt(dgvPhong.CurrentRow.Index);
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["Mã phòng"].Value?.ToString();
                txtTenPhong.Text = row.Cells["Tên phòng"].Value?.ToString();
                txtGiaPhong.Text = row.Cells["Giá phòng"].Value?.ToString();
                cbTinhTrang.Text = row.Cells["Tình trạng"].Value?.ToString();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QLPHONG_Load(object sender, EventArgs e)
        {

        }
    }
}
