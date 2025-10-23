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
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.txtMaNuoc = new System.Windows.Forms.TextBox();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.txtChiSoCu = new System.Windows.Forms.TextBox();
            this.txtChiSoMoi = new System.Windows.Forms.TextBox();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.dtpTaoTienNuoc = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNuoc
            // 
            this.dgvNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNuoc.Location = new System.Drawing.Point(18, 355);
            this.dgvNuoc.Name = "dgvNuoc";
            this.dgvNuoc.RowHeadersWidth = 51;
            this.dgvNuoc.RowTemplate.Height = 29;
            this.dgvNuoc.Size = new System.Drawing.Size(760, 240);
            this.dgvNuoc.TabIndex = 0;
            // 
            // lblMaNuoc
            // 
            this.lblMaNuoc.AutoSize = true;
            this.lblMaNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNuoc.Location = new System.Drawing.Point(40, 20);
            this.lblMaNuoc.Name = "lblMaNuoc";
            this.lblMaNuoc.Size = new System.Drawing.Size(130, 32);
            this.lblMaNuoc.TabIndex = 11;
            this.lblMaNuoc.Text = "Mã nước:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(40, 70);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(145, 32);
            this.lblPhong.TabIndex = 10;
            this.lblPhong.Text = "Phòng trọ:";
            // 
            // lblChiSoCu
            // 
            this.lblChiSoCu.AutoSize = true;
            this.lblChiSoCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiSoCu.Location = new System.Drawing.Point(40, 120);
            this.lblChiSoCu.Name = "lblChiSoCu";
            this.lblChiSoCu.Size = new System.Drawing.Size(131, 32);
            this.lblChiSoCu.TabIndex = 9;
            this.lblChiSoCu.Text = "Chỉ số cũ";
            // 
            // lblChiSoMoi
            // 
            this.lblChiSoMoi.AutoSize = true;
            this.lblChiSoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiSoMoi.Location = new System.Drawing.Point(40, 170);
            this.lblChiSoMoi.Name = "lblChiSoMoi";
            this.lblChiSoMoi.Size = new System.Drawing.Size(147, 32);
            this.lblChiSoMoi.TabIndex = 8;
            this.lblChiSoMoi.Text = "Chỉ số mới";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNuoc.Location = new System.Drawing.Point(40, 270);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(139, 32);
            this.lblTienNuoc.TabIndex = 6;
            this.lblTienNuoc.Text = "Tiền nước";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(40, 220);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(127, 32);
            this.lblThang.TabIndex = 5;
            this.lblThang.Text = "Ngày tạo";
           
            // 
            // txtMaNuoc
            // 
            this.txtMaNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNuoc.Location = new System.Drawing.Point(194, 20);
            this.txtMaNuoc.Name = "txtMaNuoc";
            this.txtMaNuoc.Size = new System.Drawing.Size(200, 38);
            this.txtMaNuoc.TabIndex = 17;
            // 
            // cboPhong
            // 
            this.cboPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhong.Location = new System.Drawing.Point(194, 70);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(200, 39);
            this.cboPhong.TabIndex = 16;
            // 
            // txtChiSoCu
            // 
            this.txtChiSoCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoCu.Location = new System.Drawing.Point(194, 120);
            this.txtChiSoCu.Name = "txtChiSoCu";
            this.txtChiSoCu.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoCu.TabIndex = 15;
            // 
            // txtChiSoMoi
            // 
            this.txtChiSoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoMoi.Location = new System.Drawing.Point(194, 170);
            this.txtChiSoMoi.Name = "txtChiSoMoi";
            this.txtChiSoMoi.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoMoi.TabIndex = 14;
            // 
            // txtTienNuoc
            // 
            this.txtTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienNuoc.Location = new System.Drawing.Point(194, 220);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.ReadOnly = true;
            this.txtTienNuoc.Size = new System.Drawing.Size(200, 38);
            this.txtTienNuoc.TabIndex = 12;
            // 
            // dtpTaoTienNuoc
            // 
            this.dtpTaoTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTaoTienNuoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTaoTienNuoc.Location = new System.Drawing.Point(194, 270);
            this.dtpTaoTienNuoc.Name = "dtpTaoTienNuoc";
            this.dtpTaoTienNuoc.Size = new System.Drawing.Size(200, 38);
            this.dtpTaoTienNuoc.TabIndex = 18;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(504, 314);
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
            this.btnXoa.Location = new System.Drawing.Point(362, 314);
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
            this.btnSua.Location = new System.Drawing.Point(222, 314);
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
            this.btnThem.Location = new System.Drawing.Point(86, 314);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // frmNuoc
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblTienNuoc);
            this.Controls.Add(this.lblChiSoMoi);
            this.Controls.Add(this.lblChiSoCu);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblMaNuoc);
            this.Controls.Add(this.txtTienNuoc);
            this.Controls.Add(this.txtChiSoMoi);
            this.Controls.Add(this.txtChiSoCu);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.txtMaNuoc);
            this.Controls.Add(this.dtpTaoTienNuoc);
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
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.Label lblThang;

        private System.Windows.Forms.TextBox txtMaNuoc;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.TextBox txtChiSoCu;
        private System.Windows.Forms.TextBox txtChiSoMoi;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.DateTimePicker dtpTaoTienNuoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
    }
}