//using AgriIntel_Advisory_System.Model;
//using System.Net.Http.Json;

//namespace AgriIntel_Advisory_System.Services
//{
//    public class ExpertApiService
//    {
//        private readonly HttpClient _http;

//        public ExpertApiService(IHttpClientFactory factory)
//        {
//            _http = factory.CreateClient("MyApi");
//        }


//        // ✅ PROFILE (ADD THIS)
//        // =====================================================

//        public async Task<ExpertM?> GetExpertProfileAsync(int expertId)
//        {
//            return await _http.GetFromJsonAsync<ExpertM>(
//                $"/api/expert/profile/{expertId}");
//        }




//        // =====================================================
//        // EXPERT ADVICE
//        // =====================================================

//        public async Task<IEnumerable<ExpertAdviceM>> GetPendingAdviceAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<ExpertAdviceM>>(
//                "/api/expert/advice/pending")
//                ?? new List<ExpertAdviceM>();
//        }

//        public async Task<IEnumerable<ExpertAdviceM>> GetResolvedAdviceAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<ExpertAdviceM>>(
//                "/api/expert/advice/resolved")
//                ?? new List<ExpertAdviceM>();
//        }

//        public async Task<bool> SubmitAdviceAsync(int adviceId, int expertId, string advice)
//        {
//            var response = await _http.PostAsJsonAsync(
//                $"/api/expert/advice/{adviceId}?expertId={expertId}",
//                advice);

//            return response.IsSuccessStatusCode;
//        }


//        // =====================================================
//        // ARTICLES
//        // =====================================================

//        public async Task<IEnumerable<ArticleM>> GetArticlesAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<ArticleM>>(
//                "/api/expert/articles")
//                ?? new List<ArticleM>();
//        }

//        public async Task<bool> AddArticleAsync(ArticleM article)
//        {
//            var response = await _http.PostAsJsonAsync(
//                "/api/expert/articles",
//                article);

//            return response.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteArticleAsync(int articleId)
//        {
//            var response = await _http.DeleteAsync(
//                $"/api/expert/articles/{articleId}");

//            return response.IsSuccessStatusCode;
//        }


//        // =====================================================
//        // SOIL TEST
//        // =====================================================

//        // ✅ Get pending soil tests
//        public async Task<IEnumerable<SoilTestingM>> GetPendingSoilTestsAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<SoilTestingM>>(
//                "/api/expert/soiltests/pending")
//                ?? new List<SoilTestingM>();
//        }

//        // ✅ Get completed soil tests (history)
//        public async Task<IEnumerable<SoilTestingM>> GetCompletedSoilTestsAsync()
//        {
//            return await _http.GetFromJsonAsync<IEnumerable<SoilTestingM>>(
//                "/api/expert/soiltests/completed")
//                ?? new List<SoilTestingM>();
//        }

//        // ✅ Update soil test → expert enters health card no
//        public async Task<bool> UpdateSoilTestAsync(int testId, string healthCardNo)
//        {
//            var response = await _http.PutAsJsonAsync(
//                $"/api/expert/soiltests/{testId}",
//                healthCardNo);

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
    public class ExpertApiService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _httpContext;

        public ExpertApiService(IHttpClientFactory factory,
                                IHttpContextAccessor httpContext)
        {
            _http = factory.CreateClient("MyApi");
            _httpContext = httpContext;
        }

        // =====================================================
        // 🔐 ADD TOKEN AUTOMATICALLY
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
        // PROFILE
        // =====================================================
        public async Task<ExpertM?> GetExpertProfileAsync(int expertId)
        {
            AddToken();

            return await _http.GetFromJsonAsync<ExpertM>(
                $"/api/expert/profile/{expertId}");
        }

        // =====================================================
        // EXPERT ADVICE
        // =====================================================
        public async Task<IEnumerable<ExpertAdviceM>> GetPendingAdviceAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<ExpertAdviceM>>(
                "/api/expert/advice/pending")
                ?? new List<ExpertAdviceM>();
        }

        public async Task<IEnumerable<ExpertAdviceM>> GetResolvedAdviceAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<ExpertAdviceM>>(
                "/api/expert/advice/resolved")
                ?? new List<ExpertAdviceM>();
        }

        public async Task<bool> SubmitAdviceAsync(int adviceId, int expertId, string advice)
        {
            AddToken();

            var response = await _http.PostAsJsonAsync(
                $"/api/expert/advice/{adviceId}?expertId={expertId}",
                advice);

            return response.IsSuccessStatusCode;
        }

        // =====================================================
        // ARTICLES
        // =====================================================
        public async Task<IEnumerable<ArticleM>> GetArticlesAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<ArticleM>>(
                "/api/expert/articles")
                ?? new List<ArticleM>();
        }

        public async Task<bool> AddArticleAsync(ArticleM article)
        {
            AddToken();

            var response = await _http.PostAsJsonAsync(
                "/api/expert/articles",
                article);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            AddToken();

            var response = await _http.DeleteAsync(
                $"/api/expert/articles/{articleId}");

            return response.IsSuccessStatusCode;
        }

        // =====================================================
        // SOIL TEST
        // =====================================================
        public async Task<IEnumerable<SoilTestingM>> GetPendingSoilTestsAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<SoilTestingM>>(
                "/api/expert/soiltests/pending")
                ?? new List<SoilTestingM>();
        }

        public async Task<IEnumerable<SoilTestingM>> GetCompletedSoilTestsAsync()
        {
            AddToken();

            return await _http.GetFromJsonAsync<IEnumerable<SoilTestingM>>(
                "/api/expert/soiltests/completed")
                ?? new List<SoilTestingM>();
        }

        public async Task<bool> UpdateSoilTestAsync(int testId, string healthCardNo)
        {
            AddToken();

            var response = await _http.PutAsJsonAsync(
                $"/api/expert/soiltests/{testId}",
                healthCardNo);

            return response.IsSuccessStatusCode;
        }
    }
}