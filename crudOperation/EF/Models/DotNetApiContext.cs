using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudOperation.EF;

namespace crudOperation.EF.Models;

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
        => optionsBuilder.UseSqlServer("Name=UMSContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product");

            entity.Property(e => e.Pid)
                .ValueGeneratedOnAdd()
                .HasColumnName("PId");
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
