using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Farmer
{
    public class FarmDashboardModel : PageModel
    {
        public string? FarmerId => HttpContext.Session.GetString("FarmerId");
        public void OnGet() { }
    }
}