using Styn.Domain.DTOs;
using Styn.Domain.Entities;
using Styn.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Styn.Infrastructure.Data
{
    public class StynContext : IdentityDbContext<ApplicationUser>
    {
        public StynContext(DbContextOptions<StynContext> options)
         : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
        }


    }




}
