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
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        private void quảnLýPhòngThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongTro frm = new frmPhongTro();
            frm.ShowDialog();
        }

        private void quảnLýKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNguoiThue frm = new frmNguoiThue();
            frm.ShowDialog();
        }

        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDong frm = new frmHopDong();
            frm.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.ShowDialog();
        }

        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChuTro frm = new frmChuTro();
            frm.ShowDialog();
        }

        // ======================= MENU "CHỨC NĂNG" =========================

        private void thuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuePhong frm = new frmThuePhong();
            frm.ShowDialog();
        }

        private void trảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraPhong frm = new frmTraPhong();
            frm.ShowDialog();
        }

        // ======================= MENU "TÌM" =========================

        private void tìmPhòngThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimPhong frm = new frmTimPhong();
            frm.ShowDialog();
        }

        private void tìmKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKhachThue frm = new frmTimKhachThue();
            frm.ShowDialog();
        }

        private void tìmHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimHopDong frm = new frmTimHopDong();
            frm.ShowDialog();
        }

        private void tìmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimHoaDon frm = new frmTimHoaDon();
            frm.ShowDialog();
        }

    }
}
