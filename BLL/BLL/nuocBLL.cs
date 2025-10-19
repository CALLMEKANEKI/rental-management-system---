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
        private ContextDB _dbContext;

        public nuocBLL()
        {
            _dbContext = new ContextDB();
        }

        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL
        // R - READ (ALL): Lấy tất cả chỉ số Nước
        public List<nuoc> LayTatCaBanGhiNuoc()
        {
            return _dbContext.nuocs.ToList();
        }

        // R - READ (BY ID): Lấy chỉ số Nước theo ID
        public nuoc LayBanGhiNuocTheoId(string id)
        {
            return _dbContext.nuocs.Find(id);
        }

        // R - READ (BY ID): Lấy chỉ số Nước theo ID của hóa đơn
        public nuoc LayBanGhiNuocTheoHoaDonId(string id_hoadon)
        {
            // Tìm Hóa đơn, sau đó truy xuất chi tiết Nước
            var hoadon = _dbContext.hoadons
                                   .Include(hd => hd.nuoc)
                                   .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);
            return hoadon?.nuoc;
        }
    }
}
