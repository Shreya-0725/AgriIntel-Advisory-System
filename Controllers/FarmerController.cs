using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Mvc;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Authorization;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Farmer")]
    public class FarmerController : ControllerBase
    {
        private readonly FarmerInterface _farmerRepo;

        public FarmerController(FarmerInterface farmerRepo)
        {
            _farmerRepo = farmerRepo;
        }


        // -------- GET PROFILE --------
        [HttpGet("profile/{farmerId}")]
        public async Task<IActionResult> GetProfile(int farmerId)   // ✅ changed to int
        {
            var farmer = await _farmerRepo.GetFarmerByIdAsync(farmerId);
            return Ok(farmer);
        }

     
        // -------- SUBMIT QUERY --------
        [HttpPost("query")]
        public async Task<IActionResult> SubmitQuery(QueryM query)
        {
            await _farmerRepo.SubmitQueryAsync(query);
            return Ok("Query Submitted");
        }

        // -------- GET MY QUERIES --------
        [HttpGet("queries/{farmerId}")]
        public async Task<IActionResult> GetMyQueries(int farmerId)   // ✅ changed to int
        {
            var queries = await _farmerRepo.GetMyQueriesAsync(farmerId);
            return Ok(queries);
        }



        // -------- SUBMIT SOIL TEST --------
        [HttpPost("soiltest")]
        public async Task<IActionResult> SubmitSoilTest(SoilTestingM soilTest)
        {
            await _farmerRepo.SubmitSoilTestAsync(soilTest);
            return Ok("Soil Test Submitted");
        }

        // -------- GET MY SOIL TESTS --------
        [HttpGet("soiltests/{farmerId}")]
        public async Task<IActionResult> GetMySoilTests(int farmerId)   // ✅ changed to int
        {
            var tests = await _farmerRepo.GetMySoilTestsAsync(farmerId);
            return Ok(tests);
        }



        // -------- SUBMIT EXPERT ADVICE --------
        [HttpPost("expertadvice")]
        public async Task<IActionResult> SubmitExpertAdvice(ExpertAdviceM advice)
        {
            await _farmerRepo.SubmitExpertAdviceAsync(advice);
            return Ok("Expert Advice Request Submitted");
        }

        // -------- GET MY EXPERT ADVICES --------
        [HttpGet("expertadvices/{farmerId}")]
        public async Task<IActionResult> GetMyExpertAdvices(int farmerId)
        {
            var advices = await _farmerRepo.GetMyExpertAdvicesAsync(farmerId);
            return Ok(advices);
        }


    }
}