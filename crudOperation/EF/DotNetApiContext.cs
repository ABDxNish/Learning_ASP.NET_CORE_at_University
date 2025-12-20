using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace crudOperation.EF;

public partial class DotNetApiContext : DbContext
{
    public DotNetApiContext()
    {
    }

    public DotNetApiContext(DbContextOptions<DotNetApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-TC7UTBCV\\SQLEXPRESS;Database=DotNetAPI;User Id=sa;Password=KHNISHAT172;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("Product");

            entity.Property(e => e.Pid).HasColumnName("PId");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product Name");
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product Type");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
