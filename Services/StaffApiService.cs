//using AgriIntel_Advisory_System.Model;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//namespace AgriIntel_Advisory_System.Services
//{
//    public class StaffApiService
//    {
//        private readonly HttpClient _http;

//        public StaffApiService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("MyApi");
//        }

//        // -------- GET PROFILE --------
//        public async Task<StaffM?> GetProfileAsync(int empId)
//        {
//            return await _http.GetFromJsonAsync<StaffM>(
//                $"/api/staff/profile/{empId}");
//        }


//        // ---------------- GET ALL QUERIES ----------------

//        public async Task<IEnumerable<QueryM>> GetAllQueriesAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
//                "/api/staff/queries")
//                   ?? new List<QueryM>();
//        }

//        // ---------------- GET PENDING QUERIES ----------------

//        public async Task<IEnumerable<QueryM>> GetPendingQueriesAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
//                "/api/staff/queries/pending")
//                   ?? new List<QueryM>();
//        }

//        // ---------------- GET RESOLVED QUERIES ----------------

//        public async Task<IEnumerable<QueryM>> GetResolvedQueriesAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
//                "/api/staff/queries/resolved")
//                   ?? new List<QueryM>();
//        }

//        // ---------------- GET QUERY BY ID ----------------

//        public async Task<QueryM?> GetQueryByIdAsync(int queryNo)
//        {
//            return await _http.GetFromJsonAsync<QueryM>(
//                $"/api/staff/queries/{queryNo}");
//        }

//        // ---------------- SUBMIT SOLUTION ----------------

//        public async Task<bool> SubmitSolutionAsync(int queryNo, string solution)
//        {
//            var response = await _http.PostAsJsonAsync(
//                $"/api/staff/queries/{queryNo}/solution", solution);

//            return response.IsSuccessStatusCode;
//        }
//    }
//}


using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AgriIntel_Advisory_System.Services
{
    public class StaffApiService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _httpContext;

        public StaffApiService(IHttpClientFactory factory,
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
        // ---------------- GET PROFILE ------------------------
        // =====================================================
        public async Task<StaffM?> GetProfileAsync(int empId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<StaffM>(
                $"/api/staff/profile/{empId}");
        }

        // =====================================================
        // ---------------- GET ALL QUERIES --------------------
        // =====================================================
        public async Task<IEnumerable<QueryM>> GetAllQueriesAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
                "/api/staff/queries")
                   ?? new List<QueryM>();
        }

        // =====================================================
        // ---------------- GET PENDING QUERIES ----------------
        // =====================================================
        public async Task<IEnumerable<QueryM>> GetPendingQueriesAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
                "/api/staff/queries/pending")
                   ?? new List<QueryM>();
        }

        // =====================================================
        // ---------------- GET RESOLVED QUERIES ----------------
        // =====================================================
        public async Task<IEnumerable<QueryM>> GetResolvedQueriesAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<QueryM>>(
                "/api/staff/queries/resolved")
                   ?? new List<QueryM>();
        }

        // =====================================================
        // ---------------- GET QUERY BY ID --------------------
        // =====================================================
        public async Task<QueryM?> GetQueryByIdAsync(int queryNo)
        {
            AddToken();

            return await _http.GetFromJsonAsync<QueryM>(
                $"/api/staff/queries/{queryNo}");
        }

        // =====================================================
        // ---------------- SUBMIT SOLUTION --------------------
        // =====================================================
        public async Task<bool> SubmitSolutionAsync(int queryNo, string solution)
        {
            AddToken();

            var response = await _http.PostAsJsonAsync(
                $"/api/staff/queries/{queryNo}/solution",
                solution);

            return response.IsSuccessStatusCode;
        }
    }
}