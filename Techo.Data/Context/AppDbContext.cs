using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.Models;

namespace Techo.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asistencia>()
                .HasKey(a => new { a.ActividadId, a.VoluntarioId });

        }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<Voluntario> Voluntario { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Comuna> Comuna { get; set; }
        public DbSet<Comunidad> Comunidad { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<MesaTrabajo> MesaTrabajo { get; set; }
        public DbSet<ActividadAlternativa> ActividadAlternativa { get; set; }
        public DbSet<Asistencia> Asistencia { get; set; }

    }
}
