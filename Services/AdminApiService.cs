using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;

namespace AgriIntel_Advisory_System.Services
{
    public class AdminApiService
    {
        private readonly AdminInterface _adminRepository;

        public AdminApiService(AdminInterface adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // ===============================
        // Get All Articles
        // ===============================
        public async Task<List<ArticleM>> GetAllArticlesAsync()
        {
            return await _adminRepository.GetAllArticlesAsync();
        }

        // ===============================
        // Get Article By Id
        // ===============================
        public async Task<ArticleM?> GetArticleByIdAsync(int id)
        {
            return await _adminRepository.GetArticleByIdAsync(id);
        }

        // ===============================
        // Approve Article
        // ===============================
        public async Task<bool> ApproveArticleAsync(int id)
        {
            return await _adminRepository.ApproveArticleAsync(id);
        }

        // ===============================
        // Reject Article
        // ===============================
        public async Task<bool> RejectArticleAsync(int id)
        {
            return await _adminRepository.RejectArticleAsync(id);
        }

        // ===============================
        // Delete Article
        // ===============================
        public async Task<bool> DeleteArticleAsync(int id)
        {
            return await _adminRepository.DeleteArticleAsync(id);
        }


        // ==================================================
        // QUERY MANAGEMENT (VIEW ISSUE)
        // ==================================================

        // Get All Queries
        public async Task<List<QueryM>> GetAllQueriesAsync()
        {
            return await _adminRepository.GetAllQueriesAsync();
        }

        // Get Query By Id
        public async Task<QueryM?> GetQueryByIdAsync(int id)
        {
            return await _adminRepository.GetQueryByIdAsync(id);
        }

        // Resolve Query
        public async Task<bool> ResolveQueryAsync(int queryId, string solution)
        {
            return await _adminRepository.ResolveQueryAsync(queryId, solution);
        }



        // ==================================================
        // SOIL TEST MANAGEMENT
        // ==================================================

        // Get All Soil Tests
        public async Task<List<SoilTestingM>> GetAllSoilTestsAsync()
        {
            return await _adminRepository.GetAllSoilTestsAsync();
        }

        // Get Soil Test By Id
        public async Task<SoilTestingM?> GetSoilTestByIdAsync(int id)
        {
            return await _adminRepository.GetSoilTestByIdAsync(id);
        }

        // Update Soil Test Status
        public async Task<bool> UpdateSoilTestStatusAsync(int testId, string status)
        {
            return await _adminRepository.UpdateSoilTestStatusAsync(testId, status);
        }

        // Delete Soil Test
        public async Task<bool> DeleteSoilTestAsync(int testId)
        {
            return await _adminRepository.DeleteSoilTestAsync(testId);
        }

        // =============================== EXPERT MANAGEMENT ====================

        // Get All Experts
        public async Task<List<ExpertM>> GetAllExpertsAsync()
        {
            return await _adminRepository.GetAllExpertsAsync();
        }

        // Get Expert By Id
        public async Task<ExpertM?> GetExpertByIdAsync(int id)
        {
            return await _adminRepository.GetExpertByIdAsync(id);
        }

       
        // Delete Expert
        public async Task<bool> DeleteExpertAsync(int id)
        {
            return await _adminRepository.DeleteExpertAsync(id);
        }


        // =============================== FARMERS ===============================
        public async Task<List<FarmerM>> GetAllFarmersAsync()
            => await _adminRepository.GetAllFarmersAsync();

        public async Task<FarmerM?> GetFarmerByIdAsync(int id)
            => await _adminRepository.GetFarmerByIdAsync(id);

        public async Task<bool> DeleteFarmerAsync(int id)
            => await _adminRepository.DeleteFarmerAsync(id);

        public async Task<List<QueryM>> GetFarmerQueriesAsync(int farmerId)
            => await _adminRepository.GetFarmerQueriesAsync(farmerId);

        public async Task<List<SoilTestingM>> GetFarmerSoilTestsAsync(int farmerId)
            => await _adminRepository.GetFarmerSoilTestsAsync(farmerId);

        public async Task<List<ExpertAdviceM>> GetFarmerExpertAdvicesAsync(int farmerId)
            => await _adminRepository.GetFarmerExpertAdvicesAsync(farmerId);



        // ===================== STAFF MANAGEMENT =====================
        public async Task<List<StaffM>> GetAllStaffAsync()
        {
            return await _adminRepository.GetAllStaffAsync();
        }

        public async Task<StaffM?> GetStaffByIdAsync(int id)
        {
            return await _adminRepository.GetStaffByIdAsync(id);
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            return await _adminRepository.DeleteStaffAsync(id);
        }
    }
}