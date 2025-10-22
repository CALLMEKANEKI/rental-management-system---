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
    public partial class frmTimPhong : Form
    {
        public frmTimPhong()
        {
            InitializeComponent();
            cboTimTheo.SelectedIndex = 0; // chọn mặc định
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string timTheo = cboTimTheo.SelectedItem.ToString();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung tìm kiếm!");
                return;
            }

            // Chưa kết nối SQL — chỉ hiển thị thông báo mô phỏng kết quả
            MessageBox.Show($"Đang tìm theo '{timTheo}' với nội dung: {noiDung}");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNoiDung.Clear();
            dgvKetQua.DataSource = null; // làm trống kết quả
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}