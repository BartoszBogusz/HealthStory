using HealthStory.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthStory.Web.Infrastructure
{
    public class HealthStoryContext : DbContext
    {
        public HealthStoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<BloodTestSubstance> BloodTestsSubstances { get; set; }
        public DbSet<SubstanceInfo> SubstanceInfo { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AppUser
            modelBuilder.Entity<AppUser>()
                .HasKey(x => x.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(x => x.BloodTests)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);

            // BloodTest
            modelBuilder.Entity<BloodTest>()
                .HasKey(x => x.BloodTestId);
            modelBuilder.Entity<BloodTest>()
                .HasMany(x => x.BloodTestSubstances)
                .WithOne(x => x.BloodTest)
                .HasForeignKey(x => x.BloodTestId);

            // BloodTestSubstance
            modelBuilder.Entity<BloodTestSubstance>()
                .HasKey(x => x.BloodTestSubstanceId);
            modelBuilder.Entity<BloodTestSubstance>()
                .HasOne(x => x.SubstanceInfo)
                .WithMany(x => x.BloodTestSubstances)
                .HasForeignKey(x => x.SubstanceInfoId);

            // SubstanceInfo
            modelBuilder.Entity<SubstanceInfo>()
                .HasKey(x => x.SubstanceInfoId);

            //Units
            modelBuilder.Entity<Unit>()
                .HasKey(x => x.UnitId);
        }
    }
}
