namespace WinForms_singleselection
{
    partial class FormRegister
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
            txtStuName = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtConfirmPassword = new TextBox();
            txtStuNumber = new TextBox();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtStuName
            // 
            txtStuName.BackColor = Color.FromArgb(45, 45, 49);
            txtStuName.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStuName.ForeColor = Color.FromArgb(0, 193, 255);
            txtStuName.Location = new Point(749, 188);
            txtStuName.Name = "txtStuName";
            txtStuName.Size = new Size(334, 58);
            txtStuName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(45, 45, 49);
            txtPassword.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(0, 193, 255);
            txtPassword.Location = new Point(749, 397);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(334, 60);
            txtPassword.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 193, 255);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(427, 653);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(637, 73);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "注       册";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 193, 255);
            label1.Location = new Point(390, 187);
            label1.Name = "label1";
            label1.Size = new Size(189, 57);
            label1.TabIndex = 3;
            label1.Text = "姓      名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 193, 255);
            label2.Location = new Point(390, 400);
            label2.Name = "label2";
            label2.Size = new Size(189, 57);
            label2.TabIndex = 4;
            label2.Text = "密      码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 193, 255);
            label3.Location = new Point(390, 496);
            label3.Name = "label3";
            label3.Size = new Size(197, 57);
            label3.TabIndex = 5;
            label3.Text = "重复密码";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(45, 45, 49);
            txtConfirmPassword.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.ForeColor = Color.FromArgb(0, 193, 255);
            txtConfirmPassword.Location = new Point(749, 493);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '•';
            txtConfirmPassword.Size = new Size(334, 60);
            txtConfirmPassword.TabIndex = 6;
            // 
            // txtStuNumber
            // 
            txtStuNumber.BackColor = Color.FromArgb(45, 45, 49);
            txtStuNumber.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStuNumber.ForeColor = Color.FromArgb(0, 193, 255);
            txtStuNumber.Location = new Point(749, 293);
            txtStuNumber.Name = "txtStuNumber";
            txtStuNumber.Size = new Size(334, 60);
            txtStuNumber.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 193, 255);
            label4.Location = new Point(390, 296);
            label4.Name = "label4";
            label4.Size = new Size(189, 57);
            label4.TabIndex = 8;
            label4.Text = "学      号";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(10, 19, 26);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 193, 255);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 19, 26);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 19, 26);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.关闭;
            button1.Location = new Point(1555, 20);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(78, 67);
            button1.TabIndex = 9;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 193, 255);
            label5.Location = new Point(36, 30);
            label5.Name = "label5";
            label5.Size = new Size(283, 57);
            label5.TabIndex = 10;
            label5.Text = "欢迎新用户！";
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 26);
            ClientSize = new Size(1656, 867);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtStuNumber);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtStuName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStuName;
        private TextBox txtPassword;
        private Button btnRegister;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtConfirmPassword;
        private TextBox txtStuNumber;
        private Label label4;
        private Button button1;
        private Label label5;
    }
}