using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class ManageArticlesModel : PageModel

    {


        private readonly AdminApiService _adminService;

        public ManageArticlesModel(AdminApiService adminService)
        {
            _adminService = adminService;
        }



        public List<ArticleM> Articles { get; set; } = new();

        // ✅ Message For UI Feedback
        [TempData]
        public string? Message { get; set; }

        // ==============================
        // GET
        // ==============================
        public async Task OnGetAsync()
        {
            Articles = await _adminService.GetAllArticlesAsync();
        }

        // ==============================
        // APPROVE
        // ==============================
        public async Task<IActionResult> OnPostApproveAsync(int id)
        {
            await _adminService.ApproveArticleAsync(id);

            Message = "Article Approved Successfully";

            return RedirectToPage();
        }

        // ==============================
        // REJECT
        // ==============================
        public async Task<IActionResult> OnPostRejectAsync(int id)
        {
            await _adminService.RejectArticleAsync(id);

            Message = "Article Rejected Successfully";

            return RedirectToPage();
        }

        // ==============================
        // DELETE
        // ==============================
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _adminService.DeleteArticleAsync(id);

            Message = "Article Deleted Successfully";

            return RedirectToPage();
        }
    }
}