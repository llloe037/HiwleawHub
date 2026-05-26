using System;
using System.Windows.Forms;
using HiwleawHubShared; // เรียกใช้โมเดล Menu

namespace HiwleawHubAdminApp
{
    public partial class MenuCardControl : UserControl
    {
        // เก็บข้อมูลเมนูของการ์ดใบนี้ไว้
        public Menu CurrentMenu { get; private set; }

        // สร้าง "สายไฟ" (Event) ไว้ให้หน้าจอหลักมาเสียบ เพื่อรอฟังว่าปุ่มถูกกดไหม
        public event EventHandler OnEditClicked;
        public event EventHandler OnDeleteClicked;

        public MenuCardControl()
        {
            InitializeComponent();
        }

        // ฟังก์ชันสำหรับรับข้อมูลจากหน้าหลัก มาแปะลงบนตัวหนังสือของการ์ด
        public void SetMenuData(Menu menu)
        {
            CurrentMenu = menu;
            lblMenuName.Text = menu.Name;
            lblMenuPrice.Text = $"ราคา: {menu.Price} บาท";

            // --- โค้ดส่วนที่เพิ่มเข้ามาเพื่อโหลดรูปภาพ ---
            if (!string.IsNullOrEmpty(menu.ImageUrl))
            {
                // สร้าง URL เต็มๆ (เอา URL ของ Server มารวมกับที่อยู่ใน Database)
                // **ถ้าพอร์ตเซิร์ฟเวอร์ของคุณไม่ใช่ 5275 ให้เปลี่ยนให้ตรงด้วยนะครับ**
                string fullImageUrl = "http://localhost:5275" + menu.ImageUrl;

                try
                {
                    // สั่งให้ PictureBox โหลดรูปจากอินเทอร์เน็ต/เซิร์ฟเวอร์
                    // ใช้ LoadAsync เพื่อไม่ให้หน้าจอค้างตอนรอโหลดรูป
                    picMenu.LoadAsync(fullImageUrl);
                    picMenu.SizeMode = PictureBoxSizeMode.Zoom; // ปรับให้รูปพอดีกรอบ
                    picMenu.BackColor = Color.White; // เปลี่ยนพื้นหลังเป็นสีขาว
                }
                catch
                {
                    // ถ้าโหลดรูปพัง (เช่น เน็ตหลุด หรือไฟล์หาย) ให้กลับไปเป็นสีเทา
                    picMenu.Image = null;
                    picMenu.BackColor = Color.LightGray;
                }
            }
            else
            {
                // ถ้าเมนูนี้ไม่มีรูปใน Database ให้เป็นกล่องสีเทาเหมือนเดิม
                picMenu.Image = null;
                picMenu.BackColor = Color.LightGray;
            }
        }

        // เมื่อปุ่ม "แก้ไข" ในการ์ดถูกกด
        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked?.Invoke(this, EventArgs.Empty); // ตะโกนบอกหน้าหลัก
        }

        // เมื่อปุ่ม "ลบ" ในการ์ดถูกกด
        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClicked?.Invoke(this, EventArgs.Empty); // ตะโกนบอกหน้าหลัก
        }
    }
}