namespace WinForms_singleselection
{
    partial class FormDouban
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
            comboBoxType = new ComboBox();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            listViewResults = new ListView();
            txtTitle = new TextBox();
            txtRating = new TextBox();
            txtRatingCount = new TextBox();
            txtPubInfo = new TextBox();
            txtIntro = new TextBox();
            linkLabelUrl = new LinkLabel();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "书籍", "电影" });
            comboBoxType.Location = new Point(25, 66);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(242, 39);
            comboBoxType.TabIndex = 0;
            comboBoxType.SelectedIndexChanged += listViewResults_SelectedIndexChanged;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(337, 66);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(200, 38);
            txtKeyword.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(562, 53);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // listViewResults
            // 
            listViewResults.Location = new Point(25, 224);
            listViewResults.Name = "listViewResults";
            listViewResults.Size = new Size(163, 214);
            listViewResults.TabIndex = 3;
            listViewResults.UseCompatibleStateImageBehavior = false;
            listViewResults.SelectedIndexChanged += listViewResults_SelectedIndexChanged;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(277, 238);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(223, 38);
            txtTitle.TabIndex = 4;
            // 
            // txtRating
            // 
            txtRating.Location = new Point(547, 247);
            txtRating.Name = "txtRating";
            txtRating.Size = new Size(200, 38);
            txtRating.TabIndex = 5;
            // 
            // txtRatingCount
            // 
            txtRatingCount.Location = new Point(261, 381);
            txtRatingCount.Name = "txtRatingCount";
            txtRatingCount.Size = new Size(239, 38);
            txtRatingCount.TabIndex = 6;
            // 
            // txtPubInfo
            // 
            txtPubInfo.Location = new Point(575, 390);
            txtPubInfo.Name = "txtPubInfo";
            txtPubInfo.Size = new Size(200, 38);
            txtPubInfo.TabIndex = 7;
            // 
            // txtIntro
            // 
            txtIntro.Location = new Point(337, 552);
            txtIntro.Multiline = true;
            txtIntro.Name = "txtIntro";
            txtIntro.Size = new Size(200, 76);
            txtIntro.TabIndex = 8;
            // 
            // linkLabelUrl
            // 
            linkLabelUrl.AutoSize = true;
            linkLabelUrl.Location = new Point(693, 661);
            linkLabelUrl.Name = "linkLabelUrl";
            linkLabelUrl.Size = new Size(128, 31);
            linkLabelUrl.TabIndex = 9;
            linkLabelUrl.TabStop = true;
            linkLabelUrl.Text = "linkLabel1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(818, 172);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 31);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "label1";
            // 
            // FormDouban
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 876);
            Controls.Add(lblStatus);
            Controls.Add(linkLabelUrl);
            Controls.Add(txtIntro);
            Controls.Add(txtPubInfo);
            Controls.Add(txtRatingCount);
            Controls.Add(txtRating);
            Controls.Add(txtTitle);
            Controls.Add(listViewResults);
            Controls.Add(btnSearch);
            Controls.Add(txtKeyword);
            Controls.Add(comboBoxType);
            Name = "FormDouban";
            Text = "FormDouban";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxType;
        private TextBox txtKeyword;
        private Button btnSearch;
        private ListView listViewResults;
        private TextBox txtTitle;
        private TextBox txtRating;
        private TextBox txtRatingCount;
        private TextBox txtPubInfo;
        private TextBox txtIntro;
        private LinkLabel linkLabelUrl;
        private Label lblStatus;
    }
}