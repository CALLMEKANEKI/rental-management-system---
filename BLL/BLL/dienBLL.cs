using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL.BLL
{
    public class dienBLL
    {
        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả chỉ số Điện
        public List<dien> LayTatCaBanGhiDien()
        {
            using (var dbContext = new ContextDB())
            {
                return dbContext.diens.ToList();
            }
        }

        // R - READ (BY ID): Lấy chỉ số Điện theo ID
        public dien LayBanGhiDienTheoId(string id)
        {
            using (var dbContext = new ContextDB())
            {
                // Find() hoạt động hiệu quả khi tìm kiếm theo khóa chính
                return dbContext.diens.Find(id);
            }
        }

        // R - READ (BY ID): Lấy chỉ số Điện theo ID của hóa đơn
        public dien LayBanGhiDienTheoHoaDonId(string id_hoadon)
        {
            using (var dbContext = new ContextDB())
            {
                // Tìm Hóa đơn, sau đó truy xuất chi tiết Điện
                // Sử dụng Include(hd => hd.dien) để tải chi tiết Điện
                var hoadon = dbContext.hoadons
                                       .Include(hd => hd.dien)
                                       .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);

                // Trả về chi tiết Điện từ Hóa đơn (có thể là null nếu không tìm thấy)
                return hoadon?.dien;
            }
        }
    }
}