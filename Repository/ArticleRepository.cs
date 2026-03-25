using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgriIntel_Advisory_System.Data;

namespace AgriIntel_Advisory_System.Repository
{
    public class ArticleRepository : ArticleInterface
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArticleM>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<ArticleM?> GetByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task AddAsync(ArticleM article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ArticleM article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
    }
}

