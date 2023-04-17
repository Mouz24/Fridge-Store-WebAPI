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
    [Migration("20220927180411_InitialData")]
    partial class InitialData
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
                        .HasColumnName("id");

                    b.Property<Guid>("Model_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Owner_name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Model_id");

                    b.ToTable("fridge");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            Model_id = new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"),
                            Name = "Atlant",
                            Owner_name = "Maxim"
                        },
                        new
                        {
                            Id = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            Model_id = new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"),
                            Name = "Atlant",
                            Owner_name = "Alexandr"
                        });
                });

            modelBuilder.Entity("Entities.Models.fridge_model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
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
                            Name = "ХМ-6024-031",
                            Year = 2021
                        },
                        new
                        {
                            Id = new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"),
                            Name = "ХМ 4209-000",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Entities.Models.fridge_products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("Fridge_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Product_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Fridge_id");

                    b.HasIndex("Product_id");

                    b.ToTable("fridge_products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1117aee8-cfc5-4a7d-85bd-3b869b334a21"),
                            Fridge_id = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            Product_id = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                            Quantity = 6
                        },
                        new
                        {
                            Id = new Guid("36e8b9dd-cbfa-4ac3-9273-b20ebeb226b5"),
                            Fridge_id = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            Product_id = new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"),
                            Quantity = 4
                        },
                        new
                        {
                            Id = new Guid("1e0c50ea-8503-4b85-b86a-92077130249c"),
                            Fridge_id = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                            Product_id = new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"),
                            Quantity = 7
                        },
                        new
                        {
                            Id = new Guid("d99726a5-b08a-4ace-adfc-eec6c2c60f8d"),
                            Fridge_id = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            Product_id = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                            Quantity = 4
                        },
                        new
                        {
                            Id = new Guid("a7b6eaf4-7a70-482a-8a0a-1240ef0c3a63"),
                            Fridge_id = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                            Product_id = new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"),
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("Entities.Models.products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int?>("Default_quantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"),
                            Default_quantity = 2,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                            Default_quantity = 7,
                            Name = "Sausage"
                        },
                        new
                        {
                            Id = new Guid("e52efc08-e592-4f81-a0b5-b570a7604b09"),
                            Default_quantity = 4,
                            Name = "Tomatoe"
                        },
                        new
                        {
                            Id = new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"),
                            Default_quantity = 3,
                            Name = "Cucumber"
                        },
                        new
                        {
                            Id = new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"),
                            Default_quantity = 10,
                            Name = "Egg"
                        },
                        new
                        {
                            Id = new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"),
                            Default_quantity = 2,
                            Name = "Beef"
                        });
                });

            modelBuilder.Entity("Entities.Models.fridge", b =>
                {
                    b.HasOne("Entities.Models.fridge_model", "fridge_model")
                        .WithMany()
                        .HasForeignKey("Model_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fridge_model");
                });

            modelBuilder.Entity("Entities.Models.fridge_products", b =>
                {
                    b.HasOne("Entities.Models.fridge", "fridge")
                        .WithMany()
                        .HasForeignKey("Fridge_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.products", "products")
                        .WithMany()
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fridge");

                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
