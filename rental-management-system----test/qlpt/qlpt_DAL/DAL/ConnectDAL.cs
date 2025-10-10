using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration; // Đảm bảo đã cài đặt gói NuGet System.Configuration.ConfigurationManager

namespace qlpt_DAL.DAL
{
    public class ConnectDAL
    {
        // Thuộc tính private để lưu chuỗi kết nối đã đọc được
        private string connectionString;

        // Hàm khởi tạo: Đọc chuỗi kết nối ngay khi lớp được tạo
        public ConnectDAL()
        {
            try
            {
                // Lấy đối tượng cấu hình chuỗi kết nối có tên "QLPT_DB"
                // Đã sửa lỗi chính tả tại đây: từ 'connectionString' thành 'ConnectionStringSettings'
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["QLPT_DB"];

                if (settings != null)
                {
                    this.connectionString = settings.ConnectionString;
                }
                else
                {
                    Console.WriteLine("Lỗi cấu hình: Không tìm thấy chuỗi kết nối 'QLPT_DB'.");
                    this.connectionString = null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi đọc file cấu hình
                Console.WriteLine($"Lỗi khi đọc file App.config: {ex.Message}");
                this.connectionString = null;
            }
        }

        // PHƯƠNG THỨC CHÍNH: Cung cấp đối tượng SqlConnection cho các lớp DAL khác
        public SqlConnection GetConnection()
        {
            // Kiểm tra tính hợp lệ trước khi tạo đối tượng
            if (string.IsNullOrEmpty(this.connectionString))
            {
                throw new InvalidOperationException("Không thể tạo kết nối. Chuỗi kết nối không hợp lệ hoặc không tồn tại.");
            }

            // Trả về một đối tượng kết nối MỚI
            return new SqlConnection(this.connectionString);
        }
    }
}