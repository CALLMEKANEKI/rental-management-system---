using BLL.BLL;
using DAL.Model;
using System;
using System.Windows.Forms;

namespace MAIN.main
{
    public partial class LOGIN : Form
    {
        private chutroBLL _chutroBLL = new chutroBLL();

        public LOGIN()
        {
            InitializeComponent();
        }

        // 🔹 Đăng nhập
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            chutro user = _chutroBLL.LayChutroTheoUserName(username);

            if (user != null && user.matkhau == password)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form login
                this.Hide();

                // Truyền id_chutro cho frmQuanLy nếu cần
                var frm = new frmQuanLy();
                frm.ShowDialog(this);
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        // 🔹 Đăng ký
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string newUser = txtNewUser.Text.Trim();
            string newPass = txtNewPass.Text.Trim();

            if (string.IsNullOrEmpty(newUser) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem username đã tồn tại chưa
            if (_chutroBLL.LayChutroTheoUserName(newUser) != null)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng chủ trọ mới
            chutro newChutro = new chutro
            {
                taikhoan = newUser,
                matkhau = newPass,
                hoten = newUser,       // có thể chỉnh sau
                email = "",
                sdt = "",
                diachi = ""
            };

            try
            {
                bool success = _chutroBLL.ThemChutro(newChutro);
                if (success)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSwitchSignIn_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống khi đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSwitchSignIn_Click(object sender, EventArgs e)
        {
            panelSignUp.Visible = false;
            panelSignIn.Visible = true;
        }

        private void btnSwitchSignUp_Click(object sender, EventArgs e)
        {
            panelSignIn.Visible = false;
            panelSignUp.Visible = true;
        }




    }
}
