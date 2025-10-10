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

        public ChuTro login(string TaiKhoan, string MatKhau)
        {
            // BLL Validation: Kiểm tra dữ liệu đầu vào (đặt trong hàm)
            if (string.IsNullOrEmpty(TaiKhoan) || string.IsNullOrEmpty(MatKhau))
                return null;

            // Gọi DAL để thực hiện truy vấn CSDL
            return ChuTroDAL.Login(TaiKhoan, MatKhau);
        }

        //Mã hóa mật khẩu
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
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

        public ChuTro GetChuTroById(int idChuTro)
        {
            if (idChuTro <= 0)
                return null;

            // Giả định bạn có hàm GetChuTroById trong DAL
            return ChuTroDAL.GetChuTroById(idChuTro);
        }

    }
}
