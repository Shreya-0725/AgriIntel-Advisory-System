using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface FarmerInterface
    {
      

        // -------- MY PROFILE --------
        Task<FarmerM?> GetFarmerByIdAsync(int farmerId);   // ✅ changed to int
   

        // -------- QUERIES --------
        Task SubmitQueryAsync(QueryM query);
        Task<IEnumerable<QueryM>> GetMyQueriesAsync(int farmerId);   // ✅ changed to int
       

        // -------- SOIL TEST --------
        Task SubmitSoilTestAsync(SoilTestingM soilTest);
        Task<IEnumerable<SoilTestingM>> GetMySoilTestsAsync(int farmerId);   // ✅ changed to int
   

        // -------- EXPERT ADVICE --------
        Task SubmitExpertAdviceAsync(ExpertAdviceM advice);
        Task<IEnumerable<ExpertAdviceM>> GetMyExpertAdvicesAsync(int farmerId);
     
    }
}