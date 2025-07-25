using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WinForms_singleselection
{
    public partial class FrmLogin : Form
    {
        string stuNo, stuPwd;
        SQLHelper sh;
        PictureBox bgPictureBox;

        public FrmLogin()
        {
            InitializeComponent();
            sh = new SQLHelper(); //数据库链接对象初始化
            this.StartPosition = FormStartPosition.CenterScreen;
            // 设置背景图片
            InitializeBackground();

            // 美化文本框
            StyleTextBoxes();

           

            LoadAutoLoginSettings();
        }
        private void InitializeBackground()
        {
            bgPictureBox = new PictureBox();
            bgPictureBox.Dock = DockStyle.Fill;
            bgPictureBox.Image = System.Drawing.Image.FromFile("C:/consoleApp/images/背景.png"); // 替换为你的图片路径
            bgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Controls.Add(bgPictureBox);
            bgPictureBox.SendToBack();
        }

        private void StyleTextBoxes()
        {
            
            

            // 边框样式
            txtUserNo.BorderStyle = BorderStyle.FixedSingle;
            txtPwd.BorderStyle = BorderStyle.FixedSingle;
        }


        private void LoadAutoLoginSettings()
        {
            var (username, password, rememberMe) = ConfigHelper.LoadCredentials();

            txtUserNo.Text = username;
            txtPwd.Text = password;
            chkRememberMe.Checked = rememberMe;

            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            stuNo = txtUserNo.Text;
            stuPwd = txtPwd.Text;//明文


            string sql = string.Format("select pwd,salt from tblTopstudents where studentNo='{0}'", stuNo);

            try
            {
                // 函数名一样，参数不一样，这在OO里面叫重载 overload
                DataSet ds = new DataSet();
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                //1个dataset包含落干个datatable
                if (dt.Rows.Count > 0)
                {
                    string pwd = dt.Rows[0]["pwd"].ToString();
                    string salt = dt.Rows[0]["salt"].ToString();
                    if (PasswordHelper.VerifyHash(stuPwd, salt, pwd))
                    {
                        // 保存记住我设置
                        ConfigHelper.SaveCredentials(stuNo, stuPwd, chkRememberMe.Checked);
                        
                        MessageBox.Show("登录成功！");
                        FrmSQL fm = new FrmSQL();
                        fm.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("密码不匹配！");
                }
                else
                {
                    MessageBox.Show("用户名不存在！");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录失败: {ex.Message}\n\n堆栈跟踪:\n{ex.StackTrace}");
                
            }
            finally
            {
                sh.Close();
            }

        }

        private void LnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForgotPassword frmForgot = new FrmForgotPassword();
            if (frmForgot.ShowDialog() == DialogResult.OK)
            {
                // Optionally auto-fill the username if they successfully reset password
                txtUserNo.Text = frmForgot.StudentNo;
            }
        }
       
    }
}
