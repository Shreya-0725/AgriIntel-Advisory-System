using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblSoilTesting")]
    public class SoilTestingM
    {
        [Key]
        [Column("TestId")]
        public int TestId { get; set; }   // FIXED: INT IDENTITY

        [Required]
        [Column("FarmerId")]
        public int FarmerId { get; set; }   // FIXED: INT

        [Column("ApplicationDate")]
        public DateTime ApplicationDate { get; set; }

        [Column("SoilType")]
        [MaxLength(50)]
        public string? SoilType { get; set; }

        [Column("Nutrient")]
        [MaxLength(100)]
        public string? Nutrient { get; set; }

        [Column("Acidity")]
        [MaxLength(20)]
        public string? Acidity { get; set; }

        [Column("PhLevel")]
        public decimal? PhLevel { get; set; }

        [Column("HealthCardNo")]
        [MaxLength(20)]
        public string? HealthCardNo { get; set; }

        [Required]
        [Column("Status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        // Navigation
        [ForeignKey("FarmerId")]
        public FarmerM? Farmer { get; set; }
    }
}