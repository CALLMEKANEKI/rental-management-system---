using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace BLL.BLL
{
    public class lephiBLL
    {
        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả Lệ phí
        public List<lephi> LayTatCaLePhi()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.lephis.ToList();
            }
        }

        // R - READ (BY ID): Lấy Lệ phí theo ID
        public lephi LayLePhiTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                // Find() hoạt động hiệu quả khi tìm kiếm theo khóa chính
                return dbContext.lephis.Find(id);
            }
        }

        //R - READ (BY ID): Lấy Lệ phí theo ID của hóa đơn
        public lephi LayBanGhiLePhiTheoHoaDonId(string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                // Tìm Hóa đơn, sau đó truy xuất chi tiết Lệ Phí
                // Sử dụng Include(hd => hd.lephi) để tải chi tiết Lệ Phí
                var hoadon = dbContext.hoadons
                                       .Include(hd => hd.lephi)
                                       .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);

                // Trả về chi tiết Lệ Phí từ Hóa đơn (có thể là null nếu không tìm thấy)
                return hoadon?.lephi;
            }
        }
    }
}