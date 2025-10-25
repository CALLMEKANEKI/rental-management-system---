using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure; // Cần thiết để bắt lỗi DbUpdateException
using System.Linq;

namespace BLL.BLL
{
    public class nguoithueBLL
    {

        // Hàm tạo ID (Đã sửa để nhận Context)
        private string GenerateNewNguoiThueId(ContextDB dbContext)
        {
            // Cố gắng tìm ID Người thuê lớn nhất hiện có
            var lastId = dbContext.nguoithues // Giả định tên DbSet là Nguoithues
                                .OrderByDescending(nt => nt.id_nguoi_thue)
                                .Select(nt => nt.id_nguoi_thue)
                                .FirstOrDefault();

            string prefix = "G";
            int numberLength = 9;
            int newNumber = 1;

            if (lastId != null && lastId.StartsWith(prefix) && lastId.Length == prefix.Length + numberLength)
            {
                string numberPart = lastId.Substring(prefix.Length);
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    if (currentNumber < 999999999)
                    {
                        newNumber = currentNumber + 1;
                    }
                    else
                    {
                        throw new OverflowException("ID Người thuê đã đạt giới hạn tối đa.");
                    }
                }
            }
            return prefix + newNumber.ToString($"D{numberLength}");
        }

        // C - CREATE: Thêm mới Người thuê (Đã sửa lỗi Context Tracking)
        public bool ThemNguoiThue(nguoi_thue newNguoiThue, string id_chutro)
        {
            if (newNguoiThue == null || string.IsNullOrEmpty(newNguoiThue.id_phong))
                throw new Exception("Phòng trọ không hợp lệ hoặc chưa được chọn.");

            using (var dbContext = new ContextDB())
            {
                // KIỂM TRA LOGIC VÀ QUYỀN SỞ HỮU
                var phongTro = dbContext.phongtroes
                                        .FirstOrDefault(p =>
                                            p.id_phong == newNguoiThue.id_phong &&
                                            p.id_chutro == id_chutro);

                if (phongTro == null)
                {
                    // Phòng không tồn tại HOẶC không thuộc về chủ trọ này
                    Console.WriteLine("Lỗi logic: Phòng trọ không tồn tại hoặc không thuộc về chủ trọ.");
                    return false;
                }

                try
                {
                    // 2. TẠO VÀ GÁN ID MỚI TRƯỚC KHI LƯU
                    newNguoiThue.id_nguoi_thue = GenerateNewNguoiThueId(dbContext);

                    // 3. Thêm và lưu
                    dbContext.nguoithues.Add(newNguoiThue);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Thêm Người thuê): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể thêm người thuê mới. Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ALL): Lấy tất cả Người Thuê (Entity)
        public List<nguoi_thue> LayTatCaNguoiThue(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                // Sử dụng Include để tải thông tin phongtro, tránh N+1 Query
                return dbContext.nguoithues
                                 .Include(nt => nt.phongtro)
                                 .Where(nt => nt.phongtro.id_chutro == id_chutro)
                                 .ToList();
            }
        }

        // R - READ (BY ID): Lấy người thuê theo ID
        public nguoi_thue LayNguoiThueTheoId(string id_chutro, string id_nguoithue)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.nguoithues
                                 .Include(nt => nt.phongtro)
                                 .FirstOrDefault(nt => nt.phongtro.id_chutro == id_chutro
                                                        && nt.id_nguoi_thue == id_nguoithue);
            }
        }

        //R - READ (BY ID): Lấy người thuê viewmodel
        public List<nguoithueViewModel> LayTatCaNguoiThueViewModel(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                // Sử dụng LINQ Join để tạo ViewModel
                var query = from nt in dbContext.nguoithues
                            join pt in dbContext.phongtroes on nt.id_phong equals pt.id_phong
                            where pt.id_chutro == id_chutro
                            select new nguoithueViewModel
                            {
                                IDNguoiThue = nt.id_nguoi_thue,
                                HoTenNguoiThue = nt.hoten,
                                SoDienThoai = nt.sdt,
                                CCCD = nt.cccd,
                                Email = nt.email,
                                TenPhong = pt.tenphong,
                                IDPhong = pt.id_phong
                            };

                return query.ToList();
            }
        }

        //R - READ (BY ID): Lấy người thuê viewmodel theo keyword
        public List<nguoithueViewModel> TimKiemNguoiThue(string keyword, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                string searchKeyword = (keyword ?? string.Empty).ToLower();

                // 1. Join Người Thuê và Phòng Trọ
                var query = from nt in dbContext.nguoithues
                            join pt in dbContext.phongtroes on nt.id_phong equals pt.id_phong
                            where pt.id_chutro == id_chutro
                            select new { nt, pt };

                // 2. Lọc theo Từ khóa
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(data =>
                        data.nt.id_nguoi_thue.ToLower().Contains(searchKeyword) ||
                        data.nt.hoten.ToLower().Contains(searchKeyword) ||
                        data.nt.cccd.ToLower().Contains(searchKeyword) ||
                        data.nt.sdt.ToLower().Contains(searchKeyword) ||
                        data.pt.tenphong.ToLower().Contains(searchKeyword)
                    );
                }

                // 3. Ánh xạ kết quả sang ViewModel
                var result = query.Select(data => new nguoithueViewModel
                {
                    IDNguoiThue = data.nt.id_nguoi_thue,
                    HoTenNguoiThue = data.nt.hoten,
                    SoDienThoai = data.nt.sdt,
                    CCCD = data.nt.cccd,
                    Email = data.nt.email,
                    TenPhong = data.pt.tenphong,
                    IDPhong = data.pt.id_phong
                }).ToList();

                return result;
            }
        }

        // R - READ (BY ID): Lấy tất cả người thuê theo phòng
        public List<nguoi_thue> LayNguoiThueTheoPhong(string id_chutro, string id_phong)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.nguoithues
                                 .Include(nt => nt.phongtro)
                                 .Where(nt => nt.phongtro.id_chutro == id_chutro && nt.id_phong == id_phong)
                                 .ToList();
            }
        }

        // U - UPDATE: Cập nhật thông tin Người Thuê
        public bool CapNhatNguoiThue(nguoi_thue updatedNguoiThue, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    // Lấy đối tượng hiện có, đồng thời xác minh quyền sở hữu
                    var existing = dbContext.nguoithues
                                             .Include(nt => nt.phongtro)
                                             .FirstOrDefault(nt => nt.phongtro.id_chutro == id_chutro
                                                                    && nt.id_nguoi_thue == updatedNguoiThue.id_nguoi_thue);
                    if (existing == null) return false;

                    existing.hoten = updatedNguoiThue.hoten;
                    existing.cccd = updatedNguoiThue.cccd;
                    existing.sdt = updatedNguoiThue.sdt;
                    existing.email = updatedNguoiThue.email;
                    existing.id_phong = updatedNguoiThue.id_phong;

                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể cập nhật người thuê. Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        // D - DELETE: Xóa Người Thuê
        public bool XoaNguoiThue(string id_nguoithue, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    // Lấy đối tượng để xóa, đồng thời xác minh quyền sở hữu
                    var nguoiThueToDelete = dbContext.nguoithues
                                                     .Include(nt => nt.phongtro)
                                                     .FirstOrDefault(nt => nt.phongtro.id_chutro == id_chutro
                                                                    && nt.id_nguoi_thue == id_nguoithue);
                    if (nguoiThueToDelete == null) return false;

                    dbContext.nguoithues.Remove(nguoiThueToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Xóa Người thuê): Không thể xóa do tồn tại ràng buộc dữ liệu. Chi tiết: " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể xóa người thuê. Lỗi: " + ex.Message);
                    return false;
                }
            }
        }
    }
}