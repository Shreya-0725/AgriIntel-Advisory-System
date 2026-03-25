using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.kisankendra
{
    public class FarmerDetailsModel : PageModel
    {
        private readonly KKApiService _service;

        public FarmerDetailsModel(KKApiService service)
        {
            _service = service;
        }

        public List<FarmerM> Farmers { get; set; } = new();

        private int GetKKId()
        {
            var id = HttpContext.Session.GetString("KKId");
            return string.IsNullOrEmpty(id) ? 0 : int.Parse(id);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int kkId = GetKKId();

            if (kkId == 0)
                return RedirectToPage("/Home/Login");

            Farmers = (await _service.GetFarmersAsync(kkId)).ToList();

            return Page();
        }
    }
}