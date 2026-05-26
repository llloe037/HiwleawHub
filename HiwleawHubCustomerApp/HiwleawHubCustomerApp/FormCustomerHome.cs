using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using HiwleawHubShared; // เรียกใช้โมเดล

namespace HiwleawHubCustomerApp
{
    public partial class FormCustomerHome : Form
    {
        // ตั้งค่าตัวยิง API ไปที่ Server ของเรา
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };

        public FormCustomerHome()
        {
            InitializeComponent();
            // สั่งให้โหลดข้อมูลทันทีที่เปิดหน้าต่าง
            this.Load += FormCustomerHome_Load;
        }

        private void FormCustomerHome_Load(object sender, EventArgs e)
        {
            LoadTopRatedRestaurants();
        }

        private async void LoadTopRatedRestaurants()
        {
            try
            {
                flpRestaurants.Controls.Clear(); // ล้างกระดานก่อน

                // ยิง API ไปขอรายชื่อร้านที่เรียงตามดาว (Endpoint ที่เราเพิ่งเขียนใน Server)
                var response = await _client.GetAsync("Restaurants/top-rated");

                if (response.IsSuccessStatusCode)
                {
                    var restaurants = await response.Content.ReadFromJsonAsync<List<Restaurant>>();

                    if (restaurants != null && restaurants.Count > 0)
                    {
                        foreach (var rest in restaurants)
                        {
                            // 1. สร้างการ์ดร้านอาหาร 1 ใบ
                            RestaurantCardControl card = new RestaurantCardControl();

                            // 2. ใส่ข้อมูลให้การ์ด
                            card.SetRestaurantData(rest);

                            // 3. กำหนดสายไฟใหม่: รอรับสัญญาณ OnCardClicked จากการ์ด
                            card.OnCardClicked += (s, ev) =>
                            {
                                FormRestaurantHomePage restaurantPage = new FormRestaurantHomePage(rest);

                                // 1. ซ่อนหน้า Home ไว้ก่อน
                                this.Hide();

                                // 2. ใช้ ShowDialog() แทน Show() (คำสั่งนี้จะทำให้ระบบ "หยุดรอ" จนกว่าหน้าต่างร้านอาหารจะถูกปิด)
                                restaurantPage.ShowDialog();

                                // 3. พอหน้าต่างร้านอาหารโดนปิดปุ๊บ (ไม่ว่าจะกด Back หรือกด X) ให้ดึงหน้า Home กลับมาโชว์อีกรอบ!
                                this.Show();
                            };

                            // 4. เอาการ์ดไปแปะบนหน้าจอ
                            flpRestaurants.Controls.Add(card);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ยังไม่มีร้านอาหารในระบบครับ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อ Server ได้: " + ex.Message);
            }
        }
    }
}