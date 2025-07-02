using System.Drawing.Text;

namespace WinForms_singleselection
{
    public partial class Form1 : Form
    {
        private string[] questions =
            {
            "1.下列哪件事真的发生过？",
            "2.下列哪件商品在古代直播间会被 “禁售”？",
            "3.以下哪句话最可能是老板对员工的 PUA？",
            "4.下列哪句最符合宋代文人的 “凡尔赛”？",
            "5.以下哪条 “秦朝朋友圈” 最可能是假的？"
            };
        private string[][] options =
        {
                new string[] { "乾隆给英国使团送《孙子兵法》当国礼", "李白为杨贵妃写 “云想衣裳花想容”", "哥伦布航行时带了本《马可・波罗游记》", "以上全是真的" },
                new string[] { "唐代直播间：波斯进口的琉璃瓶", "元代直播间：景德镇青花瓷茶具", "明代直播间：玉米炒虾仁套餐", "清代直播间：机器缝制的龙袍" },
                new string[] { "秦始皇对修长城民工：“建成后给你们发‘小篆十级证书’”", "汉武帝对董仲舒：“独尊儒术可以，但得兼容百家哦”", "唐太宗对魏征：“爱卿谏言虽狠，但朕就喜欢直球”", "慈禧对维新派：“变法可以，祖宗之法不能变哦～”" },
                new string[] { "“朕刚在汴京盖了个皇家花园，也就比西湖大一点”", "唉，今天殿试又拿了榜首，状元及第好烦啊", "新买的交子居然贬值了，心疼我那二两银子", "最近和李清照姐姐组队写诗，她总让我先" },
                new string[] { "李斯：终于用小篆统一文字啦，再也不用看六国乱码了！", "某方士：帮秦始皇找仙丹中，海边蹲守 ing~", "蒙恬：刚修完长城，累成狗，求点赞换休假", "刘邦：今天斩白蛇创业，投资人项羽已打款" }
            };
        private int[] correctAnswers = { 3, 3, 0, 1, 3 }; // 正确答案索引(0-based)
        private int currentQuestionIndex = 0;
        private int score = 0;
        private RadioButton[] optionRadios;
        public Form1()
        {
            InitializeComponent();
            optionRadios = new RadioButton[] { rad1_1, rad1_2, rad1_3, rad1_4 };
            SetGreeting();
            LoadQuestion(currentQuestionIndex);

        }
        private void SetGreeting()
        {
            int currentHour = DateTime.Now.Hour;
            if (currentHour < 12)
            {
                label1.Text = "早上好，欢迎来到历史知识测试";
            }
            else if (currentHour < 18)
            {
                label1.Text = "下午好，欢迎来到历史知识测试";
            }
            else
            {
                label1.Text = "晚上好，欢迎来到历史知识测试";
            }
        }
        private void LoadQuestion(int index)
        {
            if (index >= 0 && index < questions.Length)
            {
                // 设置题目文本
                lblQuestion.Text = questions[index];

                // 设置选项文本
                for (int i = 0; i < 4; i++)
                {
                    optionRadios[i].Text = options[index][i];
                    optionRadios[i].Checked = false;
                }

                // 更新进度标签
                lblProgress.Text = $"问题 {index + 1}/{questions.Length}";

                // 重置反馈标签
                lblFeedback.Text = "";
                lblFeedback.ForeColor = Color.Black;
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 检查是否选择了选项
            int selectedOption = -1;
            for (int i = 0; i < 4; i++)
            {
                if (optionRadios[i].Checked)
                {
                    selectedOption = i;
                    break;
                }
            }

            if (selectedOption == -1)
            {
                MessageBox.Show("请选择一个选项!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 检查答案
            if (selectedOption == correctAnswers[currentQuestionIndex])
            {
                score++;
                lblFeedback.Text = "回答正确!";
                lblFeedback.ForeColor = Color.Green;
            }
            else
            {
                lblFeedback.Text = $"回答错误! 正确答案是: {options[currentQuestionIndex][correctAnswers[currentQuestionIndex]]}";
                lblFeedback.ForeColor = Color.Red;
            }

            // 更新分数显示
            lblScore.Text = $"得分: {score}/{questions.Length}";

            // 禁用提交按钮，启用下一题按钮
            btnSubmit.Enabled = false;
            btnNext.Enabled = true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            // 移动到下一题
            currentQuestionIndex++;

            if (currentQuestionIndex < questions.Length)
            {
                LoadQuestion(currentQuestionIndex);
                btnSubmit.Enabled = true;
                btnNext.Enabled = false;
            }
            else
            {
                // 测验结束
                MessageBox.Show($"测验结束! 你的最终得分是: {score}/{questions.Length}", "测验完成",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 重置测验
                currentQuestionIndex = 0;
                score = 0;
                LoadQuestion(currentQuestionIndex);
                lblScore.Text = "得分: 0";
                btnSubmit.Enabled = true;
                btnNext.Enabled = false;
            }
        }




        private void rad1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rad1_3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad1_4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad1_2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblFeedback_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
