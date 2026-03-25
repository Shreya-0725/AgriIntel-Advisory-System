using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriIntel_Advisory_System.Interface
{
    public interface AdminInterface
    {

        // ===============================
        // FARMER MANAGEMENT
        // ===============================
        Task<List<FarmerM>> GetAllFarmersAsync();                   // Get all farmers
        Task<FarmerM?> GetFarmerByIdAsync(int id);                 // Get farmer by ID
        Task<bool> DeleteFarmerAsync(int id);                      // Delete farmer (with history check)
        Task<List<QueryM>> GetFarmerQueriesAsync(int farmerId);    // Get queries submitted by the farmer
        Task<List<SoilTestingM>> GetFarmerSoilTestsAsync(int farmerId); // Get soil tests submitted by the farmer
        Task<List<ExpertAdviceM>> GetFarmerExpertAdvicesAsync(int farmerId); // Get expert advices requested by the farmer




        // EXPERT MANAGEMENT
        Task<List<ExpertM>> GetAllExpertsAsync();
        Task<ExpertM?> GetExpertByIdAsync(int id);
        Task<bool> DeleteExpertAsync(int id);





        // ===============================
        // ARTICLE MANAGEMENT
        // ===============================

        Task<List<ArticleM>> GetAllArticlesAsync();
        Task<ArticleM?> GetArticleByIdAsync(int id);
        Task<bool> ApproveArticleAsync(int id);
        Task<bool> RejectArticleAsync(int id);
        Task<bool> DeleteArticleAsync(int id);

        // ==================================================
        // QUERY / VIEW ISSUE MANAGEMENT
        // ==================================================

        // Get all queries for admin "View Issue" page
        Task<List<QueryM>> GetAllQueriesAsync();
        Task<QueryM?> GetQueryByIdAsync(int id);
        Task<bool> ResolveQueryAsync(int queryId, string solution);


        // ===============================
        // SOIL TEST MANAGEMENT
        // ===============================

        Task<List<SoilTestingM>> GetAllSoilTestsAsync();

        Task<SoilTestingM?> GetSoilTestByIdAsync(int id);

        // Admin updates status only
        Task<bool> UpdateSoilTestStatusAsync(int testId, string status);

        // Optional
        Task<bool> DeleteSoilTestAsync(int testId);



        // ===================== STAFF MANAGEMENT =====================
        Task<List<StaffM>> GetAllStaffAsync();
        Task<StaffM?> GetStaffByIdAsync(int id);
        Task<bool> DeleteStaffAsync(int id);

    }




}