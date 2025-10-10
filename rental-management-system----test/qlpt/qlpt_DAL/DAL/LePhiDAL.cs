using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class LePhiDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // 1. CREATE: Thêm bản ghi Lệ Phí mới (và lấy ID)
        public int InsertLePhi(LePhi objLePhi)
        {
            // Thêm các cột lệ phí chi tiết của bạn vào đây
            string query = "INSERT INTO lephi (id_lephi, ngaytao, tienphong, tiendv, thanhtien_lephi) " +
                           "VALUES (@id_lephi, @ngaytao, @tienphong, @tiendv, @thanhtien_lephi); ";
            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_lephi", objLePhi.Id_LePhi);
                cmd.Parameters.AddWithValue("@ngaytao", objLePhi.NgayTao);
                cmd.Parameters.AddWithValue("@tienphong", objLePhi.TienPhong);
                cmd.Parameters.AddWithValue("@tiendv", objLePhi.TienDv);
                cmd.Parameters.AddWithValue("@thanhtien_lephi", objLePhi.ThanhTien_LePhi);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertLePhi): " + ex.Message);
                    return -1;
                }
            }
        }

        //2. Read: Lấy tất cả bản ghi lệ phí
        public List<LePhi> GetAllLePhi()
        {
            List<LePhi> listLePhi = new List<LePhi>();
            string query = "SELECT * FROM lephi";

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
                            LePhi objLePhi = new LePhi
                            {
                                Id_LePhi = reader.GetInt32(reader.GetOrdinal("id_lephi")),
                                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                                TienPhong = reader.GetDecimal(reader.GetOrdinal("tienphong")),
                                TienDv = reader.GetDecimal(reader.GetOrdinal("tiendv")),
                            };
                            listLePhi.Add(objLePhi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllLePhi): " + ex.Message);
                }
            }
            return listLePhi;
        }

        //4.Delete: Xóa bản ghi lệ phí
        public bool DeleteLePhi(int idLePhi)
        {
            string query = "DELETE FROM lephi WHERE id_lephi = @id_lephi";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_lephi", idLePhi);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteLePhi): " + ex.Message);
                    return false;
                }
            }
        }
    }
}
