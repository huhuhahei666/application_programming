namespace WinForms_singleselection
{
    partial class FormSpiderLeetCode2
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
            splitContainer1 = new SplitContainer();
            panelTop = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnSearch = new Button();
            btnFetch = new Button();
            cmbDifficulty = new ComboBox();
            txtSearch = new TextBox();
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            dataGridView1 = new DataGridView();
            btnAddToBank = new Button();
            btnExport = new Button();
            lblDetailTitle = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            pieChartPanel = new Panel();
            label1 = new Label();
            tabPage2 = new TabPage();
            barChartPanel = new Panel();
            label2 = new Label();
            BtnPersonalCenter = new Button();
            notePanel = new Panel();
            btnSaveNote = new Button();
            txtNote = new RichTextBox();
            btnAI = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            notePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(39, 94);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer1.Panel1.Controls.Add(panelTop);
            splitContainer1.Panel1.Controls.Add(progressBar1);
            splitContainer1.Panel1.Controls.Add(lblStatus);
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(45, 45, 49);
            splitContainer1.Panel2.Controls.Add(btnAddToBank);
            splitContainer1.Panel2.Controls.Add(btnExport);
            splitContainer1.Panel2.Controls.Add(lblDetailTitle);
            splitContainer1.Size = new Size(1718, 1276);
            splitContainer1.SplitterDistance = 814;
            splitContainer1.TabIndex = 9;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(10, 19, 26);
            panelTop.Controls.Add(label8);
            panelTop.Controls.Add(label7);
            panelTop.Controls.Add(label6);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(btnFetch);
            panelTop.Controls.Add(cmbDifficulty);
            panelTop.Controls.Add(txtSearch);
            panelTop.Location = new Point(25, 31);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(742, 326);
            panelTop.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("微软雅黑 Light", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(0, 193, 255);
            label8.Location = new Point(513, 94);
            label8.Name = "label8";
            label8.Size = new Size(168, 48);
            label8.TabIndex = 15;
            label8.Text = "选择难度";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("微软雅黑 Light", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(0, 193, 255);
            label7.Location = new Point(162, 94);
            label7.Name = "label7";
            label7.Size = new Size(205, 48);
            label7.TabIndex = 14;
            label7.Text = "输入关键词";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 193, 255);
            label6.Location = new Point(16, 146);
            label6.Name = "label6";
            label6.Size = new Size(96, 50);
            label6.TabIndex = 13;
            label6.Text = "筛选";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 193, 255);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(333, 240);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(182, 60);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnFetch
            // 
            btnFetch.BackColor = Color.FromArgb(0, 193, 255);
            btnFetch.FlatStyle = FlatStyle.Flat;
            btnFetch.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFetch.ForeColor = SystemColors.ControlText;
            btnFetch.Location = new Point(34, 30);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(662, 59);
            btnFetch.TabIndex = 1;
            btnFetch.Text = "一 键 获 取 题 目";
            btnFetch.UseVisualStyleBackColor = false;
            btnFetch.Click += btnFetch_Click;
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.BackColor = Color.FromArgb(45, 45, 49);
            cmbDifficulty.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbDifficulty.ForeColor = Color.FromArgb(0, 193, 255);
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Location = new Point(467, 157);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(242, 58);
            cmbDifficulty.TabIndex = 11;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(45, 45, 49);
            txtSearch.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.FromArgb(0, 193, 255);
            txtSearch.Location = new Point(167, 158);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(239, 56);
            txtSearch.TabIndex = 10;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(41, 1180);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(280, 34);
            progressBar1.TabIndex = 6;
            progressBar1.Click += progressBar1_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(0, 193, 255);
            lblStatus.Location = new Point(41, 1090);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(96, 50);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "状态";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 363);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(644, 682);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddToBank
            // 
            btnAddToBank.BackColor = Color.FromArgb(45, 45, 49);
            btnAddToBank.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToBank.ForeColor = Color.FromArgb(0, 193, 255);
            btnAddToBank.Location = new Point(544, 1186);
            btnAddToBank.Name = "btnAddToBank";
            btnAddToBank.Size = new Size(313, 84);
            btnAddToBank.TabIndex = 2;
            btnAddToBank.Text = "加入我的题库";
            btnAddToBank.UseVisualStyleBackColor = false;
            btnAddToBank.Click += btnAddToBank_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(45, 45, 49);
            btnExport.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.FromArgb(0, 193, 255);
            btnExport.Location = new Point(3, 1186);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(293, 87);
            btnExport.TabIndex = 1;
            btnExport.Text = "导出为excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetailTitle.ForeColor = Color.FromArgb(0, 193, 255);
            lblDetailTitle.Location = new Point(19, 19);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(96, 50);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "题目";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1893, 716);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(786, 884);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(45, 45, 49);
            tabPage1.Controls.Add(pieChartPanel);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(8, 45);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(770, 831);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "饼状图";
            // 
            // pieChartPanel
            // 
            pieChartPanel.Location = new Point(6, 165);
            pieChartPanel.Name = "pieChartPanel";
            pieChartPanel.Size = new Size(758, 638);
            pieChartPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 193, 255);
            label1.Location = new Point(300, 59);
            label1.Name = "label1";
            label1.Size = new Size(154, 57);
            label1.TabIndex = 4;
            label1.Text = "饼状图";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(45, 45, 49);
            tabPage2.Controls.Add(barChartPanel);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(8, 45);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(770, 831);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "条形图";
            // 
            // barChartPanel
            // 
            barChartPanel.Location = new Point(6, 159);
            barChartPanel.Name = "barChartPanel";
            barChartPanel.Size = new Size(758, 644);
            barChartPanel.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 193, 255);
            label2.Location = new Point(300, 59);
            label2.Name = "label2";
            label2.Size = new Size(154, 57);
            label2.TabIndex = 5;
            label2.Text = "条形图";
            // 
            // BtnPersonalCenter
            // 
            BtnPersonalCenter.BackColor = Color.FromArgb(0, 193, 255);
            BtnPersonalCenter.FlatStyle = FlatStyle.Flat;
            BtnPersonalCenter.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnPersonalCenter.ForeColor = SystemColors.ControlText;
            BtnPersonalCenter.Location = new Point(2377, 155);
            BtnPersonalCenter.Name = "BtnPersonalCenter";
            BtnPersonalCenter.Size = new Size(218, 97);
            BtnPersonalCenter.TabIndex = 13;
            BtnPersonalCenter.Text = "个人中心";
            BtnPersonalCenter.UseVisualStyleBackColor = false;
            BtnPersonalCenter.Click += BtnPersonalCenter_Click;
            // 
            // notePanel
            // 
            notePanel.BackColor = Color.FromArgb(45, 45, 49);
            notePanel.Controls.Add(btnSaveNote);
            notePanel.Controls.Add(txtNote);
            notePanel.Location = new Point(920, 1387);
            notePanel.Name = "notePanel";
            notePanel.Size = new Size(758, 350);
            notePanel.TabIndex = 14;
            // 
            // btnSaveNote
            // 
            btnSaveNote.BackColor = Color.FromArgb(0, 193, 255);
            btnSaveNote.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveNote.Location = new Point(222, 261);
            btnSaveNote.Name = "btnSaveNote";
            btnSaveNote.Size = new Size(295, 65);
            btnSaveNote.TabIndex = 1;
            btnSaveNote.Text = "保存笔记";
            btnSaveNote.UseVisualStyleBackColor = false;
            // 
            // txtNote
            // 
            txtNote.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNote.Location = new Point(42, 22);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(648, 218);
            txtNote.TabIndex = 0;
            txtNote.Text = "";
            // 
            // btnAI
            // 
            btnAI.BackColor = Color.FromArgb(0, 193, 255);
            btnAI.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAI.Location = new Point(2377, 396);
            btnAI.Name = "btnAI";
            btnAI.Size = new Size(218, 85);
            btnAI.TabIndex = 15;
            btnAI.Text = "AI推荐";
            btnAI.UseVisualStyleBackColor = false;
            btnAI.Click += btnAI_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.用户;
            pictureBox1.Location = new Point(2136, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 202);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.知识库;
            pictureBox2.Location = new Point(2136, 332);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 198);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 193, 255);
            label3.Location = new Point(2105, 585);
            label3.Name = "label3";
            label3.Size = new Size(530, 41);
            label3.TabIndex = 18;
            label3.Text = "找不到适合自己的题目？让AI来帮忙";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 193, 255);
            label4.Location = new Point(406, 1404);
            label4.Name = "label4";
            label4.Size = new Size(466, 41);
            label4.TabIndex = 19;
            label4.Text = "记个笔记吧，解题印象更深刻！";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 193, 255);
            label5.Location = new Point(39, 12);
            label5.Name = "label5";
            label5.Size = new Size(157, 57);
            label5.TabIndex = 20;
            label5.Text = "label5";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(10, 19, 26);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.关闭1;
            button1.Location = new Point(2630, 8);
            button1.Name = "button1";
            button1.Size = new Size(85, 80);
            button1.TabIndex = 21;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormSpiderLeetCode2
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 26);
            ClientSize = new Size(2740, 1767);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(notePanel);
            Controls.Add(btnAI);
            Controls.Add(BtnPersonalCenter);
            Controls.Add(tabControl1);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSpiderLeetCode2";
            Text = "FormSpiderLeetCode2";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            notePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panelTop;
        private Button btnSearch;
        private Button btnFetch;
        private ComboBox cmbDifficulty;
        private TextBox txtSearch;
        private ProgressBar progressBar1;
        private Label lblStatus;
        private DataGridView dataGridView1;
        private Label lblDetailTitle;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel pieChartPanel;
        private Label label1;
        private TabPage tabPage2;
        private Panel barChartPanel;
        private Label label2;
        private Button btnExport;
        private Button btnHistory;
        private Button BtnPersonalCenter;
        private Panel notePanel;
        private Button btnSaveNote;
        private RichTextBox txtNote;
        private Button btnAI;
        private Button btnAddToBank;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button button1;
    }
}