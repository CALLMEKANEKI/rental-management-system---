using BLL.BLL;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class hoadonService
    {
        hoadonBLL hoadonBLL = new hoadonBLL();

        public string ThemHoaDon(hoadon objHoaDon, dien objDien, nuoc objNuoc, lephi objLePhi, string id_chutro)
        {
            string mess = ""; // 1. Khởi tạo biến để Validator gán lỗi vào

            // 2. VALIDATION: Kiểm tra TẤT CẢ các thực thể liên quan

            if (!Validators.ValidateHoaDon(objHoaDon, out mess))
            {
                return "Lỗi Hóa đơn: " + mess;
            }
            if (!Validators.ValidateDien(objDien, out mess))
            {
                return "Lỗi chỉ số Điện: " + mess;
            }
            if (!Validators.ValidateNuoc(objNuoc, out mess))
            {
                return "Lỗi chỉ số Nước: " + mess;
            }
            if (!Validators.ValidateLePhi(objLePhi, out mess))
            {
                return "Lỗi Lệ phí: " + mess;
            }

            // Nếu tất cả Validation OK
            try
            {
                // 3. GỌI BLL
                bool isSuccess = hoadonBLL.ThemHoaDon(objHoaDon, objDien, objNuoc, objLePhi, id_chutro);

                if (isSuccess)
                {
                    return "Thêm hóa đơn thành công";
                }
                else
                {
                    // Lỗi từ BLL (Ví dụ: ID Phòng không tồn tại hoặc không thuộc Chủ trọ)
                    return "Lỗi nghiệp vụ: Phòng trọ không thuộc quyền sở hữu hoặc dữ liệu con không hợp lệ.";
                }
            }
            catch (Exception ex)
            {
                // Lỗi hệ thống/DB (Ví dụ: Lỗi kết nối, Transaction thất bại)
                return "Lỗi hệ thống khi thêm dữ liệu: " + ex.Message;
            }
        }

        public List<hoadon> LayTatCaHoaDon(string id_chutro)
        {
            return hoadonBLL.LayTatCaHoaDon(id_chutro);
        }

        public hoadon LayHoaDonTheoId(string id_chutro, string id)
        {
            return hoadonBLL.LayHoaDonTheoId(id_chutro, id);
        }

        public List<hoadonViewModel> LayTatCaHoaDonViewModel(string id_chutro)
        {
            return hoadonBLL.LayTatCaHoaDonViewModel(id_chutro);
        }

        public hoadonViewModel LayHoaDonViewModelTheoID(string id_hoadon, string id_chutro)
        {
            return hoadonBLL.LayHoaDonViewModelTheoID(id_hoadon, id_chutro);
        }

        public List<hoadonViewModel> LayTatCaHoaDonTheoKeywork(string keyword, string id_chutro)
        {
            return hoadonBLL.LayTatCaHoaDonViewModelTheoKeywork(keyword, id_chutro);
        }

        public List<hoadonViewModel> LayHoaDonChuaThanhToan(string id_chutro)
        {
            return hoadonBLL.LayHoaDonChuaThanhToan(id_chutro);
        }

        public string CapNhat(hoadon objHoaDon, dien objDien, nuoc objNuoc, lephi objLePhi, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidateHoaDon(objHoaDon, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện cập nhật hóa đơn trong DB (gọi BLL)
                    bool isSuccess = hoadonBLL.CapNhatHoaDon(objHoaDon, objDien, objNuoc, objLePhi, id_chutro);

                    if (isSuccess)
                    {
                        return "Cập nhật hóa đơn thành công.";
                    }
                    else
                    {
                        return "Lỗi: Không thể cập nhật vào cơ sở dữ liệu.";
                    }
                }
                catch (Exception ex)
                {
                    return "Lỗi hệ thống khi cập nhật dữ liệu: " + ex.Message;
                }
            }
            else
            {
                return "Lỗi: " + mess;
            }
        }

        public string Xoa(string id_HoaDon , string id_chutro)
        {
                try
                {
                // Thực hiện xóa hóa đơn trong DB (gọi BLL)
                bool isSuccess = hoadonBLL.XoaHoaDon(id_HoaDon, id_chutro);
                if (isSuccess)
                {
                    return "Xóa hóa đơn thành công.";
                }
                else
                {
                    return "Lỗi: Không thể xóa vào cơ sở dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống khi xóa dữ liệu: " + ex.Message;
            }
        }
    }
}
