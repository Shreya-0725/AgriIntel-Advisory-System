using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class ManageSoilTestsModel : PageModel
    {
        private readonly AdminApiService _adminService;

        public ManageSoilTestsModel(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        public List<SoilTestingM> SoilTests { get; set; } = new();

        // ✅ Load Table
        public async Task OnGetAsync()
        {
            SoilTests = await _adminService.GetAllSoilTestsAsync();
        }

        // ✅ Update Status
        public async Task<IActionResult> OnPostUpdateStatusAsync(int id, string status)
        {
            var result = await _adminService.UpdateSoilTestStatusAsync(id, status);

            TempData["Message"] = result
                ? "Soil Test Status Updated Successfully"
                : "Error Updating Soil Test Status";

            return RedirectToPage();
        }

        // ✅ Delete
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var result = await _adminService.DeleteSoilTestAsync(id);

            TempData["Message"] = result
                ? "Soil Test Deleted Successfully"
                : "Error Deleting Soil Test";

            return RedirectToPage();
        }
    }
}