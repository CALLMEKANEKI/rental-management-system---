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
        private PhongTroDAL PhongTroDAL = new PhongTroDAL();

        // --- CREATE ---
        public int InsertHopDong(HopDong objHopDong)
        {
            //  Validation cơ bản
            if (objHopDong.Id_Phong <= 0 || objHopDong.Id_NguoiThue <= 0 || objHopDong.TienCoc <= 0)
            {
                return -1; // Lỗi: Thiếu thông tin bắt buộc
            }

            // Logic nghiệp vụ 2: Đảm bảo việc Thêm hợp đồng và Cập nhật trạng thái phòng là Nguyên tố
            int newHopDongId = -1;

            // Sử dụng TransactionScope để quản lý giao tác phân tán (nếu cần) hoặc giao tác cục bộ
            using (var scope = new TransactionScope())
            {
                try
                {
                    // A. Thêm Hợp đồng vào CSDL
                    newHopDongId = hopDongDAL.InsertHopDong(objHopDong);

                    if (newHopDongId > 0)
                    {
                        // B. Cập nhật trạng thái phòng trọ sang "Đã thuê"
                        // GIẢ ĐỊNH: Trong PhongTroDAL có hàm UpdateTrangThaiPhong(int idPhong, string newStatus)
                        // Bạn cần định nghĩa PhongTro.TrangThaiPhong = "Đã Thuê"
                        const string TRANG_THAI_DA_THUE = "Đã thuê";

                        bool updatePhongSuccess = PhongTroDAL.UpdateTrangThaiPhong(objHopDong.Id_Phong, TRANG_THAI_DA_THUE);

                        if (updatePhongSuccess)
                        {
                            scope.Complete(); // Hoàn tất giao tác
                            return newHopDongId;
                        }
                        else
                        {
                            // Nếu cập nhật phòng thất bại, giao tác sẽ không Complete và sẽ bị Rollback
                            return -1;
                        }
                    }
                    return -1; // Thêm hợp đồng thất bại
                }
                catch (Exception ex)
                {
                    // Mọi lỗi (SQL hoặc code) sẽ dẫn đến Rollback do scope.Complete() chưa được gọi.
                    Console.WriteLine("Error in InsertHopDong BLL Transaction: " + ex.Message);
                    return -1;
                }
            }
        }

        // --- UPDATE ---
        public bool UpdateHopDong(HopDong objHopDong)
        {
            // 1. Validation nghiệp vụ
            if (objHopDong.NgayKetThuc <= objHopDong.NgayBatDau)
            {
                return false;
            }

            // 2. Gọi DAL
            return hopDongDAL.UpdateHopDong(objHopDong);
        }

        // --- DELETE ---
        public bool DeleteHopDong(int idHopDong)
        {
            // Thêm logic kiểm tra xem hợp đồng có hóa đơn liên quan không, nếu có thì ngăn chặn xóa (hoặc phải xóa hóa đơn trước)
            return hopDongDAL.DeleteHopDong(idHopDong);
        }

        // --- READ / SEARCH ---
        public List<HopDongViewModel> GetAllHopDongViewModel(int idChuTro)
        {
            return hopDongDAL.GetAllHopDongViewModel(idChuTro);
        }

        public List<HopDongViewModel> GetAllHopDongViewModelByKeyWord(int idChuTro, string keyword)
        {
            return hopDongDAL.GetAllHopDongViewModelByKeyWord(idChuTro, keyword);
        }
    }
}