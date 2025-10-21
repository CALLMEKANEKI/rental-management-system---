
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlpt.GUI
{
    public partial class QLHOPDONG : Form
    {
        private DataTable dsHopDong;
        public QLHOPDONG()
        {
            InitializeComponent();
        }
        private void FormQLHopDong_Load(object sender, EventArgs e)
        {
            dsHopDong = new DataTable();
            dsHopDong.Columns.Add("Mã hợp đồng");
            dsHopDong.Columns.Add("Chủ trọ");
            dsHopDong.Columns.Add("Khách thuê");
            dsHopDong.Columns.Add("Tên phòng");
            dsHopDong.Columns.Add("Tiền cọc");
            dsHopDong.Columns.Add("Ngày bắt đầu");
            dsHopDong.Columns.Add("Ngày kết thúc");
            dsHopDong.Columns.Add("Ảnh hợp đồng", typeof(byte[])); // ảnh lưu dạng mảng byte

            dtHopDong.DataSource = dsHopDong;
        }

        // ========== NÚT TẢI ẢNH ==========
        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh hợp đồng";
                ofd.Filter = "File ảnh|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picHopDong.Image = Image.FromFile(ofd.FileName);
                    picHopDong.Tag = ofd.FileName; // lưu đường dẫn ảnh tạm
                }
            }
        }

        // ========== NÚT THÊM ==========
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text) ||
                string.IsNullOrWhiteSpace(txtChuTro.Text) ||
                string.IsNullOrWhiteSpace(txtKhachThue.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            byte[] anhData = null;
            if (picHopDong.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picHopDong.Image.Save(ms, picHopDong.Image.RawFormat);
                    anhData = ms.ToArray();
                }
            }

            dsHopDong.Rows.Add(
                txtMaHD.Text,
                txtChuTro.Text,
                txtKhachThue.Text,
                txtTenPhong.Text,
                txtTienCoc.Text,
                dtNgayBatDau.Value.ToShortDateString(),
                dtNgayKetThuc.Value.ToShortDateString(),
                anhData
            );

            ClearInputs();
        }

        // ========== NÚT SỬA ==========
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtHopDong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng để sửa!");
                return;
            }

            DataRow row = ((DataRowView)dtHopDong.CurrentRow.DataBoundItem).Row;
            row["Mã hợp đồng"] = txtMaHD.Text;
            row["Chủ trọ"] = txtChuTro.Text;
            row["Khách thuê"] = txtKhachThue.Text;
            row["Tên phòng"] = txtTenPhong.Text;
            row["Tiền cọc"] = txtTienCoc.Text;
            row["Ngày bắt đầu"] = dtNgayBatDau.Value.ToShortDateString();
            row["Ngày kết thúc"] = dtNgayKetThuc.Value.ToShortDateString();

            if (picHopDong.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picHopDong.Image.Save(ms, picHopDong.Image.RawFormat);
                    row["Ảnh hợp đồng"] = ms.ToArray();
                }
            }

            ClearInputs();
        }

        // ========== NÚT XÓA ==========
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtHopDong.CurrentRow != null)
            {
                dtHopDong.Rows.RemoveAt(dtHopDong.CurrentRow.Index);
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }

        // ========== NÚT LÀM MỚI ==========
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        // ========== CHỌN DÒNG TRONG DATAGRIDVIEW ==========
        private void dtHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtHopDong.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["Mã hợp đồng"].Value?.ToString();
                txtChuTro.Text = row.Cells["Chủ trọ"].Value?.ToString();
                txtKhachThue.Text = row.Cells["Khách thuê"].Value?.ToString();
                txtTenPhong.Text = row.Cells["Tên phòng"].Value?.ToString();
                txtTienCoc.Text = row.Cells["Tiền cọc"].Value?.ToString();

                DateTime ngayBD, ngayKT;
                if (DateTime.TryParse(row.Cells["Ngày bắt đầu"].Value?.ToString(), out ngayBD))
                    dtNgayBatDau.Value = ngayBD;
                if (DateTime.TryParse(row.Cells["Ngày kết thúc"].Value?.ToString(), out ngayKT))
                    dtNgayKetThuc.Value = ngayKT;

                // Hiển thị ảnh
                if (row.Cells["Ảnh hợp đồng"].Value is byte[] imgData)
                {
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        picHopDong.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picHopDong.Image = null;
                }
            }
        }

        // ========== XÓA INPUT ==========
        private void ClearInputs()
        {
            txtMaHD.Clear();
            txtChuTro.Clear();
            txtKhachThue.Clear();
            txtTenPhong.Clear();
            txtTienCoc.Clear();
            picHopDong.Image = null;
            picHopDong.Tag = null;
            dtNgayBatDau.Value = DateTime.Today;
            dtNgayKetThuc.Value = DateTime.Today;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
