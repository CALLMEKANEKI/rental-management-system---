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
    public partial class QLTRA : Form
    {
        DataTable dtKhach = new DataTable();
        DataTable dtThue = new DataTable();
        public QLTRA()
        {
            InitializeComponent();
            KhoiTaoBang();
        }
        private void KhoiTaoBang()
        {
            dtKhach.Columns.Add("Mã KH");
            dtKhach.Columns.Add("Tên KH");
            dtKhach.Columns.Add("SĐT");
            dgvKhachHang.DataSource = dtKhach;

            dtThue.Columns.Add("Mã Thuê Phòng");
            dtThue.Columns.Add("Mã KH");
            dtThue.Columns.Add("Mã Phòng");
            dtThue.Columns.Add("Ngày Đến");
            dtThue.Columns.Add("Ngày Đi");
            dgvThuePhong.DataSource = dtThue;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo");
                return;
            }

            dtKhach.Rows.Add(dtKhach.Rows.Count + 1, txtTimTen.Text, "0123456789");
            MessageBox.Show("Tìm kiếm và thêm tạm thời khách hàng!", "Thông báo");
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng!", "Thông báo");
                return;
            }

            dtThue.Rows.Add(dtThue.Rows.Count + 1, txtTenKH.Text, "P101", "1/1/2025", dtpNgayDi.Value.ToShortDateString());
            MessageBox.Show("Trả phòng thành công!", "Thông báo");
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboGioiTinh.SelectedIndex = -1;
            txtTimTen.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void QLTRA_Load(object sender, EventArgs e)
        {

        }

        private void groupKhach_Enter(object sender, EventArgs e)
        {

        }
    }
}
