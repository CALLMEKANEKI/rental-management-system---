using BLL.BLL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace BLL.Services
{
    public class chutroService
    {
        private chutroBLL chutroBLL = new chutroBLL();
        public string SignUp(chutro objChuTro)
        {
            try
            {
                //1. Tìm kiếm dự trên tài khoản và mật  khẩu
                chutro obj = chutroBLL.LayChutroTheoUserName(objChuTro.taikhoan);
                if (obj == null)
                {
                    // Thực hiện tạo tài khoản trong DB (gọi BLL)
                    bool isSuccess = chutroBLL.ThemChutro(objChuTro);

                    if (isSuccess)
                    {
                        return "Tạo tài khoản thành công.";
                    }
                    else
                    {
                        return "Lỗi: Không thể thêm vào cơ sở dữ liệu. (Có thể do ID đã tồn tại)";
                    }
                }
                else return "Tài khoản đã tồn tại";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống khi thêm dữ liệu: " + ex.Message;
            }
            
        }

        public string SignIn(string username, string pass, out string id_chutrohientai)
        {
            id_chutrohientai = null;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                return "Tên đăng nhập và mật khẩu không được rỗng.";
            }
            try
            {
                //1. Tìm kiếm dự trên tài khoản và mật  khẩu
                chutro objChuTro = chutroBLL.LayChutroTheoUserName(username);

                // 2. XÁC MINH: Kiểm tra tồn tại và mật khẩu
                if (objChuTro == null)
                {
                    return "Tài khoản không tồn tại.";
                }

                if (objChuTro.matkhau == pass)
                {
                    id_chutrohientai = objChuTro.id_chutro;
                    return "Đăng nhập thành công.";
                }
                else
                {
                    return "Mật khẩu không chính xác.";
                }
            }
            catch (Exception ex)
            {
                // Lỗi từ tầng DB (ví dụ: mất kết nối)
                return "Lỗi hệ thống khi truy vấn dữ liệu: " + ex.Message;
            }
        }

        public chutro LayChuTroById(string id)
        {
            return chutroBLL.LayChutroTheoId(id);
        }

        public string CapNhat(chutro objChuTro, string id_chutrohientai)
        {
            string mess = ""; // Khởi tạo biến để Validator gán lỗi vào

            if (Validators.ValidateChuTro(objChuTro, out mess))
            {
                // 2. Nếu HỢP LỆ (Validate trả về true)
                try
                {
                    // Thực hiện tạo tài khoản trong DB (gọi BLL)
                    bool isSuccess = chutroBLL.CapNhatChutro(objChuTro);

                    if (isSuccess)
                    {
                        return "cập nhật thành công.";
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

        public string Xoa(string id_chutrohientai)
        {
            try
            {
                // Thực hiện tạo tài khoản trong DB (gọi BLL)
                bool isSuccess = chutroBLL.XoaChutro(id_chutrohientai);
                if (isSuccess)
                {
                    return "Xóa thành công.";
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
