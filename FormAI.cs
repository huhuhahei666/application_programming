using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_singleselection
{
    public partial class FormAI : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string _sessionId = Guid.NewGuid().ToString();  // 维持会话ID
        private CancellationTokenSource _loadingCts;
        private SQLHelper _sqlHelper;
        private int _currentStudentId;
        private string _currentStudentName;
        private LeetCodeProblem2 _currentGeneratedProblem;
        public FormAI(SQLHelper sqlHelper, int studentId = -1, string studentName = "")
        {
            InitializeComponent();
            
            _sqlHelper = sqlHelper;
            _currentStudentId = studentId;
            _currentStudentName = studentName;
            progressBar.Style = ProgressBarStyle.Marquee; // 流动式进度条
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;
            lblStatus.Text = "准备就绪";
            lblStatus.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text.Trim();
            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("请输入问题");
                return;
            }
            _loadingCts?.Cancel();
            _loadingCts = new CancellationTokenSource();
            try
            {
                // 显示加载状态
                // 启动10秒自动完成的加载状态
                StartLoadingAnimation(_loadingCts.Token);
                button1.Enabled = false;
                txtAnswer.AppendText($"你: {question}\r\n");
                txtAnswer.AppendText("星火: ");

                var request = new
                {
                    question = question,
                    session_id = _sessionId
                };

                string json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://localhost:5000/chat", content);
                string responseJson = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseJson);
                txtAnswer.AppendText(result.answer.ToString() + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtAnswer.AppendText($"错误: {ex.Message}\r\n");
            }
            finally
            {
                button1.Enabled = true;
            }
        }


        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            txtAnswer.Clear();

        }
        private void SetLoadingState(bool isLoading, string message = "")
        {
            this.SafeInvoke(() =>
            {
                progressBar.Visible = isLoading;
                lblStatus.Visible = isLoading;
                lblStatus.Text = message;
                this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;

                if (!isLoading)
                {
                    progressBar.Style = ProgressBarStyle.Continuous;
                    progressBar.Value = 100;
                    lblStatus.Text = "加载完成✅";
                }
            });
        }

        private async void StartLoadingAnimation(CancellationToken token)
        {
            this.SafeInvoke(() =>
            {
                progressBar.Visible = true;
                lblStatus.Visible = true;
                lblStatus.Text = "正在处理请求...";
                progressBar.Value = 0;
                Cursor = Cursors.WaitCursor;
            });

            try
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    token.ThrowIfCancellationRequested();

                    this.SafeInvoke(() =>
                    {
                        progressBar.Value = i;
                        lblStatus.Text = $"正在处理请求... ";
                    });

                    await Task.Delay(8000, token);
                }

                this.SafeInvoke(() =>
                {
                    progressBar.Value = 100;
                    lblStatus.Text = "加载完成✅";
                    Cursor = Cursors.Default;

                    Task.Delay(2000).ContinueWith(_ =>
                    {
                        this.SafeInvoke(() =>
                        {
                            progressBar.Visible = false;
                            lblStatus.Visible = false;
                        });
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                });
            }
            catch (OperationCanceledException)
            {
                // 取消时恢复UI状态
                this.SafeInvoke(() =>
                {
                    progressBar.Value = 0;
                    lblStatus.Text = "操作已取消";
                    Cursor = Cursors.Default;
                });
            }
            catch (ObjectDisposedException)
            {
                // 窗体已关闭，无需处理
            }
            finally
            {
                // 统一使用SafeInvoke
                this.SafeInvoke(() =>
                {
                    if (!token.IsCancellationRequested)
                    {
                        progressBar.Value = 100;
                        lblStatus.Text = "加载完成✅";
                        Cursor = Cursors.Default;

                        Task.Delay(2000).ContinueWith(_ =>
                        {
                            this.SafeInvoke(() =>
                            {
                                progressBar.Visible = false;
                                lblStatus.Visible = false;
                            });
                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                });
            }
        }
        private void StopLoadingAnimation()
        {
            this.SafeInvoke(() =>
            {
                // 停止进度条动画
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 100;
                progressBar.Visible = false;

                // 更新状态标签
                lblStatus.Text = "加载完成";

                // 延迟2秒后隐藏状态标签
                Task.Delay(2000).ContinueWith(_ =>
                {
                    this.SafeInvoke(() =>
                    {
                        lblStatus.Visible = false;
                        this.Cursor = Cursors.Default;
                    });
                }, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        private async void btnRecommend_Click(object sender, EventArgs e)
        {
            try
            {
                StartLoadingAnimation(CancellationToken.None);
                button1.Enabled = false;

                // 获取用户做题历史作为上下文
                var history = GetUserProblemHistory();

                var request = new
                {
                    action = "recommend",
                    history = history,
                    session_id = _sessionId
                };

                string json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://localhost:5000/chat", content);
                string responseJson = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseJson);
                txtAnswer.AppendText($"【AI推荐题目】\r\n{result.answer.ToString()}\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtAnswer.AppendText($"推荐失败: {ex.Message}\r\n");
            }
            finally
            {
                button1.Enabled = true;
                StopLoadingAnimation();
            }
        }

        private async void btnGenerateByTag_Click(object sender, EventArgs e)
        {
            // 创建标签选择对话框
            var tagForm = new FormTagSelection();
            if (tagForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StartLoadingAnimation(CancellationToken.None);
                    button1.Enabled = false;

                    var request = new
                    {
                        action = "generate_by_tag",
                        difficulty = tagForm.SelectedDifficulty,
                        algorithm_type = tagForm.SelectedAlgorithmType,
                        session_id = _sessionId
                    };

                    string json = JsonConvert.SerializeObject(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync("http://localhost:5000/chat", content);
                    string responseJson = await response.Content.ReadAsStringAsync();

                    dynamic result = JsonConvert.DeserializeObject(responseJson);
                    string problemContent = result.answer.ToString();
                    txtAnswer.AppendText($"【AI生成题目 - {tagForm.SelectedDifficulty}/{tagForm.SelectedAlgorithmType}】\r\n{result.answer.ToString()}\r\n\r\n");
                    // 新增：解析并保存生成的题目
                    _currentGeneratedProblem = ParseGeneratedProblem(problemContent);
                    btnAddToLibrary.Enabled = _currentGeneratedProblem != null;
                }
                catch (Exception ex)
                {
                    txtAnswer.AppendText($"生成失败: {ex.Message}\r\n");
                }
                finally
                {
                    button1.Enabled = true;
                    StopLoadingAnimation();
                }
            }
        }
        private List<ProblemHistory> GetUserProblemHistory()
        {
            var history = new List<ProblemHistory>();
            if (_currentStudentId <= 0) return history;

            var sql = @"
                SELECT p.problem_id, p.title, p.difficulty, p.Acceptance, 
                       sp.IsCompleted, sp.LastAttemptTime, sp.AttemptCount
                FROM StudentProblem sp
                JOIN Problems p ON sp.problem_id = p.problem_id
                WHERE sp.StuID = @StuID
                ORDER BY sp.LastAttemptTime DESC";

            var dt = _sqlHelper.ExecuteQuery(sql, new SqlParameter("@StuID", _currentStudentId));

            foreach (DataRow row in dt.Rows)
            {
                history.Add(new ProblemHistory
                {
                    ProblemId = row["problem_id"]?.ToString() ?? "未知ID", // 处理可能的 NULL
                    Title = row["title"]?.ToString() ?? "未知题目",      // 处理可能的 NULL
                    Difficulty = row["difficulty"]?.ToString() ?? "未知难度", // 处理可能的 NULL
                    IsCompleted = row["IsCompleted"] != DBNull.Value && Convert.ToBoolean(row["IsCompleted"]), // 检查 NULL 再转换
                    AttemptCount = row["AttemptCount"] != DBNull.Value ? Convert.ToInt32(row["AttemptCount"]) : 0 // 检查 NULL 再转换
                });
            }

            return history;
        }
        private void SaveProblemToStudentLibrary(LeetCodeProblem2 problem)
        {
            if (_currentStudentId <= 0)
            {
                MessageBox.Show("请先登录再保存题目", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 直接插入到AIProblem表
                string insertSql = @"
            INSERT INTO AIProblem 
            (stuID, AIProblemID, title, content, difficulty)
            VALUES 
            (@stuID, @AIProblemID, @title, @content, @difficulty)";

                _sqlHelper.ExecuteNonQuery(insertSql,
                    new SqlParameter("@stuID", _currentStudentId),
                    new SqlParameter("@AIProblemID", problem.Id),
                    new SqlParameter("@title", problem.Title),
                    new SqlParameter("@content", problem.Content), // 存储完整内容
                    new SqlParameter("@difficulty", problem.Difficulty));

                MessageBox.Show($"题目【{problem.Title}】已成功加入AI题库", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存题目失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddToLibrary_Click(object sender, EventArgs e)
        {
            if (_currentGeneratedProblem == null)
            {
                MessageBox.Show("没有可保存的题目", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveProblemToStudentLibrary(_currentGeneratedProblem);
            btnAddToLibrary.Enabled = false;
        }
        private LeetCodeProblem2 ParseGeneratedProblem(string aiResponse)
        {
            try
            {
                var problem = new LeetCodeProblem2
                {
                    Id = "AI-" + Guid.NewGuid().ToString("N").Substring(0, 8), // 生成唯一ID
                    Content = aiResponse,
                    Tags = new List<string> { "AI生成" },
                    IsCompleted = false,
                    LastAttemptTime = DateTime.Now,
                    AttemptCount = 0
                };

                // 改进的解析逻辑
                var titleMatch = Regex.Match(aiResponse, @"题目名称[：:]\s*(.+?)\s*[\r\n]");
                problem.Title = titleMatch.Success ? titleMatch.Groups[1].Value.Trim() : "AI生成题目";

                var difficultyMatch = Regex.Match(aiResponse, @"难度[：:]\s*(简单|中等|困难)");
                problem.Difficulty = difficultyMatch.Success ? difficultyMatch.Groups[1].Value : "中等";


                return problem;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"解析题目失败: {ex.Message}");
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class ProblemHistory
    {
        public string ProblemId { get; set; }
        public string Title { get; set; }
        public string Difficulty { get; set; }
        public bool IsCompleted { get; set; }
        public int AttemptCount { get; set; }
    }
    
}
