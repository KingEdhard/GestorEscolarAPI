using GestorEscolarAPI.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorEscolarAPI.Server.Context
{
    public class GestorEscolarContext : DbContext
    {
        public GestorEscolarContext(DbContextOptions<GestorEscolarContext> options) : base(options) 
        {
        
        }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.Profesor)
                .WithMany(p => p.Materias)
                .HasForeignKey(m => m.ProfesorId);

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Alumno)
                .WithMany(a => a.Calificaciones)
                .HasForeignKey(c => c.AlumnoId);

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Materia)
                .WithMany(m => m.Calificaciones)
                .HasForeignKey(c => c.MateriaId);
        }
    }
}
