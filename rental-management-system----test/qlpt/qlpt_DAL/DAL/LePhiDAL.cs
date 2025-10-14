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
            // SỬA: Loại bỏ id_lephi khỏi INSERT và thêm SELECT SCOPE_IDENTITY() để lấy ID mới
            string query = "INSERT INTO lephi (ngaytao, tienphong, tiendv, thanhtien_lephi) " +
                           "VALUES (@ngaytao, @tienphong, @tiendv, @thanhtien_lephi); " +
                           "SELECT SCOPE_IDENTITY();"; // Lấy ID vừa tạo

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // SỬA: Loại bỏ tham số @id_lephi
                cmd.Parameters.AddWithValue("@ngaytao", objLePhi.NgayTao);
                cmd.Parameters.AddWithValue("@tienphong", objLePhi.TienPhong);
                cmd.Parameters.AddWithValue("@tiendv", objLePhi.TienDv);
                cmd.Parameters.AddWithValue("@thanhtien_lephi", objLePhi.ThanhTien_LePhi);

                try
                {
                    conn.Open();
                    // ExecuteScalar trả về ID mới (decimal, cần Convert)
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

        // 2. Read: Lấy tất cả bản ghi lệ phí theo Chủ trọ (Cần thiết cho BLL)
        public List<LePhi> GetAllLePhi(int idChuTro)
        {
            List<LePhi> listLePhi = new List<LePhi>();
            //JOIN với HoaDon và PhongTro để lọc theo id_ChuTro
            string query = @"
                SELECT lp.* FROM lephi lp
                INNER JOIN HoaDon hd ON lp.id_lephi = hd.id_lephi
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
                            LePhi objLePhi = new LePhi
                            {
                                Id_LePhi = reader.GetInt32(reader.GetOrdinal("id_lephi")),
                                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                                TienPhong = reader.GetDecimal(reader.GetOrdinal("tienphong")),
                                TienDv = reader.GetDecimal(reader.GetOrdinal("tiendv")),
                                //Thanhtien_lephi được tính toán sẵn không cần lấy
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

        // 3. Update: cập nhật bản ghi lệ phí
        public bool UpdateLePhi(LePhi objLePhi)
        {
            // SỬA: Sửa tên bảng từ nuoc thành lephi, loại bỏ cập nhật id_lephi, thêm dấu phẩy
            string query = "UPDATE lephi SET ngaytao = @ngaytao, tienphong = @tienphong, tiendv = @tiendv, " +
                           "thanhtien_lephi = @thanhtien_lephi WHERE id_lephi = @id_lephi";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_lephi", objLePhi.Id_LePhi);
                cmd.Parameters.AddWithValue("@ngaytao", objLePhi.NgayTao);
                cmd.Parameters.AddWithValue("@tienphong", objLePhi.TienPhong);
                cmd.Parameters.AddWithValue("@tiendv", objLePhi.TienDv);
                cmd.Parameters.AddWithValue("@thanhtien_lephi", objLePhi.ThanhTien_LePhi);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateLePhi): " + ex.Message);
                    return false;
                }
            }
        }

        // 4. Delete: Xóa bản ghi lệ phí
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