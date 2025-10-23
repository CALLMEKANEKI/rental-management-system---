using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.BLL
{
    public class chutroBLL
    {
        // Khởi tạo ContextDB
        private ContextDB _dbContext;

        public chutroBLL()
        {
            _dbContext = new ContextDB(); // Tạo ContextDB instance
        }

        private string GenerateNewChuTroId()
        {
            // Lấy tất cả ID hiện tại trong DB
            var existingIds = _dbContext.chutroes.Select(c => c.id_chutro).ToList();

            int maxNumber = 0;
            foreach (var id in existingIds)
            {
                if (id.StartsWith("CT") && int.TryParse(id.Substring(2), out int num))
                {
                    if (num > maxNumber) maxNumber = num;
                }
            }

            // Tăng 1 để tạo ID mới
            int newNumber = maxNumber + 1;
            return $"CT{newNumber:D8}"; // CT00000001
        }


        
        public bool ThemChutro(chutro newChutro)
        {
            try
            {
                // Tạo ID mới nếu chưa có
                if (string.IsNullOrEmpty(newChutro.id_chutro))
                {
                    newChutro.id_chutro = GenerateNewChuTroId();
                }

                // Nếu email hoặc sdt trống → gán giá trị tạm
                if (string.IsNullOrWhiteSpace(newChutro.email))
                    newChutro.email = $"noemail_{Guid.NewGuid()}@example.com";
                if (string.IsNullOrWhiteSpace(newChutro.sdt))
                    newChutro.sdt = $"000{new Random().Next(1000000, 9999999)}";

                // Kiểm tra trùng username, email, sdt
                if (_dbContext.chutroes.Any(c => c.taikhoan == newChutro.taikhoan))
                    throw new Exception($"Username '{newChutro.taikhoan}' da ton tai!");
                if (_dbContext.chutroes.Any(c => c.email == newChutro.email))
                    throw new Exception($"Email '{newChutro.email}' da ton tai!");
                if (_dbContext.chutroes.Any(c => c.sdt == newChutro.sdt))
                    throw new Exception($"SĐT '{newChutro.sdt}' da ton tai!");

                // Thêm vào database
                _dbContext.chutroes.Add(newChutro);
                _dbContext.SaveChanges();
                Console.WriteLine("Them chutro thanh cong: " + newChutro.id_chutro);
                return true;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Chi tiet loi: " + ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                        Console.WriteLine("Chi tiet loi 2: " + ex.InnerException.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("Loi khi them chutro: " + ex.Message);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi them chutro: " + ex.Message);
                return false;
            }
        }





        // R - READ (ALL): Lấy tất cả Chủ Trọ
        public List<chutro> LayTatCaChutro()
        {
            return _dbContext.chutroes.ToList();
        }

        // R - READ (BY ID): Lấy Chủ Trọ theo ID
        public chutro LayChutroTheoId(string id)
        {
            return _dbContext.chutroes.FirstOrDefault(ct => ct.id_chutro == id);
        }

        // R - READ (BY ID): Lấy Chủ Trọ theo tên tài khoản
        public chutro LayChutroTheoUserName(string username)
        {
            return _dbContext.chutroes.FirstOrDefault(ct => ct.taikhoan == username);
        }

        // U - UPDATE: Cập nhật thông tin Chủ Trọ
        public bool CapNhatChutro(chutro updatedChutro)
        {
            if (updatedChutro == null || updatedChutro.id_chutro == "0")
            {
                return false;
            }

            try
            {
                var existingChutro = _dbContext.chutroes.Find(updatedChutro.id_chutro);

                if (existingChutro == null)
                {
                    return false; // Không tìm thấy để cập nhật
                }

                // Cập nhật các thuộc tính
                existingChutro.sdt = updatedChutro.sdt;
                existingChutro.hoten = updatedChutro.hoten;
                existingChutro.email = updatedChutro.email;
                existingChutro.diachi = updatedChutro.diachi;
                existingChutro.taikhoan = updatedChutro.taikhoan;
                // Không nên cập nhật mật khẩu ở đây, nên có phương thức riêng
                existingChutro.avatar_url = updatedChutro.avatar_url;
                existingChutro.anh_cccd_truoc_url = updatedChutro.anh_cccd_truoc_url;
                existingChutro.anh_cccd_sau_url = updatedChutro.anh_cccd_sau_url;

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể cập nhật chủ trọ. LỖi: " + ex.Message);
                return false;
            }
        }

        // D - DELETE: Xóa Chủ Trọ
        public bool XoaChutro(string id_chutro)
        {
            try
            {
                var chutroToDelete = _dbContext.chutroes.Find(id_chutro);
                if (chutroToDelete == null)
                    return false;

                _dbContext.chutroes.Remove(chutroToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể xóa chủ trọ. Lỗi: " + ex.Message);
                return false;
            }
        }
    }
}
