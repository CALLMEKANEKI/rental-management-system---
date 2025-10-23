using BLL.BLL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class hopdongService
    {
        hopdongBLL hopdongBLL = new hopdongBLL();
        phongtroBLL phongtroBLL = new phongtroBLL();
        chutroBLL chutroBLL = new chutroBLL();
        nguoithueBLL nguoithueBLL = new nguoithueBLL();

        public string ThemHopDong(hopdong objHopDong, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidateHopDong(objHopDong, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện tạo hợp đồng trong DB (gọi BLL)
                    bool isSuccess = hopdongBLL.ThemHopDong(objHopDong, id_chutro);

                    if (isSuccess)
                    {
                        return "Thêm hợp đồng thành công thành công.";
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

        public List<hopdong> LayAllHopDong(string id_chutro)
        {
            return hopdongBLL.LayTatCaHopDong(id_chutro);
        }

        public string CapNhat(hopdong objHopDong, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidateHopDong(objHopDong, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện cập nhật hợp đồng trong DB (gọi BLL)
                    bool isSuccess = hopdongBLL.CapNhatHopDong(objHopDong, id_chutro);

                    if (isSuccess)
                    {
                        return "Cập nhật hợp đồng thành công.";
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

        public string Xoa(string id_HopDong , string id_chutro)
        {
            //Kiểm tra hợp đồng có tồn tại không
            var objHopDong = hopdongBLL.LayHopDongtheoId(id_HopDong, id_chutro);
            if (objHopDong == null)
            {
                return "Không tồn tại hợp đồng";
            }    
            //Kiểm tra xem người thuê trên hợp đồng này có tồn tại hay không
            var NguoiThueHienTai = (nguoithueBLL.LayTatCaNguoiThue(id_chutro)).
                                        Where(nt => nt.id_nguoi_thue == objHopDong.id_nguoi_thue).
                                        ToList(); 
            if (NguoiThueHienTai != null && NguoiThueHienTai.Count > 0 )
                return "Không thể xóa hợp đồng này khi vẫn còn người thuê";
            else //Nếu không, tức là đã không có người thuê đang còn hiệu lực với hợp đông -> hợp đồng không có hiệu lực, có thể xóa
            {
                try
                {
                    // Thực hiện xóa hợp đồng trong DB (gọi BLL)
                    bool isSuccess = hopdongBLL.XoaHopDong(id_HopDong, id_chutro);
                    if (isSuccess)
                    {
                        return "Xóa hợp đồng thành công.";
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
}
