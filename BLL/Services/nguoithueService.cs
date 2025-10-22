using BLL.BLL;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class nguoithueService
    {
        nguoithueBLL nguoithueBLL = new nguoithueBLL();

        public string ThemNguoiThue(nguoi_thue objNguoiThue, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidateNguoiThue(objNguoiThue, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện tạo người thuê trong DB (gọi BLL)
                    bool isSuccess = nguoithueBLL.ThemNguoiThue(objNguoiThue, id_chutro);

                    if (isSuccess)
                    {
                        return "Thêm người thuê thành công.";
                    }
                    else
                    {
                        return "Lỗi: Không thể thêm vào cơ sở dữ liệu. (Có thể do ID đã tồn tại)";
                    }
                }
                catch (Exception ex)
                {
                    return "Lỗi hệ thống khi thêm dữ liệu: " + ex.Message;
                }
            }
            else
            {
                return "Lỗi: " + mess;
            }
        }
        public List<nguoi_thue> LayTatCaNguoiThue(string id_chutro)
        {
            return nguoithueBLL.LayTatCaNguoiThue(id_chutro);
        }

        public nguoi_thue LayTatCaNguoiThueById(string id_chutro, string id_nguoithue)
        {
            return nguoithueBLL.LayNguoiThueTheoId(id_chutro, id_nguoithue);
        }

        public List<nguoithueViewModel> LayTatCaNguoiThueViewModel(string id_chutro)
        {
            return nguoithueBLL.LayTatCaNguoiThueViewModel(id_chutro);
        }

        public string CapNhat(nguoi_thue objNguoiThue, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidateNguoiThue(objNguoiThue, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện cập nhật người thuê trong DB (gọi BLL)
                    bool isSuccess = nguoithueBLL.CapNhatNguoiThue(objNguoiThue, id_chutro);

                    if (isSuccess)
                    {
                        return "Cập nhật người thuê thành công.";
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

       
        public string Xoa(string id_NguoiThue, string id_chutro)
        {
            try
            {
                // Thực hiện xóa người thuê trong DB (gọi BLL)
                bool isSuccess = nguoithueBLL.XoaNguoiThue(id_NguoiThue, id_chutro);
                if (isSuccess)
                {
                    return "Xóa người thuê thành công.";
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
