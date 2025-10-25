using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL.BLL
{
    public class nuocBLL
    {

        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả chỉ số Nước
        public List<nuoc> LayTatCaBanGhiNuoc()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.nuocs.ToList();
            }
        }

        // R - READ (BY ID): Lấy chỉ số Nước theo ID
        public nuoc LayBanGhiNuocTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.nuocs.Find(id);
            }
        }

        // R - READ (BY ID): Lấy chỉ số Nước theo ID của hóa đơn
        public nuoc LayBanGhiNuocTheoHoaDonId(string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                // Tìm Hóa đơn, sau đó truy xuất chi tiết Nước
                // Sử dụng Include(hd => hd.nuoc) để tải chi tiết Nước
                var hoadon = dbContext.hoadons
                                       .Include(hd => hd.nuoc)
                                       .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);

                // Trả về chi tiết Nước từ Hóa đơn (có thể là null nếu không tìm thấy)
                return hoadon?.nuoc;
            }
        }
    }
}