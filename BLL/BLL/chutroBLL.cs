using DAL.Model;
using System;
using System.Collections.Generic;
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

        // C - CREATE: Thêm mới Chủ Trọ
        //Hàm tự khởi taỌ ID
        private string GenerateNewChuTroId()
        {
            // Cố gắng tìm ID Chủ trọ lớn nhất hiện có
            var lastId = _dbContext.chutroes // Giả định tên DbSet là Chutros
                                   .OrderByDescending(ct => ct.id_chutro)
                                   .Select(ct => ct.id_chutro)
                                   .FirstOrDefault();

            string prefix = "A";
            int numberLength = 9; // 8 chữ số sau CT
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
                        throw new OverflowException("ID Chủ trọ đã đạt giới hạn tối đa.");
                    }
                }
            }
            // Định dạng số thành chuỗi với số 0 đệm
            return prefix + newNumber.ToString($"D{numberLength}");
        }
        public bool ThemChutro(chutro newChutro)
        {
            if (newChutro == null)
            {
                return false;
            }

            try
            {
                // 1. TẠO VÀ GÁN ID MỚI TRƯỚC KHI LƯU
                newChutro.id_chutro = GenerateNewChuTroId();

                // 2. Thêm và lưu
                _dbContext.chutroes.Add(newChutro); // Giả định tên DbSet là Chutros
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể thêm chủ trọ mới. LỖi: " + ex.Message);
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
                {
                    return false; // Không tìm thấy để xóa
                }

                _dbContext.chutroes.Remove(chutroToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể xóa chủ trọ. LỖi: " + ex.Message);
                return false;
            }
        }
    }
}
