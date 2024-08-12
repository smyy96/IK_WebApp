
using BESMIK.Common;
using BESMIK.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BESMIK.DAL
{
    public class BesmikDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public BesmikDbContext(DbContextOptions<BesmikDbContext> options) : base(options)
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyManager> CompanyManagers { get; set; }

        public DbSet<Permission> Permissions { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//EntityConfig Dosyaların eklenmesi

        }
    }
}
