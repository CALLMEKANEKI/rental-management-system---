using BLL.BLL;
using DAL.Model;
using System;
using System.Linq;

namespace BLL.Services
{
    public class chutroService
    {
        private chutroBLL chutroBLL = new chutroBLL();

        public string SignUp(chutro objChuTro)
        {
            if (objChuTro == null)
                return "Dữ liệu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(objChuTro.taikhoan) || string.IsNullOrWhiteSpace(objChuTro.matkhau))
                return "Vui lòng nhập tài khoản và mật khẩu.";

            // kiểm tra tồn tại
            if (IsExist(objChuTro.taikhoan))
                return "Tài khoản này đã tồn tại. Vui lòng đặt tên khác.";

            try
            {
                bool isSuccess = chutroBLL.ThemChutro(objChuTro);
                return isSuccess ? "Đăng ký thành công." : "Lỗi: Không thể thêm vào cơ sở dữ liệu.";
            }
            catch (Exception ex)
            {
                // Trả thông điệp lỗi thực tế để debug, sau khi fix thì có thể sanitize message
                return "Lỗi hệ thống khi thêm dữ liệu: " + ex.Message;
            }
        }



        public string SignIn(string username, string pass, out string id_chutrohientai)
        {
            id_chutrohientai = null;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
                return "Tên đăng nhập và mật khẩu không được rỗng.";

            try
            {
                chutro objChuTro = chutroBLL.LayChutroTheoUserName(username);
                if (objChuTro == null)
                    return "Tài khoản không tồn tại.";  

                if (objChuTro.matkhau == pass)
                {
                    id_chutrohientai = objChuTro.id_chutro;
                    return "Đăng nhập thành công.";
                }
                else
                    return "Mật khẩu không chính xác.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống khi truy vấn dữ liệu: " + ex.Message;
            }
        }

        public string CapNhat(chutro objChuTro, string id_chutrohientai)
        {
            string mess = "";

            if (!Validators.ValidateChuTro(objChuTro, out mess))
                return "Lỗi: " + mess;

            try
            {
                bool isSuccess = chutroBLL.CapNhatChutro(objChuTro);
                return isSuccess ? "Cập nhật thành công." : "Lỗi: Không thể cập nhật vào cơ sở dữ liệu.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống khi cập nhật dữ liệu: " + ex.Message;
            }
        }

        public bool IsExist(string username)
        {
            using (var db = new ContextDB())
            {
                return db.chutroes.Any(c => c.taikhoan == username);
            }
        }

        public string Xoa(string id_chutrohientai)
        {
            try
            {
                bool isSuccess = chutroBLL.XoaChutro(id_chutrohientai);
                return isSuccess ? "Xóa thành công." : "Lỗi: Không thể xóa khỏi cơ sở dữ liệu.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống khi xóa dữ liệu: " + ex.Message;
            }
        }
    }
}
