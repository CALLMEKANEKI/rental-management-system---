using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class DienDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // 1. CREATE: Thêm bản ghi Tiền Điện mới (và lấy ID)
        public int InsertDien(Dien objDien)
        {
            // SỬA: Loại bỏ id_dien khỏi INSERT và thêm SELECT SCOPE_IDENTITY() để lấy ID mới
            string query = "INSERT INTO dien (ngaytao, chiso_dau, chiso_cuoi, thanhtien_dien) " +
                           "VALUES (@ngaytao, @chiso_dau, @chiso_cuoi, @thanhtien_dien); " +
                           "SELECT SCOPE_IDENTITY();"; // Lấy ID vừa tạo

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // SỬA: Loại bỏ tham số @id_dien
                cmd.Parameters.AddWithValue("@ngaytao", objDien.NgayTao);
                cmd.Parameters.AddWithValue("@chiso_dau", objDien.ChiSo_Dau);
                cmd.Parameters.AddWithValue("@chiso_cuoi", objDien.ChiSo_Cuoi);
                cmd.Parameters.AddWithValue("@thanhtien_dien", objDien.ThanhTien_Dien);

                try
                {
                    conn.Open();
                    // SỬA: ExecuteScalar trả về ID mới (decimal, cần Convert)
                    object result = cmd.ExecuteScalar();
                    // Chuyển đổi sang int nếu thành công
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertDien): " + ex.Message);
                    return -1;
                }
            }
        }

        //2. Read: lấy tất cả bản ghi điện theo Chủ trọ (Cần thiết cho BLL)
        public List<Dien> GetAllDien(int idChuTro)
        {
            List<Dien> listDien = new List<Dien>();
            // SỬA: JOIN với HoaDon và PhongTro để lọc theo id_ChuTro
            string query = @"
                SELECT d.* FROM dien d
                INNER JOIN HoaDon hd ON d.id_dien = hd.id_dien
                INNER JOIN PhongTro pt ON hd.id_phong = pt.id_phong
                WHERE pt.id_chutro = @id_chutro";

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
                            Dien objDien = new Dien
                            {
                                Id_Dien = reader.GetInt32(reader.GetOrdinal("id_dien")),
                                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                                ChiSo_Dau = reader.GetDecimal(reader.GetOrdinal("chiso_dau")),
                                ChiSo_Cuoi = reader.GetDecimal(reader.GetOrdinal("chiso_cuoi")),
                                ThanhTien_Dien = reader.GetDecimal(reader.GetOrdinal("thanhtien_dien"))
                            };
                            listDien.Add(objDien);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllDien): " + ex.Message);
                }
            }
            return listDien;
        }

        //3.Update: cập nhật bản ghi điện
        public bool UpdateDien(Dien objDien)
        {
            // SỬA: Thêm dấu phẩy và loại bỏ cập nhật id_dien
            string query = "UPDATE dien SET ngaytao = @ngaytao, chiso_dau = @chiso_dau, " +
                           "chiso_cuoi = @chiso_cuoi, thanhtien_dien = @thanhtien_dien " +
                           "WHERE id_dien = @id_dien"; // Dùng id_dien trong WHERE để lọc

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_dien", objDien.Id_Dien);
                cmd.Parameters.AddWithValue("@ngaytao", objDien.NgayTao);
                cmd.Parameters.AddWithValue("@chiso_dau", objDien.ChiSo_Dau);
                cmd.Parameters.AddWithValue("@chiso_cuoi", objDien.ChiSo_Cuoi);
                cmd.Parameters.AddWithValue("@thanhtien_dien", objDien.ThanhTien_Dien);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateDien): " + ex.Message);
                    return false;
                }
            }
        }

        //4.Delete: Xóa bản ghi dien
        public bool DeleteDien(int iddien)
        {
            string query = "DELETE FROM dien WHERE id_dien = @id_dien";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_dien", iddien);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteDien): " + ex.Message);
                    return false;
                }
            }
        }
    }
}