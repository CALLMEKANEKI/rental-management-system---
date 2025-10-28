using BLL.Services;
using DAL.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmLePhi : Form
    {
        private lephiService _lephiService = new lephiService();
        private string id_chutrohientai = string.Empty;

        public frmLePhi()
        {
            InitializeComponent();
            this.id_chutrohientai = MAIN.main.LOGIN.id_chutrohientai;
            LoadDGVLePhi();
        }

        private void LoadDGVLePhi()
        {
            try
            {
                List<lephiViewModel> listLePhi = _lephiService.LayTatCaBanGhiLePhiViewModel(id_chutrohientai);
                dgvLePhi.DataSource = listLePhi;
                EditDGVLePhi();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void EditDGVLePhi()
        {
            dgvLePhi.Columns["IdLePhi"].HeaderText = "Mã bản ghi lẹ phí";
            dgvLePhi.Columns["IdLePhi"].DisplayIndex = 0;

            dgvLePhi.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvLePhi.Columns["NgayTao"].DisplayIndex = 1;

            dgvLePhi.Columns["TenPhong"].HeaderText = "Phòng";
            dgvLePhi.Columns["TenPhong"].DisplayIndex = 2;

            dgvLePhi.Columns["TienPhong"].HeaderText = "Tiền phòng";
            dgvLePhi.Columns["TienPhong"].DisplayIndex = 3;
            dgvLePhi.Columns["TienPhong"].DefaultCellStyle.Format = "N0";

            dgvLePhi.Columns["TienDV"].HeaderText = "Tiền dịch vụ";
            dgvLePhi.Columns["TienDV"].DisplayIndex = 4;
            dgvLePhi.Columns["TienDV"].DefaultCellStyle.Format = "N0";

            dgvLePhi.Columns["TienLePhi"].HeaderText = "Tiền lệ phí";
            dgvLePhi.Columns["TienLePhi"].DisplayIndex = 5;
            dgvLePhi.Columns["TienLePhi"].DefaultCellStyle.Format = "N0";

            dgvLePhi.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvLePhi.Columns["TrangThai"].DisplayIndex = 6;

            // Cho phép chọn toàn bộ hàng
            dgvLePhi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ClearDataLePhi()
        {
            txtMaLePhi.Text = "";
            txtTienPhong.Text = "";
            txtTienDV.Text = "";
            txtTrangThai.Text = "";
            txtPhong.Text = "";
            txtLePhi.Text = "";
            dtpNgayTao.Value = DateTime.Now;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearDataLePhi();
            LoadDGVLePhi();
        }

        public void DGVLePhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLePhi.Rows[e.RowIndex];

                object GetValue(string columnName)
                {
                    return row.Cells[columnName].Value;
                }

                txtMaLePhi.Text = GetValue("IdLePhi")?.ToString() ?? string.Empty;
                if (GetValue("NgayTao") is DateTime ngayTao)
                {
                    dtpNgayTao.Value = ngayTao;
                }
                txtTienPhong.Text = GetValue("TienPhong")?.ToString() ?? "0";
                txtTienDV.Text = GetValue("TienDV")?.ToString() ?? "0";
                txtLePhi.Text = GetValue("TienLePhi")?.ToString() ?? "0";
                txtPhong.Text = GetValue("TenPhong")?.ToString() ?? "0";
                txtTrangThai.Text = GetValue("TrangThai")?.ToString() ?? "0";
            }
        }
        private void txtTimLePhi_Enter(object sender, EventArgs e)
        {
            if (txtTimLePhi.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimLePhi.Text = "";
                txtTimLePhi.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimLePhi_Leave(object sender, EventArgs e)
        {
            if (txtTimLePhi.Text == "")
            {
                txtTimLePhi.Text = "Nhập từ khóa để tìm kiếm";
                txtTimLePhi.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnTimLePhi_Click(object sender, EventArgs e)
        {
            string keyword = txtTimLePhi.Text.Trim();

            // 1. Kiểm tra từ khóa
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi Service để tìm kiếm
            List<lephiViewModel> searchResults = _lephiService.LayTatCaBanGhiLePhiViewModelTheoKeyWord(id_chutrohientai, keyword);

            // 3. Xử lý kết quả tìm kiếm
            if (searchResults == null || searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bản ghi lẹ phí nào phù hợp với từ khóa: " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Load DataGridView với kết quả mới
            dgvLePhi.DataSource = searchResults;
            EditDGVLePhi();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (dgvLePhi.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn để xuất!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("DanhSachBanGhiDien");

                    // Tạo tiêu đề
                    worksheet.Cells[1, 1].Value = "DANH SÁCH BẢN GHI LỆ PHÍ";
                    worksheet.Cells[1, 1, 1, 10].Merge = true;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Size = 14;
                    worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    // Thông tin xuất file
                    worksheet.Cells[2, 1].Value = "Ngày xuất:";
                    worksheet.Cells[2, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[3, 1].Value = "Tổng số bản ghi:";
                    worksheet.Cells[3, 2].Value = dgvLePhi.Rows.Count;

                    // Header - bắt đầu từ dòng 5
                    int startRow = 5;

                    worksheet.Cells[startRow, 1].Value = "ID bản ghi";
                    worksheet.Cells[startRow, 2].Value = "Ngày Tạo";
                    worksheet.Cells[startRow, 3].Value = "Phòng";
                    worksheet.Cells[startRow, 4].Value = "Tiền phòng";
                    worksheet.Cells[startRow, 5].Value = "Tiền dịch vụ";
                    worksheet.Cells[startRow, 6].Value = "Tổng lệ phí";
                    worksheet.Cells[startRow, 7].Value = "Trạng Thái";

                    // Chỉ in đậm header, không màu nền
                    using (var range = worksheet.Cells[startRow, 1, startRow, 10])
                    {
                        range.Style.Font.Bold = true;
                    }

                    // Đổ dữ liệu từ DataGridView
                    for (int i = 0; i < dgvLePhi.Rows.Count; i++)
                    {
                        int row = startRow + i + 1;

                        worksheet.Cells[row, 1].Value = dgvLePhi.Rows[i].Cells["IdLePhi"].Value?.ToString();

                        // Định dạng ngày tháng
                        var ngayTao = dgvLePhi.Rows[i].Cells["NgayTao"].Value;
                        if (ngayTao != null && DateTime.TryParse(ngayTao.ToString(), out DateTime ngayTaoValue))
                        {
                            worksheet.Cells[row, 2].Value = ngayTaoValue;
                            worksheet.Cells[row, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                        }
                        else
                        {
                            worksheet.Cells[row, 2].Value = ngayTao?.ToString();
                        }

                        worksheet.Cells[row, 3].Value = dgvLePhi.Rows[i].Cells["TenPhong"].Value?.ToString();
                        worksheet.Cells[row, 4].Value = dgvLePhi.Rows[i].Cells["TrangThai"].Value?.ToString();
                        // Định dạng các cột tiền
                        FormatCurrencyCell(worksheet, row, 5, dgvLePhi.Rows[i].Cells["TienPhong"].Value); // Tiền Phòng
                        FormatCurrencyCell(worksheet, row, 6, dgvLePhi.Rows[i].Cells["TienDV"].Value); // Tiền Điện
                        FormatCurrencyCell(worksheet, row, 7, dgvLePhi.Rows[i].Cells["TienLePhi"].Value); // Tiền Nước
                    }

                    // Auto fit columns để hiển thị đẹp
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Thêm border nhẹ cho toàn bộ bảng
                    int endRow = startRow + dgvLePhi.Rows.Count;
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
                    for (int i = 0; i < dgvLePhi.Rows.Count; i++)
                    {
                        var thanhTienValue = dgvLePhi.Rows[i].Cells["TienDien"].Value;
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
                    worksheet.Cells[summaryRow + 1, 1].Style.Font.Bold = true;

                    decimal thucNhan = 0;
                    for (int i = 0; i < dgvLePhi.Rows.Count; i++)
                    {
                        var thanhTienValue = dgvLePhi.Rows[i].Cells["TienDien"].Value;
                        var trangthai = dgvLePhi.Rows[i].Cells["TrangThai"].Value?.ToString();
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
                    worksheet.Cells[summaryRow + 2, 9].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow + 2, 9].Style.Font.Bold = true;

                    // Thống kê trạng thái
                    int statsRow = summaryRow + 3;
                    worksheet.Cells[statsRow, 1].Value = "THỐNG KÊ TRẠNG THÁI:";
                    worksheet.Cells[statsRow, 1].Style.Font.Bold = true;

                    var thongKeTrangThai = dgvLePhi.Rows.Cast<DataGridViewRow>()
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
                    saveFileDialog.FileName = $"DanhSachBanGhiLePhi_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(excelFile);

                        MessageBox.Show($"Xuất Excel thành công!\nTổng số bản ghi lệ phí: {dgvLePhi.Rows.Count}\nTổng doanh thu: {tongTien:N0} VNĐ",
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
