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
            // Thêm các cột chỉ số cũ/mới, đơn giá, số lượng tiêu thụ vào đây
            string query = "INSERT INTO dien (id_dien, ngaytao, chiso_dau, chiso_cuoi, thanhtien_dien) " +
                           "VALUES (@id_dien, @ngaytao, @chiso_dau, @chiso_cuoi, @thanhtien_dien); ";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_dien", objDien.Id_Dien);
                cmd.Parameters.AddWithValue("@ngaytao", objDien.NgayTao);
                cmd.Parameters.AddWithValue("@chiso_dau", objDien.ChiSo_Dau);
                cmd.Parameters.AddWithValue("@chiso_cuoi", objDien.ChiSo_Cuoi);
                cmd.Parameters.AddWithValue("@thanhtien_dien", objDien.ThanhTien_Dien);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertDien): " + ex.Message);
                    return -1;
                }
            }
        }
       
        //2. Read: lấy tất cả bản ghi điện
        public List<Dien> GetAllDien()
        {
            List<Dien> listDien = new List<Dien>();
            string query = "SELECT * FROM dien";

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
