using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Admin
{
    public class ManageFarmersModel : PageModel
    {
        private readonly AdminApiService _adminService;

        public ManageFarmersModel(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        public List<FarmerM> Farmers { get; set; } = new List<FarmerM>();

        [TempData]
        public string? Message { get; set; }

        [TempData]
        public string MessageClass { get; set; } = "alert-success";

        // The farmer whose details are currently shown
        [BindProperty(SupportsGet = true)]
        public int? SelectedFarmerId { get; set; }

        public FarmerM? SelectedFarmer { get; set; }
        public List<QueryM> SelectedQueries { get; set; } = new();
        public List<SoilTestingM> SelectedSoilTests { get; set; } = new();
        public List<ExpertAdviceM> SelectedExpertAdvices { get; set; } = new();

        public async Task OnGetAsync()
        {
            Farmers = await _adminService.GetAllFarmersAsync();

            if (SelectedFarmerId.HasValue)
            {
                await LoadSelectedFarmerDetails(SelectedFarmerId.Value);
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int FarmerId)
        {
            var result = await _adminService.DeleteFarmerAsync(FarmerId);

            if (!result)
            {
                Message = "Cannot delete farmer: has existing queries, soil tests, or expert advices.";
                MessageClass = "alert-danger";
            }
            else
            {
                Message = "Farmer deleted successfully!";
                MessageClass = "alert-success";
            }

            Farmers = await _adminService.GetAllFarmersAsync();
            return Page();
        }

        private async Task LoadSelectedFarmerDetails(int farmerId)
        {
            SelectedFarmer = await _adminService.GetFarmerByIdAsync(farmerId);
            if (SelectedFarmer != null)
            {
                SelectedQueries = await _adminService.GetFarmerQueriesAsync(farmerId);
                SelectedSoilTests = await _adminService.GetFarmerSoilTestsAsync(farmerId);
                SelectedExpertAdvices = await _adminService.GetFarmerExpertAdvicesAsync(farmerId);
            }
        }
    }
}