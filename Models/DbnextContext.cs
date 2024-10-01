using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFull.Models;

public partial class DbnextContext : DbContext
{
    public DbnextContext()
    {
    }

    public DbnextContext(DbContextOptions<DbnextContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Eventos__3214EC075A310126");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Lugar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07E9A9B9C3");

            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
