using AgriIntel_Advisory_System.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Kendra")]
    public class KKController : ControllerBase
    {
        private readonly KisanKendraInterface _repo;

        public KKController(KisanKendraInterface repo)
        {
            _repo = repo;
        }

        // ================= GET KK PROFILE =================
        [HttpGet("profile/{kkId}")]
        public async Task<IActionResult> GetProfile(int kkId)
        {
            var data = await _repo.GetKisanKendraProfileAsync(kkId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }


        // ================= GET FARMERS UNDER KK =================
        [HttpGet("farmers/{kkId}")]
        public async Task<IActionResult> GetFarmers(int kkId)
        {
            var farmers = await _repo.GetFarmersByKisanKendraAsync(kkId);

            return Ok(farmers);
        }
    }
}