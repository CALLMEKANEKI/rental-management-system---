namespace MAIN.main
{
    partial class frmNuoc
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
            this.txtTimNuoc = new System.Windows.Forms.TextBox();
            this.dgvNuoc = new System.Windows.Forms.DataGridView();
            this.btnTimNuoc = new System.Windows.Forms.Button();
            this.grbNuoc = new System.Windows.Forms.GroupBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.lblChiSoCuoi = new System.Windows.Forms.Label();
            this.lblChiSoDau = new System.Windows.Forms.Label();
            this.lblMaNuoc = new System.Windows.Forms.Label();
            this.txtChiSoCuoi = new System.Windows.Forms.TextBox();
            this.txtChiSoDau = new System.Windows.Forms.TextBox();
            this.txtMaNuoc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuoc)).BeginInit();
            this.grbNuoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXuat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTimNuoc);
            this.groupBox1.Controls.Add(this.dgvNuoc);
            this.groupBox1.Controls.Add(this.btnTimNuoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 478);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(782, 34);
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
            this.btnXuat.Location = new System.Drawing.Point(676, 34);
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
            // txtTimNuoc
            // 
            this.txtTimNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimNuoc.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTimNuoc.Location = new System.Drawing.Point(12, 29);
            this.txtTimNuoc.Name = "txtTimNuoc";
            this.txtTimNuoc.Size = new System.Drawing.Size(338, 38);
            this.txtTimNuoc.TabIndex = 44;
            this.txtTimNuoc.Text = "Nhập từ khóa để tìm kiếm";
            this.txtTimNuoc.Enter += new System.EventHandler(this.txtTimNuoc_Enter);
            this.txtTimNuoc.Leave += new System.EventHandler(this.txtTimNuoc_Leave);
            // 
            // dgvNuoc
            // 
            this.dgvNuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNuoc.Location = new System.Drawing.Point(12, 78);
            this.dgvNuoc.Name = "dgvNuoc";
            this.dgvNuoc.ReadOnly = true;
            this.dgvNuoc.RowHeadersWidth = 51;
            this.dgvNuoc.RowTemplate.Height = 29;
            this.dgvNuoc.Size = new System.Drawing.Size(904, 386);
            this.dgvNuoc.TabIndex = 42;
            this.dgvNuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVNuoc_CellClick);
            // 
            // btnTimNuoc
            // 
            this.btnTimNuoc.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimNuoc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimNuoc.Location = new System.Drawing.Point(356, 34);
            this.btnTimNuoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimNuoc.Name = "btnTimNuoc";
            this.btnTimNuoc.Size = new System.Drawing.Size(84, 32);
            this.btnTimNuoc.TabIndex = 31;
            this.btnTimNuoc.Text = "Tìm";
            this.btnTimNuoc.UseVisualStyleBackColor = false;
            this.btnTimNuoc.Click += new System.EventHandler(this.btnTimNuoc_Click);
            // 
            // grbNuoc
            // 
            this.grbNuoc.Controls.Add(this.lblTrangThai);
            this.grbNuoc.Controls.Add(this.txtTrangThai);
            this.grbNuoc.Controls.Add(this.txtPhong);
            this.grbNuoc.Controls.Add(this.lblPhong);
            this.grbNuoc.Controls.Add(this.lblTienNuoc);
            this.grbNuoc.Controls.Add(this.dtpNgayTao);
            this.grbNuoc.Controls.Add(this.lblNgayTao);
            this.grbNuoc.Controls.Add(this.txtTienNuoc);
            this.grbNuoc.Controls.Add(this.lblChiSoCuoi);
            this.grbNuoc.Controls.Add(this.lblChiSoDau);
            this.grbNuoc.Controls.Add(this.lblMaNuoc);
            this.grbNuoc.Controls.Add(this.txtChiSoCuoi);
            this.grbNuoc.Controls.Add(this.txtChiSoDau);
            this.grbNuoc.Controls.Add(this.txtMaNuoc);
            this.grbNuoc.Location = new System.Drawing.Point(12, 12);
            this.grbNuoc.Name = "grbNuoc";
            this.grbNuoc.Size = new System.Drawing.Size(774, 231);
            this.grbNuoc.TabIndex = 48;
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
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(411, 68);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(150, 32);
            this.lblPhong.TabIndex = 72;
            this.lblPhong.Text = "Tên phòng";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNuoc.Location = new System.Drawing.Point(411, 184);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(139, 32);
            this.lblTienNuoc.TabIndex = 71;
            this.lblTienNuoc.Text = "Tiền nước";
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
            // txtTienNuoc
            // 
            this.txtTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienNuoc.Location = new System.Drawing.Point(560, 181);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.ReadOnly = true;
            this.txtTienNuoc.Size = new System.Drawing.Size(200, 38);
            this.txtTienNuoc.TabIndex = 22;
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
            // lblMaNuoc
            // 
            this.lblMaNuoc.AutoSize = true;
            this.lblMaNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNuoc.Location = new System.Drawing.Point(6, 18);
            this.lblMaNuoc.Name = "lblMaNuoc";
            this.lblMaNuoc.Size = new System.Drawing.Size(161, 32);
            this.lblMaNuoc.TabIndex = 16;
            this.lblMaNuoc.Text = "Mã bản ghi ";
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
            // txtMaNuoc
            // 
            this.txtMaNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNuoc.Location = new System.Drawing.Point(173, 18);
            this.txtMaNuoc.Name = "txtMaNuoc";
            this.txtMaNuoc.ReadOnly = true;
            this.txtMaNuoc.Size = new System.Drawing.Size(200, 38);
            this.txtMaNuoc.TabIndex = 20;
            // 
            // frmNuoc
            // 
            this.ClientSize = new System.Drawing.Size(946, 740);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbNuoc);
            this.Name = "frmNuoc";
            this.Text = "Quản lý tiền nước";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuoc)).EndInit();
            this.grbNuoc.ResumeLayout(false);
            this.grbNuoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimNuoc;
        private System.Windows.Forms.DataGridView dgvNuoc;
        private System.Windows.Forms.Button btnTimNuoc;
        private System.Windows.Forms.GroupBox grbNuoc;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.Label lblChiSoCuoi;
        private System.Windows.Forms.Label lblChiSoDau;
        private System.Windows.Forms.Label lblMaNuoc;
        private System.Windows.Forms.TextBox txtChiSoCuoi;
        private System.Windows.Forms.TextBox txtChiSoDau;
        private System.Windows.Forms.TextBox txtMaNuoc;
    }
}