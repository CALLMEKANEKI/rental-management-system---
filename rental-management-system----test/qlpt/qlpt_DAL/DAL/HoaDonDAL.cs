using qlpt_DTO.Models;
using qlpt_DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class HoaDonDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // CƠ SỞ TRUY VẤN VIEWMODEL (Dùng chung cho GetAll và các hàm tìm kiếm)
        private const string BaseSelectQuery = @"
            SELECT  hd.*, 
                    pt.TenPhong AS TenPhongHienThi,
                    d.ChiSo_Dau AS ChiSo_Dien_Cu_HienThi,
                    d.ChiSo_Cuoi AS ChiSo_Dien_Moi_HienThi,
                    d.ThanhTien_Dien AS TongTienDien_HienThi,
                    n.ChiSo_Dau AS ChiSo_Nuoc_Cu_HienThi,
                    n.ChiSo_Cuoi AS ChiSo_Nuoc_Moi_HienThi,
                    n.ThanhTien_Nuoc AS TongTienNuoc_HienThi,
                    lp.TienDv AS TienDichVu_HienThi,
                    lp.TienPhong AS TienPhong_HienThi
            FROM hoadon hd
            INNER JOIN PhongTro pt ON hd.id_phong = pt.id_phong
            INNER JOIN Dien d ON hd.id_dien = d.id_dien
            INNER JOIN Nuoc n ON hd.id_nuoc = n.id_nuoc
            INNER JOIN LePhi lp ON hd.id_lephi = lp.id_lephi ";
        
        // 1. CREATE: Tạo Hóa Đơn mới (và lấy ID)
        public int InsertHoaDon(HoaDon objHoaDon)
        {
            string query = "INSERT INTO hoadon (ngaytao, trangthai, noidung, id_lephi, id_dien, id_nuoc, id_phong, thanhtien) " +
                            "OUTPUT INSERTED.id_hoadon " +
                           "VALUES (@ngaytao, @trangthai, @noidung, @id_lephi, @id_dien, @id_nuoc, @id_phong, @thanhtien);";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@ngaytao", objHoaDon.NgayTao);
                cmd.Parameters.AddWithValue("@trangthai", objHoaDon.TrangThai);
                cmd.Parameters.AddWithValue("@noidung", objHoaDon.NoiDung ?? (object)DBNull.Value); // Xử lý NULL
                cmd.Parameters.AddWithValue("@id_lephi", objHoaDon.Id_LePhi);
                cmd.Parameters.AddWithValue("@id_dien", objHoaDon.Id_Dien);
                cmd.Parameters.AddWithValue("@id_nuoc", objHoaDon.Id_Nuoc);
                cmd.Parameters.AddWithValue("@id_phong", objHoaDon.Id_Phong);
                cmd.Parameters.AddWithValue("@thanhtien", objHoaDon.ThanhTien);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex) { Console.WriteLine("SQL Error (InsertHoaDon): " + ex.Message); return -1; }
            }
        }

        // 2. READ: Lấy ViewModel (Chuyển logic JOIN từ BLL xuống DAL)
        // Hàm ánh xạ từ SqlDataReader sang HoaDon Model (Model gốc, chỉ dùng cho READ)
        private HoaDon MapToHoaDon(SqlDataReader reader)
        {
            // Cần sửa lại để lấy cả ThanhTien
            return new HoaDon
            {
                Id_HoaDon = reader.GetInt32(reader.GetOrdinal("id_hoadon")),
                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                TrangThai = reader.GetString(reader.GetOrdinal("trangthai")),
                NoiDung = reader.IsDBNull(reader.GetOrdinal("noidung")) ? null : reader.GetString(reader.GetOrdinal("noidung")),
                Id_Dien = reader.GetInt32(reader.GetOrdinal("id_dien")),
                Id_Nuoc = reader.GetInt32(reader.GetOrdinal("id_nuoc")),
                Id_LePhi = reader.GetInt32(reader.GetOrdinal("id_lephi")),
                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                ThanhTien = reader.GetDecimal(reader.GetOrdinal("thanhtien")) // Thêm ThanhTien
            };
        }

        // Hàm ánh xạ từ SqlDataReader sang HoaDonViewModel
        private HoaDonViewModel MapToHoaDonViewModel(SqlDataReader reader)
        {
            return new HoaDonViewModel
            {
                Id_HoaDon = reader.GetInt32(reader.GetOrdinal("id_hoadon")),
                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                TrangThai = reader.GetString(reader.GetOrdinal("trangthai")),
                NoiDung = reader.IsDBNull(reader.GetOrdinal("noidung")) ? null : reader.GetString(reader.GetOrdinal("noidung")),
                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                Id_Dien = reader.GetInt32(reader.GetOrdinal("id_dien")),
                Id_Nuoc = reader.GetInt32(reader.GetOrdinal("id_nuoc")),
                Id_LePhi = reader.GetInt32(reader.GetOrdinal("id_lephi")),

                // Thuộc tính đã JOIN
                TenPhongHienThi = reader.GetString(reader.GetOrdinal("TenPhongHienThi")),

                ChiSo_Dien_Cu_HienThi = reader.GetDecimal(reader.GetOrdinal("ChiSo_Dien_Cu_HienThi")),
                ChiSo_Dien_Moi_HienThi = reader.GetDecimal(reader.GetOrdinal("ChiSo_Dien_Moi_HienThi")),
                TongTienDien_HienThi = reader.GetDecimal(reader.GetOrdinal("TongTienDien_HienThi")),

                ChiSo_Nuoc_Cu_HienThi = reader.GetDecimal(reader.GetOrdinal("ChiSo_Nuoc_Cu_HienThi")),
                ChiSo_Nuoc_Moi_HienThi = reader.GetDecimal(reader.GetOrdinal("ChiSo_Nuoc_Moi_HienThi")),
                TongTienNuoc_HienThi = reader.GetDecimal(reader.GetOrdinal("TongTienNuoc_HienThi")),

                TienDichVu_HienThi = reader.GetDecimal(reader.GetOrdinal("TienDichVu_HienThi")),
                TienPhong_HienThi = reader.GetDecimal(reader.GetOrdinal("TienPhong_HienThi")),
            };
        }

        private List<HoaDonViewModel> ExecuteQueryAndMap(string query, SqlParameter[] parameters)
        {
            List<HoaDonViewModel> listKetQua = new List<HoaDonViewModel>();

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Thêm tham số vào SqlCommand
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listKetQua.Add(MapToHoaDonViewModel(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"SQL Error in ExecuteQueryAndMap (HoaDon): {ex.Message} - Query: {query}");
                }
            }
            return listKetQua;
        }

        // Lấy tất cả hóa đơn ViewModel theo idChuTro
        public List<HoaDonViewModel> GetAllHoaDonViewModel(int idChuTro)
        {
            List<HoaDonViewModel> listHoaDonViewModel = new List<HoaDonViewModel>();

            string query = BaseSelectQuery + " WHERE pt.id_chutro = @id_chutro";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_chutro", idChuTro);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listHoaDonViewModel.Add(MapToHoaDonViewModel(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllHoaDonViewModel): " + ex.Message);
                }
            }
            return listHoaDonViewModel;
        }

        //Lấy tất cả hóa đơn theo keyworrd
        public List<HoaDonViewModel> GetAllHoaDonViewModelByKeyWord(int idChuTro, string keyword)
        {
            List<HoaDonViewModel> listHoaDonViewModel = new List<HoaDonViewModel>();

            // 1. Kiểm tra từ khóa: Nếu rỗng, trả về toàn bộ danh sách (Tốt hơn là gọi GetAllHoaDonViewModel)
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Giả sử bạn có hàm GetAllHoaDonViewModel đã sửa ở phần trước
                return GetAllHoaDonViewModel(idChuTro);
            }

            // 2. Sửa lỗi cú pháp SQL (Thêm khoảng trắng và dấu OR/AND, bỏ OR cuối cùng)
            // Dùng tên cột gốc (hd.NoiDung, hd.TrangThai, pt.TenPhong) sau JOIN
            string query = BaseSelectQuery +
                           " WHERE pt.id_chutro = @id_chutro" +
                           " AND ( " +
                           // Tìm kiếm theo ID (Cần CONVERT sang chuỗi)
                           " CONVERT(NVARCHAR, hd.id_hoadon) LIKE @KeywordParam OR " +
                           // Tìm kiếm theo Ngày tạo (Cần CONVERT sang chuỗi, ví dụ 103 = dd/mm/yyyy)
                           " CONVERT(NVARCHAR, hd.ngaytao, 103) LIKE @KeywordParam OR " +
                           // Tìm kiếm trên các cột chuỗi
                           " pt.TenPhong LIKE @KeywordParam OR " +
                           " hd.NoiDung LIKE @KeywordParam OR " +
                           " hd.TrangThai LIKE @KeywordParam " +
                           " )";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // 3. Sửa lỗi tham số: Truyền ID Chủ trọ
                cmd.Parameters.AddWithValue("@id_chutro", idChuTro);

                // 4. Sửa lỗi tham số: Thêm ký tự đại diện "%" cho toán tử LIKE
                cmd.Parameters.AddWithValue("@KeywordParam", "%" + keyword + "%");

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listHoaDonViewModel.Add(MapToHoaDonViewModel(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Đổi tên biến lỗi để dễ theo dõi
                    Console.WriteLine("SQL Error (GetAllHoaDonViewModelByKeyWord): " + ex.Message);
                }
            }
            return listHoaDonViewModel;
        }

        // Lấy hóa đơn Model theo ID (Dùng cho BLL Delete/Update)
        public HoaDon GetHoaDonById(int idHoaDon)
        {
            HoaDon objHoaDon = null;
            // SỬA: Phải SELECT TẤT CẢ các cột cần thiết cho MapToHoaDon
            string query = "SELECT * FROM hoadon WHERE id_hoadon = @id_hoadon";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_hoadon", idHoaDon);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objHoaDon = MapToHoaDon(reader); // Dùng hàm MapToHoaDon đầy đủ
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("SQL Error (GetHoaDonById): " + ex.Message); }
            }
            return objHoaDon;
        }

        // 3. UPDATE
        // Cập nhật trạng thái Hóa đơn (Giữ nguyên, đã OK)
        public bool UpdateTrangThai(int idHoaDon, string trangThaiMoi)
        {
            string query = "UPDATE hoadon SET trangthai = @trangthai WHERE id_hoadon = @id_hoadon";
            // ... (Phần code còn lại giữ nguyên) ...
            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@trangthai", trangThaiMoi);
                cmd.Parameters.AddWithValue("@id_hoadon", idHoaDon);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex) { Console.WriteLine("SQL Error (UpdateTrangThai): " + ex.Message); return false; }
            }
        }

        // Cập nhật toàn bộ thông tin hóa đơn (Transaction)
        public bool UpdateHoaDon(HoaDon objHoaDon)
        {
            // SỬA LỖI CÚ PHÁP SQL: Thiếu dấu phẩy (,) sau @noidung
            string query = "UPDATE hoadon SET ngaytao = @ngaytao, trangthai = @trangthai, noidung = @noidung, " +
                           "id_lephi = @id_lephi, id_nuoc = @id_nuoc, id_dien = @id_dien, id_phong = @id_phong, thanhtien = @thanhtien " +
                           "WHERE id_hoadon = @id_hoadon";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_hoadon", objHoaDon.Id_HoaDon);
                cmd.Parameters.AddWithValue("@ngaytao", objHoaDon.NgayTao);
                cmd.Parameters.AddWithValue("@trangthai", objHoaDon.TrangThai);
                cmd.Parameters.AddWithValue("@noidung", objHoaDon.NoiDung ?? (object)DBNull.Value); // Xử lý NULL
                cmd.Parameters.AddWithValue("@id_lephi", objHoaDon.Id_LePhi);
                cmd.Parameters.AddWithValue("@id_nuoc", objHoaDon.Id_Nuoc);
                cmd.Parameters.AddWithValue("@id_dien", objHoaDon.Id_Dien);
                cmd.Parameters.AddWithValue("@id_phong", objHoaDon.Id_Phong);
                cmd.Parameters.AddWithValue("@thanhtien", objHoaDon.ThanhTien);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateHoaDon): " + ex.Message);
                    return false;
                }
            }
        }

        // 4. DELETE
        // Xóa hóa đơn 
        public bool DeleteHoaDon(int idHoaDon)
        {
            string query = "DELETE FROM hoadon WHERE id_hoadon = @id_hoadon";
            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_hoadon", idHoaDon);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteHoaDon): " + ex.Message);
                    return false;
                }
            }
        }
    }
}
