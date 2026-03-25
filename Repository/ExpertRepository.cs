using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.EntityFrameworkCore;

namespace AgriIntel_Advisory_System.Repository
{
    public class ExpertRepository : ExpertInterface
    {
        private readonly AppDbContext _context;

        public ExpertRepository(AppDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // ✅ PROFILE (ADD THIS)
        // =====================================================

        public async Task<ExpertM?> GetExpertByIdAsync(int expertId)
        {
            return await _context.Experts
                .FirstOrDefaultAsync(e => e.ExpertId == expertId);
        }


        // =====================================================
        // EXPERT ADVICE
        // =====================================================

        public async Task<IEnumerable<ExpertAdviceM>> GetPendingAdviceAsync()
        {
            return await _context.ExpertAdvices
                .Where(a => a.Status == "Pending")
                .OrderByDescending(a => a.RequestDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExpertAdviceM>> GetResolvedAdviceAsync()
        {
            return await _context.ExpertAdvices
                .Where(a => a.Status == "Resolved")
                .OrderByDescending(a => a.ResponseDate)
                .ToListAsync();
        }

        public async Task SubmitAdviceAsync(int adviceId, int expertId, string advice)
        {
            var request = await _context.ExpertAdvices
                .FirstOrDefaultAsync(a => a.AdviceId == adviceId);

            if (request != null)
            {
                request.ExpertId = expertId;
                request.Advice = advice;
                request.ResponseDate = DateTime.Now;
                request.Status = "Resolved";

                await _context.SaveChangesAsync();
            }
        }


        // =====================================================
        // ARTICLES
        // =====================================================

        public async Task<IEnumerable<ArticleM>> GetAllArticlesAsync()
        {
            return await _context.Articles
                .OrderByDescending(a => a.ArticleId)
                .ToListAsync();
        }

        public async Task AddArticleAsync(ArticleM article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int articleId)
        {
            var article = await _context.Articles.FindAsync(articleId);

            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }


        // =====================================================
        // SOIL TEST
        // =====================================================

        // ✅ Get only pending soil tests
        public async Task<IEnumerable<SoilTestingM>> GetPendingSoilTestsAsync()
        {
            return await _context.SoilTestings
                .Where(s => s.Status == "Pending")
                .OrderByDescending(s => s.ApplicationDate)
                .ToListAsync();
        }

        // ✅ Get completed soil tests (history)
        public async Task<IEnumerable<SoilTestingM>> GetCompletedSoilTestsAsync()
        {
            return await _context.SoilTestings
                .Where(s => s.Status == "Completed")
                .OrderByDescending(s => s.ApplicationDate)
                .ToListAsync();
        }

        // ✅ Update soil test → add health card → mark completed
        public async Task UpdateSoilTestAsync(int testId, string healthCardNo)
        {
            var test = await _context.SoilTestings
                .FirstOrDefaultAsync(s => s.TestId == testId);

            if (test != null)
            {
                test.HealthCardNo = healthCardNo;
                test.Status = "Completed";

                await _context.SaveChangesAsync();
            }
        }
    }
}