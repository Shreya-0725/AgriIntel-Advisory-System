using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class AdminLoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ApiClient");

                var loginData = new
                {
                    username = Username,
                    password = Password
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(loginData),
                    Encoding.UTF8,
                    "application/json"
                );

                // Call your API controller
                var response = await client.PostAsync("/api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var json = JsonSerializer.Deserialize<JsonElement>(result);

                    var token = json.GetProperty("token").GetString();

                    // Store token in session
                    HttpContext.Session.SetString("JWToken", token);
                    HttpContext.Session.SetString("AdminUsername", Username);

                    return RedirectToPage("/Admin/AdminDashboard");
                }

                ErrorMessage = "Invalid Username or Password";
                return Page();
            }
            catch
            {
                ErrorMessage = "Something went wrong.";
                return Page();
            }
        }
    }
}