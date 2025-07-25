using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static WinForms_singleselection.FormSpiderLeetCode2;

namespace WinForms_singleselection
{
    public partial class FormPersonalCenter : Form
    {
        private readonly SQLHelper _sqlHelper;
        private readonly int _currentStudentId;
        private readonly string _currentStudentName;
        public FormPersonalCenter(SQLHelper sqlHelper, int studentId, string studentName)
        {
            InitializeComponent();
            _sqlHelper = sqlHelper;
            _currentStudentId = studentId;
            _currentStudentName = studentName;
            InitializeUI();
            //LoadData();
        }
        private void InitializeUI()
        {
            this.Text = $"个人中心 - {_currentStudentName}";
            //this.WindowState = FormWindowState.Maximized;
            InitializeMyProblemsTab(tabMyProblems);
            InitializeHistoryTab(tabHistory);
            InitializeAnalyticsTab(tabAnalytics);
            InitializeRankingTab(tabRanking);
            InitializeAIProblemsTab(); // 新增初始化AI题目标签页
        }
        private void InitializeMyProblemsTab(TabPage tabPage)
        {




            // 配置DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 200 },
                new DataGridViewTextBoxColumn { HeaderText = "标题", DataPropertyName = "Title", Width = 500 },
                new DataGridViewTextBoxColumn { HeaderText = "难度", DataPropertyName = "Difficulty", Width = 80 },
                new DataGridViewTextBoxColumn { HeaderText = "通过率", DataPropertyName = "Acceptance", Width = 200 },
                new DataGridViewCheckBoxColumn { HeaderText = "已完成", DataPropertyName = "IsCompleted", Width = 80 },
                new DataGridViewTextBoxColumn { HeaderText = "最后尝试", DataPropertyName = "LastAttemptTime", Width = 500 },
                new DataGridViewTextBoxColumn { HeaderText = "笔记", DataPropertyName = "Notes", Width = 500 }  // 新增Notes列
            );

            // 加载数据
            var sql = @"
       SELECT p.problem_id AS Id, p.title AS Title, p.difficulty AS Difficulty, 
             p.Acceptance, sp.IsCompleted, sp.LastAttemptTime, sp.Notes
       FROM StudentProblem sp
       JOIN Problems p ON sp.problem_id = p.problem_id
       WHERE sp.StuID = @StuID
       ORDER BY sp.LastAttemptTime DESC";

            var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@StuID", _currentStudentId));
            dataGridView1.DataSource = dt;


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
        private void InitializeHistoryTab(TabPage tabPage)
        {
            var chart = new Chart { Dock = DockStyle.Fill };
            tabPage.Controls.Add(chart);

            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series
            {
                ChartType = SeriesChartType.Column,
                Name = "每日刷题数",
                XValueType = ChartValueType.Date
            };

            // 获取刷题历史数据
            var sql = @"
            SELECT CAST(LastAttemptTime AS DATE) AS AttemptDate, 
                   COUNT(*) AS ProblemCount
            FROM StudentProblem
            WHERE StuID = @StuID
            GROUP BY CAST(LastAttemptTime AS DATE)
            ORDER BY AttemptDate";

            var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@StuID", _currentStudentId));

            foreach (DataRow row in dt.Rows)
            {
                // 双重保险检查
                if (row["AttemptDate"] != DBNull.Value)
                {
                    series.Points.AddXY(
                        Convert.ToDateTime(row["AttemptDate"]),
                        Convert.ToInt32(row["ProblemCount"])
                    );
                }
            }

            chart.Series.Add(series);
            chart.Titles.Add("刷题历史记录");

            // 配置坐标轴
            chartArea.AxisX.Title = "日期";
            chartArea.AxisY.Title = "刷题数量";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.LabelStyle.Format = "MM-dd";
        }
        private void InitializeAnalyticsTab(TabPage tabPage)
        {


            // 上方：难度分布饼图
            var pieChart = new Chart { Dock = DockStyle.Fill };
            splitContainer2.Panel1.Controls.Add(pieChart);
            InitializeDifficultyPieChart(pieChart);

            // 下方：完成进度柱状图
            var barChart = new Chart { Dock = DockStyle.Fill };
            splitContainer2.Panel2.Controls.Add(barChart);
            InitializeCompletionBarChart(barChart);
        }
        private void InitializeDifficultyPieChart(Chart chart)
        {
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series
            {
                ChartType = SeriesChartType.Pie,
                Name = "难度分布"
            };

            // 获取难度分布数据
            var sql = @"
            SELECT p.difficulty, 
                   COUNT(*) AS Count,
                   SUM(CASE WHEN sp.IsCompleted = 1 THEN 1 ELSE 0 END) AS CompletedCount
            FROM StudentProblem sp
            JOIN Problems p ON sp.problem_id = p.problem_id
            WHERE sp.StuID = @StuID
            GROUP BY p.difficulty";

            var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@StuID", _currentStudentId));

            foreach (DataRow row in dt.Rows)
            {
                string difficulty = row["difficulty"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                int completed = Convert.ToInt32(row["CompletedCount"]);

                series.Points.AddXY($"{difficulty}({completed}/{count})", count);
            }

            chart.Series.Add(series);
            chart.Titles.Add("题目难度分布 (已完成/总数)");

            // 设置颜色
            if (series.Points.Count > 0)
            {
                series.Points[0].Color = Color.Green;   // 简单
                if (series.Points.Count > 1) series.Points[1].Color = Color.Orange; // 中等
                if (series.Points.Count > 2) series.Points[2].Color = Color.Red;   // 困难
            }

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
        }

        private void InitializeCompletionBarChart(Chart chart)
        {
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var completedSeries = new Series
            {
                ChartType = SeriesChartType.Column,
                Name = "已完成",
                Color = Color.Green
            };

            var totalSeries = new Series
            {
                ChartType = SeriesChartType.Column,
                Name = "总题数",
                Color = Color.LightGray
            };

            // 获取每周完成情况数据
            var sql = @"
            SELECT 
                DATEPART(YEAR, LastAttemptTime) AS Year,
                DATEPART(WEEK, LastAttemptTime) AS Week,
                COUNT(*) AS TotalCount,
                SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END) AS CompletedCount
            FROM StudentProblem
            WHERE StuID = @StuID
            GROUP BY DATEPART(YEAR, LastAttemptTime), DATEPART(WEEK, LastAttemptTime)
            ORDER BY Year, Week";

            var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@StuID", _currentStudentId));

            foreach (DataRow row in dt.Rows)
            {
                string weekLabel = $"{row["Year"]}-W{row["Week"]}";
                int total = Convert.ToInt32(row["TotalCount"]);
                int completed = Convert.ToInt32(row["CompletedCount"]);

                completedSeries.Points.AddXY(weekLabel, completed);
                totalSeries.Points.AddXY(weekLabel, total);
            }

            chart.Series.Add(completedSeries);
            chart.Series.Add(totalSeries);
            chart.Titles.Add("每周刷题进度");

            // 配置坐标轴
            chartArea.AxisX.Title = "周";
            chartArea.AxisY.Title = "题目数量";
            chartArea.AxisX.Interval = 1;
        }
        private void InitializeRankingTab(TabPage tabPage)
        {





            // 下方：排行榜图表
            var chart = new Chart { Dock = DockStyle.Fill };
            splitContainer3.Panel2.Controls.Add(chart);
            InitializeRankingChart(chart);

            // 加载排行榜数据
            var sql = @"
            SELECT 
                s.StuID,
                s.StuName,
                COUNT(sp.problem_id) AS TotalAttempted,
                SUM(CASE WHEN sp.IsCompleted = 1 THEN 1 ELSE 0 END) AS CompletedCount,
                RANK() OVER (ORDER BY SUM(CASE WHEN sp.IsCompleted = 1 THEN 1 ELSE 0 END) DESC) AS Rank
            FROM tblStuinfo s
            LEFT JOIN StudentProblem sp ON s.StuID = sp.StuID
            GROUP BY s.StuID, s.StuName
            ORDER BY CompletedCount DESC";

            var dt = _sqlHelper.ExecuteQuery(sql);
            dataGridView2.DataSource = dt;

            // 高亮当前用户
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["StuID"].Value != null && row.Cells["StuID"].Value.ToString() == _currentStudentId.ToString())
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }
        private void InitializeRankingChart(Chart chart)
        {
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series
            {
                ChartType = SeriesChartType.Column,
                Name = "已完成题目数",
                Color = Color.SteelBlue
            };

            // 获取排行榜数据
            var sql = @"
            SELECT TOP 10
                s.StuName,
                SUM(CASE WHEN sp.IsCompleted = 1 THEN 1 ELSE 0 END) AS CompletedCount
            FROM tblStuinfo s
            LEFT JOIN StudentProblem sp ON s.StuID = sp.StuID
            GROUP BY s.StuID, s.StuName
            ORDER BY CompletedCount DESC";

            var dt = _sqlHelper.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    row["StuName"].ToString(),
                    Convert.ToInt32(row["CompletedCount"])
                );
            }

            chart.Series.Add(series);
            chart.Titles.Add("排行榜 TOP 10");

            // 配置坐标轴
            chartArea.AxisX.Title = "学生";
            chartArea.AxisY.Title = "已完成题目数";
            chartArea.AxisX.Interval = 1;
        }
        private void InitializeAIProblemsTab()
        {
            dataGridViewAIProblems2.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "AIProblemID", Width = 200 },
            new DataGridViewTextBoxColumn { HeaderText = "标题", DataPropertyName = "title", Width = 300 },
            new DataGridViewTextBoxColumn { HeaderText = "难度", DataPropertyName = "difficulty", Width = 80 },
            new DataGridViewButtonColumn { HeaderText = "查看详情", Text = "查看", UseColumnTextForButtonValue = true, Width = 100 }
        );
            // 加载数据
            LoadAIProblems();
            // 添加点击事件
            dataGridViewAIProblems2.CellClick += DataGridViewAIProblems2_CellClick;
        }
        private void LoadAIProblems()
        {
            var sql = @"
            SELECT AIProblemID, title, difficulty, content
            FROM AIProblem
            WHERE stuID = @stuID
            ORDER BY id DESC";

            var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@stuID", _currentStudentId));
            dataGridViewAIProblems2.DataSource = dt;
        }
        private void DataGridViewAIProblems2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 如果是"查看详情"按钮被点击
            if (dataGridViewAIProblems2.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                // 使用列索引而不是列名
                string problemId = dataGridViewAIProblems2.Rows[e.RowIndex].Cells[0].Value.ToString(); // 第一列是AIProblemID
                string content = dataGridViewAIProblems2.Rows[e.RowIndex].Cells["content"].Value?.ToString();


                // 显示题目详情
                ShowAIProblemDetail(problemId, content);
            }
        }
        private void ShowAIProblemDetail(string problemId, string content)
        {
            var detailForm = new Form
            {
                Text = $"AI题目详情 - {problemId}",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterParent
            };

            var textBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Text = content,
                ReadOnly = true,
                Font = new Font("Consolas", 10) // 使用等宽字体更好看
            };

            detailForm.Controls.Add(textBox);
            detailForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
