namespace WinForms_singleselection
{
    partial class Form3
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
            label1 = new Label();
            cbCategory = new ComboBox();
            cbSubCategory = new ComboBox();
            pictureBox = new PictureBox();
            btnPrev = new Button();
            btnNext = new Button();
            lblImageInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(154, 79);
            label1.Name = "label1";
            label1.Size = new Size(210, 42);
            label1.TabIndex = 0;
            label1.Text = "这是一本相册";
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(83, 297);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(242, 39);
            cbCategory.TabIndex = 1;
            // 
            // cbSubCategory
            // 
            cbSubCategory.FormattingEnabled = true;
            cbSubCategory.Location = new Point(83, 394);
            cbSubCategory.Name = "cbSubCategory";
            cbSubCategory.Size = new Size(242, 39);
            cbSubCategory.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(851, 277);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(200, 100);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(751, 436);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(150, 46);
            btnPrev.TabIndex = 4;
            btnPrev.Text = "button1";
            btnPrev.UseVisualStyleBackColor = true;            
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1038, 436);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(150, 46);
            btnNext.TabIndex = 5;
            btnNext.Text = "button2";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // lblImageInfo
            // 
            lblImageInfo.AutoSize = true;
            lblImageInfo.Location = new Point(918, 199);
            lblImageInfo.Name = "lblImageInfo";
            lblImageInfo.Size = new Size(82, 31);
            lblImageInfo.TabIndex = 6;
            lblImageInfo.Text = "label2";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1274, 712);
            Controls.Add(lblImageInfo);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(pictureBox);
            Controls.Add(cbSubCategory);
            Controls.Add(cbCategory);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbCategory;
        private ComboBox cbSubCategory;
        private PictureBox pictureBox;
        private Button btnPrev;
        private Button btnNext;
        private Label lblImageInfo;
    }
}