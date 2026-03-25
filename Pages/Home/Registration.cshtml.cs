using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using AgriIntel_Advisory_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriIntel_Advisory_System.Pages.Home
{
    public class RegistrationModel : PageModel
    {
        private readonly RegisterApiService _service;
        private readonly AppDbContext _context;

        public RegistrationModel(RegisterApiService service,
                                 AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [BindProperty] public FarmerM Farmer { get; set; } = new();
        [BindProperty] public ExpertM Expert { get; set; } = new();
        [BindProperty] public StaffM Staff { get; set; } = new();
        [BindProperty] public KisanKendraM Kendra { get; set; } = new();

        public List<SelectListItem> StateList { get; set; } = new();
        public List<SelectListItem> DistrictList { get; set; } = new();
        public List<SelectListItem> VillageList { get; set; } = new();

        public void OnGet()
        {
            LoadDropdowns();
        }

        private void LoadDropdowns()
        {
            StateList = _context.States
                .Select(s => new SelectListItem
                {
                    Value = s.StateCode,
                    Text = s.StateName
                }).ToList();

            DistrictList = _context.Districts
                .Select(d => new SelectListItem
                {
                    Value = d.DistrictCode,
                    Text = d.DistrictName
                }).ToList();

            VillageList = _context.Villages
                .Select(v => new SelectListItem
                {
                    Value = v.VillageCode,
                    Text = v.VillageName
                }).ToList();
        }

        /* ==================== FARMER ==================== */
        public async Task<IActionResult> OnPostFarmerAsync()
        {
            LoadDropdowns();

            if (!ValidatePassword(Farmer.Password, Farmer.ConfirmPassword, "Farmer"))
                return Page();

            await _service.RegisterFarmerAsync(Farmer);
            TempData["SuccessMessage"] = "Farmer Registered Successfully!";
            return RedirectToPage();
        }

        /* ==================== EXPERT ==================== */
        public async Task<IActionResult> OnPostExpertAsync()
        {
            LoadDropdowns();

            if (!ValidatePassword(Expert.Password, Expert.ConfirmPassword, "Expert"))
                return Page();

            await _service.RegisterExpertAsync(Expert);
            TempData["SuccessMessage"] = "Expert Registered Successfully!";
            return RedirectToPage();
        }

        /* ==================== STAFF ==================== */
        public async Task<IActionResult> OnPostStaffAsync()
        {
            LoadDropdowns();

            if (!ValidatePassword(Staff.Password, Staff.ConfirmPassword, "Staff"))
                return Page();

            await _service.RegisterStaffAsync(Staff);
            TempData["SuccessMessage"] = "Staff Registered Successfully!";
            return RedirectToPage();
        }

        /* ==================== KISAN KENDRA ==================== */
        public async Task<IActionResult> OnPostKendraAsync()
        {
            LoadDropdowns();

            if (!ValidatePassword(Kendra.Password, Kendra.ConfirmPassword, "Kendra"))
                return Page();

            await _service.RegisterKendraAsync(Kendra);
            TempData["SuccessMessage"] = "Kisan Kendra Registered Successfully!";
            return RedirectToPage();
        }

        /* ==================== PASSWORD VALIDATION ==================== */
        private bool ValidatePassword(string password, string confirmPassword, string rolePrefix)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ModelState.AddModelError($"{rolePrefix}.Password", "Password and Confirm Password are required.");
                return false;
            }

            if (password != confirmPassword)
            {
                ModelState.AddModelError($"{rolePrefix}.ConfirmPassword", "Passwords do not match.");
                return false;
            }

            if (password.Length < 8)
            {
                ModelState.AddModelError($"{rolePrefix}.Password", "Password must be at least 8 characters long.");
                return false;
            }

            // Optional: Add more rules like special characters, numbers, uppercase letters etc.
            return true;
        }
    }
}