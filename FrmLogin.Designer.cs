namespace WinForms_singleselection
{
    partial class FrmLogin
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
            txtUserNo = new TextBox();
            txtPwd = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            LnkForgot = new LinkLabel();
            chkRememberMe = new CheckBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtUserNo
            // 
            txtUserNo.Location = new Point(1061, 189);
            txtUserNo.Name = "txtUserNo";
            txtUserNo.Size = new Size(286, 38);
            txtUserNo.TabIndex = 0;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(1061, 243);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(286, 38);
            txtPwd.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.HighlightText;
            btnLogin.Location = new Point(996, 372);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(475, 58);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "立即登录";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Microsoft YaHei UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(973, 189);
            label1.Name = "label1";
            label1.Size = new Size(62, 31);
            label1.TabIndex = 3;
            label1.Text = "学号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Font = new Font("Microsoft YaHei UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(973, 250);
            label2.Name = "label2";
            label2.Size = new Size(62, 31);
            label2.TabIndex = 4;
            label2.Text = "密码";
            // 
            // LnkForgot
            // 
            LnkForgot.AutoSize = true;
            LnkForgot.Location = new Point(1361, 423);
            LnkForgot.Name = "LnkForgot";
            LnkForgot.Size = new Size(110, 31);
            LnkForgot.TabIndex = 5;
            LnkForgot.TabStop = true;
            LnkForgot.Text = "忘记密码";
            LnkForgot.LinkClicked += LnkForgot_LinkClicked;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(982, 436);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(190, 35);
            chkRememberMe.TabIndex = 6;
            chkRememberMe.Text = "下次自动登录";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 18F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 122, 204);
            label3.Location = new Point(514, 9);
            label3.Name = "label3";
            label3.Size = new Size(267, 64);
            label3.TabIndex = 7;
            label3.Text = "数据库登录";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 808);
            Controls.Add(label2);
            Controls.Add(txtPwd);
            Controls.Add(label1);
            Controls.Add(txtUserNo);
            Controls.Add(label3);
            Controls.Add(chkRememberMe);
            Controls.Add(LnkForgot);
            Controls.Add(btnLogin);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserNo;
        private TextBox txtPwd;
        private Button btnLogin;
        private Label label1;
        private Label label2;
        private LinkLabel LnkForgot;
        private CheckBox chkRememberMe;
        private Label label3;
    }
}