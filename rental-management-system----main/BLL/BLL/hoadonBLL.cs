using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.BLL
{
    public class hoadonBLL
    {
        private ContextDB _dbContext;

        public hoadonBLL()
        {
            _dbContext = new ContextDB();
        }

        // C - CREATE: Thêm mới hóa dơn
        //Hàm tự động tạo id
        private string GenerateNewHoaDonId()
        {
            var lastId = _dbContext.hoadons
                                   .OrderByDescending(h => h.id_hoadon)
                                   .Select(h => h.id_hoadon)
                                   .FirstOrDefault();

            string prefix = "B";
            int numberLength = 9; // 8 chữ số sau HD
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
                        // Xử lý khi ID đạt giới hạn
                        throw new OverflowException("ID Hóa đơn đã đạt giới hạn tối đa.");
                    }
                }
            }
            return prefix + newNumber.ToString($"D{numberLength}");
        }

        public bool ThemHoaDon(hoadon newHoaDon, dien newDien, nuoc newNuoc, lephi newLePhi, string id_chutro)
        {
            if (newHoaDon == null || newDien == null || newNuoc == null || newLePhi == null) return false;

            // LỖI LOGIC ĐÃ SỬA: Kiểm tra xem id_phong trong hóa đơn có thuộc id_chutro không
            var phongTro = _dbContext.phongtroes // Sửa tên DbSet (Giả định là Phongtros)
                                     .FirstOrDefault(p =>
                                         p.id_phong == newHoaDon.id_phong && // Xác minh phòng cụ thể
                                         p.id_chutro == id_chutro);          // Xác minh quyền sở hữu

            if (phongTro == null) return false; // Không có quyền tạo Hóa đơn cho phòng này

            using (var transaction = new TransactionScope())
            {
                try
                {
                    // A. Thêm các chi tiết (ID tự động tăng nếu có)
                    // Sử dụng tên DbSet số nhiều (ví dụ: Diens, Nuocs, Lephis)
                    _dbContext.diens.Add(newDien);
                    _dbContext.nuocs.Add(newNuoc);
                    _dbContext.lephis.Add(newLePhi);
                    _dbContext.SaveChanges();

                    // B. Gán ID chi tiết vào Hóa đơn (ID này có thể là tự động tăng hoặc do người dùng cung cấp)
                    newHoaDon.id_dien = newDien.id_dien;
                    newHoaDon.id_nuoc = newNuoc.id_nuoc;
                    newHoaDon.id_lephi = newLePhi.id_lephi;

                    // C. TẠO VÀ GÁN ID HÓA ĐƠN MỚI
                    newHoaDon.id_hoadon = GenerateNewHoaDonId();

                    // D. Thêm Hóa đơn
                    _dbContext.hoadons.Add(newHoaDon);
                    _dbContext.SaveChanges();

                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi tạo hóa đơn và chi tiết: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ALL): Lấy tất cả hóa đơn
        public List<hoadon> LayTatCaHoaDon(string id_chutro)
        {
            return _dbContext.hoadons.Where(hd => hd.phongtro.id_chutro == id_chutro)
                                        .ToList();
        }

        // R - READ (ALL): Lấy tất cả hóa đơn theo id
        public hoadon LayHoaDonTheoId(string id_chutro, string id_hoadon)
        {
            return _dbContext.hoadons.FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro
                                                                        && hd.id_hoadon == id_hoadon);
        }

        public bool CapNhatHoaDon(hoadon updatedHoaDon, dien updatedDien, nuoc updatedNuoc, lephi updatedLePhi, string id_chutro)
        {
            if (updatedHoaDon == null) return false;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    // 1. Tìm bản ghi Hóa đơn 
                    var existingHoaDon = _dbContext.hoadons
                                                 .Include(h => h.phongtro) // Cần Include để lọc theo id_chutro
                                                 .FirstOrDefault(h => h.id_hoadon == updatedHoaDon.id_hoadon &&
                                                                      h.phongtro.id_chutro == id_chutro);
                    if (existingHoaDon == null) return false;

                    // 2. Cập nhật Hóa đơn
                    existingHoaDon.ngay_tao = updatedHoaDon.ngay_tao;
                    existingHoaDon.thanh_tien = updatedHoaDon.thanh_tien;
                    existingHoaDon.trang_thai = updatedHoaDon.trang_thai;
                    existingHoaDon.noi_dung = updatedHoaDon.noi_dung;
                    // 3. Tìm và cập nhật các chi tiết (Sử dụng FK từ Hóa đơn gốc)

                    // Cập nhật Điện
                    var existingDien = _dbContext.diens.Find(existingHoaDon.id_dien);
                    if (existingDien != null)
                    {
                        existingDien.ngay_tao = updatedDien.ngay_tao;
                        existingDien.chi_so_dau = updatedDien.chi_so_dau;
                        existingDien.chi_so_cuoi = updatedDien.chi_so_cuoi;
                        existingDien.thanh_tien_dien = updatedDien.thanh_tien_dien;
                    }

                    // Cập nhật Nước
                    var existingNuoc = _dbContext.nuocs.Find(existingHoaDon.id_nuoc);
                    if (existingNuoc != null)
                    {
                        existingNuoc.ngay_tao = updatedNuoc.ngay_tao;
                        existingNuoc.chi_so_dau = updatedNuoc.chi_so_dau;
                        existingNuoc.chi_so_cuoi = updatedNuoc.chi_so_cuoi;
                        existingNuoc.thanh_tien_nuoc = updatedNuoc.thanh_tien_nuoc;
                    }

                    // Cập nhật Lệ phí
                    var existingLePhi = _dbContext.lephis.Find(existingHoaDon.id_lephi);
                    if (existingLePhi != null)
                    {
                        existingLePhi.tenphong = updatedLePhi.tenphong;
                        existingLePhi.tien_dv = updatedLePhi.tien_dv;
                        existingLePhi.thanh_tien_lephi = updatedLePhi.thanh_tien_lephi;
                    }

                    _dbContext.SaveChanges();
                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("không thể cập nhập hóa đơn. Lỗi " + ex.Message);
                    return false;
                }
            }
        }

        // D - DELETE: Xóa Hóa Đơn
        public bool XoaHoaDon(string id_hoadon, string id_chutro)
        {
            // Bắt đầu Transaction Scope để đảm bảo Rollback nếu có lỗi
            using (var transaction = new TransactionScope())
            {
                try
                {
                    // 1. TÌM VÀ XÁC MINH QUYỀN SỞ HỮU
                    // Cần Include PhongTro để truy vấn id_chutro và đảm bảo Hóa đơn thuộc về chủ trọ này
                    var existingHoaDon = _dbContext.hoadons // Sửa tên DbSet
                                                 .Include(h => h.phongtro)
                                                 .FirstOrDefault(h => h.id_hoadon == id_hoadon &&
                                                                      h.phongtro.id_chutro == id_chutro);
                    if (existingHoaDon == null) return false; // Không tìm thấy hoặc không có quyền

                    // 2. TÌM CÁC BẢN GHI CON DỰA TRÊN FOREIGN KEY
                    // Sử dụng ID từ Hóa đơn vừa tìm được
                    var dienToDelete = _dbContext.diens.Find(existingHoaDon.id_dien);
                    var nuocToDelete = _dbContext.nuocs.Find(existingHoaDon.id_nuoc);
                    var lePhiToDelete = _dbContext.lephis.Find(existingHoaDon.id_lephi);

                    // 3. XÓA CÁC BẢN GHI CON TRƯỚC
                    if (dienToDelete != null)
                    {
                        _dbContext.diens.Remove(dienToDelete);
                    }
                    if (nuocToDelete != null)
                    {
                        _dbContext.nuocs.Remove(nuocToDelete);
                    }
                    if (lePhiToDelete != null)
                    {
                        _dbContext.lephis.Remove(lePhiToDelete);
                    }

                    // 4. XÓA BẢN GHI CHA
                    _dbContext.hoadons.Remove(existingHoaDon);

                    // 5. LƯU TẤT CẢ THAY ĐỔI
                    _dbContext.SaveChanges();

                    // 6. HOÀN TẤT TRANSACTION
                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có bất kỳ lỗi nào, Transaction Scope sẽ tự động Rollback
                    Console.WriteLine("Lỗi xóa hóa đơn và chi tiết: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
