using System.Windows.Forms;
using HiwleawHubShared;

namespace HiwleawHubCustomerApp
{
    public partial class CustomerMenuCardControl : UserControl
    {
        public CustomerMenuCardControl() => InitializeComponent();

        public void SetMenuData(Menu menu)
        {
            lblName.Text = menu.Name;
            lblPrice.Text = $"{menu.Price:N2} บาท";
            lblRatingScore.Text = $"⭐ {menu.AverageRating:F1}";

            // โหลดรูปภาพจาก Server
            if (!string.IsNullOrEmpty(menu.ImageUrl))
            {
                // เปลี่ยนเลข Port ให้ตรงกับ Server ของคุณ (ดูที่หน้าดำ/Swagger)
                picFood.LoadAsync("http://localhost:5275/" + menu.ImageUrl);
            }
        }
    }
}