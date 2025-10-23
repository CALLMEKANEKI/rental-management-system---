
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlpt.GUI
{
    public partial class Phong : Form
    {
        public Phong()
        {
            InitializeComponent();
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLCHUTRO f = new QLCHUTRO();
            f.ShowDialog();
        }

        private void quảnLýKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKHACH f = new QLKHACH();
            f.ShowDialog();
        }

        private void quảnLýPhòngThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPHONG f = new QLPHONG();
            f.ShowDialog();
        }

        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHOPDONG f = new QLHOPDONG();
            f.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHOADON f = new QLHOADON();
            f.ShowDialog();
        }

        // ======== MENU CHỨC NĂNG ========
        private void thuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTHUE f = new QLTHUE();
            f.ShowDialog();
        }

        private void trảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTRA f = new QLTRA();
            f.ShowDialog();
        }

        // ======== MENU TÌM KIẾM ========
        private void tìmKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TIMKHACHTHUE f = new TIMKHACHTHUE();
            f.ShowDialog();
        }

        private void tìmPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TIMPHONG f = new TIMPHONG();
            f.ShowDialog();
        }

        private void tìmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TIMHOADON f = new TIMHOADON();
            f.ShowDialog();
        }

        private void tìmHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TIMHOPDONG f = new TIMHOPDONG();
            f.ShowDialog();
        }
        private void tìmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Phong_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
