using HtmlAgilityPack;
using JiebaNet.Analyser;
using JiebaNet.Segmenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_singleselection
{
    public partial class FormSpiderEcnu : Form
    {

        public FormSpiderEcnu()
        {
            InitializeComponent();


        }
        private async void btnCrawl_Click(object sender, EventArgs e)
        {
            string url = "https://www.ecnu.edu.cn";

            try
            {
                txtStatus.Text = "正在爬取数据...";
                btnCrawl.Enabled = false;

                // 获取网页内容
                string htmlContent = await GetWebContent(url);

                // 提取文本
                string cleanText = ExtractTextFromHtml(htmlContent);

                // 统计高频词
                var wordFrequencies = CountWordFrequencies(cleanText);

                // 显示结果
                DisplayResults(wordFrequencies);
                // 生成词云
                GenerateWordCloud(wordFrequencies);

                txtStatus.Text = "爬取完成!";
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"错误: {ex.Message}";
            }
            finally
            {
                btnCrawl.Enabled = true;
            }
        }
        private async Task<string> GetWebContent(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // 设置User-Agent模拟浏览器访问
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        private string ExtractTextFromHtml(string html)
        {
            // 使用HtmlAgilityPack解析HTML
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // 移除不需要的节点(脚本、样式等)
            doc.DocumentNode.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style" || n.Name == "nav" || n.Name == "footer")
                .ToList()
                .ForEach(n => n.Remove());

            // 获取纯文本
            string text = doc.DocumentNode.InnerText;

            // 清理文本 - 移除多余空格、换行等
            text = Regex.Replace(text, @"\s+", " ");
            text = Regex.Replace(text, @"<[^>]*>", string.Empty);

            return text;
        }
        private Dictionary<string, int> CountWordFrequencies(string text)
        {
            // 中文分词简单实现(这里使用简单分割，实际项目应考虑使用专业分词库)
            var words = Regex.Split(text, @"\W+")
                .Where(w => w.Length > 1 && IsChineseOrEnglishWord(w))
                .Select(w => w.ToLower());

            // 过滤停用词
            var stopWords = GetStopWords();
            words = words.Where(w => !stopWords.Contains(w));

            // 统计词频
            return words.GroupBy(w => w)
                       .OrderByDescending(g => g.Count())
                       .Take(50) // 取前50个高频词
                       .ToDictionary(g => g.Key, g => g.Count());
        }
        private bool IsChineseOrEnglishWord(string word)
        {
            // 简单判断是否是中文或英文单词
            return Regex.IsMatch(word, @"^[\u4e00-\u9fa5]+$") ||
                   Regex.IsMatch(word, @"^[a-zA-Z]+$");
        }
        private HashSet<string> GetStopWords()
        {
            // 常见停用词列表(可根据需要扩展)
            return new HashSet<string>
            {
                "的", "和", "是", "在", "了", "有", "我", "你", "他", "她", "它",
                "这", "那", "为", "与", "或", "就", "都", "而", "及", "等", "也",
                "年", "月", "日", "时", "分", "秒", "www", "com", "http", "https",
                "the", "and", "a", "an", "in", "on", "at", "to", "of", "for",
                "华东师范大学", "大学", "学校", "学院", "相关", "表示", "可以", "工作"
            };
        }
        private void DisplayResults(Dictionary<string, int> wordFrequencies)
        {
            lstResults.Items.Clear();

            foreach (var item in wordFrequencies.OrderByDescending(x => x.Value))
            {
                lstResults.Items.Add($"{item.Key}: {item.Value}次");
            }
        }
        private void GenerateWordCloud(Dictionary<string, int> wordFrequencies)
        {
            panelWordCloud.Controls.Clear();

            if (wordFrequencies == null || wordFrequencies.Count == 0)
                return;

            // 计算最大最小词频用于缩放
            int maxFreq = wordFrequencies.Max(x => x.Value);
            int minFreq = wordFrequencies.Min(x => x.Value);
            int range = Math.Max(1, maxFreq - minFreq); // 避免除以零

            Random rand = new Random();
            int panelCenterX = panelWordCloud.Width / 2;
            int panelCenterY = panelWordCloud.Height / 2;

            // 螺旋布局参数
            double angleStep = Math.PI / 12; // 15度步长
            double currentAngle = 0;
            double radiusStep = 5;
            double currentRadius = 0;

            // 创建词语标签 (取前50个高频词)
            foreach (var item in wordFrequencies.OrderByDescending(x => x.Value).Take(50))
            {
                Label wordLabel = new Label();
                wordLabel.Text = item.Key;

                // 根据词频计算字体大小 (10-32pt范围)
                float fontSize = 10 + (item.Value - minFreq) * 22f / range;
                wordLabel.Font = new Font("Microsoft YaHei", fontSize, FontStyle.Bold);

                // 随机颜色 (避免太亮或太暗)
                wordLabel.ForeColor = Color.FromArgb(
                    rand.Next(50, 200),
                    rand.Next(50, 200),
                    rand.Next(50, 200));

                wordLabel.AutoSize = true;

                // 尝试放置词语，避免重叠
                int attempts = 0;
                Point location;
                bool overlap;

                do
                {
                    // 螺旋布局计算位置
                    currentAngle += angleStep;
                    currentRadius += radiusStep;

                    int x = panelCenterX + (int)(currentRadius * Math.Cos(currentAngle)) - wordLabel.Width / 2;
                    int y = panelCenterY + (int)(currentRadius * Math.Sin(currentAngle)) - wordLabel.Height / 2;

                    location = new Point(
                        Math.Max(0, Math.Min(x, panelWordCloud.Width - wordLabel.Width)),
                        Math.Max(0, Math.Min(y, panelWordCloud.Height - wordLabel.Height)));

                    wordLabel.Location = location;

                    // 检查重叠
                    overlap = CheckOverlap(wordLabel, panelWordCloud.Controls);
                    attempts++;

                    // 如果尝试太多次，随机放置
                    if (attempts > 50)
                    {
                        location = new Point(
                            rand.Next(0, panelWordCloud.Width - wordLabel.Width),
                            rand.Next(0, panelWordCloud.Height - wordLabel.Height));
                        break;
                    }
                } while (overlap);

                wordLabel.Location = location;

                // 添加悬停效果
                wordLabel.MouseEnter += (s, e) => {
                    wordLabel.BackColor = Color.LightYellow;
                    wordLabel.BorderStyle = BorderStyle.FixedSingle;
                };
                wordLabel.MouseLeave += (s, e) => {
                    wordLabel.BackColor = Color.Transparent;
                    wordLabel.BorderStyle = BorderStyle.None;
                };

                // 添加ToolTip显示词频
                toolTip1.SetToolTip(wordLabel, $"{item.Key}: {item.Value}次");

                // 添加到Panel
                panelWordCloud.Controls.Add(wordLabel);
            }
        }
        private bool CheckOverlap(Control newControl, Control.ControlCollection existingControls)
        {
            Rectangle newRect = new Rectangle(
                newControl.Location,
                newControl.Size);

            foreach (Control ctrl in existingControls)
            {
                Rectangle existingRect = new Rectangle(
                    ctrl.Location,
                    ctrl.Size);

                if (newRect.IntersectsWith(existingRect))
                    return true;
            }

            return false;
        }

        private void panelWordCloud_Resize(object sender, EventArgs e)
        {
            // 当面板大小改变时重新生成词云
            if (panelWordCloud.Tag != null)
            {
                GenerateWordCloud((Dictionary<string, int>)panelWordCloud.Tag);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
