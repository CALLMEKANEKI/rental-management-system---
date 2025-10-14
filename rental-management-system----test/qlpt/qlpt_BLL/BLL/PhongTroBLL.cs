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
        private HopDongDAL hopDongDAL = new HopDongDAL();

        //Hàm kiểm tra nhập liệu
        public int PhongTroValidationCode(PhongTro phongTro)
        {
            // Kiểm tra đối tượng có NULL không
            if (phongTro == null) return -99;

            // 1. Kiểm tra Tên phòng (Không được để trống và độ dài)
            if (string.IsNullOrWhiteSpace(phongTro.TenPhong))
            {
                return -10; // Lỗi: Tên phòng không được trống
            }
            if (phongTro.TenPhong.Length > 12)
            {
                return -11; // Lỗi: Tên phòng quá dài (> 50)
            }

            // 2. Kiểm tra Giá phòng (Không âm)
            // Kiểm tra giá trị không âm (Giá phòng phải >= 0)
            if (phongTro.GiaPhong < 0)
            {
                return -22; // Lỗi: Giá phòng không hợp lệ (âm)
            }
            if (string.IsNullOrEmpty(phongTro.TinhTrang))
                return -31; //Lỗi tình trạng để trống

            if (phongTro.TinhTrang.Length > 255)
                return 30; //Lỗi tình trạng quá dài
            return 1; // Thành công
        }


        // 1. Thêm Phòng Trọ (CREATE)
        public int InsertPhongTro(PhongTro objPhong)
        {
            // BLL Validation 1: Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrEmpty(objPhong.TenPhong) || objPhong.GiaPhong <= 0 || objPhong.Id_ChuTro <= 0)
                return -2; // Mã lỗi: Dữ liệu thiếu hoặc không hợp lệ

            // BLL Logic 2: Đảm bảo Tình trạng ban đầu là "Trống"
            objPhong.TinhTrang = "Trống";
            return phongTroDAL.InsertPhong(objPhong);
        }

        //2. Lấy Danh sách Phòng Trọ (READ ALL)
        public List<PhongTro> GetAllPhong(int idChuTro)
        {
            return phongTroDAL.GetAllPhong(idChuTro);
        }

        //2.1 Lấy phòng theo tên phòng
        public List<PhongTro> GetPhongByName(int idChuTro, string nameRoom)
        {
            return phongTroDAL.GetPhongByName(idChuTro, nameRoom);
        }

        //2.2 Lấy tất cả theo keyword
        public List<PhongTro> GetAllPhongTroByKeyWord(int idChuTro, string keyWord)
        {
            return phongTroDAL.GetAllPhongByKeyWord(idChuTro, keyWord);
        }

        // 3. Cập nhật Phòng Trọ (UPDATE)
        public bool UpdatePhong(PhongTro objPhong)
        {
            // BLL Validation 1: Kiểm tra ID phòng phải lớn hơn 0
            if (objPhong.Id_Phong <= 0)
                return false;

            // BLL Validation 2: Kiểm tra Tên phòng không được trống
            if (string.IsNullOrEmpty(objPhong.TenPhong))
                return false;

            // Kiểm tra nhập liệu
            PhongTroValidationCode(objPhong);

            return phongTroDAL.UpdatePhong(objPhong);
        }

        // 4. Xóa Phòng Trọ (DELETE)
        public int DeletePhong(int idChuTro, int idPhong)
        {
            if (idPhong < 0)
                return -1;
            // BLL Logic QUAN TRỌNG: Cấm xóa nếu phòng đang có Hợp đồng
            if (hopDongDAL.GetActiveHopDongByRoomId(idPhong).Any())
                return -2; // Mã lỗi: Phòng đang có hợp đồng, không thể xóa

            if (phongTroDAL.DeletePhong(idChuTro, idPhong))
                return 1; // Thành công
            else
                return 0; // Thất bại trong CSDL
        }
    }
}