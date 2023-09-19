using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webproyectos.Entidades;
using webproyectos.Models;

namespace webproyectos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<proyectos>().HasKey(p => p.Id);
            modelBuilder.Entity<proyectos>().Property(g => g.Nombre).HasMaxLength(150);
        }

        //Escribir Modelos
        public DbSet<proyectos> Proyectos { get; set; }
        public DbSet<Estados> Estados  {get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Tareas> Tareas { get; set; }



    }
}
















