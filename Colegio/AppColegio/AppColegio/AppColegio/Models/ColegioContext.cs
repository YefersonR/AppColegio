using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppColegio.Models
{
    public partial class ColegioContext : DbContext
    {
        public ColegioContext()
        {
        }

        public ColegioContext(DbContextOptions<ColegioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0A0VEDP\\SQLEXPRESS;Database=Colegio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.Idalumno);

                entity.Property(e => e.Idalumno).HasColumnName("IDAlumno");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Idcurso).HasColumnName("IDCurso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.Idcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAC");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Idcurso);

                entity.Property(e => e.Idcurso).HasColumnName("IDCurso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Seccion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.Idmaterias);

                entity.Property(e => e.Idmaterias).HasColumnName("IDMaterias");

                entity.Property(e => e.Horario)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idcurso).HasColumnName("IDCurso");

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Profesor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.Materias)
                    .HasForeignKey(d => d.Idcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMC");
            });
        }
    }
}
