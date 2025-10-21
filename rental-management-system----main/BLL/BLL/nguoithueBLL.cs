using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace BLL.BLL
{
    public class nguoithueBLL
    {
        private ContextDB _dbContext;

        public nguoithueBLL()
        {
            _dbContext = new ContextDB();
        }

        // C - CREATE: Thêm mới Người thuê
        //Hàm tạo mới id
        private string GenerateNewNguoiThueId()
        {
            // Cố gắng tìm ID Người thuê lớn nhất hiện có
            var lastId = _dbContext.nguoithues // Giả định tên DbSet là Nguoithues
                                   .OrderByDescending(nt => nt.id_nguoi_thue)
                                   .Select(nt => nt.id_nguoi_thue)
                                   .FirstOrDefault();

            string prefix = "G";
            int numberLength = 9; // 8 chữ số sau NT
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
                        throw new OverflowException("ID Người thuê đã đạt giới hạn tối đa.");
                    }
                }
            }
            return prefix + newNumber.ToString($"D{numberLength}");
        }
        public bool ThemNguoiThue(nguoi_thue newNguoiThue, string id_chutro)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản (Bỏ kiểm tra id_nguoithue)
            if (newNguoiThue == null || string.IsNullOrEmpty(newNguoiThue.id_phong)) return false;

            // LỖI LOGIC ĐÃ SỬA: Kiểm tra id_phong trong Người thuê có thuộc id_chutro không
            var phongTro = _dbContext.phongtroes // Giả định tên DbSet là Phongtros
                                     .FirstOrDefault(p =>
                                        p.id_phong == newNguoiThue.id_phong && // Xác minh phòng cụ thể
                                        p.id_chutro == id_chutro);              // Xác minh quyền sở hữu

            if (phongTro == null)
            {
                // Phòng không tồn tại HOẶC không thuộc về chủ trọ này
                return false;
            }

            try
            {
                // 2. TẠO VÀ GÁN ID MỚI TRƯỚC KHI LƯU
                newNguoiThue.id_nguoi_thue = GenerateNewNguoiThueId();

                // 3. Thêm và lưu
                _dbContext.nguoithues.Add(newNguoiThue); // Giả định tên DbSet là Nguoithues
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể thêm người thuê mới. LỖi: " + ex.Message);
                return false;
            }
        }

        // R - READ (ALL): Lấy tất cả Người Thuê
        public List<nguoi_thue> LayTatCaNguoiThue(string id_chutro)
        {
            return _dbContext.nguoithues
                             .Where(nt => nt.phongtro.id_chutro == id_chutro) // Truy vấn qua Navigation Property
                             .ToList();
        }

        // R - READ (BY ID): Lấy người thuê theo ID
        public nguoi_thue LayNguoiThueTheoId(string id_chutro, string id_nguoithue)
        {
            return _dbContext.nguoithues
                             .FirstOrDefault(nt => nt.phongtro.id_chutro == id_chutro
                                                && nt.id_nguoi_thue == id_nguoithue); // Truy vấn qua Navigation Property                             
        }

        // U - UPDATE: Cập nhật thông tin Người Thuê
        public bool CapNhatNguoiThue(nguoi_thue updatedNguoiThue, string id_chutro)
        {
            try
            {
                var existing = _dbContext.nguoithues.FirstOrDefault(nt => nt.phongtro.id_chutro == id_chutro
                                                && nt.id_nguoi_thue == updatedNguoiThue.id_nguoi_thue);
                if (existing == null) return false;

                existing.hoten = updatedNguoiThue.hoten;
                existing.cccd = updatedNguoiThue.cccd;
                existing.sdt = updatedNguoiThue.sdt;
                existing.email = updatedNguoiThue.email;

                // Khóa ngoại id_chutro có thể cần logic kiểm tra trước khi cập nhật

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể cập nhật người thuê. LỖi: " + ex.Message);

                return false;
            }
        }

        // D - DELETE: Xóa Phòng Trọ
        public bool XoaNguoiThue(string id_nguoithue, string id_chutro)
        {
            try
            {
                var phongToDelete = _dbContext.nguoithues.FirstOrDefault(nt => nt.phongtro.id_chutro == id_chutro
                                                && nt.id_nguoi_thue == id_nguoithue);
                if (phongToDelete == null) return false;

                _dbContext.nguoithues.Remove(phongToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể xóa người thuê. LỖi: " + ex.Message);
                return false;
            }
        }
    }
}
