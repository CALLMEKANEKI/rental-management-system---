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
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
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
            this.lblMaLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLePhi.Location = new System.Drawing.Point(40, 30);
            this.lblMaLePhi.Name = "lblMaLePhi";
            this.lblMaLePhi.Size = new System.Drawing.Size(137, 32);
            this.lblMaLePhi.TabIndex = 8;
            this.lblMaLePhi.Text = "Mã lệ phí:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(40, 80);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(145, 32);
            this.lblPhong.TabIndex = 7;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // lblTienDV
            // 
            this.lblTienDV.AutoSize = true;
            this.lblTienDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDV.Location = new System.Drawing.Point(40, 130);
            this.lblTienDV.Name = "lblTienDV";
            this.lblTienDV.Size = new System.Drawing.Size(167, 32);
            this.lblTienDV.TabIndex = 6;
            this.lblTienDV.Text = "Tiền dịch vụ";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.Location = new System.Drawing.Point(40, 180);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(149, 32);
            this.lblThanhTien.TabIndex = 5;
            this.lblThanhTien.Text = "Thành tiền";
         
            // 
            // txtMaLePhi
            // 
            this.txtMaLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLePhi.Location = new System.Drawing.Point(276, 30);
            this.txtMaLePhi.Name = "txtMaLePhi";
            this.txtMaLePhi.ReadOnly = true;
            this.txtMaLePhi.Size = new System.Drawing.Size(200, 38);
            this.txtMaLePhi.TabIndex = 12;
            // 
            // cboPhong
            // 
            this.cboPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhong.Location = new System.Drawing.Point(276, 80);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 39);
            this.cboPhong.TabIndex = 11;
            // 
            // txtTienDV
            // 
            this.txtTienDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDV.Location = new System.Drawing.Point(276, 130);
            this.txtTienDV.Name = "txtTienDV";
            this.txtTienDV.ReadOnly = true;
            this.txtTienDV.Size = new System.Drawing.Size(200, 38);
            this.txtTienDV.TabIndex = 10;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(276, 180);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(200, 38);
            this.txtThanhTien.TabIndex = 9;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(532, 239);
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
            this.btnXoa.Location = new System.Drawing.Point(398, 239);
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
            this.btnSua.Location = new System.Drawing.Point(260, 239);
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
            this.btnThem.Location = new System.Drawing.Point(128, 239);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // frmLePhi
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
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
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
    }
}