using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface StaffInterface
    {
       

        // ---------------- PROFILE ----------------
        Task<StaffM?> GetStaffByIdAsync(int empId);
       



        // ---------------- QUERY MANAGEMENT ----------------
        Task<IEnumerable<QueryM>> GetAllQueriesAsync();
        Task<IEnumerable<QueryM>> GetPendingQueriesAsync();
        Task<IEnumerable<QueryM>> GetResolvedQueriesAsync();
        Task<QueryM?> GetQueryByIdAsync(int queryNo);

        Task SubmitSolutionAsync(int queryNo, string solution);
    }
}