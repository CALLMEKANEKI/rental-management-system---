using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BLL.BLL
{
    public class dienBLL
    {
        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL
        private hoadonBLL _hoadonBLL = new hoadonBLL();
        // R - READ (ALL): Lấy tất cả chỉ số Điện
        public List<dien> LayTatCaBanGhiDien()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.diens.ToList();
            }
        }

        // R - READ (BY ID): Lấy chỉ số Điện theo ID
        public dien LayBanGhiDienTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                // Find() hoạt động hiệu quả khi tìm kiếm theo khóa chính
                return dbContext.diens.Find(id);
            }
        }

        // R - READ (BY ID): Lấy chỉ số Điện theo ID của hóa đơn
        public dien LayBanGhiDienTheoHoaDonId(string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                // Tìm Hóa đơn, sau đó truy xuất chi tiết Điện
                // Sử dụng Include(hd => hd.dien) để tải chi tiết Điện
                var hoadon = dbContext.hoadons
                                       .Include(hd => hd.dien)
                                       .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);

                // Trả về chi tiết Điện từ Hóa đơn (có thể là null nếu không tìm thấy)
                return hoadon?.dien;
            }
        }

        public List<dienViewModel> LatTatCaBanGhiDienViewModel (string id_chutrohientai)
        {
            using ( var dbContext = new ContextDB())
            {
                var query = from hd in dbContext.hoadons
                            join d in dbContext.diens on hd.id_dien equals d.id_dien
                            where hd.phongtro.id_chutro == id_chutrohientai
                            select new dienViewModel
                            {
                                TenPhong = hd.phongtro.tenphong,
                                IdDien = d.id_dien,
                                ChiSo_Dau = d.chi_so_dau,
                                ChiSo_Cuoi = d.chi_so_cuoi,
                                NgayTao = d.ngay_tao,
                                TienDien = d.thanh_tien_dien,
                                TrangThai = hd.trang_thai,
                            };
                return query.ToList();
            }    
        }

        public List<dienViewModel> LatTatCaBanGhiDienViewModelTheoKeyWord(string id_chutrohientai, string keyword)
        {
            using (var dbContext = new ContextDB())
            {
                string searchKeyword = (keyword ?? string.Empty).ToLower();
                var query= from hd in dbContext.hoadons
                                        join d in dbContext.diens on hd.id_dien equals d.id_dien
                                        where (hd.phongtro.id_chutro == id_chutrohientai)
                                        select new dienViewModel
                                        {
                                            TenPhong = hd.phongtro.tenphong,
                                            IdDien = d.id_dien,
                                            ChiSo_Dau = d.chi_so_dau,
                                            ChiSo_Cuoi = d.chi_so_cuoi,
                                            NgayTao = d.ngay_tao,
                                            TienDien = d.thanh_tien_dien,
                                            TrangThai = hd.trang_thai,
                                        };

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(d =>
                        d.IdDien.ToLower().Contains(searchKeyword) ||
                        d.ChiSo_Dau.ToString().ToLower().Contains(searchKeyword) ||
                        d.ChiSo_Cuoi.ToString().Contains(searchKeyword) ||
                        d.NgayTao.ToString().ToLower().Contains(searchKeyword) ||
                        d.TenPhong.ToLower().Contains(searchKeyword) ||
                        d.TienDien.ToString().ToLower().Contains(searchKeyword) ||
                        d.TrangThai.ToLower().Contains(searchKeyword) 
                        );
                }

                return query.ToList();
            }
        }

    }
}