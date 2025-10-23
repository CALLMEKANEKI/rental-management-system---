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
    public partial class QLTHUE : Form
    {
        DataTable dtThuePhong = new DataTable();
        public QLTHUE()
        {
            InitializeComponent();
            KhoiTaoBang();

        }
        private void KhoiTaoBang()
        {
            dtThuePhong.Columns.Add("Mã Thuê Phòng");
            dtThuePhong.Columns.Add("Mã Khách Hàng");
            dtThuePhong.Columns.Add("Mã Phòng");
            dtThuePhong.Columns.Add("Ngày Đến");
            dtThuePhong.Columns.Add("Ngày Đi");

            dgvThuePhong.DataSource = dtThuePhong;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(cboPhong.Text) ||
                string.IsNullOrWhiteSpace(cboKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dòng mới vào DataTable
            int maThue = dtThuePhong.Rows.Count + 1;
            dtThuePhong.Rows.Add(
                maThue.ToString(),
                cboKhach.Text,
                cboPhong.Text,
                dtpNgayDen.Value.ToShortDateString(),
                ""
            );

            MessageBox.Show("Thêm thuê phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form nhập
            cboPhong.SelectedIndex = -1;
            cboKhach.SelectedIndex = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void QLTHUE_Load(object sender, EventArgs e)
        {

        }

        private void QLTHUE_Load_1(object sender, EventArgs e)
        {

        }
    }
}
