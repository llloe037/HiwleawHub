using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using HiwleawHubShared;

namespace HiwleawHubAdminApp
{
    public partial class FormSelectRestaurant : Form
    {
        // ใช้ http และพอร์ตเดิมที่คุณเคยดึงข้อมูลได้
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };

        public FormSelectRestaurant()
        {
            InitializeComponent();
            LoadRestaurantsToCards();
        }

        private async void LoadRestaurantsToCards()
        {
            try
            {
                var restaurants = await _client.GetFromJsonAsync<List<Restaurant>>("Restaurants");
                flpRestaurants.Controls.Clear();

                if (restaurants == null || restaurants.Count == 0) return;

                foreach (var rest in restaurants)
                {
                    Button card = new Button();
                    card.Text = rest.Name;
                    card.Width = 250;
                    card.Height = 150;
                    card.BackColor = Color.LightGray;
                    card.FlatStyle = FlatStyle.Flat;
                    card.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    card.Margin = new Padding(15);

                    // เมื่อการ์ดถูกกด ให้เปิดหน้าจัดการเมนู
                    card.Click += (sender, e) =>
                    {
                        FormManageMenu manageForm = new FormManageMenu(rest.Id, rest.Name);
                        manageForm.Show();
                        this.Hide();
                    };

                    flpRestaurants.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เชื่อมต่อเซิร์ฟเวอร์ไม่ได้: " + ex.Message);
            }
        }

        // เมื่อปิดหน้านี้ ให้ปิดโปรแกรมเลย
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}