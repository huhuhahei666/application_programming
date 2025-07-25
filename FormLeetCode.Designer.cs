namespace WinForms_singleselection
{
    partial class FormLeetCode
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
            dataGridView1 = new DataGridView();
            btnFetch = new Button();
            pieChartPanel = new Panel();
            barChartPanel = new Panel();
            label1 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            splitContainer1 = new SplitContainer();
            panelTop = new Panel();
            btnSearch = new Button();
            cmbDifficulty = new ComboBox();
            txtSearch = new TextBox();
            lblDetailTitle = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelTop.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 363);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(548, 521);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += DataGridView1_CellClick;
            // 
            // btnFetch
            // 
            btnFetch.BackColor = SystemColors.ActiveCaption;
            btnFetch.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFetch.ForeColor = SystemColors.ButtonHighlight;
            btnFetch.Location = new Point(16, 24);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(134, 59);
            btnFetch.TabIndex = 1;
            btnFetch.Text = "获取";
            btnFetch.UseVisualStyleBackColor = false;
            btnFetch.Click += btnFetch_Click;
            // 
            // pieChartPanel
            // 
            pieChartPanel.Location = new Point(6, 165);
            pieChartPanel.Name = "pieChartPanel";
            pieChartPanel.Size = new Size(709, 638);
            pieChartPanel.TabIndex = 2;
            // 
            // barChartPanel
            // 
            barChartPanel.Location = new Point(6, 159);
            barChartPanel.Name = "barChartPanel";
            barChartPanel.Size = new Size(709, 644);
            barChartPanel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(213, 53);
            label1.Name = "label1";
            label1.Size = new Size(142, 52);
            label1.TabIndex = 4;
            label1.Text = "饼状图";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(226, 56);
            label2.Name = "label2";
            label2.Size = new Size(142, 52);
            label2.TabIndex = 5;
            label2.Text = "条形图";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(3, 994);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(280, 34);
            progressBar1.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.Highlight;
            lblStatus.Location = new Point(3, 923);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 42);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "状态";
            lblStatus.Click += lblStatus_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(24, 32);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelTop);
            splitContainer1.Panel1.Controls.Add(progressBar1);
            splitContainer1.Panel1.Controls.Add(lblStatus);
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblDetailTitle);
            splitContainer1.Size = new Size(1305, 1046);
            splitContainer1.SplitterDistance = 612;
            splitContainer1.TabIndex = 8;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(btnFetch);
            panelTop.Controls.Add(cmbDifficulty);
            panelTop.Controls.Add(txtSearch);
            panelTop.Location = new Point(25, 31);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(548, 326);
            panelTop.TabIndex = 9;
            panelTop.Paint += panelTop_Paint;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(16, 225);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Location = new Point(283, 128);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(242, 39);
            cmbDifficulty.TabIndex = 11;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(16, 128);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 38);
            txtSearch.TabIndex = 10;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetailTitle.Location = new Point(19, 19);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(73, 37);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "题目";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1335, 32);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(737, 862);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pieChartPanel);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(8, 45);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(721, 809);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "饼状图";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(barChartPanel);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(8, 45);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(721, 809);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "条形图";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormLeetCode
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2084, 1111);
            Controls.Add(tabControl1);
            Controls.Add(splitContainer1);
            Name = "FormLeetCode";
            Text = "FormLeetCode";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnFetch;
        private Panel pieChartPanel;
        private Panel barChartPanel;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Label lblStatus;
        private SplitContainer splitContainer1;
        private Panel panelTop;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox cmbDifficulty;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblDetailTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}