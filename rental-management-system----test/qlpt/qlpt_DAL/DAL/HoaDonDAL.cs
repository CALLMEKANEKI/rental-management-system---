using qlpt_DTO.Models;
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
                cmd.Parameters.AddWithValue("@noidung", objHoaDon.NoiDung);
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

        //2.1:READ: Lấy tất cả hóa đơn
        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();
            string query = "SELECT * FROM hoadon";
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
                            HoaDon objHoaDon = new HoaDon
                            {
                                Id_HoaDon = reader.GetInt32(reader.GetOrdinal("id_hoadon")),
                                NgayTao = reader.GetDateTime(reader.GetOrdinal("ngaytao")),
                                TrangThai = reader.GetString(reader.GetOrdinal("trangthai")),
                                NoiDung = reader.GetString(reader.GetOrdinal("noidung")),
                                Id_Dien = reader.GetInt32(reader.GetOrdinal("id_dien")),
                                Id_Nuoc = reader.GetInt32(reader.GetOrdinal("id_nuoc")),
                                Id_LePhi = reader.GetInt32(reader.GetOrdinal("id_lephi")),
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                //ThanhTien = reader.GetDecimal(reader.GetOrdinal("thanhtien")),
                            };
                            listHoaDon.Add(objHoaDon);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllPhong): " + ex.Message);
                }
            }
            return listHoaDon;
        }

        //2.2.READ: Lấy hóa đơn theo ID
        public HoaDon GetHoaDonById(int idHoaDon)
        {
            HoaDon objHoaDon = null;
            string query = "SELECT id_lephi, id_dien, id_nuoc FROM hoadon WHERE id_hoadon = @id_hoadon";

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
                            objHoaDon = new HoaDon
                            {
                                Id_LePhi = reader.GetInt32(reader.GetOrdinal("id_lephi")),
                                Id_Dien = reader.GetInt32(reader.GetOrdinal("id_dien")),
                                Id_Nuoc = reader.GetInt32(reader.GetOrdinal("id_nuoc")),
                                // Không cần lấy các trường khác nếu chỉ dùng cho việc xóa
                            };
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("SQL Error (GetHoaDonById): " + ex.Message); }
            }
            return objHoaDon;
        }

        //3.1. UPDATE: Cập nhật trạng thái Hóa đơn
        public bool UpdateTrangThai(int idHoaDon, string trangThaiMoi)
        {
            string query = "UPDATE hoadon SET trangthai = @trangthai WHERE id_hoadon = @id_hoadon";
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

        //3.2. UPDATE: cập nhật thông tin hóa đơn
        public bool UpdateHoaDon(HoaDon objHoaDon)
        {
            string query = "UPDATE hoadon SET id_hoadon = @id_hoadon, ngaytao = @ngaytao, trangthai = @trangthai, noidung = @noidung" +
                           "id_lephi = @id_lephi, id_nuoc = @id_nuoc, id_dien = @id_dien, id_phong, thanhtien = @thanhtien WHERE id_hoadon = @id_hoadon";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_hoadon", objHoaDon.Id_HoaDon);
                cmd.Parameters.AddWithValue("@ngaytao", objHoaDon.NgayTao);
                cmd.Parameters.AddWithValue("@trangthai", objHoaDon.TrangThai);
                cmd.Parameters.AddWithValue("@noidung", objHoaDon.NoiDung);
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

        //4. DELETE: Xóa hóa đơn
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
