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
    public partial class TIMPHONG : Form
    {
        private DataTable dtPhong = new DataTable();
        public TIMPHONG()
        {
            InitializeComponent();
            KhoiTaoBang();
        }
        private void KhoiTaoBang()
        {
            dtPhong.Columns.Add("Mã phòng");
            dtPhong.Columns.Add("Tên phòng");
            dtPhong.Columns.Add("Giá phòng");
            dtPhong.Columns.Add("Tình trạng");

            dgvPhong.DataSource = dtPhong;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa cần tìm!");
                return;
            }

            DataView dv = new DataView(dtPhong);
            string cotTim = cboTimTheo.Text == "Tên phòng" ? "Tên phòng" : "Mã phòng";
            dv.RowFilter = string.Format("[{0}] LIKE '%{1}%'", cotTim, txtTuKhoa.Text);

            dgvPhong.DataSource = dv;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            dgvPhong.DataSource = dtPhong;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TIMPHONG_Load(object sender, EventArgs e)
        {

        }

        private void TIMPHONG_Load_1(object sender, EventArgs e)
        {

        }
    }
}
