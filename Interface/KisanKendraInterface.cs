using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface KisanKendraInterface
    {
        // Get Kisan Kendra Profile
        Task<KisanKendraM?> GetKisanKendraProfileAsync(int kkId);

        // Get Farmers registered under this Kisan Kendra
        Task<List<FarmerM>> GetFarmersByKisanKendraAsync(int kkId);
    }
}

