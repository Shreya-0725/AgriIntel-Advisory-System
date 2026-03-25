using AgriIntel_Advisory_System.Services;
using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.kisankendra
{
    public class kkProfileModel : PageModel
    {
        private readonly KKApiService _service;

        public kkProfileModel(KKApiService service)
        {
            _service = service;
        }

        public KisanKendraM? Kendra { get; set; }

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

            Kendra = await _service.GetKisanKendraProfileAsync(kkId);

            Kendra ??= new KisanKendraM();

            return Page();
        }
    }
}