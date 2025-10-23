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
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.txtIDHopDong = new System.Windows.Forms.TextBox();
            this.cboNguoiThue = new System.Windows.Forms.ComboBox();
            this.txtTienCoc = new System.Windows.Forms.TextBox();
            this.lblIDHopDong = new System.Windows.Forms.Label();
            this.lblNguoiThue = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblTienCoc = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.txtTimHD = new System.Windows.Forms.TextBox();
            this.btnTimHD = new System.Windows.Forms.Button();
            this.lblTimHopDong = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Location = new System.Drawing.Point(28, 348);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.RowHeadersWidth = 51;
            this.dgvHopDong.RowTemplate.Height = 29;
            this.dgvHopDong.Size = new System.Drawing.Size(760, 240);
            this.dgvHopDong.TabIndex = 0;
            // 
            // txtIDHopDong
            // 
            this.txtIDHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDHopDong.Location = new System.Drawing.Point(215, 20);
            this.txtIDHopDong.Name = "txtIDHopDong";
            this.txtIDHopDong.ReadOnly = true;
            this.txtIDHopDong.Size = new System.Drawing.Size(200, 38);
            this.txtIDHopDong.TabIndex = 17;
            // 
            // cboNguoiThue
            // 
            this.cboNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguoiThue.Location = new System.Drawing.Point(215, 120);
            this.cboNguoiThue.Name = "cboNguoiThue";
            this.cboNguoiThue.Size = new System.Drawing.Size(200, 39);
            this.cboNguoiThue.TabIndex = 14;
            // 
            // txtTienCoc
            // 
            this.txtTienCoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienCoc.Location = new System.Drawing.Point(622, 120);
            this.txtTienCoc.Name = "txtTienCoc";
            this.txtTienCoc.ReadOnly = true;
            this.txtTienCoc.Size = new System.Drawing.Size(200, 38);
            this.txtTienCoc.TabIndex = 11;
            // 
            // lblIDHopDong
            // 
            this.lblIDHopDong.AutoSize = true;
            this.lblIDHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDHopDong.Location = new System.Drawing.Point(22, 20);
            this.lblIDHopDong.Name = "lblIDHopDong";
            this.lblIDHopDong.Size = new System.Drawing.Size(187, 32);
            this.lblIDHopDong.TabIndex = 10;
            this.lblIDHopDong.Text = "Mã hợp đồng:";
            // 
            // lblNguoiThue
            // 
            this.lblNguoiThue.AutoSize = true;
            this.lblNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiThue.Location = new System.Drawing.Point(22, 120);
            this.lblNguoiThue.Name = "lblNguoiThue";
            this.lblNguoiThue.Size = new System.Drawing.Size(160, 32);
            this.lblNguoiThue.TabIndex = 7;
            this.lblNguoiThue.Text = "Người thuê:";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Location = new System.Drawing.Point(426, 20);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(190, 32);
            this.lblNgayBatDau.TabIndex = 6;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(426, 70);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(194, 32);
            this.lblNgayKetThuc.TabIndex = 5;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // lblTienCoc
            // 
            this.lblTienCoc.AutoSize = true;
            this.lblTienCoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienCoc.Location = new System.Drawing.Point(426, 120);
            this.lblTienCoc.Name = "lblTienCoc";
            this.lblTienCoc.Size = new System.Drawing.Size(121, 32);
            this.lblTienCoc.TabIndex = 4;
            this.lblTienCoc.Text = "Tiền cọc";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(540, 194);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 25;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkGreen;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoa.Location = new System.Drawing.Point(407, 194);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 26;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSua.Location = new System.Drawing.Point(137, 194);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Location = new System.Drawing.Point(271, 194);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // cboPhong
            // 
            this.cboPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhong.Location = new System.Drawing.Point(215, 70);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 39);
            this.cboPhong.TabIndex = 15;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(22, 70);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(145, 32);
            this.lblPhong.TabIndex = 8;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // txtTimHD
            // 
            this.txtTimHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimHD.Location = new System.Drawing.Point(356, 263);
            this.txtTimHD.Name = "txtTimHD";
            this.txtTimHD.Size = new System.Drawing.Size(151, 38);
            this.txtTimHD.TabIndex = 43;
            // 
            // btnTimHD
            // 
            this.btnTimHD.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimHD.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimHD.Location = new System.Drawing.Point(540, 263);
            this.btnTimHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimHD.Name = "btnTimHD";
            this.btnTimHD.Size = new System.Drawing.Size(100, 32);
            this.btnTimHD.TabIndex = 42;
            this.btnTimHD.Text = "Tìm";
            this.btnTimHD.UseVisualStyleBackColor = false;
            // 
            // lblTimHopDong
            // 
            this.lblTimHopDong.AutoSize = true;
            this.lblTimHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimHopDong.Location = new System.Drawing.Point(112, 263);
            this.lblTimHopDong.Name = "lblTimHopDong";
            this.lblTimHopDong.Size = new System.Drawing.Size(187, 32);
            this.lblTimHopDong.TabIndex = 41;
            this.lblTimHopDong.Text = "Tìm hợp đồng";
    
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(622, 20);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayBD.TabIndex = 44;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(622, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 38);
            this.dateTimePicker1.TabIndex = 45;
            // 
            // frmHopDong
            // 
            this.ClientSize = new System.Drawing.Size(938, 600);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dtpNgayBD);
            this.Controls.Add(this.txtTimHD);
            this.Controls.Add(this.btnTimHD);
            this.Controls.Add(this.lblTimHopDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblTienCoc);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblNguoiThue);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblIDHopDong);
            this.Controls.Add(this.txtTienCoc);
            this.Controls.Add(this.cboNguoiThue);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.txtIDHopDong);
            this.Controls.Add(this.dgvHopDong);
            this.Name = "frmHopDong";
            this.Text = "Quản lý Hợp đồng thuê phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.TextBox txtIDHopDong;
        private System.Windows.Forms.ComboBox cboNguoiThue;
        private System.Windows.Forms.TextBox txtTienCoc;

        private System.Windows.Forms.Label lblIDHopDong;
        private System.Windows.Forms.Label lblNguoiThue;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblTienCoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtTimHD;
        private System.Windows.Forms.Button btnTimHD;
        private System.Windows.Forms.Label lblTimHopDong;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}