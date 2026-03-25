using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Expert
{
    public class ManageSoilTestModel : PageModel
    {
        private readonly ExpertApiService _service;

        public ManageSoilTestModel(ExpertApiService service)
        {
            _service = service;
        }

        public List<SoilTestingM> PendingTests { get; set; } = new();
        public List<SoilTestingM> CompletedTests { get; set; } = new();

        [BindProperty]
        public int TestId { get; set; }

        [BindProperty]
        public string HealthCardNo { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            PendingTests = (await _service.GetPendingSoilTestsAsync()).ToList();
            CompletedTests = (await _service.GetCompletedSoilTestsAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateSoilTestAsync(TestId, HealthCardNo);

            TempData["SuccessMessage"] = "Soil Test Updated Successfully!";

            return RedirectToPage();
        }
    }
}