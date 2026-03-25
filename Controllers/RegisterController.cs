using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterInterface _registerRepository;

        public RegisterController(RegisterInterface registerRepository)
        {
            _registerRepository = registerRepository;
        }

        /* ========================================================= */
        /* ======================= FARMER ========================== */
        /* ========================================================= */

        [HttpPost("farmer")]
        public async Task<IActionResult> RegisterFarmer([FromBody] FarmerM farmer)
        {
            if (farmer == null)
                return BadRequest("Farmer data is null");

            await _registerRepository.RegisterFarmerAsync(farmer);

            return Ok(new
            {
                message = "Farmer Registered Successfully",
                id = farmer.FarmerId
            });
        }

        /* ========================================================= */
        /* ======================= EXPERT ========================== */
        /* ========================================================= */

        [HttpPost("expert")]
        public async Task<IActionResult> RegisterExpert([FromBody] ExpertM expert)
        {
            if (expert == null)
                return BadRequest("Expert data is null");

            await _registerRepository.RegisterExpertAsync(expert);

            return Ok(new
            {
                message = "Expert Registered Successfully",
                id = expert.ExpertId
            });
        }

        /* ========================================================= */
        /* ======================= STAFF =========================== */
        /* ========================================================= */

        [HttpPost("staff")]
        public async Task<IActionResult> RegisterStaff([FromBody] StaffM staff)
        {
            if (staff == null)
                return BadRequest("Staff data is null");

            await _registerRepository.RegisterStaffAsync(staff);

            return Ok(new
            {
                message = "Staff Registered Successfully",
                id = staff.EmpId
            });
        }

        /* ========================================================= */
        /* ==================== KISAN KENDRA ======================= */
        /* ========================================================= */

        [HttpPost("kendra")]
        public async Task<IActionResult> RegisterKendra([FromBody] KisanKendraM kendra)
        {
            if (kendra == null)
                return BadRequest("Kisan Kendra data is null");

            await _registerRepository.RegisterKendraAsync(kendra);

            return Ok(new
            {
                message = "Kisan Kendra Registered Successfully",
                id = kendra.KKId
            });
        }
    }
}