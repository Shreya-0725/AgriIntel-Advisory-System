using Microsoft.EntityFrameworkCore;
using AgriIntel_Advisory_System.Model;
using System.Collections.Generic;

namespace AgriIntel_Advisory_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       

        public DbSet<AdminM> Admins { get; set; }
        public DbSet<ArticleM> Articles { get; set; }
        public DbSet<StateM> States { get; set; }
        public DbSet<DistrictM> Districts { get; set; }
        public DbSet<VillageM> Villages { get; set; }
        public DbSet<ExpertM> Experts { get; set; }
        public DbSet<FarmerM> Farmers { get; set; }
        public DbSet<KisanKendraM> KisanKendras { get; set; }
        public DbSet<QueryM> Queries { get; set; }
        public DbSet<SoilTestingM> SoilTestings { get; set; }
        public DbSet<StaffM> Staffs { get; set; }
        public DbSet<ExpertAdviceM> ExpertAdvices { get; set; }

        


        public class Apisettings
        {
            public string BaseUrl { get; set; } = string.Empty;
        }

    }
}