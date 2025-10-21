using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.BLL
{
    public class thanhtoanBLL
    {
         ContextDB _dbContext = new ContextDB();

        // C - CREATE: Thêm mới Thanh toán
        public bool ThemThanhToan(thanh_toan newThanhToan, string id_chutro)
        {
            // Kiểm tra tính hợp lệ của Khóa chính kép
            if (newThanhToan == null || string.IsNullOrEmpty(newThanhToan.id_hoadon) || string.IsNullOrEmpty(newThanhToan.id_nguoi_thue))
                return false;

            // Lọc quyền: Kiểm tra Hóa đơn có thuộc quyền sở hữu của Chủ trọ này không.
            var hoadon = _dbContext.hoadons
                                   .Include(h => h.phongtro)
                                   .FirstOrDefault(h =>
                                        h.id_hoadon == newThanhToan.id_hoadon &&
                                        h.phongtro.id_chutro == id_chutro);

            if (hoadon == null) return false;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    // 1. Thêm bản ghi Thanh toán
                    _dbContext.thanh_toan.Add(newThanhToan);

                    // 2. Cập nhật trạng thái Hóa đơn
                    hoadon.trang_thai = "Đã thanh toán";
                    _dbContext.SaveChanges(); // Lưu cả 2 thay đổi cùng lúc
                    transaction.Complete(); // Commit transaction
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi thêm Thanh toán: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ (ALL/FILTER): Lấy tất cả Thanh toán theo Chủ trọ (Không đổi)
        public List<thanh_toan> LayTatCaThanhToan(string id_chutro)
        {
            return _dbContext.thanh_toan
                .Where(tt => tt.hoadon.phongtro.id_chutro == id_chutro)
                .Include(tt => tt.hoadon)
                .Include(tt => tt.nguoi_thue)
                .ToList();
        }

        // R - READ (BY ID): Sử dụng cặp khóa chính kép (hoadonId, nguoithueId)
        public thanh_toan LayThanhToanTheoId(string id_hoadon, string id_nguoithue, string id_chutro)
        {
            return _dbContext.thanh_toan
                             .Include(tt => tt.hoadon)
                             .FirstOrDefault(tt => tt.id_hoadon == id_hoadon &&
                                                  tt.id_nguoi_thue == id_nguoithue &&
                                                  tt.hoadon.phongtro.id_chutro == id_chutro);
        }

        // U - UPDATE: Cập nhật Thanh toán
        public bool CapNhatThanhToan(thanh_toan updatedThanhToan, string id_chutro)
        {
            if (updatedThanhToan == null) return false;

            // 1. Tìm bản ghi gốc và xác minh quyền
            var existing = _dbContext.thanh_toan
                                     .Include(tt => tt.hoadon)
                                     .FirstOrDefault(tt => tt.id_hoadon == updatedThanhToan.id_hoadon &&
                                                          tt.id_nguoi_thue == updatedThanhToan.id_nguoi_thue &&
                                                          tt.hoadon.phongtro.id_chutro == id_chutro);
            if (existing == null) return false;

            try
            {
                // 2. Cập nhật các thuộc tính
                existing.ngay_thanh_toan = updatedThanhToan.ngay_thanh_toan;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Lỗi cập nhật Thanh toán: " + ex.Message);
                return false;
            }
        }

        // D - DELETE: Xóa Thanh toán
        public bool XoaThanhToan(string id_hoadon, string id_nguoithue, string id_chutro)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    // 1. Tìm và xác minh quyền
                    var toDelete = _dbContext.thanh_toan
                                             .Include(tt => tt.hoadon)
                                             .FirstOrDefault(tt => tt.id_hoadon == id_hoadon &&
                                                                  tt.id_nguoi_thue == id_nguoithue &&
                                                                  tt.hoadon.phongtro.id_chutro == id_chutro);
                    if (toDelete == null) return false;

                    // 2. Cập nhật trạng thái Hóa đơn về "Chưa TT"
                    var hoadon = toDelete.hoadon;
                    if (hoadon != null)
                    {
                        hoadon.trang_thai = "Chưa thanh toán";
                        _dbContext.Entry(hoadon).State = EntityState.Modified;
                    }

                    // 3. Xóa Thanh toán
                    _dbContext.thanh_toan.Remove(toDelete);

                    _dbContext.SaveChanges();
                    transaction.Complete();
                    return true;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Lỗi cập nhật Thanh toán: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
