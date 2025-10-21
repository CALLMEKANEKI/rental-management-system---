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
            this.cboChuTro = new System.Windows.Forms.ComboBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.cboNguoiThue = new System.Windows.Forms.ComboBox();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.txtTienCoc = new System.Windows.Forms.TextBox();
            this.lblIDHopDong = new System.Windows.Forms.Label();
            this.lblChuTro = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblNguoiThue = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblTienCoc = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Location = new System.Drawing.Point(20, 330);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.RowHeadersWidth = 51;
            this.dgvHopDong.RowTemplate.Height = 29;
            this.dgvHopDong.Size = new System.Drawing.Size(760, 240);
            this.dgvHopDong.TabIndex = 0;
            // 
            // txtIDHopDong
            // 
            this.txtIDHopDong.Location = new System.Drawing.Point(160, 30);
            this.txtIDHopDong.Name = "txtIDHopDong";
            this.txtIDHopDong.Size = new System.Drawing.Size(200, 22);
            this.txtIDHopDong.TabIndex = 17;
            // 
            // cboChuTro
            // 
            this.cboChuTro.Location = new System.Drawing.Point(160, 70);
            this.cboChuTro.Name = "cboChuTro";
            this.cboChuTro.Size = new System.Drawing.Size(200, 24);
            this.cboChuTro.TabIndex = 16;
            // 
            // cboPhong
            // 
            this.cboPhong.Location = new System.Drawing.Point(160, 110);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 24);
            this.cboPhong.TabIndex = 15;
            // 
            // cboNguoiThue
            // 
            this.cboNguoiThue.Location = new System.Drawing.Point(160, 150);
            this.cboNguoiThue.Name = "cboNguoiThue";
            this.cboNguoiThue.Size = new System.Drawing.Size(200, 24);
            this.cboNguoiThue.TabIndex = 14;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Location = new System.Drawing.Point(160, 190);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayBatDau.TabIndex = 13;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(160, 230);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayKetThuc.TabIndex = 12;
            // 
            // txtTienCoc
            // 
            this.txtTienCoc.Location = new System.Drawing.Point(160, 270);
            this.txtTienCoc.Name = "txtTienCoc";
            this.txtTienCoc.Size = new System.Drawing.Size(200, 22);
            this.txtTienCoc.TabIndex = 11;
            // 
            // lblIDHopDong
            // 
            this.lblIDHopDong.AutoSize = true;
            this.lblIDHopDong.Location = new System.Drawing.Point(40, 33);
            this.lblIDHopDong.Name = "lblIDHopDong";
            this.lblIDHopDong.Size = new System.Drawing.Size(89, 16);
            this.lblIDHopDong.TabIndex = 10;
            this.lblIDHopDong.Text = "Mã hợp đồng:";
            // 
            // lblChuTro
            // 
            this.lblChuTro.AutoSize = true;
            this.lblChuTro.Location = new System.Drawing.Point(40, 73);
            this.lblChuTro.Name = "lblChuTro";
            this.lblChuTro.Size = new System.Drawing.Size(51, 16);
            this.lblChuTro.TabIndex = 9;
            this.lblChuTro.Text = "Chủ trọ:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(40, 113);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(67, 16);
            this.lblPhong.TabIndex = 8;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // lblNguoiThue
            // 
            this.lblNguoiThue.AutoSize = true;
            this.lblNguoiThue.Location = new System.Drawing.Point(40, 153);
            this.lblNguoiThue.Name = "lblNguoiThue";
            this.lblNguoiThue.Size = new System.Drawing.Size(74, 16);
            this.lblNguoiThue.TabIndex = 7;
            this.lblNguoiThue.Text = "Người thuê:";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(40, 193);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(91, 16);
            this.lblNgayBatDau.TabIndex = 6;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(40, 233);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(91, 16);
            this.lblNgayKetThuc.TabIndex = 5;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // lblTienCoc
            // 
            this.lblTienCoc.AutoSize = true;
            this.lblTienCoc.Location = new System.Drawing.Point(40, 273);
            this.lblTienCoc.Name = "lblTienCoc";
            this.lblTienCoc.Size = new System.Drawing.Size(59, 16);
            this.lblTienCoc.TabIndex = 4;
            this.lblTienCoc.Text = "Tiền cọc";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(420, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(420, 75);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(420, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(420, 165);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmHopDong
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblTienCoc);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblNguoiThue);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblChuTro);
            this.Controls.Add(this.lblIDHopDong);
            this.Controls.Add(this.txtTienCoc);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.cboNguoiThue);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.cboChuTro);
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
        private System.Windows.Forms.ComboBox cboChuTro;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.ComboBox cboNguoiThue;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.TextBox txtTienCoc;

        private System.Windows.Forms.Label lblIDHopDong;
        private System.Windows.Forms.Label lblChuTro;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblNguoiThue;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblTienCoc;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}