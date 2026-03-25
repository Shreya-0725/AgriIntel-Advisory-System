
using System.ComponentModel.DataAnnotations;

namespace AgriIntel_Advisory_System.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string Identifier { get; set; } = string.Empty; // Email OR Mobile

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty ;
    }
}