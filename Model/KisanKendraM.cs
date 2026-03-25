using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    
    [Table("tblKisaanKendra")]
    public class KisanKendraM
    {
        [Key]
        [Column("KKId")]
        public int KKId { get; set; }   // INT IDENTITY

        [Required]
        [Column("Password")]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("Confirm_Password")]
        [MaxLength(20)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Column("StateCode")]
        [MaxLength(11)]
        public string? StateCode { get; set; }

        [Column("DistrictCode")]
        [MaxLength(11)]
        public string? DistrictCode { get; set; }

        [Column("Block")]
        [MaxLength(50)]
        public string? Block { get; set; }

        [Column("VillageCode")]
        [MaxLength(11)]
        public string? VillageCode { get; set; }

        [Column("OwnerName")]
        [MaxLength(50)]
        public string? OwnerName { get; set; }

        [Column("MobileNo")]
        [MaxLength(15)]
        public string? MobileNo { get; set; }

        // Navigation Properties

        [ForeignKey("StateCode")]
        public StateM? State { get; set; }

        [ForeignKey("DistrictCode")]
        public DistrictM? District { get; set; }

        [ForeignKey("VillageCode")]
        public VillageM? Village { get; set; }
    }
}