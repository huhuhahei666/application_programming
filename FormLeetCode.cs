using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinForms_singleselection
{
    public partial class FormLeetCode : Form
    {
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;

        private List<LeetCodeProblem> problems = new List<LeetCodeProblem>();
        private BindingList<LeetCodeProblem> displayedProblems = new BindingList<LeetCodeProblem>();
        public FormLeetCode()
        {
            InitializeComponent();

            InitializeDataGridView();
            InitializeControls();
            // 绑定数据源
            dataGridView1.DataSource = displayedProblems;

            // 添加点击事件
            dataGridView1.CellClick += DataGridView1_CellClick;
        }
        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;

            // 添加列
            dataGridView1.Columns.Add("idColumn", "ID");
            dataGridView1.Columns["idColumn"].DataPropertyName = "Id";

            dataGridView1.Columns.Add("titleColumn", "标题");
            dataGridView1.Columns["titleColumn"].DataPropertyName = "Title";
            dataGridView1.Columns["titleColumn"].Width = 250;

            dataGridView1.Columns.Add("difficultyColumn", "难度");
            dataGridView1.Columns["difficultyColumn"].DataPropertyName = "Difficulty";

            dataGridView1.Columns.Add("acceptanceColumn", "通过率");
            dataGridView1.Columns["acceptanceColumn"].DataPropertyName = "Acceptance";
        }
        private void InitializeControls()
        {
            // 初始化筛选下拉框
            cmbDifficulty.Items.AddRange(new object[] { "全部", "简单", "中等", "困难" });
            cmbDifficulty.SelectedIndex = 0;
            // 初始化 WebView2
            InitializeWebView2();


        }
        private async void InitializeWebView2()
        {
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            webView2.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(webView2); // 添加到右侧面板

            // 确保运行时已安装
            await webView2.EnsureCoreWebView2Async();

            // 初始导航到空白页
            webView2.CoreWebView2.Navigate("about:blank");
        }
        private string GetEmbeddedResource(string resourceName)
        {
            // 获取当前程序集
            var assembly = Assembly.GetExecutingAssembly();

            // 如果项目默认命名空间是 "WinForms_singleselection"
            string fullResourceName = $"{assembly.GetName().Name}.{resourceName}";

            using (Stream stream = assembly.GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException($"未找到嵌入式资源: {fullResourceName}");

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        private async void btnFetch_Click(object sender, EventArgs e)
        {
            btnFetch.Enabled = false;
            lblStatus.Text = "正在获取数据...";
            progressBar1.Value = 0;

            try
            {
                await FetchLeetCodeProblems();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = problems;

                CreatePieChart();
                CreateBarChart();

                lblStatus.Text = $"获取完成，共 {problems.Count} 道题目";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "获取数据失败";
                btnSearch.Enabled = true;
            }
            finally
            {
                btnFetch.Enabled = true;
            }
        }
        private async Task FetchLeetCodeProblems()
        {
            problems.Clear();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                // 力扣的题目列表API
                string url = "https://leetcode.cn/api/problems/all/";
                var response = await client.GetStringAsync(url);

                var json = JObject.Parse(response);
                var problemList = json["stat_status_pairs"].ToObject<List<JObject>>();

                int total = problemList.Count;
                int processed = 0;

                foreach (var item in problemList)
                {
                    var problem = new LeetCodeProblem
                    {
                        Id = item["stat"]["frontend_question_id"].ToString(),
                        Title = item["stat"]["question__title"].ToString(),
                        Slug = item["stat"]["question__title_slug"].ToString(),
                        Difficulty = GetDifficultyString(item["difficulty"]["level"].ToObject<int>()),
                        Acceptance = CalculateAcceptanceRate(
                            item["stat"]["total_acs"].ToObject<double>(),
                            item["stat"]["total_submitted"].ToObject<double>())
                    };

                    problems.Add(problem);

                    processed++;
                    progressBar1.Value = (int)((double)processed / total * 100);
                }
            }
        }
        private string GetDifficultyString(int level)
        {
            switch (level)
            {
                case 1: return "简单";
                case 2: return "中等";
                case 3: return "困难";
                default: return "未知";
            }
        }
        private string CalculateAcceptanceRate(double acs, double submitted)
        {
            if (submitted == 0) return "0%";
            double rate = acs / submitted * 100;
            return $"{rate:F1}%";
        }
        private void FilterProblems()
        {
            var filtered = problems.AsQueryable();

            // 应用搜索条件
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchText = txtSearch.Text.ToLower();
                filtered = filtered.Where(p =>
                    p.Title.ToLower().Contains(searchText) ||
                    p.Id.ToLower().Contains(searchText));
            }

            // 应用难度筛选
            if (cmbDifficulty.SelectedIndex > 0)
            {
                string difficulty = cmbDifficulty.SelectedItem.ToString();
                filtered = filtered.Where(p => p.Difficulty == difficulty);
            }

            // 创建新列表替换旧列表（触发完整刷新）
            displayedProblems = new BindingList<LeetCodeProblem>(filtered.ToList());
            foreach (var problem in filtered.ToList())
            {
                displayedProblems.Add(problem);
            }
            // 重新绑定数据源（强制刷新）
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = displayedProblems;
            // 更新图表
            CreatePieChart();
            CreateBarChart();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterProblems();
        }
        private async void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var selectedProblem = displayedProblems[e.RowIndex];
                await ShowProblemDetail(selectedProblem);
            }
        }
        private async Task ShowProblemDetail(LeetCodeProblem problem)
        {
            lblDetailTitle.Text = $"{problem.Id}. {problem.Title} ({problem.Difficulty})";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                    // 获取题目详情页面
                    string url = $"https://leetcode.cn/problems/{problem.Slug}/";
                    var response = await client.GetStringAsync(url);

                    // 使用HtmlAgilityPack解析HTML
                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(response);

                    var contentNode = htmlDoc.DocumentNode.SelectSingleNode(
    "//div[@class='elfjS' and @data-track-load='description_content']"
) ?? htmlDoc.DocumentNode.SelectSingleNode(
    "//div[contains(@class, 'content__')]"  // 备用选择器
);

                    string content = contentNode?.InnerHtml ?? "无法获取题目内容";

                    // 清理内容 - 移除不需要的脚本和样式
                    var scripts = contentNode?.SelectNodes(".//script") ?? new HtmlAgilityPack.HtmlNodeCollection(null);
                    foreach (var script in scripts)
                    {
                        script.Remove();
                    }

                    var styles = contentNode?.SelectNodes(".//style") ?? new HtmlAgilityPack.HtmlNodeCollection(null);
                    foreach (var style in styles)
                    {
                        style.Remove();
                    }

                    // 提取标签
                    var tagNodes = htmlDoc.DocumentNode.SelectNodes("c//a[contains(@class, 'tag__2PqS')]") ??
                                  htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'tag')]");

                    problem.Tags.Clear();
                    if (tagNodes != null)
                    {
                        foreach (var tagNode in tagNodes)
                        {
                            problem.Tags.Add(tagNode.InnerText.Trim());
                        }
                    }

                    // 读取嵌入式HTML模板
                    string htmlTemplate = GetEmbeddedResource("ProblemTemplate.html");
                    string difficultyClass = problem.Difficulty switch
                    {
                        "简单" => "easy",
                        "中等" => "medium",
                        "困难" => "hard",
                        _ => "unknown"
                    };

                    var templateData = new
                    {
                        Title = $"{problem.Id}. {problem.Title}",
                        Difficulty = problem.Difficulty,
                        DifficultyClass = difficultyClass,
                        Acceptance = problem.Acceptance,
                        Tags = problem.Tags.Distinct().ToList(), // 去重
                        Content = content
                    };

                    // 模板替换
                    string html = htmlTemplate
                        .Replace("{{Title}}", templateData.Title)
                        .Replace("{{Difficulty}}", templateData.Difficulty)
                        .Replace("{{DifficultyClass}}", templateData.DifficultyClass)
                        .Replace("{{Acceptance}}", templateData.Acceptance)
                        .Replace("{{{Content}}}", templateData.Content);

                    // 处理标签
                    if (templateData.Tags.Count > 0)
                    {
                        var tagsHtml = string.Join("", templateData.Tags.Select(t => $"<span class='tag'>{t}</span>"));
                        html = html.Replace("{{#Tags}}{{.}}{{/Tags}}", tagsHtml);
                    }
                    else
                    {
                        html = html.Replace("{{#Tags}}{{.}}{{/Tags}}", "暂无标签");
                    }

                    // 使用WebView2加载HTML
                    await webView2.EnsureCoreWebView2Async();
                    webView2.NavigateToString(html);
                }
            }
            catch (Exception ex)
            {
                await webView2.EnsureCoreWebView2Async();
                webView2.NavigateToString($"<html><body><h3>无法加载题目详情</h3><p>{ex.Message}</p></body></html>");
            }
        }
        private void CreatePieChart()
        {
            pieChartPanel.Controls.Clear();

            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.ChartType = SeriesChartType.Pie;

            // 统计各难度题目数量
            int easy = 0, medium = 0, hard = 0;
            foreach (var problem in displayedProblems)
            {
                switch (problem.Difficulty)
                {
                    case "简单": easy++; break;
                    case "中等": medium++; break;
                    case "困难": hard++; break;
                }
            }

            series.Points.AddXY($"简单({easy})", easy);
            series.Points.AddXY($"中等({medium})", medium);
            series.Points.AddXY($"困难({hard})", hard);

            // 设置颜色
            series.Points[0].Color = Color.Green;
            series.Points[1].Color = Color.Orange;
            series.Points[2].Color = Color.Red;

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            chart.Series.Add(series);
            chart.Titles.Add("题目难度分布");

            pieChartPanel.Controls.Add(chart);
        }
        private void CreateBarChart()
        {
            barChartPanel.Controls.Clear();

            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.Name = "通过率";

            // 取前20道题目显示通过率
            int count = Math.Min(20, displayedProblems.Count);
            for (int i = 0; i < count; i++)
            {
                var problem = displayedProblems[i];
                double rate = double.Parse(problem.Acceptance.TrimEnd('%'));
                series.Points.AddXY($"{problem.Id}.{problem.Title}", rate);
            }

            chart.Series.Add(series);
            chart.Titles.Add("题目通过率 (前20题)");

            // 设置Y轴标题
            chartArea.AxisY.Title = "通过率(%)";

            // 自动调整X轴标签角度
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;

            barChartPanel.Controls.Add(chart);
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    public class LeetCodeProblem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Difficulty { get; set; }
        public string Acceptance { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
