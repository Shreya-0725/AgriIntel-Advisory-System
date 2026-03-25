using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Pages.Admin
{

    public class ManageExpertsModel : PageModel
    {
        private readonly AdminApiService _adminService;

        public ManageExpertsModel(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        public List<ExpertM> Experts { get; set; }
        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Experts = await _adminService.GetAllExpertsAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int ExpertId)
        {
            try
            {
                var deleted = await _adminService.DeleteExpertAsync(ExpertId);

                if (deleted)
                {
                    Message = "Expert deleted successfully.";
                }
                else
                {
                    Message = "Cannot delete expert: Expert has advice history.";
                }
            }
            catch (DbUpdateException)
            {
                Message = "Cannot delete expert: Expert has advice history.";
            }

            // Refresh the list
            Experts = await _adminService.GetAllExpertsAsync();

            return Page();
        }
    }


}
