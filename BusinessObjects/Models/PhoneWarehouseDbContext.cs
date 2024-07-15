﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models;

public partial class PhoneWarehouseDbContext : DbContext
{
    public PhoneWarehouseDbContext()
    {
    }

    public PhoneWarehouseDbContext(DbContextOptions<PhoneWarehouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;database=PhoneWarehouseDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brand__DAD4F3BEDB3074C2");

            entity.ToTable("Brand");

            entity.HasIndex(e => e.BrandName, "UQ__Brand__2206CE9B0FF9DD5E").IsUnique();

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.BrandName).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(1);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8A748A74A");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Status).HasDefaultValue(1);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("PK__Phones__F3EE4BD0007CEE4A");

            entity.Property(e => e.PhoneId).HasColumnName("PhoneID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.ModelName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasDefaultValue(1);

            entity.HasOne(d => d.Brand).WithMany(p => p.Phones)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Phones__BrandID__29572725");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Purchase__C3905BAF04E8F323");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__PurchaseO__Suppl__300424B4");
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Purchase__D3B9D30C0AB7461E");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PhoneId).HasColumnName("PhoneID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__PurchaseO__Order__33D4B598");

            entity.HasOne(d => d.Phone).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.PhoneId)
                .HasConstraintName("FK__PurchaseO__Phone__34C8D9D1");
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.SaleOrderId).HasName("PK__SalesOrd__DB86E32289BD0354");

            entity.Property(e => e.SaleOrderId).HasColumnName("SaleOrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__SalesOrde__Custo__3B75D760");
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK__SalesOrd__70DB141EDED14B0A");

            entity.Property(e => e.SaleDetailId).HasColumnName("SaleDetailID");
            entity.Property(e => e.PhoneId).HasColumnName("PhoneID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SaleOrderId).HasColumnName("SaleOrderID");
            entity.Property(e => e.Status).HasDefaultValue(1);

            entity.HasOne(d => d.Phone).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.PhoneId)
                .HasConstraintName("FK__SalesOrde__Phone__403A8C7D");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.SaleOrderId)
                .HasConstraintName("FK__SalesOrde__SaleO__3F466844");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE6669449157945");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.SupplierName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
