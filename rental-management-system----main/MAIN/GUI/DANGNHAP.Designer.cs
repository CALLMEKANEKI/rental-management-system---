using System.Drawing;

namespace qlpt.GUI
{
    partial class DANGNHAP
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnSwitchSignIn = new System.Windows.Forms.Button();
            this.btnSwitchSignUp = new System.Windows.Forms.Button();
            this.panelSignIn = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.panelSignUp = new System.Windows.Forms.Panel();
            this.lblNewUser = new System.Windows.Forms.Label();
            this.txtNewUser = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.panelSignIn.SuspendLayout();
            this.panelSignUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSwitchSignIn
            // 
            this.btnSwitchSignIn.BackColor = System.Drawing.Color.LightGray;
            this.btnSwitchSignIn.FlatAppearance.BorderSize = 0;
            this.btnSwitchSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchSignIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSwitchSignIn.ForeColor = System.Drawing.Color.Black;
            this.btnSwitchSignIn.Location = new System.Drawing.Point(130, 30);
            this.btnSwitchSignIn.Name = "btnSwitchSignIn";
            this.btnSwitchSignIn.Size = new System.Drawing.Size(130, 40);
            this.btnSwitchSignIn.TabIndex = 0;
            this.btnSwitchSignIn.Text = "SIGN IN";
            this.btnSwitchSignIn.UseVisualStyleBackColor = false;
            this.btnSwitchSignIn.Click += new System.EventHandler(this.btnSwitchSignIn_Click);
            // 
            // btnSwitchSignUp
            // 
            this.btnSwitchSignUp.BackColor = System.Drawing.Color.LightGray;
            this.btnSwitchSignUp.FlatAppearance.BorderSize = 0;
            this.btnSwitchSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSwitchSignUp.ForeColor = System.Drawing.Color.Black;
            this.btnSwitchSignUp.Location = new System.Drawing.Point(280, 30);
            this.btnSwitchSignUp.Name = "btnSwitchSignUp";
            this.btnSwitchSignUp.Size = new System.Drawing.Size(130, 40);
            this.btnSwitchSignUp.TabIndex = 1;
            this.btnSwitchSignUp.Text = "SIGN UP";
            this.btnSwitchSignUp.UseVisualStyleBackColor = false;
            this.btnSwitchSignUp.Click += new System.EventHandler(this.btnSwitchSignUp_Click);
            // 
            // panelSignIn
            // 
            this.panelSignIn.BackColor = System.Drawing.Color.White;
            this.panelSignIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSignIn.Controls.Add(this.lblUser);
            this.panelSignIn.Controls.Add(this.txtUsername);
            this.panelSignIn.Controls.Add(this.lblPass);
            this.panelSignIn.Controls.Add(this.txtPassword);
            this.panelSignIn.Controls.Add(this.chkRemember);
            this.panelSignIn.Controls.Add(this.btnSignIn);
            this.panelSignIn.Controls.Add(this.lnkForgot);
            this.panelSignIn.Location = new System.Drawing.Point(82, 97);
            this.panelSignIn.Name = "panelSignIn";
            this.panelSignIn.Size = new System.Drawing.Size(400, 350);
            this.panelSignIn.TabIndex = 2;
            this.panelSignIn.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSignIn_Paint);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(30, 40);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(98, 23);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "USERNAME";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 65);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 30);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPass.ForeColor = System.Drawing.Color.Black;
            this.lblPass.Location = new System.Drawing.Point(30, 115);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(99, 23);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "PASSWORD";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(30, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(320, 30);
            this.txtPassword.TabIndex = 3;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRemember.ForeColor = System.Drawing.Color.Gray;
            this.chkRemember.Location = new System.Drawing.Point(30, 180);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(129, 24);
            this.chkRemember.TabIndex = 4;
            this.chkRemember.Text = "Remember me";
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(30, 220);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(320, 37);
            this.btnSignIn.TabIndex = 5;
            this.btnSignIn.Text = "SIGN IN";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkForgot.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkForgot.Location = new System.Drawing.Point(130, 280);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(125, 20);
            this.lnkForgot.TabIndex = 6;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Forgot Password?";
            this.lnkForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgot_LinkClicked);
            // 
            // panelSignUp
            // 
            this.panelSignUp.BackColor = System.Drawing.Color.White;
            this.panelSignUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSignUp.Controls.Add(this.lblNewUser);
            this.panelSignUp.Controls.Add(this.txtNewUser);
            this.panelSignUp.Controls.Add(this.lblNewPass);
            this.panelSignUp.Controls.Add(this.txtNewPass);
            this.panelSignUp.Controls.Add(this.lblConfirm);
            this.panelSignUp.Controls.Add(this.txtConfirm);
            this.panelSignUp.Controls.Add(this.btnSignUp);
            this.panelSignUp.Location = new System.Drawing.Point(82, 97);
            this.panelSignUp.Name = "panelSignUp";
            this.panelSignUp.Size = new System.Drawing.Size(400, 350);
            this.panelSignUp.TabIndex = 3;
            this.panelSignUp.Visible = false;
            // 
            // lblNewUser
            // 
            this.lblNewUser.AutoSize = true;
            this.lblNewUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewUser.ForeColor = System.Drawing.Color.Black;
            this.lblNewUser.Location = new System.Drawing.Point(30, 40);
            this.lblNewUser.Name = "lblNewUser";
            this.lblNewUser.Size = new System.Drawing.Size(98, 23);
            this.lblNewUser.TabIndex = 0;
            this.lblNewUser.Text = "USERNAME";
            // 
            // txtNewUser
            // 
            this.txtNewUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewUser.Location = new System.Drawing.Point(30, 65);
            this.txtNewUser.Name = "txtNewUser";
            this.txtNewUser.Size = new System.Drawing.Size(320, 30);
            this.txtNewUser.TabIndex = 1;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewPass.ForeColor = System.Drawing.Color.Black;
            this.lblNewPass.Location = new System.Drawing.Point(30, 115);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(99, 23);
            this.lblNewPass.TabIndex = 2;
            this.lblNewPass.Text = "PASSWORD";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPass.Location = new System.Drawing.Point(30, 140);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '•';
            this.txtNewPass.Size = new System.Drawing.Size(320, 30);
            this.txtNewPass.TabIndex = 3;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirm.ForeColor = System.Drawing.Color.Black;
            this.lblConfirm.Location = new System.Drawing.Point(30, 190);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(179, 23);
            this.lblConfirm.TabIndex = 4;
            this.lblConfirm.Text = "CONFIRM PASSWORD";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirm.Location = new System.Drawing.Point(30, 215);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '•';
            this.txtConfirm.Size = new System.Drawing.Size(320, 30);
            this.txtConfirm.TabIndex = 5;
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(30, 265);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(320, 37);
            this.btnSignUp.TabIndex = 6;
            this.btnSignUp.Text = "SIGN UP";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // DANGNHAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(594, 520);
            this.Controls.Add(this.btnSwitchSignIn);
            this.Controls.Add(this.btnSwitchSignUp);
            this.Controls.Add(this.panelSignIn);
            this.Controls.Add(this.panelSignUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DANGNHAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.DANGNHAP_Load);
            this.panelSignIn.ResumeLayout(false);
            this.panelSignIn.PerformLayout();
            this.panelSignUp.ResumeLayout(false);
            this.panelSignUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSwitchSignIn;
        private System.Windows.Forms.Button btnSwitchSignUp;
        private System.Windows.Forms.Panel panelSignIn;
        private System.Windows.Forms.Panel panelSignUp;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.LinkLabel lnkForgot;
        private System.Windows.Forms.Label lblNewUser;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtNewUser;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnSignUp;
    }
}
