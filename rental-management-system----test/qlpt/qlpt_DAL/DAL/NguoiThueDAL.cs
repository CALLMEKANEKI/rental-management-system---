
using qlpt_DTO.Models;
using qlpt_DTO.ViewModel;
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
        // Hàm ánh xạ chung từ SqlDataReader sang NguoiThue Model (chỉ dùng READ)
        private NguoiThue MapToNguoiThue(SqlDataReader reader, bool includePassword = false)
        {
            NguoiThue objNguoiThue = new NguoiThue
            {
                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("id_nguoithue")),
                Id_Phong = reader.GetInt32(reader.GetOrdinal("id_phong")),
                HoTen = reader.GetString(reader.GetOrdinal("hoten")),
                Cccd = reader.GetString(reader.GetOrdinal("cccd")),
                Sdt = reader.GetString(reader.GetOrdinal("sdt")),
                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                TaiKhoan = reader.IsDBNull(reader.GetOrdinal("taikhoan")) ? null : reader.GetString(reader.GetOrdinal("taikhoan"))
            };

            // Chỉ lấy mật khẩu khi được yêu cầu (thường là cho logic login)
            if (includePassword && !reader.IsDBNull(reader.GetOrdinal("matkhau")))
            {
                objNguoiThue.MatKhau = reader.GetString(reader.GetOrdinal("matkhau"));
            }
            return objNguoiThue;
        }

        private NguoiThueViewModel MapToViewModel(SqlDataReader reader)
        {
            // Lấy chỉ mục cột để tối ưu hóa và kiểm tra IsDBNull an toàn
            int emailOrdinal = reader.GetOrdinal("Email");
            int taikhoanOrdinal = reader.GetOrdinal("TaiKhoan");
            int matkhauOrdinal = reader.GetOrdinal("MatKhau");
            int tenPhongOrdinal = reader.GetOrdinal("TenPhong");

            return new NguoiThueViewModel
            {
                Id_NguoiThue = reader.GetInt32(reader.GetOrdinal("Id_NguoiThue")),
                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                Cccd = reader.GetString(reader.GetOrdinal("Cccd")),
                Sdt = reader.GetString(reader.GetOrdinal("Sdt")),
                Id_Phong = reader.GetInt32(reader.GetOrdinal("Id_Phong")),

                // Xử lý NULL an toàn cho các trường có thể NULL trong DB
                Email = reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal),
                TaiKhoan = reader.IsDBNull(taikhoanOrdinal) ? null : reader.GetString(taikhoanOrdinal),
                MatKhau = reader.IsDBNull(matkhauOrdinal) ? null : reader.GetString(matkhauOrdinal),

                // Xử lý NULL cho cột JOIN (TenPhong)
                TenPhongHienThi = reader.IsDBNull(tenPhongOrdinal) ? string.Empty : reader.GetString(tenPhongOrdinal)
            };
        }

        // 2. READ: Hàm Đăng nhập (Login)
        public NguoiThue Login(string taiKhoan, string matkhau)
        {
            NguoiThue objNguoiThue = null;
            string query = "SELECT id_nguoithue, id_phong, hoten, cccd, sdt, email, taikhoan, matkhau " +
                           "FROM nguoithue WHERE taikhoan = @taikhoan and matkhau = @matkhau";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@taikhoan", taiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", matkhau);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objNguoiThue = MapToNguoiThue(reader, true);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (GetNguoiThueByTaiKhoan): " + ex.Message);
                }
            }
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

        //2.3.Read: Lấy tất cả người thuê
        public List<NguoiThue> GetAllNguoiThue(int idChuTro)
        {
            List<NguoiThue> listNguoiThue = new List<NguoiThue>();

            //Thêm JOIN và WHERE để lọc theo id_chutro
            string query = "SELECT nt.id_nguoithue, nt.id_phong, nt.hoten, nt.cccd, nt.sdt, nt.email, nt.taikhoan, nt.matkhau " +
                           "FROM nguoithue nt " +
                           "INNER JOIN phongtro pt ON nt.id_phong = pt.id_phong " + // JOIN để lấy id_chutro
                           "WHERE pt.id_chutro = @id_chutro"; // LỌC theo ID của Chủ trọ đang đăng nhập

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //Tham số hóa ID Chủ trọ được truyền vào hàm
                cmd.Parameters.AddWithValue("@id_chutro", idChuTro);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listNguoiThue.Add(MapToNguoiThue(reader, true));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (GetAllNguoiThue): " + ex.Message);
                }
            }
            return listNguoiThue;
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
                            list.Add( MapToNguoiThue(reader, true));
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

        

        //2.5 Lấy người thuê theo id

        public NguoiThue GetNguoiThueById(int idNguoiThue)
        {
            string query = "SELECT id_nguoithue, id_phong, hoten, cccd, sdt, email, taikhoan, matkhau " +
                           "FROM nguoithue WHERE id_nguoithue = @id_nguoithue";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_nguoithue", idNguoiThue);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToNguoiThue(reader, true);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error (GetNguoiThueById): " + ex.Message);
                }
            }
            return null;
        }

        //2.5 Lấy tất cả khách thuê ViewModel theo keyword
        public List<NguoiThueViewModel> GetAllNguoiThueVewModelByKeyWord(int idChuTro, string keyword)
        {
            List<NguoiThueViewModel> listGuest = new List<NguoiThueViewModel>();

            // Đảm bảo từ khóa sạch và kiểm tra NULL/rỗng
            string trimmedKeyword = keyword?.Trim() ?? string.Empty;

            // 1. CÂU TRUY VẤN CƠ SỞ: Chỉ lọc theo Id_ChuTro (Không có điều kiện tìm kiếm ban đầu)
            string query = @"
    SELECT nt.*, pt.tenphong 
    FROM NguoiThue nt 
    INNER JOIN PhongTro pt ON nt.id_phong = pt.id_phong
    WHERE pt.id_chutro = @id_chuTro";

            // Khởi tạo danh sách tham số (CHỈ sử dụng List này để thêm vào cmd)
            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@id_chuTro", idChuTro)
    };

            // 2. LOGIC ĐIỀU KIỆN: Chỉ thêm mệnh đề tìm kiếm nếu có từ khóa
            if (!string.IsNullOrEmpty(trimmedKeyword))
            {
                query += @" AND(
    CONVERT(NVARCHAR, nt.id_nguoithue) LIKE '%' + @keyword + '%'
    OR nt.hoten LIKE '%' + @keyword + '%'
    OR nt.cccd LIKE '%' + @keyword + '%'
    OR nt.sdt LIKE '%' + @keyword + '%'
    OR nt.email LIKE '%' + @keyword + '%'
    OR nt.taikhoan LIKE '%' + @keyword + '%'
    OR pt.tenphong LIKE '%' + @keyword + '%'
)";

                // Thêm tham số keyword vào danh sách
                parameters.Add(new SqlParameter("@keyword", "%" + trimmedKeyword + "%"));
            }

            // 3. THỰC THI TRUY VẤN
            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // === SỬA LỖI QUAN TRỌNG: Sử dụng mảng tham số đã được chuẩn bị ===
                cmd.Parameters.AddRange(parameters.ToArray());
                // =================================================================

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listGuest.Add(MapToViewModel(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error (Search NguoiThue ViewModel): " + ex.Message);
                }
            }
            return listGuest;
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
                cmd.Parameters.AddWithValue("@NewPass", NewPass);
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
