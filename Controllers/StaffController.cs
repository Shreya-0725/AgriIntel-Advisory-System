using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Mvc;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Authorization;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Staff")]
    public class StaffController : ControllerBase
    {
        private readonly StaffInterface _staffRepo;

        public StaffController(StaffInterface staffRepo)
        {
            _staffRepo = staffRepo;
        }

        // -------- GET STAFF PROFILE --------
        [HttpGet("profile/{empId}")]
        public async Task<IActionResult> GetProfile(int empId)
        {
            var staff = await _staffRepo.GetStaffByIdAsync(empId);

            if (staff == null)
                return NotFound();

            return Ok(staff);
        }


        // -------- GET ALL QUERIES --------
        [HttpGet("queries")]
        public async Task<IActionResult> GetAllQueries()
        {
            var queries = await _staffRepo.GetAllQueriesAsync();
            return Ok(queries);
        }

        // -------- GET PENDING QUERIES --------
        [HttpGet("queries/pending")]
        public async Task<IActionResult> GetPendingQueries()
        {
            var queries = await _staffRepo.GetPendingQueriesAsync();
            return Ok(queries);
        }

        // -------- GET RESOLVED QUERIES --------
        [HttpGet("queries/resolved")]
        public async Task<IActionResult> GetResolvedQueries()
        {
            var queries = await _staffRepo.GetResolvedQueriesAsync();
            return Ok(queries);
        }

        // -------- GET QUERY BY ID --------
        [HttpGet("queries/{queryId}")]
        public async Task<IActionResult> GetQuery(int queryId)
        {
            var query = await _staffRepo.GetQueryByIdAsync(queryId);

            if (query == null)
                return NotFound();

            return Ok(query);
        }

        // -------- SUBMIT SOLUTION --------
        [HttpPost("queries/{queryId}/solution")]
        public async Task<IActionResult> SubmitSolution(
            int queryId,
            [FromBody] string solution)
        {
            await _staffRepo.SubmitSolutionAsync(queryId, solution);
            return Ok("Solution Submitted Successfully");
        }
    }
}