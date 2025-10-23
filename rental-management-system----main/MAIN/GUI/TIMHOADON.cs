using System;
using System.Data;
using System.Windows.Forms;

namespace qlpt.GUI
{
    public partial class TIMHOADON : Form
    {
        private DataTable dtHoaDon;

        public TIMHOADON()
        {
            InitializeComponent();
            KhoiTaoBang();
        }

        private void KhoiTaoBang()
        {
            dtHoaDon = new DataTable();
            dtHoaDon.Columns.Add("Mã hóa đơn");
            dtHoaDon.Columns.Add("Tên phòng");
            dtHoaDon.Columns.Add("Ngày tạo");
            dtHoaDon.Columns.Add("Trạng thái");
            dtHoaDon.Columns.Add("Thành tiền");

            // Bảng trống ban đầu
            dgvKetQua.DataSource = dtHoaDon;
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

            // Chưa có dữ liệu thật, nên chỉ mô phỏng
            MessageBox.Show($"Đang tìm hóa đơn theo {kieuTim}: {tuKhoa}", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNoiDung.Clear();
            cboTimTheo.SelectedIndex = -1;
            dtHoaDon.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TIMHOADON_Load(object sender, EventArgs e)
        {

        }
    }
}
