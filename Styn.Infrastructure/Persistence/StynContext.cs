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

        public DbSet<Alertas> Alertas { get; set; }
        public DbSet<Celos> Celos { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<ControlLechero> ControlLechero { get; set; }
        public DbSet<Descartes> Descartes { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<EventosSanitarios> EventosSanitarios { get; set; }
        public DbSet<ExamenGenital> ExamenGenital { get; set; }
        public DbSet<FichaAnimal> FichaAnimal { get; set; }
        public DbSet<Lotes> Lotes { get; set; }
        public DbSet<Metodos> Metodos { get; set; }
        public DbSet<Partos> Partos { get; set; }
        public DbSet<PatologiasUbre> PatologiasUbres { get; set; }
        public DbSet<PatologiasPatas> PatologiasPatas { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<RegistroOrdenes> RegistroOrdenes { get; set; }
        public DbSet<Secado> Secados { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TipoAlerta> TipoAlertas { get; set; }
        public DbSet<TipoDescarte> TipoDescartes { get; set; }
        public DbSet<TipoPartos> TipoPartos { get; set; }
        public DbSet<TipoSecado> TipoSecados { get; set; }
        public DbSet<TiposServicios> TiposServicios { get; set; }
        public DbSet<Toros> Toros { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
        }


    }




}
