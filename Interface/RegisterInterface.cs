using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface RegisterInterface
    {
        // Farmer
        Task RegisterFarmerAsync(FarmerM farmer);

        // Expert
        Task RegisterExpertAsync(ExpertM expert);

        // Staff
        Task RegisterStaffAsync(StaffM staff);

        // Kisan Kendra
        Task RegisterKendraAsync(KisanKendraM kendra);
    }
}



