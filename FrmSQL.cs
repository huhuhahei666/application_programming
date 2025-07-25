using Microsoft.VisualBasic;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms_singleselection
{
    public partial class FrmSQL : Form
    {
        string msg = string.Empty;
        SQLHelper sh;
        string base_sql = "select studentno as 学号, studentname as 学生姓名, major as 专业 from tblTopStudents where 1=1";
        /// <summary>
        /// 构造函数往往放置一些初始化的工作
        /// </summary>
        public FrmSQL()
        {
            InitializeComponent();
            sh = new SQLHelper("Data Source=.;Initial Catalog=tblStudents;Integrated Security=True"); //数据库链接对象初始化
        }
        private string currentStudentNo = ""; // 当前选中的学号
        private string currentImagePath = ""; // 当前头像路径
        private void btnLink_Click(object sender, EventArgs e)
        {

            string sql = "select count(*) from tblstudents"; //该SQL意思是，获取tblstudents的行数
            try
            {
                string? num = sh.RunSelectSQLToScalar(sql);  //一般运行查询语句
                msg = string.Format("我们班共有{0}个同学!", num);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                sh.Close();
            }
            MessageBox.Show(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentnumber = Interaction.InputBox("打卡", "请输入打卡的学号，默认是自己", "10130212110");
            try
            {
                //string studentnumber = "10130212110";
                string sql = string.Format("insert into tblStudentAbsent(studentNumber)values('{0}')", studentnumber);
                int ret = sh.RunSQL(sql); //一般运行 查询之外的删、改、增
                msg = string.Format("打卡成功");
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                sh.Close();
            }
            MessageBox.Show(msg);
        }
        /// <summary>
        /// 在初始化之后，内存中加载窗体的时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSQL_Load(object sender, EventArgs e)
        {

            bindData(base_sql);  //把数据绑定到datagridview
            initCombox(); //初始化combobox
            // 初始化 ImageList
            ImageList imgList = new ImageList();
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageSize = new Size(32, 32); // 图片大小

            // 加载图片到 ImageList
            imgList.Images.Add(Image.FromFile(@"C:\consoleApp\images\boy.png"));
            imgList.Images.Add(Image.FromFile(@"C:\consoleApp\images\girl.png"));

            // 关联 ImageList 到 ListView
            listView2.SmallImageList = imgList;
            listView2.LargeImageList = imgList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = base_sql;
            string major = cboMajor.Text;
            string name = txtStuName.Text;
            // 无论专业是否"全部显示"，都应用姓名筛选
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" AND studentname LIKE '%{name}%'";
            }

            // 如果选了具体专业，再添加专业条件
            if (cboMajor.Text != "全部显示" && !string.IsNullOrEmpty(major))
            {
                sql += $" AND major = '{major}'";
            }

            bindData(sql); // 重新绑定数据

            bindData(sql);
        }
        /// <summary>
        /// 给我传递一个SQL命令，我来绑定数据到datagridview
        /// </summary>
        /// <param name="sql">传递过来的SQL命令</param>
        private void bindData(string sql)
        {
            //数据集 mini的database
            DataSet ds = new DataSet();

            try
            {
                // 函数名一样，参数不一样，这在OO里面叫重载 overload
                sh.RunSQL(sql, ref ds);
                //1个dataset包含落干个datatable
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                lblCount.Text = string.Format("共有{0}个同学", dt.Rows.Count);
                //dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }

        }
        /// <summary>
        /// 用tbltopstudents里面的major来初始化这个combox
        /// </summary>
        private void initCombox()
        {
            string sql = "SELECT DISTINCT major FROM tblTopStudents";
            DataSet ds = new DataSet();

            try
            {
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                dt.Rows.Add("全部显示");
                // 绑定DataTable到ComboBox
                cboMajor.DataSource = dt;
                cboMajor.DisplayMember = "Major";
                // 如果你想将某个列作为值成员，可以这样设置：
                cboMajor.ValueMember = "Major";
                cboMajor.Text = "全部显示";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

            bindData(base_sql);  //把数据绑定到datagridview

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 如果点击的是表头，忽略
                                        // 打印所有列名（调试用）
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                Debug.WriteLine($"列名: {column.Name}, 标题: {column.HeaderText}");
            }

            // 获取选中的行
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // 提取学号（假设 DataGridView 的列名是 studentno）
            currentStudentNo = row.Cells["学号"].Value?.ToString() ?? "";

            if (string.IsNullOrEmpty(currentStudentNo))
            {
                MessageBox.Show("未找到学号信息！");
                return;
            }

            // 查询该学生的详细信息
            string sql = $"SELECT studentno, studentname, major, gender FROM tblTopStudents WHERE studentno = '{currentStudentNo}'";
            DataSet ds = new DataSet();

            try
            {
                sh.RunSQL(sql, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow student = ds.Tables[0].Rows[0];

                    // 显示学生信息
                    txtStudentNo.Text = student["studentno"].ToString();
                    txtStudentName.Text = student["studentname"].ToString();
                    txtMajor.Text = student["major"].ToString();

                    // 根据性别加载头像
                    bool isMale = Convert.ToBoolean(student["gender"]);
                    string imagePath = isMale
                        ? @"C:\consoleApp\images\boy.png"
                        : @"C:\consoleApp\images\girl.png";
                    picStudent.Image = Image.FromFile(imagePath);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载学生信息失败: " + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
                btnAlert.Text = "停止报警";
            else
                btnAlert.Text = "开始报警";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SearchStu();
        }
        private void SearchStu()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            string sql = "SELECT studentno,STUDENTNAME,gender FROM tblTopStudents\r\nWHERE studentNo NOT IN\r\n(\r\nselect STUDENTNUMBER from tblStudentAbsent where DATEDIFF(DAY,dtedate,GETDATE())=0\r\n)\r\n";
            DataSet ds = new DataSet();
            try
            {

                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                bindImgTolist(dt);
                StringBuilder tmp = new StringBuilder();
                foreach (DataRow stu in dt.Rows)
                {
                    tmp.Append(string.Format("学号:{0},姓名:{1}", stu[0], stu[1]));
                    listView1.Items.Add(tmp.ToString());
                }
                //MessageBox.Show(tmp.ToString());
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }
        }
        private void bindImgTolist(DataTable dt)
        {

            foreach (DataRow stu in dt.Rows)
            {
                ListViewItem item1 = new ListViewItem(stu[1].ToString());
                if (stu[2].ToString() == "True")
                    item1.ImageIndex = 0; // 设置为 ImageList 中第一张图片
                else
                    item1.ImageIndex = 1; // 设置为 ImageList 中第一张图片
                listView2.Items.Add(item1);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentStudentNo))
            {
                MessageBox.Show("请先选择学生！");
                return;
            }

            try
            {
                // 更新数据库（不修改头像）
                string sql = $@"
            UPDATE tblTopStudents 
            SET 
                studentname = '{txtStudentName.Text}',
                major = '{txtMajor.Text}'
            WHERE studentno = '{currentStudentNo}'";

                int rowsAffected = sh.RunSQL(sql);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("更新成功！");
                    bindData(base_sql); // 刷新 DataGridView
                }
                else
                {
                    MessageBox.Show("更新失败，学生不存在！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败: " + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentNo.Text))
            {
                MessageBox.Show("请先选择一个学生");
                return;
            }
            if (txtNewPwd.Text.Length < 6)  //检测密码强度，大模型求助
            {
                MessageBox.Show("密码长度不能小于6位");
                return;
            }
            if (txtNewPwd.Text != txtConfirmPwd.Text)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }
            // 创建哈希密码
            string password = txtNewPwd.Text;
            string salt;
            string hash = PasswordHelper.CreateHash(password, out salt); //不可逆哈希
            try
            {

                string sql = string.Format(@"update tblTopStudents
set pwd='{0}', salt='{1}' 
where studentNo='{2}'", hash, salt, txtStudentNo.Text);
                int ret = sh.RunSQL(sql); //一般运行 查询之外的删、改、增
                msg = string.Format("重置密码成功！");

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                sh.Close();
            }
            MessageBox.Show(msg);
        }

       
    }
}
