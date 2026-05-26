using System.ComponentModel.DataAnnotations.Schema;

namespace HiwleawHubShared
{
    [Table("restaurants")]
    public class Restaurant
    {
        [Column("id")] // แปะป้ายว่าตรงกับคอลัมน์ id
        public int Id { get; set; }

        [Column("name")] // แปะป้ายว่าตรงกับคอลัมน์ name
        public string Name { get; set; } = string.Empty;

        [Column("description")] // แปะป้ายว่าตรงกับคอลัมน์ description
        public string? Description { get; set; }

        // ====== ✅ เพิ่มบรรทัดนี้ลงไปเพื่อรับ Url รูปภาพ ======
        [Column("image_url")] 
        public string? ImageUrl { get; set; }

        [NotMapped]
        public double AverageRating { get; set; }
    }
}