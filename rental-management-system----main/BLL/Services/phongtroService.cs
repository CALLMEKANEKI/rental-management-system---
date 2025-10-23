using BLL.BLL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class phongtroService
    {
        phongtroBLL PhongTroBLL = new phongtroBLL();
        nguoithueBLL nguoithueBLL = new nguoithueBLL();

        public string ThemPhongTro(phongtro objPhongTro, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidatePhongTro(objPhongTro, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện tạo phòng trọ trong DB (gọi BLL)
                    bool isSuccess = PhongTroBLL.ThemPhongTro(objPhongTro, id_chutro);

                    if (isSuccess)
                    {
                        return "Thêm phòng thành công.";
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

        public string CapNhat(phongtro objPhongTro, string id_chutro)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidatePhongTro(objPhongTro, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện cập nhật trong DB (gọi BLL)
                    bool isSuccess = PhongTroBLL.CapNhatPhongTro(objPhongTro, id_chutro);

                    if (isSuccess)
                    {
                        return "Cập nhật phòng thành công.";
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

        public string Xoa(string id_Phongtro,string id_chutro)
        {
            //Kiểm tra xem có ai đang thuê phòng hay không
            var result = (nguoithueBLL.LayTatCaNguoiThue(id_chutro)).
                                Where(nt => nt.id_phong == id_Phongtro).
                                ToList();
            if (result != null && result.Count > 0)
            {
                return "Không thể xóa phòng do đang có người thuê phòng";

            }    //Nếu có, phòng đang có người thuê -> không được phép xóa
            else
            {
                try
                {
                    // Thực hiện xóa phòng trong DB (gọi BLL)
                    bool isSuccess = PhongTroBLL.XoaPhongTro(id_Phongtro, id_chutro);
                    if (isSuccess)
                    {
                        return "Xóa phòng thành công.";
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
