namespace MAIN.main
{
    partial class frmPhongTro
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
            this.dgvPhongTro = new System.Windows.Forms.DataGridView();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.txtGiaThue = new System.Windows.Forms.TextBox();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.lblGiaThue = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTimPhong = new System.Windows.Forms.Button();
            this.lblTimPhong = new System.Windows.Forms.Label();
            this.txtTimPhong = new System.Windows.Forms.TextBox();
            this.btnTraPhong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongTro)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhongTro
            // 
            this.dgvPhongTro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongTro.Location = new System.Drawing.Point(24, 435);
            this.dgvPhongTro.Name = "dgvPhongTro";
            this.dgvPhongTro.RowHeadersWidth = 51;
            this.dgvPhongTro.RowTemplate.Height = 29;
            this.dgvPhongTro.Size = new System.Drawing.Size(750, 250);
            this.dgvPhongTro.TabIndex = 0;
            this.dgvPhongTro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongTro_CellClick_1);
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhong.Location = new System.Drawing.Point(194, 30);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.ReadOnly = true;
            this.txtMaPhong.Size = new System.Drawing.Size(200, 38);
            this.txtMaPhong.TabIndex = 15;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhong.Location = new System.Drawing.Point(194, 80);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.ReadOnly = true;
            this.txtTenPhong.Size = new System.Drawing.Size(200, 38);
            this.txtTenPhong.TabIndex = 14;
            // 
            // txtGiaThue
            // 
            this.txtGiaThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaThue.Location = new System.Drawing.Point(194, 130);
            this.txtGiaThue.Name = "txtGiaThue";
            this.txtGiaThue.ReadOnly = true;
            this.txtGiaThue.Size = new System.Drawing.Size(200, 38);
            this.txtGiaThue.TabIndex = 12;
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinhTrang.Items.AddRange(new object[] {
            "Trống",
            "Đã thuê"});
            this.cboTinhTrang.Location = new System.Drawing.Point(194, 180);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(200, 39);
            this.cboTinhTrang.TabIndex = 11;
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhong.Location = new System.Drawing.Point(40, 30);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(148, 32);
            this.lblMaPhong.TabIndex = 9;
            this.lblMaPhong.Text = "Mã phòng:";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPhong.Location = new System.Drawing.Point(40, 80);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(158, 32);
            this.lblTenPhong.TabIndex = 8;
            this.lblTenPhong.Text = "Tên phòng:";
            // 
            // lblGiaThue
            // 
            this.lblGiaThue.AutoSize = true;
            this.lblGiaThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaThue.Location = new System.Drawing.Point(40, 130);
            this.lblGiaThue.Name = "lblGiaThue";
            this.lblGiaThue.Size = new System.Drawing.Size(122, 32);
            this.lblGiaThue.TabIndex = 6;
            this.lblGiaThue.Text = "Giá thuê";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhTrang.Location = new System.Drawing.Point(40, 180);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(150, 32);
            this.lblTinhTrang.TabIndex = 5;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(493, 226);
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
            this.btnXoa.Location = new System.Drawing.Point(344, 226);
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
            this.btnSua.Location = new System.Drawing.Point(194, 226);
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
            this.btnThem.Location = new System.Drawing.Point(56, 226);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnTimPhong
            // 
            this.btnTimPhong.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimPhong.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimPhong.Location = new System.Drawing.Point(128, 353);
            this.btnTimPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimPhong.Name = "btnTimPhong";
            this.btnTimPhong.Size = new System.Drawing.Size(166, 32);
            this.btnTimPhong.TabIndex = 31;
            this.btnTimPhong.Text = "Tìm phòng";
            this.btnTimPhong.UseVisualStyleBackColor = false;
            this.btnTimPhong.Click += new System.EventHandler(this.btnTimPhong_Click);
            // 
            // lblTimPhong
            // 
            this.lblTimPhong.AutoSize = true;
            this.lblTimPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimPhong.Location = new System.Drawing.Point(78, 291);
            this.lblTimPhong.Name = "lblTimPhong";
            this.lblTimPhong.Size = new System.Drawing.Size(211, 32);
            this.lblTimPhong.TabIndex = 29;
            this.lblTimPhong.Text = "Tìm phòng thuê";
            // 
            // txtTimPhong
            // 
            this.txtTimPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimPhong.Location = new System.Drawing.Point(315, 285);
            this.txtTimPhong.Name = "txtTimPhong";
            this.txtTimPhong.Size = new System.Drawing.Size(203, 38);
            this.txtTimPhong.TabIndex = 41;
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTraPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraPhong.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTraPhong.Location = new System.Drawing.Point(427, 353);
            this.btnTraPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(166, 32);
            this.btnTraPhong.TabIndex = 42;
            this.btnTraPhong.Text = "Trả phòng";
            this.btnTraPhong.UseVisualStyleBackColor = false;
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            // 
            // frmPhongTro
            // 
            this.ClientSize = new System.Drawing.Size(1924, 816);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.txtTimPhong);
            this.Controls.Add(this.btnTimPhong);
            this.Controls.Add(this.lblTimPhong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblGiaThue);
            this.Controls.Add(this.lblTenPhong);
            this.Controls.Add(this.lblMaPhong);
            this.Controls.Add(this.cboTinhTrang);
            this.Controls.Add(this.txtGiaThue);
            this.Controls.Add(this.txtTenPhong);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.dgvPhongTro);
            this.Name = "frmPhongTro";
            this.Text = "Quản lý Phòng trọ";
          
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongTro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhongTro;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtGiaThue;
        private System.Windows.Forms.ComboBox cboTinhTrang;

        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblGiaThue;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTimPhong;
        private System.Windows.Forms.Label lblTimPhong;
        private System.Windows.Forms.TextBox txtTimPhong;
        private System.Windows.Forms.Button btnTraPhong;
    }
}