using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Farmer
{
    public class ExpertAdvicesModel : PageModel
    {
        private readonly FarmerApiService _service;

        public ExpertAdvicesModel(FarmerApiService service)
        {
            _service = service;
        }

        // -------- Bind New Advice --------
        [BindProperty]
        public ExpertAdviceM NewAdvice { get; set; } = new();

        // -------- History --------
        public List<ExpertAdviceM> MyAdvices { get; set; } = new();

        // ✅ Get Logged Farmer Id
        private int GetLoggedFarmerId()
        {
            var id = HttpContext.Session.GetString("FarmerId");

            if (string.IsNullOrEmpty(id))
                return 0;

            return int.Parse(id);
        }

        // ================= LOAD =================
        public async Task OnGetAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return;

            // ✅ Load ONLY logged farmer advice
            MyAdvices = (await _service.GetMyExpertAdvicesAsync(farmerId)).ToList();
        }

        // ================= SUBMIT =================
        public async Task<IActionResult> OnPostAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return RedirectToPage("/Home/Login");

            if (!ModelState.IsValid)
            {
                MyAdvices = (await _service.GetMyExpertAdvicesAsync(farmerId)).ToList();
                return Page();
            }

            // ✅ Attach farmer id
            NewAdvice.FarmerId = farmerId;

            await _service.SubmitExpertAdviceAsync(NewAdvice);

            TempData["SuccessMessage"] = "Advice request submitted successfully!";

            return RedirectToPage();
        }
    }
}