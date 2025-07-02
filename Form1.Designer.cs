namespace WinForms_singleselection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            groupBox1 = new GroupBox();
            rad1_2 = new RadioButton();
            lblQuestion = new Label();
            rad1_3 = new RadioButton();
            rad1_4 = new RadioButton();
            rad1_1 = new RadioButton();
            btnSubmit = new Button();
            btnNext = new Button();
            lblFeedback = new Label();
            lblProgress = new Label();
            lblScore = new Label();
            lbltime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 29);
            label1.Name = "label1";
            label1.Size = new Size(144, 52);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rad1_2);
            groupBox1.Controls.Add(lblQuestion);
            groupBox1.Controls.Add(rad1_3);
            groupBox1.Controls.Add(rad1_4);
            groupBox1.Controls.Add(rad1_1);
            groupBox1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(24, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(998, 501);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // rad1_2
            // 
            rad1_2.AutoSize = true;
            rad1_2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rad1_2.Location = new Point(6, 216);
            rad1_2.Name = "rad1_2";
            rad1_2.Size = new Size(263, 46);
            rad1_2.TabIndex = 6;
            rad1_2.TabStop = true;
            rad1_2.Text = "radioButton1";
            rad1_2.UseVisualStyleBackColor = true;
            rad1_2.CheckedChanged += rad1_2_CheckedChanged;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(6, 48);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(82, 42);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "题目";
            // 
            // rad1_3
            // 
            rad1_3.AutoSize = true;
            rad1_3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rad1_3.Location = new Point(6, 306);
            rad1_3.Name = "rad1_3";
            rad1_3.Size = new Size(263, 46);
            rad1_3.TabIndex = 5;
            rad1_3.TabStop = true;
            rad1_3.Text = "radioButton1";
            rad1_3.UseVisualStyleBackColor = true;
            rad1_3.CheckedChanged += rad1_3_CheckedChanged;
            // 
            // rad1_4
            // 
            rad1_4.AutoSize = true;
            rad1_4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rad1_4.Location = new Point(6, 392);
            rad1_4.Name = "rad1_4";
            rad1_4.Size = new Size(263, 46);
            rad1_4.TabIndex = 4;
            rad1_4.TabStop = true;
            rad1_4.Text = "radioButton1";
            rad1_4.UseVisualStyleBackColor = true;
            rad1_4.CheckedChanged += rad1_4_CheckedChanged;
            // 
            // rad1_1
            // 
            rad1_1.AutoSize = true;
            rad1_1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rad1_1.Location = new Point(6, 126);
            rad1_1.Name = "rad1_1";
            rad1_1.Size = new Size(263, 46);
            rad1_1.TabIndex = 2;
            rad1_1.TabStop = true;
            rad1_1.Text = "radioButton1";
            rad1_1.UseVisualStyleBackColor = true;
            rad1_1.CheckedChanged += rad1_CheckedChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = SystemColors.ActiveCaption;
            btnSubmit.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = SystemColors.ButtonHighlight;
            btnSubmit.Location = new Point(49, 654);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(119, 68);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = SystemColors.ActiveCaption;
            btnNext.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = SystemColors.ControlLightLight;
            btnNext.Location = new Point(588, 654);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(118, 68);
            btnNext.TabIndex = 3;
            btnNext.Text = "下一题";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeedback.Location = new Point(1056, 119);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(103, 40);
            lblFeedback.TabIndex = 4;
            lblFeedback.Text = "label2";
            lblFeedback.Click += lblFeedback_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgress.Location = new Point(1056, 257);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(103, 40);
            lblProgress.TabIndex = 7;
            lblProgress.Text = "label2";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(1056, 369);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(73, 40);
            lblScore.TabIndex = 8;
            lblScore.Text = "得分";
            // 
            // lbltime
            // 
            lbltime.AutoSize = true;
            lbltime.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltime.Location = new Point(1056, 564);
            lbltime.Name = "lbltime";
            lbltime.Size = new Size(101, 37);
            lbltime.TabIndex = 9;
            lbltime.Text = "倒计时";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1056, 615);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 46);
            progressBar1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1992, 921);
            Controls.Add(progressBar1);
            Controls.Add(lbltime);
            Controls.Add(lblScore);
            Controls.Add(lblProgress);
            Controls.Add(lblFeedback);
            Controls.Add(btnNext);
            Controls.Add(btnSubmit);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rad1_1;
        private Label lblQuestion;
        private RadioButton rad1_3;
        private RadioButton rad1_4;
        private RadioButton rad1_2;
        private Button btnSubmit;
        private Button btnNext;
        private Label lblFeedback;
        private Label lblProgress;
        private Label lblScore;
        private Label lbltime;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
    }
}
