using BLL.BLL;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class dienService
    {
        dienBLL _dienBLL = new dienBLL();

        public List<dienViewModel> LatTatCaBanGhiDienViewModel(string id_chutrohientai)
        {
            return _dienBLL.LatTatCaBanGhiDienViewModel(id_chutrohientai);
        }

        public List<dienViewModel> LatTatCaBanGhiDienViewModelTheoKeyWord(string id_chutrohientai, string keywword) 
        { 
            return _dienBLL.LatTatCaBanGhiDienViewModelTheoKeyWord(id_chutrohientai , keywword);
        }

    }
}
