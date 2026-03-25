using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.AspNetCore.Mvc;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Authorization;

namespace AgriIntel_Advisory_System.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Expert")]
     public class ExpertController : ControllerBase
    {
        private readonly ExpertInterface _expertRepo;

        public ExpertController(ExpertInterface expertRepo)
        {
            _expertRepo = expertRepo;
        }

        // =====================================================
        // MY PROFILE
        // =====================================================

        [HttpGet("profile/{expertId}")]
        public async Task<IActionResult> GetExpertProfile(int expertId)
        {
            var expert = await _expertRepo.GetExpertByIdAsync(expertId);

            if (expert == null)
                return NotFound("Expert not found");

            return Ok(expert);
        }



        // =====================================================
        // EXPERT ADVICE
        // =====================================================

        [HttpGet("advice/pending")]
        public async Task<IActionResult> GetPendingAdvice()
        {
            var result = await _expertRepo.GetPendingAdviceAsync();
            return Ok(result);
        }

        [HttpGet("advice/resolved")]
        public async Task<IActionResult> GetResolvedAdvice()
        {
            var result = await _expertRepo.GetResolvedAdviceAsync();
            return Ok(result);
        }

        [HttpPost("advice/{adviceId}")]
        public async Task<IActionResult> SubmitAdvice(
            int adviceId,
            [FromQuery] int expertId,
            [FromBody] string advice)
        {
            await _expertRepo.SubmitAdviceAsync(adviceId, expertId, advice);
            return Ok("Advice submitted successfully");
        }

        // =====================================================
        // ARTICLES
        // =====================================================

        [HttpGet("articles")]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _expertRepo.GetAllArticlesAsync();
            return Ok(result);
        }

        [HttpPost("articles")]
        public async Task<IActionResult> AddArticle([FromBody] ArticleM article)
        {
            await _expertRepo.AddArticleAsync(article);
            return Ok("Article added successfully");
        }

        [HttpDelete("articles/{articleId}")]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            await _expertRepo.DeleteArticleAsync(articleId);
            return Ok("Article deleted successfully");
        }

        // =====================================================
        // SOIL TEST
        // =====================================================

        // ✅ Get Pending Soil Tests
        [HttpGet("soiltests/pending")]
        public async Task<IActionResult> GetPendingSoilTests()
        {
            var result = await _expertRepo.GetPendingSoilTestsAsync();
            return Ok(result);
        }

        // ✅ Get Completed Soil Tests
        [HttpGet("soiltests/completed")]
        public async Task<IActionResult> GetCompletedSoilTests()
        {
            var result = await _expertRepo.GetCompletedSoilTestsAsync();
            return Ok(result);
        }

        // ✅ Update Soil Test (Add HealthCardNo + Mark Completed)
        [HttpPut("soiltests/{testId}")]
        public async Task<IActionResult> UpdateSoilTest(
            int testId,
            [FromBody] string healthCardNo)
        {
            await _expertRepo.UpdateSoilTestAsync(testId, healthCardNo);
            return Ok("Soil Test Updated Successfully");
        }

    }
}