using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace WinForms_singleselection
{
    public partial class FormDouban : Form
    {
        // 存储搜索结果的详情链接（用于后续加载详情）
        private string[] _detailUrls;
        public FormDouban()
        {
            InitializeComponent();
           
            comboBoxType.SelectedIndex = 0; // 默认选中书籍
        }
        // The error indicates that the `HtmlWeb` class does not have a `CookieContainer` property or method.
        // To fix this, you need to remove the line that attempts to set `CookieContainer` on `HtmlWeb`.
        // Instead, you can use the `PreRequest` delegate to add cookies to the request.

        private HtmlAgilityPack.HtmlDocument GetHtmlDocument(string url)
        {
            try
            {
                var web = new HtmlWeb();
                // 设置UserAgent
                web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";

                // 使用PreRequest来添加Cookie
                web.PreRequest = request =>
                {
                    request.Headers.Add("Cookie", "dbcl2=\"288024676:UvCXk5ztbkU\"");
                    return true;
                };

                // 添加随机延迟避免被封
                System.Threading.Thread.Sleep(new Random().Next(1000, 3000));

                return web.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"请求失败: {ex.Message}");
                return null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 输入验证
            if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("请选择查询类型（书籍/电影）");
                return;
            }
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键词");
                return;
            }

            // 清空之前的结果
            listViewResults.Items.Clear();
            ClearDetailFields();

            // 根据选择的类型执行搜索
            if (comboBoxType.Text == "电影")
            {
                SearchMovies(keyword);
            }
            else
            {
                SearchBooks(keyword);
            }
        }
        // 清空详情字段
        private void ClearDetailFields()
        {
            txtTitle.Text = "";
            txtRating.Text = "";
            txtRatingCount.Text = "";
            txtPubInfo.Text = "";
            txtIntro.Text = "";
            linkLabelUrl.Text = "";
            linkLabelUrl.Links.Clear();
        }
        private void SearchMovies(string keyword)
        {
            // 构建搜索URL（编码关键词）
            string encodedKeyword = Uri.EscapeDataString(keyword);
            string searchUrl = $"https://movie.douban.com/subject_search?search_text={encodedKeyword}&cat=1002";

            HtmlAgilityPack.HtmlDocument doc = GetHtmlDocument(searchUrl);
            if (doc == null) return;

            // 解析搜索结果列表（XPath根据豆瓣最新页面结构调整）
            var resultNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'item-root')]");
            if (resultNodes == null)
            {
                MessageBox.Show("未找到相关电影");
                return;
            }

            // 存储详情页链接
            _detailUrls = new string[resultNodes.Count];

            // 遍历结果节点
            for (int i = 0; i < resultNodes.Count; i++)
            {
                var node = resultNodes[i];

                // 提取标题
                var titleNode = node.SelectSingleNode(".//a[contains(@href, '/subject/')]");
                string title = titleNode?.InnerText.Trim() ?? "未知标题";

                // 提取评分
                var ratingNode = node.SelectSingleNode(".//span[contains(@class, 'rating_num')]");
                string rating = ratingNode?.InnerText.Trim() ?? "暂无评分";

                // 提取评价人数
                var countNode = node.SelectSingleNode(".//span[contains(text(), '人评价')]");
                string count = countNode?.InnerText.Trim() ?? "0人评价";

                // 提取详情页链接
                string detailUrl = titleNode?.Attributes["href"]?.Value ?? "";
                _detailUrls[i] = detailUrl;

                // 添加到ListView
                ListViewItem item = new ListViewItem(title);
                item.SubItems.Add(rating);
                item.SubItems.Add(count);
                listViewResults.Items.Add(item);
            }
        }
        private void SearchBooks(string keyword)
        {
            // 构建书籍搜索URL
            string encodedKeyword = Uri.EscapeDataString(keyword);
            string searchUrl = $"https://book.douban.com/subject_search?search_text={encodedKeyword}&cat=1001";

            HtmlAgilityPack.HtmlDocument doc = GetHtmlDocument(searchUrl);
            if (doc == null) return;

            // 解析书籍搜索结果
            var resultNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'item-root') and .//a[contains(@href, '/subject/')]]");
            if (resultNodes == null)
            {
                MessageBox.Show("未找到相关书籍");
                return;
            }

            // 存储详情页链接
            _detailUrls = new string[resultNodes.Count];

            // 遍历结果节点
            for (int i = 0; i < resultNodes.Count; i++)
            {
                var node = resultNodes[i];

                // 提取标题
                var titleNode = node.SelectSingleNode(".//a[contains(@href, '/subject/')]");
                string title = titleNode?.InnerText.Trim() ?? "未知书名";

                // 提取评分
                var ratingNode = node.SelectSingleNode(".//span[contains(@class, 'rating_num')]");
                string rating = ratingNode?.InnerText.Trim() ?? "暂无评分";

                // 提取评价人数
                var countNode = node.SelectSingleNode(".//span[contains(text(), '人评价')]");
                string count = countNode?.InnerText.Trim() ?? "0人评价";

                // 提取详情页链接
                string detailUrl = titleNode?.Attributes["href"]?.Value ?? "";
                _detailUrls[i] = detailUrl;

                // 添加到ListView
                ListViewItem item = new ListViewItem(title);
                item.SubItems.Add(rating);
                item.SubItems.Add(count);
                listViewResults.Items.Add(item);
            }
        }
        private void listViewResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count == 0) return;

            int selectedIndex = listViewResults.SelectedIndices[0];
            string detailUrl = _detailUrls?[selectedIndex];
            if (string.IsNullOrEmpty(detailUrl)) return;

            // 根据类型加载详情
            if (comboBoxType.Text == "电影")
            {
                LoadMovieDetail(detailUrl);
            }
            else
            {
                LoadBookDetail(detailUrl);
            }
        }
        private void LoadMovieDetail(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = GetHtmlDocument(url);
            if (doc == null) return;

            // 标题
            var titleNode = doc.DocumentNode.SelectSingleNode("//h1/span[@property='v:itemreviewed']");
            txtTitle.Text = titleNode?.InnerText.Trim() ?? "";

            // 评分
            var ratingNode = doc.DocumentNode.SelectSingleNode("//strong[@class='ll rating_num']");
            txtRating.Text = ratingNode?.InnerText.Trim() ?? "暂无评分";

            // 评价人数
            var countNode = doc.DocumentNode.SelectSingleNode("//a[@class='rating_people']/span");
            txtRatingCount.Text = countNode?.InnerText.Trim() ?? "0人评价";

            // 上映信息（导演、主演、类型、上映日期等）
            var infoNode = doc.DocumentNode.SelectSingleNode("//div[@id='info']");
            string pubInfo = "";
            if (infoNode != null)
            {
                // 清理多余空格和空行
                pubInfo = Regex.Replace(infoNode.InnerText.Trim(), @"\s+", " ");
            }
            txtPubInfo.Text = pubInfo;

            // 简介
            var introNode = doc.DocumentNode.SelectSingleNode("//div[@class='indent']//span[@property='v:summary']");
            txtIntro.Text = introNode?.InnerText.Trim() ?? "暂无简介";

            // 详情页链接
            linkLabelUrl.Text = url;
            linkLabelUrl.Links.Clear();
            linkLabelUrl.Links.Add(0, url.Length, url);
        }
        private void LoadBookDetail(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = GetHtmlDocument(url);
            if (doc == null) return;

            // 标题
            var titleNode = doc.DocumentNode.SelectSingleNode("//h1/span");
            txtTitle.Text = titleNode?.InnerText.Trim() ?? "";

            // 评分
            var ratingNode = doc.DocumentNode.SelectSingleNode("//strong[@class='ll rating_num']");
            txtRating.Text = ratingNode?.InnerText.Trim() ?? "暂无评分";

            // 评价人数
            var countNode = doc.DocumentNode.SelectSingleNode("//a[@class='rating_people']/span");
            txtRatingCount.Text = countNode?.InnerText.Trim() ?? "0人评价";

            // 出版信息（作者、出版社、出版日期、页数等）
            var infoNode = doc.DocumentNode.SelectSingleNode("//div[@id='info']");
            string pubInfo = "";
            if (infoNode != null)
            {
                pubInfo = Regex.Replace(infoNode.InnerText.Trim(), @"\s+", " ");
            }
            txtPubInfo.Text = pubInfo;

            // 简介
            var introNode = doc.DocumentNode.SelectSingleNode("//div[@class='intro']");
            if (introNode == null)
            {
                // 备选XPath（处理不同页面结构）
                introNode = doc.DocumentNode.SelectSingleNode("//div[@id='link-report']//div[@class='indent']");
            }
            txtIntro.Text = introNode?.InnerText.Trim() ?? "暂无简介";

            // 详情页链接
            linkLabelUrl.Text = url;
            linkLabelUrl.Links.Clear();
            linkLabelUrl.Links.Add(0, url.Length, url);
        }
        private void linkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData != null)
            {
                string url = e.Link.LinkData.ToString();
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"无法打开链接：{ex.Message}");
                }
            }
        }
        

    }
}
