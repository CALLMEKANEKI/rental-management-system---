using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace BLL.BLL
{
    public class thanhtoanBLL
    {
        // C - CREATE: Thêm mới Thanh toán (Giữ nguyên)
        public bool ThemThanhToan(thanh_toan newThanhToan, string id_chutro)
        {
            if (newThanhToan == null || string.IsNullOrEmpty(newThanhToan.id_hoadon) || string.IsNullOrEmpty(newThanhToan.id_nguoi_thue))
                return false;

            using (var transaction = new TransactionScope())
            using (var dbContext = new ContextDB())
            {
                var hoadon = dbContext.hoadons.Include(h => h.phongtro).FirstOrDefault(h =>
                                         h.id_hoadon == newThanhToan.id_hoadon &&
                                         h.phongtro.id_chutro == id_chutro);

                if (hoadon == null || hoadon.trang_thai == "Đã thanh toán") return false;

                try
                {
                    dbContext.thanh_toan.Add(newThanhToan);
                    hoadon.trang_thai = "Đã thanh toán";
                    dbContext.Entry(hoadon).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi thêm Thanh toán: " + ex.Message);
                    return false;
                }
            }
        }

        // R - READ : Lấy tất cả thanh toán ViewModel   
        public List<thanhToanViewModel> GetLichSuThanhToan(string id_chutro, string keyword = null)
        {
            using (var dbContext = new ContextDB())
            {
                var query = from tt in dbContext.thanh_toan
                            join hd in dbContext.hoadons on tt.id_hoadon equals hd.id_hoadon
                            join nt in dbContext.nguoithues on tt.id_nguoi_thue equals nt.id_nguoi_thue
                            join pt in dbContext.phongtroes on hd.id_phong equals pt.id_phong

                            where pt.id_chutro == id_chutro

                            select new thanhToanViewModel
                            {
                                MaHD = hd.id_hoadon,
                                NgayTao = hd.ngay_tao,
                                NoiDung = hd.noi_dung,
                                LePhi = hd.lephi.thanh_tien_lephi,
                                TienDien = hd.dien.thanh_tien_dien,
                                TienNuoc = hd.nuoc.thanh_tien_nuoc,
                                ThanhTien = hd.thanh_tien,
                                NgayThanhToan = tt.ngay_thanh_toan,
                                TenNguoiThanhToan = nt.hoten,
                                TenPhong = pt.tenphong
                                // ĐÃ BỎ: IDNguoiThue = nt.id_nguoi_thue
                            };

                if (!string.IsNullOrEmpty(keyword))
                {
                    string searchKeyword = keyword.Trim().ToLower();
                    query = query.Where(x =>
                        x.MaHD.ToLower().Contains(searchKeyword) ||
                        x.TenNguoiThanhToan.ToLower().Contains(searchKeyword) ||
                        x.TenPhong.ToLower().Contains(searchKeyword)
                    );
                }

                return query.OrderByDescending(x => x.NgayThanhToan).ToList();
            }
        }

        // U - UPDATE: Cập nhật Thanh toán 
        public bool CapNhatThanhToan(
            string id_hoadon_goc,
            string id_nguoithue_goc,
            string new_id_nguoi_thue,
            DateTime new_ngay_thanh_toan,
            string id_chutro)
        {
            if (string.IsNullOrEmpty(id_hoadon_goc) || string.IsNullOrEmpty(id_nguoithue_goc)) return false;

            using (var transaction = new TransactionScope())
            using (var dbContext = new ContextDB())
            {
                try
                {
                    // 1. Tìm bản ghi GỐC bằng cặp khóa chính cũ
                    var existing = dbContext.thanh_toan
                                            .Include(tt => tt.hoadon.phongtro)
                                            .FirstOrDefault(tt => tt.id_hoadon == id_hoadon_goc &&
                                                                   tt.id_nguoi_thue == id_nguoithue_goc &&
                                                                   tt.hoadon.phongtro.id_chutro == id_chutro);
                    if (existing == null) return false;

                    // 2. Xử lý Sửa
                    if (existing.id_nguoi_thue != new_id_nguoi_thue)
                    {
                        dbContext.thanh_toan.Remove(existing);

                        var newThanhToan = new thanh_toan
                        {
                            id_hoadon = id_hoadon_goc,
                            id_nguoi_thue = new_id_nguoi_thue,
                            ngay_thanh_toan = new_ngay_thanh_toan,
                        };
                        dbContext.thanh_toan.Add(newThanhToan);
                    }
                    else
                    {
                        existing.ngay_thanh_toan = new_ngay_thanh_toan;
                        dbContext.Entry(existing).State = EntityState.Modified;
                    }

                    dbContext.SaveChanges();
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

        // D - DELETE: Xóa Thanh toán 
        public bool XoaThanhToan(string id_hoadon, string id_chutro)
        {
            using (var transaction = new TransactionScope())
            using (var dbContext = new ContextDB())
            {
                try
                {
                    // 1. Tìm bản ghi bằng CẶP KHÓA CHÍNH
                    var toDelete = dbContext.thanh_toan
                                             .Include(tt => tt.hoadon.phongtro)
                                             .Include(tt => tt.hoadon)
                                             .FirstOrDefault(tt => tt.id_hoadon == id_hoadon &&
                                                                    tt.hoadon.phongtro.id_chutro == id_chutro);
                    if (toDelete == null) return false;

                    var hoadon = toDelete.hoadon;
                    if (hoadon == null) return false;

                    // 2. Xóa và Cập nhật trạng thái Hóa đơn
                    dbContext.thanh_toan.Remove(toDelete);
                    hoadon.trang_thai = "Chưa thanh toán";
                    dbContext.Entry(hoadon).State = EntityState.Modified;

                    dbContext.SaveChanges();
                    transaction.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi xóa Thanh toán: " + ex.Message);
                    return false;
                }
            }
        }
    }
}