
using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class ChuTroDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        //1. Insert: Thêm chủ trọ
        public int InsertChuTro(ChuTro objChuTro)
        {
            string query = "INSERT INTO chutro (hoten, sdt, email, diachi, taikhoan, matkhau) " +
                            "OUTPUT INSERTED.id_chutro " +
                           "VALUES (@hoten, @sdt, @email, @diachi, @taikhoan, @matkhau);";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa dữ liệu
                cmd.Parameters.AddWithValue("@hoten", objChuTro.HoTen);
                cmd.Parameters.AddWithValue("@sdt", objChuTro.Sdt);

                // Sử dụng DBNull.Value nếu các trường này có thể NULL trong CSDL
                cmd.Parameters.AddWithValue("@email", (object)objChuTro.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@diachi", (object)objChuTro.DiaChi ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@taikhoan", objChuTro.TaiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", objChuTro.MatKhau);
                // LƯU Ý QUAN TRỌNG: Mật khẩu nên được HASHING ở tầng BLL trước khi truyền vào đây!

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    // Trả về ID Chủ trọ mới được tạo
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (InsertChuTro): " + ex.Message);
                    // Có thể trả về mã lỗi đặc biệt nếu lỗi là do trùng lặp tài khoản
                    return -1;
                }
            }
        }

        //2.1.READ: Hàm Đăng nhập (Login)
        public ChuTro Login(string taiKhoan, string matKhau)
        {
            ChuTro objChuTro = null;

            // LƯU Ý: Không trả về mật khẩu. Chỉ lấy các thông tin cần thiết.
            string query = "SELECT id_chutro, hoten, sdt, email, diachi, taikhoan " +
                           "FROM chutro WHERE taikhoan = @taikhoan AND matkhau = @matkhau";

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
                            // Ánh xạ dữ liệu từ CSDL sang đối tượng ChuTro
                            objChuTro = new ChuTro
                            {
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                DiaChi = reader.GetString(reader.GetOrdinal("diachi")),
                                TaiKhoan = reader.GetString(reader.GetOrdinal("taikhoan"))
                                // KHÔNG gán mật khẩu vào đây
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Ghi lại lỗi CSDL (ví dụ: mất kết nối)
                    Console.WriteLine("SQL Error (Login): " + ex.Message);
                    // Trả về null nếu có lỗi
                }
            }
            // Trả về đối tượng ChuTro (nếu thành công) hoặc null (nếu thất bại)
            return objChuTro;
        }

        //2.2.Read: Kiểm tra tài khoản có tồn tại hay chưa
        public bool IsTaiKhoanDaTonTai(string taiKhoan)
        {
            string query = "SELECT COUNT(*) FROM chutro WHERE taikhoan = @taikhoan";

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
        

        //2.3. Read: Lấy chủ trọ theo ID
        public ChuTro GetChuTroById(int idChuTro)
        {
            ChuTro objChuTro = null;
            string query = "SELECT * FROM chutro WHERE id_chutro = @id_chutro";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_chutro", idChuTro);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objChuTro = new ChuTro
                            {
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                                DiaChi = reader.IsDBNull(reader.GetOrdinal("diachi")) ? null : reader.GetString(reader.GetOrdinal("diachi")),
                                TaiKhoan = reader.GetString(reader.GetOrdinal("taikhoan")),
                                MatKhau = reader.GetString(reader.GetOrdinal("matkhau"))
                            };
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("SQL Error (GetChuTroById): " + ex.Message); }
            }
            return objChuTro;
        }
        //2.4. Read: Lấy toàn bộ chủ trọ 
        public List<ChuTro> GetAllChuTro()
        {
            List<ChuTro> listChuTro = new List<ChuTro>();
            string query = "SELECT * FROM chutro";
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
                            ChuTro objChuTro = new ChuTro
                            {
                                Id_ChuTro = reader.GetInt32(reader.GetOrdinal("id_chutro")),
                                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                                DiaChi = reader.GetString(reader.GetOrdinal("diachi")),
                                Email = reader.IsDBNull(reader.GetOrdinal("email"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("email")),
                                TaiKhoan = reader.GetString(reader.GetOrdinal("taikhoan")),
                                MatKhau = reader.GetString(reader.GetOrdinal("matkhau"))
                            };
                            listChuTro.Add(objChuTro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllPhong): " + ex.Message);
                }
            }
            return listChuTro;
        }

        //3.1 Update: Cật nhật thông tin chủ trọ (trừ mật khẩu)
        public bool UpdateChuTro(ChuTro objChuTro)
        {
            string query = "UPDATE chutro SET hoten = @hoten, sdt = @sdt, " +
                           " email = @email, diachi =@diachi WHERE id_chutro = @id_chutro";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_chutro", objChuTro.Id_ChuTro);
                cmd.Parameters.AddWithValue("@hoten", objChuTro.HoTen);
                cmd.Parameters.AddWithValue("@sdt", objChuTro.Sdt);
                cmd.Parameters.AddWithValue("@email", objChuTro.Email);
                cmd.Parameters.AddWithValue("@diachi", objChuTro.DiaChi);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (UpdateChuTro): " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateMatKhau(ChuTro objChuTro, string NewPass)
        {
            string query = "UPDATE chutro SET matkhau = @NewPass WHERE id_chutro = @id_chutro";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NewPass", objChuTro.MatKhau);
                cmd.Parameters.AddWithValue("@id_chutro", objChuTro.Id_ChuTro);
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

        //4.Delete: Xóa chủ trọ
        public bool DeleteChuTro(int idChuTro)
        {
            string query = "DELETE FROM chutro WHERE id_chutro = @id_chutro";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_chutro", idChuTro);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (DeleteChuTro): " + ex.Message);
                    return false;
                }
            }
        }
    }
}
