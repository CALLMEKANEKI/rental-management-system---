using qlpt_DTO.Models;
using qlpt_DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace qlpt_DAL.DAL
{
    public class HopDongDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();
        
        //CREATE 
        public int InsertHopDong(HopDong objHopDong)
        {
            string query = "INSERT INTO HopDong (Id_Phong, Id_NguoiThue, NgayBatDau, NgayKetThuc, TienCoc) " +
                           "VALUES (@Id_Phong, @Id_NguoiThue, @NgayBatDau, @NgayKetThuc, @TienCoc); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Không cần Id_ChuTro vì nó được xác định qua Id_Phong
                cmd.Parameters.AddWithValue("@Id_Phong", objHopDong.Id_Phong);
                cmd.Parameters.AddWithValue("@Id_NguoiThue", objHopDong.Id_NguoiThue);
                cmd.Parameters.AddWithValue("@NgayBatDau", objHopDong.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", objHopDong.NgayKetThuc);
                cmd.Parameters.AddWithValue("@TienCoc", objHopDong.TienCoc);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertHopDong): " + ex.Message);
                    return -1;
                }
            }
        }
        // Hàm ánh xạ chung từ SqlDataReader sang NguoiThue Model (chỉ dùng READ)

        private HopDong MapToHopDong(SqlDataReader reader)
        {
            return new HopDong
            {
                Id_HopDong = reader.GetInt32(reader.GetOrdinal("Id_HopDong")),
                NgayBatDau = reader.GetDateTime(reader.GetOrdinal("NgayBatDau")),
                NgayKetThuc = reader.GetDateTime(reader.GetOrdinal("NgayKetThuc")),
                TienCoc = reader.GetDecimal(reader.GetOrdinal("TienCoc")),

                // Khóa ngoại
                Id_Phong = reader.GetInt32(reader.GetOrdinal("Id_Phong")),
                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("Id_NguoiThue")),
                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("Id_ChuTro")), // Lấy từ JOIN
            };
        }

        private HopDongViewModel MapToViewModel(SqlDataReader reader)
        {
            return new HopDongViewModel
            {
                Id_HopDong = reader.GetInt32(reader.GetOrdinal("Id_HopDong")),
                NgayBatDau = reader.GetDateTime(reader.GetOrdinal("NgayBatDau")),
                NgayKetThuc = reader.GetDateTime(reader.GetOrdinal("NgayKetThuc")),
                TienCoc = reader.GetDecimal(reader.GetOrdinal("TienCoc")),

                // Khóa ngoại
                Id_Phong = reader.GetInt32(reader.GetOrdinal("Id_Phong")),
                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("Id_NguoiThue")),
                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("Id_ChuTro")), // Lấy từ JOIN

                // Các cột hiển thị (ViewModel)
                TenPhongHienThi = reader.GetString(reader.GetOrdinal("TenPhongHienThi")),
                TenNguoiThueHienThi = reader.GetString(reader.GetOrdinal("TenNguoiThueHienThi")),
                CccdHienThi = reader.GetString(reader.GetOrdinal("CccdHienThi")),
                SdtHienThi = reader.GetString(reader.GetOrdinal("SdtHienThi")),
                TenChuTroHienThi = reader.GetString(reader.GetOrdinal("TenChuTroHienThi"))
            };
        }

        private List<HopDongViewModel> ExecuteQueryAndMap(string query, params SqlParameter[] parameters)
        {
            List<HopDongViewModel> listContract = new List<HopDongViewModel>();

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listContract.Add(MapToViewModel(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (ExecuteQueryAndMap): " + ex.Message);
                }
            }
            return listContract;
        }

        // --- READ / SEARCH ---
        private string BaseSelectQuery = @"
        SELECT 
            hd.*, 
            pt.TenPhong AS TenPhongHienThi, 
            nt.HoTen AS TenNguoiThueHienThi, 
            nt.Cccd AS CccdHienThi, 
            nt.Sdt AS SdtHienThi,
            pt.Id_ChuTro,
            ct.HoTen AS TenChuTroHienThi
        FROM HopDong hd
        INNER JOIN PhongTro pt ON hd.Id_Phong = pt.Id_Phong
        INNER JOIN NguoiThue nt ON hd.Id_NguoiThue = nt.Id_NguoiThue
        INNER JOIN ChuTro ct ON pt.Id_ChuTro = ct.Id_ChuTro ";

        //Lấy tất cả hợp đồng (list<ViewModel>)
        public List<HopDongViewModel> GetAllHopDongViewModel(int idChuTro)
        {
            string query = BaseSelectQuery + " WHERE pt.Id_ChuTro = @Id_ChuTro";
            return ExecuteQueryAndMap(query, new SqlParameter("@Id_ChuTro", idChuTro));
        }

        //Lấy tất cả hợp đồng theo keyword 
        public List<HopDongViewModel> GetAllHopDongViewModelByKeyWord(int idChuTro, string keyword)
        {
            string query = BaseSelectQuery + @" 
             WHERE pt.Id_ChuTro = @Id_ChuTro 
             AND (
                        pt.TenPhong LIKE @Keyword OR 
                        nt.HoTen LIKE @Keyword OR 
                        CONVERT(NVARCHAR, hd.id_hopdong) LIKE @Keyword OR 
                        CONVERT(NVARCHAR, hd.TienCoc) LIKE @Keyword OR
                        CONVERT(NVARCHAR, nt.Cccd) LIKE @Keyword OR
                        CONVERT(NVARCHAR, nt.Sdt) LIKE @Keyword OR
                         CONVERT(NVARCHAR, hd.NgayBatDau, 103) LIKE @Keyword OR
                         CONVERT(NVARCHAR, hd.NgayKetThuc, 103) LIKE @Keyword
            )";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_ChuTro", idChuTro),
            new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            return ExecuteQueryAndMap(query, parameters);
        }

        public List<HopDongViewModel> GetActiveHopDongByRoomId(int idPhong)
        {
            // CHỈ LẤY CÁC HỢP ĐỒNG MÀ NGÀY KẾT THÚC CHƯA ĐẾN
            string query = BaseSelectQuery + @" 
                            WHERE hd.Id_Phong = @Id_Phong
                            AND (hd.NgayKetThuc IS NULL OR hd.NgayKetThuc >= GETDATE())";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id_Phong", idPhong)
            };

            return ExecuteQueryAndMap(query, parameters);
        }



        //UPDATE
        public bool UpdateHopDong(HopDong objHopDong)
        {
            string query = "UPDATE HopDong SET Id_Phong = @Id_Phong, Id_NguoiThue = @Id_NguoiThue, " +
                           "NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, TienCoc = @TienCoc " +
                           "WHERE Id_HopDong = @Id_HopDong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id_Phong", objHopDong.Id_Phong);
                cmd.Parameters.AddWithValue("@Id_NguoiThue", objHopDong.Id_NguoiThue);
                cmd.Parameters.AddWithValue("@NgayBatDau", objHopDong.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", objHopDong.NgayKetThuc);
                cmd.Parameters.AddWithValue("@TienCoc", objHopDong.TienCoc);
                cmd.Parameters.AddWithValue("@Id_HopDong", objHopDong.Id_HopDong);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateHopDong): " + ex.Message);
                    return false;
                }
            }
        }

        //DELETE
        public bool DeleteHopDong(int idHopDong)
        {
            string query = "DELETE FROM HopDong WHERE Id_HopDong = @Id_HopDong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id_HopDong", idHopDong);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteHopDong): " + ex.Message);
                    return false;
                }
            }
        }        
    }
}