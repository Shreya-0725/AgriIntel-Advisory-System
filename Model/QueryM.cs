using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblQueryDetails")]
    public class QueryM
    {
        [Key]
        [Column("QueryNo")]
        public int QueryNo { get; set; }

        [Required]
        [Column("FarmerId")]
        public int FarmerId { get; set; }

        [Required]
        [Column("Title")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("Description")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("Solution")]
        [MaxLength(500)]
        public string? Solution { get; set; }

        [Column("SolutionDate")]
        public DateTime? SolutionDate { get; set; }

        [Required]
        [Column("Status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        // Navigation Property
        [ForeignKey("FarmerId")]
        public FarmerM? Farmer { get; set; }
    }
}