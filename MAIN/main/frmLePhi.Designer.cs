namespace MAIN.main
{
    partial class frmLePhi
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
            this.dgvLePhi = new System.Windows.Forms.DataGridView();
            this.lblMaLePhi = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblTienDV = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.txtMaLePhi = new System.Windows.Forms.TextBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.txtTienDV = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLePhi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLePhi
            // 
            this.dgvLePhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLePhi.Location = new System.Drawing.Point(20, 280);
            this.dgvLePhi.Name = "dgvLePhi";
            this.dgvLePhi.RowHeadersWidth = 51;
            this.dgvLePhi.RowTemplate.Height = 29;
            this.dgvLePhi.Size = new System.Drawing.Size(760, 300);
            this.dgvLePhi.TabIndex = 0;
            // 
            // lblMaLePhi
            // 
            this.lblMaLePhi.AutoSize = true;
            this.lblMaLePhi.Location = new System.Drawing.Point(40, 35);
            this.lblMaLePhi.Name = "lblMaLePhi";
            this.lblMaLePhi.Size = new System.Drawing.Size(64, 16);
            this.lblMaLePhi.TabIndex = 8;
            this.lblMaLePhi.Text = "Mã lệ phí:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(40, 75);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(67, 16);
            this.lblPhong.TabIndex = 7;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // lblTienDV
            // 
            this.lblTienDV.AutoSize = true;
            this.lblTienDV.Location = new System.Drawing.Point(40, 115);
            this.lblTienDV.Name = "lblTienDV";
            this.lblTienDV.Size = new System.Drawing.Size(121, 16);
            this.lblTienDV.TabIndex = 6;
            this.lblTienDV.Text = "Tiền dịch vụ (VNĐ):";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(40, 155);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(111, 16);
            this.lblThanhTien.TabIndex = 5;
            this.lblThanhTien.Text = "Thành tiền (VNĐ):";
            // 
            // txtMaLePhi
            // 
            this.txtMaLePhi.Location = new System.Drawing.Point(180, 32);
            this.txtMaLePhi.Name = "txtMaLePhi";
            this.txtMaLePhi.Size = new System.Drawing.Size(200, 22);
            this.txtMaLePhi.TabIndex = 12;
            // 
            // cboPhong
            // 
            this.cboPhong.Location = new System.Drawing.Point(180, 72);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 24);
            this.cboPhong.TabIndex = 11;
            // 
            // txtTienDV
            // 
            this.txtTienDV.Location = new System.Drawing.Point(180, 112);
            this.txtTienDV.Name = "txtTienDV";
            this.txtTienDV.Size = new System.Drawing.Size(200, 22);
            this.txtTienDV.TabIndex = 10;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(180, 152);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(200, 22);
            this.txtThanhTien.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(430, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(430, 75);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(430, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(430, 165);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(100, 35);
            this.btnTinhTien.TabIndex = 1;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(430, 210);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmLePhi
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lblTienDV);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblMaLePhi);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.txtTienDV);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.txtMaLePhi);
            this.Controls.Add(this.dgvLePhi);
            this.Name = "frmLePhi";
            this.Text = "Quản lý lệ phí / phí dịch vụ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLePhi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLePhi;
        private System.Windows.Forms.Label lblMaLePhi;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblTienDV;
        private System.Windows.Forms.Label lblThanhTien;

        private System.Windows.Forms.TextBox txtMaLePhi;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.TextBox txtTienDV;
        private System.Windows.Forms.TextBox txtThanhTien;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnLamMoi;
    }
}