
using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
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
                    "OUTPUT INSERTED.id_phong " + 
                    "VALUES (@id_chutro, @tenphong, @giaphong, @tinhtrang);";

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

        // Hàm ánh xạ chung từ SqlDataReader sang PhongTro Model (chỉ dùng READ)
        private PhongTro MapToPhongTro(SqlDataReader reader)
        {
            PhongTro objPhongTro = new PhongTro
            {
                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                TenPhong = reader.GetString(reader.GetOrdinal("tenphong")),
                GiaPhong = reader.GetDecimal(reader.GetOrdinal("giaphong")),
                TinhTrang = reader.GetString(reader.GetOrdinal("tinhtrang"))
            };
            return objPhongTro;
        }

        // 2. READ: Lấy tất cả Phòng trọ
        public List<PhongTro> GetAllPhong(int idChuTro)
        {
            List<PhongTro> listPhong = new List<PhongTro>();
            string query = "SELECT id_phong, id_chutro, tenphong, giaphong, tinhtrang FROM phongtro WHERE id_chutro = @id_chutro";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id_chutro", idChuTro);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listPhong.Add(MapToPhongTro(reader));
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

        //2.2 Lấy phòng theo tên
        public List<PhongTro> GetPhongByName(int idChuTro, string tenPhong)
        {
            List<PhongTro> listPhong = new List<PhongTro>();

            // Query: Tìm kiếm phòng theo Id_ChuTro và tên phòng (sử dụng LIKE cho tìm kiếm gần đúng)
            string query = "SELECT * FROM PhongTro WHERE Id_ChuTro = @Id_ChuTro AND TenPhong LIKE @TenPhong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // 1. Tham số hóa Id Chủ trọ
                cmd.Parameters.AddWithValue("@Id_ChuTro", idChuTro);

                // 2. Tham số hóa Tên phòng (thêm ký tự % cho tìm kiếm LIKE)
                cmd.Parameters.AddWithValue("@TenPhong", "%" + tenPhong + "%");

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listPhong.Add(MapToPhongTro(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (SearchPhongTro): " + ex.Message);
                }
            }
            return listPhong;
        }

        //2.3 Lấy tất cả phòng trọ theo keyword
        public List<PhongTro> GetAllPhongByKeyWord(int idChuTro, string KeyWord)
        {
            List<PhongTro> listPhong = new List<PhongTro>();

            // Chuẩn hóa KeyWord (loại bỏ khoảng trắng thừa)
            string trimmedKeyword = KeyWord?.Trim() ?? string.Empty;

            // 1. CÂU TRUY VẤN CƠ SỞ: Luôn lọc theo Id_ChuTro
            string query = "SELECT * FROM PhongTro WHERE Id_ChuTro = @Id_ChuTro";

            // 2. THÊM ĐIỀU KIỆN TÌM KIẾM CHỈ KHI CÓ KEYWORD
            if (!string.IsNullOrEmpty(trimmedKeyword))
            {
                query += " AND (id_phong LIKE @KeyWord OR tenphong LIKE @KeyWord OR giaphong LIKE @KeyWord OR tinhtrang LIKE @KeyWord)";
            }

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // 1. Tham số hóa Id Chủ trọ
                cmd.Parameters.AddWithValue("@Id_ChuTro", idChuTro);

                // 2. Tham số hóa KeyWord CHỈ KHI CÓ TỪ KHÓA
                if (!string.IsNullOrEmpty(trimmedKeyword))
                {
                    cmd.Parameters.AddWithValue("@KeyWord", "%" + trimmedKeyword + "%");
                }

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listPhong.Add(MapToPhongTro(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Tốt nhất là ném lại ngoại lệ hoặc xử lý log chi tiết
                    Console.WriteLine("SQL Error (SearchPhongTro): " + ex.Message);
                }
            }
            return listPhong;
        }

        // 3. UPDATE: Cập nhật Phòng trọ
        public bool UpdatePhong(PhongTro objPhong)
        {
            String query = "UPDATE phongtro SET tenphong = @tenphong, " +
                   "giaphong = @giaphong, tinhtrang = @tinhtrang WHERE id_phong = @id_phong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
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

        public bool UpdateTrangThaiPhong(int idPhong, string trangthai)
        {
            string query = "UPDATE phongtro SET tinhtrang = @tinhtrang WHERE id_phong = @id_phong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_phong", idPhong);
                cmd.Parameters.AddWithValue("@tinhtrang", trangthai);
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
        public bool DeletePhong(int idChuTro, int idPhong)
        {
            string query = "DELETE FROM phongtro WHERE id_phong = @id_phong AND id_chutro = @id_chutro";
            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_phong", idPhong);
                cmd.Parameters.AddWithValue("@id_chutro", idChuTro);
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
    }
}
