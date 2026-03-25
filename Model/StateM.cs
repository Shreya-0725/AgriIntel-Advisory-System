using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblState")]
    public class StateM
    {
        [Key]
        [Column("StateCode")]
        [MaxLength(11)]
        public string StateCode { get; set; } = string.Empty;

        [Column("StateName")]
        [MaxLength(50)]
        public string StateName { get; set; } = string.Empty;

        //Navigation property for related Districts
        public ICollection<DistrictM>? Districts { get; set; }
    }
}
