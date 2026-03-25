using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        public string? Username { get; set; }

        public void OnGet()
        {
            // Only used to display the admin username
            Username = HttpContext.Session.GetString("AdminUsername");
        }

    }
}

