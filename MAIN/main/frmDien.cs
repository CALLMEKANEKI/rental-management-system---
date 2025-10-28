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
    public partial class frmDien : Form
    {
        private dienService _dienService = new dienService();
        private string id_chutrohientai;
        public frmDien()
        {
            InitializeComponent();
            this.id_chutrohientai = main.LOGIN.id_chutrohientai;
            LoadDataDien();
           
        }

        public void LoadDataDien()
        {
            try
            {
                List<dienViewModel> ListDien = _dienService.LatTatCaBanGhiDienViewModel(id_chutrohientai);
                dgvDien.DataSource = ListDien;
                EditdgvDien();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ClearDataDien()
        {
            txtMaDien.Text = "";
            txtChiSoDau.Text = "";
            txtChiSoCuoi.Text = "";
            txtTienDien.Text = "";
            txtPhong.Text = "";
            txtTienDien.Text = "";
            dtpNgayTao.Value = DateTime.Now;
        }
        
        public void EditdgvDien()
        {
            dgvDien.Columns["IdDien"].HeaderText = "Mã bản ghi điện";
            dgvDien.Columns["IdDien"].DisplayIndex = 0;

            dgvDien.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvDien.Columns["NgayTao"].DisplayIndex = 1;

            dgvDien.Columns["TenPhong"].HeaderText = "Phòng";
            dgvDien.Columns["TenPhong"].DisplayIndex = 2;

            dgvDien.Columns["ChiSo_Dau"].HeaderText = "Chỉ số cũ";
            dgvDien.Columns["ChiSo_Dau"].DisplayIndex = 3;

            dgvDien.Columns["ChiSo_Cuoi"].HeaderText = "Chỉ số mới";
            dgvDien.Columns["ChiSo_Cuoi"].DisplayIndex = 4;

            dgvDien.Columns["TienDien"].HeaderText = "Tiền điện";
            dgvDien.Columns["TienDien"].DisplayIndex = 5;
            dgvDien.Columns["TienDien"].DefaultCellStyle.Format = "N0";

            dgvDien.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvDien.Columns["TrangThai"].DisplayIndex = 6;

            // Cho phép chọn toàn bộ hàng
            dgvDien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void DGVDien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDien.Rows[e.RowIndex];

                object GetValue(string columnName)
                {
                    return row.Cells[columnName].Value;
                }

                txtMaDien.Text = GetValue("IdDien")?.ToString() ?? string.Empty;
                if (GetValue("NgayTao") is DateTime ngayTao)
                {
                    dtpNgayTao.Value = ngayTao;
                }
                txtChiSoDau.Text = GetValue("ChiSo_Dau")?.ToString() ?? "0";
                txtChiSoCuoi.Text = GetValue("ChiSo_Cuoi")?.ToString() ?? "0";
                txtTienDien.Text = GetValue("TienDien")?.ToString() ?? "0";
                txtPhong.Text = GetValue("TenPhong")?.ToString() ?? "0";
                txtTrangThai.Text = GetValue("TrangThai")?.ToString() ?? "0";
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearDataDien();
            LoadDataDien();
        }

        private void txtTimDien_Enter(object sender, EventArgs e)
        {
            if (txtTimDien.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimDien.Text = "";
                txtTimDien.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimDien_Leave(object sender, EventArgs e)
        {
            if (txtTimDien.Text == "")
            {
                txtTimDien.Text = "Nhập từ khóa để tìm kiếm";
                txtTimDien.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnTimDien_Click(object sender, EventArgs e)
        {
            string keyword = txtTimDien.Text.Trim();

            // 1. Kiểm tra từ khóa
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa  để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi Service để tìm kiếm
            List<dienViewModel> searchResults = _dienService.LatTatCaBanGhiDienViewModelTheoKeyWord(id_chutrohientai, keyword);

            // 3. Xử lý kết quả tìm kiếm
            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bản ghi điện nào phù hợp với từ khóa: " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Load DataGridView với kết quả mới
            dgvDien.DataSource = searchResults;
            EditdgvDien();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (dgvDien.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn để xuất!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("DanhSachBanGhiDien");

                    // Tạo tiêu đề
                    worksheet.Cells[1, 1].Value = "DANH SÁCH BẢN GHI ĐIỆN";
                    worksheet.Cells[1, 1, 1, 10].Merge = true;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Size = 14;
                    worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    // Thông tin xuất file
                    worksheet.Cells[2, 1].Value = "Ngày xuất:";
                    worksheet.Cells[2, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[3, 1].Value = "Tổng số bản ghi:";
                    worksheet.Cells[3, 2].Value = dgvDien.Rows.Count;

                    // Header - bắt đầu từ dòng 5
                    int startRow = 5;

                    worksheet.Cells[startRow, 1].Value = "ID bản ghi";
                    worksheet.Cells[startRow, 2].Value = "Ngày Tạo";
                    worksheet.Cells[startRow, 3].Value = "Phòng";
                    worksheet.Cells[startRow, 4].Value = "Chỉ số cũ";
                    worksheet.Cells[startRow, 5].Value = "Chỉ số mới";
                    worksheet.Cells[startRow, 6].Value = "Tiền Điện";
                    worksheet.Cells[startRow, 7].Value = "Trạng Thái";

                    // Chỉ in đậm header, không màu nền
                    using (var range = worksheet.Cells[startRow, 1, startRow, 10])
                    {
                        range.Style.Font.Bold = true;
                    }

                    // Đổ dữ liệu từ DataGridView
                    for (int i = 0; i < dgvDien.Rows.Count; i++)
                    {
                        int row = startRow + i + 1;

                        worksheet.Cells[row, 1].Value = dgvDien.Rows[i].Cells["IdDien"].Value?.ToString();

                        // Định dạng ngày tháng
                        var ngayTao = dgvDien.Rows[i].Cells["NgayTao"].Value;
                        if (ngayTao != null && DateTime.TryParse(ngayTao.ToString(), out DateTime ngayTaoValue))
                        {
                            worksheet.Cells[row, 2].Value = ngayTaoValue;
                            worksheet.Cells[row, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            worksheet.Cells[row, 2].Value = ngayTao?.ToString();
                        }

                        worksheet.Cells[row, 3].Value = dgvDien.Rows[i].Cells["TenPhong"].Value?.ToString();
                        worksheet.Cells[row, 4].Value = dgvDien.Rows[i].Cells["TrangThai"].Value?.ToString();
                        // Định dạng các cột tiền
                        FormatCurrencyCell(worksheet, row, 5, dgvDien.Rows[i].Cells["ChiSo_Dau"].Value); // Tiền Phòng
                        FormatCurrencyCell(worksheet, row, 6, dgvDien.Rows[i].Cells["ChiSo_Cuoi"].Value); // Tiền Điện
                        FormatCurrencyCell(worksheet, row, 7, dgvDien.Rows[i].Cells["TienDien"].Value); // Tiền Nước
                    }

                    // Auto fit columns để hiển thị đẹp
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Thêm border nhẹ cho toàn bộ bảng
                    int endRow = startRow + dgvDien.Rows.Count;
                    using (var range = worksheet.Cells[startRow, 1, endRow, 10])
                    {
                        range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }

                    // Thống kê tổng tiền
                    int summaryRow = endRow + 2;
                    worksheet.Cells[summaryRow, 1].Value = "TỔNG DOANH THU:";
                    worksheet.Cells[summaryRow, 1].Style.Font.Bold = true;

                    decimal tongTien = 0;
                    for (int i = 0; i < dgvDien.Rows.Count; i++)
                    {
                        var thanhTienValue = dgvDien.Rows[i].Cells["TienDien"].Value;
                        if (thanhTienValue != null && decimal.TryParse(thanhTienValue.ToString(), out decimal thanhTien))
                        {
                            tongTien += thanhTien;
                        }
                    }
                    worksheet.Cells[summaryRow, 9].Value = tongTien;
                    worksheet.Cells[summaryRow, 9].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow, 9].Style.Font.Bold = true;

                    //Thực nhận
                    worksheet.Cells[summaryRow + 1, 1].Value = "THỰC NHẬN";
                    worksheet.Cells[summaryRow + 1 , 1].Style.Font.Bold = true;

                    decimal thucNhan = 0;
                    for (int i = 0; i < dgvDien.Rows.Count; i++)
                    {
                        var thanhTienValue = dgvDien.Rows[i].Cells["TienDien"].Value;
                        var trangthai = dgvDien.Rows[i].Cells["TrangThai"].Value?.ToString();
                        if (thanhTienValue != null && decimal.TryParse(thanhTienValue.ToString(), out decimal thanhTien) && trangthai == "Đã thanh toán")
                        {
                            thucNhan += thanhTien;
                        }
                    }
                    worksheet.Cells[summaryRow + 1, 9].Value = thucNhan;
                    worksheet.Cells[summaryRow + 1, 9].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow + 1, 9].Style.Font.Bold = true;


                    //Còn thiếu
                    worksheet.Cells[summaryRow + 2, 1].Value = "CÒN THIẾU";
                    worksheet.Cells[summaryRow + 2, 1].Style.Font.Bold = true;

                    worksheet.Cells[summaryRow + 2, 9].Value = tongTien - thucNhan;
                    worksheet.Cells[summaryRow+ 2, 9].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow + 2, 9].Style.Font.Bold = true;

                    // Thống kê trạng thái
                    int statsRow = summaryRow + 3;
                    worksheet.Cells[statsRow, 1].Value = "THỐNG KÊ TRẠNG THÁI:";
                    worksheet.Cells[statsRow, 1].Style.Font.Bold = true;

                    var thongKeTrangThai = dgvDien.Rows.Cast<DataGridViewRow>()
                          .GroupBy(r => r.Cells["TrangThai"].Value?.ToString() ?? "Không xác định")
                        .Select(g => new { TrangThai = g.Key, SoLuong = g.Count() });

                    int statDetailRow = statsRow + 1;
                    foreach (var stat in thongKeTrangThai)
                    {
                        worksheet.Cells[statDetailRow, 1].Value = $"- {stat.TrangThai}:";
                        worksheet.Cells[statDetailRow, 2].Value = stat.SoLuong;
                        statDetailRow++;
                    }

                    // Hiển thị dialog lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.FileName = $"DanhSachBanGhiDien_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(excelFile);

                        MessageBox.Show($"Xuất Excel thành công!\nTổng số bản ghi điện: {dgvDien.Rows.Count}\nTổng doanh thu: {tongTien:N0} VNĐ",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hỗ trợ định dạng ô tiền tệ
        private void FormatCurrencyCell(ExcelWorksheet worksheet, int row, int col, object value)
        {
            if (value != null && decimal.TryParse(value.ToString(), out decimal number))
            {
                worksheet.Cells[row, col].Value = number;
                worksheet.Cells[row, col].Style.Numberformat.Format = "#,##0";
            }
            else
            {
                worksheet.Cells[row, col].Value = value?.ToString();
            }
        }
    }
}
