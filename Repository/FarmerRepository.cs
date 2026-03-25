using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.EntityFrameworkCore;

namespace AgriIntel_Advisory_System.Repository
{
    public class FarmerRepository : FarmerInterface
    {
        private readonly AppDbContext _context;

        public FarmerRepository(AppDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // ---------------- MY PROFILE -------------------------
        // =====================================================

        public async Task<FarmerM?> GetFarmerByIdAsync(int farmerId)
        {
            return await _context.Farmers
                .FirstOrDefaultAsync(f => f.FarmerId == farmerId);
        }

       


        // =====================================================
        // ---------------- QUERIES ----------------------------
        // =====================================================

        public async Task SubmitQueryAsync(QueryM query)
        {
            query.CreationDate = DateTime.UtcNow;
            query.Status = "Pending";

            await _context.Queries.AddAsync(query);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QueryM>> GetMyQueriesAsync(int farmerId)
        {
            return await _context.Queries
                .Where(q => q.FarmerId == farmerId)
                .OrderByDescending(q => q.CreationDate)
                .ToListAsync();
        }

    

        // =====================================================
        // ---------------- SOIL TEST --------------------------
        // =====================================================

        public async Task SubmitSoilTestAsync(SoilTestingM soilTest)
        {
            soilTest.ApplicationDate = DateTime.UtcNow;
            soilTest.Status = "Pending";

            await _context.SoilTestings.AddAsync(soilTest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SoilTestingM>> GetMySoilTestsAsync(int farmerId)
        {
            return await _context.SoilTestings
                .Where(s => s.FarmerId == farmerId)
                .OrderByDescending(s => s.ApplicationDate)
                .ToListAsync();
        }

      

        // =====================================================
        // ---------------- EXPERT ADVICE ----------------------
        // =====================================================

        public async Task SubmitExpertAdviceAsync(ExpertAdviceM advice)
        {
            advice.RequestDate = DateTime.UtcNow;
            advice.Status = "Pending";

            await _context.ExpertAdvices.AddAsync(advice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpertAdviceM>> GetMyExpertAdvicesAsync(int farmerId)
        {
            return await _context.ExpertAdvices
                .Where(a => a.FarmerId == farmerId)
                .OrderByDescending(a => a.RequestDate)
                .ToListAsync();
        }

       
    }
}