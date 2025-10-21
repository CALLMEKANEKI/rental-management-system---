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
    public partial class TIMKHACHTHUE : Form
    {
        private DataTable dtKhach;
        public TIMKHACHTHUE()
        {
            InitializeComponent();
            KhoiTaoBang();

        }
        private void KhoiTaoBang()
        {
            dtKhach = new DataTable();
            dtKhach.Columns.Add("Tên Khách");
            dtKhach.Columns.Add("Số ĐT");
            dtKhach.Columns.Add("Email");
            dtKhach.Columns.Add("Địa Chỉ");
            dtKhach.Columns.Add("Giới Tính");

            // KHÔNG có dữ liệu mẫu — bảng trống ban đầu
            dgvKetQua.DataSource = dtKhach;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            string kieuTim = cboTimTheo.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(kieuTim))
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm!", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo");
                return;
            }


            MessageBox.Show($"Đang tìm khách theo {kieuTim}: {tuKhoa}", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            cboTimTheo.SelectedIndex = -1;
            dtKhach.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TIMKHACHTHUE_Load(object sender, EventArgs e)
        {

        }

        private void TIMKHACHTHUE_Load_1(object sender, EventArgs e)
        {

        }
    }
}
