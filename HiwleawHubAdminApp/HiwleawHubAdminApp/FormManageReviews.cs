using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using HiwleawHubShared; // เรียกใช้โมเดล Review

namespace HiwleawHubAdminApp
{
    public partial class FormManageReviews : Form
    {
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };
        private int _restaurantId;

        // รับรหัสร้านค้าเข้ามาตอนเปิดหน้าจอ เพื่อดึงรีวิวเฉพาะของร้านนี้
        public FormManageReviews(int restaurantId)
        {
            InitializeComponent();
            _restaurantId = restaurantId;
            LoadReviews();
        }

        private void FormManageReviews_Load(object sender, EventArgs e)
        {
            LoadReviews();
            timerRefresh.Start();
        }

        // ฟังก์ชันโหลดรีวิวจาก API
        private async void LoadReviews()
        {
            try
            {
                flpReviews.Controls.Clear(); // ล้างหน้าจอเก่าออกก่อน

                // ยิง API ไปดึงรีวิวของร้านค้านี้ (ส่งไอดีร้านไปกรองหลังบ้าน)
                var response = await _client.GetAsync($"Reviews/restaurant/{_restaurantId}");

                if (response.IsSuccessStatusCode)
                {
                    var reviews = await response.Content.ReadFromJsonAsync<List<Review>>();

                    if (reviews != null && reviews.Count > 0)
                    {
                        foreach (var review in reviews)
                        {
                            // 1. สร้างกล่องรีวิวมินิมอลขึ้นมาใหม่ทีละใบ
                            ReviewCardControl card = new ReviewCardControl();

                            // 2. ส่งข้อมูลรีวิวเข้าไปให้กล่องแสดงผลข้อความ
                            card.SetReviewData(review);

                            // 3. ผูกสัญญาณว่า ถ้าปุ่มลบในกล่องนั้นโดนกด ให้วิ่งมาทำงานที่ฟังก์ชันด้านล่าง
                            card.OnDeleteClicked += Card_OnDeleteClicked;

                            // 4. เอากล่องรีวิวไปหย่อนใส่ FlowLayoutPanel เพื่อให้มันเรียงต่อกัน
                            flpReviews.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดข้อมูลรีวิวได้: " + ex.Message);
            }
        }

        // ฟังก์ชันจัดการเมื่อแอดมินกดปุ่มลบการ์ดรีวิว
        private async void Card_OnDeleteClicked(object sender, EventArgs e)
        {
            // ดึงข้อมูลการ์ดใบที่ส่งสัญญาณมา
            var selectedCard = (ReviewCardControl)sender;
            var reviewId = selectedCard.CurrentReview.Id;

            var confirm = MessageBox.Show("คุณแน่ใจใช่ไหมที่จะลบรีวิวนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // ยิง API สั่งลบข้อมูลใน Database ของฝั่ง Server
                    var response = await _client.DeleteAsync($"Reviews/{reviewId}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("ลบรีวิวเรียบร้อยแล้วครับ");
                        LoadReviews(); // โหลดรีวิวใหม่เพื่ออัปเดตหน้าจอทันที
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบ: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop();
            this.Close(); // ปิดหน้าต่างย้อนกลับ
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadReviews();
        }
    }
}