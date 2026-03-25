using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Staff
{
    public class ProfileModel : PageModel
    {
        private readonly StaffApiService _service;

        public ProfileModel(StaffApiService service)
        {
            _service = service;
        }

        // ================= PROFILE DATA =================
        [BindProperty]
        public StaffM Staff { get; set; } = new StaffM();

        // ================= GET STAFF ID FROM SESSION =================
        private int GetLoggedStaffId()
        {
            var id = HttpContext.Session.GetString("EmpId");

            if (string.IsNullOrEmpty(id))
                return 0;

            return int.TryParse(id, out int empId) ? empId : 0;
        }

        // ================= LOAD PROFILE =================
        public async Task<IActionResult> OnGetAsync()
        {
            int empId = GetLoggedStaffId();

            if (empId == 0)
                return RedirectToPage("/Home/Login");

            var staffData = await _service.GetProfileAsync(empId);

            // ✅ Prevent null reference
            Staff = staffData ?? new StaffM();

            return Page();
        }
    }
}