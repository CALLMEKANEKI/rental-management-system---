
using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class PhongTroDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // 1. CREATE: Thêm Phòng Trọ Mới
        public int InsertPhong(PhongTro objPhong)
        {
            // Sử dụng SCOPE_IDENTITY() để lấy ID tự tăng
            string query = "INSERT INTO phongtro (id_chutro, tenphong, giaphong, tinhtrang) " +
                           "VALUES (@id_chutro, @tenphong, @giaphong, @tinhtrang); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_chutro", objPhong.Id_ChuTro);
                cmd.Parameters.AddWithValue("@tenphong", objPhong.TenPhong);
                cmd.Parameters.AddWithValue("@giaphong", objPhong.GiaPhong);
                cmd.Parameters.AddWithValue("@tinhtrang", objPhong.TinhTrang);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertPhong): " + ex.Message);
                    return -1;
                }
            }
        }

        // 2. READ: Lấy tất cả Phòng trọ
        public List<PhongTro> GetAllPhong()
        {
            List<PhongTro> listPhong = new List<PhongTro>();
            string query = "SELECT id_phong, id_chutro, tenphong, giaphong, tinhtrang FROM phongtro";

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
                            PhongTro objPhong = new PhongTro
                            {
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                TenPhong = reader.GetString(reader.GetOrdinal("tenphong")),
                                GiaPhong = reader.GetDecimal(reader.GetOrdinal("giaphong")),
                                TinhTrang = reader.GetString(reader.GetOrdinal("tinhtrang"))
                            };
                            listPhong.Add(objPhong);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllPhong): " + ex.Message);
                }
            }
            return listPhong;
        }

        // 3. UPDATE: Cập nhật Phòng trọ
        public bool UpdatePhong(PhongTro objPhong)
        {
            string query = "UPDATE phongtro SET id_chutro = @id_chutro, tenphong = @tenphong, " +
                           "giaphong = @giaphong, tinhtrang = @tinhtrang WHERE id_phong = @id_phong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_chutro", objPhong.Id_ChuTro);
                cmd.Parameters.AddWithValue("@tenphong", objPhong.TenPhong);
                cmd.Parameters.AddWithValue("@giaphong", objPhong.GiaPhong);
                cmd.Parameters.AddWithValue("@tinhtrang", objPhong.TinhTrang);
                cmd.Parameters.AddWithValue("@id_phong", objPhong.Id_Phong);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdatePhong): " + ex.Message);
                    return false;
                }
            }
        }

        // 4. DELETE: Xóa Phòng trọ
        public bool DeletePhong(int idPhong)
        {
            string query = "DELETE FROM phongtro WHERE id_phong = @id_phong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_phong", idPhong);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeletePhong): " + ex.Message);
                    return false;
                }
            }
        }

        //5. Lấy phòng theo id
        public PhongTro GetPhongById(int idPhong)
        {
            PhongTro objPhong = null;
            string query = "SELECT id_phong, id_chutro, tenphong, giaphong, tinhtrang FROM phongtro WHERE id_phong = @id_phong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_phong", idPhong);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objPhong = new PhongTro
                            {
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                TenPhong = reader.GetString(reader.GetOrdinal("tenphong")),
                                GiaPhong = reader.GetDecimal(reader.GetOrdinal("giaphong")),
                                TinhTrang = reader.GetString(reader.GetOrdinal("tinhtrang"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetPhongById): " + ex.Message);
                }
            }
            return objPhong;
        }
    }
}
