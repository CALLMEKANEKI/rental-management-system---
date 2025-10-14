using qlpt_DAL;
using qlpt_DAL.DAL;
using qlpt_DTO;
using qlpt_DTO.Models;
using qlpt_DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_BLL.BLL
{
    public class NguoiThueBLL
    {
        private NguoiThueDAL NguoiThueDAL = new NguoiThueDAL();
        private PhongTroDAL PhongTroDAL = new PhongTroDAL();

        public NguoiThue Login(string TaiKhoan, string MatKhau)
        {
            if (string.IsNullOrEmpty(TaiKhoan) || string.IsNullOrEmpty(MatKhau))
                return null;

            // 1. TÌM KIẾM NGƯỜI THUÊ THEO TÀI KHOẢN (Bổ sung hàm GetByTaiKhoan trong DAL)
            // Hàm này sẽ trả về đối tượng NguoiThue đầy đủ (bao gồm cả MatKhau đã hash)
            NguoiThue objNguoiThue = NguoiThueDAL.Login(TaiKhoan, MatKhau);

            /*
             * Thêm vào khi release
            if (objNguoiThue == null)
                return null; // Tài khoản không tồn tại

            // 2. Hash mật khẩu người dùng nhập
            string matKhauHashNguoiDung = HashPassword(MatKhau);

            // 3. So sánh mật khẩu đã hash (từ CSDL) với mật khẩu đã hash (người dùng nhập)
            if (objNguoiThue.MatKhau == matKhauHashNguoiDung)
            {
                // XÓA MẬT KHẨU trước khi trả về cho tầng UI
                objNguoiThue.MatKhau = null;
                return objNguoiThue; // Đăng nhập thành công
            }
            return null; // Mật khẩu không đúng
             */

            //Bỏ khi release
            if (objNguoiThue == null)
                return null; // Tài khoản không tồn tại
            else return objNguoiThue;
        }

        //2.1 Thêm người thuê (READ)
        public int InsertNguoiThue(NguoiThue objNguoiThue)
        {
            // BLL Validation: Kiểm tra dữ liệu bắt buộc (Tên, CCCD, ID phòng)
            if (string.IsNullOrEmpty(objNguoiThue.HoTen) || string.IsNullOrEmpty(objNguoiThue.Cccd) || string.IsNullOrEmpty(objNguoiThue.Sdt) || string.IsNullOrEmpty(objNguoiThue.Email))
                return -2; // Lỗi: Thiếu thông tin

            // BLL Logic: Nếu có tài khoản/mật khẩu, phải mã hóa mật khẩu TẠI ĐÂY
            if (!string.IsNullOrEmpty(objNguoiThue.MatKhau))
                objNguoiThue.MatKhau = HashPassword(objNguoiThue.MatKhau); 

            // Hàm này trả về ID Người Thuê mới được tạo
            return NguoiThueDAL.InsertNguoiThue(objNguoiThue);
        }

        //Mã hóa mật khẩu
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }

        // 2. Lấy danh sách Người Thuê theo Phòng (READ)
        public List<NguoiThue> getNguoiThueTheoPhong(int idPhong)
        {
            if (idPhong <= 0)
                return new List<NguoiThue>();

            return NguoiThueDAL.GetNguoiThueByPhong(idPhong);
        }

        //2.2 Lấy toàn bộ người thuê (READ)
        public List<NguoiThue> GetAllNguoiThue(int idChuTro)
        {
            if (idChuTro <= 0)
                return new List<NguoiThue>();

            return NguoiThueDAL.GetAllNguoiThue(idChuTro);
        }

        public List<NguoiThueViewModel> GetAllNguoiThueViewModel(int idChuTro)
        {
            if (idChuTro <= 0)
                return new List<NguoiThueViewModel>();

            // 1. Lấy dữ liệu thô đã lọc theo idChuTro
            List<NguoiThue> listNguoiThue = NguoiThueDAL.GetAllNguoiThue(idChuTro);

            // GIẢ ĐỊNH: Bạn có hàm GetAllPhong(int idChuTro) trong PhongTroDAL
            List<PhongTro> listPhongTro = PhongTroDAL.GetAllPhong(idChuTro);

            // 2. JOIN và Ánh xạ sang ViewModel bằng LINQ
            var result = from nt in listNguoiThue
                         join pt in listPhongTro on nt.Id_Phong equals pt.Id_Phong into phongGroup
                         from pt in phongGroup.DefaultIfEmpty()
                         select new NguoiThueViewModel
                         {
                             Id_NguoiThue = nt.Id_NguoiThue,
                             Id_Phong = nt.Id_Phong,
                             HoTen = nt.HoTen,
                             Cccd = nt.Cccd,
                             Sdt = nt.Sdt,
                             Email = nt.Email,
                             TaiKhoan = nt.TaiKhoan,
                             MatKhau = nt.MatKhau, 

                             // Thêm thuộc tính đã JOIN
                             TenPhongHienThi = pt != null ? pt.TenPhong : "Chưa có phòng"
                         };

            return result.ToList();
        }


        
        //2.3 Tìm người thuê theo keyworrd (id hợp đồng)
        public List<NguoiThueViewModel> GetAllNguoiThueVewModelByKeyWord(int idChuTro, string keyword)
        {
            return NguoiThueDAL.GetAllNguoiThueVewModelByKeyWord(idChuTro, keyword);
        }

        //2.4. Lấy người thuê theo ID (Cần thiết cho việc chỉnh sửa)
        public NguoiThue GetNguoiThueById(int idNguoiThue)
        {
            if (idNguoiThue <= 0) return null;
            return NguoiThueDAL.GetNguoiThueById(idNguoiThue);
        }

        //3.Cập nhật người thuê(Update)

        public bool UpdateNguoiThue(NguoiThue objNguoiThue, bool updatePassword = false)
        {
            // 1. Validation cơ bản
            if (objNguoiThue.Id_NguoiThue <= 0 || string.IsNullOrEmpty(objNguoiThue.HoTen))
                return false;

            // 2. Hash mật khẩu mới nếu cờ được bật và mật khẩu không rỗng
            if (updatePassword && !string.IsNullOrEmpty(objNguoiThue.MatKhau))
            {
                objNguoiThue.MatKhau = HashPassword(objNguoiThue.MatKhau);
                // SỬ DỤNG HÀM UpdateMatKhau riêng biệt trong DAL nếu chỉ muốn cập nhật mật khẩu.
                // Nếu bạn dùng hàm UpdateNguoiThue chung, bạn phải đảm bảo
                // MatKhau trong objNguoiThue luôn được gửi lên DAL, kể cả khi không đổi.
                // Tốt nhất là sử dụng hàm UpdateMatKhau của DAL.
            }

            // *Đã có hàm UpdateMatKhau riêng* -> Giữ nguyên logic cập nhật thông tin khác
            return NguoiThueDAL.UpdateNguoiThue(objNguoiThue);
        }

        // Bổ sung: Hàm cập nhật mật khẩu gọi DAL
        public bool UpdateMatKhau(NguoiThue objNguoiThue, string newPassword)
        {
            if (objNguoiThue.Id_NguoiThue <= 0 || string.IsNullOrEmpty(newPassword))
                return false;

            string hashedPassword = HashPassword(newPassword);
            return NguoiThueDAL.UpdateMatKhau(objNguoiThue, hashedPassword);
        }



        //4.Xóa người thuê (Delete)
        public bool DeleteNguoiThue(int idNguoiThue)
        {
            if (idNguoiThue <= 0) return false; // ID không hợp lệ
            if (NguoiThueDAL.DeleteNguoiThue(idNguoiThue))
                return true; // Thành công
            else
                return false; // Thất bại (có thể do lỗi khóa ngoại khác hoặc lỗi SQL)
        }
    }
}
