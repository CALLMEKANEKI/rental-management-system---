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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private ChuTroBLL ChuTroBll = new ChuTroBLL();
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            ChuTro chuTro = new ChuTro
            {
                HoTen = txtNameAd.Text,
                Sdt = txtPhoneNumberAd.Text,
                Email = txtEmailAd.Text,
                DiaChi = txtAddressAd.Text,
                TaiKhoan = txtUserName.Text,
                MatKhau = txtPass.Text
            };

            int result = ChuTroBll.SignUp(chuTro);
            if (result > 0)
            {
                MessageBox.Show("Tạo tài khoản thành công");
                this.Close();
            }
            else if (result == -2)
            {
                MessageBox.Show("Dữ liệu của chủ trọ không được để trống");
            }
            else if (result == -3)
            {
                MessageBox.Show("Tài khoản đã tồn tại !!!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
