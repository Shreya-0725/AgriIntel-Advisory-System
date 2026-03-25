using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Expert
{
    public class GiveExpertAdviceModel : PageModel
    {
        private readonly ExpertApiService _service;

        public GiveExpertAdviceModel(ExpertApiService service)
        {
            _service = service;
        }

        public List<ExpertAdviceM> PendingRequests { get; set; } = new();
        public List<ExpertAdviceM> ResolvedRequests { get; set; } = new();

        [BindProperty]
        public int AdviceId { get; set; }

        [BindProperty]
        public string SolutionText { get; set; } = string.Empty;

        // ================= LOAD DATA =================
        public async Task<IActionResult> OnGetAsync()
        {
            var expertIdString = HttpContext.Session.GetString("ExpertId");

            if (string.IsNullOrEmpty(expertIdString))
                return RedirectToPage("/Home/Login");

            PendingRequests = (await _service.GetPendingAdviceAsync()).ToList();
            ResolvedRequests = (await _service.GetResolvedAdviceAsync()).ToList();

            return Page();
        }

        // ================= SUBMIT SOLUTION =================
        public async Task<IActionResult> OnPostAsync()
        {
            var expertIdString = HttpContext.Session.GetString("ExpertId");

            if (string.IsNullOrEmpty(expertIdString))
                return RedirectToPage("/Home/Login");

            if (string.IsNullOrWhiteSpace(SolutionText))
            {
                await OnGetAsync();
                return Page();
            }

            int expertId = int.Parse(expertIdString);

            await _service.SubmitAdviceAsync(AdviceId, expertId, SolutionText);

            TempData["SuccessMessage"] = "Solution submitted successfully!";

            return RedirectToPage();
        }
    }
}