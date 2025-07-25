using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JiebaNet.Segmenter;
using JiebaNet.Segmenter.PosSeg;

namespace WinForms_singleselection
{
   
    public partial class FormSegment : Form
    {
        private readonly PosSegmenter _posSegmenter;
        public FormSegment()
        {
            InitializeComponent();
            // 设置资源路径（相对于exe所在目录）
            var resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/consoleApp/WinForms_singleselection/Resources");

            // 如果资源目录不存在，尝试创建（首次运行时可能需要）
            if (!Directory.Exists(resourcePath))
            {
                try
                {
                    Directory.CreateDirectory(resourcePath);
                    // 这里可以添加代码检查必要文件是否存在，如果不存在则从程序内嵌资源释放
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"无法创建资源目录: {ex.Message}");
                    return;
                }
            }

            // 配置jieba的资源路径
            JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = resourcePath;

            try
            {
                _posSegmenter = new PosSegmenter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化分词器失败: {ex.Message}");
                // 可以考虑禁用相关功能按钮
                btnExtract.Enabled = false;
            }
        }
        private void btnExtract_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("请输入要分析的文本");
                return;
            }

            // 进行词性标注
            var posSegList = _posSegmenter.Cut(inputText);

            // 使用字典统计人名及其出现次数
            Dictionary<string, int> nameCounts = new Dictionary<string, int>();
            foreach (var pair in posSegList)
            {
                if (pair.Flag == "nr" || pair.Flag == "nz") // nr为人名，nz为其他专名
                {
                    if (nameCounts.ContainsKey(pair.Word))
                    {
                        nameCounts[pair.Word]++;
                    }
                    else
                    {
                        nameCounts[pair.Word] = 1;
                    }
                }
            }

            // 显示结果
            if (nameCounts.Count > 0)
            {
                // 将字典转换为列表显示，格式为"人名(出现次数)"
                var displayList = nameCounts.Select(kv => $"{kv.Key}({kv.Value})").ToList();
                lstNames.DataSource = displayList;

                // 计算总出现次数（去重后的人名数量）和总次数（所有人名出现次数的总和）
                int uniqueNamesCount = nameCounts.Count;
                int totalOccurrences = nameCounts.Values.Sum();
                lblResult.Text = $"找到 {uniqueNamesCount} 个不同人名，共出现 {totalOccurrences} 次";
            }
            else
            {
                lstNames.DataSource = null;
                lblResult.Text = "未找到人名";
            }
        }
    }
}

