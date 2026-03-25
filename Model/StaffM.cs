using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
  
    [Table("tblStaff")]
    public class StaffM
    {
        [Key]
        [Column("EmpId")]
        public int EmpId { get; set; }   // INT IDENTITY

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
        public string? Gender { get; set; }

        [Required]
        [Column("MobileNo")]
        [MaxLength(15)]
        public string MobileNo { get; set; } = string.Empty;

        [Column("Email")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Column("Address")]
        [MaxLength(100)]
        public string? Address { get; set; }
    }
}