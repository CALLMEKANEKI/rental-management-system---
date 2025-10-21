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

    public partial class QLHOADON : Form
    {
        private DataTable dtHoaDon = new DataTable();

        public QLHOADON()
        {
            InitializeComponent();
            TaoBang();
        }
        private void TaoBang()
        {
            dtHoaDon.Columns.Add("Mã hóa đơn");
            dtHoaDon.Columns.Add("Tên phòng");
            dtHoaDon.Columns.Add("Tiền phòng");
            dtHoaDon.Columns.Add("Tiền dịch vụ");
            dtHoaDon.Columns.Add("Chỉ số điện cũ");
            dtHoaDon.Columns.Add("Chỉ số điện mới");
            dtHoaDon.Columns.Add("Tiền điện");
            dtHoaDon.Columns.Add("Chỉ số nước cũ");
            dtHoaDon.Columns.Add("Chỉ số nước mới");
            dtHoaDon.Columns.Add("Tiền nước");
            dtHoaDon.Columns.Add("Ngày tạo");
            dtHoaDon.Columns.Add("Trạng thái");
            dtHoaDon.Columns.Add("Nội dung");
            dtHoaDon.Columns.Add("Thành tiền");

            dgvHoaDon.DataSource = dtHoaDon;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text) || string.IsNullOrWhiteSpace(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            DataRow row = dtHoaDon.NewRow();
            row["Mã hóa đơn"] = txtMaHD.Text;
            row["Tên phòng"] = txtTenPhong.Text;
            row["Tiền phòng"] = txtTienPhong.Text;
            row["Tiền dịch vụ"] = txtTienDV.Text;
            row["Chỉ số điện cũ"] = txtDienCu.Text;
            row["Chỉ số điện mới"] = txtDienMoi.Text;
            row["Tiền điện"] = txtTienDien.Text;
            row["Chỉ số nước cũ"] = txtNuocCu.Text;
            row["Chỉ số nước mới"] = txtNuocMoi.Text;
            row["Tiền nước"] = txtTienNuoc.Text;
            row["Ngày tạo"] = dtpNgayTao.Value.ToShortDateString();
            row["Trạng thái"] = cboTrangThai.Text;
            row["Nội dung"] = txtNoiDung.Text;
            row["Thành tiền"] = txtThanhTien.Text;

            dtHoaDon.Rows.Add(row);
            MessageBox.Show("Thêm hóa đơn thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            int index = dgvHoaDon.CurrentRow.Index;
            dtHoaDon.Rows[index]["Tên phòng"] = txtTenPhong.Text;
            dtHoaDon.Rows[index]["Tiền phòng"] = txtTienPhong.Text;
            dtHoaDon.Rows[index]["Tiền dịch vụ"] = txtTienDV.Text;
            dtHoaDon.Rows[index]["Tiền điện"] = txtTienDien.Text;
            dtHoaDon.Rows[index]["Tiền nước"] = txtTienNuoc.Text;
            dtHoaDon.Rows[index]["Trạng thái"] = cboTrangThai.Text;
            dtHoaDon.Rows[index]["Thành tiền"] = txtThanhTien.Text;

            MessageBox.Show("Cập nhật hóa đơn thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                dgvHoaDon.Rows.RemoveAt(dgvHoaDon.CurrentRow.Index);
                MessageBox.Show("Đã xóa hóa đơn!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void QLHOADON_Load(object sender, EventArgs e)
        {

        }

        private void QLHOADON_Load_1(object sender, EventArgs e)
        {

        }

        private void QLHOADON_Load_2(object sender, EventArgs e)
        {

        }
    }
}
