using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblExpertAdvice")]
    public class ExpertAdviceM
    {
        [Key]
        [Column("AdviceId")]
        public int AdviceId { get; set; }

        // ------------------- FOREIGN KEYS -------------------

        [Required]
        [Column("FarmerId")]
        public int FarmerId { get; set; }

        [Column("ExpertId")]
        public int? ExpertId { get; set; }

        // ------------------- ADVICE DETAILS -------------------

        [Required]
        [Column("AdviceType")]
        [MaxLength(50)]
        public string AdviceType { get; set; } = string.Empty;

        [Required]
        [Column("Subject")]
        [MaxLength(150)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [Column("Description")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column("Advice")]
        [MaxLength(500)]
        public string? Advice { get; set; }

        [Column("RequestDate")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Column("ResponseDate")]
        public DateTime? ResponseDate { get; set; }

        [Required]
        [Column("Status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        // ------------------- NAVIGATION PROPERTIES -------------------

        [ForeignKey("FarmerId")]
        public FarmerM? Farmer { get; set; }

        [ForeignKey("ExpertId")]
        public ExpertM? Expert { get; set; }
    }
}