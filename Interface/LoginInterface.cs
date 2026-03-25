using AgriIntel_Advisory_System.Model;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface LoginInterface
    {
        // Farmer Login (Mobile + Password)
        Task<FarmerM?> LoginFarmerAsync(string mobileNo, string password);

        // Expert Login (Email + Password)
        Task<ExpertM?> LoginExpertAsync(string email, string password);

        // Staff Login (Email + Password)
        Task<StaffM?> LoginStaffAsync(string email, string password);

        // Kisan Kendra Login (Mobile + Password)
        Task<KisanKendraM?> LoginKendraAsync(string mobileNo, string password);

    }
}