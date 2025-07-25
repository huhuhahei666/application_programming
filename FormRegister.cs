using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinForms_singleselection
{
    public partial class FormRegister : Form
    {
        private readonly SQLHelper _sqlHelper;

        // 注册成功后的回调，返回用户名
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        // 注册成功后的回调，返回用户名
        public Action<string> OnRegisterSuccess { get; set; }

        public FormRegister(SQLHelper sqlHelper)
        {
            InitializeComponent();
            _sqlHelper = sqlHelper;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string stuName = txtStuName.Text.Trim();       // 学生姓名
            string stuNumber = txtStuNumber.Text.Trim();   // 学号
            string password = txtPassword.Text;             // 密码
            string confirmPassword = txtConfirmPassword.Text; // 确认密码

            // 输入验证
            if (string.IsNullOrEmpty(stuName) || string.IsNullOrEmpty(stuNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("学生姓名、学号和密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("两次输入的密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                Console.WriteLine("参数值: @stuNumber = " + stuNumber);
                // 检查用户名是否已存在
                var checkSql = "SELECT COUNT(*) FROM tblstuinfo WHERE stuNumber = @stuNumber";
                var count = Convert.ToInt32(_sqlHelper.ExecuteScalar(checkSql, new SqlParameter("@stuNumber", stuNumber)));

                if (count > 0)
                {
                    MessageBox.Show("用户名已存在", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 注册新用户
                string insertSql = @"
                INSERT INTO tblstuinfo (stuName, stuNumber, Password, RegisterTime) 
                VALUES (@stuName, @stuNumber, @Password, @RegisterTime)";


                var parameters = new SqlParameter[]
                {
                new SqlParameter("@stuName", stuName),
                new SqlParameter("@Password", HashPassword(password)),
                new SqlParameter("@stuNumber", stuNumber),
                new SqlParameter("@RegisterTime", DateTime.Now)
            };

                int rowsAffected = _sqlHelper.ExecuteNonQuery(insertSql, parameters);

                if (rowsAffected > 0)
                {
                    OnRegisterSuccess?.Invoke(stuNumber);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败，数据库未更新", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"数据库错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"注册失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
