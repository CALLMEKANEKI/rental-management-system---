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
        private ContextDB _dbContext;

        public dienBLL()
        {
            _dbContext = new ContextDB();
        }

        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả chỉ số Điện
        public List<dien> LayTatCaBanGhiDien()
        {
            return _dbContext.diens.ToList();
        }

        // R - READ (BY ID): Lấy chỉ số Điện theo ID
        public dien LayBanGhiDienTheoId(string id)
        {
            return _dbContext.diens.Find(id);
        }

        // R - READ (BY ID): Lấy chỉ số Điện theo ID của hóa đơn
        public dien LayBanGhiDienTheoHoaDonId(string id_hoadon)
        {
            // Tìm Hóa đơn, sau đó truy xuất chi tiết Điện
            var hoadon = _dbContext.hoadons
                                   .Include(hd => hd.dien)
                                   .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);
            return hoadon?.dien;
        }
    }
}
