namespace MAIN.main
{
    partial class frmHopDong
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
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimHopDong = new System.Windows.Forms.TextBox();
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.btnTimHopDong = new System.Windows.Forms.Button();
            this.grbHopDong = new System.Windows.Forms.GroupBox();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblIDHopDong = new System.Windows.Forms.Label();
            this.lblTienCoc = new System.Windows.Forms.Label();
            this.txtIDHopDong = new System.Windows.Forms.TextBox();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.cboNguoiThue = new System.Windows.Forms.ComboBox();
            this.lblNguoiThue = new System.Windows.Forms.Label();
            this.txtTienCoc = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnXuat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.grbHopDong.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(932, 226);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 25;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkGreen;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoa.Location = new System.Drawing.Point(327, 226);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 26;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSua.Location = new System.Drawing.Point(174, 226);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Location = new System.Drawing.Point(28, 226);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTimHopDong);
            this.groupBox1.Controls.Add(this.dgvHopDong);
            this.groupBox1.Controls.Add(this.btnTimHopDong);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1109, 463);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 45;
            // 
            // txtTimHopDong
            // 
            this.txtTimHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimHopDong.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTimHopDong.Location = new System.Drawing.Point(12, 29);
            this.txtTimHopDong.Name = "txtTimHopDong";
            this.txtTimHopDong.Size = new System.Drawing.Size(338, 38);
            this.txtTimHopDong.TabIndex = 44;
            this.txtTimHopDong.Text = "Nhập từ khóa để tìm kiếm";
            this.txtTimHopDong.Enter += new System.EventHandler(this.txtTimHopDong_Enter);
            this.txtTimHopDong.Leave += new System.EventHandler(this.txtTimHopDong_Leave);
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Location = new System.Drawing.Point(12, 78);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.ReadOnly = true;
            this.dgvHopDong.RowHeadersWidth = 51;
            this.dgvHopDong.RowTemplate.Height = 29;
            this.dgvHopDong.Size = new System.Drawing.Size(1091, 379);
            this.dgvHopDong.TabIndex = 42;
            this.dgvHopDong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHopDong_CellClick);
            // 
            // btnTimHopDong
            // 
            this.btnTimHopDong.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimHopDong.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimHopDong.Location = new System.Drawing.Point(356, 34);
            this.btnTimHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimHopDong.Name = "btnTimHopDong";
            this.btnTimHopDong.Size = new System.Drawing.Size(84, 32);
            this.btnTimHopDong.TabIndex = 31;
            this.btnTimHopDong.Text = "Tìm";
            this.btnTimHopDong.UseVisualStyleBackColor = false;
            this.btnTimHopDong.Click += new System.EventHandler(this.btnTimHopDong_Click);
            // 
            // grbHopDong
            // 
            this.grbHopDong.Controls.Add(this.dtpNgayKT);
            this.grbHopDong.Controls.Add(this.dtpNgayBD);
            this.grbHopDong.Controls.Add(this.lblIDHopDong);
            this.grbHopDong.Controls.Add(this.lblTienCoc);
            this.grbHopDong.Controls.Add(this.txtIDHopDong);
            this.grbHopDong.Controls.Add(this.lblNgayKetThuc);
            this.grbHopDong.Controls.Add(this.cboPhong);
            this.grbHopDong.Controls.Add(this.lblNgayBatDau);
            this.grbHopDong.Controls.Add(this.cboNguoiThue);
            this.grbHopDong.Controls.Add(this.lblNguoiThue);
            this.grbHopDong.Controls.Add(this.txtTienCoc);
            this.grbHopDong.Controls.Add(this.lblPhong);
            this.grbHopDong.Location = new System.Drawing.Point(28, 26);
            this.grbHopDong.Name = "grbHopDong";
            this.grbHopDong.Size = new System.Drawing.Size(1004, 184);
            this.grbHopDong.TabIndex = 48;
            this.grbHopDong.TabStop = false;
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(750, 65);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayKT.TabIndex = 60;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(750, 18);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayBD.TabIndex = 59;
            // 
            // lblIDHopDong
            // 
            this.lblIDHopDong.AutoSize = true;
            this.lblIDHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDHopDong.Location = new System.Drawing.Point(6, 18);
            this.lblIDHopDong.Name = "lblIDHopDong";
            this.lblIDHopDong.Size = new System.Drawing.Size(187, 32);
            this.lblIDHopDong.TabIndex = 54;
            this.lblIDHopDong.Text = "Mã hợp đồng:";
            // 
            // lblTienCoc
            // 
            this.lblTienCoc.AutoSize = true;
            this.lblTienCoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienCoc.Location = new System.Drawing.Point(554, 118);
            this.lblTienCoc.Name = "lblTienCoc";
            this.lblTienCoc.Size = new System.Drawing.Size(121, 32);
            this.lblTienCoc.TabIndex = 49;
            this.lblTienCoc.Text = "Tiền cọc";
            // 
            // txtIDHopDong
            // 
            this.txtIDHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDHopDong.Location = new System.Drawing.Point(199, 18);
            this.txtIDHopDong.Name = "txtIDHopDong";
            this.txtIDHopDong.ReadOnly = true;
            this.txtIDHopDong.Size = new System.Drawing.Size(264, 38);
            this.txtIDHopDong.TabIndex = 58;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(554, 68);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(194, 32);
            this.lblNgayKetThuc.TabIndex = 50;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // cboPhong
            // 
            this.cboPhong.Enabled = false;
            this.cboPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhong.Location = new System.Drawing.Point(199, 68);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(264, 39);
            this.cboPhong.TabIndex = 57;
            this.cboPhong.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPhong_SelectedIndexChanged);
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Location = new System.Drawing.Point(554, 18);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(190, 32);
            this.lblNgayBatDau.TabIndex = 51;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // cboNguoiThue
            // 
            this.cboNguoiThue.Enabled = false;
            this.cboNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguoiThue.Location = new System.Drawing.Point(199, 118);
            this.cboNguoiThue.Name = "cboNguoiThue";
            this.cboNguoiThue.Size = new System.Drawing.Size(264, 39);
            this.cboNguoiThue.TabIndex = 56;
            this.cboNguoiThue.Click += new System.EventHandler(this.cboNguoiThue_Click);
            // 
            // lblNguoiThue
            // 
            this.lblNguoiThue.AutoSize = true;
            this.lblNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiThue.Location = new System.Drawing.Point(6, 118);
            this.lblNguoiThue.Name = "lblNguoiThue";
            this.lblNguoiThue.Size = new System.Drawing.Size(160, 32);
            this.lblNguoiThue.TabIndex = 52;
            this.lblNguoiThue.Text = "Người thuê:";
            // 
            // txtTienCoc
            // 
            this.txtTienCoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienCoc.Location = new System.Drawing.Point(750, 118);
            this.txtTienCoc.Name = "txtTienCoc";
            this.txtTienCoc.ReadOnly = true;
            this.txtTienCoc.Size = new System.Drawing.Size(200, 38);
            this.txtTienCoc.TabIndex = 55;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(6, 68);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(145, 32);
            this.lblPhong.TabIndex = 53;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.DimGray;
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXuat.Location = new System.Drawing.Point(778, 226);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(100, 35);
            this.btnXuat.TabIndex = 49;
            this.btnXuat.Text = "Xuất file";
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // frmHopDong
            // 
            this.ClientSize = new System.Drawing.Size(1161, 759);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.grbHopDong);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Name = "frmHopDong";
            this.Text = "Quản lý hợp đồng thuê phòng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.grbHopDong.ResumeLayout(false);
            this.grbHopDong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimHopDong;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.Button btnTimHopDong;
        private System.Windows.Forms.GroupBox grbHopDong;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label lblIDHopDong;
        private System.Windows.Forms.Label lblTienCoc;
        private System.Windows.Forms.TextBox txtIDHopDong;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.ComboBox cboNguoiThue;
        private System.Windows.Forms.Label lblNguoiThue;
        private System.Windows.Forms.TextBox txtTienCoc;
        private System.Windows.Forms.Label lblPhong;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Button btnXuat;
    }
}