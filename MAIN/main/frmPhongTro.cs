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
            LoadComboBoxTinhTrang();
            LoadDataDetailPhong();
            clearPhongTro();
        }

        private void LoadDataDetailPhong()
        {
            int tongphong = _phongtroService.LayTatCaPhongTro(id_chutrohientai).Count();
            int sophongtrong = _phongtroService.TimPhongTrong(id_chutrohientai).Count();
            int sophogndathue = tongphong - sophongtrong;

            lblTongPhong.Text = "Tổng phòng: " + tongphong.ToString();
            lblSoPhongTrong.Text = "Số phòng trống: " + sophongtrong.ToString();
            lblSoPhongThue.Text = "Số phòng thuê: " + sophogndathue.ToString();
        }

        private void LoadDGVPhongTro()
        {
            try
            { 
                List<phongtro> listPhongTro = _phongtroService.LayTatCaPhongTro(id_chutrohientai);
                if (listPhongTro != null)
                {
                    dgvPhongTro.DataSource = listPhongTro;
                    EditDGVPhongTro();
                }
                else
                {
                    dgvPhongTro.DataSource = null;
                }

                LoadDataDetailPhong();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải DGV Phòng Trọ: " + ex.Message);
            }
        }


        private void EditDGVPhongTro()
        {
            dgvPhongTro.Columns["id_phong"].HeaderText = "ID Phòng";
            dgvPhongTro.Columns["id_phong"].DisplayIndex = 0;
            dgvPhongTro.Columns["tenphong"].HeaderText = "Tên phòng";
            dgvPhongTro.Columns["tenphong"].DisplayIndex = 1;
            dgvPhongTro.Columns["giaphong"].HeaderText = "Giá phòng";
            dgvPhongTro.Columns["giaphong"].DisplayIndex = 2;
            dgvPhongTro.Columns["tinhtrang"].HeaderText = "Tình trạng";
            dgvPhongTro.Columns["tinhtrang"].DisplayIndex = 3;

            dgvPhongTro.Columns["id_chutro"].Visible = false;
            dgvPhongTro.Columns["chutro"].Visible = false;
            dgvPhongTro.Columns["hopdongs"].Visible = false;
            dgvPhongTro.Columns["nguoi_thue"].Visible = false;

            // Cho phép chọn toàn bộ hàng
            dgvPhongTro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void dgvPhongTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPhongTro.Rows.Count == 0)
                return;
            try
            {
                DataGridViewRow row = dgvPhongTro.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["id_phong"].Value?.ToString();
                txtTenPhong.Text = row.Cells["tenphong"].Value?.ToString();
                txtGiaThue.Text = row.Cells["giaphong"].Value?.ToString();
                cboTinhTrang.Text = row.Cells["tinhtrang"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadComboBoxTinhTrang()
        {
            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.Add("Đang sửa chửa");
            cboTinhTrang.Items.Add("Trống");
            cboTinhTrang.Items.Add("Đã thuê(Còn chỗ)");
            cboTinhTrang.Items.Add("Đã thuê(Đầy)");
            cboTinhTrang.SelectedIndex = 0;
        }

        private void isPhongTroEditing(bool mode)
        {
            txtTenPhong.ReadOnly = !mode;
            txtGiaThue.ReadOnly = !mode;
            cboTinhTrang.Enabled = mode;
        }
        private void clearPhongTro  ()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtGiaThue.Text = "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearPhongTro();
            LoadDGVPhongTro();
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

        private void btnThem_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(txtTenPhong.Text) || string.IsNullOrEmpty(cboTinhTrang.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên phòng và Tình trạng.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaThue.Text, out decimal giaphongValue) || giaphongValue <= 0)
                {
                    MessageBox.Show("Giá phòng phải là một số hợp lệ và lớn hơn 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                phongtro newPhongTro = new phongtro
                {
                    tenphong = txtTenPhong.Text,
                    giaphong = giaphongValue,
                    tinhtrang = cboTinhTrang.Text,
                    id_chutro = id_chutrohientai,
                };

                string mess = _phongtroService.ThemPhongTro(newPhongTro, id_chutrohientai);

                if (mess == "Thêm phòng thành công.")
                {
                    clearPhongTro();
                    isPhongTroEditing(false);
                    btn.Text = "Thêm";
                    LoadDGVPhongTro();
                    LoadDataDetailPhong(); // Cập nhật thống kê sau khi thêm
                }
                MessageBox.Show(mess);
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
                if (string.IsNullOrEmpty(txtTenPhong.Text) || string.IsNullOrEmpty(cboTinhTrang.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên phòng và Tình trạng.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaThue.Text, out decimal giaphongValue) || giaphongValue <= 0)
                {
                    MessageBox.Show("Giá phòng phải là một số hợp lệ và lớn hơn 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                    LoadDataDetailPhong();
                }
                MessageBox.Show(mess);
            }
        }

        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            string keyword = txtTimPhong.Text.Trim();
            List<phongtro> searchResults = _phongtroService.TimKiemPhongTro(keyword, id_chutrohientai);
            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvPhongTro.DataSource = searchResults;
            EditDGVPhongTro(); 
        }

        private void txtTimPhong_Enter(object sender, EventArgs e)
        {
            if (txtTimPhong.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimPhong.Text = "";
                txtTimPhong.ForeColor = System.Drawing.Color.Black;
            }    
        }

        private void txtTimPhong_Leave(object sender, EventArgs e)
        {
            if (txtTimPhong.Text == "")
            {
                txtTimPhong.Text = "Nhập từ khóa để tìm kiếm";
                txtTimPhong.ForeColor = System.Drawing.Color.Gray;
            }
        }


        /*
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
        */


    }
}


