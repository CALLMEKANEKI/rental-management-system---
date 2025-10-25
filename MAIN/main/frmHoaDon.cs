using BLL.Services;
using DAL.Model;
using DAL.ViewModel;
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
    public partial class frmHoaDon : Form
    {
        private hoadonService _hoadonService = new hoadonService();
        private phongtroService _phongtroService = new phongtroService();
        private string id_chutrohientai;

        public frmHoaDon()
        {
            InitializeComponent();
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            LoadComboBoxPhong();
            LoadDGVHoaDon();
            LoadComboBoxTrangThai();
            LoadHoaDonDetail();
            clearHoaDon();
        }

        private void LoadComboBoxPhong()
        {
            try
            {
                var listPhong = _phongtroService.LayTatCaPhongTroViewModel(id_chutrohientai);

                if (listPhong != null && listPhong.Any())
                {
                    cboPhong.DataSource = listPhong;
                    cboPhong.DisplayMember = "tenphong"; // đúng tên trong ViewModel
                    cboPhong.ValueMember = "id_phong";   // đúng tên trong ViewModel
                    cboPhong.SelectedIndex = -1;
                }
                else
                {
                    cboPhong.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách phòng: " + ex.Message);
            }
        }

        private void LoadComboBoxTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Chưa thanh toán");
            cboTrangThai.Items.Add("Đã thanh toán");
        }


        private void LoadDGVHoaDon()
        {
            try
            {
                List<hoadonViewModel> ListHoaDon = _hoadonService.LayTatCaHoaDonViewModel(id_chutrohientai);
                dgvHoaDon.DataSource = ListHoaDon;
                EditDGVHoaDon();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LoadHoaDonDetail()
        {
            int tonghoadon = _hoadonService.LayTatCaHoaDonViewModel(id_chutrohientai).Count();
            int sohoadonchuathanhtoan = _hoadonService.LayHoaDonChuaThanhToan(id_chutrohientai).Count();
            int sohoadondathanhtoan = tonghoadon - sohoadonchuathanhtoan;

            lblTongHoaDon.Text = "Tổng hóa đơn: " + tonghoadon.ToString();
            lblHDChuaThanhToan.Text = "Số hóa đơn chưa thanh toán: " + sohoadonchuathanhtoan.ToString();
            lblHDThanhToan.Text = "Số hóa đơn đã thanh toán: " + sohoadondathanhtoan.ToString();
        }

        private void EditDGVHoaDon()
        {
            // --- 1. Tùy chỉnh tên cột và thứ tự hiển thị ---

            // Cột cơ bản
            dgvHoaDon.Columns["IDHoaDon"].HeaderText = "ID Hóa Đơn";
            dgvHoaDon.Columns["IDHoaDon"].DisplayIndex = 0;

            dgvHoaDon.Columns["NgayTao"].HeaderText = "Ngày Tạo";
            dgvHoaDon.Columns["NgayTao"].DisplayIndex = 1;

            dgvHoaDon.Columns["TenPhong"].HeaderText = "Phòng";
            dgvHoaDon.Columns["TenPhong"].DisplayIndex = 2;

            dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvHoaDon.Columns["TrangThai"].DisplayIndex = 3;

            // Cột chi tiết
            dgvHoaDon.Columns["Tien_Phong"].HeaderText = "Tiền Phòng";
            dgvHoaDon.Columns["Tien_Phong"].DisplayIndex = 4;
            dgvHoaDon.Columns["ThanhTien_Dien"].HeaderText = "Tiền Điện";
            dgvHoaDon.Columns["ThanhTien_Dien"].DisplayIndex = 5;
            dgvHoaDon.Columns["ThanhTien_Nuoc"].HeaderText = "Tiền Nước";
            dgvHoaDon.Columns["ThanhTien_Nuoc"].DisplayIndex = 6;
            dgvHoaDon.Columns["Tien_dv"].HeaderText = "Dịch Vụ";
            dgvHoaDon.Columns["Tien_dv"].DisplayIndex = 7;

            // Cột tổng tiền
            dgvHoaDon.Columns["ThanhTien"].HeaderText = "TỔNG TIỀN";
            dgvHoaDon.Columns["ThanhTien"].DisplayIndex = 8;

            // Cột Nội dung (Thường để ở cuối hoặc ẩn)
            dgvHoaDon.Columns["NoiDung"].HeaderText = "Nội dung ghi chú";
            dgvHoaDon.Columns["NoiDung"].DisplayIndex = 9;


            // --- 2. Định dạng kiểu số và ngày tháng ---

            // Định dạng tiền tệ
            dgvHoaDon.Columns["Tien_Phong"].DefaultCellStyle.Format = "N0"; // Ví dụ: 10,000
            dgvHoaDon.Columns["ThanhTien_Dien"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["ThanhTien_Nuoc"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["Tien_dv"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["Tien_Phong"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            // Định dạng ngày
            dgvHoaDon.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";


            // --- 3. Ẩn các cột chỉ số chi tiết (Giữ lại nếu muốn xem chi tiết) ---
            dgvHoaDon.Columns["ChiSoDien_Dau"].Visible = false;
            dgvHoaDon.Columns["ChiSoDien_Cuoi"].Visible = false;
            dgvHoaDon.Columns["ChiSoNuoc_Dau"].Visible = false;
            dgvHoaDon.Columns["ChiSoNuoc_Cuoi"].Visible = false;


            // --- 4. Thiết lập chung ---

            // Cho phép chọn toàn bộ hàng
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void isHoaDonEditing(bool mode)
        {
            dtpNgayTao.Enabled = mode;
            txtNoiDung.ReadOnly = !mode;

            cboPhong.Enabled = mode;
            cboTrangThai.Enabled = mode;

            
            txtTienPhong.ReadOnly = true;

            txtChiSoDienCu.ReadOnly = !mode;
            txtChiSoDienMoi.ReadOnly = !mode;
            txtTienDien.ReadOnly = !mode; 

            txtChiSoNuocCu.ReadOnly = !mode;
            txtChiSoNuocMoi.ReadOnly = !mode;
            txtTienNuoc.ReadOnly = !mode; 

            txtTienDV.ReadOnly = !mode;
            txtTienPhong.ReadOnly = !mode;
        }

        private void  clearHoaDon()
        {

            txtMaHoaDon.Text = "";
            dtpNgayTao.Value = DateTime.Now; 
            txtNoiDung.Text = "";
            txtTongTien.Text = "0"; 

            cboPhong.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1; 

            // Chỉ số Điện
            txtChiSoDienCu.Text = "0";
            txtChiSoDienMoi.Text = "0";
            txtTienDien.Text = "0";

            // Chỉ số Nước
            txtChiSoNuocCu.Text = "0";
            txtChiSoNuocMoi.Text = "0";
            txtTienNuoc.Text = "0";

            // Dịch vụ và Lệ phí
            txtTienDV.Text = "0";
            txtTienPhong.Text = "0";
        }

        private void DGVHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                object GetValue(string columnName)
                {
                    return row.Cells[columnName].Value;
                }
                // IDHoaDon
                txtMaHoaDon.Text = GetValue("IDHoaDon")?.ToString() ?? string.Empty;

                // NgayTao (Sử dụng .Value cho DateTimePicker)
                if (GetValue("NgayTao") is DateTime ngayTao)
                {
                    dtpNgayTao.Value = ngayTao;
                }
                cboPhong.Text = GetValue("TenPhong")?.ToString() ?? string.Empty;
                cboTrangThai.Text = GetValue("TrangThai")?.ToString() ?? string.Empty;
                txtNoiDung.Text = GetValue("NoiDung")?.ToString() ?? string.Empty;

                txtTienPhong.Text = GetValue("Tien_Phong")?.ToString() ?? "0";
                txtTienDien.Text = GetValue("ThanhTien_Dien")?.ToString() ?? "0";
                txtTienNuoc.Text = GetValue("ThanhTien_Nuoc")?.ToString() ?? "0";
                txtTienDV.Text = GetValue("Tien_dv")?.ToString() ?? "0";
                txtTongTien.Text = GetValue("ThanhTien")?.ToString() ?? "0";

                txtChiSoDienCu.Text = GetValue("ChiSoDien_Dau")?.ToString() ?? "0";
                txtChiSoDienMoi.Text = GetValue("ChiSoDien_Cuoi")?.ToString() ?? "0";

                txtChiSoNuocCu.Text = GetValue("ChiSoNuoc_Dau")?.ToString() ?? "0";
                txtChiSoNuocMoi.Text = GetValue("ChiSoNuoc_Cuoi")?.ToString() ?? "0";

                txtMaHoaDon.ReadOnly = true;
            }
        }

        private void txtTimHoaDon_Enter(object sender, EventArgs e)
        {
            if (txtTimHoaDon.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimHoaDon.Text = "";
                txtTimHoaDon.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtHoaDon_Leave(object sender, EventArgs e)
        {
            if (txtTimHoaDon.Text == "")
            {
                txtTimHoaDon.Text = "Nhập từ khóa để tìm kiếm";
                txtTimHoaDon.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Thêm")
            {
                clearHoaDon();
                isHoaDonEditing(true);
                MessageBox.Show("Vui lòng nhập thông tin hóa đơn mới. \nNhấn vào nút Lưu để lưu thông tin ");
                btn.Text = "Lưu";
            }
            else if (btn.Text == "Lưu")
            {
                dien newDien = new dien
                {
                    id_dien = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    chi_so_dau = decimal.Parse(txtChiSoDienCu.Text),
                    chi_so_cuoi = decimal.Parse(txtChiSoDienMoi.Text),
                    thanh_tien_dien = decimal.Parse(txtTienDien.Text),
                };

                nuoc newNuoc = new nuoc
                {
                    id_nuoc = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    chi_so_dau = decimal.Parse(txtChiSoNuocCu.Text),
                    chi_so_cuoi = decimal.Parse(txtChiSoNuocMoi.Text),
                    thanh_tien_nuoc = decimal.Parse(txtTienNuoc.Text),
                };

                lephi newLephi = new lephi
                {
                    id_lephi = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    tien_dv = decimal.Parse(txtTienDV.Text),
                    tien_phong = decimal.Parse(txtTienPhong.Text),
                    thanh_tien_lephi = decimal.Parse(txtTienDV.Text) + decimal.Parse(txtTienPhong.Text),
                };

                // Lưu thông tin người thuê mới
                hoadon newHoaDon = new hoadon
                {
                    id_hoadon = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    trang_thai = cboTrangThai.Text,
                    noi_dung = txtNoiDung.Text,
                    id_phong = cboPhong.SelectedValue?.ToString(),
                    id_dien = newDien.id_dien,
                    id_nuoc = newNuoc.id_nuoc,
                    id_lephi = newLephi.id_lephi,
                    thanh_tien = newDien.thanh_tien_dien + newNuoc.thanh_tien_nuoc + newLephi.thanh_tien_lephi,
                };
                string mess = _hoadonService.ThemHoaDon(newHoaDon, newDien, newNuoc, newLephi, id_chutrohientai);
                if (mess == "Thêm hóa đơn thành công.")
                {
                    clearHoaDon();
                    isHoaDonEditing(false);
                    btn.Text = "Thêm";
                    LoadDGVHoaDon();
                    LoadComboBoxPhong();
                }
                MessageBox.Show(mess);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Sửa")
            {
                if (string.IsNullOrEmpty(txtMaHoaDon.Text))
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Bây giờ bạn đã có thể chỉnh sửa !!! \nNhấn vào nút Lưu để lưu thông tin ");
                isHoaDonEditing(true);
                ((Button)sender).Text = "Lưu";
            }

            else if (btn.Text == "Lưu")
            {
                // Lưu thông tin hóa đơn đã chỉnh sửa
                dien UpdatedDien = new dien
                {
                    id_dien = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    chi_so_dau = decimal.Parse(txtChiSoDienCu.Text),
                    chi_so_cuoi = decimal.Parse(txtChiSoDienMoi.Text),
                    thanh_tien_dien = decimal.Parse(txtTienDien.Text),
                };

                nuoc UpdatedNuoc = new nuoc
                {
                    id_nuoc = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    chi_so_dau = decimal.Parse(txtChiSoNuocCu.Text),
                    chi_so_cuoi = decimal.Parse(txtChiSoNuocMoi.Text),
                    thanh_tien_nuoc = decimal.Parse(txtTienNuoc.Text),
                };

                lephi UpdatedLephi = new lephi
                {
                    id_lephi = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    tien_dv = decimal.Parse(txtTienDV.Text),
                    tien_phong = decimal.Parse(txtTienPhong.Text),
                    thanh_tien_lephi = decimal.Parse(txtTienDV.Text) + decimal.Parse(txtTienPhong.Text),
                };

                // Lưu thông tin người thuê mới
                hoadon UpdatedHoaDon = new hoadon
                {
                    id_hoadon = txtMaHoaDon.Text,
                    ngay_tao = dtpNgayTao.Value,
                    trang_thai = cboTrangThai.Text,
                    noi_dung = txtNoiDung.Text,
                    id_phong = cboPhong.SelectedValue?.ToString(),
                    phongtro = _phongtroService.LayPhongTroById(cboPhong.SelectedValue?.ToString(), id_chutrohientai),
                    id_dien = UpdatedDien.id_dien,
                    id_nuoc = UpdatedNuoc.id_nuoc,
                    id_lephi = UpdatedLephi.id_lephi,
                    thanh_tien = UpdatedDien.thanh_tien_dien + UpdatedNuoc.thanh_tien_nuoc + UpdatedLephi.thanh_tien_lephi,
                };
                string mess = _hoadonService.CapNhat(UpdatedHoaDon, UpdatedDien, UpdatedNuoc, UpdatedLephi, id_chutrohientai);
                if (mess == "Cập nhật hóa đơn thành công.")
                {
                    clearHoaDon();
                    isHoaDonEditing(false);
                    btn.Text = "Sửa";
                    LoadDGVHoaDon();
                }
                MessageBox.Show(mess);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "LƯU Ý: HÀNH ĐỘNG SAU ĐÂY KHÔNG THỂ HOÀN TÁC!!!\n BẠN CHẮC CHẮN MUỐN XÓA?",
              "Xác nhận",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
          );
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtMaHoaDon.Text))
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string idHoaDonToDelete = txtMaHoaDon.Text;
                string mess = _hoadonService.Xoa(idHoaDonToDelete, id_chutrohientai);
                if (mess == "Xóa hóa đơn thành công.")
                {
                    MessageBox.Show(mess);
                    clearHoaDon();
                    LoadDGVHoaDon();
                }
                else
                {
                    MessageBox.Show(mess, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            string keyword = txtTimHoaDon.Text.Trim();

            // 1. Kiểm tra từ khóa
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa  để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi Service để tìm kiếm
            List<hoadonViewModel> searchResults = _hoadonService.LayTatCaHoaDonTheoKeywork(keyword, id_chutrohientai);

            // 3. Xử lý kết quả tìm kiếm
            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào phù hợp với từ khóa: " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Load DataGridView với kết quả mới
            dgvHoaDon.DataSource = searchResults;
            EditDGVHoaDon(); 
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDGVHoaDon();
            clearHoaDon();
        }
    }
}
