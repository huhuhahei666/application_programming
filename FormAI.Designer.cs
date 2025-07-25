namespace WinForms_singleselection
{
    partial class FormAI
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
            txtQuestion = new TextBox();
            button1 = new Button();
            txtAnswer = new RichTextBox();
            label1 = new Label();
            lblStatus = new Label();
            btnClearHistory = new Button();
            progressBar = new ProgressBar();
            btnRecommend = new Button();
            btnAddToLibrary = new Button();
            btnGenerateByTag = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtQuestion
            // 
            txtQuestion.BackColor = Color.FromArgb(45, 45, 49);
            txtQuestion.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtQuestion.ForeColor = Color.FromArgb(0, 193, 255);
            txtQuestion.Location = new Point(456, 220);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(1297, 56);
            txtQuestion.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 193, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(995, 340);
            button1.Name = "button1";
            button1.Size = new Size(230, 78);
            button1.TabIndex = 1;
            button1.Text = "发  送";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.FromArgb(45, 45, 49);
            txtAnswer.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAnswer.ForeColor = Color.FromArgb(0, 193, 255);
            txtAnswer.Location = new Point(456, 472);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(1297, 393);
            txtAnswer.TabIndex = 2;
            txtAnswer.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 193, 255);
            label1.Location = new Point(236, 220);
            label1.Name = "label1";
            label1.Size = new Size(170, 50);
            label1.TabIndex = 3;
            label1.Text = "输入问题";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(0, 193, 255);
            lblStatus.Location = new Point(1228, 39);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(135, 50);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "label2";
            // 
            // btnClearHistory
            // 
            btnClearHistory.BackColor = Color.FromArgb(0, 193, 255);
            btnClearHistory.FlatStyle = FlatStyle.Flat;
            btnClearHistory.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearHistory.Location = new Point(1453, 340);
            btnClearHistory.Name = "btnClearHistory";
            btnClearHistory.Size = new Size(291, 78);
            btnClearHistory.TabIndex = 5;
            btnClearHistory.Text = "清除历史记录";
            btnClearHistory.UseVisualStyleBackColor = false;
            btnClearHistory.Click += btnClearHistory_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(1228, 110);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(494, 46);
            progressBar.TabIndex = 6;
            // 
            // btnRecommend
            // 
            btnRecommend.BackColor = Color.FromArgb(0, 193, 255);
            btnRecommend.FlatStyle = FlatStyle.Flat;
            btnRecommend.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecommend.ForeColor = SystemColors.ControlText;
            btnRecommend.Location = new Point(34, 68);
            btnRecommend.Name = "btnRecommend";
            btnRecommend.Size = new Size(414, 77);
            btnRecommend.TabIndex = 7;
            btnRecommend.Text = "一键推荐题目";
            btnRecommend.UseVisualStyleBackColor = false;
            btnRecommend.Click += btnRecommend_Click;
            // 
            // btnAddToLibrary
            // 
            btnAddToLibrary.BackColor = Color.FromArgb(0, 193, 255);
            btnAddToLibrary.FlatStyle = FlatStyle.Flat;
            btnAddToLibrary.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToLibrary.Location = new Point(890, 894);
            btnAddToLibrary.Name = "btnAddToLibrary";
            btnAddToLibrary.Size = new Size(452, 69);
            btnAddToLibrary.TabIndex = 8;
            btnAddToLibrary.Text = "加入我的题库";
            btnAddToLibrary.UseVisualStyleBackColor = false;
            btnAddToLibrary.Click += btnAddToLibrary_Click;
            // 
            // btnGenerateByTag
            // 
            btnGenerateByTag.BackColor = Color.FromArgb(0, 193, 255);
            btnGenerateByTag.FlatStyle = FlatStyle.Flat;
            btnGenerateByTag.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateByTag.ForeColor = SystemColors.ControlText;
            btnGenerateByTag.Location = new Point(605, 68);
            btnGenerateByTag.Name = "btnGenerateByTag";
            btnGenerateByTag.Size = new Size(414, 77);
            btnGenerateByTag.TabIndex = 9;
            btnGenerateByTag.Text = "标签选择生成题目";
            btnGenerateByTag.UseVisualStyleBackColor = false;
            btnGenerateByTag.Click += btnGenerateByTag_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 193, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1763, 39);
            button2.Name = "button2";
            button2.Size = new Size(269, 77);
            button2.TabIndex = 10;
            button2.Text = "回到主界面";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.帮助;
            pictureBox1.Location = new Point(22, 170);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 188);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumTurquoise;
            panel1.Location = new Point(-1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(2056, 32);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MediumTurquoise;
            panel2.Location = new Point(-12, 1012);
            panel2.Name = "panel2";
            panel2.Size = new Size(2078, 32);
            panel2.TabIndex = 13;
            panel2.Paint += panel2_Paint;
            // 
            // FormAI
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 26);
            ClientSize = new Size(2044, 1036);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(btnGenerateByTag);
            Controls.Add(btnAddToLibrary);
            Controls.Add(btnRecommend);
            Controls.Add(progressBar);
            Controls.Add(btnClearHistory);
            Controls.Add(lblStatus);
            Controls.Add(label1);
            Controls.Add(txtAnswer);
            Controls.Add(button1);
            Controls.Add(txtQuestion);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAI";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuestion;
        private Button button1;
        private RichTextBox txtAnswer;
        private Label label1;
        private Label lblStatus;
        private Button btnClearHistory;
        private ProgressBar progressBar;
        private Button btnRecommend;
        private Button btnAddToLibrary;
        private Button btnGenerateByTag;
        private Button button2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
    }
}