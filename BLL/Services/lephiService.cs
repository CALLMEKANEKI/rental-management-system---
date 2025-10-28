using BLL.BLL;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class lephiService
    {
        lephiBLL _lephiBLL = new lephiBLL();
        public List<lephiViewModel> LayTatCaBanGhiLePhiViewModel(string id_chutrohientai)
        {
            return _lephiBLL.LatTatCaBanGhiLePhiViewModel(id_chutrohientai);
        }

        public List<lephiViewModel> LayTatCaBanGhiLePhiViewModelTheoKeyWord(string id_chutrohientai, string keyword)
        {
            return _lephiBLL.LatTatCaBanGhiLePhiViewModelTheoKeyWord(id_chutrohientai, keyword);
        }
    }
}
