//using AgriIntel_Advisory_System.Model;
//using System.Net.Http;
//using System.Net.Http.Json;

//namespace AgriIntel_Advisory_System.Services
//{
//    public class KKApiService
//    {
//        private readonly HttpClient _http;

//        public KKApiService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("MyApi");
//        }

//        // ================= GET KK PROFILE =================
//        public async Task<KisanKendraM?> GetKisanKendraProfileAsync(int kkId)
//        {
//            return await _http.GetFromJsonAsync<KisanKendraM>(
//                $"/api/KK/profile/{kkId}");
//        }

//        // ================= GET FARMERS =================
//        public async Task<List<FarmerM>> GetFarmersAsync(int kkId)
//        {
//            return await _http.GetFromJsonAsync<List<FarmerM>>(
//                $"/api/KK/farmers/{kkId}")
//                ?? new List<FarmerM>();
//        }
//    }
//}



using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AgriIntel_Advisory_System.Services
{
    public class KKApiService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _httpContext;

        public KKApiService(IHttpClientFactory factory,
                            IHttpContextAccessor httpContext)
        {
            _http = factory.CreateClient("MyApi");
            _httpContext = httpContext;
        }

        // =====================================================
        // 🔐 AUTO ATTACH JWT TOKEN
        // =====================================================
        private void AddToken()
        {
            var token = _httpContext.HttpContext?.Session.GetString("JWToken");

            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // =====================================================
        // ================= GET KK PROFILE ====================
        // =====================================================
        public async Task<KisanKendraM?> GetKisanKendraProfileAsync(int kkId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<KisanKendraM>(
                $"/api/KK/profile/{kkId}");
        }

        // =====================================================
        // ================= GET FARMERS =======================
        // =====================================================
        public async Task<List<FarmerM>> GetFarmersAsync(int kkId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<List<FarmerM>>(
                $"/api/KK/farmers/{kkId}")
                ?? new List<FarmerM>();
        }
    }
}