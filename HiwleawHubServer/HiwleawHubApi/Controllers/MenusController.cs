using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiwleawHubApi.Models;
using HiwleawHubShared;

namespace HiwleawHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenusController(AppDbContext context)
        {
            _context = context;
        }

        // 1. ฟังก์ชันสำหรับแอปฝั่งลูกค้า: ดึงเมนูเฉพาะของร้านที่เลือก
        // วิธีเรียกใช้งาน: GET /api/Menus/restaurant/1 (เลข 1 คือ ID ของร้าน)
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenusByRestaurant(int restaurantId)
        {
            // ไปค้นหาเมนูที่ค่า RestaurantId ตรงกับที่ส่งเข้ามา
            var menus = await _context.Menus
                                      .Where(m => m.RestaurantId == restaurantId)
                                      .ToListAsync();
            return Ok(menus);
        }

        // 2. ฟังก์ชันสำหรับแอปฝั่งเจ้าของร้าน: เพิ่มเมนูใหม่ลง Database
        // วิธีเรียกใช้งาน: POST /api/Menus
        [HttpPost]
        public async Task<ActionResult<Menu>> AddMenu(Menu menu)
        {
            // สั่งให้ Entity Framework นำข้อมูลไป Insert ลงตาราง menus
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(); // สั่ง Save เพื่อให้ข้อมูลลง Database จริงๆ

            return Ok(menu); // ส่งข้อมูลเมนูที่ถูกบันทึกแล้วกลับไปให้หน้าจอ
        }
        // ฟังก์ชันสำหรับลบเมนูอาหาร
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            // ค้นหาเมนูจาก ID
            var menu = await _context.Menus.FindAsync(id);

            // ถ้าหาไม่เจอ ให้ตอบกลับไปว่า NotFound (นี่แหละที่แอปคุณเจอ!)
            if (menu == null)
            {
                return NotFound();
            }

            // ถ้าเจอ ก็สั่งลบออกจาก Database
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            // ตอบกลับว่าทำสำเร็จ (No Content คือสำเร็จแต่ไม่มีข้อมูลอะไรส่งกลับไป)
            return NoContent();
        }

        // ฟังก์ชันสำหรับแก้ไขข้อมูล (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, Menu updatedMenu)
        {
            if (id != updatedMenu.Id) return BadRequest();

            // บอก Database ว่าข้อมูลก้อนนี้ถูกแก้ไขแล้วนะ ให้เตรียมเซฟ
            _context.Entry(updatedMenu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // ฟังก์ชันสำหรับรับไฟล์รูปภาพ
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            // เช็คว่ามีไฟล์ส่งมาจริงๆ ใช่ไหม
            if (file == null || file.Length == 0)
            {
                return BadRequest("ไม่มีไฟล์ถูกส่งมาครับ");
            }

            // สร้างโฟลเดอร์ชื่อ 'images' ไว้ใน 'wwwroot' (ถ้ายังไม่มีระบบจะสร้างให้)
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // ตั้งชื่อไฟล์ใหม่ด้วยระบบสุ่ม (Guid) เพื่อไม่ให้ชื่อไฟล์ซ้ำกันเวลาคนอัปโหลดรูปชื่อเดียวกัน
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // ทำการเซฟไฟล์ลงในโฟลเดอร์
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // สร้างเส้นทาง (URL) สำหรับให้แอปเอาไปโชว์ แล้วส่งกลับไปบอกแอป
            var imageUrl = $"/images/{uniqueFileName}";
            return Ok(new { url = imageUrl });
        }
        // ==========================================
        // ✨ โค้ดสำหรับฝั่งลูกค้า: ดึงเมนูของร้าน พร้อมเรียงตามดาวเฉลี่ย
        // GET: api/Menus/restaurant/{restaurantId}/top-rated
        // ==========================================
        [HttpGet("restaurant/{restaurantId}/top-rated")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetTopRatedMenusByRestaurant(int restaurantId)
        {
            try
            {
                // 1. ดึงเมนูทั้งหมดของร้านนี้มา
                var menus = await _context.Menus
                                          .Where(m => m.RestaurantId == restaurantId)
                                          .ToListAsync();

                // 2. วนลูปหาดาวเฉลี่ยให้แต่ละเมนู
                foreach (var menu in menus)
                {
                    var ratings = await _context.Reviews
                                                .Where(r => r.MenuId == menu.Id)
                                                .Select(r => r.Rating)
                                                .ToListAsync();

                    if (ratings.Count > 0)
                    {
                        menu.AverageRating = ratings.Average();
                    }
                    else
                    {
                        menu.AverageRating = 0.0;
                    }
                }

                // 3. เรียงลำดับเมนูจากดาวมากไปดาวน้อย (OrderByDescending)
                var sortedMenus = menus.OrderByDescending(m => m.AverageRating).ToList();

                return Ok(sortedMenus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }
}