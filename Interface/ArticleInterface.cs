using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface ArticleInterface
    {
        Task<List<ArticleM>> GetAllAsync();

        Task<ArticleM?> GetByIdAsync(int id);

        Task AddAsync(ArticleM article);

        Task UpdateAsync(ArticleM article);

        Task DeleteAsync(int id);
    }
}

