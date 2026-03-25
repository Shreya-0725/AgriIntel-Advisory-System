using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Expert
{
    public class MyProfileModel : PageModel
    {
        private readonly ExpertApiService _service;

        public MyProfileModel(ExpertApiService service)
        {
            _service = service;
        }

        // ================= PROFILE DATA =================
        [BindProperty]
        public ExpertM Expert { get; set; } = new ExpertM();

        // ================= GET EXPERT ID FROM SESSION =================
        private int GetLoggedExpertId()
        {
            var id = HttpContext.Session.GetString("ExpertId");

            if (string.IsNullOrEmpty(id))
                return 0;

            return int.TryParse(id, out int expertId) ? expertId : 0;
        }

        // ================= LOAD PROFILE =================
        public async Task<IActionResult> OnGetAsync()
        {
            int expertId = GetLoggedExpertId();

            if (expertId == 0)
                return RedirectToPage("/Home/Login");

            var expertData = await _service.GetExpertProfileAsync(expertId);

            // ✅ Prevent null reference
            Expert = expertData ?? new ExpertM();

            return Page();
        }
    }
}