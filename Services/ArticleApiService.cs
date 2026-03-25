using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Services
{
    public class ArticleApiService
    {
        private readonly ArticleInterface _articleRepository;

        public ArticleApiService(ArticleInterface articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<ArticleM>> GetAllAsync()
        {
            return await _articleRepository.GetAllAsync();
        }

        public async Task<ArticleM?> GetByIdAsync(int id)
        {
            return await _articleRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ArticleM article)
        {
            await _articleRepository.AddAsync(article);
        }

        public async Task UpdateAsync(ArticleM article)
        {
            await _articleRepository.UpdateAsync(article);
        }

        public async Task DeleteAsync(int id)
        {
            await _articleRepository.DeleteAsync(id);
        }
    }
}