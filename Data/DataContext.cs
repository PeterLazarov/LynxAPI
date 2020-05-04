using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProvinceCaseDataModel> ProvinceData { get; set; }
        public DbSet<ProvinceCaseDayDataModel> ProvinceDayData { get; set; }
        public DbSet<CombinedDailyCaseModel> CombinedDailyCases { get; set; }
        public DbSet<RegionCaseDataModel> RegionData { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<CaseUpdateModel> CaseUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProvinceCaseDataModel>().ToTable("PROVINCE_CASE_DATA");
            modelBuilder.Entity<ProvinceCaseDayDataModel>().ToTable("PROVINCE_CASE_DAY_DATA");
            modelBuilder.Entity<RegionCaseDataModel>().ToTable("REGION_CASE_DATA");
            modelBuilder.Entity<PatientModel>().ToTable("PATIENT");
            modelBuilder.Entity<CaseUpdateModel>().ToTable("CASE_UPDATE");
            modelBuilder.Entity<CombinedDailyCaseModel>().HasNoKey().ToView("v_PROVINCE_COMBINED_DAILY_CASE_DATA");
        }
    }
}