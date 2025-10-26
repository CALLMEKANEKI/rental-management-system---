using BLL.Services;
using DAL.Model;
using DAL.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmNguoiThue : Form
    {
        private nguoithueService _nguoithueSerVice = new nguoithueService();
        private phongtroService _phongtroService = new phongtroService();
        private string id_chutrohientai;

   
        public frmNguoiThue()
        {
            InitializeComponent();
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            LoadComboBoxPhong();
            LoadDGVNguoiThue();
        }

        public void LoadDGVNguoiThue()
        {
            try
            {
                List<nguoithueViewModel> ListNguoiThue = _nguoithueSerVice.LayTatCaNguoiThueViewModel(id_chutrohientai);
                dgvNguoiThue.DataSource = ListNguoiThue;
                EditDGVNguoiThue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        private void EditDGVNguoiThue()
        {
            // Tùy chỉnh tên cột thân thiện hơn
            dgvNguoiThue.Columns["IDNguoiThue"].HeaderText = "ID Người Thuê";
            dgvNguoiThue.Columns["IDNguoiThue"].DisplayIndex = 0;
            dgvNguoiThue.Columns["HoTenNguoiThue"].HeaderText = "Họ tên";
            dgvNguoiThue.Columns["HoTenNguoiThue"].DisplayIndex = 1;
            dgvNguoiThue.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvNguoiThue.Columns["SoDienThoai"].DisplayIndex = 2;
            dgvNguoiThue.Columns["CCCD"].HeaderText = "CCCD";
            dgvNguoiThue.Columns["CCCD"].DisplayIndex = 3;
            dgvNguoiThue.Columns["Email"].HeaderText = "Email";
            dgvNguoiThue.Columns["Email"].DisplayIndex = 4;
            dgvNguoiThue.Columns["TenPhong"].HeaderText = "Phòng";
            dgvNguoiThue.Columns["TenPhong"].DisplayIndex = 5;

            // Cho phép chọn toàn bộ hàng
            dgvNguoiThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvNguoiThue.Columns["IDPhong"].Visible = false;
        }

        private void DGVNguoiThue_CellCLick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row = dgvNguoiThue.Rows[e.RowIndex];
               
                txtID.Text = row.Cells["IDNguoiThue"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTenNguoiThue"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                cboPhong.Text = row.Cells["TenPhong"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearNguoiThue();
            LoadDGVNguoiThue();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            if (btn.Text == "Thêm")
            {
                clearNguoiThue();
                isNguoiThueEditing(true);
                MessageBox.Show("Vui lòng nhập thông tin người thuê mới. \nNhấn vào nút Lưu để lưu thông tin ");
                btn.Text = "Lưu";
            }
            else if (btn.Text == "Lưu")
            {
                // Lưu thông tin người thuê mới
                nguoi_thue newNguoiThue = new nguoi_thue
                {
                    id_nguoi_thue = txtID.Text,
                    hoten = txtHoTen.Text,
                    cccd = txtCCCD.Text,
                    sdt = txtSDT.Text,
                    email = txtEmail.Text,
                    id_phong = cboPhong.SelectedValue?.ToString(),
                };
                string mess = _nguoithueSerVice.ThemNguoiThue(newNguoiThue, id_chutrohientai);
                if (mess == "Thêm người thuê thành công.")
                {
                    clearNguoiThue();
                    isNguoiThueEditing(false);
                    btn.Text = "Thêm";
                    LoadDGVNguoiThue();
                    LoadComboBoxPhong();    
                }
                MessageBox.Show(mess);


            }
        }
        private void isNguoiThueEditing(bool mode)
        {
            txtHoTen.ReadOnly = !mode;
            txtCCCD.ReadOnly = !mode;
            txtSDT.ReadOnly = !mode;
            txtEmail.ReadOnly = !mode;
            cboPhong.Enabled = mode;
        }
        private void clearNguoiThue()
        {
            txtID.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";

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



        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "LƯU Ý: HÀNH ĐỘNG SAU ĐÂY KHÔNG THỂ HOÀN TÁC!!!\n Nếu xóa người thuê nyaf, bạn đồng thời cũng xóa đi hợp đồng và lịch sử thanh toán của người thuê này luôn\n BẠN CHẮC CHẮN MUỐN XÓA?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn người thuê để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string idNguoiThueToDelete = txtID.Text;
                string mess = _nguoithueSerVice.Xoa(idNguoiThueToDelete, id_chutrohientai);
                if (mess == "Xóa người thuê thành công.")
                {
                    clearNguoiThue();
                    LoadDGVNguoiThue();
                    MessageBox.Show(mess, "Thông báo");
                }
                else
                {
                    MessageBox.Show(mess, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Sửa")
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn người thuê để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                MessageBox.Show("Bây giờ bạn đã có thể chỉnh sửa !!! \nNhấn vào nút Lưu để lưu thông tin ");
                isNguoiThueEditing(true);
                ((Button)sender).Text = "Lưu";
            }

            else if (btn.Text == "Lưu")
            {
                // Lưu thông tin người thuê đã chỉnh sửa
                nguoi_thue updatedNguoiThue = new nguoi_thue
                {
                    id_nguoi_thue = txtID.Text,
                    hoten = txtHoTen.Text,
                    cccd = txtCCCD.Text,
                    sdt = txtSDT.Text,
                    email = txtEmail.Text,
                    id_phong = cboPhong.SelectedValue?.ToString(),
                };
                string mess = _nguoithueSerVice.CapNhat(updatedNguoiThue, id_chutrohientai);
                if (mess == "Cập nhật người thuê thành công.")
                {
                    clearNguoiThue();
                    isNguoiThueEditing(false);
                    btn.Text = "Sửa";
                    LoadDGVNguoiThue();
                }
                MessageBox.Show(mess);
            }
        }

        private void btnTimNguoiThue_Click(object sender, EventArgs e)
        {
            string keyword = txtTimNT.Text.Trim();

            // 1. Kiểm tra từ khóa
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa (Tên, CCCD, SĐT, hoặc Tên phòng) để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi Service để tìm kiếm
            List<nguoithueViewModel> searchResults = _nguoithueSerVice.TimKiemNguoiThue(keyword, id_chutrohientai);

            // 3. Xử lý kết quả tìm kiếm
            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy người thuê nào phù hợp với từ khóa: " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Load DataGridView với kết quả mới
            dgvNguoiThue.DataSource = searchResults;
            EditDGVNguoiThue(); // Đảm bảo hàm định dạng cột được gọi
        }

        private void txtTimNT_Enter(object sender, EventArgs e)
        {
            if (txtTimNT.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimNT.Text = "";
                txtTimNT.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimNT_Leave(object sender, EventArgs e)
        {
            if (txtTimNT.Text == "")
            {
                txtTimNT.Text = "Nhập từ khóa để tìm kiếm";
                txtTimNT.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (dgvNguoiThue.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu người thuê để xuất!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("DanhSachNguoiThue");

                    // Tạo tiêu đề
                    worksheet.Cells[1, 1].Value = "DANH SÁCH NGƯỜI THUÊ";
                    worksheet.Cells[1, 1, 1, 6].Merge = true;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Size = 14;
                    worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    // Thông tin xuất file
                    worksheet.Cells[2, 1].Value = "Ngày xuất:";
                    worksheet.Cells[2, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[3, 1].Value = "Tổng số người thuê:";
                    worksheet.Cells[3, 2].Value = dgvNguoiThue.Rows.Count;

                    // Header - bắt đầu từ dòng 5
                    int startRow = 5;

                    worksheet.Cells[startRow, 1].Value = "ID Người Thuê";
                    worksheet.Cells[startRow, 2].Value = "Họ tên";
                    worksheet.Cells[startRow, 3].Value = "Số điện thoại";
                    worksheet.Cells[startRow, 4].Value = "CCCD";
                    worksheet.Cells[startRow, 5].Value = "Email";
                    worksheet.Cells[startRow, 6].Value = "Phòng";

                    // Chỉ in đậm header, không màu nền
                    using (var range = worksheet.Cells[startRow, 1, startRow, 6])
                    {
                        range.Style.Font.Bold = true;
                    }

                    // Đổ dữ liệu từ DataGridView
                    for (int i = 0; i < dgvNguoiThue.Rows.Count; i++)
                    {
                        int row = startRow + i + 1;

                        worksheet.Cells[row, 1].Value = dgvNguoiThue.Rows[i].Cells["IDNguoiThue"].Value?.ToString();
                        worksheet.Cells[row, 2].Value = dgvNguoiThue.Rows[i].Cells["HoTenNguoiThue"].Value?.ToString();
                        worksheet.Cells[row, 3].Value = dgvNguoiThue.Rows[i].Cells["SoDienThoai"].Value?.ToString();
                        worksheet.Cells[row, 4].Value = dgvNguoiThue.Rows[i].Cells["CCCD"].Value?.ToString();
                        worksheet.Cells[row, 5].Value = dgvNguoiThue.Rows[i].Cells["Email"].Value?.ToString();
                        worksheet.Cells[row, 6].Value = dgvNguoiThue.Rows[i].Cells["TenPhong"].Value?.ToString();
                    }

                    // Auto fit columns để hiển thị đẹp
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Thêm border nhẹ cho toàn bộ bảng
                    int endRow = startRow + dgvNguoiThue.Rows.Count;
                    using (var range = worksheet.Cells[startRow, 1, endRow, 6])
                    {
                        range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }

                    // Hiển thị dialog lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.FileName = $"DanhSachNguoiThue_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(excelFile);

                        MessageBox.Show($"Xuất Excel thành công!\nTổng số người thuê: {dgvNguoiThue.Rows.Count}",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
