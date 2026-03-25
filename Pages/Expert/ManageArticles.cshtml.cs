using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Expert
{
    public class ManageArticlesModel : PageModel
    {
        private readonly ArticleApiService _articleService;

        public ManageArticlesModel(ArticleApiService articleService)
        {
            _articleService = articleService;
        }

        public List<ArticleM> Articles { get; set; } = new();

        [BindProperty]
        public ArticleM Article { get; set; } = new();

        // Load Articles
        public async Task OnGetAsync()
        {
            Articles = await _articleService.GetAllAsync();
        }

        // Add Article
        public async Task<IActionResult> OnPostAsync()
        {
            await _articleService.AddAsync(Article);
            return RedirectToPage();
        }

        // Delete Article
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _articleService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}