using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblAdminLogin")]
    public class AdminM
    {
        [Key]
        [Column("AdminId")]
        public int AdminId { get; set; }

        [Required]
        [Column("Username")]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("Password")]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}