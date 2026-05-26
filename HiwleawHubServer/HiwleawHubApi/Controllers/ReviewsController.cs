using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiwleawHubApi.Models;
using HiwleawHubShared;

namespace HiwleawHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. ดึงรีวิวทั้งหมดของเมนูนั้นๆ มาโชว์ (โค้ดเดิมของคุณ)
        [HttpGet("menu/{menuId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByMenu(int menuId)
        {
            return await _context.Reviews
                                 .Where(r => r.MenuId == menuId)
                                 .ToListAsync();
        }

        // 2. ให้ลูกค้าส่งรีวิวใหม่เข้ามา (โค้ดเดิมของคุณ)
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok(review);
        }

        // ==========================================
        // ✨ โค้ดส่วนที่เพิ่มใหม่ สำหรับหน้า Admin (เจ้าของร้าน) ✨
        // ==========================================

        // 3. ดึงรีวิวทั้งหมดแยกตาม "รหัสร้านอาหาร" 
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByRestaurant(int restaurantId)
        {
            var reviews = await _context.Reviews
                .Join(_context.Menus,
                      review => review.MenuId,
                      menu => menu.Id,
                      (review, menu) => new { Review = review, Menu = menu })
                .Where(rm => rm.Menu.RestaurantId == restaurantId)
                .Select(rm => new Review
                {
                    Id = rm.Review.Id,
                    MenuId = rm.Review.MenuId,
                    ReviewerName = rm.Review.ReviewerName,
                    Rating = rm.Review.Rating,
                    Comment = rm.Review.Comment,
                    MenuName = rm.Menu.Name // <--- ไฮไลท์อยู่ตรงนี้ครับ! เราเอาชื่อเมนูมายัดใส่ให้แล้ว
                })
                .ToListAsync();

            return reviews;
        }

        // 4. คำสั่งลบรีวิว (รับค่า Id ของรีวิวที่ต้องการลบ)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            // หารีวิวใน Database
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound("ไม่พบรีวิวที่ต้องการลบ");
            }

            // สั่งลบ
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok("ลบรีวิวสำเร็จ");
        }
    }
}