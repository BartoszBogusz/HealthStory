using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Entities
{
    public class HealthStoryContext : DbContext
    {
        public HealthStoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=HealthStory;User Id=root; Password=admin;");
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<BloodTestSubstance> BloodTestsSubstances { get; set; }
        public DbSet<SubDef> SubDefs { get; set; }

    }
}
