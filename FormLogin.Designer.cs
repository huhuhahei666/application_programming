namespace WinForms_singleselection
{
    partial class FormLogin
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(45, 45, 49);
            txtUsername.Font = new Font("黑体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtUsername.ForeColor = Color.FromArgb(0, 193, 255);
            txtUsername.Location = new Point(517, 319);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(596, 53);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(45, 45, 49);
            txtPassword.Font = new Font("黑体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPassword.ForeColor = Color.FromArgb(0, 193, 255);
            txtPassword.Location = new Point(517, 524);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(596, 53);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.FromArgb(0, 193, 255);
            label1.Location = new Point(517, 225);
            label1.Name = "label1";
            label1.Size = new Size(136, 57);
            label1.TabIndex = 2;
            label1.Text = "学 号:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.ForeColor = Color.FromArgb(0, 193, 255);
            label2.Location = new Point(517, 419);
            label2.Name = "label2";
            label2.Size = new Size(136, 57);
            label2.TabIndex = 3;
            label2.Text = "密 码:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 193, 255);
            btnLogin.FlatAppearance.BorderColor = Color.White;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnLogin.Location = new Point(530, 654);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(572, 68);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "登        录";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 193, 255);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnRegister.Location = new Point(530, 752);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(577, 70);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "立 即 注 册";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(10, 19, 26);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 193, 255);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 19, 26);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 19, 26);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.关闭;
            button1.Location = new Point(1566, 20);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(78, 67);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.ForeColor = Color.FromArgb(0, 193, 255);
            label3.Location = new Point(12, 30);
            label3.Name = "label3";
            label3.Size = new Size(572, 57);
            label3.TabIndex = 7;
            label3.Text = "欢迎来到LeetCode刷题助手";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(14F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 26);
            ClientSize = new Size(1656, 867);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Font = new Font("黑体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private Button btnRegister;
        private Button button1;
        private Label label3;
    }
}