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
        public DbSet<BloodTestInfo> BloodTestsInfo { get; set; }
        public DbSet<BloodTestSubstanceInfo> BloodTestsSubstancesInfo { get; set; }
        public DbSet<SubstanceInfo> SubstanceInfo { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AppUser
            modelBuilder.Entity<AppUser>()
                .HasKey(x => x.AppUserId);
            modelBuilder.Entity<AppUser>()
                .Property(f => f.AppUserId)
                .ValueGeneratedOnAdd();

            //Units
            modelBuilder.Entity<Unit>()
                .HasKey(x => x.UnitId);
            modelBuilder.Entity<Unit>()
                .Property(f => f.UnitId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Unit>()
                .HasMany(x => x.SubstanceInfo)
                .WithOne(x => x.Unit)
                .HasForeignKey(x => x.UnitId);

            // SubstanceInfo
            modelBuilder.Entity<SubstanceInfo>()
                .HasKey(x => x.SubstanceInfoId);
            modelBuilder.Entity<SubstanceInfo>()
                .Property(f => f.SubstanceInfoId)
                .ValueGeneratedOnAdd();

            // BloodTestInfo
            modelBuilder.Entity<BloodTestInfo>()
                .HasKey(x => x.BloodTestInfoId);
            modelBuilder.Entity<BloodTestInfo>()
                .Property(f => f.BloodTestInfoId)
                .ValueGeneratedOnAdd();

            // BloodTestInfo
            modelBuilder.Entity<BloodTestSubstanceInfo>()
                .HasKey(x => new { x.BloodTestInfoId, x.SubstanceInfoId });

        }
    }
}
