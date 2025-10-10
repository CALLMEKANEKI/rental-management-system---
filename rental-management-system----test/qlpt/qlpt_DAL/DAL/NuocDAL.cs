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
            string query = "INSERT INTO nuoc (id_nuoc, ngaytao, chiso_dau, chiso_cuoi, thanhtien_nuoc) " +
                           "VALUES (@id_nuoc, @ngaytao, @chiso_dau, @chiso_cuoi, @thanhtien_nuoc); ";
            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_nuoc", objNuoc.Id_Nuoc);
                cmd.Parameters.AddWithValue("@ngaytao", objNuoc.NgayTao);
                cmd.Parameters.AddWithValue("@ChiSo_Dau", objNuoc.ChiSo_Dau);
                cmd.Parameters.AddWithValue("@chisomoi", objNuoc.ChiSo_Cuoi);
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
        //2.Read: Lấy tất cả bản ghi nước
        public List<Nuoc> GetAllNuoc()
        {
            List<Nuoc> listNuoc = new List<Nuoc>();
            string query = "SELECT * FROM nuoc";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
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

        //4.Delete: Xóa bản ghi nước
        public bool DeleteNuoc(int idnuoc)
        {
            string query = "DELETE FROM nuoc WHERE id_nuoc = @idnuoc";

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
