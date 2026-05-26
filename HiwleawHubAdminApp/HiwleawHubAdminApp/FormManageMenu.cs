using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using HiwleawHubShared;

namespace HiwleawHubAdminApp
{
    public partial class FormManageMenu : Form
    {
        private int _currentRestaurantId;
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };

        public FormManageMenu(int restaurantId, string restaurantName)
        {
            InitializeComponent();
            _currentRestaurantId = restaurantId;
            this.Text = $"จัดการร้าน - {restaurantName}";

            LoadMenus(); // โหลดข้อมูลทันที
        }

        private async void LoadMenus()
        {
            try
            {
                var menus = await _client.GetFromJsonAsync<List<Menu>>($"Menus/restaurant/{_currentRestaurantId}");

                // เคลียร์กระดานให้โล่งก่อน
                flpMenus.Controls.Clear();

                if (menus == null || menus.Count == 0) return;

                // วนลูปเสกการ์ดตามจำนวนเมนู
                foreach (var menu in menus)
                {
                    MenuCardControl card = new MenuCardControl();
                    card.SetMenuData(menu); // ส่งข้อมูลเมนูเข้าไปในการ์ด

                    // เอาสายไฟมาเสียบ: ถ้าการ์ดตะโกนว่าถูกกด ให้ทำอะไรต่อ?
                    card.OnEditClicked += (sender, e) => EditMenu(menu);
                    card.OnDeleteClicked += (sender, e) => DeleteMenu(menu);

                    // เอาการ์ดไปแปะบนกระดาน
                    flpMenus.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถดึงข้อมูลเมนูได้: " + ex.Message);
            }
        }

        // ฟังก์ชันเมื่อกดปุ่มแก้ไข (เดี๋ยวเรามาทำหน้า Pop-up กันสเตปต่อไป)
        private void EditMenu(Menu menu)
        {
            // เปิด Pop-up โหมดแก้ไข (โยนข้อมูลเก่าไปให้ด้วย)
            FormAddEditMenu editForm = new FormAddEditMenu(menu);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadMenus();
            }
        }

        // ฟังก์ชันเมื่อกดปุ่มลบ (ทำตาม Figma ของคุณเป๊ะๆ)
        private async void DeleteMenu(Menu menu)
        {
            var confirmResult = MessageBox.Show(
                $"คุณต้องการลบเมนู '{menu.Name}' ใช่หรือไม่?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // ส่งคำสั่งลบไปที่ API
                    var response = await _client.DeleteAsync($"Menus/{menu.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("ลบเมนูสำเร็จ!");
                        LoadMenus(); // โหลดการ์ดใหม่
                    }
                    else
                    {
                        // ทริคของโปรแกรมเมอร์: ดึงข้อความ Error ลึกๆ จาก Backend มาอ่าน
                        string errorDetail = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API ปฏิเสธการลบ! (รหัส: {response.StatusCode})\nรายละเอียด: {errorDetail}", "Backend Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อ: " + ex.Message);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            // เปิด Pop-up โหมดเพิ่ม
            FormAddEditMenu addForm = new FormAddEditMenu(_currentRestaurantId);

            // ถ้าหน้า Pop-up ปิดลงและส่งสัญญาณว่า OK (เซฟสำเร็จ) ให้โหลดการ์ดใหม่
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadMenus();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // สร้างหน้าจอเลือกร้านขึ้นมาใหม่
            FormSelectRestaurant selectForm = new FormSelectRestaurant();

            // สั่งให้หน้าจอเลือกร้านโชว์ขึ้นมา
            selectForm.Show();

            // ซ่อนหน้าจัดการร้าน (หน้านี้) เอาไว้
            this.Hide();
        }

        private void btnViewReviews_Click(object sender, EventArgs e)
        {
            FormManageReviews reviewForm = new FormManageReviews(_currentRestaurantId);
            reviewForm.ShowDialog();
        }
        // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อผู้ใช้กดปุ่มกากบาทปิดหน้าต่าง

    }

}