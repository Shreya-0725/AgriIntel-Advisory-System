using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Expert
{
    public class ExpertDashboardModel : PageModel
    {
        public string? ExpertId => HttpContext.Session.GetString("ExpertId");
        public void OnGet() { }
    }
}