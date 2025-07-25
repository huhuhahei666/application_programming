namespace WinForms_singleselection
{
    partial class FrmSQL
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
            button1 = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            cboMajor = new ComboBox();
            txtStuName = new TextBox();
            dataGridView1 = new DataGridView();
            lblCount = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnAlert = new Button();
            btnSearch = new Button();
            label1 = new Label();
            label2 = new Label();
            btnLink = new Button();
            chkAll = new CheckBox();
            picStudent = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtStudentNo = new TextBox();
            txtStudentName = new TextBox();
            txtMajor = new TextBox();
            btnSave = new Button();
            txtCurrentPwd = new TextBox();
            txtNewPwd = new TextBox();
            label6 = new Label();
            label7 = new Label();
            btnUpdatePwd = new Button();
            txtConfirmPwd = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(383, 397);
            button1.Name = "button1";
            button1.Size = new Size(182, 53);
            button1.TabIndex = 0;
            button1.Text = "一键打卡";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(35, 887);
            listView1.Name = "listView1";
            listView1.Size = new Size(111, 79);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // listView2
            // 
            listView2.Location = new Point(202, 880);
            listView2.Name = "listView2";
            listView2.Size = new Size(131, 86);
            listView2.TabIndex = 2;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            // 
            // cboMajor
            // 
            cboMajor.FormattingEnabled = true;
            cboMajor.Location = new Point(171, 175);
            cboMajor.Name = "cboMajor";
            cboMajor.Size = new Size(293, 44);
            cboMajor.TabIndex = 3;
            // 
            // txtStuName
            // 
            txtStuName.Location = new Point(171, 61);
            txtStuName.Name = "txtStuName";
            txtStuName.Size = new Size(242, 43);
            txtStuName.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1265, 113);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(707, 693);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellClick;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(1300, 23);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(94, 36);
            lblCount.TabIndex = 6;
            lblCount.Text = "label1";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btnAlert
            // 
            btnAlert.Location = new Point(56, 808);
            btnAlert.Name = "btnAlert";
            btnAlert.Size = new Size(182, 53);
            btnAlert.TabIndex = 7;
            btnAlert.Text = "开始报警";
            btnAlert.UseVisualStyleBackColor = true;
            btnAlert.Click += button1_Click_1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(25, 278);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(182, 53);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "查找";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 183);
            label1.Name = "label1";
            label1.Size = new Size(71, 36);
            label1.TabIndex = 9;
            label1.Text = "专业";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 61);
            label2.Name = "label2";
            label2.Size = new Size(71, 36);
            label2.TabIndex = 10;
            label2.Text = "姓名";
            // 
            // btnLink
            // 
            btnLink.BackColor = SystemColors.ActiveCaption;
            btnLink.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLink.ForeColor = SystemColors.ButtonHighlight;
            btnLink.Location = new Point(12, 397);
            btnLink.Name = "btnLink";
            btnLink.Size = new Size(217, 53);
            btnLink.TabIndex = 11;
            btnLink.Text = "连接数据库";
            btnLink.UseVisualStyleBackColor = false;
            btnLink.Click += btnLink_Click;
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Location = new Point(531, 182);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(103, 40);
            chkAll.TabIndex = 12;
            chkAll.Text = "全部";
            chkAll.UseVisualStyleBackColor = true;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            // 
            // picStudent
            // 
            picStudent.Location = new Point(757, 129);
            picStudent.Name = "picStudent";
            picStudent.Size = new Size(391, 381);
            picStudent.TabIndex = 13;
            picStudent.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(627, 561);
            label3.Name = "label3";
            label3.Size = new Size(71, 36);
            label3.TabIndex = 14;
            label3.Text = "学号";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(627, 666);
            label4.Name = "label4";
            label4.Size = new Size(71, 36);
            label4.TabIndex = 15;
            label4.Text = "姓名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(627, 763);
            label5.Name = "label5";
            label5.Size = new Size(71, 36);
            label5.TabIndex = 16;
            label5.Text = "专业";
            // 
            // txtStudentNo
            // 
            txtStudentNo.Location = new Point(757, 554);
            txtStudentNo.Name = "txtStudentNo";
            txtStudentNo.Size = new Size(242, 43);
            txtStudentNo.TabIndex = 17;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(757, 663);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(242, 43);
            txtStudentName.TabIndex = 18;
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(757, 763);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(242, 43);
            txtMajor.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(658, 863);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 53);
            btnSave.TabIndex = 20;
            btnSave.Text = "更新";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtCurrentPwd
            // 
            txtCurrentPwd.Location = new Point(223, 490);
            txtCurrentPwd.Name = "txtCurrentPwd";
            txtCurrentPwd.Size = new Size(200, 43);
            txtCurrentPwd.TabIndex = 21;
            // 
            // txtNewPwd
            // 
            txtNewPwd.Location = new Point(223, 580);
            txtNewPwd.Name = "txtNewPwd";
            txtNewPwd.Size = new Size(200, 43);
            txtNewPwd.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 474);
            label6.Name = "label6";
            label6.Size = new Size(99, 36);
            label6.TabIndex = 23;
            label6.Text = "原密码";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 571);
            label7.Name = "label7";
            label7.Size = new Size(99, 36);
            label7.TabIndex = 24;
            label7.Text = "新密码";
            // 
            // btnUpdatePwd
            // 
            btnUpdatePwd.BackColor = SystemColors.ActiveCaption;
            btnUpdatePwd.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdatePwd.ForeColor = SystemColors.ControlLightLight;
            btnUpdatePwd.Location = new Point(56, 746);
            btnUpdatePwd.Name = "btnUpdatePwd";
            btnUpdatePwd.Size = new Size(263, 53);
            btnUpdatePwd.TabIndex = 25;
            btnUpdatePwd.Text = "更新密码";
            btnUpdatePwd.UseVisualStyleBackColor = false;
            btnUpdatePwd.Click += btnUpdatePwd_Click;
            // 
            // txtConfirmPwd
            // 
            txtConfirmPwd.Location = new Point(223, 688);
            txtConfirmPwd.Name = "txtConfirmPwd";
            txtConfirmPwd.Size = new Size(200, 43);
            txtConfirmPwd.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 688);
            label8.Name = "label8";
            label8.Size = new Size(155, 36);
            label8.TabIndex = 27;
            label8.Text = "重复新密码";
            // 
            // FrmSQL
            // 
            AutoScaleDimensions = new SizeF(17F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2451, 1071);
            Controls.Add(label8);
            Controls.Add(txtConfirmPwd);
            Controls.Add(btnUpdatePwd);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtNewPwd);
            Controls.Add(txtCurrentPwd);
            Controls.Add(btnSave);
            Controls.Add(txtMajor);
            Controls.Add(txtStudentName);
            Controls.Add(txtStudentNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(picStudent);
            Controls.Add(chkAll);
            Controls.Add(btnLink);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(btnAlert);
            Controls.Add(lblCount);
            Controls.Add(dataGridView1);
            Controls.Add(txtStuName);
            Controls.Add(cboMajor);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button1);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FrmSQL";
            Text = "Form5";
            Load += frmSQL_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListView listView1;
        private ListView listView2;
        private ComboBox cboMajor;
        private TextBox txtStuName;
        private DataGridView dataGridView1;
        private Label lblCount;
        private System.Windows.Forms.Timer timer1;
        private Button btnAlert;
        private Button btnSearch;
        private Label label1;
        private Label label2;
        private Button btnLink;
        private CheckBox chkAll;
        private PictureBox picStudent;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtStudentNo;
        private TextBox txtStudentName;
        private TextBox txtMajor;
        private Button btnSave;
        private TextBox txtCurrentPwd;
        private TextBox txtNewPwd;
        private Label label6;
        private Label label7;
        private Button btnUpdatePwd;
        private TextBox txtConfirmPwd;
        private Label label8;
    }
}