using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WinForms_singleselection
{
    public partial class FrmForgotPassword : Form
    {
        private string verificationCode; // 存储生成的验证码
        private string studentNo;      // 存储验证通过的学号
        public string StudentNo { get { return studentNo; } }
        public FrmForgotPassword()
        {
            InitializeComponent();
            SetupControls();
        }
        private void SetupControls()
        {
            // 发送验证码按钮事件
            btnSendCode.Click += async (s, e) => {
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtStudentNo.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("请填写完整信息");
                    return;
                }

                // 禁用按钮防止重复点击
               // btnSendCode.Enabled = false;

                // 验证用户信息
                SQLHelper sh = new SQLHelper("Data Source=.;Initial Catalog=tblStudents;Integrated Security=True");
                try
                {
                    string sql = $@"SELECT email FROM tblTopstudents 
                      WHERE studentNo='{txtStudentNo.Text}' 
                      AND studentName='{txtName.Text}'";

                    DataSet ds = new DataSet();
                    sh.RunSQL(sql, ref ds);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("姓名与学号不匹配");
                        return;
                    }

                    string dbEmail = ds.Tables[0].Rows[0]["email"].ToString();
                    if (!dbEmail.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("邮箱与注册信息不符");
                        return;
                    }

                    // 生成验证码
                    studentNo = txtStudentNo.Text;
                    verificationCode = new Random().Next(100000, 999999).ToString();

                    // 异步发送邮件
                    bool isSent = await Task.Run(() => EmailHelper.SendVerificationEmail(txtEmail.Text, verificationCode));

                    if (isSent)
                    {
                        MessageBox.Show("验证码已发送至您的邮箱，请查收");
                        StartCountdown(60); // 开始60秒倒计时
                    }
                    else
                    {
                        MessageBox.Show("邮件发送失败，请稍后重试");
                        btnSendCode.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误: " + ex.Message);
                    btnSendCode.Enabled = true;
                }
                finally
                {
                    sh.Close();
                }
            };

            // 重置密码按钮事件
            btnReset.Click += (s, e) => {
                if (string.IsNullOrEmpty(txtCode.Text) ||
                    string.IsNullOrEmpty(txtNewPwd.Text) ||
                    string.IsNullOrEmpty(txtConfirmPwd.Text))
                {
                    MessageBox.Show("请填写完整信息");
                    return;
                }

                if (txtNewPwd.Text != txtConfirmPwd.Text)
                {
                    MessageBox.Show("两次输入的密码不一致");
                    return;
                }

                if (txtCode.Text != verificationCode)
                {
                    MessageBox.Show("验证码错误");
                    return;
                }

                // 更新数据库密码
                SQLHelper sh = new SQLHelper();
                // 创建哈希密码
                string password = txtNewPwd.Text;
                string salt;
                string hash = PasswordHelper.CreateHash(password, out salt); //不可逆哈希
                try
                {
                    

                    string sql = $@"UPDATE tblTopstudents 
                              SET pwd='{hash}', salt='{salt}' 
                              WHERE studentNo='{studentNo}'";

                    sh.RunSQL(sql);

                    MessageBox.Show("密码重置成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("重置失败: " + ex.Message);
                }
                finally
                {
                    sh.Close();
                }
            };
        }
        // 添加倒计时方法
        private void StartCountdown(int seconds)
        {
            Button btn = btnSendCode;
            btn.Text = $"{seconds}秒后重试";

        
            timer.Tick += (s, e) => {
                seconds--;
                if (seconds <= 0)
                {
                    timer.Stop();
                    btn.Text = "发送验证码";
                    btn.Enabled = true;
                }
                else
                {
                    btn.Text = $"{seconds}秒后重试";
                }
            };
            timer.Start();
        }
    }
}
