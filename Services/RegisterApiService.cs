using AgriIntel_Advisory_System.Model;
using System.Net.Http.Json;

namespace AgriIntel_Advisory_System.Services
{
    public class RegisterApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /* ===================== FARMER ===================== */

        public async Task RegisterFarmerAsync(FarmerM farmer)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/register/farmer", farmer);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Farmer Registration Failed: {error}");
            }
        }

        /* ===================== EXPERT ===================== */

        public async Task RegisterExpertAsync(ExpertM expert)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/register/expert", expert);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Expert Registration Failed: {error}");
            }
        }

        /* ===================== STAFF ===================== */

        public async Task RegisterStaffAsync(StaffM staff)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/register/staff", staff);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Staff Registration Failed: {error}");
            }
        }

        /* ===================== KENDRA ===================== */

        public async Task RegisterKendraAsync(KisanKendraM kendra)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/register/kendra", kendra);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Kendra Registration Failed: {error}");
            }
        }

        /* ===================== LOGIN - FARMER ===================== */

        public async Task<FarmerM?> LoginFarmerAsync(string mobileNo, string password)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/login/farmer", new
            {
                MobileNo = mobileNo,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FarmerM>();
            }

            return null;
        }

        /* ===================== LOGIN - EXPERT ===================== */

        public async Task<ExpertM?> LoginExpertAsync(string email, string password)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/login/expert", new
            {
                Email = email,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ExpertM>();
            }

            return null;
        }

        /* ===================== LOGIN - STAFF ===================== */

        public async Task<StaffM?> LoginStaffAsync(string email, string password)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/login/staff", new
            {
                Email = email,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StaffM>();
            }

            return null;
        }

        /* ===================== LOGIN - KENDRA ===================== */

        public async Task<KisanKendraM?> LoginKendraAsync(string OwnerName, string password)
        {
            var client = _httpClientFactory.CreateClient("MyApi");

            var response = await client.PostAsJsonAsync("api/login/kendra", new
            {
                OwnerName = OwnerName,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<KisanKendraM>();
            }

            return null;
        }

    }


}