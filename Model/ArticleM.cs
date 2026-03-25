using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblArticle")]
    public class ArticleM
    {
        [Key]
        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Required]
        [Column("ImagePath")]
        [MaxLength(300)]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        [Column("TitleEnglish")]
        [MaxLength(200)]
        public string TitleEnglish { get; set; } = string.Empty;

        [Required]
        [Column("DescriptionEnglish")]
        public string DescriptionEnglish { get; set; } = string.Empty;

        [Required]
        [Column("TitleHindi")]
        [MaxLength(200)]
        public string TitleHindi { get; set; } = string.Empty;

        [Required]
        [Column("DescriptionHindi")]
        public string DescriptionHindi { get; set; } = string.Empty;
    }
}