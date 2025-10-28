namespace MAIN.main
{
    partial class frmDien
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
            this.grbNuoc = new System.Windows.Forms.GroupBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblDien = new System.Windows.Forms.Label();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.lblChiSoCuoi = new System.Windows.Forms.Label();
            this.lblChiSoDau = new System.Windows.Forms.Label();
            this.lblMaDien = new System.Windows.Forms.Label();
            this.txtChiSoCuoi = new System.Windows.Forms.TextBox();
            this.txtChiSoDau = new System.Windows.Forms.TextBox();
            this.txtMaDien = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimDien = new System.Windows.Forms.TextBox();
            this.dgvDien = new System.Windows.Forms.DataGridView();
            this.btnTimDien = new System.Windows.Forms.Button();
            this.grbNuoc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDien)).BeginInit();
            this.SuspendLayout();
            // 
            // grbNuoc
            // 
            this.grbNuoc.Controls.Add(this.lblTrangThai);
            this.grbNuoc.Controls.Add(this.txtTrangThai);
            this.grbNuoc.Controls.Add(this.txtPhong);
            this.grbNuoc.Controls.Add(this.lblDien);
            this.grbNuoc.Controls.Add(this.lblTienDien);
            this.grbNuoc.Controls.Add(this.dtpNgayTao);
            this.grbNuoc.Controls.Add(this.lblNgayTao);
            this.grbNuoc.Controls.Add(this.txtTienDien);
            this.grbNuoc.Controls.Add(this.lblChiSoCuoi);
            this.grbNuoc.Controls.Add(this.lblChiSoDau);
            this.grbNuoc.Controls.Add(this.lblMaDien);
            this.grbNuoc.Controls.Add(this.txtChiSoCuoi);
            this.grbNuoc.Controls.Add(this.txtChiSoDau);
            this.grbNuoc.Controls.Add(this.txtMaDien);
            this.grbNuoc.Location = new System.Drawing.Point(24, 12);
            this.grbNuoc.Name = "grbNuoc";
            this.grbNuoc.Size = new System.Drawing.Size(774, 231);
            this.grbNuoc.TabIndex = 13;
            this.grbNuoc.TabStop = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(411, 118);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(142, 32);
            this.lblTrangThai.TabIndex = 75;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.Location = new System.Drawing.Point(560, 118);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(200, 38);
            this.txtTrangThai.TabIndex = 74;
            // 
            // txtPhong
            // 
            this.txtPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(560, 68);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(200, 38);
            this.txtPhong.TabIndex = 73;
            // 
            // lblDien
            // 
            this.lblDien.AutoSize = true;
            this.lblDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDien.Location = new System.Drawing.Point(411, 68);
            this.lblDien.Name = "lblDien";
            this.lblDien.Size = new System.Drawing.Size(150, 32);
            this.lblDien.TabIndex = 72;
            this.lblDien.Text = "Tên phòng";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDien.Location = new System.Drawing.Point(411, 184);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(132, 32);
            this.lblTienDien.TabIndex = 71;
            this.lblTienDien.Text = "Tiền điện";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Enabled = false;
            this.dtpNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(560, 18);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayTao.TabIndex = 70;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTao.Location = new System.Drawing.Point(411, 18);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(127, 32);
            this.lblNgayTao.TabIndex = 21;
            this.lblNgayTao.Text = "Ngày tạo";
            // 
            // txtTienDien
            // 
            this.txtTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDien.Location = new System.Drawing.Point(560, 181);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.ReadOnly = true;
            this.txtTienDien.Size = new System.Drawing.Size(200, 38);
            this.txtTienDien.TabIndex = 22;
            // 
            // lblChiSoCuoi
            // 
            this.lblChiSoCuoi.AutoSize = true;
            this.lblChiSoCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiSoCuoi.Location = new System.Drawing.Point(6, 118);
            this.lblChiSoCuoi.Name = "lblChiSoCuoi";
            this.lblChiSoCuoi.Size = new System.Drawing.Size(154, 32);
            this.lblChiSoCuoi.TabIndex = 13;
            this.lblChiSoCuoi.Text = "Chỉ số cuối";
            // 
            // lblChiSoDau
            // 
            this.lblChiSoDau.AutoSize = true;
            this.lblChiSoDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiSoDau.Location = new System.Drawing.Point(6, 68);
            this.lblChiSoDau.Name = "lblChiSoDau";
            this.lblChiSoDau.Size = new System.Drawing.Size(149, 32);
            this.lblChiSoDau.TabIndex = 14;
            this.lblChiSoDau.Text = "Chỉ số đầu";
            // 
            // lblMaDien
            // 
            this.lblMaDien.AutoSize = true;
            this.lblMaDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDien.Location = new System.Drawing.Point(6, 18);
            this.lblMaDien.Name = "lblMaDien";
            this.lblMaDien.Size = new System.Drawing.Size(161, 32);
            this.lblMaDien.TabIndex = 16;
            this.lblMaDien.Text = "Mã bản ghi ";
            // 
            // txtChiSoCuoi
            // 
            this.txtChiSoCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoCuoi.Location = new System.Drawing.Point(173, 118);
            this.txtChiSoCuoi.Name = "txtChiSoCuoi";
            this.txtChiSoCuoi.ReadOnly = true;
            this.txtChiSoCuoi.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoCuoi.TabIndex = 17;
            // 
            // txtChiSoDau
            // 
            this.txtChiSoDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoDau.Location = new System.Drawing.Point(173, 68);
            this.txtChiSoDau.Name = "txtChiSoDau";
            this.txtChiSoDau.ReadOnly = true;
            this.txtChiSoDau.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoDau.TabIndex = 18;
            // 
            // txtMaDien
            // 
            this.txtMaDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDien.Location = new System.Drawing.Point(173, 18);
            this.txtMaDien.Name = "txtMaDien";
            this.txtMaDien.ReadOnly = true;
            this.txtMaDien.Size = new System.Drawing.Size(200, 38);
            this.txtMaDien.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXuat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTimDien);
            this.groupBox1.Controls.Add(this.dgvDien);
            this.groupBox1.Controls.Add(this.btnTimDien);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 489);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(793, 32);
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
            this.btnXuat.Location = new System.Drawing.Point(687, 32);
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
            // txtTimDien
            // 
            this.txtTimDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimDien.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTimDien.Location = new System.Drawing.Point(12, 29);
            this.txtTimDien.Name = "txtTimDien";
            this.txtTimDien.Size = new System.Drawing.Size(338, 38);
            this.txtTimDien.TabIndex = 44;
            this.txtTimDien.Text = "Nhập từ khóa để tìm kiếm";
            this.txtTimDien.Enter += new System.EventHandler(this.txtTimDien_Enter);
            this.txtTimDien.Leave += new System.EventHandler(this.txtTimDien_Leave);
            // 
            // dgvDien
            // 
            this.dgvDien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDien.Location = new System.Drawing.Point(12, 78);
            this.dgvDien.Name = "dgvDien";
            this.dgvDien.ReadOnly = true;
            this.dgvDien.RowHeadersWidth = 51;
            this.dgvDien.RowTemplate.Height = 29;
            this.dgvDien.Size = new System.Drawing.Size(933, 399);
            this.dgvDien.TabIndex = 42;
            this.dgvDien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDien_CellClick);
            // 
            // btnTimDien
            // 
            this.btnTimDien.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimDien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimDien.Location = new System.Drawing.Point(356, 34);
            this.btnTimDien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimDien.Name = "btnTimDien";
            this.btnTimDien.Size = new System.Drawing.Size(84, 32);
            this.btnTimDien.TabIndex = 31;
            this.btnTimDien.Text = "Tìm";
            this.btnTimDien.UseVisualStyleBackColor = false;
            this.btnTimDien.Click += new System.EventHandler(this.btnTimDien_Click);
            // 
            // frmDien
            // 
            this.ClientSize = new System.Drawing.Size(975, 748);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbNuoc);
            this.Name = "frmDien";
            this.Text = "Điện";
            this.grbNuoc.ResumeLayout(false);
            this.grbNuoc.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbNuoc;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.Label lblChiSoCuoi;
        private System.Windows.Forms.Label lblChiSoDau;
        private System.Windows.Forms.Label lblMaDien;
        private System.Windows.Forms.TextBox txtChiSoCuoi;
        private System.Windows.Forms.TextBox txtChiSoDau;
        private System.Windows.Forms.TextBox txtMaDien;
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimDien;
        private System.Windows.Forms.DataGridView dgvDien;
        private System.Windows.Forms.Button btnTimDien;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblDien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnLamMoi;
    }
}