using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using HiwleawHubShared;
using System.IO;
using System.Net.Http.Headers;

namespace HiwleawHubAdminApp
{
    public partial class FormAddEditMenu : Form
    {
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5275/api/") };

        private int _restaurantId;
        private string _selectedImagePath = "";
        private Menu _menuToEdit; // ถ้าอันนี้เป็น null = โหมดเพิ่มเมนู

        // 1. ช่องทางเข้าสำหรับ "โหมดเพิ่มเมนูใหม่" (รับแค่ ID ร้าน)
        public FormAddEditMenu(int restaurantId)
        {
            InitializeComponent();
            _restaurantId = restaurantId;

            lblTitle.Text = "Add Menu";
            btnSave.Text = "Add New Menu";
        }

        // 2. ช่องทางเข้าสำหรับ "โหมดแก้ไขเมนู" (รับข้อมูลเมนูเก่ามาทั้งก้อน)
        public FormAddEditMenu(Menu menuToEdit)
        {
            InitializeComponent();
            _menuToEdit = menuToEdit;
            _restaurantId = menuToEdit.RestaurantId;

            // ... โค้ดเดิมที่เซ็ตชื่อกับราคา ...
            txtName.Text = menuToEdit.Name;
            txtPrice.Text = menuToEdit.Price.ToString();

            // --- เพิ่มโค้ดดึงรูปมาโชว์ ---
            if (!string.IsNullOrEmpty(menuToEdit.ImageUrl))
            {
                string fullImageUrl = "http://localhost:5275" + menuToEdit.ImageUrl;
                picMenu.LoadAsync(fullImageUrl);
                picMenu.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // เมื่อกดปุ่ม Save / Add
        // คลาสเล็กๆ เอาไว้รับค่า URL ที่เซิร์ฟเวอร์ส่งกลับมา
        private class UploadResponse
        {
            public string url { get; set; }
        }

        // ฟังก์ชันสำหรับแพ็คไฟล์รูปภาพส่งไปที่ API
        private async Task<string> UploadImageAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return null;

            using (var multipartContent = new MultipartFormDataContent())
            {
                // โหลดไฟล์รูปภาพจากเครื่อง
                var fileStream = new StreamContent(File.OpenRead(filePath));
                fileStream.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                // เอาไฟล์ใส่กล่องพัสดุ (ตั้งชื่อ "file" ให้ตรงกับที่ API รอรับ)
                multipartContent.Add(fileStream, name: "file", fileName: Path.GetFileName(filePath));

                // ส่งพัสดุไปที่เซิร์ฟเวอร์
                var response = await _client.PostAsync("Menus/upload", multipartContent);

                if (response.IsSuccessStatusCode)
                {
                    // ถ้ารับสำเร็จ ให้แกะกล่องเอา URL รูปที่เซิร์ฟเวอร์ส่งกลับมา
                    var result = await response.Content.ReadFromJsonAsync<UploadResponse>();
                    return result?.url;
                }
                return null;
            }
        }

        // เมื่อกดปุ่ม Save
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. ถ้ามีการเลือกรูปภาพใหม่ ให้อัปโหลดรูปไปที่เซิร์ฟเวอร์ก่อน
                string imageUrl = _menuToEdit?.ImageUrl; // ดึง URL รูปเก่ามารอก่อน (ถ้ามี)
                if (!string.IsNullOrEmpty(_selectedImagePath))
                {
                    imageUrl = await UploadImageAsync(_selectedImagePath); // ได้ URL ใหม่จากเซิร์ฟเวอร์
                }

                // 2. จัดการข้อมูลเมนู
                if (_menuToEdit == null)
                {
                    // --- โหมดเพิ่มเมนูใหม่ ---
                    var newMenu = new Menu
                    {
                        Name = txtName.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        RestaurantId = _restaurantId,
                        ImageUrl = imageUrl // เอา URL รูปที่ได้ ใส่เข้าไปใน Database
                    };

                    var response = await _client.PostAsJsonAsync("Menus", newMenu);
                    if (response.IsSuccessStatusCode)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // --- โหมดแก้ไขเมนู ---
                    _menuToEdit.Name = txtName.Text;
                    _menuToEdit.Price = decimal.Parse(txtPrice.Text);
                    if (imageUrl != null)
                    {
                        _menuToEdit.ImageUrl = imageUrl; // อัปเดต URL รูปใหม่
                    }

                    var response = await _client.PutAsJsonAsync($"Menus/{_menuToEdit.Id}", _menuToEdit);
                    if (response.IsSuccessStatusCode)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้องครับ!\n" + ex.Message);
            }
        }

        // เมื่อกดปุ่มลูกศรกลับ
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // กำหนดให้เลือกได้แค่ไฟล์รูปภาพ
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 1. เก็บที่อยู่ไฟล์ไว้ในตัวแปร _selectedImagePath
                    _selectedImagePath = ofd.FileName;

                    // 2. เอารูปขึ้นมาโชว์ที่ PictureBox (picMenu)
                    picMenu.Image = Image.FromFile(_selectedImagePath);
                }
            }
        }
    }
}