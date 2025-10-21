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
    public partial class QLKHACH : Form
    {

        private DataTable dtKhach;
        public QLKHACH()
        {
            InitializeComponent();
            InitTable();
            dgvKhach.DataSource = dtKhach;
        }

        private void InitTable()
        {
            dtKhach = new DataTable();
            dtKhach.Columns.Add("Tên");
            dtKhach.Columns.Add("SĐT");
            dtKhach.Columns.Add("Email");
            dtKhach.Columns.Add("Địa chỉ");
            dtKhach.Columns.Add("Giới tính");
        }

        private void ClearFields()
        {
            txtTen.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cbGioiTinh.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên và SĐT!");
                return;
            }

            dtKhach.Rows.Add(txtTen.Text, txtSDT.Text, txtEmail.Text, txtDiaChi.Text, cbGioiTinh.Text);
            ClearFields();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhach.CurrentRow != null)
            {
                dgvKhach.Rows.RemoveAt(dgvKhach.CurrentRow.Index);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhach.CurrentRow != null)
            {
                var row = dgvKhach.CurrentRow;
                row.Cells["Tên"].Value = txtTen.Text;
                row.Cells["SĐT"].Value = txtSDT.Text;
                row.Cells["Email"].Value = txtEmail.Text;
                row.Cells["Địa chỉ"].Value = txtDiaChi.Text;
                row.Cells["Giới tính"].Value = cbGioiTinh.Text;
            }
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhach.Rows[e.RowIndex];
                txtTen.Text = row.Cells["Tên"].Value?.ToString();
                txtSDT.Text = row.Cells["SĐT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtDiaChi.Text = row.Cells["Địa chỉ"].Value?.ToString();
                cbGioiTinh.Text = row.Cells["Giới tính"].Value?.ToString();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void QLKHACH_Load(object sender, EventArgs e)
        {

        }
    }
}

