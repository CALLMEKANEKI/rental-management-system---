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
    public partial class frmHopDong : Form
    {
        private hopdongService _hopdongService = new hopdongService();
        private phongtroService _phongtroService = new phongtroService();
        private nguoithueService _nguoithueService = new nguoithueService();
        private string id_chutrohientai = string.Empty;

        public frmHopDong()
        {
            InitializeComponent();
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            LoadComboBoxPhong();
            LoadDGVHopDong();
            ClearHopDong();
        }

        public void ClearHopDong() 
        {
            txtIDHopDong.Text = "";
            txtTienCoc.Text = "";
            dtpNgayBD.Value =DateTime.Now;
            dtpNgayKT.Value =DateTime.Now;
            cboPhong.SelectedIndex = -1;
            cboNguoiThue.SelectedIndex = -1;
        } 

        public void LoadDGVHopDong()
        {
            try
            {
                List<hopdongViewModel> ListHopDong = _hopdongService.LayAllHopDongViewModel(id_chutrohientai);
                dgvHopDong.DataSource = ListHopDong;
                EditDGVHopDong();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EditDGVHopDong()
        {
            dgvHopDong.Columns["IDHopDong"].HeaderText = "Mã hợp đồng";
            dgvHopDong.Columns["IDHopDong"].DisplayIndex = 0;

            dgvHopDong.Columns["TenNguoiThue"].HeaderText = "Người thuê";
            dgvHopDong.Columns["TenNguoiThue"].DisplayIndex = 1;

            dgvHopDong.Columns["TenPhong"].HeaderText = "Phòng thuê";
            dgvHopDong.Columns["TenPhong"].DisplayIndex = 2;

            dgvHopDong.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            dgvHopDong.Columns["NgayBatDau"].DisplayIndex = 3;

            dgvHopDong.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            dgvHopDong.Columns["NgayKetThuc"].DisplayIndex = 4;

            dgvHopDong.Columns["Tiencoc"].HeaderText = "Tiền cọc";
            dgvHopDong.Columns["Tiencoc"].DisplayIndex = 5;

            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void  isHopDongEditting(bool mode)
        {
            dtpNgayBD.Enabled = mode;
            dtpNgayKT.Enabled = mode;
            cboPhong.Enabled = mode;
            cboNguoiThue.Enabled = mode;
            txtTienCoc.ReadOnly = !mode;
        }

        public void LoadComboBoxPhong()
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

        private void ComboBoxPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboBoxNguoiThue();
        }

        public void LoadComboBoxNguoiThue() 
        {
            try
            {
                string id_phong = cboPhong.SelectedValue?.ToString();
                var listNguoiThue = _nguoithueService.LayTatCaNguoiThueTheoPhong(id_chutrohientai, id_phong);
                if (listNguoiThue != null && listNguoiThue.Any())
                {
                    cboNguoiThue.DataSource = listNguoiThue;
                    cboNguoiThue.DisplayMember = "hoten"; // đúng tên trong ViewModel
                    cboNguoiThue.ValueMember = "id_nguoi_thue";   // đúng tên trong ViewModel
                    cboNguoiThue.SelectedIndex = -1;
                }
                else
                {
                    cboNguoiThue.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách người thuê: " + ex.Message);
            }
        }

        private void txtTimHopDong_Enter(object sender, EventArgs e)
        {
            if (txtTimHopDong.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimHopDong.Text = "";
                txtTimHopDong.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void DGVHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

                object GetValue(string columnName)
                {
                    return row.Cells[columnName].Value;
                }
                txtIDHopDong.Text = GetValue("IDHopDong")?.ToString() ?? string.Empty;

                if (GetValue("NgayBatDau") is DateTime ngayBD)
                {
                    dtpNgayBD.Value = ngayBD;
                }
                if (GetValue("NgayKetThuc") is DateTime ngayKT)
                {
                    dtpNgayKT.Value = ngayKT;
                }
                cboPhong.Text = GetValue("TenPhong")?.ToString() ?? string.Empty;
                cboNguoiThue.Text = GetValue("TenNguoiThue")?.ToString() ?? string.Empty;
                txtTienCoc.Text = GetValue("Tiencoc")?.ToString() ?? string.Empty;
            }
        }

        private void txtTimHopDong_Leave(object sender, EventArgs e)
        {
            if (txtTimHopDong.Text == "")
            {
                txtTimHopDong.Text = "Nhập từ khóa để tìm kiếm";
                txtTimHopDong.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void cboNguoiThue_Click(object sender, EventArgs e)
        {

            if (cboPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Phòng trước khi chọn Người thuê.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDGVHopDong();
            ClearHopDong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Thêm")
            {
                ClearHopDong();
                isHopDongEditting(true);
                MessageBox.Show("Vui lòng nhập thông tin hợp đồng mới. \nNhấn vào nút Lưu để lưu thông tin ");
                btn.Text = "Lưu";
            }
            else if (btn.Text == "Lưu")
            {
                // Lưu thông tin người thuê mới
                hopdong newHopDong = new hopdong
                {
                    ngay_bat_dau = dtpNgayBD.Value,
                    ngay_ket_thuc = dtpNgayKT.Value,
                    tien_coc = decimal.Parse(txtTienCoc.Text),
                    id_chutro = id_chutrohientai,
                    id_nguoi_thue = cboNguoiThue.SelectedValue?.ToString(),
                    id_phong = cboPhong.SelectedValue?.ToString(),
                };
                string mess = _hopdongService.ThemHopDong(newHopDong, id_chutrohientai);
                if (mess == "Thêm hợp đồng thành công.")
                {
                    ClearHopDong ();
                    isHopDongEditting(false);
                    btn.Text = "Thêm";
                    LoadComboBoxPhong();
                    LoadDGVHopDong();
                }
                MessageBox.Show(mess);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "Sửa")
            {
                if (string.IsNullOrEmpty(txtIDHopDong.Text))
                {
                    MessageBox.Show("Vui lòng chọn Hợp đồng để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Bây giờ bạn đã có thể chỉnh sửa !!! \nNhấn vào nút Lưu để lưu thông tin ");
                isHopDongEditting(true);
                ((Button)sender).Text = "Lưu";
            }

            else if (btn.Text == "Lưu")
            {
               
                hopdong updatedHopDong = new hopdong
                {
                    id_hopdong = txtIDHopDong.Text, 
                    ngay_bat_dau = dtpNgayBD.Value,
                    ngay_ket_thuc = dtpNgayKT.Value,
                    tien_coc = decimal.Parse(txtTienCoc.Text),
                    id_phong = cboPhong.SelectedValue?.ToString(),
                    id_nguoi_thue = cboNguoiThue.SelectedValue?.ToString()
                };

                string mess = _hopdongService.CapNhat(updatedHopDong, id_chutrohientai);
                if (mess.Contains("thành công"))
                {
                    ClearHopDong();
                    isHopDongEditting(false);
                    btn.Text = "Sửa";
                    LoadDGVHopDong();
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
                if (string.IsNullOrEmpty(txtIDHopDong.Text))
                {
                    MessageBox.Show("Vui lòng chọn hợp đồng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string idHopDongToDelete = txtIDHopDong.Text;
                string mess = _hopdongService.Xoa(idHopDongToDelete, id_chutrohientai);
                if (mess == "Xóa hợp đồng thành công.")
                {
                    MessageBox.Show(mess);
                    ClearHopDong();
                    LoadDGVHopDong();
                }
                else
                {
                    MessageBox.Show(mess, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimHopDong_Click(object sender, EventArgs e)
        {
            string keyword = txtTimHopDong.Text.Trim(); // Giả định có control txtTimHopDong
            List<hopdongViewModel> searchResults = _hopdongService.LayAllHopDongViewModelTheoKeyWork(id_chutrohientai, keyword);

            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Hợp đồng nào phù hợp với từ khóa: " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Load DataGridView với kết quả mới
            dgvHopDong.DataSource = searchResults;
            EditDGVHopDong(); 
        }
    }
}
