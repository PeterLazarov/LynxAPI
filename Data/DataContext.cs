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

        public DbSet<ProvinceCaseData> ProvinceData { get; set; }
        public DbSet<RegionCaseData> RegionData { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<CaseUpdate> CaseUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProvinceCaseData>().ToTable("PROVINCE_CASE_DATA");
            modelBuilder.Entity<RegionCaseData>().ToTable("REGION_CASE_DATA");
            modelBuilder.Entity<Patient>().ToTable("PATIENT");
            modelBuilder.Entity<CaseUpdate>().ToTable("CASE_UPDATE");
        }
    }
}