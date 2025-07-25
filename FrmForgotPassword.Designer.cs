namespace WinForms_singleselection
{
    partial class FrmForgotPassword
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
            components = new System.ComponentModel.Container();
            txtName = new TextBox();
            txtStudentNo = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSendCode = new Button();
            txtCode = new TextBox();
            label4 = new Label();
            txtNewPwd = new TextBox();
            txtConfirmPwd = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnReset = new Button();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(346, 171);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(242, 43);
            txtName.TabIndex = 0;
            // 
            // txtStudentNo
            // 
            txtStudentNo.Location = new Point(346, 325);
            txtStudentNo.Margin = new Padding(4, 3, 4, 3);
            txtStudentNo.Name = "txtStudentNo";
            txtStudentNo.Size = new Size(242, 43);
            txtStudentNo.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(346, 469);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(242, 43);
            txtEmail.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 171);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 36);
            label1.TabIndex = 3;
            label1.Text = "姓名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 316);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 36);
            label2.TabIndex = 4;
            label2.Text = "学号";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 448);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 36);
            label3.TabIndex = 5;
            label3.Text = "邮箱";
            // 
            // btnSendCode
            // 
            btnSendCode.Location = new Point(168, 563);
            btnSendCode.Margin = new Padding(4, 3, 4, 3);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(420, 52);
            btnSendCode.TabIndex = 6;
            btnSendCode.Text = "发送验证码";
            btnSendCode.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(364, 678);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(224, 43);
            txtCode.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(168, 685);
            label4.Name = "label4";
            label4.Size = new Size(99, 36);
            label4.TabIndex = 8;
            label4.Text = "验证码";
            // 
            // txtNewPwd
            // 
            txtNewPwd.Location = new Point(1313, 194);
            txtNewPwd.Name = "txtNewPwd";
            txtNewPwd.Size = new Size(200, 43);
            txtNewPwd.TabIndex = 9;
            // 
            // txtConfirmPwd
            // 
            txtConfirmPwd.Location = new Point(1313, 426);
            txtConfirmPwd.Name = "txtConfirmPwd";
            txtConfirmPwd.Size = new Size(200, 43);
            txtConfirmPwd.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1115, 194);
            label5.Name = "label5";
            label5.Size = new Size(155, 36);
            label5.TabIndex = 11;
            label5.Text = "输入新密码";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1115, 433);
            label6.Name = "label6";
            label6.Size = new Size(127, 36);
            label6.TabIndex = 12;
            label6.Text = "确认密码";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1275, 663);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(150, 46);
            btnReset.TabIndex = 13;
            btnReset.Text = "重置密码";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            timer.Interval = 1000;
            // 
            // FrmForgotPassword
            // 
            AutoScaleDimensions = new SizeF(17F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1957, 1108);
            Controls.Add(btnReset);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtConfirmPwd);
            Controls.Add(txtNewPwd);
            Controls.Add(label4);
            Controls.Add(txtCode);
            Controls.Add(btnSendCode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtStudentNo);
            Controls.Add(txtName);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmForgotPassword";
            Text = "FrmForgotPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtStudentNo;
        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSendCode;
        private TextBox txtCode;
        private Label label4;
        private TextBox txtNewPwd;
        private TextBox txtConfirmPwd;
        private Label label5;
        private Label label6;
        private Button btnReset;
        private System.Windows.Forms.Timer timer;
    }
}