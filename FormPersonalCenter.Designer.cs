namespace WinForms_singleselection
{
    partial class FormPersonalCenter
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
            tabControl = new TabControl();
            tabMyProblems = new TabPage();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            dataGridViewAIProblems2 = new DataGridView();
            tabHistory = new TabPage();
            tabAnalytics = new TabPage();
            splitContainer2 = new SplitContainer();
            tabRanking = new TabPage();
            splitContainer3 = new SplitContainer();
            dataGridView2 = new DataGridView();
            dataGridViewAIProblems = new DataGridView();
            button1 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridView3 = new DataGridView();
            tabControl.SuspendLayout();
            tabMyProblems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAIProblems2).BeginInit();
            tabAnalytics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.SuspendLayout();
            tabRanking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAIProblems).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabMyProblems);
            tabControl.Controls.Add(tabHistory);
            tabControl.Controls.Add(tabAnalytics);
            tabControl.Controls.Add(tabRanking);
            tabControl.Location = new Point(28, 43);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1901, 983);
            tabControl.TabIndex = 0;
            // 
            // tabMyProblems
            // 
            tabMyProblems.Controls.Add(splitContainer1);
            tabMyProblems.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabMyProblems.Location = new Point(8, 45);
            tabMyProblems.Name = "tabMyProblems";
            tabMyProblems.Padding = new Padding(3);
            tabMyProblems.Size = new Size(1885, 930);
            tabMyProblems.TabIndex = 0;
            tabMyProblems.Text = "我的题库";
            tabMyProblems.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer1.Panel2.Controls.Add(dataGridViewAIProblems2);
            splitContainer1.Size = new Size(1879, 924);
            splitContainer1.SplitterDistance = 917;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(859, 817);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridViewAIProblems2
            // 
            dataGridViewAIProblems2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAIProblems2.Location = new Point(65, 57);
            dataGridViewAIProblems2.Name = "dataGridViewAIProblems2";
            dataGridViewAIProblems2.RowHeadersWidth = 82;
            dataGridViewAIProblems2.Size = new Size(817, 817);
            dataGridViewAIProblems2.TabIndex = 0;
            // 
            // tabHistory
            // 
            tabHistory.BackColor = Color.FromArgb(45, 45, 49);
            tabHistory.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabHistory.Location = new Point(8, 45);
            tabHistory.Name = "tabHistory";
            tabHistory.Padding = new Padding(3);
            tabHistory.Size = new Size(1885, 930);
            tabHistory.TabIndex = 1;
            tabHistory.Text = "刷题历史";
            // 
            // tabAnalytics
            // 
            tabAnalytics.Controls.Add(splitContainer2);
            tabAnalytics.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabAnalytics.Location = new Point(8, 45);
            tabAnalytics.Name = "tabAnalytics";
            tabAnalytics.Padding = new Padding(3);
            tabAnalytics.Size = new Size(1885, 930);
            tabAnalytics.TabIndex = 2;
            tabAnalytics.Text = "学习分析";
            tabAnalytics.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = Color.FromArgb(45, 45, 49);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer2.Size = new Size(1879, 924);
            splitContainer2.SplitterDistance = 870;
            splitContainer2.TabIndex = 0;
            // 
            // tabRanking
            // 
            tabRanking.Controls.Add(splitContainer3);
            tabRanking.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabRanking.ForeColor = SystemColors.ActiveCaptionText;
            tabRanking.Location = new Point(8, 45);
            tabRanking.Name = "tabRanking";
            tabRanking.Padding = new Padding(3);
            tabRanking.Size = new Size(1885, 930);
            tabRanking.TabIndex = 3;
            tabRanking.Text = "排行榜";
            tabRanking.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 3);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer3.Panel1.Controls.Add(dataGridView2);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer3.Size = new Size(1879, 924);
            splitContainer3.SplitterDistance = 815;
            splitContainer3.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(43, 88);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(655, 766);
            dataGridView2.TabIndex = 0;
            // 
            // dataGridViewAIProblems
            // 
            dataGridViewAIProblems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAIProblems.Location = new Point(118, 106);
            dataGridViewAIProblems.Name = "dataGridViewAIProblems";
            dataGridViewAIProblems.RowHeadersWidth = 82;
            dataGridViewAIProblems.Size = new Size(930, 817);
            dataGridViewAIProblems.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.关闭2;
            button1.Location = new Point(1960, 53);
            button1.Name = "button1";
            button1.Size = new Size(100, 80);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumAquamarine;
            panel1.Controls.Add(dataGridViewAIProblems);
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2076, 37);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MediumAquamarine;
            panel2.Controls.Add(dataGridView3);
            panel2.Location = new Point(-3, 1053);
            panel2.Name = "panel2";
            panel2.Size = new Size(2076, 37);
            panel2.TabIndex = 3;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(118, 106);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 82;
            dataGridView3.Size = new Size(930, 817);
            dataGridView3.TabIndex = 0;
            // 
            // FormPersonalCenter
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 26);
            ClientSize = new Size(2072, 1087);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPersonalCenter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPersonalCenter";
            tabControl.ResumeLayout(false);
            tabMyProblems.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAIProblems2).EndInit();
            tabAnalytics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabRanking.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAIProblems).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabMyProblems;
        private TabPage tabHistory;
        private TabPage tabAnalytics;
        private TabPage tabRanking;
        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private DataGridView dataGridView2;
        private DataGridView dataGridViewAIProblems;
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView3;
        private DataGridView dataGridViewAIProblems2;
    }
}