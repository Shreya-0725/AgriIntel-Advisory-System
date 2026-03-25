
using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class ManageQueriesModel : PageModel
    {
        private readonly AdminApiService _adminService;

        public ManageQueriesModel(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        // ===============================
        // Data For Table
        // ===============================
        public List<QueryM> Queries { get; set; } = new();

        // ===============================
        // Message After Resolve
        // ===============================
        [TempData]
        public string? Message { get; set; }

        // ===============================
        // GET → Load All Queries
        // ===============================
        public async Task OnGetAsync()
        {
            Queries = await _adminService.GetAllQueriesAsync();
        }

        // ===============================
        // POST → Resolve Query
        // ===============================
        public async Task<IActionResult> OnPostResolveAsync(int id, string solution)
        {
            await _adminService.ResolveQueryAsync(id, solution);

            Message = "Query Resolved Successfully";

            return RedirectToPage();
        }
    }
}