using qlpt_DAL;
using qlpt_DAL.DAL;
using qlpt_DTO;
using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_BLL.BLL
{
    public class ChuTroBLL
    {
        private ChuTroDAL ChuTroDAL = new ChuTroDAL();

        //Hàm bổ trợ 
        public int ChuTroValidationCode(ChuTro chuTro)
        {
            if (chuTro.HoTen.Length > 50) return -1; //Lỗi tên quá dài
            if (chuTro.Sdt.Length >10) return -2; //Lỗi Std không hợp lệ
            if (chuTro.Email.Length > 255) return -3; //Lỗi email quá dài
            if (chuTro.DiaChi.Length > 255) return -4; //Lỗi địa chị chỉ quá dài
            return 1;
        }

        // 1. Đăng ký (CREATE)
        public int SignUp(ChuTro objChuTro)
        {
            // BLL Validation: Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(objChuTro.TaiKhoan) || string.IsNullOrEmpty(objChuTro.MatKhau) || string.IsNullOrEmpty(objChuTro.Sdt) || string.IsNullOrEmpty(objChuTro.Email) || string.IsNullOrEmpty(objChuTro.DiaChi) || string.IsNullOrEmpty(objChuTro.HoTen))
            {
                return -2;
            }

            // BLL Logic:kiểm tra xem tên tài khoản đã tồn tại chưa
            if (ChuTroDAL.IsTaiKhoanDaTonTai(objChuTro.TaiKhoan))
                return -3;

            //BLL Logic: Mã hóa mật khẩu (HASHING) trước khi lưu vào DAL
            objChuTro.MatKhau = HashPassword(objChuTro.MatKhau);

            return ChuTroDAL.InsertChuTro(objChuTro);
        }
        // 2.Đăng nhập (READ)
        public ChuTro Login(string TaiKhoan, string MatKhau)
        {
            if (string.IsNullOrEmpty(TaiKhoan) || string.IsNullOrEmpty(MatKhau))
                return null;

            // 1. Tìm kiếm ChuTro theo Tài Khoản
            ChuTro objChuTro = ChuTroDAL.Login(TaiKhoan, MatKhau);
            /*
            if (objChuTro == null)
                return null; // Tài khoản không tồn tại

            // 2. Hash mật khẩu người dùng nhập
            string matKhauHashNguoiDung = HashPassword(MatKhau);

            // 3. So sánh mật khẩu đã hash từ CSDL với mật khẩu đã hash người dùng nhập
            // Lưu ý: ChuTroDAL.GetChuTroByTaiKhoan phải trả về cả trường MatKhau đã hash
            if (objChuTro.MatKhau == matKhauHashNguoiDung)
            {
                // XÓA MẬT KHẨU trước khi trả về cho tầng UI để đảm bảo bảo mật
                objChuTro.MatKhau = null;
                return objChuTro; // Đăng nhập thành công
            }

            return null; // Mật khẩu không đúng
            */
            if (objChuTro == null)
                return null; // Tài khoản không tồn tại
            else return objChuTro;
        }


        //Mã hóa mật khẩu
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }

        //Lấy đối tượng chủ trọ theo id
        public ChuTro GetChuTroById(int idChuTro)
        {
            if (idChuTro <= 0)
                return null;
            return ChuTroDAL.GetChuTroById(idChuTro);
        }

        //3.1. Cập nhật thông tin chủ trọ (UPDATE)
        public int UpdateChuTro(ChuTro objChuTro)
        {
            if (ChuTroValidationCode(objChuTro) != 1 && ChuTroDAL.UpdateChuTro(objChuTro) == true)
                return 1;
            else return ChuTroValidationCode(objChuTro);
        }

        //3.2. Cập nhật mật khẩu (UPDATE)
        public bool UpdateMatKhau( ChuTro chutro, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi)) return false;

            // 1. Xử lý logic: Mã hóa mật khẩu mới
            string matKhauDaHash = HashPassword(matKhauMoi);

            // 2. Gọi DAL (Cần thêm hàm UpdateMatKhau vào ChuTroDAL)
            return ChuTroDAL.UpdateMatKhau(chutro, matKhauMoi);
        }

        //4. Xóa tài khoản (DELETE)
        public bool DeleteChuTro(int idChuTro)
        {
            return ChuTroDAL.DeleteChuTro(idChuTro);
        }


    }
}
