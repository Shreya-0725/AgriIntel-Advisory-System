using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Staff
{
    public class StaffDashboardModel : PageModel
    {
        public string? EmpId => HttpContext.Session.GetString("EmpId");
        public void OnGet() { }
    }
}