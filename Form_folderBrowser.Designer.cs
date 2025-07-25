namespace WinForms_singleselection
{
    partial class Form_folderBrowser
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnBrowser = new Button();
            txtPath = new TextBox();
            txtSearch = new TextBox();
            listViewFiles = new ListView();
            label1 = new Label();
            label2 = new Label();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // btnBrowser
            // 
            btnBrowser.Location = new Point(848, 177);
            btnBrowser.Name = "btnBrowser";
            btnBrowser.Size = new Size(150, 46);
            btnBrowser.TabIndex = 0;
            btnBrowser.Text = "浏览";
            btnBrowser.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(520, 177);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(200, 38);
            txtPath.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(520, 294);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 38);
            txtSearch.TabIndex = 2;
            // 
            // listViewFiles
            // 
            listViewFiles.Location = new Point(603, 443);
            listViewFiles.Name = "listViewFiles";
            listViewFiles.Size = new Size(242, 194);
            listViewFiles.TabIndex = 3;
            listViewFiles.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(395, 177);
            label1.Name = "label1";
            label1.Size = new Size(62, 31);
            label1.TabIndex = 4;
            label1.Text = "路径";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 294);
            label2.Name = "label2";
            label2.Size = new Size(86, 31);
            label2.TabIndex = 5;
            label2.Text = "关键词";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(848, 294);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // Form_folderBrowser
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 770);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listViewFiles);
            Controls.Add(txtSearch);
            Controls.Add(txtPath);
            Controls.Add(btnBrowser);
            Name = "Form_folderBrowser";
            Text = "Form_folderBrowser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnBrowser;
        private TextBox txtPath;
        private TextBox txtSearch;
        private ListView listViewFiles;
        private Label label1;
        private Label label2;
        private Button btnSearch;
    }
}