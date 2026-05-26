using HiwleawHubShared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace HiwleawHubCustomerApp
{
    public partial class FormRestaurantHomePage : Form
    {
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };
        private Restaurant _currentRestaurant;

        public FormRestaurantHomePage(Restaurant restaurant)
        {
            InitializeComponent();
            _currentRestaurant = restaurant;
            lblRestaurantName.Text = _currentRestaurant.Name;

            LoadAllData();
        }

        private void LoadAllData()
        {
            LoadMenus();   // โหลดเมนู (เรียงตามดาว)
            LoadReviews(); // โหลดรีวิวร้าน
        }

        private async void LoadMenus()
        {
            try
            {
                // ยิงไปที่ Endpoint สเตปที่ 9 ที่เราสร้างไว้ (เรียงดาวมากไปน้อย)
                var menus = await _client.GetFromJsonAsync<List<Menu>>($"Menus/restaurant/{_currentRestaurant.Id}/top-rated");
                flpMenus.Controls.Clear();
                foreach (var m in menus)
                {
                    var card = new CustomerMenuCardControl();
                    card.SetMenuData(m);
                    flpMenus.Controls.Add(card);
                }
            }
            catch { /* จัดการ error */ }
        }

        private async void LoadReviews()
        {
            try
            {
                var reviews = await _client.GetFromJsonAsync<List<Review>>($"Reviews/restaurant/{_currentRestaurant.Id}");
                flpReviews.Controls.Clear();
                foreach (var r in reviews)
                {
                    var card = new CustomerReviewCardControl();
                    card.SetReviewData(r);
                    flpReviews.Controls.Add(card);
                }
            }
            catch { /* จัดการ error */ }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop();

            this.Close(); // ปิดหน้านี้ทิ้ง
        }
        private void btnAddReview_Click(object sender, EventArgs e)
        {
            // 1. สร้างหน้าต่าง Add Review ขึ้นมา พร้อมส่งรหัสร้านอาหาร (Id) ไปให้ด้วย
            FormAddReview addReviewForm = new FormAddReview(_currentRestaurant.Id);

            // 2. สั่งให้เปิดแบบ ShowDialog (เด้งเป็น Pop-up บังหน้าเดิมไว้จนกว่าจะกดปิด)
            // และถ้าลูกค้ากด Submit สำเร็จ (หน้าต่างส่งค่า OK กลับมา)
            if (addReviewForm.ShowDialog() == DialogResult.OK)
            {
                // 3. ให้ทำการรีเฟรชดึงข้อมูลรีวิวมาใหม่ เพื่อให้คอมเมนต์ล่าสุดโชว์ขึ้นมาทันที!
                LoadAllData();
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadAllData();
        }
    }
}