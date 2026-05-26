using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiwleawHubApi.Models;
using HiwleawHubShared;

namespace HiwleawHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // รับเอา AppDbContext (สะพานเชื่อม DB ของเรา) เข้ามาใช้งานในหน้านี้
        public RestaurantsController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint แรกของเรา! สำหรับดึงรายชื่อร้านอาหารทั้งหมด
        // วิธีเรียกใช้งาน: GET /api/restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            // สั่งให้ Entity Framework วิ่งไปกวาดข้อมูลจากตาราง Restaurants มาทั้งหมด
            var restaurants = await _context.Restaurants.ToListAsync();

            // ส่งข้อมูลกลับไปให้หน้าแอปในรูปแบบ รหัส 200 OK (สำเร็จ)
            return Ok(restaurants);
        }

        // ==========================================
        // ✨ โค้ดส่วนที่เพิ่มใหม่ (Step 5) ดึงร้านอาหารเรียงตามดาว
        // ==========================================
        // GET: api/Restaurants/top-rated
        [HttpGet("top-rated")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetTopRatedRestaurants()
        {
            try
            {
                // 1. ดึงรายชื่อร้านอาหารทั้งหมดออกมาก่อน
                var restaurants = await _context.Restaurants.ToListAsync();

                // 2. วนลูปเพื่อคำนวณดาวเฉลี่ยของแต่ละร้าน
                foreach (var rest in restaurants)
                {
                    // หา ID เมนูทั้งหมดที่อยู่ในร้านนี้
                    var menuIds = await _context.Menus
                                                .Where(m => m.RestaurantId == rest.Id)
                                                .Select(m => m.Id)
                                                .ToListAsync();

                    // ดึงคะแนนรีวิวทั้งหมดที่ตรงกับเมนูของร้านนี้
                    var ratings = await _context.Reviews
                                                .Where(r => menuIds.Contains(r.MenuId))
                                                .Select(r => r.Rating)
                                                .ToListAsync();

                    // ถ้ามีคนมารีวิว ให้หาค่าเฉลี่ย ถ้าไม่มีให้เป็น 0
                    if (ratings.Count > 0)
                    {
                        rest.AverageRating = ratings.Average();
                    }
                    else
                    {
                        rest.AverageRating = 0.0;
                    }
                }

                // 3. จัดเรียงจากดาวมากไปดาวน้อย (OrderByDescending)
                var sortedRestaurants = restaurants.OrderByDescending(r => r.AverageRating).ToList();

                return Ok(sortedRestaurants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }
}