using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Farmer
{
    public class SoilTestRequestModel : PageModel
    {
        private readonly FarmerApiService _service;

        public SoilTestRequestModel(FarmerApiService service)
        {
            _service = service;
        }

        // -------- Bind New Soil Test --------
        [BindProperty]
        public SoilTestingM NewSoilTest { get; set; } = new();

        // -------- History --------
        public List<SoilTestingM> MySoilTests { get; set; } = new();

        // ✅ Get Logged Farmer Id From Session
        private int GetLoggedFarmerId()
        {
            var id = HttpContext.Session.GetString("FarmerId");

            if (string.IsNullOrEmpty(id))
                return 0;

            return int.Parse(id);
        }

        // ================= LOAD DATA =================
        public async Task OnGetAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return;

            // ✅ Load ONLY logged farmer soil tests
            MySoilTests = (await _service.GetMySoilTestsAsync(farmerId)).ToList();
        }

        // ================= SUBMIT =================
        public async Task<IActionResult> OnPostAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return RedirectToPage("/Home/Login");

            if (!ModelState.IsValid)
            {
                MySoilTests = (await _service.GetMySoilTestsAsync(farmerId)).ToList();
                return Page();
            }

            // ✅ Attach farmer id
            NewSoilTest.FarmerId = farmerId;

            await _service.SubmitSoilTestAsync(NewSoilTest);

            TempData["SuccessMessage"] = "Soil test request submitted successfully!";

            return RedirectToPage();
        }
    }
}