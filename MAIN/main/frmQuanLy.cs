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

        private void thuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDien frm = new frmDien();
            frm.ShowDialog();
        }

        private void trảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuoc frm = new frmNuoc();
            frm.ShowDialog();
        }

        private void tiềnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLePhi frm = new frmLePhi();
            frm.ShowDialog();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan();
            frm.ShowDialog();
        }
    }
}
