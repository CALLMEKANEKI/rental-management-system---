using System;
using System.Drawing;
using System.Windows.Forms;

namespace qlpt.GUI
{
    public partial class DANGNHAP : Form
    {
        public DANGNHAP()
        {
            InitializeComponent();
        }

        private void btnSwitchSignIn_Click(object sender, EventArgs e)
        {
            panelSignUp.Visible = false;
            panelSignIn.Visible = true;
            btnSwitchSignIn.ForeColor = Color.White;
            btnSwitchSignUp.BackColor = Color.LightGray;
            btnSwitchSignUp.ForeColor = Color.Black;
        }

        private void btnSwitchSignUp_Click(object sender, EventArgs e)
        {
            panelSignIn.Visible = false;
            panelSignUp.Visible = true;
            btnSwitchSignUp.ForeColor = Color.White;
            btnSwitchSignIn.BackColor = Color.LightGray;
            btnSwitchSignIn.ForeColor = Color.Black;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gọi service để kiểm tra
            var service = new BLL.Services.chutroService();
            string idChuTroHienTai;

            string result = service.SignIn(username, password, out idChuTroHienTai);

            if (result == "Đăng nhập thành công.")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // mở form chính
                Phong mainForm = new Phong();
                this.Hide(); // ẩn form đăng nhập
                mainForm.ShowDialog();

                this.Show(); // hiện lại sau khi form chính đóng
            }
            else
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            string username = txtNewUser.Text.Trim();
            string password = txtNewPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không set id_chutro ở đây, để service tự tạo ID hợp lệ
            var newChuTro = new DAL.Model.chutro()
            {
                taikhoan = username,
                matkhau = password,
                 hoten = "Chủ trọ mới",
                email = username + "@example.com"
            };

            var service = new BLL.Services.chutroService();
            string result = service.SignUp(newChuTro);

            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DANGNHAP_Load(object sender, EventArgs e)
        {

        }

        private void panelSignIn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
