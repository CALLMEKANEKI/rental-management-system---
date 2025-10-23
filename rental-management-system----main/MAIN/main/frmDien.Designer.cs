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
            this.dgvDien = new System.Windows.Forms.DataGridView();
            this.lblMaDien = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblChiSoCu = new System.Windows.Forms.Label();
            this.lblChiSoMoi = new System.Windows.Forms.Label();
            this.lblSoDienTieuThu = new System.Windows.Forms.Label();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.txtMaDien = new System.Windows.Forms.TextBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.txtChiSoCu = new System.Windows.Forms.TextBox();
            this.txtChiSoMoi = new System.Windows.Forms.TextBox();
            this.txtSoDienTieuThu = new System.Windows.Forms.TextBox();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDien
            // 
            this.dgvDien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDien.Location = new System.Drawing.Point(20, 340);
            this.dgvDien.Name = "dgvDien";
            this.dgvDien.RowHeadersWidth = 51;
            this.dgvDien.RowTemplate.Height = 29;
            this.dgvDien.Size = new System.Drawing.Size(760, 240);
            this.dgvDien.TabIndex = 0;
            // 
            // lblMaDien
            // 
            this.lblMaDien.AutoSize = true;
            this.lblMaDien.Location = new System.Drawing.Point(40, 35);
            this.lblMaDien.Name = "lblMaDien";
            this.lblMaDien.Size = new System.Drawing.Size(58, 16);
            this.lblMaDien.TabIndex = 11;
            this.lblMaDien.Text = "Mã điện:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(40, 75);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(67, 16);
            this.lblPhong.TabIndex = 10;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // lblChiSoCu
            // 
            this.lblChiSoCu.AutoSize = true;
            this.lblChiSoCu.Location = new System.Drawing.Point(40, 115);
            this.lblChiSoCu.Name = "lblChiSoCu";
            this.lblChiSoCu.Size = new System.Drawing.Size(102, 16);
            this.lblChiSoCu.TabIndex = 9;
            this.lblChiSoCu.Text = "Chỉ số cũ (kWh):";
            // 
            // lblChiSoMoi
            // 
            this.lblChiSoMoi.AutoSize = true;
            this.lblChiSoMoi.Location = new System.Drawing.Point(40, 155);
            this.lblChiSoMoi.Name = "lblChiSoMoi";
            this.lblChiSoMoi.Size = new System.Drawing.Size(110, 16);
            this.lblChiSoMoi.TabIndex = 8;
            this.lblChiSoMoi.Text = "Chỉ số mới (kWh):";
            // 
            // lblSoDienTieuThu
            // 
            this.lblSoDienTieuThu.AutoSize = true;
            this.lblSoDienTieuThu.Location = new System.Drawing.Point(40, 195);
            this.lblSoDienTieuThu.Name = "lblSoDienTieuThu";
            this.lblSoDienTieuThu.Size = new System.Drawing.Size(81, 16);
            this.lblSoDienTieuThu.TabIndex = 7;
            this.lblSoDienTieuThu.Text = "Điện tiêu thụ:";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Location = new System.Drawing.Point(40, 235);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(105, 16);
            this.lblTienDien.TabIndex = 6;
            this.lblTienDien.Text = "Tiền điện (VNĐ):";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(40, 275);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(49, 16);
            this.lblThang.TabIndex = 5;
            this.lblThang.Text = "Tháng:";
            // 
            // txtMaDien
            // 
            this.txtMaDien.Location = new System.Drawing.Point(160, 32);
            this.txtMaDien.Name = "txtMaDien";
            this.txtMaDien.Size = new System.Drawing.Size(200, 22);
            this.txtMaDien.TabIndex = 17;
            // 
            // cboPhong
            // 
            this.cboPhong.Location = new System.Drawing.Point(160, 72);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 24);
            this.cboPhong.TabIndex = 16;
            // 
            // txtChiSoCu
            // 
            this.txtChiSoCu.Location = new System.Drawing.Point(160, 112);
            this.txtChiSoCu.Name = "txtChiSoCu";
            this.txtChiSoCu.Size = new System.Drawing.Size(200, 22);
            this.txtChiSoCu.TabIndex = 15;
            // 
            // txtChiSoMoi
            // 
            this.txtChiSoMoi.Location = new System.Drawing.Point(160, 152);
            this.txtChiSoMoi.Name = "txtChiSoMoi";
            this.txtChiSoMoi.Size = new System.Drawing.Size(200, 22);
            this.txtChiSoMoi.TabIndex = 14;
            // 
            // txtSoDienTieuThu
            // 
            this.txtSoDienTieuThu.Location = new System.Drawing.Point(160, 192);
            this.txtSoDienTieuThu.Name = "txtSoDienTieuThu";
            this.txtSoDienTieuThu.ReadOnly = true;
            this.txtSoDienTieuThu.Size = new System.Drawing.Size(200, 22);
            this.txtSoDienTieuThu.TabIndex = 13;
            // 
            // txtTienDien
            // 
            this.txtTienDien.Location = new System.Drawing.Point(160, 232);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.ReadOnly = true;
            this.txtTienDien.Size = new System.Drawing.Size(200, 22);
            this.txtTienDien.TabIndex = 12;
            // 
            // dtpThang
            // 
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThang.Location = new System.Drawing.Point(160, 272);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(200, 22);
            this.dtpThang.TabIndex = 18;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(420, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(420, 75);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(420, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(420, 165);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(100, 35);
            this.btnTinhTien.TabIndex = 1;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(420, 210);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmDien
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblTienDien);
            this.Controls.Add(this.lblSoDienTieuThu);
            this.Controls.Add(this.lblChiSoMoi);
            this.Controls.Add(this.lblChiSoCu);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblMaDien);
            this.Controls.Add(this.txtTienDien);
            this.Controls.Add(this.txtSoDienTieuThu);
            this.Controls.Add(this.txtChiSoMoi);
            this.Controls.Add(this.txtChiSoCu);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.txtMaDien);
            this.Controls.Add(this.dtpThang);
            this.Controls.Add(this.dgvDien);
            this.Name = "frmDien";
            this.Text = "Quản lý tiền điện";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDien;
        private System.Windows.Forms.Label lblMaDien;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblChiSoCu;
        private System.Windows.Forms.Label lblChiSoMoi;
        private System.Windows.Forms.Label lblSoDienTieuThu;
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.Label lblThang;

        private System.Windows.Forms.TextBox txtMaDien;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.TextBox txtChiSoCu;
        private System.Windows.Forms.TextBox txtChiSoMoi;
        private System.Windows.Forms.TextBox txtSoDienTieuThu;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.DateTimePicker dtpThang;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnLamMoi;
    }
}