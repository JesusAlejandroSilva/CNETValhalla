using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VikingosAPI.Models;

public partial class ValhallaDbContext : DbContext
{
    public ValhallaDbContext()
    {
    }

    public ValhallaDbContext(DbContextOptions<ValhallaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vikingo> Vikingos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vikingo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vikingos__3214EC0798D89258");

            entity.Property(e => e.ArmaFavorita).HasMaxLength(50);
            entity.Property(e => e.CausaMuerte).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
