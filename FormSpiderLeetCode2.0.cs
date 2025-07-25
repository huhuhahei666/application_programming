using HtmlAgilityPack;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace WinForms_singleselection
{

    public partial class FormSpiderLeetCode2 : Form
    {
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;

        private List<LeetCodeProblem2> problems = new List<LeetCodeProblem2>();
        private BindingList<LeetCodeProblem2> displayedProblems = new BindingList<LeetCodeProblem2>();
        private readonly LeetCodeGraphQLService _graphQLService = new LeetCodeGraphQLService();
        // 新增字段
        private SQLHelper _sqlHelper;
        private int _currentStudentId = -1;
        private string _currentStudentName = "";
        private LeetCodeProblem2 _currentProblem;
        public FormSpiderLeetCode2(SQLHelper sqlHelper, int studentId, string studentName)
        {

            InitializeComponent();
            // 绑定保存笔记按钮事件（只绑定一次）
            btnSaveNote.Click += (sender, e) =>
            {
                if (_currentProblem != null)
                {
                    _sqlHelper.SaveProblemNote(_currentStudentId, _currentProblem.Id, txtNote.Text);
                    MessageBox.Show("笔记保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            this.WindowState = FormWindowState.Normal;  // 必须先设为 Normal
            this.Bounds = Screen.PrimaryScreen.Bounds;
            _sqlHelper = sqlHelper;
            _currentStudentId = studentId;
            _currentStudentName = studentName;
            // 设置窗体标题显示当前用户
            //this.Text = $"力扣刷题助手 - 欢迎, {_currentStudentName}";
            label5.Text = $"力扣刷题助手 - 欢迎, {_currentStudentName}";
            InitializeDataGridView();
            InitializeControls();
            // 加载学生进度
            _ = LoadStudentProgress();
            // 绑定数据源
            dataGridView1.DataSource = displayedProblems;

            // 添加点击事件
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
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
            // 新增完成状态列
            dataGridView1.AutoGenerateColumns = false;
            var completedColumn = new DataGridViewCheckBoxColumn
            {
                Name = "completedColumn",
                HeaderText = "已完成",
                DataPropertyName = "IsCompleted"
            };
            dataGridView1.Columns.Add(completedColumn);

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

            // 1. 创建控件和设置属性（线程安全操作）
            var webView = new Microsoft.Web.WebView2.WinForms.WebView2
            {
                Dock = DockStyle.Fill,
                CreationProperties = new CoreWebView2CreationProperties
                {
                    UserDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WebView2Cache")
                }
            };

            // 2. 添加控件到窗体（必须在UI线程）
            if (splitContainer1.Panel2.InvokeRequired)
            {
                splitContainer1.Panel2.Invoke((MethodInvoker)delegate
                {
                    splitContainer1.Panel2.Controls.Add(webView);
                });
            }
            else
            {
                splitContainer1.Panel2.Controls.Add(webView);
            }

            // 3. 初始化WebView2环境
            try
            {
                await webView.EnsureCoreWebView2Async();
                webView.CoreWebView2.Navigate("about:blank");
                webView2 = webView; // 仅当成功时赋值
            }
            catch (WebView2RuntimeNotFoundException ex)
            {
                MessageBox.Show("请安装WebView2运行时: https://go.microsoft.com/fwlink/p/?LinkId=2124703");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化失败: {ex.GetType().Name} - {ex.Message}");
                webView.Dispose();
            }
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
        public class LeetCodeGraphQLService
        {
            private const string GraphQLEndpoint = "https://leetcode.cn/graphql";
            private readonly HttpClient _httpClient;

            public LeetCodeGraphQLService()
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            }

            public async Task<JObject> GetQuestionDetail(string titleSlug)
            {
                var query = new
                {
                    operationName = "questionData",
                    query = @"query questionData($titleSlug: String!) {
                question(titleSlug: $titleSlug) {
                    questionId
                    title
                    translatedTitle
                    difficulty
                    content
                    translatedContent
                    exampleTestcases
                    topicTags { name translatedName }
                    stats
                }
            }",
                    variables = new { titleSlug }
                };

                var response = await _httpClient.PostAsync(
                    GraphQLEndpoint,
                    new StringContent(JsonConvert.SerializeObject(query),
                    Encoding.UTF8,
                    "application/json"));

                return JObject.Parse(await response.Content.ReadAsStringAsync());
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
                    var problem = new LeetCodeProblem2
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
                    // 保存题目到数据库
                    SaveProblemToDatabase(problem);
                    processed++;
                    progressBar1.Value = (int)((double)processed / total * 100);
                }
            }
            // 重新加载学生进度
            if (_currentStudentId > 0)
            {
                await LoadStudentProgress();
            }

        }
        private void SaveProblemToDatabase(LeetCodeProblem2 problem)
        {
            try
            {
                // 检查题目是否已存在
                var checkSql = "SELECT COUNT(*) FROM Problems WHERE problem_id = @problem_id";
                var exists = Convert.ToInt32(_sqlHelper.ExecuteScalar(checkSql,
                    new SqlParameter("@problem_id", problem.Id))) > 0;

                if (!exists)
                {
                    // 插入新题目
                    var insertSql = @"
                    INSERT INTO Problems (problem_id, title, slug, difficulty, Acceptance, tags)
                    VALUES (@problem_id, @title, @slug, @difficulty, @Acceptance, @tags)";

                    _sqlHelper.ExecuteNonQuery(insertSql,
                        new SqlParameter("@problem_id", problem.Id),
                        new SqlParameter("@title", problem.Title),
                        new SqlParameter("@slug", problem.Slug),
                        new SqlParameter("@difficulty", problem.Difficulty),
                        new SqlParameter("@Acceptance", problem.Acceptance),
                        new SqlParameter("@tags", string.Join(",", problem.Tags)));
                }
            }
            catch (Exception ex)
            {
                // 记录错误但不中断程序
                Debug.WriteLine($"保存题目到数据库失败: {ex.Message}");
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
            try
            {
                var filtered = problems.AsQueryable();

                // 应用搜索条件
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string searchText = txtSearch.Text.Trim().ToLower();
                    filtered = filtered.Where(p =>
                        (p.Title != null && p.Title.ToLower().Contains(searchText)) ||
                    (p.Id != null && p.Id.ToLower().Contains(searchText)));
                }

                // 应用难度筛选
                if (cmbDifficulty.SelectedIndex > 0)
                {
                    string difficulty = cmbDifficulty.SelectedItem.ToString();
                    filtered = filtered.Where(p => p.Difficulty == difficulty);
                }

                // 创建新列表替换旧列表（触发完整刷新）
                displayedProblems = new BindingList<LeetCodeProblem2>(filtered.ToList());
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
            catch (Exception ex)
            {
                MessageBox.Show($"筛选时出错: {ex.Message}");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterProblems();
        }
        private async void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 检查是否点击了有效单元格（排除行头/列头）
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 检查数据源是否为空
            if (displayedProblems == null || displayedProblems.Count == 0) return;

            // 双重检查索引范围
            if (e.RowIndex >= displayedProblems.Count)
            {
                // 记录错误或显示提示
                Debug.WriteLine($"无效的行索引: {e.RowIndex}, 总行数: {displayedProblems.Count}");
                return;
            }

            try
            {
                var selectedProblem = displayedProblems[e.RowIndex];
                RecordProblemView(selectedProblem);
                await ShowProblemDetail(selectedProblem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载题目详情失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 处理完成状态复选框点击
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                 dataGridView1.Columns[e.ColumnIndex].Name == "completedColumn")
            {
                var problem = displayedProblems[e.RowIndex];
                bool isCompleted = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                MarkProblemAsCompleted(problem.Id, !isCompleted);
            }
        }

        private void RecordProblemView(LeetCodeProblem2 problem)
        {
            try
            {
                // 只更新查看时间，不创建新记录
                var updateSql = @"
            UPDATE StudentProblem 
            SET LastViewTime = @LastViewTime
            WHERE StuID = @StuID AND problem_id = @problem_id";

                _sqlHelper.ExecuteNonQuery(updateSql,
                    new SqlParameter("@StuID", _currentStudentId),
                    new SqlParameter("@problem_id", problem.Id),
                    new SqlParameter("@LastViewTime", DateTime.Now));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"记录题目查看失败: {ex.Message}");
            }
        }
        // 新增方法：标记题目完成状态
        private void MarkProblemAsCompleted(string problemId, bool isCompleted)
        {
            if (_currentStudentId <= 0) return;

            try
            {
                // 检查是否已有记录
                var checkSql = @"
                SELECT COUNT(*) FROM StudentProblem 
                WHERE StuID = @StuID AND problem_id = @problem_id";

                var exists = Convert.ToInt32(_sqlHelper.ExecuteScalar(checkSql,
                    new SqlParameter("@StuID", _currentStudentId),
                    new SqlParameter("@problem_id", problemId))) > 0;

                if (exists)
                {
                    // 更新完成状态
                    var updateSql = @"
                    UPDATE StudentProblem 
                    SET IsCompleted = @IsCompleted,
                        LastAttemptTime = @LastAttemptTime
                    WHERE StuID = @StuID AND problem_id = @problem_id";

                    _sqlHelper.ExecuteNonQuery(updateSql,
                        new SqlParameter("@StuID", _currentStudentId),
                        new SqlParameter("@problem_id", problemId),
                        new SqlParameter("@IsCompleted", isCompleted),
                        new SqlParameter("@LastAttemptTime", DateTime.Now));
                }
                else
                {
                    // 插入新记录
                    var insertSql = @"
                    INSERT INTO StudentProblem (StuID, problem_id, IsCompleted, LastAttemptTime, AttemptCount)
                    VALUES (@StuID, @problem_id, @IsCompleted, @LastAttemptTime, 1)";

                    _sqlHelper.ExecuteNonQuery(insertSql,
                        new SqlParameter("@StuID", _currentStudentId),
                        new SqlParameter("@problem_id", problemId),
                        new SqlParameter("@IsCompleted", isCompleted),
                        new SqlParameter("@LastAttemptTime", DateTime.Now));
                }

                // 更新本地数据
                var problem = problems.FirstOrDefault(p => p.Id == problemId);
                if (problem != null)
                {
                    problem.IsCompleted = isCompleted;
                    problem.LastAttemptTime = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新完成状态失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ShowProblemDetail(LeetCodeProblem2 problem)
        {
            lblDetailTitle.Text = $"{problem.Id}. {problem.Title} ({problem.Difficulty})";
            _currentProblem = problem;
            try
            {
                // 加载现有笔记
                txtNote.Text = _sqlHelper.GetProblemNote(_currentStudentId, problem.Id);
                
                // 1. 使用GraphQL API获取数据
                var result = await _graphQLService.GetQuestionDetail(problem.Slug);
                var question = result["data"]?["question"];

                if (question == null)
                {
                    throw new Exception("API返回数据格式异常");
                }

                // 2. 解析关键字段
                string content = question["translatedContent"]?.ToString() ??
                                question["content"]?.ToString() ??
                                "暂无题目描述";

                string examples = question["exampleTestcases"]?.ToString() ?? "无示例";
                var tags = question["topicTags"]?
                    .Select(t => t["translatedName"]?.ToString() ?? t["name"]?.ToString())
                    .Where(t => !string.IsNullOrEmpty(t))
                    .ToList() ?? new List<string>();

                // 3. 统计信息解析
                var stats = JObject.Parse(question["stats"]?.ToString() ?? "{}");
                string acceptance = stats["acRate"]?.ToString() ?? problem.Acceptance;

                // 4. 生成HTML
                string html = BuildProblemHtml(
                    title: $"{problem.Id}. {problem.Title}",
                    difficulty: problem.Difficulty,
                    acceptance: acceptance,
                    content: content,
                    examples: examples,
                    tags: tags
                );

                // 5. 渲染到WebView2
                await webView2.EnsureCoreWebView2Async();
                webView2.NavigateToString(html);
                /*// 注册JS回调
                webView2.CoreWebView2.AddHostObjectToScript("external", new
                {
                    ToggleCompletion = (Action)(() =>
                    {
                        // 在主线程上执行
                        this.Invoke((MethodInvoker)delegate
                        {
                            var isCompleted = !problem.IsCompleted;
                            MarkProblemAsCompleted(problem.Id, isCompleted);

                            // 更新UI
                            if (isCompleted)
                            {
                                MessageBox.Show("题目已标记为完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("题目已标记为未完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // 刷新显示
                            FilterProblems();
                        });
                    }),
                    ReloadPage = (Action)(() =>
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            var p = displayedProblems[dataGridView1.CurrentRow.Index];
                            _ = ShowProblemDetail(p);
                        }
                    })
                });*/
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常类型: {ex.GetType().Name}");
                Console.WriteLine($"异常消息: {ex.Message}");
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
                await ShowErrorPage(ex);
            }
        }

        private string BuildProblemHtml(string title, string difficulty, string acceptance,
                                      string content, string examples, List<string> tags)
        {
            string difficultyClass = difficulty switch
            {
                "简单" => "easy",
                "中等" => "medium",
                "困难" => "hard",
                _ => "unknown"
            };

            string htmlTemplate = GetEmbeddedResource("ProblemTemplate.html");
            // 添加完成状态按钮
            string completionButton = _currentStudentId > 0 ?
                $"<button id='completeBtn' class='completion-btn' onclick='window.external.ToggleCompletion()'>标记为完成</button>" :
                "<div class='login-prompt'>请登录以记录做题进度</div>";

            return htmlTemplate
                .Replace("{{Title}}", title)
                .Replace("{{Difficulty}}", difficulty)
                .Replace("{{DifficultyClass}}", difficultyClass)
                .Replace("{{Acceptance}}", acceptance)
                .Replace("{{{Content}}}", FormatContent(content, examples))
                .Replace("{{#Tags}}{{.}}{{/Tags}}",
                    tags.Count > 0 ? string.Join("", tags.Select(t => $"<span class='tag'>{t}</span>")) : "暂无标签")
                .Replace("{{CompletionButton}}", completionButton);
        }

        private string FormatContent(string content, string examples)
        {
            // 将Markdown格式的测试用例转换为HTML
            if (!string.IsNullOrWhiteSpace(examples))
            {
                string examplesHtml = $"<h3>示例测试用例</h3><pre>{System.Net.WebUtility.HtmlEncode(examples)}</pre>";
                content += examplesHtml;
            }
            return content;
        }

        private async Task ShowErrorPage(Exception ex)
        {
            string errorHtml = $$$"""
        <html>
            <style>
            body {{
                font-family: Arial;
                padding: 20px;
                color: #dc3545;
            }}

            .retry-btn {{
                padding: 8px 16px;
                background: #007bff;
                color: white;
                border: none;
                border-radius: 4px;
                cursor: pointer;
            }}
        </style>
            <body>
                <h3>⚠️ 加载题目详情失败</h3>
                <p>{ex.Message}</p>
                <button class="retry-btn" onclick="window.external.ReloadPage()">重试</button>
            </body>
        </html>
        """;

            await webView2.EnsureCoreWebView2Async();
            webView2.NavigateToString(errorHtml);

            // 注册JS回调（需在WebView2初始化时配置）
            webView2.CoreWebView2.AddHostObjectToScript("external", new
            {
                ReloadPage = (Action)(() =>
                {
                    // 获取当前选中的题目重新加载
                    if (dataGridView1.CurrentRow != null)
                    {
                        var problem = displayedProblems[dataGridView1.CurrentRow.Index];
                        _ = ShowProblemDetail(problem);
                    }
                })
            });
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
        private async Task ExportToExcel(IEnumerable<LeetCodeProblem> problems, string filePath)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");
            try
            {

                // 设置非商业许可证（EPPlus 8+ 新方式）
                ExcelPackage.License.SetNonCommercialPersonal("刘德华");

                using (var package = new ExcelPackage(new FileInfo(tempPath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("力扣题目");

                    // 设置列头
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "标题";
                    worksheet.Cells[1, 3].Value = "难度";
                    worksheet.Cells[1, 4].Value = "通过率";
                    worksheet.Cells[1, 5].Value = "标签";

                    // 分批写入数据
                    int batchSize = 500;
                    for (int i = 0; i < displayedProblems.Count; i += batchSize)
                    {
                        var batch = displayedProblems.Skip(i).Take(batchSize);
                        int row = i + 2; // 数据从第2行开始

                        foreach (var problem in batch)
                        {
                            worksheet.Cells[row, 1].Value = problem.Id;
                            worksheet.Cells[row, 2].Value = problem.Title;
                            worksheet.Cells[row, 3].Value = problem.Difficulty;
                            worksheet.Cells[row, 4].Value = problem.Acceptance;
                            worksheet.Cells[row, 5].Value = string.Join(", ", problem.Tags);
                            row++;
                        }

                        // 每批保存一次
                        package.Save();
                        await Task.Delay(100); // 避免UI冻结
                    }

                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                }

                // 移动到最终位置
                if (File.Exists(filePath)) File.Delete(filePath);
                File.Move(tempPath, filePath);
            }
            catch (Exception ex)
            {
                if (File.Exists(tempPath)) File.Delete(tempPath);
                throw new Exception($"导出失败: {ex.Message}");
            }

        }
        private async Task ExportProblemDetailToExcel(LeetCodeProblem2 problem, string filePath)
        {
            string tempPath = Path.GetTempFileName();
            try
            {
                // 设置非商业许可证（EPPlus 8+ 新方式）
                ExcelPackage.License.SetNonCommercialPersonal("刘德华");

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("题目详情");

                    // 1. 添加标题行（带样式）
                    using (var header = worksheet.Cells["A1:D1"])
                    {
                        header.Style.Font.Bold = true;
                        header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        header.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    }

                    // 2. 基础信息
                    worksheet.Cells["A1"].Value = "字段";
                    worksheet.Cells["B1"].Value = "内容";

                    worksheet.Cells["A2"].Value = "ID";
                    worksheet.Cells["B2"].Value = problem.Id;

                    worksheet.Cells["A3"].Value = "标题";
                    worksheet.Cells["B3"].Value = problem.Title;

                    worksheet.Cells["A4"].Value = "难度";
                    worksheet.Cells["B4"].Value = problem.Difficulty;

                    worksheet.Cells["A5"].Value = "通过率";
                    worksheet.Cells["B5"].Value = problem.Acceptance;

                    // 3. 获取题目详情（使用GraphQL API）
                    var detail = await _graphQLService.GetQuestionDetail(problem.Slug);
                    var question = detail["data"]?["question"];
                    string content = question?["translatedContent"]?.ToString() ?? "无内容";

                    // 4. 处理内容中的图片
                    var imageUrls = ExtractImageUrls(content);
                    var imageDict = new Dictionary<string, ExcelPicture>();

                    // 下载图片并添加到Excel
                    using (var client = new HttpClient())
                    {
                        int imgIndex = 0;
                        foreach (var imageUrl in imageUrls)
                        {
                            try
                            {
                                var imageBytes = await client.GetByteArrayAsync(imageUrl);
                                var picture = worksheet.Drawings.AddPicture($"img_{imgIndex}", new MemoryStream(imageBytes));
                                imageDict[imageUrl] = picture;
                                imgIndex++;
                            }
                            catch
                            {
                                // 如果图片下载失败，忽略继续处理
                            }
                        }
                    }

                    // 5. 添加详细内容（保留HTML格式）
                    worksheet.Cells["A6"].Value = "题目描述";
                    var richText = worksheet.Cells["B6"].RichText;
                    var cleanedContent = ConvertHtmlToRichText(content, richText, imageDict);
                    worksheet.Row(6).Height = 150; // 设置行高

                    // 6. 测试用例
                    worksheet.Cells["A7"].Value = "测试用例";
                    worksheet.Cells["B7"].Value = question?["exampleTestcases"]?.ToString();
                    worksheet.Row(7).Height = 100;

                    // 7. 标签
                    worksheet.Cells["A8"].Value = "标签";
                    worksheet.Cells["B8"].Value = string.Join(", ",
                        question?["topicTags"]?
                            .Select(t => t["translatedName"]?.ToString()) ??
                        problem.Tags);

                    // 设置自动换行和列宽
                    worksheet.Column(1).Width = 15;
                    worksheet.Column(2).Width = 80;
                    worksheet.Cells["B2:B8"].Style.WrapText = true;

                    // 保存到临时文件
                    package.SaveAs(new FileInfo(tempPath));
                }

                // 移动到目标位置
                if (File.Exists(filePath)) File.Delete(filePath);
                File.Move(tempPath, filePath);
            }
            catch (Exception ex)
            {
                if (File.Exists(tempPath)) File.Delete(tempPath);
                throw new Exception($"导出失败: {ex.Message}");
            }
        }
        private List<string> ExtractImageUrls(string htmlContent)
        {
            var imageUrls = new List<string>();
            if (string.IsNullOrEmpty(htmlContent)) return imageUrls;

            var regex = new Regex("<img.*?src=[\"'](.*?)[\"'].*?>", RegexOptions.IgnoreCase);
            var matches = regex.Matches(htmlContent);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string url = match.Groups[1].Value;
                    // 处理相对路径
                    if (url.StartsWith("//"))
                    {
                        url = "https:" + url;
                    }
                    else if (url.StartsWith("/"))
                    {
                        url = "https://leetcode.cn" + url;
                    }
                    imageUrls.Add(url);
                }
            }

            return imageUrls;
        }

        private string ConvertHtmlToRichText(string html, ExcelRichTextCollection richText, Dictionary<string, ExcelPicture> imageDict)
        {
            if (string.IsNullOrEmpty(html)) return "无内容";

            // 先移除所有图片标签，因为我们已经单独处理了图片
            html = Regex.Replace(html, "<img[^>]*>", "[图片]");

            // 简单处理其他HTML标签
            html = html.Replace("<p>", "\n")
                       .Replace("</p>", "\n")
                       .Replace("<br>", "\n")
                       .Replace("<br/>", "\n")
                       .Replace("<pre>", "\n")
                       .Replace("</pre>", "\n")
                       .Replace("<code>", "")
                       .Replace("</code>", "")
                       .Replace("<strong>", "")
                       .Replace("</strong>", "")
                       .Replace("<em>", "")
                       .Replace("</em>", "");

            // 添加文本到RichText
            richText.Add(html);

            return html;
        }
        private string CleanContent(string html)
        {
            if (string.IsNullOrEmpty(html)) return "无内容";

            // 简单清理HTML标签
            return Regex.Replace(html, "<[^>]*>", "")
                       .Replace("&nbsp;", " ")
                       .Replace("&lt;", "<")
                       .Replace("&gt;", ">");
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请先选择要导出的题目", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var problem = displayedProblems[dataGridView1.CurrentRow.Index];

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = $"力扣题目_{problem.Id}_{problem.Title}.xlsx";
                saveDialog.Filter = "Excel文件|*.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        btnExport.Enabled = false;

                        await ExportProblemDetailToExcel(problem, saveDialog.FileName);

                        MessageBox.Show($"题目【{problem.Title}】导出成功！", "成功",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 自动打开所在文件夹
                        Process.Start("explorer.exe", $"/select, \"{saveDialog.FileName}\"");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"导出失败: {ex.Message}", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        btnExport.Enabled = true;
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        private async Task LoadStudentProgress()
        {
            if (_currentStudentId <= 0) return;

            try
            {
                // 获取学生的做题记录
                var sql = @"
                SELECT p.problem_id, p.title, p.difficulty, p.Acceptance, 
                       sp.IsCompleted, sp.LastAttemptTime, sp.AttemptCount
                FROM Problems p
                LEFT JOIN StudentProblem sp ON p.problem_id = sp.problem_id AND sp.StuID = @StuID";

                var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@StuID", _currentStudentId));

                // 更新问题列表中的状态
                foreach (DataRow row in dt.Rows)
                {
                    var problemId = row["problem_id"].ToString();
                    var problem = problems.FirstOrDefault(p => p.Id == problemId);

                    if (problem != null)
                    {
                        problem.IsCompleted = row["IsCompleted"] != DBNull.Value ?
                    Convert.ToBoolean(row["IsCompleted"]) : false; // 默认值设为false

                        problem.LastAttemptTime = row["LastAttemptTime"] != DBNull.Value ?
                            Convert.ToDateTime(row["LastAttemptTime"]) : (DateTime?)null;

                        problem.AttemptCount = row["AttemptCount"] != DBNull.Value ?
                            Convert.ToInt32(row["AttemptCount"]) : 0; // 默认值设为0
                    }
                }

                // 刷新数据显示
                FilterProblems();
                // 更新状态栏
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载做题进度失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateStatusBar()
        {
            int total = problems.Count;
            int completed = problems.Count(p => p.IsCompleted);

            lblStatus.Text = $"用户: {_currentStudentName} | 总题数: {total} | 已完成: {completed}";
        }

        private void BtnPersonalCenter_Click(object sender, EventArgs e)
        {
            var personalCenterForm = new FormPersonalCenter(_sqlHelper, _currentStudentId, _currentStudentName);
            personalCenterForm.ShowDialog();
        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            var aiForm = new FormAI(_sqlHelper, _currentStudentId, _currentStudentName);
            aiForm.ShowDialog();
        }

        private void btnAddToBank_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var problem = displayedProblems[dataGridView1.CurrentRow.Index];
                AddToMyQuestionBank(problem);
            }
            else
            {
                MessageBox.Show("请先选择题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AddToMyQuestionBank(LeetCodeProblem2 problem)
        {
            if (_currentStudentId <= 0)
            {
                MessageBox.Show("请先登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 检查是否已在题库中
                var checkSql = @"
        SELECT COUNT(*) FROM StudentProblem 
        WHERE StuID = @StuID AND problem_id = @problem_id";

                var exists = Convert.ToInt32(_sqlHelper.ExecuteScalar(checkSql,
           new SqlParameter("@StuID", _currentStudentId),
           new SqlParameter("@problem_id", problem.Id))) > 0;

                if (exists)
                {
                    MessageBox.Show("该题目已在您的题库中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 插入到个人题库
                var insertSql = @"
        INSERT INTO StudentProblem 
        (StuID, problem_id, IsCompleted, LastViewTime, LastAttemptTime, AttemptCount)
        VALUES 
        (@StuID, @problem_id, @IsCompleted, @LastViewTime, @LastAttemptTime, @AttemptCount)";

                _sqlHelper.ExecuteNonQuery(insertSql,
                    new SqlParameter("@StuID", _currentStudentId),
                    new SqlParameter("@problem_id", problem.Id),
                    new SqlParameter("@IsCompleted", problem.IsCompleted),
                    new SqlParameter("@LastViewTime", problem.LastAttemptTime ?? (object)DBNull.Value),
                    new SqlParameter("@LastAttemptTime", problem.LastAttemptTime ?? (object)DBNull.Value),
                    new SqlParameter("@AttemptCount", problem.AttemptCount)
                   );

                MessageBox.Show("题目已成功加入您的题库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 刷新显示
                _ = LoadStudentProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加到题库失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class LeetCodeProblem2
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
            public string Difficulty { get; set; }
            public string Acceptance { get; set; }
            public List<string> Tags { get; set; } = new List<string>();
            public bool IsCompleted { get; set; }  // 新增完成状态
            public DateTime? LastAttemptTime { get; set; }  // 新增最后尝试时间
            public int AttemptCount { get; set; }  // 新增尝试次数
            public string Content { get; set; }
        }

    }

