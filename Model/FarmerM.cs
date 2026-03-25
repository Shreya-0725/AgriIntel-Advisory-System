using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    
    [Table("tblFarmer")]
    public class FarmerM
    {
        [Key]
        [Column("FarmerId")]
        public int FarmerId { get; set; }   // INT IDENTITY

        [Required]
        [Column("Password")]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("Confirm_Password")]
        [MaxLength(20)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [Column("FirstName")]
        [MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column("LastName")]
        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Column("MobileNo")]
        [MaxLength(15)]
        public string MobileNo { get; set; } = string.Empty;   // Changed to string

        [Column("Address")]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Column("StateCode")]
        [MaxLength(11)]
        public string? StateCode { get; set; }

        [Column("DistrictCode")]
        [MaxLength(11)]
        public string? DistrictCode { get; set; }

        [Column("VillageCode")]
        [MaxLength(11)]
        public string? VillageCode { get; set; }

        [Column("PINCode")]
        public int? PINCode { get; set; }

        [Column("AadharNo")]
        [MaxLength(12)]
        public string? AadharNo { get; set; }   // Changed to string

        // Navigation property to State
        [ForeignKey("StateCode")]
        public StateM? State { get; set; }

        // Navigation property to District
        [ForeignKey("DistrictCode")]
        public DistrictM? District { get; set; }

        // Navigation property to Village
        [ForeignKey("VillageCode")]
        public VillageM? Village { get; set; }
    }
}