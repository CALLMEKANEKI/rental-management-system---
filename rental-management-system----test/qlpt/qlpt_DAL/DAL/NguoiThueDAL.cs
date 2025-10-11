
using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class NguoiThueDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        //1. Create: Thêm người thuê mới
        public int InsertNguoiThue(NguoiThue objNguoiThue)
        {
            string query = "INSERT INTO nguoithue (id_phong, hoten, cccd, sdt, email, taikhoan, matkhau) " +
                            "OUTPUT INSERTED.id_nguoithue" +
                           "VALUES (@id_phong, @hoten, @cccd, @sdt, @email, @taikhoan, @matkhau);";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa dữ liệu. Sử dụng DBNull.Value cho các trường có thể NULL
                cmd.Parameters.AddWithValue("@id_phong", objNguoiThue.Id_Phong);
                cmd.Parameters.AddWithValue("@hoten", objNguoiThue.HoTen);
                cmd.Parameters.AddWithValue("@cccd", objNguoiThue.Cccd);
                cmd.Parameters.AddWithValue("@sdt", objNguoiThue.Sdt);
                cmd.Parameters.AddWithValue("@email", objNguoiThue.Email);

                try
                {
                    conn.Open();
                    // Lấy ID tự tăng vừa được tạo
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertNguoiThue): " + ex.Message);
                    return -1;
                }
            }
        }

        // 2. READ: Hàm Đăng nhập (Login)
        public NguoiThue Login(string taiKhoan, string matKhau)
        {
            NguoiThue objNguoiThue = null;

            // LƯU Ý: Không trả về mật khẩu. Chỉ lấy các thông tin cần thiết.
            string query = "SELECT id_nguoithue, id_phong, hoten, cccd, sdt, email, taikhoan " +
                           "FROM nguoithue WHERE taikhoan = @taikhoan AND matkhau = @matkhau";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa để ngăn chặn SQL Injection
                cmd.Parameters.AddWithValue("@taikhoan", taiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", matKhau);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Ánh xạ dữ liệu từ CSDL sang đối tượng NguoiThue
                            objNguoiThue = new NguoiThue
                            {
                                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("id_nguoithue")),
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                                Cccd = reader.GetString(reader.GetOrdinal("cccd")),
                                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                TaiKhoan = reader.GetString(reader.GetOrdinal("taikhoan"))
                                // KHÔNG gán mật khẩu vào đây. Đảm bảo tính bảo mật
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Ghi lại lỗi CSDL 
                    Console.WriteLine("SQL Error (Login): " + ex.Message);
                    // Trả về null nếu có lỗi
                }
            }
            // Trả về đối tượng ChuTro (nếu thành công) hoặc null (nếu thất bại)
            return objNguoiThue;
        }

        //2.2.Read: Kiểm tra tài khoản có tồn tại hay chưa
        public bool IsTaiKhoanDaTonTai(string taiKhoan)
        {
            string query = "SELECT COUNT(*) FROM nguoithue WHERE taikhoan = @taikhoan";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@taikhoan", taiKhoan);
                try
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    // Nếu count > 0, nghĩa là tài khoản đã tồn tại
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (IsTaiKhoanDaTonTai): " + ex.Message);
                    // Giả định là đã tồn tại nếu có lỗi CSDL
                    return true;
                }
            }
        }


        //2.3. READ: Lấy danh sách Người Thuê theo ID Phòng
        public List<NguoiThue> GetNguoiThueByPhong(int idPhong)
        {
            List<NguoiThue> list = new List<NguoiThue>();
            string query = "SELECT id_nguoithue, id_phong, hoten, cccd, sdt, email FROM nguoithue WHERE id_phong = @id_phong";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_phong", idPhong);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new NguoiThue
                            {
                                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("id_nguoithue")),
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                                Cccd = reader.GetString(reader.GetOrdinal("cccd")),
                                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                                Email = reader.GetString(reader.GetOrdinal("email"))
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetNguoiThueByPhong): " + ex.Message);
                }
            }
            return list;
        }

        //2.4.Read: Lấy tất cả người thuê
        public List<NguoiThue> GetAllNguoiThue()
        {
            List<NguoiThue> listNguoiThue = new List<NguoiThue>();
            string query = "SELECT id_nguoithue, id_phong, hoten, cccd, sdt ,email , taikhoan, matkhau FROM nguoithue";
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
                            NguoiThue objNguoiThue = new NguoiThue
                            {
                                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("id_nguoithue")),
                                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                                Cccd = reader.GetString(reader.GetOrdinal("cccd")),
                                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                                Email = reader.IsDBNull(reader.GetOrdinal("email"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("email")),
                                TaiKhoan = reader.GetString(reader.GetOrdinal("taikhoan")),
                                MatKhau = reader.GetString(reader.GetOrdinal("matkhau"))
                            };
                            listNguoiThue.Add(objNguoiThue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllPhong): " + ex.Message);
                }
            }
            return listNguoiThue;
        }

        //3. UPDATE: cập nhật thông tin người thuê
        public bool UpdateNguoiThue(NguoiThue objNguoiThue)
        {
            string query = "UPDATE nguoithue SET id_phong = @id_phong, hoten = @hoten, cccd = @cccd, " +
                           "sdt = @sdt, email = @email, taikhoan = @taikhoan, matkhau = @matkhau WHERE id_nguoithue = @id_nguoithue";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_phong", objNguoiThue.Id_Phong);
                cmd.Parameters.AddWithValue("@hoten", objNguoiThue.HoTen);
                cmd.Parameters.AddWithValue("@cccd", objNguoiThue.Cccd);
                cmd.Parameters.AddWithValue("@sdt", objNguoiThue.Sdt);
                cmd.Parameters.AddWithValue("@email", objNguoiThue.Email);
                cmd.Parameters.AddWithValue("@taikhoan", (object)objNguoiThue.TaiKhoan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@matkhau", (object)objNguoiThue.MatKhau ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id_nguoithue", objNguoiThue.Id_NguoiThue);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateNguoiThue): " + ex.Message);
                    return false;
                }
            }
        }

        //3.2.Update: Cập nhật mật khẩu
        public bool UpdateMatKhau(NguoiThue objNguoiThue, string NewPass)
        {
            string query = "UPDATE nguoithue SET matkhau = @NewPass WHERE id_nguoithue = @id_nguoithue";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NewPass", objNguoiThue.MatKhau);
                cmd.Parameters.AddWithValue("@id_nguoithue", objNguoiThue.Id_NguoiThue);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateMatKhauChuTro): " + ex.Message);
                    return false;
                }
            }
        }

        //4. DELETE: Xóa Người Thuê
        public bool DeleteNguoiThue(int idNguoiThue)
        {
            // Lưu ý: Nếu người thuê này còn hợp đồng hoặc hóa đơn chưa thanh toán, lệnh này sẽ thất bại (lỗi khóa ngoại).
            string query = "DELETE FROM nguoithue WHERE id_nguoithue = @id_nguoithue";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_nguoithue", idNguoiThue);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteNguoiThue): " + ex.Message);
                    return false;
                }
            }
        }

        
    }
}
