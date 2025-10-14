using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class NuocDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // 1. CREATE: Thêm bản ghi Tiền Nước mới (và lấy ID)
        public int InsertNuoc(Nuoc objNuoc)
        {
            string query = "INSERT INTO nuoc (ngaytao, chiso_dau, chiso_cuoi, thanhtien_nuoc) " +
                           "VALUES (@ngaytao, @chiso_dau, @chiso_cuoi, @thanhtien_nuoc); " +
                           "SELECT SCOPE_IDENTITY();"; 

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ngaytao", objNuoc.NgayTao);
                cmd.Parameters.AddWithValue("@chiso_dau", objNuoc.ChiSo_Dau);
                cmd.Parameters.AddWithValue("@chiso_cuoi", objNuoc.ChiSo_Cuoi);
                cmd.Parameters.AddWithValue("@thanhtien_nuoc", objNuoc.ThanhTien_Nuoc);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertNuoc): " + ex.Message);
                    return -1;
                }
            }
        }

        // 2. Read: lấy tất cả bản ghi nước theo Chủ trọ (Cần thiết cho BLL)
        public List<Nuoc> GetAllNuoc(int idChuTro)
        {
            List<Nuoc> listNuoc = new List<Nuoc>();
            //JOIN với HoaDon và PhongTro để lọc theo id_ChuTro
            string query = @"
                SELECT n.* FROM nuoc n
                INNER JOIN HoaDon hd ON n.id_nuoc = hd.id_nuoc
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
                            Nuoc objNuoc = new Nuoc
                            {
                                Id_Nuoc = reader.GetInt32(reader.GetOrdinal("id_nuoc")),
                                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                                ChiSo_Dau = reader.GetDecimal(reader.GetOrdinal("chiso_dau")),
                                ChiSo_Cuoi = reader.GetDecimal(reader.GetOrdinal("chiso_cuoi")),
                                ThanhTien_Nuoc = reader.GetDecimal(reader.GetOrdinal("thanhtien_nuoc"))
                            };
                            listNuoc.Add(objNuoc);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllNuoc): " + ex.Message);
                }
            }
            return listNuoc;
        }

        // 3. Update: cập nhật bản ghi nuoc
        public bool UpdateNuoc(Nuoc objNuoc)
        {
            string query = "UPDATE nuoc SET ngaytao = @ngaytao, chiso_dau = @chiso_dau, " +
                           "chiso_cuoi = @chiso_cuoi, thanhtien_nuoc = @thanhtien_nuoc " +
                           "WHERE id_nuoc = @id_nuoc";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_nuoc", objNuoc.Id_Nuoc);
                cmd.Parameters.AddWithValue("@ngaytao", objNuoc.NgayTao);
                cmd.Parameters.AddWithValue("@chiso_dau", objNuoc.ChiSo_Dau);
                cmd.Parameters.AddWithValue("@chiso_cuoi", objNuoc.ChiSo_Cuoi);
                cmd.Parameters.AddWithValue("@thanhtien_nuoc", objNuoc.ThanhTien_Nuoc);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateNuoc): " + ex.Message);
                    return false;
                }
            }
        }

        // 4. Delete: Xóa bản ghi nước
        public bool DeleteNuoc(int idnuoc)
        {
            // SỬA: Đồng bộ tham số @id_nuoc
            string query = "DELETE FROM nuoc WHERE id_nuoc = @id_nuoc";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_nuoc", idnuoc);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteNuoc): " + ex.Message);
                    return false;
                }
            }
        }
    }
}