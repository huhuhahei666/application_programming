namespace WinForms_singleselection
{
    partial class Form2
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
            timer1 = new System.Windows.Forms.Timer(components);
            lbl1 = new Label();
            button1 = new Button();
            button2 = new Button();
            progressBar1 = new ProgressBar();
            dateTimePicker1 = new DateTimePicker();
            btnDate = new Button();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            comboBoxCity = new ComboBox();
            comboBoxDistrict = new ComboBox();
            comboBoxProvince = new ComboBox();
            lable3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Microsoft YaHei UI", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(289, 218);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(196, 92);
            lbl1.TabIndex = 0;
            lbl1.Text = "time";
            // 
            // button1
            // 
            button1.Location = new Point(64, 100);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 1;
            button1.Text = "开始";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(564, 100);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 2;
            button2.Text = "结束";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(262, 325);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 46);
            progressBar1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(177, 46);
            dateTimePicker1.MaxDate = new DateTime(2149, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 38);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.Tag = "开学";
            // 
            // btnDate
            // 
            btnDate.Location = new Point(298, 111);
            btnDate.Name = "btnDate";
            btnDate.Size = new Size(150, 46);
            btnDate.TabIndex = 5;
            btnDate.Text = "button3";
            btnDate.UseVisualStyleBackColor = true;
            btnDate.Click += btnDate_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(177, 177);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(400, 38);
            dateTimePicker2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 46);
            label1.Name = "label1";
            label1.Size = new Size(62, 31);
            label1.TabIndex = 7;
            label1.Text = "开学";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 177);
            label2.Name = "label2";
            label2.Size = new Size(62, 31);
            label2.TabIndex = 8;
            label2.Text = "放假";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "一年级", "二年级", "三年级", "四年级", "五年级", "六年级" });
            comboBox1.Location = new Point(823, 291);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 39);
            comboBox1.TabIndex = 9;
            // 
            // comboBoxCity
            // 
            comboBoxCity.FormattingEnabled = true;
            comboBoxCity.Location = new Point(494, 560);
            comboBoxCity.Name = "comboBoxCity";
            comboBoxCity.Size = new Size(242, 39);
            comboBoxCity.TabIndex = 10;
            // 
            // comboBoxDistrict
            // 
            comboBoxDistrict.FormattingEnabled = true;
            comboBoxDistrict.Location = new Point(877, 560);
            comboBoxDistrict.Name = "comboBoxDistrict";
            comboBoxDistrict.Size = new Size(242, 39);
            comboBoxDistrict.TabIndex = 11;
            // 
            // comboBoxProvince
            // 
            comboBoxProvince.FormattingEnabled = true;
            comboBoxProvince.Location = new Point(113, 560);
            comboBoxProvince.Name = "comboBoxProvince";
            comboBoxProvince.Size = new Size(242, 39);
            comboBoxProvince.TabIndex = 12;
            // 
            // lable3
            // 
            lable3.AutoSize = true;
            lable3.Location = new Point(69, 563);
            lable3.Name = "lable3";
            lable3.Size = new Size(38, 31);
            lable3.TabIndex = 13;
            lable3.Text = "省";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(447, 563);
            label4.Name = "label4";
            label4.Size = new Size(38, 31);
            label4.TabIndex = 14;
            label4.Text = "市";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(833, 560);
            label5.Name = "label5";
            label5.Size = new Size(38, 31);
            label5.TabIndex = 15;
            label5.Text = "区";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1175, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(775, 781);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(996, 70);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 17;
            button3.Text = "加载图片";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1977, 812);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lable3);
            Controls.Add(comboBoxProvince);
            Controls.Add(comboBoxDistrict);
            Controls.Add(comboBoxCity);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(btnDate);
            Controls.Add(dateTimePicker1);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lbl1);
            Name = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label lbl1;
        private Button button1;
        private Button button2;
        private ProgressBar progressBar1;
        private DateTimePicker dateTimePicker1;
        private Button btnDate;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBoxCity;
        private ComboBox comboBoxDistrict;
        private ComboBox comboBoxProvince;
        private Label lable3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private Button button3;
    }
}