using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DAL.DAL
{
    public class ThanhToanDAL
    {
        private ConnectDAL connectDB = new ConnectDAL();

        // 1. CREATE: Ghi nhận Thanh Toán (thay đổi trạng thái Hóa đơn)
        public bool InsertThanhToan(ThanhToan objThanhToan)
        {
            // Chỉ cần chèn vào bảng ThanhToan (bảng quan hệ M-N)
            string query = "INSERT INTO thanhtoan (id_hoadon, id_nguoithue, ngaythanhtoan) VALUES (@id_hoadon, @id_nguoithue, @ngaythanhtoan)";

            using (SqlConnection conn = connectDB.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Tham số hóa
                cmd.Parameters.AddWithValue("@id_hoadon", objThanhToan.Id_HoaDon);
                cmd.Parameters.AddWithValue("@id_nguoithue", objThanhToan.Id_NguoiThue);
                cmd.Parameters.AddWithValue("@ngaythanhtoan", objThanhToan.NgayThanhToan);

                try
                {
                    conn.Open();
                    // Nếu chèn thành công bản ghi vào bảng ThanhToan
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex) { Console.WriteLine("SQL Error (InsertThanhToan): " + ex.Message); return false; }
            }
        }
    }
}
