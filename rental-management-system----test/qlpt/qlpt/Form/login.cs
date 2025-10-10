using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlpt_BLL.BLL;

namespace qlpt
{
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
        }

        private ChuTroBLL chuTroBLL = new ChuTroBLL();
        private NguoiThueBLL nguoiThueBLL = new NguoiThueBLL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string pass = txtPass.Text;
            string role = cobRole.Text;

            if (role == "Chủ trọ" || role == "Admin")
            {
                ChuTro user = chuTroBLL.login(username, pass);
                if (user != null)
                {
                    if (role == "Chủ trọ")
                    {
                        main Main = new main(user.Id_ChuTro);
                        Main.Show();
                        this.Hide();
                        MessageBox.Show("Đăng nhập thành công !!! Chào mừng người dùng " + username);
                    }
                    else if (role == "Admin")
                    {
                        SignUp signUp = new SignUp();
                        signUp.Show();
                        this.Hide();
                        MessageBox.Show("Chào mừng "+username+" trở lại !!!");
                        //check(true);
                    }                        
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                }
                
            }
            else if (role == "Người thuê")
            {
                NguoiThue user = nguoiThueBLL.login(username, pass);
                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công !!! Chào mừng người dùng " + username);
                    khachthue khachthue = new khachthue();
                    khachthue.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
