using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinForms_singleselection
{
    public partial class FormSpiderQqmusic : Form
    {
        private readonly HttpClient _httpClient;
        private BindingList<SongInfo> _searchResults = new BindingList<SongInfo>();
        private BackgroundWorker _searchWorker;
        private BackgroundWorker _commentWorker;
        public FormSpiderQqmusic()
        {
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.GZip
            };

            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Referer", "https://y.qq.com/");
            _httpClient.DefaultRequestHeaders.Add("Origin", "https://y.qq.com");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Cookie",
    "qqmusic_key=W_X_63B0a8jfC_pixBRa-M2KQ3hKYMTSEES8KdSvd-ktIJ-t3vraMVCeDFUbew1hR_uC-512Q6cv8SsrwnLxvd1d83-hbtZr08w; " +
    "wxuin=1152921504655784414; " +
    "wxopenid=opCFJw8Qyq7TWl00j5hw8dIuCTRA; " +
    "euin=oK6kowEAoK4z7eCk7KSF7ev57n**; " +
    "tmeLoginType=1; " +
    "login_type=2");
            InitializeComponent();
            InitializeBackgroundWorkers();
            InitializeDataGridView();
        }
        
        private void InitializeBackgroundWorkers()
        {
            // 搜索后台 worker
            _searchWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            _searchWorker.DoWork += SearchWorker_DoWork;
            _searchWorker.ProgressChanged += Worker_ProgressChanged;
            _searchWorker.RunWorkerCompleted += SearchWorker_RunWorkerCompleted;

            // 评论后台 worker
            _commentWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            _commentWorker.DoWork += CommentWorker_DoWork;
            _commentWorker.ProgressChanged += Worker_ProgressChanged;
            _commentWorker.RunWorkerCompleted += CommentWorker_RunWorkerCompleted;
        }
        private void InitializeDataGridView()
        {
            // 设置 DataGridView
            dgvSearchResults.AutoGenerateColumns = false;
            dgvSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchResults.MultiSelect = false;
            dgvSearchResults.DataSource = _searchResults;

            // 添加列
            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SongName",
                HeaderText = "歌曲名",
                Width = 150
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Singer",
                HeaderText = "歌手",
                Width = 120
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Album",
                HeaderText = "专辑",
                Width = 150
            });

            dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SongId",
                HeaderText = "歌曲ID",
                Width = 80,
                Visible = false // 隐藏ID列，仅用于后台使用
            });

            // 绑定选择事件
            dgvSearchResults.SelectionChanged += DgvSearchResults_SelectionChanged;
        }
        #region 搜索功能
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键词");
                return;
            }

            // 禁用控件
            SetControlsEnabled(false);

            // 重置进度条
            progressBar.Value = 0;
            lblStatus.Text = "正在搜索...";

            // 开始后台搜索
            _searchWorker.RunWorkerAsync(keyword);
        }

        private void SearchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string keyword = e.Argument as string;
            _searchWorker.ReportProgress(10, "正在连接QQ音乐服务器...");

            try
            {
                string url = $"https://c.y.qq.com/soso/fcgi-bin/client_search_cp?ct=24&qqmusic_ver=1298&new_json=1&remoteplace=txt.yqq.song&searchid=&t=0&aggr=1&cr=1&catZhida=1&lossless=0&flag_qc=0&p=1&n=20&w={Uri.EscapeDataString(keyword)}&g_tk=5381&loginUin=0&hostUin=0&format=json&inCharset=utf8&outCharset=utf-8&notice=0&platform=yqq.json&needNewCode=0";

                _searchWorker.ReportProgress(30, "正在获取搜索结果...");
                var response = _httpClient.GetStringAsync(url).Result;

                _searchWorker.ReportProgress(70, "正在解析数据...");
                var results = ParseSearchResults(response);

                // 更新结果
                this.Invoke(new Action(() =>
                {
                    _searchResults.Clear();
                    foreach (var item in results)
                    {
                        _searchResults.Add(item);
                    }
                }));

                _searchWorker.ReportProgress(100, "搜索完成");
            }
            catch (Exception ex)
            {
                _searchWorker.ReportProgress(0, $"搜索失败: {ex.Message}");
                e.Result = ex;
            }
        }
        private void SearchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null || e.Result is Exception)
            {
                MessageBox.Show($"搜索过程中发生错误: {(e.Error ?? e.Result as Exception)?.Message}");
            }

            SetControlsEnabled(true);
        }
        #endregion
        #region 评论功能
        private void btnFetchComments_Click(object sender, EventArgs e)
        {
            string songId = txtSongId.Text.Trim();
            if (string.IsNullOrEmpty(songId))
            {
                MessageBox.Show("请先选择歌曲或输入歌曲ID");
                return;
            }

            // 禁用控件
            SetControlsEnabled(false);

            // 重置进度条
            progressBar.Value = 0;
            lblStatus.Text = "正在获取评论...";
            lstComments.Items.Clear();

            // 开始后台获取评论
            _commentWorker.RunWorkerAsync(songId);
        }
        private void CommentWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string songId = e.Argument as string;
            _commentWorker.ReportProgress(10, "正在连接QQ音乐评论接口...");

            try
            {
                string url = $"https://c.y.qq.com/base/fcgi-bin/fcg_global_comment_h5.fcg?g_tk=5381&loginUin=0&hostUin=0&format=json&inCharset=utf8&outCharset=utf-8&notice=0&platform=yqq.json&needNewCode=0&cid=205360772&reqtype=2&biztype=1&topid={songId}&cmd=8&needmusiccrit=0&pagenum=0&pagesize=25&lasthotcommentid=&domain=qq.com&ct=24&cv=10101010";

                _commentWorker.ReportProgress(30, "正在获取评论数据...");
                var response = _httpClient.GetStringAsync(url).Result;

                _commentWorker.ReportProgress(70, "正在解析评论...");
                var comments = ParseComments(response);

                // 更新UI
                this.Invoke(new Action(() =>
                {
                    lstComments.Items.Clear();
                    foreach (var comment in comments)
                    {
                        lstComments.Items.Add($"{comment.Nickname}: {comment.Content} (点赞: {comment.LikeCount})");
                    }
                }));

                _commentWorker.ReportProgress(100, "评论加载完成");
            }
            catch (Exception ex)
            {
                _commentWorker.ReportProgress(0, $"获取评论失败: {ex.Message}");
                e.Result = ex;
            }
        }
        private void CommentWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null || e.Result is Exception)
            {
                MessageBox.Show($"获取评论过程中发生错误: {(e.Error ?? e.Result as Exception)?.Message}");
            }

            SetControlsEnabled(true);
        }
        #endregion
        #region 辅助方法
        private List<SongInfo> ParseSearchResults(string json)
        {
            var results = new List<SongInfo>();

            try
            {
                var jsonObj = JObject.Parse(json);
                var songList = jsonObj["data"]["song"]["list"] as JArray;

                if (songList != null)
                {
                    foreach (var item in songList)
                    {
                        // 处理多个歌手的情况
                        string singers = "";
                        var singerArray = item["singer"] as JArray;
                        if (singerArray != null)
                        {
                            foreach (var singer in singerArray)
                            {
                                if (!string.IsNullOrEmpty(singers))
                                    singers += "/";
                                singers += singer["name"].ToString();
                            }
                        }

                        results.Add(new SongInfo
                        {
                            SongId = item["id"].ToString(),
                            SongName = item["title"].ToString(),
                            Singer = singers,
                            Album = item["album"]["name"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("解析搜索结果失败", ex);
            }

            return results;
        }
        private List<MusicComment> ParseComments(string json)
        {
            var comments = new List<MusicComment>();

            try
            {
                var jsonObj = JObject.Parse(json);
                var commentList = jsonObj["comment"]["commentlist"] as JArray;

                if (commentList != null)
                {
                    foreach (var item in commentList)
                    {
                        comments.Add(new MusicComment
                        {
                            Nickname = item["nick"].ToString(),
                            Content = item["rootcommentcontent"].ToString(),
                            LikeCount = Convert.ToInt32(item["praisenum"]),
                            Time = item["time"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("解析评论失败", ex);
            }

            return comments;
        }
        private void DgvSearchResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSearchResults.SelectedRows[0];
                var songInfo = selectedRow.DataBoundItem as SongInfo;

                if (songInfo != null)
                {
                    txtSongId.Text = songInfo.SongId;
                    lblSelectedSong.Text = $"{songInfo.SongName} - {songInfo.Singer}";
                }
            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                lblStatus.Text = e.UserState.ToString();
            }
        }
        private void SetControlsEnabled(bool enabled)
        {
            txtSearchKeyword.Enabled = enabled;
            btnSearch.Enabled = enabled;
            dgvSearchResults.Enabled = enabled;
            txtSongId.Enabled = enabled;
            btnFetchComments.Enabled = enabled;
        }
        #endregion

    }
    public class SongInfo
    {
        public string SongId { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
    }

    public class MusicComment
    {
        public string Nickname { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public string Time { get; set; }
    }
}
