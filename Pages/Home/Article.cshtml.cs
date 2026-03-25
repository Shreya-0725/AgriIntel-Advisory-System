using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriIntel_Advisory_System.Pages.Home
{
    public class ArticleModel : PageModel
    {
        private readonly ArticleApiService _service;

        public ArticleModel(ArticleApiService service)
        {
            _service = service;
        }

        // All Articles (Paginated)
        public List<ArticleM> Articles { get; set; } = new();

        // Selected Article (For Read More)
        public ArticleM? SelectedArticle { get; set; }

        // Pagination
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 6;
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int? id = null)
        {
            var allArticles = await _service.GetAllAsync();

            // ✅ If Read More Clicked
            if (id != null)
            {
                SelectedArticle = await _service.GetByIdAsync(id.Value);
            }

            // ✅ Pagination Logic
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(allArticles.Count / (double)PageSize);

            Articles = allArticles
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}