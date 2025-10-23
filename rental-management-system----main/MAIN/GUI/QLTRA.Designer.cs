namespace qlpt.GUI
{
    partial class QLTRA
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.groupKhach = new System.Windows.Forms.GroupBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            this.dgvThuePhong = new System.Windows.Forms.DataGridView();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.btnXoaTrang = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.groupKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuePhong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(250, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(229, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Trả Phòng";
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(50, 60);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(180, 22);
            this.txtTimTen.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(240, 58);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm Kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.ColumnHeadersHeight = 29;
            this.dgvKhachHang.Location = new System.Drawing.Point(340, 54);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(380, 100);
            this.dgvKhachHang.TabIndex = 3;
            // 
            // groupKhach
            // 
            this.groupKhach.Controls.Add(this.txtTenKH);
            this.groupKhach.Controls.Add(this.txtSDT);
            this.groupKhach.Controls.Add(this.txtEmail);
            this.groupKhach.Controls.Add(this.cboGioiTinh);
            this.groupKhach.Controls.Add(this.txtDiaChi);
            this.groupKhach.Controls.Add(this.dtpNgayDi);
            this.groupKhach.Location = new System.Drawing.Point(30, 160);
            this.groupKhach.Name = "groupKhach";
            this.groupKhach.Size = new System.Drawing.Size(690, 120);
            this.groupKhach.TabIndex = 4;
            this.groupKhach.TabStop = false;
            this.groupKhach.Text = "Thông tin khách hàng";
            this.groupKhach.Enter += new System.EventHandler(this.groupKhach_Enter);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(20, 30);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(100, 22);
            this.txtTenKH.TabIndex = 0;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(200, 30);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(100, 22);
            this.txtSDT.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(400, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(20, 70);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(121, 24);
            this.cboGioiTinh.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(200, 70);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(100, 22);
            this.txtDiaChi.TabIndex = 4;
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.Location = new System.Drawing.Point(400, 70);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayDi.TabIndex = 5;
            // 
            // dgvThuePhong
            // 
            this.dgvThuePhong.AllowUserToAddRows = false;
            this.dgvThuePhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuePhong.ColumnHeadersHeight = 29;
            this.dgvThuePhong.Location = new System.Drawing.Point(30, 300);
            this.dgvThuePhong.Name = "dgvThuePhong";
            this.dgvThuePhong.RowHeadersWidth = 51;
            this.dgvThuePhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuePhong.Size = new System.Drawing.Size(690, 120);
            this.dgvThuePhong.TabIndex = 5;
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.Location = new System.Drawing.Point(118, 430);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(107, 23);
            this.btnTraPhong.TabIndex = 6;
            this.btnTraPhong.Text = "Trả Phòng";
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            // 
            // btnXoaTrang
            // 
            this.btnXoaTrang.Location = new System.Drawing.Point(280, 430);
            this.btnXoaTrang.Name = "btnXoaTrang";
            this.btnXoaTrang.Size = new System.Drawing.Size(75, 23);
            this.btnXoaTrang.TabIndex = 7;
            this.btnXoaTrang.Text = "Xóa Trắng";
            this.btnXoaTrang.Click += new System.EventHandler(this.btnXoaTrang_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(410, 430);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // QLTRA
            // 
            this.ClientSize = new System.Drawing.Size(771, 545);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTimTen);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.groupKhach);
            this.Controls.Add(this.dgvThuePhong);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.btnXoaTrang);
            this.Controls.Add(this.btnThoat);
            this.Name = "QLTRA";
            this.Text = "Quản Lý Trả Phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.groupKhach.ResumeLayout(false);
            this.groupKhach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuePhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTimTen;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.DataGridView dgvThuePhong;
        private System.Windows.Forms.GroupBox groupKhach;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgayDi;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.Button btnXoaTrang;
        private System.Windows.Forms.Button btnThoat;

    }
}