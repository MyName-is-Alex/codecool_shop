﻿// <auto-generated />
using Codecool.CodecoolShop.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    [DbContext(typeof(CodecoolShopContext))]
    partial class CodecoolShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DefaultPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Currency = "USD",
                            DefaultPrice = 49.9m,
                            Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
                            Name = "Amazon Fire",
                            ProductCategoryId = 1,
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 2,
                            Currency = "USD",
                            DefaultPrice = 479.0m,
                            Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.",
                            Name = "Lenovo IdeaPad Miix 700",
                            ProductCategoryId = 1,
                            SupplierId = 3
                        },
                        new
                        {
                            Id = 3,
                            Currency = "USD",
                            DefaultPrice = 89.0m,
                            Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
                            Name = "Amazon Fire HD 8",
                            ProductCategoryId = 1,
                            SupplierId = 1
                        });
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "Hardware",
                            Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display.",
                            Name = "Tablet"
                        },
                        new
                        {
                            Id = 2,
                            Department = "Hardware",
                            Description = "A phone, commonly shortened to phone, is a thin, flat mobile computer with a touchscreen display.",
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Digital content and services",
                            Name = "Amazon"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Everything you think of",
                            Name = "EMag"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Computers",
                            Name = "Lenovo"
                        });
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Product", b =>
                {
                    b.HasOne("Codecool.CodecoolShop.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Codecool.CodecoolShop.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
