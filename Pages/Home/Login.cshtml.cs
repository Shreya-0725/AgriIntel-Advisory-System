using AgriIntel_Advisory_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace AgriIntel_Advisory_System.Pages.Home
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public LoginVM Login { get; set; } = new();

        [BindProperty]
        public string SelectedRole { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Input";
                return Page();
            }

            var client = _httpClientFactory.CreateClient("ApiClient");

            string apiEndpoint = SelectedRole switch
            {
                "farmer" => "/api/Login/farmer",
                "expert" => "/api/Login/expert",
                "staff" => "/api/Login/staff",
                "kendra" => "/api/Login/kendra",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(apiEndpoint))
            {
                ErrorMessage = "Please select role";
                return Page();
            }

        

            var content = new StringContent(
                JsonSerializer.Serialize(Login),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync(apiEndpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = "Invalid Credentials";
                return Page();
            }

            var result = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(result);

            var token = json.GetProperty("token").GetString();
            var user = json.GetProperty("user");

            // ✅ STORE TOKEN
            HttpContext.Session.SetString("JWToken", token);

            // ✅ STORE ROLE ID
            if (SelectedRole == "farmer")
            {
                var farmerId = user.GetProperty("farmerId").GetInt32();
                HttpContext.Session.SetString("FarmerId", farmerId.ToString());
                return RedirectToPage("/Farmer/FarmDashboard");
            }

            if (SelectedRole == "expert")
            {
                var expertId = user.GetProperty("expertId").GetInt32();
                HttpContext.Session.SetString("ExpertId", expertId.ToString());
                return RedirectToPage("/Expert/ExpertDashboard");
            }

            if (SelectedRole == "staff")
            {
                var empId = user.GetProperty("empId").GetInt32();
                HttpContext.Session.SetString("EmpId", empId.ToString());
                return RedirectToPage("/Staff/StaffDashboard");
            }

            if (SelectedRole == "kendra")
            {
                var kkId = user.GetProperty("kkId").GetInt32();
                HttpContext.Session.SetString("KKId", kkId.ToString());
                return RedirectToPage("/kisankendra/kkDashboard");
            }

            return Page();
        }
    }
}