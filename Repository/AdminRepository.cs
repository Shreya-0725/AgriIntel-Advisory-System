using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.EntityFrameworkCore;
using AgriIntel_Advisory_System.Data;

namespace AgriIntel_Advisory_System.Repository
{
    public class AdminRepository : AdminInterface
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // ================= ARTICLE MANAGEMENT =================
        // =====================================================

        public async Task<List<ArticleM>> GetAllArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<ArticleM?> GetArticleByIdAsync(int id)
        {
            return await _context.Articles
                .FirstOrDefaultAsync(a => a.ArticleId == id);
        }

        public async Task<bool> ApproveArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
                return false;

            // If you later add Status column:
            // article.Status = "Approved";

            _context.Articles.Update(article);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
                return false;

            // article.Status = "Rejected";

            _context.Articles.Update(article);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
                return false;

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // ================= QUERY MANAGEMENT ===================
        // =====================================================

        public async Task<List<QueryM>> GetAllQueriesAsync()
        {
            return await _context.Queries
                .Include(q => q.Farmer)
                .ToListAsync();
        }

        public async Task<QueryM?> GetQueryByIdAsync(int id)
        {
            return await _context.Queries
                .Include(q => q.Farmer)
                .FirstOrDefaultAsync(q => q.QueryNo == id);
        }

        public async Task<bool> ResolveQueryAsync(int queryId, string solution)
        {
            var query = await _context.Queries.FindAsync(queryId);

            if (query == null)
                return false;

            query.Solution = solution;
            query.SolutionDate = DateTime.Now;
            query.Status = "Resolved";

            await _context.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // ================= SOIL TEST MANAGEMENT ===============
        // =====================================================

        public async Task<List<SoilTestingM>> GetAllSoilTestsAsync()
        {
            return await _context.SoilTestings
                .Include(s => s.Farmer)
                .ToListAsync();
        }

        public async Task<SoilTestingM?> GetSoilTestByIdAsync(int id)
        {
            return await _context.SoilTestings
                .Include(s => s.Farmer)
                .FirstOrDefaultAsync(s => s.TestId == id);
        }

        public async Task<bool> UpdateSoilTestStatusAsync(int testId, string status)
        {
            var soilTest = await _context.SoilTestings
                .FirstOrDefaultAsync(s => s.TestId == testId);

            if (soilTest == null)
                return false;

            soilTest.Status = status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSoilTestAsync(int testId)
        {
            var soilTest = await _context.SoilTestings
                .FirstOrDefaultAsync(s => s.TestId == testId);

            if (soilTest == null)
                return false;

            _context.SoilTestings.Remove(soilTest);
            await _context.SaveChangesAsync();

            return true;
        }



        // ===================== EXPERT MANAGEMENT =====================
        public async Task<List<ExpertM>> GetAllExpertsAsync()
        {
            return await _context.Experts
                .Include(e => e.State)
                .Include(e => e.District)
                .ToListAsync();
        }

        public async Task<ExpertM?> GetExpertByIdAsync(int id)
        {
            return await _context.Experts
                .Include(e => e.State)
                .Include(e => e.District)
                .FirstOrDefaultAsync(e => e.ExpertId == id);
        }

        public async Task<bool> DeleteExpertAsync(int id)
        {
            var expert = await _context.Experts.FindAsync(id);
            if (expert == null)
                return false;

            // Check if expert has advice history
            bool hasHistory = await _context.ExpertAdvices.AnyAsync(e => e.ExpertId == id);
            if (hasHistory)
                return false; // cannot delete, handled gracefully

            _context.Experts.Remove(expert);
            await _context.SaveChangesAsync();
            return true;
        }


        // ===================== FARMER MANAGEMENT =====================
        public async Task<List<FarmerM>> GetAllFarmersAsync()
        {
            return await _context.Farmers
                .Include(f => f.State)
                .Include(f => f.District)
                .Include(f => f.Village)
                .ToListAsync();
        }

        public async Task<FarmerM?> GetFarmerByIdAsync(int id)
        {
            return await _context.Farmers
                .Include(f => f.State)
                .Include(f => f.District)
                .Include(f => f.Village)
                .FirstOrDefaultAsync(f => f.FarmerId == id);
        }

        public async Task<bool> DeleteFarmerAsync(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
                return false;

            // Check if farmer has history in Queries, SoilTests, or ExpertAdvices
            bool hasHistory = await _context.Queries.AnyAsync(q => q.FarmerId == id)
                              || await _context.SoilTestings.AnyAsync(s => s.FarmerId == id)
                              || await _context.ExpertAdvices.AnyAsync(a => a.FarmerId == id);

            if (hasHistory)
                return false; // Cannot delete due to existing history

            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QueryM>> GetFarmerQueriesAsync(int farmerId)
        {
            return await _context.Queries
                .Where(q => q.FarmerId == farmerId)
                .Include(q => q.Farmer)
                .ToListAsync();
        }

        public async Task<List<SoilTestingM>> GetFarmerSoilTestsAsync(int farmerId)
        {
            return await _context.SoilTestings
                .Where(s => s.FarmerId == farmerId)
                .Include(s => s.Farmer)
                .ToListAsync();
        }

        public async Task<List<ExpertAdviceM>> GetFarmerExpertAdvicesAsync(int farmerId)
        {
            return await _context.ExpertAdvices
                .Where(a => a.FarmerId == farmerId)
                .Include(a => a.Farmer)
                .Include(a => a.Expert)
                .ToListAsync();
        }

        // ===================== STAFF MANAGEMENT =====================
        public async Task<List<StaffM>> GetAllStaffAsync()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task<StaffM?> GetStaffByIdAsync(int id)
        {
            return await _context.Staffs
                .FirstOrDefaultAsync(s => s.EmpId == id);
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return false;

            // Check if staff has any dependent records if needed
            // Example: If staff is linked to some tasks or logs, add a check here
            // For now, assuming no constraints:
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}