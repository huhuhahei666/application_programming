namespace WinForms_singleselection
{
    partial class FormSpiderEcnu
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
            btnCrawl = new Button();
            txtStatus = new TextBox();
            lstResults = new ListBox();
            label1 = new Label();
            panelWordCloud = new Panel();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btnCrawl
            // 
            btnCrawl.Location = new Point(68, 346);
            btnCrawl.Name = "btnCrawl";
            btnCrawl.Size = new Size(150, 46);
            btnCrawl.TabIndex = 0;
            btnCrawl.Text = "爬取";
            btnCrawl.UseVisualStyleBackColor = true;
            btnCrawl.Click += btnCrawl_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(314, 89);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(200, 38);
            txtStatus.TabIndex = 1;
            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(32, 89);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(240, 190);
            lstResults.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(338, 42);
            label1.TabIndex = 3;
            label1.Text = "华东师大官网词频统计";
            // 
            // panelWordCloud
            // 
            panelWordCloud.Location = new Point(703, 12);
            panelWordCloud.Name = "panelWordCloud";
            panelWordCloud.Size = new Size(1322, 857);
            panelWordCloud.TabIndex = 4;
            panelWordCloud.Paint += panel1_Paint;
            // 
            // FormSpiderEcnu
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2037, 890);
            Controls.Add(panelWordCloud);
            Controls.Add(label1);
            Controls.Add(lstResults);
            Controls.Add(txtStatus);
            Controls.Add(btnCrawl);
            Name = "FormSpiderEcnu";
            Text = "FormSpiderEcnu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCrawl;
        private TextBox txtStatus;
        private ListBox lstResults;
        private Label label1;
        private Panel panelWordCloud;
        private ToolTip toolTip1;
    }
}