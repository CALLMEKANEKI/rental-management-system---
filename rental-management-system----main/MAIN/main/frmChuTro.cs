using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class frmChuTro : Form
    {
        private DataTable dtChuTro;

        public frmChuTro()
        {
            InitializeComponent();
            TaoBangChuTro();

        }
        private void TaoBangChuTro()
        {
            dtChuTro = new DataTable();
            dtChuTro.Columns.Add("Họ tên");
            dtChuTro.Columns.Add("SĐT");
            dtChuTro.Columns.Add("Email");
            dtChuTro.Columns.Add("Địa chỉ");
            dtChuTro.Columns.Add("Tài khoản");
            dtChuTro.Columns.Add("Mật khẩu");

            dgvChuTro.DataSource = dtChuTro;
        }

        // Nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Tài khoản!", "Thông báo");
                return;
            }

            dtChuTro.Rows.Add(txtHoTen.Text, txtSDT.Text, txtEmail.Text,
                              txtDiaChi.Text, txtTaiKhoan.Text, txtMatKhau.Text);
            LamMoi();
        }

        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvChuTro.CurrentRow == null) return;

            int index = dgvChuTro.CurrentRow.Index;
            dtChuTro.Rows[index]["Họ tên"] = txtHoTen.Text;
            dtChuTro.Rows[index]["SĐT"] = txtSDT.Text;
            dtChuTro.Rows[index]["Email"] = txtEmail.Text;
            dtChuTro.Rows[index]["Địa chỉ"] = txtDiaChi.Text;
            dtChuTro.Rows[index]["Tài khoản"] = txtTaiKhoan.Text;
            dtChuTro.Rows[index]["Mật khẩu"] = txtMatKhau.Text;
        }

        // Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChuTro.CurrentRow != null)
            {
                int index = dgvChuTro.CurrentRow.Index;
                dtChuTro.Rows.RemoveAt(index);
                LamMoi();
            }
        }

        // Nút làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            picAvatar.Image = null;
            picCCCDTruoc.Image = null;
            picCCCDSau.Image = null;
        }

        // Khi click vào dòng trong DataGridView → hiển thị lên TextBox
        private void dgvChuTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChuTro.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["Họ tên"].Value?.ToString();
                txtSDT.Text = row.Cells["SĐT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtDiaChi.Text = row.Cells["Địa chỉ"].Value?.ToString();
                txtTaiKhoan.Text = row.Cells["Tài khoản"].Value?.ToString();
                txtMatKhau.Text = row.Cells["Mật khẩu"].Value?.ToString();
            }
        }

        // Chọn ảnh Avatar
        private void btnChonAvatar_Click(object sender, EventArgs e)
        {
            ChonAnh(picAvatar);
        }

        // Chọn CCCD trước
        private void btnCCCDTruoc_Click(object sender, EventArgs e)
        {
            ChonAnh(picCCCDTruoc);
        }

        // Chọn CCCD sau
        private void btnCCCDAfter_Click(object sender, EventArgs e)
        {
            ChonAnh(picCCCDSau);
        }

        // Hàm chọn ảnh chung
        private void ChonAnh(PictureBox pic)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(ofd.FileName);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        // Khi load form
        private void frmChuTro_Load(object sender, EventArgs e)
        {
            dgvChuTro.CellClick += dgvChuTro_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnChonAvatar.Click += btnChonAvatar_Click;
            btnCCCDTruoc.Click += btnCCCDTruoc_Click;
            btnCCCDAfter.Click += btnCCCDAfter_Click;
        }
    }
}
