using BLL.Services;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmChiTietThanhToan : Form
    {
        private string id_hoadon;
        private string id_chutrohientai ;
        public frmChiTietThanhToan(string maHoaDon)
        {
            InitializeComponent();
            this.id_hoadon = maHoaDon;
            this.id_chutrohientai = MAIN.main.LOGIN.id_chutrohientai;
            LoadChiTietThanhToan();
        }

        public void LoadChiTietThanhToan()
        {
            hoadonService _hoadonService = new hoadonService();
            hoadonViewModel objHoaDonViewModel = _hoadonService.LayHoaDonViewModelTheoID(id_hoadon, id_chutrohientai);

            txtMaHoaDon.Text = objHoaDonViewModel.IDHoaDon;
            dtpNgayTao.Value = objHoaDonViewModel.NgayTao;
            txtNoiDung.Text = objHoaDonViewModel.NoiDung;
            txtTongTien.Text = objHoaDonViewModel.ThanhTien.ToString();

            txtTenPhong.Text = objHoaDonViewModel.TenPhong;
            txtTrangThai.Text = objHoaDonViewModel.TrangThai;

            // Chỉ số Điện
            txtChiSoDienCu.Text = objHoaDonViewModel.ChiSoDien_Dau.ToString();
            txtChiSoDienMoi.Text = objHoaDonViewModel.ChiSoDien_Cuoi.ToString();
            txtTienDien.Text = objHoaDonViewModel.ThanhTien_Dien.ToString();

            // Chỉ số Nước
            txtChiSoNuocCu.Text = objHoaDonViewModel.ChiSoNuoc_Dau.ToString();
            txtChiSoNuocMoi.Text = objHoaDonViewModel.ChiSoNuoc_Cuoi.ToString();
            txtTienNuoc.Text = objHoaDonViewModel.ThanhTien_Nuoc.ToString();

            // Dịch vụ và Lệ phí
            txtTienDV.Text = objHoaDonViewModel.Tien_dv.ToString();
            txtTienPhong.Text = objHoaDonViewModel.Tien_Phong.ToString();
        }

    }
}
