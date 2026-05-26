using System;
using System.Windows.Forms;
using HiwleawHubShared;

namespace HiwleawHubCustomerApp
{
    public partial class RestaurantCardControl : UserControl
    {
        public Restaurant CurrentRestaurant { get; private set; }

        // ✨ 1. สร้างสัญญาณไฟสำหรับบอกหน้า Home ว่า "ฉันโดนคลิกแล้วนะ!"
        public event EventHandler OnCardClicked;

        public RestaurantCardControl()
        {
            InitializeComponent();

            // ✨ 2. โยงสายไฟ: ไม่ว่าจะคลิกโดนอะไรในการ์ด ให้วิ่งไปที่ฟังก์ชัน CardIsClicked
            this.Click += CardIsClicked;

            // หมายเหตุ: เช็คชื่อ Label ของคุณให้ตรงกับในหน้านี้ด้วยนะครับ
            lblRestaurantName.Click += CardIsClicked;
            lblRating.Click += CardIsClicked;

            // ถ้ามี PictureBox ด้วย ก็อย่าลืมโยงสายไฟให้มันด้วยครับ เช่น:
            // picRestaurant.Click += CardIsClicked; 
        }

        // ฟังก์ชันนี้จะทำงานเมื่อส่วนใดส่วนหนึ่งของการ์ดโดนคลิก
        private void CardIsClicked(object sender, EventArgs e)
        {
            // ตะโกนบอกหน้า Home
            OnCardClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetRestaurantData(Restaurant restaurant)
        {
            CurrentRestaurant = restaurant;
            lblRestaurantName.Text = restaurant.Name;
            lblRating.Text = $"⭐ {restaurant.AverageRating:F1}";

            if (!string.IsNullOrEmpty(restaurant.ImageUrl))
            {
                // ยิงไปโหลดรูปจาก Server (เช็ค Port 5275 ให้ตรงกับเครื่องคุณด้วยนะครับ)
                picRestaurant.LoadAsync("http://localhost:5275/" + restaurant.ImageUrl);
            }
        }
    }
}