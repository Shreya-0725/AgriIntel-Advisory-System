using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Staff
{
    public class ManageQueriesModel : PageModel
    {
        private readonly StaffApiService _service;

        public List<QueryM> PendingQueries { get; set; } = new();
        public List<QueryM> ResolvedQueries { get; set; } = new();

        [BindProperty]
        public int QueryId { get; set; }

        [BindProperty]
        public string SolutionText { get; set; } = string.Empty;

        public ManageQueriesModel(StaffApiService service)
        {
            _service = service;
        }

        // Load both lists
        public async Task OnGetAsync()
        {
            PendingQueries = (await _service.GetPendingQueriesAsync()).ToList();
            ResolvedQueries = (await _service.GetResolvedQueriesAsync()).ToList();
        }

        // Submit solution
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(SolutionText))
            {
                await OnGetAsync();
                return Page();
            }

            await _service.SubmitSolutionAsync(QueryId, SolutionText);

            TempData["SuccessMessage"] = "Solution submitted successfully!";

            return RedirectToPage();
        }
    }
}