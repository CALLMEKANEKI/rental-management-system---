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
    public class HoaDonBLL
    {

        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private DienDAL dienDAL = new DienDAL();
        private NuocDAL nuocDAL = new NuocDAL();
        private LePhiDAL lePhiDAL = new LePhiDAL();
        private PhongTroDAL PhongTroDAL = new PhongTroDAL();

        // 1. Tạo Hóa Đơn Chính thức (Bao gồm Chi phí chi tiết)
       public int CreateHoaDon(HoaDon objHoaDon, Dien objDien, Nuoc objNuoc, LePhi objLePhi)
        {
            // BLL Logic 1: Kiểm tra tính hợp lệ của dữ liệu đầu vào
            if (objHoaDon.Id_Phong <= 0)
            {
                // Trả về mã lỗi nghiệp vụ
                return -2;
            }

            int idDien = -1;
            int idNuoc = -1;
            int idLePhi = -1;

            try
            {
                // B1: Gọi DAL tạo các chi phí chi tiết
                idDien = dienDAL.InsertDien(objDien);
                idNuoc = nuocDAL.InsertNuoc(objNuoc);
                idLePhi = lePhiDAL.InsertLePhi(objLePhi);

                // Kiểm tra xem tất cả các chi phí chi tiết đã được tạo thành công chưa
                if (idDien > 0 && idNuoc > 0 && idLePhi > 0)
                {
                    // B2: Gán ID chi phí vừa tạo vào đối tượng Hóa đơn
                    objHoaDon.Id_Dien = idDien;
                    objHoaDon.Id_Nuoc = idNuoc;
                    objHoaDon.Id_LePhi = idLePhi;

                    // B3: Gọi DAL tạo Hóa đơn chính
                    int idHoaDonMoi = hoaDonDAL.InsertHoaDon(objHoaDon);

                    if (idHoaDonMoi > 0)
                    {
                        // Thành công: Trả về ID Hóa đơn mới
                        return idHoaDonMoi;
                    }
                }

                // Nếu đến đây, có lỗi xảy ra (có thể cần rollback thủ công nếu không dùng Transaction Scope)
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BLL (TaoHoaDonDayDu): " + ex.Message);
                return -1;
            }
        }

        // 2. Cập nhật trạng thái Hóa đơn
        public bool updateHoaDon(int idHoaDon, string trangThaiMoi)
        {
            // BLL Validation: Chỉ chấp nhận các trạng thái hợp lệ
            if (trangThaiMoi != "Đã thanh toán" && trangThaiMoi != "Chưa thanh toán")
                return false;

            return hoaDonDAL.UpdateTrangThai(idHoaDon, trangThaiMoi);
        }

        //3. Xóa hóa đơn(tự động xóa các bản ghi của nước, điện , lệ phí)
        public bool XoaHoaDonDayDu(int idHoaDon)
        {
            // Cần khởi tạo các DAL của chi phí chi tiết
            DienDAL dienDAL = new DienDAL();
            NuocDAL nuocDAL = new NuocDAL();
            LePhiDAL lePhiDAL = new LePhiDAL();

            // BLL Logic 1: Lấy ID chi phí liên quan
            HoaDon objHoaDon = hoaDonDAL.GetHoaDonById(idHoaDon);

            if (objHoaDon == null)
            {
                return true; // Nếu không tìm thấy hóa đơn, coi như đã xóa thành công
            }

            // BLL Logic 2: Bắt đầu Giao dịch (Transaction)
            using (var scope = new TransactionScope())
            {
                try
                {
                    // A. Xóa bản ghi Hóa đơn chính (phải làm trước vì khóa ngoại)
                    if (!hoaDonDAL.DeleteHoaDon(idHoaDon))
                        throw new Exception("Lỗi khi xóa Hóa đơn chính.");

                    // B. Xóa 3 bản ghi chi phí liên quan
                    if (!dienDAL.DeleteDien(objHoaDon.Id_Dien))
                        throw new Exception("Lỗi khi xóa chi phí Điện.");

                    if (!nuocDAL.DeleteNuoc(objHoaDon.Id_Nuoc))
                        throw new Exception("Lỗi khi xóa chi phí Nước.");

                    if (!lePhiDAL.DeleteLePhi(objHoaDon.Id_LePhi))
                        throw new Exception("Lỗi khi xóa chi phí Lệ phí.");

                    // C. Nếu tất cả thành công, xác nhận (commit) giao dịch
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, giao dịch sẽ tự động Rollback (hủy bỏ)
                    Console.WriteLine("Lỗi nghiệp vụ khi xóa Hóa đơn (Rollback): " + ex.Message);
                    return false;
                }
            }
        }

        //4. Read: Lấy toàn bộ hóa đơn ViewModel
        public List<HoaDonViewModel> GetAllHoaDonViewModel()
        {
            // 1. Lấy dữ liệu thô
            List<HoaDon> listHoaDon = hoaDonDAL.GetAllHoaDon();
            List<Dien> listDien = dienDAL.GetAllDien();
            List<Nuoc> listNuoc = nuocDAL.GetAllNuoc();
            List<LePhi> listLePhi = lePhiDAL.GetAllLePhi();
            List<PhongTro> listPhongTro = PhongTroDAL.GetAllPhong();

            // 2. JOIN 3 bảng và Ánh xạ sang ViewModel
            var result = from hd in listHoaDon
                         join d in listDien on hd.Id_Dien equals d.Id_Dien
                         join n in listNuoc on hd.Id_Nuoc equals n.Id_Nuoc
                         join lp in listLePhi on hd.Id_LePhi equals lp.Id_LePhi
                         join p in listPhongTro on hd.Id_Phong equals p.Id_Phong
                         select new HoaDonViewModel
                         {
                             // Ánh xạ các thuộc tính cơ bản (từ lớp cha HoaDOn)
                             Id_HoaDon = hd.Id_HoaDon,
                             NgayTao = hd.NgayTao,
                             TrangThai = hd.TrangThai,
                             NoiDung = hd.NoiDung,
                             Id_Phong = p.Id_Phong,
                             Id_Dien = d.Id_Dien,
                             Id_Nuoc = n.Id_Nuoc,
                             Id_LePhi = lp.Id_LePhi,
                             // Thêm thuộc tính đã JOIN
                             TenPhongHienThi = p.TenPhong,

                              ChiSo_Dien_Cu_HienThi = d.ChiSo_Dau,
                              ChiSo_Dien_Moi_HienThi = d.ChiSo_Cuoi,
                              TongTienDien_HienThi = d.ThanhTien_Dien,

                              ChiSo_Nuoc_Cu_HienThi = n.ChiSo_Dau,
                              ChiSo_Nuoc_Moi_HienThi = n.ChiSo_Cuoi,
                              TongTienNuoc_HienThi = n.ThanhTien_Nuoc,

                              TienDichVu_HienThi = lp.TienDv,
                              TienPhong_HienThi = lp.TienPhong,
                              
                         };

            return result.ToList();
        }
    }
}
