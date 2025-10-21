using System;
using System.Data;
using System.Windows.Forms;

namespace qlpt.GUI
{
    public partial class TIMHOPDONG : Form
    {
        private DataTable dtHopDong;

        public TIMHOPDONG()
        {
            InitializeComponent();
            KhoiTaoBang();
        }

        private void KhoiTaoBang()
        {
            dtHopDong = new DataTable();
            dtHopDong.Columns.Add("Mã hợp đồng");
            dtHopDong.Columns.Add("Chủ trọ");
            dtHopDong.Columns.Add("Khách thuê");
            dtHopDong.Columns.Add("Tên phòng");
            dtHopDong.Columns.Add("Ngày bắt đầu");
            dtHopDong.Columns.Add("Ngày kết thúc");

            // Khởi tạo bảng trống
            dgvKetQua.DataSource = dtHopDong;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtNoiDung.Text.Trim();
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

            MessageBox.Show($"Đang tìm hợp đồng theo {kieuTim}: {tuKhoa}", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNoiDung.Clear();
            cboTimTheo.SelectedIndex = -1;
            dtHopDong.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TIMHOPDONG_Load(object sender, EventArgs e)
        {

        }
    }
}
