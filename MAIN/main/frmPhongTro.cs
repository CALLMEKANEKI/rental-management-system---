using BLL.Services;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmPhongTro : Form
    {
        private phongtroService _phongtroService = new phongtroService();
        private chutroService _chutroService = new chutroService();
        private string id_chutrohientai;


        public frmPhongTro()
        {
            InitializeComponent();
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            LoadDGVPhongTro();

        }

        private void LoadDGVPhongTro()
        {
            try
            {
                List<phongtroViewModel> listPhongTro = _phongtroService.LayTatCaPhongTroViewModel(id_chutrohientai);
                dgvPhongTro.DataSource = listPhongTro;
                EditDGVPhongTro();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void EditDGVPhongTro()
        {

            if (dgvPhongTro.Columns.Count == 0) return;
           
            if (dgvPhongTro.Columns.Contains("id_phong"))
                dgvPhongTro.Columns["id_phong"].HeaderText = "ID Phòng";
            if (dgvPhongTro.Columns.Contains("id_chutro"))
                dgvPhongTro.Columns["id_chutro"].HeaderText = "ID Chủ Trọ";
            if (dgvPhongTro.Columns.Contains("tenphong"))
                dgvPhongTro.Columns["tenphong"].HeaderText = "Tên phòng";
            if (dgvPhongTro.Columns.Contains("giaphong"))
                dgvPhongTro.Columns["giaphong"].HeaderText = "Giá phòng";
            if (dgvPhongTro.Columns.Contains("tinhtrang"))
                dgvPhongTro.Columns["tinhtrang"].HeaderText = "Tình trạng";


        }
        private void dgvPhongTro_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPhongTro.Rows.Count == 0)
                return;

            DataGridViewRow row = dgvPhongTro.Rows[e.RowIndex];
            txtMaPhong.Text = row.Cells["id_phong"].Value?.ToString();
            txtTenPhong.Text = row.Cells["tenphong"].Value?.ToString();
            txtGiaThue.Text = row.Cells["giaphong"].Value?.ToString();
            cboTinhTrang.Text = row.Cells["tinhtrang"].Value?.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearPhongTro();
            LoadDGVPhongTro();
        }





        private void frmPhongTro_Load_1(object sender, EventArgs e)
        {
            LoadComboBoxTinhTrang();
            LoadDGVPhongTro();
        }

      

       
        private void isPhongTroEditing(bool mode)
        {
            txtMaPhong.ReadOnly = !mode;
            txtTenPhong.ReadOnly = !mode;
            txtGiaThue.ReadOnly = !mode;
        }
        private void clearPhongTro  ()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtGiaThue.Text = "";
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
                if (string.IsNullOrEmpty(txtMaPhong.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng trọ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string mess = _phongtroService.Xoa(txtMaPhong.Text, id_chutrohientai);
                if (mess == "Xóa phòng thành công.")
                {
                    MessageBox.Show(mess, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearPhongTro();
                    LoadDGVPhongTro();
                }
                else
                {
                    MessageBox.Show(mess, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadDGVPhongTro();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Thêm")
            {
                clearPhongTro();
                isPhongTroEditing(true);
                MessageBox.Show("Vui lòng nhập thông tin phòng trọ mới. \nNhấn vào nút Lưu để lưu thông tin ");
                btn.Text = "Lưu";
            }
            else if (btn.Text == "Lưu")
            {
                // Lưu thông tin phòng trọ mới
                phongtro newPhongTro = new phongtro
                {
                    tenphong = txtTenPhong.Text,
                    giaphong = decimal.Parse(txtGiaThue.Text),
                    tinhtrang = cboTinhTrang.Text,
                    id_chutro = id_chutrohientai
                };
                string mess = _phongtroService.ThemPhongTro(newPhongTro, id_chutrohientai);
                if (mess == "Thêm phòng thành công.")
                {
                    clearPhongTro();
                    isPhongTroEditing(false);
                    btn.Text = "Thêm";
                    LoadDGVPhongTro();
                }
                MessageBox.Show(mess);
            }
        }


        private void LoadComboBoxTinhTrang()
        {
             cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.Add("Tất cả");
            cboTinhTrang.Items.Add("Trống");
            cboTinhTrang.Items.Add("Đã thuê");
            cboTinhTrang.SelectedIndex = 0;
        }



        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Tìm phòng")
            {
                string keyword = txtTimPhong.Text.Trim();
                string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(keyword) && (tinhTrang == "Tất cả" || string.IsNullOrEmpty(tinhTrang)))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa hoặc chọn tình trạng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi service để tìm phòng theo keyword + tình trạng
                List<phongtroViewModel> searchResults = _phongtroService.TimKiemPhongTro(keyword, tinhTrang, id_chutrohientai);

                if (searchResults == null || searchResults.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phòng nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvPhongTro.DataSource = searchResults;
                EditDGVPhongTro();
                btn.Text = "Hủy tìm";
            }
            else if (btn.Text == "Hủy tìm")
            {
                LoadDGVPhongTro();
                txtTimPhong.Text = "";
                cboTinhTrang.SelectedIndex = 0; // trở về "Tất cả"
                btn.Text = "Tìm phòng";
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Trả phòng")
            {
                if (string.IsNullOrEmpty(txtMaPhong.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng trọ để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                phongtro objPhong = new phongtro
                {
                    id_phong = txtMaPhong.Text,
                    id_chutro = id_chutrohientai,
                    tinhtrang = "Trống" // cập nhật trạng thái phòng sau khi trả
                };

                string mess = _phongtroService.TraPhong(objPhong, id_chutrohientai);
                if (mess == "Trả phòng thành công.")
                {
                    MessageBox.Show(mess, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearPhongTro();
                    LoadDGVPhongTro();
                }
                else
                {
                    MessageBox.Show(mess, "Lỗi trả phòng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Sửa")
            {
                if (string.IsNullOrEmpty(txtMaPhong.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng trọ để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Bây giờ bạn đã có thể chỉnh sửa !!! \nNhấn vào nút Lưu để lưu thông tin ");
                isPhongTroEditing(true);
                ((Button)sender).Text = "Lưu";
            }
            else if (btn.Text == "Lưu")
            {
                // Lưu thông tin đã chỉnh sửa
                phongtro updatedPhongTro = new phongtro
                {
                    id_phong = txtMaPhong.Text,
                    tenphong = txtTenPhong.Text,
                    giaphong = decimal.Parse(txtGiaThue.Text),
                    tinhtrang = cboTinhTrang.Text,
                    id_chutro = id_chutrohientai
                };
                string mess = _phongtroService.CapNhat(updatedPhongTro, id_chutrohientai);

                if (mess == "Cập nhật phòng thành công.")
                {
                    clearPhongTro();
                    isPhongTroEditing(false);
                    btn.Text = "Sửa";
                    LoadDGVPhongTro();
                }
                MessageBox.Show(mess);
            }
        }

       
    }
}


