using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using HiwleawHubShared;

namespace HiwleawHubCustomerApp
{
    public partial class FormAddReview : Form
    {
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };
        private int _restaurantId;

        // ✨ สร้างตัวแปรเก็บคะแนนดาว (ค่าเริ่มต้นให้เป็น 5 ดาวไปเลย)
        private int _currentRating = 5;

        public FormAddReview(int restaurantId)
        {
            InitializeComponent();
            _restaurantId = restaurantId;

            // ✨ 1. สั่งให้โหลดเมนูมาใส่ Dropdown ทันทีที่เปิดหน้าต่าง
            LoadMenusForDropdown();

            // 🔌 2. เสียบสายไฟให้ดาวแบบชัวร์ๆ
            lblStar1.Click += lblStar1_Click;
            lblStar2.Click += lblStar2_Click;
            lblStar3.Click += lblStar3_Click;
            lblStar4.Click += lblStar4_Click;
            lblStar5.Click += lblStar5_Click;

            // ตอนเปิดหน้าต่างมาครั้งแรก สั่งให้ดาวทึบ 5 ดวง
            UpdateStars(5);
        }

        // ==========================================
        // ✨ โค้ดดึงเมนูมาใส่ Dropdown (แก้ไข URL แล้ว) ✨
        // ==========================================
        private async void LoadMenusForDropdown()
        {
            try
            {
                var menus = await _client.GetFromJsonAsync<List<Menu>>($"Menus/restaurant/{_restaurantId}/top-rated");

                if (menus != null && menus.Count > 0)
                {
                    cmbMenus.DataSource = menus;
                    cmbMenus.DisplayMember = "Name"; // โชว์ชื่อเมนู
                    cmbMenus.ValueMember = "Id";     // เก็บรหัสเมนู
                }
                else
                {
                    MessageBox.Show("ร้านนี้ยังไม่มีการเพิ่มเมนูอาหารในระบบครับ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("โหลดข้อมูลเมนูเข้า Dropdown ไม่สำเร็จเนื่องจาก: " + ex.Message);
            }
        }

        // ==========================================
        // ✨ โค้ดระบบดาว 5 ดวง ✨
        // ==========================================

        // ฟังก์ชันสำหรับเปลี่ยนรูปดาว โปร่ง/ทึบ ตามคะแนนที่ถูกกด
        private void UpdateStars(int rating)
        {
            _currentRating = rating;

            // ถ้าคะแนน >= ลำดับของดาว ให้เป็นดาวทึบ (★) ถ้าไม่ใช่ให้เป็นดาวโปร่ง (☆)
            lblStar1.Text = rating >= 1 ? "★" : "☆";
            lblStar2.Text = rating >= 2 ? "★" : "☆";
            lblStar3.Text = rating >= 3 ? "★" : "☆";
            lblStar4.Text = rating >= 4 ? "★" : "☆";
            lblStar5.Text = rating >= 5 ? "★" : "☆";
        }

        // โยงสายไฟ: เมื่อลูกค้าคลิกที่ดาวแต่ละดวง
        private void lblStar1_Click(object sender, EventArgs e) => UpdateStars(1);
        private void lblStar2_Click(object sender, EventArgs e) => UpdateStars(2);
        private void lblStar3_Click(object sender, EventArgs e) => UpdateStars(3);
        private void lblStar4_Click(object sender, EventArgs e) => UpdateStars(4);
        private void lblStar5_Click(object sender, EventArgs e) => UpdateStars(5);

        // ==========================================

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbMenus.SelectedValue == null || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("กรุณาเลือกเมนูและกรอกชื่อผู้รีวิวด้วยครับ");
                return;
            }

            var newReview = new Review
            {
                MenuId = (int)cmbMenus.SelectedValue,
                ReviewerName = txtName.Text,
                Rating = _currentRating,
                Comment = txtComment.Text
            };

            try
            {
                var response = await _client.PostAsJsonAsync("Reviews", newReview);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("ส่งรีวิวสำเร็จ! ขอบคุณครับ 🎉");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ส่งรีวิวไม่สำเร็จครับ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }
}