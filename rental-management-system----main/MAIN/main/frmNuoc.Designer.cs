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
            this.dgvNuoc = new System.Windows.Forms.DataGridView();
            this.lblMaNuoc = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblChiSoCu = new System.Windows.Forms.Label();
            this.lblChiSoMoi = new System.Windows.Forms.Label();
            this.lblSoNuocTieuThu = new System.Windows.Forms.Label();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.txtMaNuoc = new System.Windows.Forms.TextBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.txtChiSoCu = new System.Windows.Forms.TextBox();
            this.txtChiSoMoi = new System.Windows.Forms.TextBox();
            this.txtSoNuocTieuThu = new System.Windows.Forms.TextBox();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNuoc
            // 
            this.dgvNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNuoc.Location = new System.Drawing.Point(20, 340);
            this.dgvNuoc.Name = "dgvNuoc";
            this.dgvNuoc.RowHeadersWidth = 51;
            this.dgvNuoc.RowTemplate.Height = 29;
            this.dgvNuoc.Size = new System.Drawing.Size(760, 240);
            this.dgvNuoc.TabIndex = 0;
            // 
            // lblMaNuoc
            // 
            this.lblMaNuoc.AutoSize = true;
            this.lblMaNuoc.Location = new System.Drawing.Point(40, 35);
            this.lblMaNuoc.Name = "lblMaNuoc";
            this.lblMaNuoc.Size = new System.Drawing.Size(61, 16);
            this.lblMaNuoc.TabIndex = 11;
            this.lblMaNuoc.Text = "Mã nước:";
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
            this.lblChiSoCu.Size = new System.Drawing.Size(90, 16);
            this.lblChiSoCu.TabIndex = 9;
            this.lblChiSoCu.Text = "Chỉ số cũ (m³):";
            // 
            // lblChiSoMoi
            // 
            this.lblChiSoMoi.AutoSize = true;
            this.lblChiSoMoi.Location = new System.Drawing.Point(40, 155);
            this.lblChiSoMoi.Name = "lblChiSoMoi";
            this.lblChiSoMoi.Size = new System.Drawing.Size(98, 16);
            this.lblChiSoMoi.TabIndex = 8;
            this.lblChiSoMoi.Text = "Chỉ số mới (m³):";
            // 
            // lblSoNuocTieuThu
            // 
            this.lblSoNuocTieuThu.AutoSize = true;
            this.lblSoNuocTieuThu.Location = new System.Drawing.Point(40, 195);
            this.lblSoNuocTieuThu.Name = "lblSoNuocTieuThu";
            this.lblSoNuocTieuThu.Size = new System.Drawing.Size(86, 16);
            this.lblSoNuocTieuThu.TabIndex = 7;
            this.lblSoNuocTieuThu.Text = "Nước tiêu thụ:";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Location = new System.Drawing.Point(40, 235);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(108, 16);
            this.lblTienNuoc.TabIndex = 6;
            this.lblTienNuoc.Text = "Tiền nước (VNĐ):";
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
            // txtMaNuoc
            // 
            this.txtMaNuoc.Location = new System.Drawing.Point(160, 32);
            this.txtMaNuoc.Name = "txtMaNuoc";
            this.txtMaNuoc.Size = new System.Drawing.Size(200, 22);
            this.txtMaNuoc.TabIndex = 17;
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
            // txtSoNuocTieuThu
            // 
            this.txtSoNuocTieuThu.Location = new System.Drawing.Point(160, 192);
            this.txtSoNuocTieuThu.Name = "txtSoNuocTieuThu";
            this.txtSoNuocTieuThu.ReadOnly = true;
            this.txtSoNuocTieuThu.Size = new System.Drawing.Size(200, 22);
            this.txtSoNuocTieuThu.TabIndex = 13;
            // 
            // txtTienNuoc
            // 
            this.txtTienNuoc.Location = new System.Drawing.Point(160, 232);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.ReadOnly = true;
            this.txtTienNuoc.Size = new System.Drawing.Size(200, 22);
            this.txtTienNuoc.TabIndex = 12;
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
            // frmNuoc
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblTienNuoc);
            this.Controls.Add(this.lblSoNuocTieuThu);
            this.Controls.Add(this.lblChiSoMoi);
            this.Controls.Add(this.lblChiSoCu);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblMaNuoc);
            this.Controls.Add(this.txtTienNuoc);
            this.Controls.Add(this.txtSoNuocTieuThu);
            this.Controls.Add(this.txtChiSoMoi);
            this.Controls.Add(this.txtChiSoCu);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.txtMaNuoc);
            this.Controls.Add(this.dtpThang);
            this.Controls.Add(this.dgvNuoc);
            this.Name = "frmNuoc";
            this.Text = "Quản lý tiền nước";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNuoc;
        private System.Windows.Forms.Label lblMaNuoc;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblChiSoCu;
        private System.Windows.Forms.Label lblChiSoMoi;
        private System.Windows.Forms.Label lblSoNuocTieuThu;
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.Label lblThang;

        private System.Windows.Forms.TextBox txtMaNuoc;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.TextBox txtChiSoCu;
        private System.Windows.Forms.TextBox txtChiSoMoi;
        private System.Windows.Forms.TextBox txtSoNuocTieuThu;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.DateTimePicker dtpThang;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnLamMoi;
    }
}