using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
   
    [Table("tblExpert")]
    public class ExpertM
    {
        [Key]
        [Column("ExpertId")]
        public int ExpertId { get; set; }   // INT IDENTITY

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

        [Column("Gender")]
        [MaxLength(10)]
        public string? Gender { get; set; }   // Nullable in DB

        [Required]
        [Column("MobileNo")]
        [MaxLength(15)]
        public string MobileNo { get; set; } = string.Empty;

        [Column("Email")]
        [MaxLength(50)]
        public string? Email { get; set; }   // Nullable in DB

        [Column("StateCode")]
        [MaxLength(11)]
        public string? StateCode { get; set; }

        [Column("DistrictCode")]
        [MaxLength(11)]
        public string? DistrictCode { get; set; }

        [Column("ExpertIn")]
        [MaxLength(50)]
        public string? ExpertIn { get; set; }   // Nullable in DB

        [Column("AadharNo")]
        [MaxLength(12)]
        public string? AadharNo { get; set; }   // Nullable in DB

        // Navigation property to State
        [ForeignKey("StateCode")]
        public StateM? State { get; set; }

        // Navigation property to District
        [ForeignKey("DistrictCode")]
        public DistrictM? District { get; set; }
    }
}