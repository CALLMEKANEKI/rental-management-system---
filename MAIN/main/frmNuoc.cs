using System;
using System.Data;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmNuoc : Form
    {
        DataTable dtNuoc = new DataTable();
        int currentIndex = -1;

        public frmNuoc()
        {
            InitializeComponent();
            TaoCauTrucBang();
            LoadPhong();
            LoadData();
        }

        // 🔹 Tạo cấu trúc DataTable trống
        private void TaoCauTrucBang()
        {
            dtNuoc.Columns.Add("MaNuoc", typeof(int));
            dtNuoc.Columns.Add("MaPhong", typeof(string));
            dtNuoc.Columns.Add("ChiSoCu", typeof(double));
            dtNuoc.Columns.Add("ChiSoMoi", typeof(double));
            dtNuoc.Columns.Add("SoTieuThu", typeof(double));
            dtNuoc.Columns.Add("TienNuoc", typeof(double));
            dtNuoc.Columns.Add("Thang", typeof(string));
        }

        private void LoadData()
        {
            dgvNuoc.DataSource = dtNuoc;
        }

        // 🔹 Load danh sách phòng (chỉ thiết lập cột, không có dữ liệu sẵn)
        private void LoadPhong()
        {
            DataTable dtPhong = new DataTable();
            dtPhong.Columns.Add("MaPhong");
            dtPhong.Columns.Add("TenPhong");

            cboPhong.DataSource = dtPhong;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }

        // 🔹 Tính tiền nước
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtChiSoMoi.Text, out double moi) &&
                double.TryParse(txtChiSoCu.Text, out double cu))
            {
                if (moi >= cu)
                {
                    double tieuThu = moi - cu;
                    double donGia = 8000; // 1 m³ = 8000 VNĐ
                    double tien = tieuThu * donGia;

                    txtSoNuocTieuThu.Text = tieuThu.ToString();
                    txtTienNuoc.Text = tien.ToString("#,##0 VNĐ");
                }
                else
                {
                    MessageBox.Show("⚠️ Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ!");
                }
            }
            else
            {
                MessageBox.Show("⚠️ Vui lòng nhập đúng định dạng số!");
            }
        }

        // 🔹 Thêm hóa đơn nước
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChiSoCu.Text) || string.IsNullOrWhiteSpace(txtChiSoMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập chỉ số nước!");
                return;
            }

            DataRow row = dtNuoc.NewRow();
            row["MaNuoc"] = dtNuoc.Rows.Count + 1;
            row["MaPhong"] = cboPhong.Text;
            row["ChiSoCu"] = double.Parse(txtChiSoCu.Text);
            row["ChiSoMoi"] = double.Parse(txtChiSoMoi.Text);
            row["SoTieuThu"] = double.Parse(txtSoNuocTieuThu.Text);
            row["TienNuoc"] = double.Parse(txtTienNuoc.Text.Replace(" VNĐ", "").Replace(",", ""));
            row["Thang"] = dtpThang.Value.ToString("MM/yyyy");

            dtNuoc.Rows.Add(row);
            LoadData();
            MessageBox.Show("✅ Thêm hóa đơn nước thành công!");
        }

        // 🔹 Sửa bản ghi được chọn
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < dtNuoc.Rows.Count)
            {
                DataRow row = dtNuoc.Rows[currentIndex];
                row["MaPhong"] = cboPhong.Text;
                row["ChiSoCu"] = double.Parse(txtChiSoCu.Text);
                row["ChiSoMoi"] = double.Parse(txtChiSoMoi.Text);
                row["SoTieuThu"] = double.Parse(txtSoNuocTieuThu.Text);
                row["TienNuoc"] = double.Parse(txtTienNuoc.Text.Replace(" VNĐ", "").Replace(",", ""));
                row["Thang"] = dtpThang.Value.ToString("MM/yyyy");

                LoadData();
                MessageBox.Show("✏️ Cập nhật thành công!");
            }
        }

        // 🔹 Xóa bản ghi được chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < dtNuoc.Rows.Count)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dtNuoc.Rows.RemoveAt(currentIndex);
                    LoadData();
                    MessageBox.Show("🗑️ Xóa thành công!");
                }
            }
        }

        // 🔹 Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNuoc.Clear();
            txtChiSoCu.Clear();
            txtChiSoMoi.Clear();
            txtSoNuocTieuThu.Clear();
            txtTienNuoc.Clear();
            cboPhong.SelectedIndex = -1;
            dtpThang.Value = DateTime.Now;
        }

        // 🔹 Khi chọn dòng trong DataGridView
        private void dgvNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentIndex = e.RowIndex;
                DataRow row = dtNuoc.Rows[e.RowIndex];

                txtMaNuoc.Text = row["MaNuoc"].ToString();
                cboPhong.Text = row["MaPhong"].ToString();
                txtChiSoCu.Text = row["ChiSoCu"].ToString();
                txtChiSoMoi.Text = row["ChiSoMoi"].ToString();
                txtSoNuocTieuThu.Text = row["SoTieuThu"].ToString();
                txtTienNuoc.Text = Convert.ToDouble(row["TienNuoc"]).ToString("#,##0 VNĐ");
                dtpThang.Text = row["Thang"].ToString();
            }
        }
    }
}
