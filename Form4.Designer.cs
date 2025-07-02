namespace WinForms_singleselection
{
    partial class Form4
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
            cbCategory = new ComboBox();
            cbSubCategory = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            pictureBox = new PictureBox();
            lblImageInfo = new Label();
            btnZoomIn = new Button();
            btnZoomOut = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(178, 126);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(242, 39);
            cbCategory.TabIndex = 0;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // cbSubCategory
            // 
            cbSubCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSubCategory.FormattingEnabled = true;
            cbSubCategory.Location = new Point(178, 346);
            cbSubCategory.Name = "cbSubCategory";
            cbSubCategory.Size = new Size(242, 39);
            cbSubCategory.TabIndex = 1;
            cbSubCategory.SelectedIndexChanged += cbSubCategory_SelectedIndexChanged;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = SystemColors.ActiveCaption;
            btnPrev.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.ForeColor = SystemColors.ButtonHighlight;
            btnPrev.Location = new Point(27, 530);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(150, 46);
            btnPrev.TabIndex = 2;
            btnPrev.Text = "上一页";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = SystemColors.ActiveCaption;
            btnNext.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = SystemColors.ButtonHighlight;
            btnNext.Location = new Point(327, 530);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(150, 46);
            btnNext.TabIndex = 3;
            btnNext.Text = "下一页";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(992, 67);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(946, 935);
            pictureBox.TabIndex = 4;
            pictureBox.TabStop = false;
            // 
            // lblImageInfo
            // 
            lblImageInfo.AutoSize = true;
            lblImageInfo.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblImageInfo.Location = new Point(1273, 9);
            lblImageInfo.Name = "lblImageInfo";
            lblImageInfo.Size = new Size(144, 52);
            lblImageInfo.TabIndex = 5;
            lblImageInfo.Text = "label1";
            // 
            // btnZoomIn
            // 
            btnZoomIn.BackColor = SystemColors.ActiveCaption;
            btnZoomIn.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZoomIn.ForeColor = SystemColors.ButtonHighlight;
            btnZoomIn.Location = new Point(27, 695);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(150, 46);
            btnZoomIn.TabIndex = 6;
            btnZoomIn.Text = "放大";
            btnZoomIn.UseVisualStyleBackColor = false;
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // btnZoomOut
            // 
            btnZoomOut.BackColor = SystemColors.ActiveCaption;
            btnZoomOut.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZoomOut.ForeColor = SystemColors.ButtonHighlight;
            btnZoomOut.Location = new Point(327, 695);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(150, 46);
            btnZoomOut.TabIndex = 7;
            btnZoomOut.Text = "缩小";
            btnZoomOut.UseVisualStyleBackColor = false;
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 124);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 8;
            label1.Text = "一级分类";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 344);
            label2.Name = "label2";
            label2.Size = new Size(129, 37);
            label2.TabIndex = 9;
            label2.Text = "二级分类";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 9);
            label3.Name = "label3";
            label3.Size = new Size(547, 36);
            label3.TabIndex = 10;
            label3.Text = "提示：这是一本相册，请选择分类进行查阅";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2080, 1014);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnZoomOut);
            Controls.Add(btnZoomIn);
            Controls.Add(lblImageInfo);
            Controls.Add(pictureBox);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(cbSubCategory);
            Controls.Add(cbCategory);
            Name = "Form4";
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCategory;
        private ComboBox cbSubCategory;
        private Button btnPrev;
        private Button btnNext;
        private PictureBox pictureBox;
        private Label lblImageInfo;
        private Button btnZoomIn;
        private Button btnZoomOut;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}