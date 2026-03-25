using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminApiService _adminService;

        public AdminController(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        // ===========================
        // GET ALL ARTICLES
        // ===========================
        [HttpGet("articles")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _adminService.GetAllArticlesAsync();
            return Ok(articles);
        }

        // ===========================
        // APPROVE ARTICLE
        // ===========================
        [HttpPut("articles/approve/{id}")]
        public async Task<IActionResult> ApproveArticle(int id)
        {
            var result = await _adminService.ApproveArticleAsync(id);

            if (!result)
                return NotFound("Article Not Found");

            return Ok("Article Approved");
        }

        // ===========================
        // REJECT ARTICLE
        // ===========================
        [HttpPut("articles/reject/{id}")]
        public async Task<IActionResult> RejectArticle(int id)
        {
            var result = await _adminService.RejectArticleAsync(id);

            if (!result)
                return NotFound("Article Not Found");

            return Ok("Article Rejected");
        }

        // ===========================
        // DELETE ARTICLE
        // ===========================
        [HttpDelete("articles/{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var result = await _adminService.DeleteArticleAsync(id);

            if (!result)
                return NotFound("Article Not Found");

            return Ok("Article Deleted");
        }

        // ==================================================
        // QUERY MANAGEMENT (VIEW ISSUE)
        // ==================================================

        // Get All Queries
        [HttpGet("queries")]
        public async Task<IActionResult> GetAllQueries()
        {
            var queries = await _adminService.GetAllQueriesAsync();
            return Ok(queries);
        }

        // Get Query By Id
        [HttpGet("queries/{id}")]
        public async Task<IActionResult> GetQueryById(int id)
        {
            var query = await _adminService.GetQueryByIdAsync(id);

            if (query == null)
                return NotFound("Query Not Found");

            return Ok(query);
        }

        // Resolve Query (Add Solution + Update Status)
        [HttpPut("queries/resolve/{id}")]
        public async Task<IActionResult> ResolveQuery(int id, [FromBody] string solution)
        {
            var result = await _adminService.ResolveQueryAsync(id, solution);

            if (!result)
                return NotFound("Query Not Found");

            return Ok("Query Resolved Successfully");
        }


        // ==================================================
        // SOIL TEST MANAGEMENT
        // ==================================================

        // Get All Soil Tests
        [HttpGet("soiltests")]
        public async Task<IActionResult> GetAllSoilTests()
        {
            var soilTests = await _adminService.GetAllSoilTestsAsync();
            return Ok(soilTests);
        }

        // Get Soil Test By Id
        [HttpGet("soiltests/{id}")]
        public async Task<IActionResult> GetSoilTestById(int id)
        {
            var soilTest = await _adminService.GetSoilTestByIdAsync(id);

            if (soilTest == null)
                return NotFound("Soil Test Not Found");

            return Ok(soilTest);
        }

        // Update Soil Test Status
        [HttpPut("soiltests/status/{id}")]
        public async Task<IActionResult> UpdateSoilTestStatus(int id, [FromBody] string status)
        {
            var result = await _adminService.UpdateSoilTestStatusAsync(id, status);

            if (!result)
                return NotFound("Soil Test Not Found");

            return Ok("Soil Test Status Updated Successfully");
        }

        // Delete Soil Test
        [HttpDelete("soiltests/{id}")]
        public async Task<IActionResult> DeleteSoilTest(int id)
        {
            var result = await _adminService.DeleteSoilTestAsync(id);

            if (!result)
                return NotFound("Soil Test Not Found");

            return Ok("Soil Test Deleted Successfully");
        }

        // ===================== EXPERT MANAGEMENT =====================

        // Get All Experts
        [HttpGet("experts")]
        public async Task<IActionResult> GetAllExperts()
        {
            var experts = await _adminService.GetAllExpertsAsync();
            return Ok(experts);
        }

        // Get Expert By Id
        [HttpGet("experts/{id}")]
        public async Task<IActionResult> GetExpertById(int id)
        {
            var expert = await _adminService.GetExpertByIdAsync(id);
            if (expert == null)
                return NotFound("Expert Not Found");

            return Ok(expert);
        }

        // Delete Expert
        [HttpDelete("experts/{id}")]
        public async Task<IActionResult> DeleteExpert(int id)
        {
            var result = await _adminService.DeleteExpertAsync(id);

            if (!result)
                return BadRequest("Cannot delete expert: may have related advice or not exist");

            return Ok("Expert Deleted Successfully");
        }


        // ===================== FARMER MANAGEMENT =====================
        [HttpGet("farmers")]
        public async Task<IActionResult> GetAllFarmers()
        {
            var farmers = await _adminService.GetAllFarmersAsync();
            return Ok(farmers);
        }

        [HttpGet("farmers/{id}")]
        public async Task<IActionResult> GetFarmerById(int id)
        {
            var farmer = await _adminService.GetFarmerByIdAsync(id);
            if (farmer == null)
                return NotFound("Farmer Not Found");

            return Ok(farmer);
        }

        [HttpDelete("farmers/{id}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            var result = await _adminService.DeleteFarmerAsync(id);

            if (!result)
                return BadRequest("Cannot delete farmer: may have related queries, soil tests, or expert advices");

            return Ok("Farmer Deleted Successfully");
        }

        // ===================== FARMER RELATED DATA =====================

        // Get all queries submitted by a farmer
        [HttpGet("farmers/{id}/queries")]
        public async Task<IActionResult> GetFarmerQueries(int id)
        {
            var queries = await _adminService.GetFarmerQueriesAsync(id);
            return Ok(queries);
        }

        // Get all soil tests submitted by a farmer
        [HttpGet("farmers/{id}/soiltests")]
        public async Task<IActionResult> GetFarmerSoilTests(int id)
        {
            var soilTests = await _adminService.GetFarmerSoilTestsAsync(id);
            return Ok(soilTests);
        }

        // Get all expert advices requested by a farmer
        [HttpGet("farmers/{id}/expertadvices")]
        public async Task<IActionResult> GetFarmerExpertAdvices(int id)
        {
            var advices = await _adminService.GetFarmerExpertAdvicesAsync(id);
            return Ok(advices);
        }


        // ===================== STAFF MANAGEMENT =====================
        [HttpGet("staffs")]
        public async Task<IActionResult> GetAllStaff()
        {
            var staffs = await _adminService.GetAllStaffAsync();
            return Ok(staffs);
        }

        [HttpGet("staffs/{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _adminService.GetStaffByIdAsync(id);
            if (staff == null)
                return NotFound("Staff Not Found");

            return Ok(staff);
        }

        [HttpDelete("staffs/{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var result = await _adminService.DeleteStaffAsync(id);

            if (!result)
                return BadRequest("Cannot delete staff: may have related records or not exist");

            return Ok("Staff Deleted Successfully");
        }
    }
}
