using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoAB.Models
{
    public partial class adproyectosContext : DbContext
    {
        public adproyectosContext()
        {
        }

        public adproyectosContext(DbContextOptions<adproyectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignacion> Asignaciones { get; set; } = null!;
        public virtual DbSet<Colaborador> Colaboradores { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<Roles> Roles { get; set; } = null!;
        public virtual DbSet<RolesProyecto> RolesProyectos { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=adproyectos;User Id=postgres;Password=NADA12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.ToTable("asignaciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Colaborador).HasColumnName("id_colaborador");

                entity.Property(e => e.Tarea).HasColumnName("id_tarea");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.Asignaciones)
                    .HasForeignKey(d => d.Colaborador)
                    .HasConstraintName("asignaciones_id_colaborador_fkey");

                entity.HasOne(d => d.Tarea)
                    .WithMany(p => p.Asignaciones)
                    .HasForeignKey(d => d.Tarea)
                    .HasConstraintName("asignaciones_id_tarea_fkey");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.ToTable("colaboradores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(255)
                    .HasColumnName("nombres");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("proyectos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaFinalizacion).HasColumnName("fecha_finalizacion");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.EstadoId).HasColumnName("id_estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("proyectos_id_estado_fkey");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<RolesProyecto>(entity =>
            {
                entity.ToTable("roles_proyecto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColaboradorId).HasColumnName("id_colaborador");

                entity.Property(e => e.ProyectoId).HasColumnName("id_proyecto");

                entity.Property(e => e.RoleId).HasColumnName("id_role");

                entity.HasOne(d => d.Colaborador)
                    .WithMany(p => p.RolesProyectos)
                    .HasForeignKey(d => d.Colaborador)
                    .HasConstraintName("roles_proyecto_id_colaborador_fkey");

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.RolesProyectos)
                    .HasForeignKey(d => d.Proyecto)
                    .HasConstraintName("roles_proyecto_id_proyecto_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesProyectos)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("roles_proyecto_id_role_fkey");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("tareas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");

                entity.Property(e => e.EstadoId).HasColumnName("id_estado");

                entity.Property(e => e.ProyectoId).HasColumnName("id_proyecto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("tareas_id_estado_fkey");

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.ProyectoId)
                    .HasConstraintName("tareas_id_proyecto_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
