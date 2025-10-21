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
    public partial class frmTraPhong : Form
    {
        public frmTraPhong()
        {
            InitializeComponent();
        }

        // 🟩 Nút TÌM KIẾM (chưa truy vấn SQL)
        private void btnTim_Click(object sender, EventArgs e)
        {
            string tenKH = txtTimTen.Text.Trim();

            if (string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm!");
                return;
            }

            // ⚪ Chưa load SQL — chỉ mô phỏng kết quả
            MessageBox.Show($"Đang tìm khách hàng có tên gần giống: {tenKH}");
        }

        // 🟦 Hàm hiển thị danh sách phòng đang thuê (tạm bỏ SQL)
        private void HienThiPhongDangThue(int maKH)
        {
            // ⚪ Chưa cần code — chỉ placeholder
            MessageBox.Show($"(Giả lập) Hiển thị phòng đang thuê của khách có mã: {maKH}");
        }

        // 🟥 Nút TRẢ PHÒNG (chưa kết nối SQL)
        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (dgvThuePhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần trả!");
                return;
            }

            // ⚪ Giả lập hành động trả phòng
            MessageBox.Show("(Giả lập) Trả phòng thành công!");
        }

        // 🧹 Nút XÓA TRẮNG
        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtTimTen.Clear();
            dgvKhachHang.DataSource = null;
            dgvThuePhong.DataSource = null;
        }

        // ❌ Nút THOÁT
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}