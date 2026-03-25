using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class ManageStaffModel : PageModel
    {
        private readonly AdminApiService _adminService;

        public ManageStaffModel(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        // All staff members
        public List<StaffM> Staffs { get; set; } = new();

        // Selected staff for viewing details
        [BindProperty(SupportsGet = true)]
        public int? SelectedStaffId { get; set; }

        public StaffM? SelectedStaff { get; set; }

        [TempData]
        public string? Message { get; set; }

        [TempData]
        public string MessageClass { get; set; } = "alert-success";

        // ======================= PAGE LOAD =======================
        public async Task OnGetAsync()
        {
            Staffs = await _adminService.GetAllStaffAsync();

            if (SelectedStaffId.HasValue)
            {
                SelectedStaff = await _adminService.GetStaffByIdAsync(SelectedStaffId.Value);
            }
        }

        // ======================= DELETE STAFF ====================
        public async Task<IActionResult> OnPostDeleteAsync(int staffId)
        {
            var result = await _adminService.DeleteStaffAsync(staffId);

            if (!result)
            {
                Message = "Cannot delete staff: may have related records or does not exist.";
                MessageClass = "alert-danger";
            }
            else
            {
                Message = "Staff deleted successfully!";
                MessageClass = "alert-success";
            }

            Staffs = await _adminService.GetAllStaffAsync();
            return Page();
        }
    }
}