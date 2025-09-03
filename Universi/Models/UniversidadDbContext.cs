using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Universi.Models;

public partial class UniversidadDbContext : DbContext
{
    public UniversidadDbContext()
    {
    }

    public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=MEDAPRCGEFSP701\\SQLEXPRESS;Initial Catalog=UniversidadDB;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E0235D7515CCA29");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Profesor).HasMaxLength(100);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PK__Estudian__6F7682D8514250A9");

            entity.HasIndex(e => e.Correo, "UQ__Estudian__60695A197BA27033").IsUnique();

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.InscripcionId).HasName("PK__Inscripc__168316B9E08F5E43");

            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscripciones_Cursos");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscripciones_Estudiantes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
