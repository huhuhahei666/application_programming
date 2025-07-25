using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_singleselection
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog(); // 使用 ShowDialog 以模态方式打开 Form4
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(); // 使用 ShowDialog 以模态方式打开 Form2
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormLeetCode formLeetCode = new FormLeetCode();
            formLeetCode.ShowDialog(); // 使用 ShowDialog 以模态方式打开 FormLeetCode
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSegment formSegment = new FormSegment();
            formSegment.ShowDialog(); // 使用 ShowDialog 以模态方式打开 FormSegment
        }
    }
}
    