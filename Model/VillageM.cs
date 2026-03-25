using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriIntel_Advisory_System.Model
{
    [Table("tblVillage")]
    public class VillageM
    {
        [Key]
        [Column("VillageCode")]
        [MaxLength(11)]
        public string VillageCode { get; set; } = string.Empty;

        [Column("VillageName")]
        [MaxLength(50)]
        public string VillageName { get; set; } = string.Empty;

        [Column("DistrictCode")]
        [MaxLength(11)]
        public string DistrictCode {  get; set; } = string.Empty;

        //Navigation Property to District
        [ForeignKey("DistrictCode")]
        public DistrictM? District { get; set; }
    }
}
