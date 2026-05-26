using Microsoft.EntityFrameworkCore;
using HiwleawHubShared;

namespace HiwleawHubApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // บอกให้ C# รู้ว่าคลาสไหนคู่กับตารางไหนใน Database
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Review> Reviews { get; set; }

        // (ส่วนตาราง Reviews เราจะเพิ่มทีหลังตอนทำฟีเจอร์ลูกค้าครับ)
    }
}