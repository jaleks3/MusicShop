﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicShop.Data;

#nullable disable

namespace MusicShop.Migrations
{
    [DbContext(typeof(ProjektContext))]
    partial class ProjektContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistRecord", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int")
                        .HasColumnName("Artist_id");

                    b.Property<int>("RecordId")
                        .HasColumnType("int")
                        .HasColumnName("Record_id");

                    b.HasKey("ArtistId", "RecordId")
                        .HasName("Artist_Record_pk");

                    b.HasIndex("RecordId");

                    b.ToTable("Artist_Record", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<int>("Postcode")
                        .HasColumnType("int")
                        .HasColumnName("postcode");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_name");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int")
                        .HasColumnName("street_number");

                    b.HasKey("Id")
                        .HasName("Address_pk");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("Artist_pk");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Address_id");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int")
                        .HasColumnName("Discount_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("Customer_pk");

                    b.HasIndex("AddressId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.CustomerOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("Customer_id");

                    b.HasKey("OrderId", "CustomerId")
                        .HasName("Order_Customer_pk");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order_Customer", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxDiscount")
                        .HasColumnType("int");

                    b.Property<int>("MinPrice")
                        .HasColumnType("int");

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Discount_pk");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Distributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("Distributor_pk");

                    b.ToTable("Distributor", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("Genre_pk");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Address_id");

                    b.Property<DateTime>("FulfillAt")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("RequestAt")
                        .HasColumnType("datetime");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("Status_id");

                    b.HasKey("Id")
                        .HasName("Order_pk");

                    b.HasIndex("AddressId");

                    b.HasIndex("StatusId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.OrderRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .HasColumnType("int")
                        .HasColumnName("Record_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("RecordId", "OrderId")
                        .HasName("Order_Record_pk");

                    b.HasIndex("OrderId");

                    b.ToTable("Order_Record", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DistributorId")
                        .HasColumnType("int")
                        .HasColumnName("Distributor_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<DateTime>("Released")
                        .HasColumnType("date")
                        .HasColumnName("released");

                    b.Property<int>("TypeOfRecordId")
                        .HasColumnType("int")
                        .HasColumnName("TypeOfRecord_id");

                    b.HasKey("Id")
                        .HasName("Record_pk");

                    b.HasIndex("DistributorId");

                    b.HasIndex("TypeOfRecordId");

                    b.ToTable("Record", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.RecordStorage", b =>
                {
                    b.Property<int>("RecordId")
                        .HasColumnType("int")
                        .HasColumnName("Record_id");

                    b.Property<int>("StorageId")
                        .HasColumnType("int")
                        .HasColumnName("Storage_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("RecordId", "StorageId")
                        .HasName("Record_Storage_pk");

                    b.HasIndex("StorageId");

                    b.ToTable("Record_Storage", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("Status_pk");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Address_id");

                    b.HasKey("Id")
                        .HasName("Storage_pk");

                    b.HasIndex("AddressId");

                    b.ToTable("Storage", (string)null);
                });

            modelBuilder.Entity("MusicShop.Models.TypeOfRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("Type_Of_Record_pk");

                    b.ToTable("Type_Of_Record", (string)null);
                });

            modelBuilder.Entity("RecordGenre", b =>
                {
                    b.Property<int>("RecordId")
                        .HasColumnType("int")
                        .HasColumnName("Record_id");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("Genre_id");

                    b.HasKey("RecordId", "GenreId")
                        .HasName("Record_Genre_pk");

                    b.HasIndex("GenreId");

                    b.ToTable("Record_Genre", (string)null);
                });

            modelBuilder.Entity("ArtistRecord", b =>
                {
                    b.HasOne("MusicShop.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .IsRequired()
                        .HasConstraintName("Artist_Record_Artist");

                    b.HasOne("MusicShop.Models.Record", null)
                        .WithMany()
                        .HasForeignKey("RecordId")
                        .IsRequired()
                        .HasConstraintName("Artist_Record_Record");
                });

            modelBuilder.Entity("MusicShop.Models.Customer", b =>
                {
                    b.HasOne("MusicShop.Models.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("Customer_Address");

                    b.HasOne("MusicShop.Models.Discount", "Discount")
                        .WithMany("Customers")
                        .HasForeignKey("DiscountId")
                        .HasConstraintName("Customer_Discount");

                    b.Navigation("Address");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("MusicShop.Models.CustomerOrder", b =>
                {
                    b.HasOne("MusicShop.Models.Customer", "Customer")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("Customer_Order_Customer");

                    b.HasOne("MusicShop.Models.Order", "Order")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("Customer_Order_Order");

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MusicShop.Models.Order", b =>
                {
                    b.HasOne("MusicShop.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("Order_Address");

                    b.HasOne("MusicShop.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("Order_Status");

                    b.Navigation("Address");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MusicShop.Models.OrderRecord", b =>
                {
                    b.HasOne("MusicShop.Models.Order", "Order")
                        .WithMany("OrderRecords")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("Order_Record_Order");

                    b.HasOne("MusicShop.Models.Record", "Record")
                        .WithMany("OrderRecords")
                        .HasForeignKey("RecordId")
                        .IsRequired()
                        .HasConstraintName("Order_Record_Record");

                    b.Navigation("Order");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("MusicShop.Models.Record", b =>
                {
                    b.HasOne("MusicShop.Models.Distributor", "Distributor")
                        .WithMany("Records")
                        .HasForeignKey("DistributorId")
                        .IsRequired()
                        .HasConstraintName("Record_Distributor");

                    b.HasOne("MusicShop.Models.TypeOfRecord", "TypeOfRecord")
                        .WithMany("Records")
                        .HasForeignKey("TypeOfRecordId")
                        .IsRequired()
                        .HasConstraintName("Record_TypeOfRecord");

                    b.Navigation("Distributor");

                    b.Navigation("TypeOfRecord");
                });

            modelBuilder.Entity("MusicShop.Models.RecordStorage", b =>
                {
                    b.HasOne("MusicShop.Models.Record", "Record")
                        .WithMany("RecordStorages")
                        .HasForeignKey("RecordId")
                        .IsRequired()
                        .HasConstraintName("RecordStorage_Record");

                    b.HasOne("MusicShop.Models.Storage", "Storage")
                        .WithMany("RecordStorages")
                        .HasForeignKey("StorageId")
                        .IsRequired()
                        .HasConstraintName("RecordStorage_Storage");

                    b.Navigation("Record");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("MusicShop.Models.Storage", b =>
                {
                    b.HasOne("MusicShop.Models.Address", "Address")
                        .WithMany("Storages")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("Storage_Address");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RecordGenre", b =>
                {
                    b.HasOne("MusicShop.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("Record_Genre_Genre");

                    b.HasOne("MusicShop.Models.Record", null)
                        .WithMany()
                        .HasForeignKey("RecordId")
                        .IsRequired()
                        .HasConstraintName("Record_Genre_Record");
                });

            modelBuilder.Entity("MusicShop.Models.Address", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Orders");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("MusicShop.Models.Customer", b =>
                {
                    b.Navigation("CustomerOrders");
                });

            modelBuilder.Entity("MusicShop.Models.Discount", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MusicShop.Models.Distributor", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("MusicShop.Models.Order", b =>
                {
                    b.Navigation("CustomerOrders");

                    b.Navigation("OrderRecords");
                });

            modelBuilder.Entity("MusicShop.Models.Record", b =>
                {
                    b.Navigation("OrderRecords");

                    b.Navigation("RecordStorages");
                });

            modelBuilder.Entity("MusicShop.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MusicShop.Models.Storage", b =>
                {
                    b.Navigation("RecordStorages");
                });

            modelBuilder.Entity("MusicShop.Models.TypeOfRecord", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
