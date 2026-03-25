using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Farmer
{
    public class MyProfileModel : PageModel
    {
        private readonly FarmerApiService _service;

        public MyProfileModel(FarmerApiService service)
        {
            _service = service;
        }

        // ================= PROFILE DATA =================
        [BindProperty]
        public FarmerM Farmer { get; set; } = new FarmerM();

        // ================= GET FARMER ID FROM SESSION =================
        private int GetLoggedFarmerId()
        {
            var id = HttpContext.Session.GetString("FarmerId");

            if (string.IsNullOrEmpty(id))
                return 0;

            return int.TryParse(id, out int farmerId) ? farmerId : 0;
        }

        // ================= LOAD PROFILE =================
        public async Task<IActionResult> OnGetAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return RedirectToPage("/Home/Login");

            var farmerData = await _service.GetFarmerProfileAsync(farmerId);

            // ✅ Prevent null reference
            Farmer = farmerData ?? new FarmerM();

            return Page();
        }

     
    }
}