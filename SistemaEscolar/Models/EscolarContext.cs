using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaEscolar.Models;

public partial class EscolarContext : DbContext
{
    public EscolarContext()
    {
    }

    public EscolarContext(DbContextOptions<EscolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83F6355B113");

            entity.ToTable("calificaciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdMateria).HasColumnName("id_materia");

            entity.HasOne(d => d.Estudiantes).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__calificac__id_es__6A30C649");

            entity.HasOne(d => d.Materias).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__calificac__id_ma__693CA210");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estudian__3213E83F2FFDE8B6");

            entity.ToTable("estudiantes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");
            entity.Property(e => e.Matricula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matricula");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdUsuarios)
                .HasConstraintName("FK__estudiant__id_us__6383C8BA");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__materias__3213E83F6F39D5C9");

            entity.ToTable("materias");

            entity.HasIndex(e => e.Codigo, "UQ__materias__40F9A206DCE16955").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Materias)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("materia");
            entity.Property(e => e.Requisitos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("requisitos");
            entity.Property(e => e.Semestre).HasColumnName("semestre");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__profesor__3213E83F797375BC");

            entity.ToTable("profesores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");

            entity.HasOne(d => d.Usuarios).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdUsuarios)
                .HasConstraintName("FK__profesore__id_us__66603565");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83FD01B7386");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E61648C4C85A2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
