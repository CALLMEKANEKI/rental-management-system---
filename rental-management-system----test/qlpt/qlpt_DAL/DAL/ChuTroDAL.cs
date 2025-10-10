
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
       // READ: Hàm Đăng nhập (Login)
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

        public int InsertChuTro(ChuTro objChuTro)
        {
            // Sử dụng SCOPE_IDENTITY() để lấy ID tự tăng vừa được tạo
            string query = "INSERT INTO chutro (hoten, sdt, email, diachi, taikhoan, matkhau) " +
                           "VALUES (@hoten, @sdt, @email, @diachi, @taikhoan, @matkhau); SELECT SCOPE_IDENTITY();";

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

        //4. Get: Lấy chủ trọ theo ID
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
    }
}
