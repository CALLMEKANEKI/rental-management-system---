using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;

namespace BLL.BLL
{
    public class hoadonBLL
    {

        // Hàm tự động tạo id (Đã sửa để nhận Context)
        private string GenerateNewHoaDonId(ContextDB dbContext)
        {
            var lastId = dbContext.hoadons
                                 .OrderByDescending(h => h.id_hoadon)
                                 .Select(h => h.id_hoadon)
                                 .FirstOrDefault();

            string prefix = "B";
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
                        throw new OverflowException("ID Hóa đơn đã đạt giới hạn tối đa.");
                    }
                }
            }
            return prefix + newNumber.ToString($"D{numberLength}");
        }

        // C - CREATE: Thêm mới hóa dơn
        public bool ThemHoaDon(hoadon newHoaDon, dien newDien, nuoc newNuoc, lephi newLePhi, string id_chutro)
        {
            if (newHoaDon == null || newDien == null || newNuoc == null || newLePhi == null) return false;

            using (var transaction = new TransactionScope())
            using (var dbContext = new ContextDB()) // SỬ DỤNG CONTEXT CỤC BỘ TRONG TRANSACTION
            {
                // Kiểm tra quyền sở hữu phòng trọ
                var phongTro = dbContext.phongtroes
                                         .FirstOrDefault(p =>
                                            p.id_phong == newHoaDon.id_phong &&
                                            p.id_chutro == id_chutro);

                if (phongTro == null) return false;

                try
                {
                    // A. Thêm các chi tiết
                    dbContext.diens.Add(newDien);
                    dbContext.nuocs.Add(newNuoc);
                    dbContext.lephis.Add(newLePhi);
                    dbContext.SaveChanges(); // Lấy ID tự động tăng cho chi tiết

                    // B. Gán ID chi tiết vào Hóa đơn
                    newHoaDon.id_dien = newDien.id_dien;
                    newHoaDon.id_nuoc = newNuoc.id_nuoc;
                    newHoaDon.id_lephi = newLePhi.id_lephi;

                    // C. TẠO VÀ GÁN ID HÓA ĐƠN MỚI
                    newHoaDon.id_hoadon = GenerateNewHoaDonId(dbContext);

                    // D. Thêm Hóa đơn
                    dbContext.hoadons.Add(newHoaDon);
                    dbContext.SaveChanges();

                    transaction.Complete();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Thêm Hóa đơn): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi tạo hóa đơn và chi tiết: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ALL): Lấy tất cả hóa đơn (Entity)
        public List<hoadon> LayTatCaHoaDon(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                // Cần Include PhongTro để lọc theo id_chutro
                return dbContext.hoadons
                                .Include(hd => hd.phongtro)
                                .Where(hd => hd.phongtro.id_chutro == id_chutro)
                                .ToList();
            }
        }

        // R - READ (ALL): Lấy tất cả hóa đơn theo id (Entity)
        public hoadon LayHoaDonTheoId(string id_chutro, string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.hoadons
                                .Include(hd => hd.phongtro) // Cần Include để lọc theo id_chutro
                                .FirstOrDefault(hd => hd.phongtro.id_chutro == id_chutro
                                                       && hd.id_hoadon == id_hoadon);
            }
        }

        // Phương thức nội bộ tạo Queryable (Đã sửa để nhận Context)
        private IQueryable<hoadonViewModel> GetHoaDonQuery(ContextDB dbContext, string id_chutro)
        {
            // Sử dụng INNER JOIN cho tất cả các bảng.
            var query = from hd in dbContext.hoadons
                        join pt in dbContext.phongtroes on hd.id_phong equals pt.id_phong
                        join d in dbContext.diens on hd.id_dien equals d.id_dien
                        join n in dbContext.nuocs on hd.id_nuoc equals n.id_nuoc
                        join lp in dbContext.lephis on hd.id_lephi equals lp.id_lephi

                        where pt.id_chutro == id_chutro

                        select new hoadonViewModel
                        {
                            IDHoaDon = hd.id_hoadon,
                            NgayTao = hd.ngay_tao,
                            TrangThai = hd.trang_thai,
                            NoiDung = hd.noi_dung,
                            ThanhTien = hd.thanh_tien,

                            TenPhong = pt.tenphong,

                            ChiSoDien_Dau = d.chi_so_dau,
                            ChiSoDien_Cuoi = d.chi_so_cuoi,
                            ThanhTien_Dien = d.thanh_tien_dien,

                            ChiSoNuoc_Dau = n.chi_so_dau,
                            ChiSoNuoc_Cuoi = n.chi_so_cuoi,
                            ThanhTien_Nuoc = n.thanh_tien_nuoc,

                            Tien_dv = lp.tien_dv,
                            Tien_Phong = lp.tien_phong,
                        };

            return query;
        }

        // R - READ (ALL): Lấy tất cả hóa đơn ViewModel 
        public List<hoadonViewModel> LayTatCaHoaDonViewModel(string idChuTro)
        {
            using (var dbContext = new ContextDB())
            {
                return GetHoaDonQuery(dbContext, idChuTro).ToList();
            }
        }

        // R - READ (ALL): Lấy Hóa đơn theo ID 
        public hoadonViewModel LayHoaDonViewModelTheoID(string id_hoadon, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                return GetHoaDonQuery(dbContext, id_chutro)
                            .FirstOrDefault(hd => hd.IDHoaDon == id_hoadon);
            }
        }

        // R - READ (ALL): Lấy Hóa đơn theo keywork
        public List<hoadonViewModel> LayTatCaHoaDonViewModelTheoKeywork(string keyword, string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                string searchKeyword = (keyword ?? string.Empty).ToLower();

                var query = GetHoaDonQuery(dbContext, id_chutro);

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(hd =>
                        hd.IDHoaDon.ToLower().Contains(searchKeyword) ||
                        hd.TenPhong.ToLower().Contains(searchKeyword) ||
                        hd.TrangThai.ToLower().Contains(searchKeyword) ||
                        hd.NgayTao.ToString().ToLower().Contains(searchKeyword)
                    );
                }

                return query.ToList();
            }
        }

        // R - READ (ALL): Lấy Hóa đơn chưa thanh toán
        public List<hoadonViewModel> LayHoaDonChuaThanhToan(string id_chutro)
        {
            using (var dbContext = new ContextDB())
            {
                var query = GetHoaDonQuery(dbContext, id_chutro);

                query = query.Where(hd => hd.TrangThai == "Chưa thanh toán");

                return query.ToList();
            }
        }

        // U - Update: Cập nhật hóa đơn
        public bool CapNhatHoaDon(hoadon updatedHoaDon, dien updatedDien, nuoc updatedNuoc, lephi updatedLePhi, string id_chutro)
        {
            if (updatedHoaDon == null) return false;

            using (var transaction = new TransactionScope())
            using (var dbContext = new ContextDB()) // SỬ DỤNG CONTEXT CỤC BỘ TRONG TRANSACTION
            {
                try
                {
                    // 1. Tìm bản ghi Hóa đơn và xác minh quyền sở hữu
                    var existingHoaDon = dbContext.hoadons
                                                     .Include(h => h.phongtro)
                                                     .FirstOrDefault(h => h.id_hoadon == updatedHoaDon.id_hoadon &&
                                                                          h.phongtro.id_chutro == id_chutro);
                    if (existingHoaDon == null) return false;

                    // 2. Cập nhật Hóa đơn
                    existingHoaDon.ngay_tao = updatedHoaDon.ngay_tao;
                    existingHoaDon.thanh_tien = updatedHoaDon.thanh_tien;
                    existingHoaDon.trang_thai = updatedHoaDon.trang_thai;
                    existingHoaDon.noi_dung = updatedHoaDon.noi_dung;
                    existingHoaDon.id_phong = updatedHoaDon.id_phong;
                    existingHoaDon.id_dien = updatedHoaDon.id_dien;
                    existingHoaDon.id_nuoc = updatedHoaDon.id_nuoc;
                    existingHoaDon.id_lephi = updatedHoaDon.id_lephi;   

                    // 3. Tìm và cập nhật các chi tiết (Sử dụng FK từ Hóa đơn gốc)

                    // Cập nhật Điện
                    var existingDien = dbContext.diens.Find(existingHoaDon.id_dien);
                    if (existingDien != null)
                    {
                        existingDien.ngay_tao = updatedDien.ngay_tao;
                        existingDien.chi_so_dau = updatedDien.chi_so_dau;
                        existingDien.chi_so_cuoi = updatedDien.chi_so_cuoi;
                        existingDien.thanh_tien_dien = updatedDien.thanh_tien_dien;
                    }

                    // Cập nhật Nước
                    var existingNuoc = dbContext.nuocs.Find(existingHoaDon.id_nuoc);
                    if (existingNuoc != null)
                    {
                        existingNuoc.ngay_tao = updatedNuoc.ngay_tao;
                        existingNuoc.chi_so_dau = updatedNuoc.chi_so_dau;
                        existingNuoc.chi_so_cuoi = updatedNuoc.chi_so_cuoi;
                        existingNuoc.thanh_tien_nuoc = updatedNuoc.thanh_tien_nuoc;
                    }

                    // Cập nhật Lệ phí
                    var existingLePhi = dbContext.lephis.Find(existingHoaDon.id_lephi);
                    if (existingLePhi != null)
                    {
                        existingLePhi.ngay_tao = updatedLePhi.ngay_tao;
                        existingLePhi.tien_phong = updatedLePhi.tien_phong;
                        existingLePhi.tien_dv = updatedLePhi.tien_dv;
                        existingLePhi.thanh_tien_lephi = updatedLePhi.thanh_tien_lephi;
                    }

                    dbContext.SaveChanges();
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
            using (var transaction = new TransactionScope())
            using (var dbContext = new ContextDB()) // SỬ DỤNG CONTEXT CỤC BỘ TRONG TRANSACTION
            {
                try
                {
                    // 1. TÌM VÀ XÁC MINH QUYỀN SỞ HỮU
                    var existingHoaDon = dbContext.hoadons
                                                     .Include(h => h.phongtro)
                                                     .FirstOrDefault(h => h.id_hoadon == id_hoadon &&
                                                                          h.phongtro.id_chutro == id_chutro);
                    if (existingHoaDon == null) return false;

                    // 2. TÌM CÁC BẢN GHI CON
                    var dienToDelete = dbContext.diens.Find(existingHoaDon.id_dien);
                    var nuocToDelete = dbContext.nuocs.Find(existingHoaDon.id_nuoc);
                    var lePhiToDelete = dbContext.lephis.Find(existingHoaDon.id_lephi);

                    // 3. XÓA CÁC BẢN GHI CON TRƯỚC
                    if (dienToDelete != null)
                    {
                        dbContext.diens.Remove(dienToDelete);
                    }
                    if (nuocToDelete != null)
                    {
                        dbContext.nuocs.Remove(nuocToDelete);
                    }
                    if (lePhiToDelete != null)
                    {
                        dbContext.lephis.Remove(lePhiToDelete);
                    }

                    // 4. XÓA BẢN GHI CHA
                    dbContext.hoadons.Remove(existingHoaDon);

                    // 5. LƯU TẤT CẢ THAY ĐỔI
                    dbContext.SaveChanges();

                    // 6. HOÀN TẤT TRANSACTION
                    transaction.Complete();
                    return true;
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine("Lỗi DB (Xóa Hóa đơn): " + dbEx.InnerException?.Message ?? dbEx.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi xóa hóa đơn và chi tiết: " + ex.Message);
                    return false;
                }
            }
        }
    }
}