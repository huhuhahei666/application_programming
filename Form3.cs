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
    public partial class Form3 : Form
    {
        private Dictionary<string, Dictionary<string, List<string>>> albumData;
        private int currentImageIndex = 0;
        private float zoomFactor = 1.0f;
        public Form3()
        {
            InitializeComponent();
            InitializeAlbumData();
            InitializeUI();
        }
        private void InitializeAlbumData()
        {
            albumData = new Dictionary<string, Dictionary<string, List<string>>>
            {
                {
                    "影视剧照", new Dictionary<string, List<string>>
                    {
                        { "《鬼怪》", new List<string> { "../images/鬼怪1.jpg", "../images/鬼怪2.jpg", "../images/鬼怪3.jpg", "../images/鬼怪4.jpg", "../images/鬼怪5.jpg" } },
                        { "《爱的迫降》", new List<string> { "../images/爱的迫降1.jpg", "../images/爱的迫降2.jpg", "../images/爱的迫降3.jpg", "../images/爱的迫降4.jpg", "../images/爱的迫降5.jpg" } }
                    }
                },
                {
                    "自然风景", new Dictionary<string, List<string>>
                    {
                        { "花", new List<string> { "../images/花1.jpg", "../images/花2.jpg", "../images/花3.jpg", "../images/花4.jpg", "../images/花5.jpg" } },
                        { "云", new List<string> { "../images/云1.jpg", "../images/云2.jpg", "../images/云3.jpg", "../images/云4.jpg", "../images/云5.jpg" } }
                    }
                }

            };
        }
        private void InitializeUI()
        {
            // 初始化一级分类ComboBox
            cbCategory.Items.Clear();
            foreach (var category in albumData.Keys)
            {
                cbCategory.Items.Add(category);
            }
            cbCategory.SelectedIndex = 0;

            // 初始化按钮
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbCategory.SelectedItem.ToString();

            // 更新二级分类ComboBox
            cbSubCategory.Items.Clear();
            foreach (var subCategory in albumData[selectedCategory].Keys)
            {
                cbSubCategory.Items.Add(subCategory);
            }
            cbSubCategory.SelectedIndex = 0;
        }
        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem == null || cbSubCategory.SelectedItem == null)
                return;

            string category = cbCategory.SelectedItem.ToString();
            string subCategory = cbSubCategory.SelectedItem.ToString();

            // 重置图片索引
            currentImageIndex = 0;

            // 显示第一张图片
            ShowCurrentImage();

            // 更新按钮状态
            UpdateNavigationButtons();
        }
        private void ShowCurrentImage()
        {
            if (cbCategory.SelectedItem == null || cbSubCategory.SelectedItem == null)
                return;

            string category = cbCategory.SelectedItem.ToString();
            string subCategory = cbSubCategory.SelectedItem.ToString();
            var images = albumData[category][subCategory];

            if (currentImageIndex >= 0 && currentImageIndex < images.Count)
            {
                string imagePath = images[currentImageIndex]; // 假设现在存储的是完整路径

                try
                {
                    // 先释放之前的图片资源
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                    }

                    // 加载新图片
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // 保持图片比例
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"无法加载图片: {ex.Message}");
                }
            }


            lblImageInfo.Text = $"{category} - {subCategory} ({currentImageIndex + 1}/{images.Count})";
        }
        private void UpdateNavigationButtons()
        {
            if (cbCategory.SelectedItem == null || cbSubCategory.SelectedItem == null)
                return;

            string category = cbCategory.SelectedItem.ToString();
            string subCategory = cbSubCategory.SelectedItem.ToString();
            var images = albumData[category][subCategory];

            btnPrev.Enabled = currentImageIndex > 0;
            btnNext.Enabled = currentImageIndex < images.Count - 1;
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                ShowCurrentImage();
                UpdateNavigationButtons();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem == null || cbSubCategory.SelectedItem == null)
                return;

            string category = cbCategory.SelectedItem.ToString();
            string subCategory = cbSubCategory.SelectedItem.ToString();
            var images = albumData[category][subCategory];

            if (currentImageIndex < images.Count - 1)
            {
                currentImageIndex++;
                ShowCurrentImage();
                UpdateNavigationButtons();
            }
        }




        
    }
}
