using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.EntityFrameworkCore;

namespace AgriIntel_Advisory_System.Repository
{
    public class StaffRepository : StaffInterface
    {
        private readonly AppDbContext _context;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<StaffM?> GetStaffByIdAsync(int empId)
        {
            return await _context.Staffs
                .FirstOrDefaultAsync(s => s.EmpId == empId);
        }


        // ---------------- QUERY MANAGEMENT ----------------

        public async Task<IEnumerable<QueryM>> GetAllQueriesAsync()
        {
            return await _context.Queries
                .OrderByDescending(q => q.CreationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<QueryM>> GetPendingQueriesAsync()
        {
            return await _context.Queries
                .Where(q => q.Status == "Pending")
                .OrderByDescending(q => q.CreationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<QueryM>> GetResolvedQueriesAsync()
        {
            return await _context.Queries
                .Where(q => q.Status == "Resolved")
                .OrderByDescending(q => q.CreationDate)
                .ToListAsync();
        }

        public async Task<QueryM?> GetQueryByIdAsync(int queryNo)
        {
            return await _context.Queries
                .FirstOrDefaultAsync(q => q.QueryNo == queryNo);
        }

        public async Task SubmitSolutionAsync(int queryNo, string solution)
        {
            var query = await _context.Queries
                .FirstOrDefaultAsync(q => q.QueryNo == queryNo);

            if (query != null)
            {
                query.Solution = solution;
                query.SolutionDate = DateTime.UtcNow;
                query.Status = "Resolved";

                _context.Queries.Update(query);
                await _context.SaveChangesAsync();
            }
        }
    }
}