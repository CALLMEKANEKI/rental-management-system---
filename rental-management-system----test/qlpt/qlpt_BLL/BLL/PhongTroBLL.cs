using qlpt_DAL.DAL;
using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_BLL.BLL
{
    public class PhongTroBLL
    {
        private PhongTroDAL phongTroDAL = new PhongTroDAL();
        // Cần thêm DAL của Hợp Đồng để kiểm tra logic nghiệp vụ
        private HopDongDAL hopDongDAL = new HopDongDAL();

        // 1. Thêm Phòng Trọ (CREATE)
        public int ThemPhongTroMoi(PhongTro objPhong)
        {
            // BLL Validation 1: Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrEmpty(objPhong.TenPhong) || objPhong.GiaPhong <= 0 || objPhong.Id_ChuTro <= 0)
                return -2; // Mã lỗi: Dữ liệu thiếu hoặc không hợp lệ

            // BLL Logic 2: Đảm bảo Tình trạng ban đầu là "Trống"
            objPhong.TinhTrang = "Trống";

            // Gọi DAL thực hiện thao tác CSDL
            return phongTroDAL.InsertPhong(objPhong);
        }

        // 2. Lấy Danh sách Phòng Trọ (READ ALL)
        public List<PhongTro> GetALlPhong()
        {
            return phongTroDAL.GetAllPhong();
        }

        // 3. Cập nhật Phòng Trọ (UPDATE)
        public bool CapNhatPhong(PhongTro objPhong)
        {
            // BLL Validation: Chỉ cập nhật nếu ID và Tên phòng hợp lệ
            if (objPhong.Id_Phong <= 0 || string.IsNullOrEmpty(objPhong.TenPhong))
                return false;

            // BLL Logic: Nếu có logic đặc biệt liên quan đến việc cập nhật giá, kiểm tra ở đây.

            return phongTroDAL.UpdatePhong(objPhong);
        }

        // 4. Xóa Phòng Trọ (DELETE)
        public bool XoaPhong(int idPhong)
        {
            if (idPhong <= 0)
                return false;

            // BLL Logic QUAN TRỌNG: Cấm xóa nếu phòng đang có Hợp đồng
            if (hopDongDAL.GetHopDongHienTaiByPhongId(idPhong) != null)
                return false; // Trả về false nếu phòng đang được thuê

            return phongTroDAL.DeletePhong(idPhong);
        }
    }
}
