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
            this.dgvThanhToan = new System.Windows.Forms.DataGridView();
            this.lblNguoiThue = new System.Windows.Forms.Label();
            this.lblHoaDon = new System.Windows.Forms.Label();
            this.lblNgayThanhToan = new System.Windows.Forms.Label();
            this.cboNguoiThue = new System.Windows.Forms.ComboBox();
            this.cboHoaDon = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtpNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThanhToan
            // 
            this.dgvThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhToan.Location = new System.Drawing.Point(20, 330);
            this.dgvThanhToan.Name = "dgvThanhToan";
            this.dgvThanhToan.RowHeadersWidth = 51;
            this.dgvThanhToan.RowTemplate.Height = 29;
            this.dgvThanhToan.Size = new System.Drawing.Size(820, 290);
            this.dgvThanhToan.TabIndex = 0;
            // 
            // lblNguoiThue
            // 
            this.lblNguoiThue.AutoSize = true;
            this.lblNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiThue.Location = new System.Drawing.Point(52, 40);
            this.lblNguoiThue.Name = "lblNguoiThue";
            this.lblNguoiThue.Size = new System.Drawing.Size(160, 32);
            this.lblNguoiThue.TabIndex = 14;
            this.lblNguoiThue.Text = "Người thuê:";
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.AutoSize = true;
            this.lblHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDon.Location = new System.Drawing.Point(52, 100);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Size = new System.Drawing.Size(129, 32);
            this.lblHoaDon.TabIndex = 13;
            this.lblHoaDon.Text = "Hóa đơn:";
            // 
            // lblNgayThanhToan
            // 
            this.lblNgayThanhToan.AutoSize = true;
            this.lblNgayThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThanhToan.Location = new System.Drawing.Point(52, 160);
            this.lblNgayThanhToan.Name = "lblNgayThanhToan";
            this.lblNgayThanhToan.Size = new System.Drawing.Size(230, 32);
            this.lblNgayThanhToan.TabIndex = 12;
            this.lblNgayThanhToan.Text = "Ngày thanh toán:";
            // 
            // cboNguoiThue
            // 
            this.cboNguoiThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguoiThue.Location = new System.Drawing.Point(288, 40);
            this.cboNguoiThue.Name = "cboNguoiThue";
            this.cboNguoiThue.Size = new System.Drawing.Size(200, 39);
            this.cboNguoiThue.TabIndex = 8;
            // 
            // cboHoaDon
            // 
            this.cboHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHoaDon.Location = new System.Drawing.Point(288, 100);
            this.cboHoaDon.Name = "cboHoaDon";
            this.cboHoaDon.Size = new System.Drawing.Size(200, 39);
            this.cboHoaDon.TabIndex = 7;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(485, 250);
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
            this.btnXoa.Location = new System.Drawing.Point(352, 250);
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
            this.btnSua.Location = new System.Drawing.Point(212, 250);
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
            this.btnThem.Location = new System.Drawing.Point(81, 250);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // dtpNgayThanhToan
            // 
            this.dtpNgayThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThanhToan.Location = new System.Drawing.Point(288, 160);
            this.dtpNgayThanhToan.Name = "dtpNgayThanhToan";
            this.dtpNgayThanhToan.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayThanhToan.TabIndex = 29;
            // 
            // frmThanhToan
            // 
            this.ClientSize = new System.Drawing.Size(870, 650);
            this.Controls.Add(this.dtpNgayThanhToan);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboHoaDon);
            this.Controls.Add(this.cboNguoiThue);
            this.Controls.Add(this.lblNgayThanhToan);
            this.Controls.Add(this.lblHoaDon);
            this.Controls.Add(this.lblNguoiThue);
            this.Controls.Add(this.dgvThanhToan);
            this.Name = "frmThanhToan";
            this.Text = "Quản lý thanh toán hóa đơn";
        
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThanhToan;
        private System.Windows.Forms.Label lblNguoiThue;
        private System.Windows.Forms.Label lblHoaDon;
        private System.Windows.Forms.Label lblNgayThanhToan;
        private System.Windows.Forms.ComboBox cboNguoiThue;
        private System.Windows.Forms.ComboBox cboHoaDon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dtpNgayThanhToan;
    }
}