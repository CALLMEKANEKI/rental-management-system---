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
        public NguoiThue login(string TaiKhoan, string MatKhau)
        {
            // BLL Validation: Kiểm tra dữ liệu đầu vào (đặt trong hàm)
            if (string.IsNullOrEmpty(TaiKhoan) || string.IsNullOrEmpty(MatKhau))
                return null;

            // Gọi DAL để thực hiện truy vấn CSDL
            return NguoiThueDAL.Login(TaiKhoan, MatKhau);
        }
    
    public int insertNguoiThueMoi(NguoiThue objNguoiThue)
        {
            // BLL Validation: Kiểm tra dữ liệu bắt buộc (Tên, CCCD, ID phòng)
            if (string.IsNullOrEmpty(objNguoiThue.HoTen) || string.IsNullOrEmpty(objNguoiThue.Cccd) || objNguoiThue.Id_Phong <= 0)
                return -2; // Lỗi: Thiếu thông tin

            // BLL Logic: Kiểm tra CCCD trùng lặp (nếu cần)
            // Hiện tại chúng ta không có hàm CheckDuplicateCCCD trong DAL, nhưng nếu có thì thêm ở đây.

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

        public List<NguoiThue> GetAllNguoiThue()
        {
            return NguoiThueDAL.GetAllNguoiThue();
        }

        public List<NguoiThueViewModel> GetAllNguoiThueViewModel()
        {
            // 1. Lấy dữ liệu thô
            List<NguoiThue> listNguoiThue = NguoiThueDAL.GetAllNguoiThue();
            List<PhongTro> listPhongTro = PhongTroDAL.GetAllPhong();

            // 2. JOIN và Ánh xạ sang ViewModel bằng LINQ
            var result = from nt in listNguoiThue
                         join pt in listPhongTro on nt.Id_Phong equals pt.Id_Phong into phongGroup
                         from pt in phongGroup.DefaultIfEmpty() // Dùng DefaultIfEmpty() để giữ lại NT ngay cả khi chưa có phòng
                         select new NguoiThueViewModel
                         {
                             // Ánh xạ các thuộc tính cơ bản
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
    }
}
