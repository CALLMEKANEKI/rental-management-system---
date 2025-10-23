using BLL.BLL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class Validators
    {
        static ContextDB _contextDB = new ContextDB();
        static chutroBLL ChuTroBLL = new chutroBLL();
        static nguoithueBLL NguoiThueBLL = new nguoithueBLL();
        static phongtroBLL PhongTroBLL = new phongtroBLL();
        static hopdongBLL HopDongBLL = new hopdongBLL();
        static hoadonBLL hoadonBLL = new hoadonBLL();

        public static bool ValidateChuTro(chutro chuTro, out string errorMessage, bool forSignUp = false)
        {
            errorMessage = string.Empty;

            if (chuTro == null)
            {
                errorMessage = "Dữ liệu Chủ trọ không được null.";
                return false;
            }

            // ID: vẫn kiểm tra nhưng nới lỏng cho SignUp
            if (string.IsNullOrEmpty(chuTro.id_chutro) || chuTro.id_chutro.Length > 10)
            {
                errorMessage = "ID Chủ trọ không hợp lệ (Không được rỗng và tối đa 10 ký tự).";
                return false;
            }

            // Nếu KHÔNG phải đăng ký => kiểm tra đầy đủ các trường
            if (!forSignUp)
            {
                // Họ tên
                if (string.IsNullOrEmpty(chuTro.hoten) || chuTro.hoten.Length > 50)
                {
                    errorMessage = "Tên Chủ trọ không được rỗng và tối đa 50 ký tự.";
                    return false;
                }

                // SĐT
                if (string.IsNullOrEmpty(chuTro.sdt) || !Regex.IsMatch(chuTro.sdt, @"^\d{10,11}$"))
                {
                    errorMessage = "Số điện thoại không hợp lệ (Phải là 10 hoặc 11 chữ số).";
                    return false;
                }

                // Email
                if (!string.IsNullOrEmpty(chuTro.email) && chuTro.email.Length > 100)
                {
                    errorMessage = "Email không được quá dài (tối đa 100 ký tự).";
                    return false;
                }

                // Địa chỉ
                if (!string.IsNullOrEmpty(chuTro.diachi) && chuTro.diachi.Length > 255)
                {
                    errorMessage = "Địa chỉ không được quá dài (tối đa 255 ký tự).";
                    return false;
                }
            }

            // Kiểm tra tài khoản
            if (string.IsNullOrEmpty(chuTro.taikhoan) || chuTro.taikhoan.Length > 50)
            {
                errorMessage = "Tên tài khoản không được rỗng và tối đa 50 ký tự.";
                return false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrEmpty(chuTro.matkhau) || chuTro.matkhau.Length > 255)
            {
                errorMessage = "Mật khẩu không được rỗng và tối đa 255 ký tự.";
                return false;
            }

            return true;
        }

        public static bool ValidatePhongTro(phongtro phongTro, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (phongTro == null)
            {
                errorMessage = "Dữ liệu Phòng trọ không được null.";
                return false;
            }

            // 1. Kiểm tra ID Phòng
            if (string.IsNullOrEmpty(phongTro.id_phong))
            {
                errorMessage = "ID Phòng không được rỗng.";
                return false;
            }

            // 2. Kiểm tra Giá phòng (Phải là số dương)
            if (phongTro.giaphong <= 0)
            {
                errorMessage = "Giá phòng phải lớn hơn 0.";
                return false;
            }

            // 3. Kiểm tra Tên phòng
            if (string.IsNullOrEmpty(phongTro.tenphong) || phongTro.tenphong.Length > 20)
            {
                errorMessage = "Tên phòng không được rỗng hoặc quá dài (tối đa 20 ký tự).";
                return false;
            }

            // 3. Kiểm tra tình trạng phòng
            if (string.IsNullOrEmpty(phongTro.tinhtrang) || phongTro.tinhtrang.Length > 50)
            {
                errorMessage = "Tình trạng phòng không được rỗng hoặc quá dài (tối đa 50 ký tự).";
                return false;
            }

            return true;
        }

        public static bool ValidateNguoiThue(nguoi_thue nguoiThue, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (nguoiThue == null)
            {
                errorMessage = "Dữ liệu Người thuê không được null.";
                return false;
            }

            // 1. Kiểm tra ID Người thuê
            if (string.IsNullOrEmpty(nguoiThue.id_nguoi_thue))
            {
                errorMessage = "ID Người thuê không được rỗng.";
                return false;
            }

            // 2. Kiểm tra Họ tên
            if (string.IsNullOrEmpty(nguoiThue.hoten) || nguoiThue.hoten.Length > 100)
            {
                errorMessage = "Tên Người thuê không được rỗng hoặc quá dài (tối đa 100 ký tự.)";
                return false;
            }

            // 3. Kiểm tra CCCD 
            if (string.IsNullOrEmpty(nguoiThue.cccd) || !Regex.IsMatch(nguoiThue.cccd, @"^\d{12}$"))
            {
                errorMessage = "CCCD/CMND không hợp lệ (Phải là 12 chữ số).";
                return false;
            }

            // 4.Kiểm tra sdt 
            if (string.IsNullOrEmpty(nguoiThue.cccd) || !Regex.IsMatch(nguoiThue.cccd, @"^\d{10,11}$"))
            {
                errorMessage = "Số điện thoại không hợp lệ (Phải là 10 chữ số).";
                return false;
            }

            // 4.Kiểm tra email 
            if (string.IsNullOrEmpty(nguoiThue.email) || nguoiThue.email.Length > 100)
            {
                errorMessage = "Email không được rỗng hoặc quá dài (tối đa 100 ký tự.)";
                return false;
            }
            return true;
        }

        public static bool ValidateHoaDon(hoadon hoaDon, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (hoaDon == null)
            {
                errorMessage = "Dữ liệu Hóa đơn không được null.";
                return false;
            }

            // 1. Kiểm tra Ngày tạo
            if (hoaDon.ngay_tao == DateTime.MinValue || hoaDon.ngay_tao > DateTime.Now)
            {
                errorMessage = "Ngày tạo không hợp lệ (Không được trong tương lai).";
                return false;
            }

            // 2. Kiểm tra Thành tiền (Phải lớn hơn hoặc bằng 0)
            if (hoaDon.thanh_tien < 0)
            {
                errorMessage = "Thành tiền không được âm.";
                return false;
            }

            if (string.IsNullOrEmpty(hoaDon.noi_dung) || hoaDon.noi_dung.Length > 100)
            {
                errorMessage = "Nội dung hóa đơn không được để trống hoặc quá dài (tối đa 255 ký tự)";
                return false;
            }

            // 4. Kiểm tra Trạng thái (Ví dụ: "Chưa thanh toán", "Đã thanh toán")
            if (string.IsNullOrEmpty(hoaDon.trang_thai))
            {
                errorMessage = "Trạng thái hóa đơn không được để trống";
                return false;
            }

            return true;
        }

        public static bool ValidateHopDong(hopdong hopDong, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (hopDong == null)
            {
                errorMessage = "Dữ liệu Hợp đồng không được null.";
                return false;
            }

            // 1. Kiểm tra ID Hợp đồng
            if (string.IsNullOrEmpty(hopDong.id_hopdong))
            {
                errorMessage = "ID Hợp đồng không được rỗng.";
                return false;
            }

            // 2. Kiểm tra Ngày bắt đầu
            if (hopDong.ngay_bat_dau == DateTime.MinValue || hopDong.ngay_bat_dau > DateTime.Now)
            {
                errorMessage = "Ngày bắt đầu hợp đồng không hợp lệ.";
                return false;
            }

            // 4. Kiểm tra Ngày kết thúc (Phải sau ngày bắt đầu)
            if (hopDong.ngay_ket_thuc <= hopDong.ngay_bat_dau)
            {
                errorMessage = "Ngày kết thúc phải sau Ngày bắt đầu.";
                return false;
            }

            // 5. Kiểm tra Tiền cọc (Phải lớn hơn hoặc bằng 0)
            if (hopDong.tien_coc < 0)
            {
                errorMessage = "Tiền cọc không được âm.";
                return false;
            }

            return true;
        }

        public static bool ValidateDien(dien objDien, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (objDien == null)
            {
                errorMessage = "Dữ liệu Điện không được rỗng.";
                return false;
            }

            // 1. Chỉ số không được âm
            if (objDien.chi_so_dau < 0 || objDien.chi_so_cuoi < 0)
            {
                errorMessage = "Chỉ số điện (đầu hoặc cuối) không được âm.";
                return false;
            }

            // 2. Chỉ số cuối phải lớn hơn hoặc bằng chỉ số đầu
            if (objDien.chi_so_cuoi < objDien.chi_so_dau)
            {
                errorMessage = "Chỉ số cuối phải lớn hơn hoặc bằng chỉ số đầu.";
                return false;
            }

            // 3. Kiểm tra Ngày tạo (Giả định là phải được gán)
            if (objDien.ngay_tao == null || objDien.ngay_tao == System.DateTime.MinValue)
            {
                errorMessage = "Ngày tạo chỉ số điện không hợp lệ.";
                return false;
            }

            return true;
        }

        public static bool ValidateNuoc(nuoc objNuoc, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (objNuoc == null)
            {
                errorMessage = "Dữ liệu Nước không được rỗng.";
                return false;
            }

            // 1. Chỉ số không được âm
            if (objNuoc.chi_so_dau < 0 || objNuoc.chi_so_cuoi < 0)
            {
                errorMessage = "Chỉ số nước (đầu hoặc cuối) không được âm.";
                return false;
            }

            // 2. Chỉ số cuối phải lớn hơn hoặc bằng chỉ số đầu
            if (objNuoc.chi_so_cuoi < objNuoc.chi_so_dau)
            {
                errorMessage = "Chỉ số cuối phải lớn hơn hoặc bằng chỉ số đầu.";
                return false;
            }

            // 3. Kiểm tra Ngày tạo
            if (objNuoc.ngay_tao == null || objNuoc.ngay_tao == System.DateTime.MinValue)
            {
                errorMessage = "Ngày tạo chỉ số nước không hợp lệ.";
                return false;
            }

            return true;
        }

        public static bool ValidateLePhi(lephi objLePhi, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (objLePhi == null)
            {
                errorMessage = "Dữ liệu Lệ phí không được rỗng.";
                return false;
            }

            // 1. Tiền dịch vụ không được âm
            if (objLePhi.tien_dv < 0)
            {
                errorMessage = "Tiền dịch vụ (tiendv) không được âm.";
                return false;
            }

            // 2. Thành tiền lệ phí không được âm
            if (objLePhi.thanh_tien_lephi < 0)
            {
                errorMessage = "Thành tiền lệ phí không được âm.";
                return false;
            }

            return true;
        }
    }
}
