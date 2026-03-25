using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface ExpertInterface
    {


        // ================= PROFILE =================
        Task<ExpertM?> GetExpertByIdAsync(int expertId);



        // ================= ADVICE =================
        Task<IEnumerable<ExpertAdviceM>> GetPendingAdviceAsync();
        Task<IEnumerable<ExpertAdviceM>> GetResolvedAdviceAsync();
        Task SubmitAdviceAsync(int adviceId, int expertId, string advice);

        // ================= ARTICLES =================
        Task<IEnumerable<ArticleM>> GetAllArticlesAsync();
        Task AddArticleAsync(ArticleM article);
        Task DeleteArticleAsync(int articleId);

        // ================= SOIL TEST =================
        Task<IEnumerable<SoilTestingM>> GetPendingSoilTestsAsync();

        Task<IEnumerable<SoilTestingM>> GetCompletedSoilTestsAsync();

        Task UpdateSoilTestAsync(int testId, string healthCardNo);
    }
}