using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;

namespace AgriIntel_Advisory_System.Repository
{
    public class RegisterRepository : RegisterInterface
    {
        private readonly AppDbContext _context;

        public RegisterRepository(AppDbContext context)
        {
            _context = context;
        }

        /* ================= FARMER ================= */

        public async Task RegisterFarmerAsync(FarmerM farmer)
        {
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();
        }

        /* ================= EXPERT ================= */

        public async Task RegisterExpertAsync(ExpertM expert)
        {
            _context.Experts.Add(expert);
            await _context.SaveChangesAsync();
        }

        /* ================= STAFF ================= */

        public async Task RegisterStaffAsync(StaffM staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
        }

        /* ================= KISAN KENDRA ================= */

        public async Task RegisterKendraAsync(KisanKendraM kendra)
        {
            _context.KisanKendras.Add(kendra);
            await _context.SaveChangesAsync();
        }
    }
}
