using BLL.BLL;
using DAL.Model;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class phongtroService
    {
        phongtroBLL PhongTroBLL = new phongtroBLL();
        nguoithueBLL nguoithueBLL = new nguoithueBLL();

        // === THÊM PHÒNG TRỌ ===
        public string ThemPhongTro(phongtro objPhongTro, string id_chutro)
        {
            string mess = "";
            if (Validators.ValidatePhongTro(objPhongTro, out mess))
            {
                try
                {
                    bool isSuccess = PhongTroBLL.ThemPhongTro(objPhongTro, id_chutro);
                    return isSuccess ? "Thêm phòng thành công." : "Không thể thêm phòng vào cơ sở dự liệu";
                }
                catch (Exception ex)
                {
                    return "Lỗi hệ thống khi thêm dữ liệu: " + ex.Message;
                }
            }
            else
            {
                return "Lỗi: " + mess;
            }
        }

        // === CẬP NHẬT PHÒNG TRỌ ===
        public string CapNhat(phongtro objPhongTro, string id_chutro)
        {
            string mess = "";
            if (Validators.ValidatePhongTro(objPhongTro, out mess))
            {
                try
                {
                    bool isSuccess = PhongTroBLL.CapNhatPhongTro(objPhongTro, id_chutro);
                    return isSuccess ? "Cập nhật phòng thành công." : "Lỗi: Không thể cập nhật vào cơ sở dữ liệu.";
                }
                catch (Exception ex)
                {
                    return "Lỗi hệ thống khi cập nhật dữ liệu: " + ex.Message;
                }
            }
            else
            {
                return "Lỗi: " + mess;
            }
        }




        // === LẤY DỮ LIỆU ===
        public phongtro LayPhongTroById(string id_phongtro, string id_chutro)
        {
            return PhongTroBLL.LayPhongTroTheoId(id_phongtro, id_chutro);
        }

        public List<phongtro> LayTatCaPhongTro(string id_chutro)
        {
            return PhongTroBLL.LayTatCaPhongTro(id_chutro);
        }

        public List<phongtroViewModel> LayTatCaPhongTroViewModel(string id_chutro)
        {
            return PhongTroBLL.LayTatCaPhongTroViewModel(id_chutro);
        }

        public List<phongtroViewModel> TimKiemPhongTro(string keyword, string tinhTrang, string id_chutro)
        {
            try
            {
                var list = PhongTroBLL.LayTatCaPhongTroViewModel(id_chutro);

                // Lọc theo từ khóa
                if (!string.IsNullOrEmpty(keyword))
                {
                    list = list.Where(p =>
                        p.tenphong.ToLower().Contains(keyword.ToLower()) ||
                        p.id_phong.ToLower().Contains(keyword.ToLower())
                    ).ToList();
                }

                // Lọc theo tình trạng (nếu có chọn)
                if (!string.IsNullOrEmpty(tinhTrang) && tinhTrang != "Tất cả")
                {
                    list = list.Where(p => p.tinhtrang == tinhTrang).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm: " + ex.Message);
                return new List<phongtroViewModel>();
            }
        }



        // === XÓA PHÒNG ===
        public string Xoa(string id_Phongtro, string id_chutro)
        {
            var result = nguoithueBLL.LayTatCaNguoiThue(id_chutro)
                                     .Where(nt => nt.id_phong == id_Phongtro)
                                     .ToList();

            if (result != null && result.Count > 0)
                return "Không thể xóa phòng do đang có người thuê.";

            try
            {
                bool isSuccess = PhongTroBLL.XoaPhongTro(id_Phongtro, id_chutro);
                return isSuccess ? "Xóa phòng thành công." : "Lỗi: Không thể xóa phòng.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống khi xóa dữ liệu: " + ex.Message;
            }
        }

        // === TÌM PHÒNG TRỐNG ===

        public List<phongtro> TimPhongTrong(string id_chutro)
        {
            try
            {
                return PhongTroBLL.TimPhongTrong(id_chutro);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phòng trống: " + ex.Message);
            }
        }

        // === TÌM PHÒNG THEO KEYWORD ===

        public List<phongtro> TimKiemPhongTro(string keyword, string id_chutro)
        {
            // Thực hiện bất kỳ logic kiểm tra đầu vào nào ở đây (ví dụ: keyword có quá dài không)

            // Gọi hàm logic từ BLL
            return PhongTroBLL.TimKiemPhongTro(keyword, id_chutro);
        }
    }
}
