using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class hopdongBLL
    {
        private ContextDB _dbContext;

        public hopdongBLL()
        {
            _dbContext = new ContextDB();
        }

        // C - CREATE: Thêm mới Hợp đồng 
        //Lưu ý: không cần nhập id_hopdong vì đã có hàm tạo id

        // Hàm tự động tạo id cho hợp đồng
        private string GenerateNewHopDongId()
        {
            // Tìm ID Hợp đồng lớn nhất hiện có
            var lastId = _dbContext.hopdongs // Đảm bảo tên DbSet là Hopdongs
                                    .OrderByDescending(h => h.id_hopdong)
                                    .Select(h => h.id_hopdong)
                                    .FirstOrDefault();

            // Định dạng ID:Cxxxxxxxxx
            string prefix = "C"; //Tiền tố
            int numberLength = 9; //Độ dài của hậu tố
            int newNumber = 1; //Hậu tố

            if (lastId != null && lastId.StartsWith(prefix) && lastId.Length == prefix.Length + numberLength)
            {
                // 1. Tách phần số từ hậu tố 
                string numberPart = lastId.Substring(prefix.Length);

                // 2. Chuyển đổi và tăng số
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    // Kiểm tra giới hạn số (để tránh tràn số nếu ID vượt quá 2,147,483,647)
                    if (currentNumber < int.MaxValue)
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

        public bool ThemHopDong(hopdong newHopDong, string id_chutro)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản (Bỏ kiểm tra id_hopdong)
            if (newHopDong == null || string.IsNullOrEmpty(newHopDong.id_phong))
                return false;

            // 2. Xác minh: id_phong trong hợp đồng có thuộc về id_chutro không
            var phongtro = _dbContext.phongtroes.FirstOrDefault(p =>
                p.id_phong == newHopDong.id_phong &&
                p.id_chutro == id_chutro);

            if (phongtro == null)
            {
                return false; // Phòng không thuộc về chủ trọ này
            }

            try
            {
                // 3. TẠO VÀ GÁN ID MỚI TRƯỚC KHI LƯU
                newHopDong.id_hopdong = GenerateNewHopDongId();

                // 4. Thêm và lưu
                _dbContext.hopdongs.Add(newHopDong);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm hợp đồng: " + ex.Message);
                // Lưu ý: Nếu có lỗi DB (ví dụ: khóa chính trùng lặp), 
                // nó sẽ xảy ra ở đây.
                return false;
            }
        }

        // R - READ (ALL): Lấy tất cả Hợp đồng
        public List<hopdong> LayTatCaHopDong(string id_chutro)
        {
            return _dbContext.hopdongs.Where(hd => hd.phongtro.id_chutro == id_chutro)
                                        .ToList();
        }

        // R - READ (ALL): Lấy tất cả Hợp đồng theo Id 
        public hopdong LayHopDongtheoId(string id_hopdong, string id_chutro)
        {
            return _dbContext.hopdongs.
                FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro && 
                                        hd.id_hopdong == id_hopdong);
        }

        // R - READ (ALL): Lấy tất cả Hợp đồng ViewModel
        public List<hopdongViewModel> LayTatCaHopDongViewModel(string idChuTro)
        {
            var query = from hd in _dbContext.hopdongs
                        join pt in _dbContext.phongtroes on hd.id_phong equals pt.id_phong
                        join nt in _dbContext.nguoithues on hd.id_nguoi_thue equals nt.id_nguoi_thue
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

        // U - UPDATE: Cập nhật Hợp đồng
        public bool CapNhatHopDong(hopdong updatedHopDong, string id_chutro)
        {
            if (updatedHopDong == null || string.IsNullOrEmpty(updatedHopDong.id_hopdong))
                return false;
            try
            {
                var existing = _dbContext.hopdongs.FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro
                                                        && hd.id_hopdong == updatedHopDong.id_hopdong);
                if (existing == null) return false;

                // Cập nhật các thuộc tính
                existing.ngay_bat_dau = updatedHopDong.ngay_bat_dau;
                existing.ngay_ket_thuc = updatedHopDong.ngay_ket_thuc;
                existing.tien_coc = updatedHopDong.tien_coc;

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật hợp đồng: " + ex.Message);
                return false;
            }
        }

        // D - DELETE: Xóa Hợp đồng
        public bool XoaHopDong(string id_hopdong, string id_chutro)
        {
            try
            {
                var toDelete = _dbContext.hopdongs.FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro
                                                        && hd.id_hopdong == id_hopdong);
                if (toDelete == null) return false;

                _dbContext.hopdongs.Remove(toDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa hợp đồng: " + ex.Message);
                return false;
            }
        }
    }
}
