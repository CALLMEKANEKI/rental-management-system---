using BLL.BLL;
using BLL.Services;
using DAL.Model;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MAIN.main
{
    public partial class LOGIN : Form
    {
        private chutroService _chutroService = new chutroService();
        public static string id_chutrohientai = null;
        public LOGIN()
        {
            InitializeComponent();
        }

        // 🔹 Đăng nhập
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string mess = _chutroService.SignIn(username, password, out id_chutrohientai);

            if (mess == "Đăng nhập thành công.") 
            { 
                frmQuanLy frmQuanLy = new frmQuanLy();
                
                frmQuanLy.Show();
            }
                
            MessageBox.Show(mess);
        }

        public void clear()
        {
            txtNewUser.Text = "";
            txtNewPass.Text = "";
            txtConfirm.Text = "";
        }

        // 🔹 Đăng ký
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string newUser = txtNewUser.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string confirmPass = txtConfirm.Text.Trim();

            if (newPass == confirmPass)
            {
                chutro objChuTro = new chutro
                {
                    hoten = "",
                    sdt = "",
                    email = "",
                    diachi = "",
                    taikhoan = newUser,
                    matkhau = newPass,
                    avatar_url = "",
                    anh_cccd_sau_url = "",
                    anh_cccd_truoc_url = ""
                };

                string mess = _chutroService.SignUp(objChuTro);
                if (mess == "Tạo tài khoản thành công.")
                {
                    btnSwitchSignIn_Click(sender, e);
                    clear();
                }
                MessageBox.Show(mess);
            }
            else
                MessageBox.Show("Mật khẩu không khớp.");
            
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
