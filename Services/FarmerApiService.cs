//using AgriIntel_Advisory_System.Model;
//using System.Net.Http.Json;

//namespace AgriIntel_Advisory_System.Services
//{
//    public class FarmerApiService
//    {
//        private readonly HttpClient _http;

//        public FarmerApiService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("MyApi");
//        }

//        // =====================================================
//        // ---------------- PROFILE ----------------------------
//        // =====================================================

//        public async Task<FarmerM?> GetFarmerProfileAsync(int farmerId)
//        {
//            try
//            {
//                return await _http.GetFromJsonAsync<FarmerM>(
//                    $"/api/farmer/profile/{farmerId}");
//            }
//            catch
//            {
//                return null;
//            }
//        }


//        // =====================================================
//        // ---------------- QUERIES -----------------------------
//        // =====================================================

//        public async Task<bool> SubmitQueryAsync(QueryM query)
//        {
//            var response = await _http.PostAsJsonAsync("/api/farmer/query", query);
//            return response.IsSuccessStatusCode;
//        }

//        public async Task<IEnumerable<QueryM>> GetMyQueriesAsync(int farmerId)
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
//                $"/api/farmer/queries/{farmerId}")
//                ?? new List<QueryM>();
//        }



//        // =====================================================
//        // ---------------- SOIL TEST ---------------------------
//        // =====================================================

//        public async Task<bool> SubmitSoilTestAsync(SoilTestingM soilTest)
//        {
//            var response = await _http.PostAsJsonAsync("/api/farmer/soiltest", soilTest);
//            return response.IsSuccessStatusCode;
//        }

//        public async Task<IEnumerable<SoilTestingM>> GetMySoilTestsAsync(int farmerId)
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<SoilTestingM>>(
//                $"/api/farmer/soiltests/{farmerId}")
//                ?? new List<SoilTestingM>();
//        }


//        // =====================================================
//        // ---------------- EXPERT ADVICE -----------------------
//        // =====================================================

//        public async Task<bool> SubmitExpertAdviceAsync(ExpertAdviceM advice)
//        {
//            var response = await _http.PostAsJsonAsync("/api/farmer/expertadvice", advice);
//            return response.IsSuccessStatusCode;
//        }

//        public async Task<IEnumerable<ExpertAdviceM>> GetMyExpertAdvicesAsync(int farmerId)
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<ExpertAdviceM>>(
//                $"/api/farmer/expertadvices/{farmerId}")
//                ?? new List<ExpertAdviceM>();
//        }


//    }
//
//
//}




using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AgriIntel_Advisory_System.Services
{
    public class FarmerApiService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _httpContext;

        public FarmerApiService(IHttpClientFactory factory,
                                IHttpContextAccessor httpContext)
        {
            _http = factory.CreateClient("MyApi");
            _httpContext = httpContext;
        }

        // =====================================================
        // 🔐 AUTO ATTACH TOKEN
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
        // ---------------- PROFILE ----------------------------
        // =====================================================

        public async Task<FarmerM?> GetFarmerProfileAsync(int farmerId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<FarmerM>(
                $"/api/farmer/profile/{farmerId}");
        }

        // =====================================================
        // ---------------- QUERIES ----------------------------
        // =====================================================

        public async Task<bool> SubmitQueryAsync(QueryM query)
        {
            AddToken();

            var response = await _http.PostAsJsonAsync(
                "/api/farmer/query", query);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<QueryM>> GetMyQueriesAsync(int farmerId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
                $"/api/farmer/queries/{farmerId}")
                ?? new List<QueryM>();
        }

        // =====================================================
        // ---------------- SOIL TEST --------------------------
        // =====================================================

        public async Task<bool> SubmitSoilTestAsync(SoilTestingM soilTest)
        {
            AddToken();

            var response = await _http.PostAsJsonAsync(
                "/api/farmer/soiltest", soilTest);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<SoilTestingM>> GetMySoilTestsAsync(int farmerId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<SoilTestingM>>(
                $"/api/farmer/soiltests/{farmerId}")
                ?? new List<SoilTestingM>();
        }

        // =====================================================
        // ---------------- EXPERT ADVICE ----------------------
        // =====================================================

        public async Task<bool> SubmitExpertAdviceAsync(ExpertAdviceM advice)
        {
            AddToken();

            var response = await _http.PostAsJsonAsync(
                "/api/farmer/expertadvice", advice);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ExpertAdviceM>> GetMyExpertAdvicesAsync(int farmerId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<ExpertAdviceM>>(
                $"/api/farmer/expertadvices/{farmerId}")
                ?? new List<ExpertAdviceM>();
        }
    }
}