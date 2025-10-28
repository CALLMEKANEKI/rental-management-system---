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
    public class nuocBLL
    {

        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả chỉ số Nước
        public List<nuoc> LayTatCaBanGhiNuoc()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.nuocs.ToList();
            }
        }

        // R - READ (BY ID): Lấy chỉ số Nước theo ID
        public nuoc LayBanGhiNuocTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.nuocs.Find(id);
            }
        }

        // R - READ (BY ID): Lấy chỉ số Nước theo ID của hóa đơn
        public nuoc LayBanGhiNuocTheoHoaDonId(string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                // Tìm Hóa đơn, sau đó truy xuất chi tiết Nước
                // Sử dụng Include(hd => hd.nuoc) để tải chi tiết Nước
                var hoadon = dbContext.hoadons
                                       .Include(hd => hd.nuoc)
                                       .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);

                // Trả về chi tiết Nước từ Hóa đơn (có thể là null nếu không tìm thấy)
                return hoadon?.nuoc;
            }
        }

        public List<nuocViewModel> LatTatCaBanGhiNuocViewModel(string id_chutrohientai)
        {
            using (var dbContext = new ContextDB())
            {
                var query = from hd in dbContext.hoadons
                            join n in dbContext.nuocs on hd.id_nuoc equals n.id_nuoc
                            where hd.phongtro.id_chutro == id_chutrohientai
                            select new nuocViewModel
                            {
                                TenPhong = hd.phongtro.tenphong,
                                IdNuoc = n.id_nuoc,
                                ChiSo_Dau = n.chi_so_dau,
                                ChiSo_Cuoi = n.chi_so_cuoi,
                                NgayTao = n.ngay_tao,
                                TienNuoc = n.thanh_tien_nuoc,
                                TrangThai = hd.trang_thai,
                            };
                return query.ToList();
            }
        }

        public List<nuocViewModel> LatTatCaBanGhiNuocViewModelTheoKeyWord(string id_chutrohientai, string keyword)
        {
            using (var dbContext = new ContextDB())
            {
                string searchKeyword = (keyword ?? string.Empty).ToLower();
                var query = from hd in dbContext.hoadons
                            join n in dbContext.nuocs on hd.id_nuoc equals n.id_nuoc
                            where hd.phongtro.id_chutro == id_chutrohientai
                            select new nuocViewModel
                            {
                                TenPhong = hd.phongtro.tenphong,
                                IdNuoc = n.id_nuoc,
                                ChiSo_Dau = n.chi_so_dau,
                                ChiSo_Cuoi = n.chi_so_cuoi,
                                NgayTao = n.ngay_tao,
                                TienNuoc = n.thanh_tien_nuoc,
                                TrangThai = hd.trang_thai,
                            };

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(d =>
                        d.IdNuoc.ToLower().Contains(searchKeyword) ||
                        d.ChiSo_Dau.ToString().ToLower().Contains(searchKeyword) ||
                        d.ChiSo_Cuoi.ToString().Contains(searchKeyword) ||
                        d.NgayTao.ToString().ToLower().Contains(searchKeyword) ||
                        d.TenPhong.ToLower().Contains(searchKeyword) ||
                        d.TienNuoc.ToString().ToLower().Contains(searchKeyword) ||
                        d.TrangThai.ToLower().Contains(searchKeyword)
                        );
                }

                return query.ToList();
            }
        }
    }
}