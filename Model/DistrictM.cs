using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblDistrict")]
    public class DistrictM
    {
        [Key]
        [Column("DistrictCode")]
        [MaxLength(11)]
        public string DistrictCode { get; set; } = string.Empty;

        [Column("DistrictName")]
        [MaxLength(50)]
        public string DistrictName { get; set;} = string.Empty;

        [Column("StateCode")]
        [MaxLength(11)]
        public string StateCode {  get; set;} = string.Empty;

        //Navigation property to state
        [ForeignKey("StateCode")]
        public StateM? State { get; set;}

        //Navigation property for related villages
        public ICollection<VillageM>? Villages { get; set;}
    }
}
