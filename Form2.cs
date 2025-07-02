using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_singleselection
{
    public partial class Form2 : Form
    {
        private List<Province> provinces;
        private int counter = 60; // 倒计时初始值为60秒
        public Form2()
        {
            InitializeComponent();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            provinces = InitializeData();

            comboBoxProvince.DataSource = provinces;
            comboBoxProvince.DisplayMember = "Name";

            if (comboBoxProvince.Items.Count > 0)
            {
                comboBoxProvince.SelectedIndex = 0;
            }
        }
        private List<Province> InitializeData()
        {
            return new List<Province>
    {
        new Province
        {
            Name = "北京市",
            Cities = new List<City>
            {
                new City
                {
                    Name = "北京市",
                    Districts = new List<string> { "东城区", "西城区", "朝阳区", "海淀区", "丰台区" }
                }
            }
        },
        new Province
        {
            Name = "上海市",
            Cities = new List<City>
            {
                new City
                {
                    Name = "上海市",
                    Districts = new List<string> { "黄浦区", "徐汇区", "长宁区", "静安区", "普陀区" }
                }
            }
        },
        new Province
        {
            Name = "广东省",
            Cities = new List<City>
            {
                new City
                {
                    Name = "广州市",
                    Districts = new List<string> { "天河区", "越秀区", "海珠区", "荔湾区", "白云区" }
                },
                new City
                {
                    Name = "深圳市",
                    Districts = new List<string> { "福田区", "罗湖区", "南山区", "宝安区", "龙岗区" }
                }
            }
        }
        // 可以继续添加更多省份数据
    };
        }
        private void comboBoxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCity.DataSource = null;
            comboBoxDistrict.DataSource = null;

            if (comboBoxProvince.SelectedItem is Province selectedProvince)
            {
                comboBoxCity.DataSource = selectedProvince.Cities;
                comboBoxCity.DisplayMember = "Name";

                if (comboBoxCity.Items.Count > 0)
                {
                    comboBoxCity.SelectedIndex = 0;
                }
            }
        }
        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDistrict.DataSource = null;

            if (comboBoxCity.SelectedItem is City selectedCity)
            {
                comboBoxDistrict.DataSource = selectedCity.Districts;

                if (comboBoxDistrict.Items.Count > 0)
                {
                    comboBoxDistrict.SelectedIndex = 0;
                }
            }
        }
        private void buttonGetSelection_Click(object sender, EventArgs e)
        {
            string province = comboBoxProvince.SelectedItem != null ?
                ((Province)comboBoxProvince.SelectedItem).Name : "未选择";
            string city = comboBoxCity.SelectedItem != null ?
                ((City)comboBoxCity.SelectedItem).Name : "未选择";
            string district = comboBoxDistrict.SelectedItem?.ToString() ?? "未选择";

            MessageBox.Show($"您选择的是: {province} - {city} - {district}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            lbl1.Text = counter.ToString();
            if (counter == 0)
            {
                timer1.Stop();
            }
            progressBar1.Value = (int)((60 - counter) / 60.0 * 100); // 更新进度条
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Enabled = false; // 禁用按钮，防止重复点击
            button2.Enabled = true; // 启用停止按钮

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button1.Enabled = true; // 启用开始按钮
            button2.Enabled = false;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            DateTime starttime = dateTimePicker1.Value;
            DateTime endtime = dateTimePicker2.Value;
            TimeSpan timeDifference = endtime - starttime;

            if (timeDifference < TimeSpan.Zero)
            {
                MessageBox.Show("结束时间不能早于开始时间！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double daysDifference = timeDifference.TotalDays;
            double hoursDifference = timeDifference.TotalHours;

            MessageBox.Show($"开始时间：{starttime}\n结束时间：{endtime}\n时间差：{timeDifference.TotalDays} 天", "时间差计算", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:/consoleApp/images/爱的迫降1.jpg");
        }
    }
    public class Province
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
    public class City
    {
        public string Name { get; set; }
        public List<string> Districts { get; set; } = new List<string>();
    }
}
