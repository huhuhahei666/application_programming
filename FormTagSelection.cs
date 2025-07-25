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
    public partial class FormTagSelection : Form
    {
        public string SelectedDifficulty { get; private set; } = "中等";
        public string SelectedAlgorithmType { get; private set; } = "动态规划";
        public FormTagSelection()
        {
            InitializeComponent();
      
            this.Text = "选择题目标签";
            
            cmbDifficulty.Items.AddRange(new[] { "简单", "中等", "困难" });
            cmbDifficulty.SelectedIndex = 1;
            cmbAlgorithm.Items.AddRange(new[] { "动态规划", "回溯", "贪心", "DFS/BFS", "双指针", "排序", "二分查找", "位运算" ,"分治","二叉树","最短路径","最小生成树","强联通分量"});
            cmbAlgorithm.SelectedIndex = 0;
            btnOk.Click += (sender, e) =>
            {
                SelectedDifficulty = cmbDifficulty.SelectedItem.ToString();
                SelectedAlgorithmType = cmbAlgorithm.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            btnCancel.Click += (sender, e) => this.Close();

            
        }
    }
}
