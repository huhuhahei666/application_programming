namespace WinForms_singleselection
{
    partial class FormSpider
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
            txtTiebaName = new TextBox();
            btnCrawl = new Button();
            progressBar1 = new ProgressBar();
            numPages = new NumericUpDown();
            dataGridView1 = new DataGridView();
            btnAnalyzeKeywords = new Button();
            btnGenerateWordCloud = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtTiebaName
            // 
            txtTiebaName.Location = new Point(394, 124);
            txtTiebaName.Name = "txtTiebaName";
            txtTiebaName.Size = new Size(200, 38);
            txtTiebaName.TabIndex = 0;
            // 
            // btnCrawl
            // 
            btnCrawl.Location = new Point(706, 136);
            btnCrawl.Name = "btnCrawl";
            btnCrawl.Size = new Size(150, 46);
            btnCrawl.TabIndex = 1;
            btnCrawl.Text = "爬取";
            btnCrawl.UseVisualStyleBackColor = true;
            btnCrawl.Click += btnCrawl_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(257, 607);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 46);
            progressBar1.TabIndex = 3;
            // 
            // numPages
            // 
            numPages.Location = new Point(52, 66);
            numPages.Name = "numPages";
            numPages.Size = new Size(240, 38);
            numPages.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(184, 202);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(480, 300);
            dataGridView1.TabIndex = 5;
            
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(796, 508);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(62, 31);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "状态";
            // 
            // FormSpider
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 674);
            Controls.Add(lblStatus);
            Controls.Add(btnGenerateWordCloud);
            Controls.Add(btnAnalyzeKeywords);
            Controls.Add(dataGridView1);
            Controls.Add(numPages);
            Controls.Add(progressBar1);
            Controls.Add(btnCrawl);
            Controls.Add(txtTiebaName);
            Name = "FormSpider";
            Text = "FormSpider";
            ((System.ComponentModel.ISupportInitialize)numPages).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTiebaName;
        private Button btnCrawl;
        private ProgressBar progressBar1;
        private NumericUpDown numPages;
        private DataGridView dataGridView1;
        private Button btnAnalyzeKeywords;
        private Button btnGenerateWordCloud;
        private Label lblStatus;
    }
}