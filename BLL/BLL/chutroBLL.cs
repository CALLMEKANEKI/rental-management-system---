using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure; // Cần thiết để bắt lỗi DbUpdateException

namespace BLL.BLL
{
    public class chutroBLL
    {
        // LOẠI BỎ ContextDB FIELD để tránh lỗi Multiple Contexts và rò rỉ bộ nhớ.
        // private ContextDB _dbContext = new ContextDB(); 

        // Hàm khởi tạo ID (Đã sửa để nhận Context)
        private string GenerateNewChuTroId(ContextDB dbContext)
        {
            string prefix = "A";
            int numberLength = 9;
            int newNumber = 1;

            // 1. Tối ưu hóa truy vấn: Chỉ lấy ID lớn nhất
            var lastId = dbContext.chutroes
                                  // Chỉ chọn các ID đúng format "A" + 9 chữ số
                                  .Where(ct => ct.id_chutro.StartsWith(prefix) && ct.id_chutro.Length == prefix.Length + numberLength)
                                  .OrderByDescending(ct => ct.id_chutro) // Sắp xếp giảm dần theo chuỗi ID (hoạt động tốt nếu ID là chuỗi có độ dài cố định)
                                  .Select(ct => ct.id_chutro)
                                  .FirstOrDefault(); // Chỉ lấy một ID

            // 2. Phân tích và tạo ID mới
            if (lastId != null)
            {
                string numberPart = lastId.Substring(prefix.Length);
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    if (currentNumber < 999999999) // Giới hạn 9 chữ số (Max int 2,147,483,647)
                    {
                        newNumber = currentNumber + 1;
                    }
                    else
                    {
                        throw new OverflowException("ID Chủ trọ đã đạt giới hạn tối đa (A999999999).");
                    }
                }
            }

            // 3. Định dạng và trả về
            return prefix + newNumber.ToString($"D{numberLength}");
        }

        // C - CREATE: Thêm mới Chủ Trọ
        public bool ThemChutro(chutro newChutro)
        {
            if (newChutro == null) return false;

            using (var dbContext = new ContextDB())
            {
                try
                {
                    // 1. TẠO VÀ GÁN ID MỚI
                    newChutro.id_chutro = GenerateNewChuTroId(dbContext);

                    // 2. Thêm và lưu
                    dbContext.chutroes.Add(newChutro);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Thêm Chủ trọ): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể thêm chủ trọ mới. Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ALL): Lấy tất cả Chủ Trọ
        public List<chutro> LayTatCaChutro()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.chutroes.ToList();
            }
        }

        // R - READ (BY ID): Lấy Chủ Trọ theo ID
        public chutro LayChutroTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.chutroes.FirstOrDefault(ct => ct.id_chutro == id);
            }
        }

        // R - READ (BY USERNAME): Lấy Chủ Trọ theo tên tài khoản
        public chutro LayChutroTheoUserName(string username)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.chutroes.FirstOrDefault(ct => ct.taikhoan == username);
            }
        }

        // U - UPDATE: Cập nhật thông tin Chủ Trọ
        public bool CapNhatChutro(chutro updatedChutro)
        {
            if (updatedChutro == null || string.IsNullOrEmpty(updatedChutro.id_chutro)) return false;

            using (var dbContext = new ContextDB())
            {
                try
                {
                    // Lấy đối tượng hiện tại để Entity Framework theo dõi
                    var existingChutro = dbContext.chutroes.Find(updatedChutro.id_chutro);

                    if (existingChutro == null) return false;

                    // Cập nhật các thuộc tính
                    existingChutro.hoten = updatedChutro.hoten;
                    existingChutro.sdt = updatedChutro.sdt;
                    existingChutro.email = updatedChutro.email;
                    existingChutro.diachi = updatedChutro.diachi;
                    existingChutro.taikhoan = updatedChutro.taikhoan;
                    existingChutro.avatar_url = updatedChutro.avatar_url;
                    existingChutro.anh_cccd_truoc_url = updatedChutro.anh_cccd_truoc_url;
                    existingChutro.anh_cccd_sau_url = updatedChutro.anh_cccd_sau_url;
                    existingChutro.matkhau = updatedChutro.matkhau;

                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể cập nhật chủ trọ. Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        // D - DELETE: Xóa Chủ Trọ
        public bool XoaChutro(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                try
                {
                    // Sử dụng Find để tìm nhanh dựa trên khóa chính
                    var chutroToDelete = dbContext.chutroes.Find(id_chutro);

                    if (chutroToDelete == null) return false; // Không tìm thấy để xóa

                    dbContext.chutroes.Remove(chutroToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbUpdateException dbEx) // Bắt lỗi ràng buộc khóa ngoại (ví dụ: Chủ trọ này có phòng)
                {
                    Console.WriteLine("Lỗi DB (Xóa Chủ trọ): Không thể xóa do tồn tại ràng buộc dữ liệu. Chi tiết: " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không thể xóa chủ trọ. Lỗi: " + ex.Message);
                    return false;
                }
            }
        }
    }
}