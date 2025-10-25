namespace MAIN.main
{
    partial class frmThanhToan
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
            this.grbLSthanhToan = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimThanhToan = new System.Windows.Forms.TextBox();
            this.dgvThanhToan = new System.Windows.Forms.DataGridView();
            this.btnTimThanhToan = new System.Windows.Forms.Button();
            this.grbThanhToan = new System.Windows.Forms.GroupBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.txtLePhi = new System.Windows.Forms.TextBox();
            this.lblLePhi = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.dtpNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.cboHoaDon = new System.Windows.Forms.ComboBox();
            this.cboNguoiThue = new System.Windows.Forms.ComboBox();
            this.lblNgayThanhToan = new System.Windows.Forms.Label();
            this.lblIdHoaDon = new System.Windows.Forms.Label();
            this.lblNguoiThue = new System.Windows.Forms.Label();
            this.grbLSthanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit();
            this.grbThanhToan.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(555, 32);
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
            this.btnXoa.Location = new System.Drawing.Point(893, 284);
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
            this.btnSua.Location = new System.Drawing.Point(772, 284);
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
            this.btnThem.Location = new System.Drawing.Point(646, 284);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grbLSthanhToan
            // 
            this.grbLSthanhToan.Controls.Add(this.label1);
            this.grbLSthanhToan.Controls.Add(this.txtTimThanhToan);
            this.grbLSthanhToan.Controls.Add(this.btnLamMoi);
            this.grbLSthanhToan.Controls.Add(this.dgvThanhToan);
            this.grbLSthanhToan.Controls.Add(this.btnTimThanhToan);
            this.grbLSthanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLSthanhToan.Location = new System.Drawing.Point(12, 361);
            this.grbLSthanhToan.Name = "grbLSthanhToan";
            this.grbLSthanhToan.Size = new System.Drawing.Size(1354, 626);
            this.grbLSthanhToan.TabIndex = 46;
            this.grbLSthanhToan.TabStop = false;
            this.grbLSthanhToan.Text = "Lịch sử thanh toán";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 45;
            // 
            // txtTimThanhToan
            // 
            this.txtTimThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimThanhToan.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTimThanhToan.Location = new System.Drawing.Point(12, 29);
            this.txtTimThanhToan.Name = "txtTimThanhToan";
            this.txtTimThanhToan.Size = new System.Drawing.Size(338, 38);
            this.txtTimThanhToan.TabIndex = 44;
            this.txtTimThanhToan.Text = "Nhập từ khóa để tìm kiếm";
            this.txtTimThanhToan.Enter += new System.EventHandler(this.txtTimThanhToan_Enter);
            this.txtTimThanhToan.Leave += new System.EventHandler(this.txtThanhToan_Leave);
            // 
            // dgvThanhToan
            // 
            this.dgvThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhToan.Location = new System.Drawing.Point(12, 84);
            this.dgvThanhToan.Name = "dgvThanhToan";
            this.dgvThanhToan.RowHeadersWidth = 51;
            this.dgvThanhToan.RowTemplate.Height = 29;
            this.dgvThanhToan.Size = new System.Drawing.Size(1336, 522);
            this.dgvThanhToan.TabIndex = 42;
            this.dgvThanhToan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThanhToan_CellClick);
            this.dgvThanhToan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichSuThanhToan_CellContentClick);
            // 
            // btnTimThanhToan
            // 
            this.btnTimThanhToan.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimThanhToan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimThanhToan.Location = new System.Drawing.Point(356, 34);
            this.btnTimThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimThanhToan.Name = "btnTimThanhToan";
            this.btnTimThanhToan.Size = new System.Drawing.Size(84, 32);
            this.btnTimThanhToan.TabIndex = 31;
            this.btnTimThanhToan.Text = "Tìm";
            this.btnTimThanhToan.UseVisualStyleBackColor = false;
            this.btnTimThanhToan.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // grbThanhToan
            // 
            this.grbThanhToan.Controls.Add(this.txtPhong);
            this.grbThanhToan.Controls.Add(this.lblPhong);
            this.grbThanhToan.Controls.Add(this.btnXoa);
            this.grbThanhToan.Controls.Add(this.btnSua);
            this.grbThanhToan.Controls.Add(this.txtTienNuoc);
            this.grbThanhToan.Controls.Add(this.btnThem);
            this.grbThanhToan.Controls.Add(this.txtTienDien);
            this.grbThanhToan.Controls.Add(this.lblTongTien);
            this.grbThanhToan.Controls.Add(this.txtTongTien);
            this.grbThanhToan.Controls.Add(this.lblTienNuoc);
            this.grbThanhToan.Controls.Add(this.lblTienDien);
            this.grbThanhToan.Controls.Add(this.txtLePhi);
            this.grbThanhToan.Controls.Add(this.lblLePhi);
            this.grbThanhToan.Controls.Add(this.txtNoiDung);
            this.grbThanhToan.Controls.Add(this.lblNoiDung);
            this.grbThanhToan.Controls.Add(this.dtpNgayThanhToan);
            this.grbThanhToan.Controls.Add(this.lblNgayTao);
            this.grbThanhToan.Controls.Add(this.dtpNgayTao);
            this.grbThanhToan.Controls.Add(this.cboHoaDon);
            this.grbThanhToan.Controls.Add(this.cboNguoiThue);
            this.grbThanhToan.Controls.Add(this.lblNgayThanhToan);
            this.grbThanhToan.Controls.Add(this.lblIdHoaDon);
            this.grbThanhToan.Controls.Add(this.lblNguoiThue);
            this.grbThanhToan.Location = new System.Drawing.Point(12, 12);
            this.grbThanhToan.Name = "grbThanhToan";
            this.grbThanhToan.Size = new System.Drawing.Size(1006, 343);
            this.grbThanhToan.TabIndex = 47;
            this.grbThanhToan.TabStop = false;
            // 
            // txtPhong
            // 
            this.txtPhong.Enabled = false;
            this.txtPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(246, 123);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(239, 38);
            this.txtPhong.TabIndex = 56;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(8, 123);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(97, 32);
            this.lblPhong.TabIndex = 55;
            this.lblPhong.Text = "Phòng";
            // 
            // txtTienNuoc
            // 
            this.txtTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienNuoc.Location = new System.Drawing.Point(754, 176);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.ReadOnly = true;
            this.txtTienNuoc.Size = new System.Drawing.Size(239, 38);
            this.txtTienNuoc.TabIndex = 54;
            // 
            // txtTienDien
            // 
            this.txtTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDien.Location = new System.Drawing.Point(754, 126);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.ReadOnly = true;
            this.txtTienDien.Size = new System.Drawing.Size(239, 38);
            this.txtTienDien.TabIndex = 53;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.BackColor = System.Drawing.Color.Maroon;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTongTien.Location = new System.Drawing.Point(516, 226);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(149, 32);
            this.lblTongTien.TabIndex = 51;
            this.lblTongTien.Text = "Thành tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.Maroon;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTongTien.Location = new System.Drawing.Point(754, 220);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(239, 38);
            this.txtTongTien.TabIndex = 52;
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNuoc.Location = new System.Drawing.Point(516, 176);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(139, 32);
            this.lblTienNuoc.TabIndex = 43;
            this.lblTienNuoc.Text = "Tiền nước";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDien.Location = new System.Drawing.Point(516, 126);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(132, 32);
            this.lblTienDien.TabIndex = 42;
            this.lblTienDien.Text = "Tiền điện";
            // 
            // txtLePhi
            // 
            this.txtLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLePhi.Location = new System.Drawing.Point(754, 76);
            this.txtLePhi.Name = "txtLePhi";
            this.txtLePhi.ReadOnly = true;
            this.txtLePhi.Size = new System.Drawing.Size(239, 38);
            this.txtLePhi.TabIndex = 41;
            // 
            // lblLePhi
            // 
            this.lblLePhi.AutoSize = true;
            this.lblLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLePhi.Location = new System.Drawing.Point(516, 76);
            this.lblLePhi.Name = "lblLePhi";
            this.lblLePhi.Size = new System.Drawing.Size(155, 32);
            this.lblLePhi.TabIndex = 40;
            this.lblLePhi.Text = "Tổng lệ phí";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(754, 26);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(239, 38);
            this.txtNoiDung.TabIndex = 39;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDung.Location = new System.Drawing.Point(516, 26);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(128, 32);
            this.lblNoiDung.TabIndex = 38;
            this.lblNoiDung.Text = "Nội dung";
            // 
            // dtpNgayThanhToan
            // 
            this.dtpNgayThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThanhToan.Location = new System.Drawing.Point(246, 223);
            this.dtpNgayThanhToan.Name = "dtpNgayThanhToan";
            this.dtpNgayThanhToan.Size = new System.Drawing.Size(239, 38);
            this.dtpNgayThanhToan.TabIndex = 37;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTao.Location = new System.Drawing.Point(8, 173);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(127, 32);
            this.lblNgayTao.TabIndex = 36;
            this.lblNgayTao.Text = "Ngày tạo";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Enabled = false;
            this.dtpNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(246, 173);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(239, 38);
            this.dtpNgayTao.TabIndex = 35;
            // 
            // cboHoaDon
            // 
            this.cboHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHoaDon.Location = new System.Drawing.Point(246, 23);
            this.cboHoaDon.Name = "cboHoaDon";
            this.cboHoaDon.Size = new System.Drawing.Size(239, 39);
            this.cboHoaDon.TabIndex = 30;
            this.cboHoaDon.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHoaDon_SelectedIndexChanged);
            // 
            // cboNguoiThue
            // 
            this.cboNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguoiThue.Location = new System.Drawing.Point(246, 73);
            this.cboNguoiThue.Name = "cboNguoiThue";
            this.cboNguoiThue.Size = new System.Drawing.Size(239, 39);
            this.cboNguoiThue.TabIndex = 31;
            // 
            // lblNgayThanhToan
            // 
            this.lblNgayThanhToan.AutoSize = true;
            this.lblNgayThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThanhToan.Location = new System.Drawing.Point(8, 223);
            this.lblNgayThanhToan.Name = "lblNgayThanhToan";
            this.lblNgayThanhToan.Size = new System.Drawing.Size(222, 32);
            this.lblNgayThanhToan.TabIndex = 32;
            this.lblNgayThanhToan.Text = "Ngày thanh toán";
            // 
            // lblIdHoaDon
            // 
            this.lblIdHoaDon.AutoSize = true;
            this.lblIdHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdHoaDon.Location = new System.Drawing.Point(8, 23);
            this.lblIdHoaDon.Name = "lblIdHoaDon";
            this.lblIdHoaDon.Size = new System.Drawing.Size(218, 32);
            this.lblIdHoaDon.TabIndex = 33;
            this.lblIdHoaDon.Text = "Mã hóa hóa đơn";
            // 
            // lblNguoiThue
            // 
            this.lblNguoiThue.AutoSize = true;
            this.lblNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiThue.Location = new System.Drawing.Point(8, 73);
            this.lblNguoiThue.Name = "lblNguoiThue";
            this.lblNguoiThue.Size = new System.Drawing.Size(152, 32);
            this.lblNguoiThue.TabIndex = 34;
            this.lblNguoiThue.Text = "Người thuê";
            // 
            // frmThanhToan
            // 
            this.ClientSize = new System.Drawing.Size(1378, 1055);
            this.Controls.Add(this.grbThanhToan);
            this.Controls.Add(this.grbLSthanhToan);
            this.Name = "frmThanhToan";
            this.Text = "Quản lý thanh toán hóa đơn";
            this.grbLSthanhToan.ResumeLayout(false);
            this.grbLSthanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit();
            this.grbThanhToan.ResumeLayout(false);
            this.grbThanhToan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grbLSthanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimThanhToan;
        private System.Windows.Forms.DataGridView dgvThanhToan;
        private System.Windows.Forms.Button btnTimThanhToan;
        private System.Windows.Forms.GroupBox grbThanhToan;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.ComboBox cboHoaDon;
        private System.Windows.Forms.ComboBox cboNguoiThue;
        private System.Windows.Forms.Label lblNgayThanhToan;
        private System.Windows.Forms.Label lblIdHoaDon;
        private System.Windows.Forms.Label lblNguoiThue;
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.TextBox txtLePhi;
        private System.Windows.Forms.Label lblLePhi;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.DateTimePicker dtpNgayThanhToan;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}