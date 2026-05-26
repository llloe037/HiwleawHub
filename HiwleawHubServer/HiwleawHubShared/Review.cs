using System.ComponentModel.DataAnnotations.Schema;


namespace HiwleawHubShared
{
    [Table("reviews")]
    public class Review
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("menu_id")]
        public int MenuId { get; set; }

        [Column("reviewer_name")]
        public string ReviewerName { get; set; } = string.Empty;

        [Column("rating")]
        public int Rating { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [NotMapped]
        public string? MenuName { get; set; }


    }
}