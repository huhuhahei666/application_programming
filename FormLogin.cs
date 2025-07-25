using OfficeOpenXml;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace WinForms_singleselection
{
    public partial class FormLogin : Form
    {
        private readonly SQLHelper _sqlHelper;
        // 登录成功后的回调，返回学生ID和姓名
        private event Action<string, string> _onLoginSuccess;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<string, string> OnLoginSuccess { get; set; }

        public FormLogin(SQLHelper sqlHelper)
        {
            InitializeComponent();
            _sqlHelper = sqlHelper;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string stuNumber = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(stuNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户名和密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sql = "SELECT stuID,stuNumber, StuName FROM tblstuinfo WHERE stuNumber = @stuNumber AND password = @password";
                var parameters = new[]
                {
                new SqlParameter("@stuNumber", stuNumber),
                new SqlParameter("@password", HashPassword(password))
            };

                var result = _sqlHelper.ExecuteQuery(sql, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("用户名或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int studentId = Convert.ToInt32(result.Rows[0]["StuID"]);
                string studentName = result.Rows[0]["StuName"].ToString();

                // 触发登录成功回调（如果有其他用途）
                // OnLoginSuccess?.Invoke(stuNumber, studentName);

                // 创建并显示 FormSpiderLeetCode2，并传递学生信息
                var formSpider = new FormSpiderLeetCode2(_sqlHelper, studentId, studentName);
                formSpider.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var formRegister = new FormRegister(_sqlHelper);
            formRegister.OnRegisterSuccess = (username) =>
            {
                txtUsername.Text = username;
                txtPassword.Focus();
            };

            formRegister.ShowDialog();
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
