using BLL.BLL;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class thanhtoanService
    {
        thanhtoanBLL _thanhtoanBLL = new thanhtoanBLL();

        // 1. HÀM THÊM (CREATE)
        public bool ThemThanhToan(thanh_toan newThanhToan, string id_chutro)
        {
            return _thanhtoanBLL.ThemThanhToan(newThanhToan, id_chutro);
        }

        // 2. HÀM LẤY VIEW MODEL (READ/SEARCH)
        public List<thanhToanViewModel> LayAllThanhToanViewModel(string id_chutro, string keyword = null)
        {
            return _thanhtoanBLL.GetLichSuThanhToan(id_chutro, keyword);
        }

        // 3. HÀM SỬA (UPDATE)
        public bool SuaThanhToan(
            string id_hoadon_goc,
            string id_nguoithue_goc,
            string new_id_nguoi_thue,
            DateTime new_ngay_thanh_toan,
            string id_chutro)
        {
            return _thanhtoanBLL.CapNhatThanhToan(
                id_hoadon_goc,
                id_nguoithue_goc,
                new_id_nguoi_thue,
                new_ngay_thanh_toan,
                id_chutro);
        }

        // 4. HÀM XÓA (DELETE) - Dùng cặp Khóa chính để xóa
        public bool XoaThanhToan(string id_hoadon, string id_chutro)
        {
            return _thanhtoanBLL.XoaThanhToan(id_hoadon, id_chutro);
        }
    }
}