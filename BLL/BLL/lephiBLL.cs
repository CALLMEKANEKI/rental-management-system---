using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.BLL
{
    public class lephiBLL
    {
        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả Lệ phí
        public List<lephi> LayTatCaLePhi()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.lephis.ToList();
            }
        }

        // R - READ (BY ID): Lấy Lệ phí theo ID
        public lephi LayLePhiTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                // Find() hoạt động hiệu quả khi tìm kiếm theo khóa chính
                return dbContext.lephis.Find(id);
            }
        }

        //R - READ (BY ID): Lấy Lệ phí theo ID của hóa đơn
        public lephi LayBanGhiLePhiTheoHoaDonId(string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                // Tìm Hóa đơn, sau đó truy xuất chi tiết Lệ Phí
                // Sử dụng Include(hd => hd.lephi) để tải chi tiết Lệ Phí
                var hoadon = dbContext.hoadons
                                       .Include(hd => hd.lephi)
                                       .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);

                // Trả về chi tiết Lệ Phí từ Hóa đơn (có thể là null nếu không tìm thấy)
                return hoadon?.lephi;
            }
        }

        public List<lephiViewModel> LatTatCaBanGhiLePhiViewModel(string id_chutrohientai)
        {
            using (var dbContext = new ContextDB())
            {
                var query = from hd in dbContext.hoadons
                            join lp in dbContext.lephis on hd.id_lephi equals lp.id_lephi
                            where hd.phongtro.id_chutro == id_chutrohientai
                            select new lephiViewModel
                            {
                                TenPhong = hd.phongtro.tenphong,
                                IdLePhi = lp.id_lephi,
                                TienDV = lp.tien_dv,
                                TienPhong = lp.tien_phong,
                                NgayTao = lp.ngay_tao,
                                TienLePhi = lp.thanh_tien_lephi,
                                TrangThai = hd.trang_thai,
                            };
                return query.ToList();
            }
        }

        public List<lephiViewModel> LatTatCaBanGhiLePhiViewModelTheoKeyWord(string id_chutrohientai, string keyword)
        {
            using (var dbContext = new ContextDB())
            {
                string searchKeyword = (keyword ?? string.Empty).ToLower();
                var query = from hd in dbContext.hoadons
                            join lp in dbContext.lephis on hd.id_lephi equals lp.id_lephi
                            where hd.phongtro.id_chutro == id_chutrohientai
                            select new lephiViewModel
                            {
                                TenPhong = hd.phongtro.tenphong,
                                IdLePhi = lp.id_lephi,
                                TienDV = lp.thanh_tien_lephi,
                                TienPhong = lp.thanh_tien_lephi,
                                NgayTao = lp.ngay_tao,
                                TienLePhi = lp.thanh_tien_lephi,
                                TrangThai = hd.trang_thai,
                            };

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(lp =>
                        lp.IdLePhi.ToLower().Contains(searchKeyword) ||
                        lp.TienPhong.ToString().ToLower().Contains(searchKeyword) ||
                        lp.TienDV.ToString().Contains(searchKeyword) ||
                        lp.NgayTao.ToString().ToLower().Contains(searchKeyword) ||
                        lp.TenPhong.ToLower().Contains(searchKeyword) ||
                        lp.TienLePhi.ToString().ToLower().Contains(searchKeyword) ||
                        lp.TrangThai.ToLower().Contains(searchKeyword)
                        );
                }

                return query.ToList();
            }
        }
    }
}