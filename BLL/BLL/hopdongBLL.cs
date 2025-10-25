using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class hopdongBLL
    {

        // Hàm tự động tạo id cho hợp đồng (Đã sửa để nhận Context)
        private string GenerateNewHopDongId(ContextDB dbContext)
        {
            // Tìm ID Hợp đồng lớn nhất hiện có
            var lastId = dbContext.hopdongs
                                 .OrderByDescending(h => h.id_hopdong)
                                 .Select(h => h.id_hopdong)
                                 .FirstOrDefault();

            // Định dạng ID: Cxxxxxxxxx
            string prefix = "C";
            int numberLength = 9;
            int newNumber = 1;

            if (lastId != null && lastId.StartsWith(prefix) && lastId.Length == prefix.Length + numberLength)
            {
                // 1. Tách phần số từ hậu tố 
                string numberPart = lastId.Substring(prefix.Length);

                // 2. Chuyển đổi và tăng số
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    if (currentNumber < 999999999)
                    {
                        newNumber = currentNumber + 1;
                    }
                    else
                    {
                        throw new OverflowException("ID Hợp đồng đã đạt giới hạn tối đa.");
                    }
                }
            }

            // 3. Định dạng lại thành chuỗi 9 chữ số (D9) và trả về
            return prefix + newNumber.ToString($"D{numberLength}");
        }

        // C - CREATE: Thêm mới Hợp đồng (Đã sửa lỗi Context Tracking)
        public bool ThemHopDong(hopdong newHopDong, string id_chutro)
        {
            if (newHopDong == null || string.IsNullOrEmpty(newHopDong.id_phong))
                return false;

            using (var dbContext = new ContextDB())
            {
                // 1. Xác minh: id_phong trong hợp đồng có thuộc về id_chutro không
                var phongtro = dbContext.phongtroes.FirstOrDefault(p =>
                    p.id_phong == newHopDong.id_phong &&
                    p.id_chutro == id_chutro);

                if (phongtro == null)
                {
                    return false; // Phòng không thuộc về chủ trọ này
                }

                try
                {
                    // 2. TẠO VÀ GÁN ID MỚI TRƯỚC KHI LƯU
                    newHopDong.id_hopdong = GenerateNewHopDongId(dbContext);

                    // 3. Thêm và lưu
                    dbContext.hopdongs.Add(newHopDong);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Thêm Hợp đồng): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi thêm hợp đồng: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ALL): Lấy tất cả Hợp đồng
        public List<hopdong> LayTatCaHopDong(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                // Sử dụng Include để tải Navigation Property (phongtro)
                return dbContext.hopdongs
                                .Include(hd => hd.phongtro)
                                .Where(hd => hd.phongtro.id_chutro == id_chutro)
                                .ToList();
            }
        }

        // R - READ (ALL): Lấy tất cả Hợp đồng theo Id 
        public hopdong LayHopDongtheoId(string id_hopdong, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.hopdongs
                                 .Include(hd => hd.phongtro)
                                 .FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro &&
                                                       hd.id_hopdong == id_hopdong);
            }
        }

        // R - READ (ALL): Lấy tất cả Hợp đồng ViewModel
        public List<hopdongViewModel> LayTatCaHopDongViewModel(string idChuTro)
        {
            using (var dbContext = new ContextDB())
            {
                var query = from hd in dbContext.hopdongs
                            join pt in dbContext.phongtroes on hd.id_phong equals pt.id_phong
                            join nt in dbContext.nguoithues on hd.id_nguoi_thue equals nt.id_nguoi_thue
                            where pt.id_chutro == idChuTro
                            select new hopdongViewModel
                            {
                                IDHopDong = hd.id_hopdong,
                                NgayBatDau = hd.ngay_bat_dau,
                                NgayKetThuc = hd.ngay_ket_thuc,
                                TienCoc = hd.tien_coc,

                                // Ánh xạ thuộc tính
                                TenNguoiThue = nt.hoten,
                                TenPhong = pt.tenphong,
                            };

                return query.ToList();
            }
        }

        public List<hopdongViewModel> LayTatCaHopDongTheoKeywork(string keyword, string id_chutro)
        {
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(id_chutro))
            {
                return new List<hopdongViewModel>();
            }

            // Chuyển từ khóa về chữ thường để tìm kiếm không phân biệt hoa thường
            string searchKeyword = keyword.Trim().ToLower();

            using (var dbContext = new ContextDB())
            {
                // Truy vấn Hợp đồng, bao gồm các bảng liên quan (Phòng trọ, Người thuê)
                var query = dbContext.hopdongs
                    .Include(hd => hd.phongtro)
                    .Include(hd => hd.nguoi_thue)
                    .Where(hd => hd.phongtro.id_chutro == id_chutro) // Lọc bắt buộc theo Chủ trọ
                    .AsQueryable();

                // Lọc theo Từ khóa
                query = query.Where(hd =>
                    // Tìm theo Mã Hợp đồng
                    hd.id_hopdong.ToLower().Contains(searchKeyword) ||
                    // Tìm theo Tên Phòng
                    hd.phongtro.tenphong.ToLower().Contains(searchKeyword) ||
                    // Tìm theo Tên Người thuê
                    hd.nguoi_thue.hoten.ToLower().Contains(searchKeyword)
                );

                // Chuyển kết quả sang ViewModel để trả về
                var result = query.Select(hd => new hopdongViewModel
                {
                    IDHopDong = hd.id_hopdong,
                    NgayBatDau = hd.ngay_bat_dau,
                    NgayKetThuc = hd.ngay_ket_thuc,
                    TienCoc = hd.tien_coc,
                    TenNguoiThue = hd.nguoi_thue.hoten,
                    TenPhong = hd.phongtro.tenphong
                }).ToList();
                return result;
            }
        }

        // U - UPDATE: Cập nhật Hợp đồng
        public bool CapNhatHopDong(hopdong updatedHopDong, string id_chutro)
        {
            if (updatedHopDong == null || string.IsNullOrEmpty(updatedHopDong.id_hopdong))
                return false;

            using (var dbContext = new ContextDB())
            {
                try
                {
                    // Tìm đối tượng hiện tại và xác minh quyền sở hữu
                    var existing = dbContext.hopdongs
                                             .Include(hd => hd.phongtro)
                                             .FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro
                                                                    && hd.id_hopdong == updatedHopDong.id_hopdong);
                    if (existing == null) return false;

                    // Cập nhật các thuộc tính
                    existing.ngay_bat_dau = updatedHopDong.ngay_bat_dau;
                    existing.ngay_ket_thuc = updatedHopDong.ngay_ket_thuc;
                    existing.tien_coc = updatedHopDong.tien_coc;
                    existing.id_chutro = id_chutro;
                    existing.id_phong = updatedHopDong.id_phong;
                    existing.id_nguoi_thue = updatedHopDong.id_nguoi_thue;
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi cập nhật hợp đồng: " + ex.Message);
                    return false;
                }
            }
        }

        // D - DELETE: Xóa Hợp đồng
        public bool XoaHopDong(string id_hopdong, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    // Tìm đối tượng để xóa và xác minh quyền sở hữu
                    var toDelete = dbContext.hopdongs
                                            .Include(hd => hd.phongtro)
                                            .FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro
                                                                    && hd.id_hopdong == id_hopdong);
                    if (toDelete == null) return false;

                    dbContext.hopdongs.Remove(toDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Xóa Hợp đồng): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi xóa hợp đồng: " + ex.Message);
                    return false;
                }
            }
        }
    }
}