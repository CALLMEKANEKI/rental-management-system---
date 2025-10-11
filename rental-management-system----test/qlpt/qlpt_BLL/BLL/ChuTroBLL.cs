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


        // 1. Đăng ký (CREATE)
        public int SignUp(ChuTro objChuTro)
        {
            // BLL Validation: Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(objChuTro.TaiKhoan) || string.IsNullOrEmpty(objChuTro.MatKhau) || string.IsNullOrEmpty(objChuTro.Sdt) || string.IsNullOrEmpty(objChuTro.Email) || string.IsNullOrEmpty(objChuTro.DiaChi) || string.IsNullOrEmpty(objChuTro.HoTen) || string.IsNullOrEmpty((objChuTro.Id_ChuTro).ToString()))
            {
                return -2;
            }

            // BLL Logic:kiểm tra xem tên tài khoản đã tồn tại chưa
            if (ChuTroDAL.IsTaiKhoanDaTonTai(objChuTro.TaiKhoan))
                return -3;

            //BLL Logic: Mã hóa mật khẩu (HASHING) trước khi lưu vào DAL
            //objChuTro.MatKhau = HashPassword(objChuTro.MatKhau);

            return ChuTroDAL.InsertChuTro(objChuTro);
        }
        //2.Đâng nhập (READ)
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

        //Lấy đối tượng chủ trọ theo id
        public ChuTro GetChuTroById(int idChuTro)
        {
            if (idChuTro <= 0)
                return null;

            // Giả định bạn có hàm GetChuTroById trong DAL
            return ChuTroDAL.GetChuTroById(idChuTro);
        }

        //3.1. Cập nhật thông tin chủ trọ (UPDATE)
        public bool CapNhatThongTin(ChuTro objChuTro)
        {
            // Có thể thêm logic kiểm tra dữ liệu hoặc quyền ở đây
            return ChuTroDAL.UpdateChuTro(objChuTro);
        }

        //3.2. Cập nhật mật khẩu (UPDATE)
        public bool CapNhatMatKhau( ChuTro chutro, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi)) return false;

            // 1. Xử lý logic: Mã hóa mật khẩu mới
            //string matKhauDaHash = HashPassword(matKhauMoi);

            // 2. Gọi DAL (Cần thêm hàm UpdateMatKhau vào ChuTroDAL)
            // Cần thêm hàm: public bool UpdateMatKhau(int idChuTro, string matKhauHash)
            return ChuTroDAL.UpdateMatKhau(chutro, matKhauMoi);
        }

        //4. Xóa tài khoản (DELETE)
        public bool XoaTaiKhoan(int idChuTro)
        {
            return ChuTroDAL.DeleteChuTro(idChuTro);
        }


    }
}
