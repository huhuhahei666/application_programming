namespace WinForms_singleselection
{
    partial class FormSpiderQqmusic
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
            txtSearchKeyword = new TextBox();
            btnSearch = new Button();
            dgvSearchResults = new DataGridView();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            lblSelectedSong = new Label();
            txtSongId = new TextBox();
            btnFetchComments = new Button();
            lstComments = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
            SuspendLayout();
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Location = new Point(132, 256);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.Size = new Size(277, 38);
            txtSearchKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(625, 353);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchResults.Location = new Point(113, 442);
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.RowHeadersWidth = 82;
            dgvSearchResults.Size = new Size(480, 300);
            dgvSearchResults.TabIndex = 2;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(178, 145);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(200, 46);
            progressBar.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(1066, 283);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 31);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "label1";
            // 
            // lblSelectedSong
            // 
            lblSelectedSong.AutoSize = true;
            lblSelectedSong.Location = new Point(1066, 368);
            lblSelectedSong.Name = "lblSelectedSong";
            lblSelectedSong.Size = new Size(82, 31);
            lblSelectedSong.TabIndex = 5;
            lblSelectedSong.Text = "label1";
            // 
            // txtSongId
            // 
            txtSongId.Location = new Point(689, 234);
            txtSongId.Name = "txtSongId";
            txtSongId.Size = new Size(237, 38);
            txtSongId.TabIndex = 6;
            // 
            // btnFetchComments
            // 
            btnFetchComments.Location = new Point(842, 360);
            btnFetchComments.Name = "btnFetchComments";
            btnFetchComments.Size = new Size(150, 46);
            btnFetchComments.TabIndex = 7;
            btnFetchComments.Text = "查看";
            btnFetchComments.UseVisualStyleBackColor = true;
            btnFetchComments.Click += btnFetchComments_Click;
            // 
            // lstComments
            // 
            lstComments.FormattingEnabled = true;
            lstComments.Location = new Point(792, 533);
            lstComments.Name = "lstComments";
            lstComments.Size = new Size(240, 190);
            lstComments.TabIndex = 8;
            // 
            // FormSpiderQqmusic
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 821);
            Controls.Add(lstComments);
            Controls.Add(btnFetchComments);
            Controls.Add(txtSongId);
            Controls.Add(lblSelectedSong);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(dgvSearchResults);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchKeyword);
            Name = "FormSpiderQqmusic";
            Text = "FormSpiderQqmusic";
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchKeyword;
        private Button btnSearch;
        private DataGridView dgvSearchResults;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblSelectedSong;
        private TextBox txtSongId;
        private Button btnFetchComments;
        private ListBox lstComments;
    }
}