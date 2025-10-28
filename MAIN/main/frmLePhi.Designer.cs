namespace MAIN.main
{
    partial class frmLePhi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimLePhi = new System.Windows.Forms.TextBox();
            this.btnTimLePhi = new System.Windows.Forms.Button();
            this.grbNuoc = new System.Windows.Forms.GroupBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblTienLePhi = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.txtTienDV = new System.Windows.Forms.TextBox();
            this.lblTienDV = new System.Windows.Forms.Label();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.lblMaLePhi = new System.Windows.Forms.Label();
            this.txtLePhi = new System.Windows.Forms.TextBox();
            this.txtTienPhong = new System.Windows.Forms.TextBox();
            this.txtMaLePhi = new System.Windows.Forms.TextBox();
            this.dgvLePhi = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.grbNuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLePhi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLePhi);
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXuat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTimLePhi);
            this.groupBox1.Controls.Add(this.btnTimLePhi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 478);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(804, 32);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(103, 35);
            this.btnLamMoi.TabIndex = 52;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.DimGray;
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXuat.Location = new System.Drawing.Point(698, 32);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(100, 35);
            this.btnXuat.TabIndex = 51;
            this.btnXuat.Text = "Xuất file";
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 45;
            // 
            // txtTimLePhi
            // 
            this.txtTimLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimLePhi.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTimLePhi.Location = new System.Drawing.Point(12, 29);
            this.txtTimLePhi.Name = "txtTimLePhi";
            this.txtTimLePhi.Size = new System.Drawing.Size(338, 38);
            this.txtTimLePhi.TabIndex = 44;
            this.txtTimLePhi.Text = "Nhập từ khóa để tìm kiếm";
            this.txtTimLePhi.Enter += new System.EventHandler(this.txtTimLePhi_Enter);
            this.txtTimLePhi.Leave += new System.EventHandler(this.txtTimLePhi_Leave);
            // 
            // btnTimLePhi
            // 
            this.btnTimLePhi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimLePhi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimLePhi.Location = new System.Drawing.Point(356, 34);
            this.btnTimLePhi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimLePhi.Name = "btnTimLePhi";
            this.btnTimLePhi.Size = new System.Drawing.Size(84, 32);
            this.btnTimLePhi.TabIndex = 31;
            this.btnTimLePhi.Text = "Tìm";
            this.btnTimLePhi.UseVisualStyleBackColor = false;
            this.btnTimLePhi.Click += new System.EventHandler(this.btnTimLePhi_Click);
            // 
            // grbNuoc
            // 
            this.grbNuoc.Controls.Add(this.lblTrangThai);
            this.grbNuoc.Controls.Add(this.txtTrangThai);
            this.grbNuoc.Controls.Add(this.txtPhong);
            this.grbNuoc.Controls.Add(this.lblPhong);
            this.grbNuoc.Controls.Add(this.lblTienLePhi);
            this.grbNuoc.Controls.Add(this.lblTienPhong);
            this.grbNuoc.Controls.Add(this.txtTienPhong);
            this.grbNuoc.Controls.Add(this.dtpNgayTao);
            this.grbNuoc.Controls.Add(this.lblTienDV);
            this.grbNuoc.Controls.Add(this.lblNgayTao);
            this.grbNuoc.Controls.Add(this.txtLePhi);
            this.grbNuoc.Controls.Add(this.txtTienDV);
            this.grbNuoc.Controls.Add(this.lblMaLePhi);
            this.grbNuoc.Controls.Add(this.txtMaLePhi);
            this.grbNuoc.Location = new System.Drawing.Point(12, 12);
            this.grbNuoc.Name = "grbNuoc";
            this.grbNuoc.Size = new System.Drawing.Size(798, 231);
            this.grbNuoc.TabIndex = 50;
            this.grbNuoc.TabStop = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(6, 118);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(142, 32);
            this.lblTrangThai.TabIndex = 75;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.Location = new System.Drawing.Point(173, 115);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(200, 38);
            this.txtTrangThai.TabIndex = 74;
            // 
            // txtPhong
            // 
            this.txtPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(577, 15);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(200, 38);
            this.txtPhong.TabIndex = 73;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(404, 18);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(150, 32);
            this.lblPhong.TabIndex = 72;
            this.lblPhong.Text = "Tên phòng";
            // 
            // lblTienLePhi
            // 
            this.lblTienLePhi.AutoSize = true;
            this.lblTienLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienLePhi.Location = new System.Drawing.Point(411, 184);
            this.lblTienLePhi.Name = "lblTienLePhi";
            this.lblTienLePhi.Size = new System.Drawing.Size(155, 32);
            this.lblTienLePhi.TabIndex = 71;
            this.lblTienLePhi.Text = "Tổng lệ phí";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Enabled = false;
            this.dtpNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(173, 68);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayTao.TabIndex = 70;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTao.Location = new System.Drawing.Point(6, 68);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(127, 32);
            this.lblNgayTao.TabIndex = 21;
            this.lblNgayTao.Text = "Ngày tạo";
            // 
            // txtTienDV
            // 
            this.txtTienDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDV.Location = new System.Drawing.Point(577, 115);
            this.txtTienDV.Name = "txtTienDV";
            this.txtTienDV.ReadOnly = true;
            this.txtTienDV.Size = new System.Drawing.Size(200, 38);
            this.txtTienDV.TabIndex = 22;
            // 
            // lblTienDV
            // 
            this.lblTienDV.AutoSize = true;
            this.lblTienDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDV.Location = new System.Drawing.Point(404, 118);
            this.lblTienDV.Name = "lblTienDV";
            this.lblTienDV.Size = new System.Drawing.Size(167, 32);
            this.lblTienDV.TabIndex = 13;
            this.lblTienDV.Text = "Tiền dịch vụ";
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienPhong.Location = new System.Drawing.Point(404, 68);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(157, 32);
            this.lblTienPhong.TabIndex = 14;
            this.lblTienPhong.Text = "Tiền phòng";
            // 
            // lblMaLePhi
            // 
            this.lblMaLePhi.AutoSize = true;
            this.lblMaLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLePhi.Location = new System.Drawing.Point(6, 18);
            this.lblMaLePhi.Name = "lblMaLePhi";
            this.lblMaLePhi.Size = new System.Drawing.Size(161, 32);
            this.lblMaLePhi.TabIndex = 16;
            this.lblMaLePhi.Text = "Mã bản ghi ";
            // 
            // txtLePhi
            // 
            this.txtLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLePhi.Location = new System.Drawing.Point(577, 178);
            this.txtLePhi.Name = "txtLePhi";
            this.txtLePhi.ReadOnly = true;
            this.txtLePhi.Size = new System.Drawing.Size(200, 38);
            this.txtLePhi.TabIndex = 17;
            // 
            // txtTienPhong
            // 
            this.txtTienPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienPhong.Location = new System.Drawing.Point(577, 71);
            this.txtTienPhong.Name = "txtTienPhong";
            this.txtTienPhong.ReadOnly = true;
            this.txtTienPhong.Size = new System.Drawing.Size(200, 38);
            this.txtTienPhong.TabIndex = 18;
            // 
            // txtMaLePhi
            // 
            this.txtMaLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLePhi.Location = new System.Drawing.Point(173, 18);
            this.txtMaLePhi.Name = "txtMaLePhi";
            this.txtMaLePhi.ReadOnly = true;
            this.txtMaLePhi.Size = new System.Drawing.Size(200, 38);
            this.txtMaLePhi.TabIndex = 20;
            // 
            // dgvLePhi
            // 
            this.dgvLePhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLePhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLePhi.Location = new System.Drawing.Point(12, 83);
            this.dgvLePhi.Name = "dgvLePhi";
            this.dgvLePhi.ReadOnly = true;
            this.dgvLePhi.RowHeadersWidth = 51;
            this.dgvLePhi.RowTemplate.Height = 29;
            this.dgvLePhi.Size = new System.Drawing.Size(897, 386);
            this.dgvLePhi.TabIndex = 53;
            this.dgvLePhi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLePhi_CellClick);
            // 
            // frmLePhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 730);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbNuoc);
            this.Name = "frmLePhi";
            this.Text = "Lệ phí";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbNuoc.ResumeLayout(false);
            this.grbNuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLePhi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimLePhi;
        private System.Windows.Forms.Button btnTimLePhi;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.Label lblTienDV;
        private System.Windows.Forms.TextBox txtLePhi;
        private System.Windows.Forms.GroupBox grbNuoc;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblTienLePhi;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.TextBox txtTienDV;
        private System.Windows.Forms.Label lblMaLePhi;
        private System.Windows.Forms.TextBox txtMaLePhi;
        private System.Windows.Forms.DataGridView dgvLePhi;
    }
}