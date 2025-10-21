namespace qlpt.GUI
{
    partial class QLTHUE
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
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblKhach = new System.Windows.Forms.Label();
            this.lblNgayDen = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.cboKhach = new System.Windows.Forms.ComboBox();
            this.dtpNgayDen = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvThuePhong = new System.Windows.Forms.DataGridView();
            this.lblDanhSach = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuePhong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(180, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Thuê Phòng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(50, 70);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(139, 16);
            this.lblPhong.TabIndex = 1;
            this.lblPhong.Text = "Phòng chưa được thuê";
            // 
            // lblKhach
            // 
            this.lblKhach.AutoSize = true;
            this.lblKhach.Location = new System.Drawing.Point(50, 110);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new System.Drawing.Size(141, 16);
            this.lblKhach.TabIndex = 3;
            this.lblKhach.Text = "Thông tin Khách Hàng:";
            // 
            // lblNgayDen
            // 
            this.lblNgayDen.AutoSize = true;
            this.lblNgayDen.Location = new System.Drawing.Point(50, 150);
            this.lblNgayDen.Name = "lblNgayDen";
            this.lblNgayDen.Size = new System.Drawing.Size(69, 16);
            this.lblNgayDen.TabIndex = 5;
            this.lblNgayDen.Text = "Ngày đến:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.Location = new System.Drawing.Point(250, 67);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 24);
            this.cboPhong.TabIndex = 2;
            // 
            // cboKhach
            // 
            this.cboKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhach.Location = new System.Drawing.Point(250, 107);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new System.Drawing.Size(200, 24);
            this.cboKhach.TabIndex = 4;
            // 
            // dtpNgayDen
            // 
            this.dtpNgayDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDen.Location = new System.Drawing.Point(250, 147);
            this.dtpNgayDen.Name = "dtpNgayDen";
            this.dtpNgayDen.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayDen.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(480, 147);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 28);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm phòng thuê";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(640, 147);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvThuePhong
            // 
            this.dgvThuePhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuePhong.ColumnHeadersHeight = 29;
            this.dgvThuePhong.Location = new System.Drawing.Point(50, 230);
            this.dgvThuePhong.Name = "dgvThuePhong";
            this.dgvThuePhong.RowHeadersVisible = false;
            this.dgvThuePhong.RowHeadersWidth = 51;
            this.dgvThuePhong.Size = new System.Drawing.Size(700, 250);
            this.dgvThuePhong.TabIndex = 10;
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.Location = new System.Drawing.Point(50, 200);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(194, 23);
            this.lblDanhSach.TabIndex = 9;
            this.lblDanhSach.Text = "Danh Sách Thuê Phòng";
            // 
            // QLTHUE
            // 
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.lblKhach);
            this.Controls.Add(this.cboKhach);
            this.Controls.Add(this.lblNgayDen);
            this.Controls.Add(this.dtpNgayDen);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.dgvThuePhong);
            this.Name = "QLTHUE";
            this.Text = "Quản Lý Thuê Phòng";
            this.Load += new System.EventHandler(this.QLTHUE_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuePhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblKhach;
        private System.Windows.Forms.Label lblNgayDen;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.ComboBox cboKhach;
        private System.Windows.Forms.DateTimePicker dtpNgayDen;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvThuePhong;
        private System.Windows.Forms.Label lblDanhSach;
    }
}