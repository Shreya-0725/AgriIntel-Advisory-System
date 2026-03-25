using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using Microsoft.EntityFrameworkCore;

namespace AgriIntel_Advisory_System.Repository
{
    public class KKRepository : KisanKendraInterface
    {
        private readonly AppDbContext _context;

        public KKRepository(AppDbContext context)
        {
            _context = context;
        }

        // ================= GET KISAN KENDRA PROFILE =================

        public async Task<KisanKendraM?> GetKisanKendraProfileAsync(int kkId)
        {
            return await _context.KisanKendras
                .AsNoTracking()
                .Where(k => k.KKId == kkId)
                .Select(k => new KisanKendraM
                {
                    KKId = k.KKId,
                    StateCode = k.StateCode,
                    DistrictCode = k.DistrictCode,
                    Block = k.Block,
                    VillageCode = k.VillageCode,
                    OwnerName = k.OwnerName,
                    MobileNo = k.MobileNo,

                    State = k.State,
                    District = k.District,
                    Village = k.Village
                })
                .FirstOrDefaultAsync();
        }


        // ================= GET FARMERS (Basic Listing) =================
        public async Task<List<FarmerM>> GetFarmersByKisanKendraAsync(int kkId)
        {
            return await _context.Farmers
                .OrderByDescending(f => f.FarmerId)
                .ToListAsync();
        }
    }
}