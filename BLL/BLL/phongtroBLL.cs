using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class phongtroBLL
    {
        private ContextDB _dbContext;

        public phongtroBLL()
        {
            _dbContext = new ContextDB();
        }

        // C - CREATE: Thêm mới Phòng Trọ
        // Hàm khởi tạo id
        private string GenerateNewPhongTroId()
        {
            // Cố gắng tìm ID Phòng Trọ lớn nhất hiện có
            var lastId = _dbContext.phongtroes // Giả định tên DbSet là Phongtros
                                   .OrderByDescending(p => p.id_phong)
                                   .Select(p => p.id_phong)
                                   .FirstOrDefault();

            string prefix = "R";
            int numberLength = 9; // 8 chữ số sau PT
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
        public bool ThemPhongTro(phongtro newPhongTro, string id_chutro)
        {
            // Kiểm tra dữ liệu đầu vào cơ bản (chỉ cần kiểm tra đối tượng có null không)
            if (newPhongTro == null) return false;

            // 1. TẠO VÀ GÁN ID MỚI TRƯỚC KHI LƯU
            newPhongTro.id_phong = GenerateNewPhongTroId();

            // 2. Bắt buộc: Gán ID chủ trọ
            newPhongTro.id_chutro = id_chutro; // Sửa tên tham số để dễ hiểu hơn

            try
            {
                _dbContext.phongtroes.Add(newPhongTro); // Giả định tên DbSet là Phongtros
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể thêm phòng mới. Lỗi: " + ex.Message);
                return false;
            }
        }


        public List<phongtroViewModel> LayTatCaPhongTroViewModel(string id_chutro)
        {
            return _dbContext.phongtroes
                             .Where(p => p.id_chutro == id_chutro) // Lọc theo id_chutro
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

        // R - READ (ALL): Lấy tất cả Phòng Trọ
        public List<phongtro> LayTatCaPhongTro(string id_chutro)
        {
            return _dbContext.phongtroes
                             .Where(p => p.id_chutro == id_chutro) // Lọc theo id_chutro
                             .ToList();
        }

        // R - READ (BY ID): Lấy Phòng Trọ theo ID
        public phongtro LayPhongTroTheoId(string id_phong, string id_chutro)
        {
            // Kết hợp Find và lọc quyền sở hữu
            return _dbContext.phongtroes
                             .FirstOrDefault(p => p.id_phong == id_phong &&
                                                  p.id_chutro == id_chutro);
        }

        // U - UPDATE: Cập nhật thông tin Phòng Trọ
        public bool CapNhatPhongTro(phongtro updatedPhong, string id_chutro)
        {
            try
            {
                var existing = _dbContext.phongtroes
                                .FirstOrDefault(p => p.id_phong == updatedPhong.id_phong &&
                                                  p.id_chutro == id_chutro);
                if (existing == null) return false;

                existing.tenphong = updatedPhong.tenphong;
                existing.giaphong = updatedPhong.giaphong;
                existing.tinhtrang = updatedPhong.tinhtrang;
                // Khóa ngoại id_chutro có thể cần logic kiểm tra trước khi cập nhật

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể cập nhật phòng mới. Lỗi: " + ex.Message);
                return false;
            }
        }

        // D - DELETE: Xóa Phòng Trọ
        public bool XoaPhongTro(string id_phongtro, string id_chutro)
        {
            try
            {
                var phongToDelete = _dbContext.phongtroes.
                                                FirstOrDefault(p => p.id_phong == id_phongtro &&
                                                  p.id_chutro == id_chutro);
                if (phongToDelete == null) return false;

                _dbContext.phongtroes.Remove(phongToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể xóa phòng. Lỗi: " + ex.Message);
                return false;
            }
        }
        public bool TraPhong(string id_phong, string id_chutro)
        {
            try
            {
                var phong = _dbContext.phongtroes
                                      .FirstOrDefault(p => p.id_phong == id_phong && p.id_chutro == id_chutro);
                if (phong == null)
                    return false;

                phong.tinhtrang = "Trống";
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể trả phòng. Lỗi: " + ex.Message);
                return false;
            }
        }



        // Nghiệp vụ đặc thù: Tìm Phòng Trống
        // Thêm tham số id_chutro vào BLL
        public List<phongtro> TimPhongTrong(string id_chutro)
        {
            return _dbContext.phongtroes
                .Where(p => p.tinhtrang.ToLower().Contains("trong") && p.id_chutro == id_chutro)
                .ToList();
        }



    }
}
