using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace qlpt_DAL.DAL
{
    public class HopDongDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // 1. CREATE: Tạo Hợp Đồng Mới (và lấy ID vừa tạo)
        public int CreateHopDong(HopDong objHopDong)
        {
            // LƯU Ý: id_hopdong là tự tăng 
            string query = "INSERT INTO hopdong (id_phong, id_chutro, id_nguoithue, ngaybatdau, ngayketthuc, tiencoc) " +
                           "VALUES (@id_phong, @id_chutro, @id_nguoithue, @ngaybatdau, @ngayketthuc, @tiencoc); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_phong", objHopDong.Id_Phong);
                cmd.Parameters.AddWithValue("@id_chutro", objHopDong.Id_ChuTro);
                cmd.Parameters.AddWithValue("@id_nguoithue", objHopDong.Id_NguoiThue);
                cmd.Parameters.AddWithValue("@ngaybatdau", objHopDong.NgayBatDau);
                cmd.Parameters.AddWithValue("@ngayketthuc", objHopDong.NgayKetThuc);
                cmd.Parameters.AddWithValue("@tiencoc", objHopDong.TienCoc);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (TaoHopDongMoi): " + ex.Message);
                    return -1; // Thất bại
                }
            }
        }

        // 2. READ: Lấy Hợp Đồng đang có hiệu lực theo ID Phòng
        public HopDong GetHopDongHienTaiByPhongId(int idPhong)
        {
            HopDong objHopDong = null;
            // Tìm hợp đồng có id_phong khớp và ngày kết thúc lớn hơn hoặc bằng ngày hiện tại
            string query = "SELECT * FROM hopdong WHERE id_phong = @id_phong AND ngayketthuc >= GETDATE() ORDER BY ngaybatdau DESC";

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
                            objHopDong = new HopDong
                            {
                                Id_HopDong = reader.GetInt32(reader.GetOrdinal("id_hopdong")),
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("id_nguoithue")),
                                NgayBatDau = reader.GetDateTime(reader.GetOrdinal("ngaybatdau")),
                                NgayKetThuc = reader.GetDateTime(reader.GetOrdinal("ngayketthuc")),
                                TienCoc = reader.GetDecimal(reader.GetOrdinal("tiencoc"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetHopDongHienTaiByPhongId): " + ex.Message);
                }
            }
            return objHopDong;
        }

        // 3. UPDATE: Cập nhật Ngày kết thúc Hợp đồng (Chấm dứt HĐ)
        public bool shutdownHopDong(int idHopDong, DateTime ngayKetThucThucTe)
        {
            // Cập nhật ngày kết thúc thực tế cho hợp đồng
            string query = "UPDATE hopdong SET ngayketthuc = @ngayketthuc WHERE id_hopdong = @id_hopdong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ngayketthuc", ngayKetThucThucTe);
                cmd.Parameters.AddWithValue("@id_hopdong", idHopDong);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (KetThucHopDong): " + ex.Message);
                    return false;
                }
            }
        }

        //Read: lấy tất cả hợp đồng
        public List<HopDong> GetAllHopDong()
        {
            List<HopDong> listHopDong = new List<HopDong>();
            string query = "SELECT * FROM hopDong";
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
                            HopDong objHopDong = new HopDong
                            {
                                Id_HopDong = reader.GetInt32(reader.GetOrdinal("id_hopdong")),
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("id_nguoithue")),
                                NgayBatDau = reader.GetDateTime(reader.GetOrdinal("ngaybatdau")),
                                NgayKetThuc = reader.GetDateTime(reader.GetOrdinal("ngayketthuc")),
                                TienCoc = reader.GetDecimal(reader.GetOrdinal("tiencoc"))
                            };
                            listHopDong.Add(objHopDong);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllPhong): " + ex.Message);
                }
            }
            return listHopDong;
        }
    }
}