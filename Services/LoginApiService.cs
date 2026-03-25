
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;

namespace AgriIntel_Advisory_System.Services
{
    public class LoginApiService
    {
        private readonly LoginInterface _loginRepository;

        public LoginApiService(LoginInterface loginRepository)
        {
            _loginRepository = loginRepository;
        }

        /* ================= FARMER ================= */

        public Task<FarmerM?> FarmerLogin(string mobileNo, string password)
        {
            return _loginRepository.LoginFarmerAsync(mobileNo, password);
        }

        /* ================= EXPERT ================= */

        public Task<ExpertM?> ExpertLogin(string email, string password)
        {
            return _loginRepository.LoginExpertAsync(email, password);
        }

        /* ================= STAFF ================= */

        public Task<StaffM?> StaffLogin(string email, string password)
        {
            return _loginRepository.LoginStaffAsync(email, password);
        }

        /* ================= KENDRA ================= */

        public Task<KisanKendraM?> KendraLogin(string mobileNo, string password)
        {
            return _loginRepository.LoginKendraAsync(mobileNo, password);
        }
    }
}