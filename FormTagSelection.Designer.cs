namespace WinForms_singleselection
{
    partial class FormTagSelection
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
            cmbAlgorithm = new ComboBox();
            cmbDifficulty = new ComboBox();
            btnOk = new Button();
            label1 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            SuspendLayout();
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.BackColor = Color.FromArgb(45, 45, 49);
            cmbAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgorithm.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbAlgorithm.ForeColor = Color.FromArgb(0, 193, 255);
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Location = new Point(61, 129);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(242, 58);
            cmbAlgorithm.TabIndex = 0;
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.BackColor = Color.FromArgb(45, 45, 49);
            cmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDifficulty.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbDifficulty.ForeColor = Color.FromArgb(0, 193, 255);
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Location = new Point(511, 129);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(242, 58);
            cmbDifficulty.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(0, 193, 255);
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOk.Location = new Point(189, 428);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(157, 76);
            btnOk.TabIndex = 2;
            btnOk.Text = "确定";
            btnOk.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 193, 255);
            label1.Location = new Point(119, 65);
            label1.Name = "label1";
            label1.Size = new Size(170, 50);
            label1.TabIndex = 3;
            label1.Text = "算法类型";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 193, 255);
            label2.Location = new Point(599, 65);
            label2.Name = "label2";
            label2.Size = new Size(96, 50);
            label2.TabIndex = 4;
            label2.Text = "难度";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(0, 193, 255);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("微软雅黑", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(526, 428);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 76);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Location = new Point(845, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(18, 616);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Location = new Point(0, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(18, 616);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.Location = new Point(-8, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(871, 23);
            panel3.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Location = new Point(12, 588);
            panel4.Name = "panel4";
            panel4.Size = new Size(839, 26);
            panel4.TabIndex = 8;
            // 
            // FormTagSelection
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 26);
            ClientSize = new Size(864, 613);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Controls.Add(cmbDifficulty);
            Controls.Add(cmbAlgorithm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTagSelection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTagSelection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAlgorithm;
        private ComboBox cmbDifficulty;
        private Button btnOk;
        private Label label1;
        private Label label2;
        private Button btnCancel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}