namespace MAIN.main
{
    partial class frmHoaDon
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.lblLePhi = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.txtLePhi = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTienDV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChiSoDienCu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChiSoDienMoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChiSoNuocMoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChiSoNuocCu = new System.Windows.Forms.TextBox();
            this.txtTenPhong = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnTimHoaDon = new System.Windows.Forms.Button();
            this.lblTimHoaDon = new System.Windows.Forms.Label();
            this.txtTimHoaDon = new System.Windows.Forms.TextBox();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(29, 543);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 29;
            this.dgvHoaDon.Size = new System.Drawing.Size(850, 280);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoaDon.Location = new System.Drawing.Point(16, 20);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(171, 32);
            this.lblMaHoaDon.TabIndex = 12;
            this.lblMaHoaDon.Text = "Mã hóa đơn:";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.Location = new System.Drawing.Point(16, 70);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(142, 32);
            this.lblPhong.TabIndex = 11;
            this.lblPhong.Text = "Trạng thái";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(16, 120);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(127, 32);
            this.lblThang.TabIndex = 10;
            this.lblThang.Text = "Ngày tạo";
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienPhong.Location = new System.Drawing.Point(16, 170);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(128, 32);
            this.lblTienPhong.TabIndex = 9;
            this.lblTienPhong.Text = "Nội dung";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDien.Location = new System.Drawing.Point(16, 320);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(220, 32);
            this.lblTienDien.TabIndex = 8;
            this.lblTienDien.Text = "Thành Tiền điện";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNuoc.Location = new System.Drawing.Point(490, 120);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(227, 32);
            this.lblTienNuoc.TabIndex = 7;
            this.lblTienNuoc.Text = "Thành Tiền nước";
            // 
            // lblLePhi
            // 
            this.lblLePhi.AutoSize = true;
            this.lblLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLePhi.Location = new System.Drawing.Point(490, 220);
            this.lblLePhi.Name = "lblLePhi";
            this.lblLePhi.Size = new System.Drawing.Size(225, 32);
            this.lblLePhi.TabIndex = 6;
            this.lblLePhi.Text = "Thành tiền lệ phí";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(490, 320);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(149, 32);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Thành tiền";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(257, 20);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.ReadOnly = true;
            this.txtMaHoaDon.Size = new System.Drawing.Size(200, 38);
            this.txtMaHoaDon.TabIndex = 20;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai.Location = new System.Drawing.Point(257, 70);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(200, 39);
            this.cboTrangThai.TabIndex = 19;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(257, 170);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(200, 38);
            this.txtNoiDung.TabIndex = 17;
            // 
            // txtTienDien
            // 
            this.txtTienDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDien.Location = new System.Drawing.Point(257, 320);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.ReadOnly = true;
            this.txtTienDien.Size = new System.Drawing.Size(200, 38);
            this.txtTienDien.TabIndex = 16;
            // 
            // txtTienNuoc
            // 
            this.txtTienNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienNuoc.Location = new System.Drawing.Point(731, 120);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.ReadOnly = true;
            this.txtTienNuoc.Size = new System.Drawing.Size(200, 38);
            this.txtTienNuoc.TabIndex = 15;
            // 
            // txtLePhi
            // 
            this.txtLePhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLePhi.Location = new System.Drawing.Point(731, 220);
            this.txtLePhi.Name = "txtLePhi";
            this.txtLePhi.ReadOnly = true;
            this.txtLePhi.Size = new System.Drawing.Size(200, 38);
            this.txtLePhi.TabIndex = 14;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(731, 320);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(200, 38);
            this.txtTongTien.TabIndex = 13;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Location = new System.Drawing.Point(590, 394);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(103, 35);
            this.btnLamMoi.TabIndex = 21;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkGreen;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoa.Location = new System.Drawing.Point(460, 394);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(103, 35);
            this.btnXoa.TabIndex = 22;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSua.Location = new System.Drawing.Point(330, 394);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(103, 35);
            this.btnSua.TabIndex = 23;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Location = new System.Drawing.Point(200, 394);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(103, 35);
            this.btnThem.TabIndex = 24;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(490, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tiền dịch vụ";
            // 
            // txtTienDV
            // 
            this.txtTienDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDV.Location = new System.Drawing.Point(731, 170);
            this.txtTienDV.Name = "txtTienDV";
            this.txtTienDV.ReadOnly = true;
            this.txtTienDV.Size = new System.Drawing.Size(200, 38);
            this.txtTienDV.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 32);
            this.label2.TabIndex = 27;
            this.label2.Text = "Chỉ số điện cũ";
            // 
            // txtChiSoDienCu
            // 
            this.txtChiSoDienCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoDienCu.Location = new System.Drawing.Point(257, 220);
            this.txtChiSoDienCu.Name = "txtChiSoDienCu";
            this.txtChiSoDienCu.ReadOnly = true;
            this.txtChiSoDienCu.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoDienCu.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 32);
            this.label3.TabIndex = 29;
            this.label3.Text = "Chỉ số điện mới";
            // 
            // txtChiSoDienMoi
            // 
            this.txtChiSoDienMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoDienMoi.Location = new System.Drawing.Point(257, 270);
            this.txtChiSoDienMoi.Name = "txtChiSoDienMoi";
            this.txtChiSoDienMoi.ReadOnly = true;
            this.txtChiSoDienMoi.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoDienMoi.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(490, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 32);
            this.label4.TabIndex = 31;
            this.label4.Text = "Chỉ số nước mới";
            // 
            // txtChiSoNuocMoi
            // 
            this.txtChiSoNuocMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoNuocMoi.Location = new System.Drawing.Point(731, 70);
            this.txtChiSoNuocMoi.Name = "txtChiSoNuocMoi";
            this.txtChiSoNuocMoi.ReadOnly = true;
            this.txtChiSoNuocMoi.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoNuocMoi.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(490, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 32);
            this.label5.TabIndex = 33;
            this.label5.Text = "Chỉ số nước cũ";
            // 
            // txtChiSoNuocCu
            // 
            this.txtChiSoNuocCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiSoNuocCu.Location = new System.Drawing.Point(731, 20);
            this.txtChiSoNuocCu.Name = "txtChiSoNuocCu";
            this.txtChiSoNuocCu.ReadOnly = true;
            this.txtChiSoNuocCu.Size = new System.Drawing.Size(200, 38);
            this.txtChiSoNuocCu.TabIndex = 34;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.AutoSize = true;
            this.txtTenPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhong.Location = new System.Drawing.Point(490, 270);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(150, 32);
            this.txtTenPhong.TabIndex = 35;
            this.txtTenPhong.Text = "Tên phòng";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(731, 270);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(200, 38);
            this.textBox6.TabIndex = 36;
            // 
            // btnTimHoaDon
            // 
            this.btnTimHoaDon.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTimHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimHoaDon.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimHoaDon.Location = new System.Drawing.Point(590, 457);
            this.btnTimHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimHoaDon.Name = "btnTimHoaDon";
            this.btnTimHoaDon.Size = new System.Drawing.Size(100, 32);
            this.btnTimHoaDon.TabIndex = 39;
            this.btnTimHoaDon.Text = "Tìm";
            this.btnTimHoaDon.UseVisualStyleBackColor = false;
            // 
            // lblTimHoaDon
            // 
            this.lblTimHoaDon.AutoSize = true;
            this.lblTimHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimHoaDon.Location = new System.Drawing.Point(193, 455);
            this.lblTimHoaDon.Name = "lblTimHoaDon";
            this.lblTimHoaDon.Size = new System.Drawing.Size(171, 32);
            this.lblTimHoaDon.TabIndex = 37;
            this.lblTimHoaDon.Text = "Tìm hóa đơn";
            // 
            // txtTimHoaDon
            // 
            this.txtTimHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimHoaDon.Location = new System.Drawing.Point(400, 452);
            this.txtTimHoaDon.Name = "txtTimHoaDon";
            this.txtTimHoaDon.Size = new System.Drawing.Size(151, 38);
            this.txtTimHoaDon.TabIndex = 40;
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(257, 120);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(200, 38);
            this.dtpNgayTao.TabIndex = 41;
            // 
            // frmHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(1031, 835);
            this.Controls.Add(this.dtpNgayTao);
            this.Controls.Add(this.txtTimHoaDon);
            this.Controls.Add(this.btnTimHoaDon);
            this.Controls.Add(this.lblTimHoaDon);
            this.Controls.Add(this.txtTenPhong);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtChiSoNuocCu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChiSoNuocMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChiSoDienMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChiSoDienCu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTienDV);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblLePhi);
            this.Controls.Add(this.lblTienNuoc);
            this.Controls.Add(this.lblTienDien);
            this.Controls.Add(this.lblTienPhong);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblMaHoaDon);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtLePhi);
            this.Controls.Add(this.txtTienNuoc);
            this.Controls.Add(this.txtTienDien);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "frmHoaDon";
            this.Text = "Quản lý hóa đơn phòng trọ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.Label lblTienDien;
        private System.Windows.Forms.Label lblTienNuoc;
        private System.Windows.Forms.Label lblLePhi;
        private System.Windows.Forms.Label lblTongTien;

        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.TextBox txtLePhi;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTienDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChiSoDienCu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChiSoDienMoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChiSoNuocMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChiSoNuocCu;
        private System.Windows.Forms.Label txtTenPhong;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnTimHoaDon;
        private System.Windows.Forms.Label lblTimHoaDon;
        private System.Windows.Forms.TextBox txtTimHoaDon;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
    }
}