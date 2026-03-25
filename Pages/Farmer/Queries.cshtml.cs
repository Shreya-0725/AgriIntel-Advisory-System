using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Farmer
{
    public class QueriesModel : PageModel
    {
        private readonly FarmerApiService _service;

        public QueriesModel(FarmerApiService service)
        {
            _service = service;
        }

        // -------- Bind New Query --------
        [BindProperty]
        public QueryM NewQuery { get; set; } = new QueryM();

        // -------- Query History --------
        public List<QueryM> MyQueries { get; set; } = new();

        // ✅ Get Logged Farmer Id from Session
        private int GetLoggedFarmerId()
        {
            var farmerId = HttpContext.Session.GetString("FarmerId");

            if (string.IsNullOrEmpty(farmerId))
                return 0;

            return int.Parse(farmerId);
        }

        // ================== LOAD DATA ==================
        public async Task OnGetAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return;

            // ✅ Show ONLY logged farmer queries
            MyQueries = (await _service.GetMyQueriesAsync(farmerId)).ToList();
        }

        // ================== SUBMIT QUERY ==================
        public async Task<IActionResult> OnPostAsync()
        {
            int farmerId = GetLoggedFarmerId();

            if (farmerId == 0)
                return RedirectToPage("/Home/Login");

            if (!ModelState.IsValid)
            {
                MyQueries = (await _service.GetMyQueriesAsync(farmerId)).ToList();
                return Page();
            }

            // ✅ Attach logged farmer id
            NewQuery.FarmerId = farmerId;

            await _service.SubmitQueryAsync(NewQuery);

            TempData["SuccessMessage"] = "Query submitted successfully!";

            return RedirectToPage();
        }
    }
}