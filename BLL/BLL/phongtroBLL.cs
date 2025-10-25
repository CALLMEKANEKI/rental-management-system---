using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure; 

namespace BLL.BLL
{
    public class phongtroBLL
    {
        private string GenerateNewPhongTroId(ContextDB dbContext)
        {
            // Cố gắng tìm ID Phòng Trọ lớn nhất hiện có
            var lastId = dbContext.phongtroes
                                .OrderByDescending(p => p.id_phong)
                                .Select(p => p.id_phong)
                                .FirstOrDefault();

            string prefix = "R";
            int numberLength = 9;
            int newNumber = 1;

            if (lastId != null && lastId.StartsWith(prefix) && lastId.Length == prefix.Length + numberLength)
            {
                string numberPart = lastId.Substring(prefix.Length);
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    if (currentNumber < int.MaxValue)
                    {
                        newNumber = currentNumber + 1;
                    }
                    else
                    {
                        throw new OverflowException("ID Phòng Trọ đã đạt giới hạn tối đa.");
                    }
                }
            }
            // Định dạng số thành chuỗi với số 0 đệm
            return prefix + newNumber.ToString($"D{numberLength}");
        }

        // C - CREATE: Thêm mới Phòng Trọ (Đã sửa lỗi Context Tracking)
        public bool ThemPhongTro(phongtro newPhongTro, string id_chutro)
        {
            if (newPhongTro == null) return false;

            // Đảm bảo Context được Dispose sau khi hoàn thành
            using (var dbContext = new ContextDB())
            {
                // 1. GÁN ID MỚI (CHUYỀN CONTEXT VÀO HÀM GENERATE)
                newPhongTro.id_phong = GenerateNewPhongTroId(dbContext);

                // 2. Gán ID chủ trọ
                newPhongTro.id_chutro = id_chutro;

                try
                {
                    // LƯU Ý: Nếu newPhongTro được load từ nơi khác, vẫn có thể bị lỗi Tracking.
                    // Nếu lỗi vẫn xảy ra, hãy tạo một đối tượng mới hoàn toàn ngay tại đây
                    // var entityToSave = new phongtro { id_phong = newPhongTro.id_phong, ... }

                    dbContext.phongtroes.Add(newPhongTro);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    // In Inner Exception để biết chính xác lỗi DB
                    var innerEx = dbEx.InnerException?.InnerException?.Message ?? dbEx.InnerException?.Message ?? dbEx.Message;
                    Console.WriteLine("LỖI DB (Thêm Phòng - DbUpdateException): " + innerEx);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi (Thêm Phòng): " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ViewModel): Lấy tất cả Phòng Trọ ViewModel
        public List<phongtroViewModel> LayTatCaPhongTroViewModel(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.phongtroes
                                 .Where(p => p.id_chutro == id_chutro)
                                 .Select(p => new phongtroViewModel
                                 {
                                     id_phong = p.id_phong,
                                     tenphong = p.tenphong,
                                     giaphong = p.giaphong,
                                     tinhtrang = p.tinhtrang,
                                     id_chutro = p.id_chutro
                                 })
                                 .ToList();
            }
        }

        // R - READ (ALL): Lấy tất cả Phòng Trọ (entity)
        public List<phongtro> LayTatCaPhongTro(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.phongtroes
                                 .Where(p => p.id_chutro == id_chutro)
                                 .ToList();
            }
        }

        // R - READ (BY ID): Lấy Phòng Trọ theo ID
        public phongtro LayPhongTroTheoId(string id_phong, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.phongtroes
                                 .FirstOrDefault(p => p.id_phong == id_phong && p.id_chutro == id_chutro);
            }
        }

        // R - READ (BY ID): Lấy Phòng Trọ trống
        public List<phongtro> TimPhongTrong(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.phongtroes
                    .Where(p => p.tinhtrang.ToLower().Contains("trong") && p.id_chutro == id_chutro)
                    .ToList();
            }
        }

        // R - READ (BY ID): Lấy Phòng Trọ theo keyword
        public List<phongtro> TimKiemPhongTro(string keyword, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                var query = from pt in dbContext.phongtroes
                            where pt.id_chutro == id_chutro
                            select pt;

                string searchKeyword = (keyword ?? string.Empty).ToLower();

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(pt =>
                        pt.id_phong.ToLower().Contains(searchKeyword) ||
                        pt.tenphong.ToLower().Contains(searchKeyword) ||
                        pt.tinhtrang.ToLower().Contains(searchKeyword)
                    );
                }
                return query.ToList();
            }
        }

        // U - UPDATE: Cập nhật thông tin Phòng Trọ
        public bool CapNhatPhongTro(phongtro updatedPhong, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    var existing = dbContext.phongtroes
                                     .FirstOrDefault(p => p.id_phong == updatedPhong.id_phong &&
                                                            p.id_chutro == id_chutro);
                    if (existing == null) return false;

                    // Cập nhật các trường
                    existing.tenphong = updatedPhong.tenphong;
                    existing.giaphong = updatedPhong.giaphong;
                    existing.tinhtrang = updatedPhong.tinhtrang;
                    existing.id_chutro = id_chutro;

                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể cập nhật phòng: " + ex.Message);
                    return false;
                }
            }
        }

        // D - DELETE: Xóa Phòng Trọ
        public bool XoaPhongTro(string id_phongtro, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    var phongToDelete = dbContext.phongtroes
                                                .FirstOrDefault(p => p.id_phong == id_phongtro &&
                                                                     p.id_chutro == id_chutro);
                    if (phongToDelete == null) return false;

                    dbContext.phongtroes.Remove(phongToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Xóa Phòng): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể xóa phòng: " + ex.Message);
                    return false;
                }
            }
        }

        // TRẢ PHÒNG (UPDATE trạng thái)
        public bool TraPhong(string id_phong, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    var phong = dbContext.phongtroes
                                         .FirstOrDefault(p => p.id_phong == id_phong && p.id_chutro == id_chutro);
                    if (phong == null) return false;

                    phong.tinhtrang = "Trống";
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể trả phòng: " + ex.Message);
                    return false;
                }
            }
        }
    }
}