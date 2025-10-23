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
            this.lblTienDien = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.txtMaDien = new System.Windows.Forms.TextBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.txtChiSoCu = new System.Windows.Forms.TextBox();
            this.txtChiSoMoi = new System.Windows.Forms.TextBox();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
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
            this.lblMaDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDien.Location = new System.Drawing.Point(42, 9);
            this.lblMaDien.Name = "lblMaDien";
            this.lblMaDien.Size = new System.Drawing.Size(123, 32);
            this.lblMaDien.TabIndex = 11;
            this.lblMaDien.Text = "Mã điện:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(42, 49);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(145, 32);
            this.lblPhong.TabIndex = 10;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // lblChiSoCu
            // 
            this.lblChiSoCu.AutoSize = true;
            this.lblChiSoCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiSoCu.Location = new System.Drawing.Point(42, 92);
            this.lblChiSoCu.Name = "lblChiSoCu";
            this.lblChiSoCu.Size = new System.Drawing.Size(131, 32);
            this.lblChiSoCu.TabIndex = 9;
            this.lblChiSoCu.Text = "Chỉ số cũ";
            // 
            // lblChiSoMoi
            // 
            this.lblChiSoMoi.AutoSize = true;
            this.lblChiSoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiSoMoi.Location = new System.Drawing.Point(42, 142);
            this.lblChiSoMoi.Name = "lblChiSoMoi";
            this.lblChiSoMoi.Size = new System.Drawing.Size(147, 32);
            this.lblChiSoMoi.TabIndex = 8;
            this.lblChiSoMoi.Text = "Chỉ số mới";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDien.Location = new System.Drawing.Point(42, 186);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(132, 32);
            this.lblTienDien.TabIndex = 6;
            this.lblTienDien.Text = "Tiền điện";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(42, 230);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(127, 32);
            this.lblThang.TabIndex = 5;
            this.lblThang.Text = "Ngày tạo";
            // 
            // txtMaDien
            // 
            this.txtMaDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDien.Location = new System.Drawing.Point(205, 3);
            this.txtMaDien.Name = "txtMaDien";
            this.txtMaDien.ReadOnly = true;
            this.txtMaDien.Size = new System.Drawing.Size(200, 38);
            this.txtMaDien.TabIndex = 17;
            // 
            // cboPhong
            // 
            this.cboPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhong.Location = new System.Drawing.Point(205, 47);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 39);
            this.cboPhong.TabIndex = 16;
            // 
            // txtChiSoCu
            // 
            this.txtChiSoCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoCu.Location = new System.Drawing.Point(205, 92);
            this.txtChiSoCu.Name = "txtChiSoCu";
            this.txtChiSoCu.ReadOnly = true;
            this.txtChiSoCu.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoCu.TabIndex = 15;
            // 
            // txtChiSoMoi
            // 
            this.txtChiSoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoMoi.Location = new System.Drawing.Point(205, 136);
            this.txtChiSoMoi.Name = "txtChiSoMoi";
            this.txtChiSoMoi.ReadOnly = true;
            this.txtChiSoMoi.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoMoi.TabIndex = 14;
            // 
            // txtTienDien
            // 
            this.txtTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDien.Location = new System.Drawing.Point(205, 180);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.ReadOnly = true;
            this.txtTienDien.Size = new System.Drawing.Size(200, 38);
            this.txtTienDien.TabIndex = 12;
            // 
            // dtpThang
            // 
            this.dtpThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThang.Location = new System.Drawing.Point(205, 224);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(200, 38);
            this.dtpThang.TabIndex = 18;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(438, 294);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(103, 35);
            this.btnLamMoi.TabIndex = 25;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkGreen;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoa.Location = new System.Drawing.Point(308, 294);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(103, 35);
            this.btnXoa.TabIndex = 26;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSua.Location = new System.Drawing.Point(178, 294);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(103, 35);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Location = new System.Drawing.Point(48, 294);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(103, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // frmDien
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblTienDien);
            this.Controls.Add(this.lblChiSoMoi);
            this.Controls.Add(this.lblChiSoCu);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblMaDien);
            this.Controls.Add(this.txtTienDien);
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
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.Label lblThang;

        private System.Windows.Forms.TextBox txtMaDien;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.TextBox txtChiSoCu;
        private System.Windows.Forms.TextBox txtChiSoMoi;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.DateTimePicker dtpThang;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
    }
}