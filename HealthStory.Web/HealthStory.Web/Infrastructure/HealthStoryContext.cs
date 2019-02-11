using HealthStory.Web.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthStory.Web.Infrastructure
{
    public class HealthStoryContext : IdentityDbContext
    {
        public HealthStoryContext(DbContextOptions<HealthStoryContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserBloodTestValue> AppUserBloodTestValues { get; set; }
        public DbSet<BloodTestInfo> BloodTestsInfo { get; set; }
        public DbSet<BloodTestSubstanceInfo> BloodTestsSubstancesInfo { get; set; }
        public DbSet<SubstanceInfo> SubstanceInfo { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AppUser
            modelBuilder.Entity<AppUser>()
                .HasMany(x => x.AppUserBloodTestValue)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);

            // AppUserBloodTestValue
            modelBuilder.Entity<AppUserBloodTestValue>()
                .HasKey(x => x.AppUserBloodTestValueId);
            modelBuilder.Entity<AppUserBloodTestValue>()
                .Property(f => f.AppUserBloodTestValueId)
                .ValueGeneratedOnAdd();

            // BloodTestInfo
            modelBuilder.Entity<BloodTestInfo>()
                .HasKey(x => x.BloodTestInfoId);
            modelBuilder.Entity<BloodTestInfo>()
                .Property(f => f.BloodTestInfoId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BloodTestInfo>()
              .HasMany(x => x.AppUserBloodTestValue)
              .WithOne(x => x.BloodTestInfo)
              .HasForeignKey(x => x.BloodTestInfoId);

            // BloodTestSubstanceInfo
            modelBuilder.Entity<BloodTestSubstanceInfo>()
                .HasKey(x => new { x.BloodTestInfoId, x.SubstanceInfoId });

            // SubstanceInfo
            modelBuilder.Entity<SubstanceInfo>()
                .HasKey(x => x.SubstanceInfoId);
            modelBuilder.Entity<SubstanceInfo>()
                .Property(f => f.SubstanceInfoId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SubstanceInfo>()
              .HasMany(x => x.AppUserBloodTestValue)
              .WithOne(x => x.SubstanceInfo)
              .HasForeignKey(x => x.SubstanceInfoId);

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
        }
    }
}
