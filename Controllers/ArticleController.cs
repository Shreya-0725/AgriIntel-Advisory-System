using Microsoft.AspNetCore.Mvc;
using AgriIntel_Advisory_System.Services;
using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Interface;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleApiService _articleService;

        public ArticleController(ArticleApiService articleService)
        {
            _articleService = articleService;
        }

        // ✅ GET: api/article
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleService.GetAllAsync();
            return Ok(articles);
        }

        // ✅ GET: api/article/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article == null)
                return NotFound("Article not found");

            return Ok(article);
        }

        // ✅ POST: api/article
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleM article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _articleService.AddAsync(article);

            return Ok(new { message = "Article created successfully" });
        }

        // ✅ PUT: api/article
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ArticleM article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _articleService.UpdateAsync(article);

            return Ok(new { message = "Article updated successfully" });
        }

        // ✅ DELETE: api/article/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _articleService.DeleteAsync(id);

            return Ok(new { message = "Article deleted successfully" });
        }
    }
}