using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.kisankendra
{
    public class kkDashboardModel : PageModel
    {
        public string? KKId => HttpContext.Session.GetString("KKId");
        public void OnGet() { }
    }
}