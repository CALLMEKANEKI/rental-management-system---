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
        private ContextDB _dbContext;

        public lephiBLL()
        {
            _dbContext = new ContextDB();
        }

        //CUD không cần thêm vì đã được xử lý TransactionScope trong hoadonBLL

        // R - READ (ALL): Lấy tất cả Lệ phí
        public List<lephi> LayTatCaLePhi()
        {
            return _dbContext.lephis.ToList();
        }

        // R - READ (BY ID): Lấy Lệ phí theo ID
        public lephi LayLePhiTheoId(string id)
        {
            return _dbContext.lephis.Find(id);
        }

        //R - READ (BY ID): Lấy Lệ phí theo ID của hóa đơn
        public lephi LayBanGhiLePhiTheoHoaDonId(string id_hoadon)
        {
            // Tìm Hóa đơn, sau đó truy xuất chi tiết Lệ Phí
            var hoadon = _dbContext.hoadons
                                   .Include(hd => hd.lephi)
                                   .FirstOrDefault(hd => hd.id_hoadon == id_hoadon);
            return hoadon?.lephi;
        }
    }
}
