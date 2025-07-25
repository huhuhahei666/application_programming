namespace WinForms_singleselection
{
    partial class FormSegment
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
            txtInput = new TextBox();
            btnExtract = new Button();
            lstNames = new ListBox();
            lblResult = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(82, 119);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(604, 373);
            txtInput.TabIndex = 0;
            // 
            // btnExtract
            // 
            btnExtract.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExtract.Location = new Point(277, 548);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new Size(163, 59);
            btnExtract.TabIndex = 1;
            btnExtract.Text = "分词";
            btnExtract.UseVisualStyleBackColor = true;
            btnExtract.Click += btnExtract_Click;
            // 
            // lstNames
            // 
            lstNames.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstNames.FormattingEnabled = true;
            lstNames.Location = new Point(994, 147);
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(759, 580);
            lstNames.TabIndex = 2;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(994, 61);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(96, 50);
            lblResult.TabIndex = 3;
            lblResult.Text = "统计";
            // 
            // FormSegment
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1948, 853);
            Controls.Add(lblResult);
            Controls.Add(lstNames);
            Controls.Add(btnExtract);
            Controls.Add(txtInput);
            Name = "FormSegment";
            Text = "FormSegment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnExtract;
        private ListBox lstNames;
        private Label lblResult;
    }
}