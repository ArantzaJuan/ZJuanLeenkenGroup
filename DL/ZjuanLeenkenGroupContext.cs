using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ZjuanLeenkenGroupContext : DbContext
{
    public ZjuanLeenkenGroupContext()
    {
    }

    public ZjuanLeenkenGroupContext(DbContextOptions<ZjuanLeenkenGroupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EntidadFederativa> EntidadFederativas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= LAPTOP-PCFKJ1ME; Database= ZJuanLeenkenGroup; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E6DDBF6F0");

            entity.ToTable("Empleado", tb => tb.HasTrigger("NominaEmpleado"));

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroNomina)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEntidadFederativaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEntidadFederativa)
                .HasConstraintName("FK__Empleado__IdEnti__1273C1CD");
        });

        modelBuilder.Entity<EntidadFederativa>(entity =>
        {
            entity.HasKey(e => e.IdEntidadFederativa).HasName("PK__EntidadF__26F25BCE0AAF1CFB");

            entity.ToTable("EntidadFederativa");

            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
