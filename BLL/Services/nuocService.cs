using BLL.BLL;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class nuocService
    {
        nuocBLL _nuocBLL = new nuocBLL();
        public List<nuocViewModel> LayTatCaBanGhiNuocViewModel(string id_chutrohientai)
        {
            return _nuocBLL.LatTatCaBanGhiNuocViewModel(id_chutrohientai);
        }

        public List<nuocViewModel> LayTatCaBanGhiNuocViewModelTheoKeyWork(string id_chutrohientai, string keywork) 
        { 
            return _nuocBLL.LatTatCaBanGhiNuocViewModelTheoKeyWord(id_chutrohientai, keywork);
        }

    }
}
