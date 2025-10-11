using qlpt_DAL.DAL;
using qlpt_DTO.Models;
using qlpt_DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace qlpt_BLL.BLL
{
    public class HopDongBLL
    {
        private HopDongDAL hopDongDAL = new HopDongDAL();
        private PhongTroDAL phongTroDAL = new PhongTroDAL();
        private ChuTroDAL chuTroDAL = new ChuTroDAL();
        private NguoiThueDAL NguoiThueDAL = new NguoiThueDAL();

        // 1. Lập Hợp Đồng Mới (CREATE)
        public int LapHopDongMoi(HopDong objHopDong)
        {
            // BLL Validation 1: Kiểm tra dữ liệu bắt buộc
            if (objHopDong.Id_Phong <= 0 || objHopDong.Id_NguoiThue <= 0 || objHopDong.NgayBatDau >= objHopDong.NgayKetThuc)
            {
                // Trả về mã lỗi: Dữ liệu thiếu hoặc ngày tháng không hợp lệ
                return -2;
            }

            // BLL Logic 2: KIỂM TRA TÍNH HỢP LỆ CỦA PHÒNG TRỌ
            PhongTro objPhong = phongTroDAL.GetPhongById(objHopDong.Id_Phong);

            if (objPhong == null)
            {
                return -3; // Lỗi: Không tìm thấy phòng
            }

            // BLL Logic 3: CHỈ CHO PHÉP LẬP HĐ KHI PHÒNG CÓ TRẠNG THÁI "TRỐNG"
            if (objPhong.TinhTrang != "Trống")
            {
                return -4; // Lỗi: Phòng không ở trạng thái trống, không thể lập HĐ mới
            }

            // B4: Gọi DAL tạo Hợp đồng
            int newIdHopDong = hopDongDAL.InsertHopDong(objHopDong);

            if (newIdHopDong > 0)
            {
                // B5: THAO TÁC NGHIỆP VỤ QUAN TRỌNG: 
                // Nếu lập hợp đồng thành công, CẬP NHẬT trạng thái phòng thành "Đã thuê"
                objPhong.TinhTrang = "Đã thuê";
                phongTroDAL.UpdatePhong(objPhong);
            }

            return newIdHopDong;
        }

        // 3. Lấy Hợp Đồng đang có hiệu lực theo ID Phòng (READ)
        public HopDong LayHopDongHienTai(int idPhong)
        {
            if (idPhong <= 0)
            {
                return null;
            }
            // Gọi DAL để truy vấn hợp đồng có ngày kết thúc lớn hơn hoặc bằng ngày hiện tại
            return hopDongDAL.GetHopDongHienTaiByPhongId(idPhong);
        }
        public List<HopDongViewModel> GetAllHopDongViewModel()
        {
            // 1. Lấy dữ liệu thô
            List<HopDong> listHopDong = hopDongDAL.GetAllHopDong();
            List<ChuTro> listChuTro = chuTroDAL.GetAllChuTro();
            List<NguoiThue> listNguoiThue = NguoiThueDAL.GetAllNguoiThue();
            List<PhongTro> listPhongTro = phongTroDAL.GetAllPhong();

            // 2. JOIN 3 bảng và Ánh xạ sang ViewModel
            var result = from hd in listHopDong
                         join ct in listChuTro on hd.Id_ChuTro equals ct.Id_ChuTro
                         join pt in listPhongTro on hd.Id_Phong equals pt.Id_Phong
                         join nt in listNguoiThue on hd.Id_NguoiThue equals nt.Id_NguoiThue
                         select new HopDongViewModel
                         {
                             // Ánh xạ các thuộc tính cơ bản (từ lớp cha HopDong)
                             Id_HopDong = hd.Id_HopDong,
                             Id_ChuTro = hd.Id_ChuTro,
                             Id_Phong = hd.Id_Phong,
                             NgayBatDau = hd.NgayBatDau,
                             NgayKetThuc = hd.NgayKetThuc,
                             TienCoc = hd.TienCoc,
                             // Thêm thuộc tính đã JOIN
                             TenChuTroHienThi = ct.HoTen,
                             TenPhongHienThi = pt.TenPhong,
                             TenNguoiThueHienThi = nt.HoTen,
                             CccdHienThi = nt.Cccd,
                             SdtHienThi = nt.Sdt
                         };

            return result.ToList();
        }
    }
}
