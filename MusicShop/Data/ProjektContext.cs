using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data;

public partial class ProjektContext : DbContext
{
    public ProjektContext()
    {
    }

    public ProjektContext(DbContextOptions<ProjektContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Distributor> Distributors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderRecord> OrderRecords { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<RecordStorage> RecordStorages { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<TypeOfRecord> TypeOfRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Projekt");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Address_pk");

            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasColumnType("text")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnType("text")
                .HasColumnName("country");
            entity.Property(e => e.Postcode).HasColumnName("postcode");
            entity.Property(e => e.State)
                .HasColumnType("text")
                .HasColumnName("state");
            entity.Property(e => e.StreetName)
                .HasColumnType("text")
                .HasColumnName("street_name");
            entity.Property(e => e.StreetNumber).HasColumnName("street_number");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Artist_pk");

            entity.ToTable("Artist");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("name");

            entity.HasMany(d => d.Records).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "ArtistRecord",
                    r => r.HasOne<Record>().WithMany()
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Artist_Record_Record"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Artist_Record_Artist"),
                    j =>
                    {
                        j.HasKey("ArtistId", "RecordId").HasName("Artist_Record_pk");
                        j.ToTable("Artist_Record");
                        j.IndexerProperty<int>("ArtistId").HasColumnName("Artist_id");
                        j.IndexerProperty<int>("RecordId").HasColumnName("Record_id");
                    });
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pk");

            entity.ToTable("Customer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.DiscountId).HasColumnName("Discount_id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasColumnType("text")
                .HasColumnName("surname");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_Address");

            entity.HasOne(d => d.Discount).WithMany(p => p.Customers)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("Customer_Discount");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Discount_pk");

            entity.ToTable("Discount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Distributor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Distributor_pk");

            entity.ToTable("Distributor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Genre_pk");

            entity.ToTable("Genre");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pk");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.FulfillAt).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestAt).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("Status_id");

            entity.HasOne(d => d.Address).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Address");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Status");
        });

        modelBuilder.Entity<OrderRecord>(entity =>
        {
            entity.HasKey(e => new { e.RecordId, e.OrderId }).HasName("Order_Record_pk");

            entity.ToTable("Order_Record");

            entity.Property(e => e.RecordId).HasColumnName("Record_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderRecords)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Record_Order");

            entity.HasOne(d => d.Record).WithMany(p => p.OrderRecords)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_Record_Record");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Record_pk");

            entity.ToTable("Record");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DistributorId).HasColumnName("Distributor_id");
            entity.Property(e => e.Name)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Released)
                .HasColumnType("date")
                .HasColumnName("released");
            entity.Property(e => e.TypeOfRecordId).HasColumnName("TypeOfRecord_id");

            entity.HasOne(d => d.Distributor).WithMany(p => p.Records)
                .HasForeignKey(d => d.DistributorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Record_Distributor");

            entity.HasOne(d => d.TypeOfRecord).WithMany(p => p.Records)
                .HasForeignKey(d => d.TypeOfRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Record_TypeOfRecord");

            entity.HasMany(d => d.Genres).WithMany(p => p.Records)
                .UsingEntity<Dictionary<string, object>>(
                    "RecordGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Record_Genre_Genre"),
                    l => l.HasOne<Record>().WithMany()
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Record_Genre_Record"),
                    j =>
                    {
                        j.HasKey("RecordId", "GenreId").HasName("Record_Genre_pk");
                        j.ToTable("Record_Genre");
                        j.IndexerProperty<int>("RecordId").HasColumnName("Record_id");
                        j.IndexerProperty<int>("GenreId").HasColumnName("Genre_id");
                    });
        });

        modelBuilder.Entity<RecordStorage>(entity =>
        {
            entity.HasKey(e => new { e.RecordId, e.StorageId }).HasName("Record_Storage_pk");

            entity.ToTable("Record_Storage");

            entity.Property(e => e.RecordId).HasColumnName("Record_id");
            entity.Property(e => e.StorageId).HasColumnName("Storage_id");

            entity.HasOne(d => d.Record).WithMany(p => p.RecordStorages)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RecordStorage_Record");

            entity.HasOne(d => d.Storage).WithMany(p => p.RecordStorages)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RecordStorage_Storage");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Status_pk");

            entity.ToTable("Status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Storage_pk");

            entity.ToTable("Storage");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");

            entity.HasOne(d => d.Address).WithMany(p => p.Storages)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Storage_Address");
        });

        modelBuilder.Entity<TypeOfRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Type_Of_Record_pk");

            entity.ToTable("Type_Of_Record");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasColumnType("text")
                .HasColumnName("color");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
