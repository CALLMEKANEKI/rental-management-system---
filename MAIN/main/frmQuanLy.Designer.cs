namespace MAIN.main
{
    partial class frmQuanLy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLy));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchThuêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhòngThuêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHợpĐồngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýToolStripMenuItem,
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnToolStripMenuItem,
            this.quảnLýKháchThuêToolStripMenuItem,
            this.quảnLýPhòngThuêToolStripMenuItem,
            this.quảnLýHợpĐồngToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản Lý";
            // 
            // quảnToolStripMenuItem
            // 
            this.quảnToolStripMenuItem.Name = "quảnToolStripMenuItem";
            this.quảnToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.quảnToolStripMenuItem.Text = "Thông Tin Chủ Trọ";
            this.quảnToolStripMenuItem.Click += new System.EventHandler(this.quảnToolStripMenuItem_Click);
            // 
            // quảnLýKháchThuêToolStripMenuItem
            // 
            this.quảnLýKháchThuêToolStripMenuItem.Name = "quảnLýKháchThuêToolStripMenuItem";
            this.quảnLýKháchThuêToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.quảnLýKháchThuêToolStripMenuItem.Text = "Quản Lý Khách Thuê";
            this.quảnLýKháchThuêToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchThuêToolStripMenuItem_Click);
            // 
            // quảnLýPhòngThuêToolStripMenuItem
            // 
            this.quảnLýPhòngThuêToolStripMenuItem.Name = "quảnLýPhòngThuêToolStripMenuItem";
            this.quảnLýPhòngThuêToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.quảnLýPhòngThuêToolStripMenuItem.Text = "Quản Lý Phòng Thuê";
            this.quảnLýPhòngThuêToolStripMenuItem.Click += new System.EventHandler(this.quảnLýPhòngThuêToolStripMenuItem_Click);
            // 
            // quảnLýHợpĐồngToolStripMenuItem
            // 
            this.quảnLýHợpĐồngToolStripMenuItem.Name = "quảnLýHợpĐồngToolStripMenuItem";
            this.quảnLýHợpĐồngToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.quảnLýHợpĐồngToolStripMenuItem.Text = "Quản Lý Hợp Đồng";
            this.quảnLýHợpĐồngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHợpĐồngToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản Lý Hóa Đơn";
            this.quảnLýHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnToolStripMenuItem_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.chứcNăngToolStripMenuItem.Text = "Lịch sử thanh toán";
            this.chứcNăngToolStripMenuItem.Click += new System.EventHandler(this.chứcNăngToolStripMenuItem_Click);
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 439);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmQuanLy";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchThuêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhòngThuêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHợpĐồngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
    }
}