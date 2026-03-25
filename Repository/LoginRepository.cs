using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Model;
using AgriIntel_Advisory_System.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AgriIntel_Advisory_System.Repository
{
    public class LoginRepository : LoginInterface
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

    
        /*  FARMER LOGIN */
     

        public async Task<FarmerM?> LoginFarmerAsync(string mobileNo, string password)
        {
            return await _context.Farmers
                .Where(f => f.MobileNo == mobileNo && f.Password == password)
                .Select(f => new FarmerM
                {
                    FarmerId = f.FarmerId,
                    FirstName = f.FirstName,
                    MobileNo = f.MobileNo
                })
                .FirstOrDefaultAsync();
        }

   
        /* EXPERT LOGIN*/
        

        public async Task<ExpertM?> LoginExpertAsync(string email, string password)
        {
            return await _context.Experts
                .Where(e => e.Email == email && e.Password == password)
                .Select(e => new ExpertM
                {
                    ExpertId = e.ExpertId,
                    FirstName = e.FirstName,
                    Email = e.Email
                })
                .FirstOrDefaultAsync();
        }

      
        /* STAFF LOGIN */
     

        public async Task<StaffM?> LoginStaffAsync(string email, string password)
        {
            return await _context.Staffs
                .Where(s => s.Email == email && s.Password == password)
                .Select(s => new StaffM
                {
                    EmpId = s.EmpId,
                    FirstName = s.FirstName,
                    Email = s.Email
                })
                .FirstOrDefaultAsync();
        }


        /* KENDRA LOGIN */
       

        public async Task<KisanKendraM?> LoginKendraAsync(string mobileNo, string password)
        {
            return await _context.KisanKendras
                .Where(k => k.MobileNo == mobileNo && k.Password == password)
                .Select(k => new KisanKendraM
                {
                    KKId = k.KKId,
                    OwnerName = k.OwnerName,
                    MobileNo = k.MobileNo
                })
                .FirstOrDefaultAsync();
        }
    }
}