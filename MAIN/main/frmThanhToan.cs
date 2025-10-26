using BLL.Services;
using DAL.Model;
using DAL.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmThanhToan : Form
    {
        private hoadonService _hoadonService = new hoadonService();
        private phongtroService _phongtroService = new phongtroService();
        private thanhtoanService _thanhtoanService = new thanhtoanService();
        private nguoithueService _nguoithueService = new nguoithueService();
        private string _idHoaDonDangChon = null;
        private string _idNguoiThueDangChon = null;
        private string id_chutrohientai;

        public frmThanhToan()
        {
            InitializeComponent();
            id_chutrohientai = MAIN.main.LOGIN.id_chutrohientai;
            LoadComboBoxHoaDon();
            LoadDataThanhToan();
        }

        public void LoadDataThanhToan()
        {
            try
            {
                List<thanhToanViewModel> listThanhToan = _thanhtoanService.LayAllThanhToanViewModel(id_chutrohientai);
                dgvThanhToan.DataSource = listThanhToan;
                EditDGVThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử thanh toán: {ex.Message}", "Lỗi Tải Dữ Liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditDGVThanhToan()
        {
            // Thiết lập tên cột hiển thị
            dgvThanhToan.Columns["MaHD"].HeaderText = "Mã HĐ";
            dgvThanhToan.Columns["TenNguoiThanhToan"].HeaderText = "Người Trả";
            dgvThanhToan.Columns["TenPhong"].HeaderText = "Phòng";
            dgvThanhToan.Columns["NoiDung"].HeaderText = "Nội dung";

            // Định dạng tiền tệ và căn lề phải
            var currencyStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight };
            dgvThanhToan.Columns["LePhi"].DefaultCellStyle = currencyStyle;
            dgvThanhToan.Columns["TienDien"].DefaultCellStyle = currencyStyle;
            dgvThanhToan.Columns["TienNuoc"].DefaultCellStyle = currencyStyle;
            dgvThanhToan.Columns["ThanhTien"].DefaultCellStyle = currencyStyle;

            dgvThanhToan.Columns["LePhi"].HeaderText = "Tổng lệ Phí";
            dgvThanhToan.Columns["TienDien"].HeaderText = "Tiền điện";
            dgvThanhToan.Columns["TienNuoc"].HeaderText = "Tiền nước";
            dgvThanhToan.Columns["ThanhTien"].HeaderText = "Thành tiền";

            // Căn giữa ngày tháng
            var dateStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };
            dgvThanhToan.Columns["NgayTao"].DefaultCellStyle = dateStyle;
            dgvThanhToan.Columns["NgayThanhToan"].DefaultCellStyle = dateStyle;


            dgvThanhToan.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvThanhToan.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
            // Thêm nút Chi tiết (Chỉ thêm 1 lần)
            if (dgvThanhToan.Columns.Cast<DataGridViewColumn>().All(c => c.Name != "btnChiTiet"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = "Thao tác";
                btnColumn.Text = "Chi tiết";
                btnColumn.Name = "btnChiTiet";
                btnColumn.UseColumnTextForButtonValue = true;
                dgvThanhToan.Columns.Add(btnColumn);
            }
            dgvThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvLichSuThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvThanhToan.Columns["btnChiTiet"].Index)
                return;

            try
            {
                string maHoaDon = dgvThanhToan.Rows[e.RowIndex].Cells["MaHD"].Value?.ToString();

                if (string.IsNullOrEmpty(maHoaDon))
                {
                    MessageBox.Show("Không tìm thấy Mã Hóa Đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmChiTietThanhToan fChiTiet = new frmChiTietThanhToan(maHoaDon);
                fChiTiet.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetValueFromDisplay(ComboBox cbo, string displayValue)
        {
            // Kiểm tra xem DataSource có phải là List<nguoi_thue> không
            if (cbo.DataSource is List<nguoi_thue> listNguoiThue)
            {
                // Dùng LINQ để tìm đối tượng có hoten khớp
                var nguoiThue = listNguoiThue
                    .FirstOrDefault(nt => nt.hoten.Equals(displayValue, StringComparison.OrdinalIgnoreCase));

                // Nếu tìm thấy, trả về id_nguoi_thue
                if (nguoiThue != null)
                {
                    return nguoiThue.id_nguoi_thue;
                }
            }
            return null; // Không tìm thấy hoặc DataSource không hợp lệ
        }

        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row = dgvThanhToan.Rows[e.RowIndex];
                string maHDTuGrid = row.Cells["MaHD"].Value?.ToString();
                string tenNguoiThueTuGrid = row.Cells["TenNguoiThanhToan"].Value?.ToString();

                // 1. GÁN CÁC CONTROLS KHÔNG PHỤ THUỘC
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                txtPhong.Text = row.Cells["TenPhong"].Value?.ToString();
                txtLePhi.Text = row.Cells["LePhi"].Value?.ToString();
                txtTienNuoc.Text = row.Cells["TienNuoc"].Value?.ToString();
                txtTienDien.Text = row.Cells["TienDien"].Value?.ToString();
                txtTongTien.Text = row.Cells["ThanhTien"].Value?.ToString();

                // Gán DatetimePickers
                if (row.Cells["NgayTao"].Value != null && row.Cells["NgayTao"].Value != DBNull.Value)
                {
                    dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                }
                if (row.Cells["NgayThanhToan"].Value != null && row.Cells["NgayThanhToan"].Value != DBNull.Value)
                {
                    dtpNgayThanhToan.Value = Convert.ToDateTime(row.Cells["NgayThanhToan"].Value);
                }

                // 2. GÁN COMBOBOX HÓA ĐƠN VÀ KÍCH HOẠT SỰ KIỆN TẢI NGƯỜI THUÊ
                if (!string.IsNullOrEmpty(maHDTuGrid))
                {
                    // TÌM Index của Mã Hóa Đơn trong cboHoaDon
                    int selectedIndex = -1;
                    for (int i = 0; i < cboHoaDon.Items.Count; i++)
                    {
                        // So sánh ValueMember (id_hoadon) với giá trị từ lưới
                        // LƯU Ý: Phải truy cập ValueMember, không phải DisplayMember
                        if (cboHoaDon.GetItemText(cboHoaDon.Items[i]).Contains(maHDTuGrid))
                        {
                            // Lỗi: GetItemText lấy DisplayMember (Tên hiển thị), thường không phải MaHD duy nhất.
                            // CÁCH KHẮC PHỤC: Giả định DisplayMember là "MaHD - Tên khác"
                            // hoặc bạn phải truy cập DataSource của cboHoaDon để tìm theo ID.

                            // Nếu bạn dùng cboHoaDon.Text = maHDTuGrid (như code cũ), bạn phải chuyển sang SelectedIndex/SelectedValue
                            // Tạm thời dùng code cũ của bạn, nhưng KHÔNG NÊN DÙNG .Text:
                            // cboHoaDon.Text = maHDTuGrid; // Lỗi: Không kích hoạt SelectedIndexChanged

                            // SỬA: Thay thế bằng SelectedIndex (Ưu tiên)
                            selectedIndex = i;
                            break;
                        }
                    }

                    // Gán SelectedIndex sẽ kích hoạt cboHoaDon_SelectedIndexChanged (gọi LoadComboBoxNguoiThue)
                    if (selectedIndex != -1)
                    {
                        cboHoaDon.SelectedIndex = selectedIndex;
                    }
                    else
                    {
                        cboHoaDon.SelectedIndex = -1; // Reset nếu không tìm thấy
                    }

                    // Lưu ID Hóa Đơn
                    _idHoaDonDangChon = maHDTuGrid;
                }
                else
                {
                    cboHoaDon.SelectedIndex = -1;
                    _idHoaDonDangChon = null;
                }


                // 3. TÌM ID NGƯỜI THUÊ GỐC VÀ GÁN (CHỈ THỰC HIỆN SAU KHI CBO NGƯỜI THUÊ ĐƯỢC LOAD)
                // Vì cboHoaDon.SelectedIndex đã chạy và tải cboNguoiThue, ta có thể dùng hàm GetValueFromDisplay
                if (!string.IsNullOrEmpty(tenNguoiThueTuGrid) && cboNguoiThue.DataSource != null)
                {
                    // TÌM VALUE MEMBER (id_nguoi_thue) TỪ DISPLAY MEMBER (hoten)
                    string idNguoiThueGocTimDuoc = GetValueFromDisplay(cboNguoiThue, tenNguoiThueTuGrid);

                    if (!string.IsNullOrEmpty(idNguoiThueGocTimDuoc))
                    {
                        // Gán SelectedValue để ComboBox hiển thị đúng và lưu ID Gốc
                        cboNguoiThue.SelectedValue = idNguoiThueGocTimDuoc;
                        _idNguoiThueDangChon = idNguoiThueGocTimDuoc;
                    }
                    else
                    {
                        // Xử lý nếu không tìm thấy ID Người Thuê (ví dụ: người thuê đã bị xóa)
                        cboNguoiThue.SelectedIndex = -1;
                        _idNguoiThueDangChon = null;
                    }
                }
                else
                {
                    cboNguoiThue.SelectedIndex = -1;
                    _idNguoiThueDangChon = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadComboBoxHoaDon()
        {
            try
            {
                var listHoaDon = _hoadonService.LayTatCaHoaDon(id_chutrohientai);

                if (listHoaDon != null && listHoaDon.Any())
                {
                    cboHoaDon.DataSource = listHoaDon;
                    cboHoaDon.DisplayMember = "id_hoadon";
                    cboHoaDon.ValueMember = "id_hoadon";
                    cboHoaDon.SelectedIndex = -1;
                }
                else
                {
                    cboHoaDon.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách hóa đơn: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadComboBoxNguoiThue(string id_hoadon)
        {
            try
            {
                hoadon temp = _hoadonService.LayHoaDonTheoId(id_chutrohientai, id_hoadon);
                List<nguoi_thue> listNguoiThue = _nguoithueService.LayTatCaNguoiThueTheoPhong(id_chutrohientai, temp.id_phong);

                if (listNguoiThue != null && listNguoiThue.Any())
                {
                    cboNguoiThue.DataSource = listNguoiThue;
                    cboNguoiThue.DisplayMember = "hoten";
                    cboNguoiThue.ValueMember = "id_nguoi_thue";
                    cboNguoiThue.SelectedIndex = -1;
                }
                else
                {
                    cboNguoiThue.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách người thuê: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ComboBoxHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHoaDon.SelectedIndex == -1)
            {
                ClearThanhToan();
                return;
            }

            try
            {
                string idHoaDon = cboHoaDon.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(idHoaDon))
                {
                    MessageBox.Show("Không thể lấy ID hóa đơn", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                hoadonViewModel objHoaDon = _hoadonService.LayHoaDonViewModelTheoID(idHoaDon, id_chutrohientai);

                if (objHoaDon == null  && idHoaDon != "-1")
                {
                    ClearThanhToan();
                    return;
                }
                else
                {
                    // Đổ dữ liệu lên controls
                    txtPhong.Text = objHoaDon.TenPhong;
                    dtpNgayTao.Value = objHoaDon.NgayTao;
                    txtNoiDung.Text = objHoaDon.NoiDung;

                    // Định dạng tiền tệ
                    txtLePhi.Text = (objHoaDon.Tien_dv + objHoaDon.Tien_Phong).ToString("N0");
                    txtTienDien.Text = objHoaDon.ThanhTien_Dien.ToString("N0");
                    txtTienNuoc.Text = objHoaDon.ThanhTien_Nuoc.ToString("N0");
                    txtTongTien.Text = objHoaDon.ThanhTien.ToString("N0");

                    // Tải danh sách Người Thuê
                    LoadComboBoxNguoiThue(objHoaDon.IDHoaDon);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý chi tiết hóa đơn: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearThanhToan()
        {
            txtPhong.Text = string.Empty;
            dtpNgayTao.Value = DateTime.Now;
            txtNoiDung.Text = string.Empty;
            txtLePhi.Text = "0";
            txtTienDien.Text = "0";
            txtTienNuoc.Text = "0";
            txtTongTien.Text = "0";
            cboNguoiThue.DataSource = null;
        }

        private void txtTimThanhToan_Enter(object sender, EventArgs e)
        {
            if (txtTimThanhToan.Text == "Nhập từ khóa để tìm kiếm")
            {
                txtTimThanhToan.Text = "";
                txtTimThanhToan.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtThanhToan_Leave(object sender, EventArgs e)
        {
            if (txtTimThanhToan.Text == "")
            {
                txtTimThanhToan.Text = "Nhập từ khóa để tìm kiếm";
                txtTimThanhToan.ForeColor = System.Drawing.Color.Gray;
            }
        }

        public void isThanhToanEditting(bool mode)
        {
            cboNguoiThue.Enabled = mode;
            dtpNgayThanhToan.Enabled = mode;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataThanhToan();
            ClearThanhToan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra dữ liệu bắt buộc
                string idHoaDon = cboHoaDon.SelectedValue?.ToString();
                string idNguoiThue = cboNguoiThue.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(idHoaDon) || string.IsNullOrEmpty(idNguoiThue))
                {
                    MessageBox.Show("Vui lòng chọn Mã Hóa Đơn và Người Thanh Toán.", "Thiếu Thông Tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpNgayThanhToan.Value > DateTime.Now)
                {
                    MessageBox.Show("Ngày thanh toán không hợp lệ!!! \n VUI LÒNG CHỌN LẠI");
                }
                else
                {
                    // 2. Tạo đối tượng Thanh Toán
                    thanh_toan newThanhToan = new thanh_toan
                    {
                        id_hoadon = idHoaDon,
                        id_nguoi_thue = idNguoiThue,
                        ngay_thanh_toan = dtpNgayThanhToan.Value,
                    };

                    // 3. Gọi Service để thêm
                    bool success = _thanhtoanService.ThemThanhToan(newThanhToan, id_chutrohientai);

                    if (success)
                    {
                        MessageBox.Show("Thêm thanh toán mới thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataThanhToan(); // Tải lại lưới
                        ClearThanhToan();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại. Hóa đơn có thể đã được thanh toán hoặc dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                  
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu tiền tệ không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "Sửa")
            {
                // Kiểm tra cặp khóa chính cũ đã được chọn chưa
                if (string.IsNullOrEmpty(_idHoaDonDangChon) || string.IsNullOrEmpty(_idNguoiThueDangChon))
                {
                    MessageBox.Show("Vui lòng chọn một lịch sử thanh toán để sửa thông tin.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Bây giờ bạn đã có thể chỉnh sửa Người Thanh Toán và Ngày Thanh Toán. \nNhấn vào nút Lưu để lưu thông tin.");
                // isThanhToanEditting(true); // Bật chỉnh sửa controls
                ((Button)sender).Text = "Lưu";
            }

            else if (btn.Text == "Lưu")
            {
                // 1. Kiểm tra cặp khóa chính gốc
                if (string.IsNullOrEmpty(_idHoaDonDangChon) || string.IsNullOrEmpty(_idNguoiThueDangChon))
                {
                    MessageBox.Show("Không tìm thấy dữ liệu gốc để sửa. Vui lòng chọn lại.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((Button)sender).Text = "Sửa";
                    // isThanhToanEditting(false);
                    return;
                }

                // 2. Lấy dữ liệu mới (chỉ lấy những trường được phép sửa)
                string newIdNguoiThue = cboNguoiThue.SelectedValue?.ToString();
                DateTime newNgayThanhToan = dtpNgayThanhToan.Value;

                if (string.IsNullOrEmpty(newIdNguoiThue))
                {
                    MessageBox.Show("Vui lòng chọn Người Thanh Toán mới.", "Thiếu Thông Tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // GỌI SERVICE: Truyền cặp khóa chính gốc, dữ liệu mới, và ID Chủ trọ
                    bool success = _thanhtoanService.SuaThanhToan(
                        _idHoaDonDangChon,          // Khóa chính cũ (ID Hóa Đơn)
                        _idNguoiThueDangChon,       // Khóa chính cũ (ID Người Thuê GỐC)
                        newIdNguoiThue,             // Dữ liệu mới (ID Người Thuê MỚI)
                        newNgayThanhToan,           // Dữ liệu mới (Ngày Thanh Toán MỚI)
                        id_chutrohientai
                    );

                    if (success)
                    {
                        MessageBox.Show("Cập nhật thanh toán thành công.", "Thành Công",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // ClearHoaDonDetails();
                        // isThanhToanEditting(false);
                        btn.Text = "Sửa";
                        LoadDataThanhToan();
                        ClearThanhToan();
                        // Reset cặp khóa chính sau khi hoàn tất
                        _idHoaDonDangChon = null;
                        _idNguoiThueDangChon = null;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Dữ liệu mới có thể đã tồn tại.", "Lỗi Lưu",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //---

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra cặp khóa chính cũ
            if (string.IsNullOrEmpty(_idHoaDonDangChon))
            {
                MessageBox.Show("Vui lòng chọn lịch sử thanh toán để xóa.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"LƯU Ý: Thao tác này sẽ xóa bản ghi thanh toán này và đặt lại Hóa đơn '{_idHoaDonDangChon}' về trạng thái 'Chưa thanh toán'. \n BẠN CHẮC CHẮN MUỐN XÓA?",
                "Xác nhận Xóa Thanh Toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // GỌI SERVICE VỚI CẶP KHÓA CHÍNH VÀ ID Chủ trọ
                    bool success = _thanhtoanService.XoaThanhToan(
                        _idHoaDonDangChon,
                        id_chutrohientai
                    );

                    if (success)
                    {
                        MessageBox.Show("Xóa thanh toán thành công.", "Thành Công",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // ClearHoaDonDetails();
                        LoadDataThanhToan();

                        // Reset cặp khóa chính
                        _idHoaDonDangChon = null;
                        _idNguoiThueDangChon = null;
                        ClearThanhToan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại.", "Lỗi Xóa",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //---

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimThanhToan.Text.Trim(); // Giả định txtTimThanhToan là TextBox tìm kiếm

            if (keyword == "Nhập từ khóa để tìm kiếm" || string.IsNullOrEmpty(keyword))
            {
                keyword = null;
            }

            // GỌI SERVICE: Sử dụng hàm tìm kiếm đã được sửa
            List<thanhToanViewModel> searchResults =
                _thanhtoanService.LayAllThanhToanViewModel(id_chutrohientai, keyword);

            if (searchResults == null || !searchResults.Any())
            {
                MessageBox.Show("Không tìm thấy lịch sử thanh toán nào phù hợp với từ khóa: " + keyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hiển thị danh sách rỗng nếu tìm kiếm không ra kết quả
                dgvThanhToan.DataSource = new List<thanhToanViewModel>();
                // EditDGVThanhToan();
                return;
            }

            // Load DataGridView với kết quả mới
            dgvThanhToan.DataSource = searchResults;
            // EditDGVThanhToan(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (dgvThanhToan.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thanh toán để xuất!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("DanhSachThanhToan");

                    // Tạo tiêu đề
                    worksheet.Cells[1, 1].Value = "LỊCH SỬ THANH TOÁN";
                    worksheet.Cells[1, 1, 1, 9].Merge = true;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Size = 14;
                    worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    // Thông tin xuất file
                    worksheet.Cells[2, 1].Value = "Ngày xuất:";
                    worksheet.Cells[2, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[3, 1].Value = "Tổng số giao dịch:";
                    worksheet.Cells[3, 2].Value = dgvThanhToan.Rows.Count;

                    // Header - bắt đầu từ dòng 5
                    int startRow = 5;

                    worksheet.Cells[startRow, 1].Value = "Mã HĐ";
                    worksheet.Cells[startRow, 2].Value = "Người Trả";
                    worksheet.Cells[startRow, 3].Value = "Phòng";
                    worksheet.Cells[startRow, 4].Value = "Nội dung";
                    worksheet.Cells[startRow, 5].Value = "Tổng lệ Phí";
                    worksheet.Cells[startRow, 6].Value = "Tiền điện";
                    worksheet.Cells[startRow, 7].Value = "Tiền nước";
                    worksheet.Cells[startRow, 8].Value = "Thành tiền";
                    worksheet.Cells[startRow, 9].Value = "Ngày tạo";
                    worksheet.Cells[startRow, 10].Value = "Ngày thanh toán";

                    // Chỉ in đậm header, không màu nền
                    using (var range = worksheet.Cells[startRow, 1, startRow, 10])
                    {
                        range.Style.Font.Bold = true;
                    }

                    // Đổ dữ liệu từ DataGridView (bỏ qua cột nút Chi tiết)
                    for (int i = 0; i < dgvThanhToan.Rows.Count; i++)
                    {
                        int row = startRow + i + 1;

                        worksheet.Cells[row, 1].Value = dgvThanhToan.Rows[i].Cells["MaHD"].Value?.ToString();
                        worksheet.Cells[row, 2].Value = dgvThanhToan.Rows[i].Cells["TenNguoiThanhToan"].Value?.ToString();
                        worksheet.Cells[row, 3].Value = dgvThanhToan.Rows[i].Cells["TenPhong"].Value?.ToString();
                        worksheet.Cells[row, 4].Value = dgvThanhToan.Rows[i].Cells["NoiDung"].Value?.ToString();

                        // Định dạng các cột tiền
                        FormatCurrencyCell(worksheet, row, 5, dgvThanhToan.Rows[i].Cells["LePhi"].Value); // Tổng lệ Phí
                        FormatCurrencyCell(worksheet, row, 6, dgvThanhToan.Rows[i].Cells["TienDien"].Value); // Tiền điện
                        FormatCurrencyCell(worksheet, row, 7, dgvThanhToan.Rows[i].Cells["TienNuoc"].Value); // Tiền nước
                        FormatCurrencyCell(worksheet, row, 8, dgvThanhToan.Rows[i].Cells["ThanhTien"].Value); // Thành tiền

                        // Định dạng ngày tháng
                        FormatDateCell(worksheet, row, 9, dgvThanhToan.Rows[i].Cells["NgayTao"].Value); // Ngày tạo
                        FormatDateCell(worksheet, row, 10, dgvThanhToan.Rows[i].Cells["NgayThanhToan"].Value); // Ngày thanh toán
                    }

                    // Auto fit columns để hiển thị đẹp
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Thêm border nhẹ cho toàn bộ bảng
                    int endRow = startRow + dgvThanhToan.Rows.Count;
                    using (var range = worksheet.Cells[startRow, 1, endRow, 10])
                    {
                        range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }

                    // Thống kê tổng tiền
                    int summaryRow = endRow + 2;
                    worksheet.Cells[summaryRow, 1].Value = "TỔNG DOANH THU THANH TOÁN:";
                    worksheet.Cells[summaryRow, 1].Style.Font.Bold = true;

                    decimal tongThanhTien = 0;
                    decimal tongLePhi = 0;
                    decimal tongTienDien = 0;
                    decimal tongTienNuoc = 0;

                    for (int i = 0; i < dgvThanhToan.Rows.Count; i++)
                    {
                        tongThanhTien += GetDecimalValue(dgvThanhToan.Rows[i].Cells["ThanhTien"].Value);
                        tongLePhi += GetDecimalValue(dgvThanhToan.Rows[i].Cells["LePhi"].Value);
                        tongTienDien += GetDecimalValue(dgvThanhToan.Rows[i].Cells["TienDien"].Value);
                        tongTienNuoc += GetDecimalValue(dgvThanhToan.Rows[i].Cells["TienNuoc"].Value);
                    }

                    worksheet.Cells[summaryRow, 8].Value = tongThanhTien;
                    worksheet.Cells[summaryRow, 8].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[summaryRow, 8].Style.Font.Bold = true;

                    // Thống kê chi tiết
                    int detailRow = summaryRow + 1;
                    worksheet.Cells[detailRow, 1].Value = "Chi tiết:";
                    worksheet.Cells[detailRow, 1].Style.Font.Bold = true;

                    worksheet.Cells[detailRow + 1, 1].Value = "- Tổng lệ phí:";
                    worksheet.Cells[detailRow + 1, 5].Value = tongLePhi;
                    worksheet.Cells[detailRow + 1, 5].Style.Numberformat.Format = "#,##0";

                    worksheet.Cells[detailRow + 2, 1].Value = "- Tổng tiền điện:";
                    worksheet.Cells[detailRow + 2, 5].Value = tongTienDien;
                    worksheet.Cells[detailRow + 2, 5].Style.Numberformat.Format = "#,##0";

                    worksheet.Cells[detailRow + 3, 1].Value = "- Tổng tiền nước:";
                    worksheet.Cells[detailRow + 3, 5].Value = tongTienNuoc;
                    worksheet.Cells[detailRow + 3, 5].Style.Numberformat.Format = "#,##0";

                    // Hiển thị dialog lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.FileName = $"LichSuThanhToan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(excelFile);

                        MessageBox.Show($"Xuất Excel thành công!\nTổng số giao dịch: {dgvThanhToan.Rows.Count}\nTổng doanh thu: {tongThanhTien:N0} VNĐ",
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

        // Hàm hỗ trợ định dạng ô ngày tháng
        private void FormatDateCell(ExcelWorksheet worksheet, int row, int col, object value)
        {
            if (value != null && DateTime.TryParse(value.ToString(), out DateTime dateValue))
            {
                worksheet.Cells[row, col].Value = dateValue;
                worksheet.Cells[row, col].Style.Numberformat.Format = "dd/MM/yyyy";
            }
            else
            {
                worksheet.Cells[row, col].Value = value?.ToString();
            }
        }

        // Hàm lấy giá trị decimal
        private decimal GetDecimalValue(object value)
        {
            if (value != null && decimal.TryParse(value.ToString(), out decimal number))
            {
                return number;
            }
            return 0;
        }
    }
}