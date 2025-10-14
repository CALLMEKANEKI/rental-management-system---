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
        // Khai báo các DAL
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private DienDAL dienDAL = new DienDAL();
        private NuocDAL nuocDAL = new NuocDAL();
        private LePhiDAL lePhiDAL = new LePhiDAL();
        private PhongTroDAL PhongTroDAL = new PhongTroDAL(); // Không cần thiết nếu DAL đã JOIN
        // 1. CREATE: Tạo Hóa Đơn Chính thức (Giữ nguyên logic Transaction)

        public int CreateHoaDon(HoaDon objHoaDon, Dien objDien, Nuoc objNuoc, LePhi objLePhi)
        {
            if (objHoaDon.Id_Phong <= 0)
                return -2; // Mã lỗi: ID Phòng không hợp lệ

            // *** LOGIC VALIDATION BLL (Nên thêm ở đây) ***
            // if (objDien.ChiSo_Dau > objDien.ChiSo_Cuoi) return -10; // Ví dụ: Chỉ số điện không hợp lệ
            // if (objHoaDon.ThanhTien <= 0) return -11; // Ví dụ

            using (var scope = new TransactionScope())
            {
                try
                {
                    // B1: Gọi DAL tạo các chi phí chi tiết
                    int idDien = dienDAL.InsertDien(objDien);
                    int idNuoc = nuocDAL.InsertNuoc(objNuoc);
                    int idLePhi = lePhiDAL.InsertLePhi(objLePhi);

                    if (idDien <= 0 || idNuoc <= 0 || idLePhi <= 0)
                        throw new Exception("Lỗi khi tạo các bản ghi chi phí chi tiết.");

                    // B2: Tính tổng tiền Hóa đơn (LOGIC NGHIỆP VỤ BLL)
                    objHoaDon.ThanhTien = objDien.ThanhTien_Dien +
                                          objNuoc.ThanhTien_Nuoc +
                                          objLePhi.TienDv +
                                          objLePhi.TienPhong;

                    // Gán ID chi phí vừa tạo vào đối tượng Hóa đơn
                    objHoaDon.Id_Dien = idDien;
                    objHoaDon.Id_Nuoc = idNuoc;
                    objHoaDon.Id_LePhi = idLePhi;
                    objHoaDon.TrangThai = "Chưa thanh toán"; // Đặt trạng thái mặc định

                    // B3: Gọi DAL tạo Hóa đơn chính
                    int idHoaDonMoi = hoaDonDAL.InsertHoaDon(objHoaDon);

                    if (idHoaDonMoi <= 0)
                        throw new Exception("Lỗi khi tạo bản ghi Hóa đơn chính.");

                    // B4: Thành công, Commit giao dịch
                    scope.Complete();
                    return idHoaDonMoi;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi nghiệp vụ khi tạo Hóa đơn (Rollback): " + ex.Message);
                    return -1;
                }
            }
        }

        // 2. UPDATE: Cập nhật trạng thái Hóa đơn (Giữ nguyên)
        public bool UpdateHoaDon(int idHoaDon, string trangThaiMoi)
        {
            // BLL Validation: Chỉ chấp nhận các trạng thái hợp lệ
            if (trangThaiMoi != "Đã thanh toán" && trangThaiMoi != "Chưa thanh toán")
                return false;

            return hoaDonDAL.UpdateTrangThai(idHoaDon, trangThaiMoi);
        }

        // 3. DELETE: Xóa hóa đơn (Giữ nguyên logic Transaction)
        public bool DeleteHoaDonDayDu(int idHoaDon)
        {
            if (idHoaDon <= 0) return false;

            // BLL Logic 1: Lấy ID chi phí liên quan (từ DAL)
            // SỬA: Không cần khởi tạo lại DAL ở đây, dùng instance đã khai báo
            HoaDon objHoaDon = hoaDonDAL.GetHoaDonById(idHoaDon);

            if (objHoaDon == null)
            {
                return true;
            }

            // BLL Logic 2: Bắt đầu Giao dịch
            using (var scope = new TransactionScope())
            {
                try
                {
                    // B. Xóa 3 bản ghi chi phí liên quan
                    if (!dienDAL.DeleteDien(objHoaDon.Id_Dien))
                        throw new Exception("Lỗi khi xóa chi phí Điện.");

                    if (!nuocDAL.DeleteNuoc(objHoaDon.Id_Nuoc))
                        throw new Exception("Lỗi khi xóa chi phí Nước.");

                    if (!lePhiDAL.DeleteLePhi(objHoaDon.Id_LePhi))
                        throw new Exception("Lỗi khi xóa chi phí Lệ phí.");

                    // A. Xóa bản ghi Hóa đơn chính
                    if (!hoaDonDAL.DeleteHoaDon(idHoaDon))
                        throw new Exception("Lỗi khi xóa Hóa đơn chính.");

                    // C. Commit giao dịch
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi nghiệp vụ khi xóa Hóa đơn (Rollback): " + ex.Message);
                    return false;
                }
            }
        }

        // 4. READ: Lấy ViewModel (Đẩy logic JOIN sang DAL)
        public List<HoaDonViewModel> GetAllHoaDonViewModel(int idChuTro)
        {
            if (idChuTro <= 0)
                return new List<HoaDonViewModel>();

            // SỬA: Chỉ cần gọi hàm ViewModel đã được tối ưu trong DAL
            return hoaDonDAL.GetAllHoaDonViewModel(idChuTro);
        }

        public List<HoaDonViewModel> GetAllHoaDonViewModelByKeyWord(int idChuTro, string keywork)
        {
            return hoaDonDAL.GetAllHoaDonViewModelByKeyWord(idChuTro, keywork);
        }

    }
}
