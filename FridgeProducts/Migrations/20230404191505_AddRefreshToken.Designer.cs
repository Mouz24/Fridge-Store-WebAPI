﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FridgeProducts.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230404191505_AddRefreshToken")]
    partial class AddRefreshToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("OwnerName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("fridge");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            ModelId = new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"),
                            Name = "Atlant",
                            OwnerName = "Maxim"
                        },
                        new
                        {
                            Id = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            ModelId = new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"),
                            Name = "Atlant",
                            OwnerName = "Alexandr"
                        });
                });

            modelBuilder.Entity("Entities.Models.fridge_model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("NameOfModel")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("fridge_model");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"),
                            NameOfModel = "ХМ-6024-031",
                            Year = 2021
                        },
                        new
                        {
                            Id = new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"),
                            NameOfModel = "ХМ 4209-000",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Entities.Models.fridge_products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId");

                    b.ToTable("fridge_products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1117aee8-cfc5-4a7d-85bd-3b869b334a21"),
                            FridgeId = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            ProductId = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                            Quantity = 6
                        },
                        new
                        {
                            Id = new Guid("36e8b9dd-cbfa-4ac3-9273-b20ebeb226b5"),
                            FridgeId = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            ProductId = new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"),
                            Quantity = 4
                        },
                        new
                        {
                            Id = new Guid("1e0c50ea-8503-4b85-b86a-92077130249c"),
                            FridgeId = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            ProductId = new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"),
                            Quantity = 7
                        },
                        new
                        {
                            Id = new Guid("d99726a5-b08a-4ace-adfc-eec6c2c60f8d"),
                            FridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            ProductId = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                            Quantity = 4
                        },
                        new
                        {
                            Id = new Guid("a7b6eaf4-7a70-482a-8a0a-1240ef0c3a63"),
                            FridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            ProductId = new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("ae9042f1-379d-43eb-b7d3-57250f59c0a1"),
                            FridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            ProductId = new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"),
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Entities.Models.products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int?>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"),
                            DefaultQuantity = 2,
                            Product = "Cheese"
                        },
                        new
                        {
                            Id = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                            DefaultQuantity = 7,
                            Product = "Sausage"
                        },
                        new
                        {
                            Id = new Guid("e52efc08-e592-4f81-a0b5-b570a7604b09"),
                            DefaultQuantity = 4,
                            Product = "Tomatoe"
                        },
                        new
                        {
                            Id = new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"),
                            DefaultQuantity = 3,
                            Product = "Cucumber"
                        },
                        new
                        {
                            Id = new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"),
                            DefaultQuantity = 10,
                            Product = "Egg"
                        },
                        new
                        {
                            Id = new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"),
                            DefaultQuantity = 2,
                            Product = "Beef"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1f1b617b-8bd8-41a6-97ea-a3ce46dde231",
                            ConcurrencyStamp = "20f67eff-7f9c-496a-a519-97c85174c37a",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "4ff235a6-ef50-426a-a712-c73b3469339f",
                            ConcurrencyStamp = "cc9e610f-9e4d-442f-b935-c6dab3efecc8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.fridge", b =>
                {
                    b.HasOne("Entities.Models.fridge_model", "FridgeModel")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("Entities.Models.fridge_products", b =>
                {
                    b.HasOne("Entities.Models.fridge", "fridge")
                        .WithMany()
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.products", "products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fridge");

                    b.Navigation("products");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
