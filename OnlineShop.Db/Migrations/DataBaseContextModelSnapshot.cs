﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShop.Db.Model.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.FavouriteProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("FavouriteProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserDeliveryInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("UserDeliveryInfoId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9903536-8872-47e5-8915-14d25e1b8fe5"),
                            Cost = 0m,
                            ImagePath = "/images/product1.png"
                        },
                        new
                        {
                            Id = new Guid("df118537-7451-43d5-a2ec-82400b9bf2e2"),
                            Cost = 0m,
                            ImagePath = "/images/product2.png"
                        },
                        new
                        {
                            Id = new Guid("e55bb71b-17c9-4e60-92dc-d616e350d773"),
                            Cost = 0m,
                            ImagePath = "/images/product3.png"
                        },
                        new
                        {
                            Id = new Guid("b6e03337-352e-49c2-84a2-2ec616190248"),
                            Cost = 0m,
                            ImagePath = "/images/product4.png"
                        },
                        new
                        {
                            Id = new Guid("a83c8d84-f929-4119-a8ab-137dfec3654d"),
                            Cost = 0m,
                            ImagePath = "/images/product5.png"
                        },
                        new
                        {
                            Id = new Guid("b52b1c28-4b81-4f81-8839-fc4e017eda30"),
                            Cost = 0m,
                            ImagePath = "/images/product6.png"
                        },
                        new
                        {
                            Id = new Guid("4c4e9d04-f200-4ddc-9251-4bc4ecd3f86a"),
                            Cost = 0m,
                            ImagePath = "/images/product7.png"
                        },
                        new
                        {
                            Id = new Guid("38cbfabe-b5f4-43c5-ac34-f2d3f46a6962"),
                            Cost = 0m,
                            ImagePath = "/images/product8.png"
                        },
                        new
                        {
                            Id = new Guid("49a6e5f2-a388-4163-bec9-4ead3e829494"),
                            Cost = 0m,
                            ImagePath = "/images/product9.png"
                        },
                        new
                        {
                            Id = new Guid("7b62cd0d-1f08-4f33-bc06-559d9d0fb7e5"),
                            Cost = 0m,
                            ImagePath = "/images/product10.png"
                        },
                        new
                        {
                            Id = new Guid("6ab8bc80-a1c8-4916-ba91-b53f9f42c011"),
                            Cost = 0m,
                            ImagePath = "/images/product11.png"
                        },
                        new
                        {
                            Id = new Guid("aa263bfe-875d-422f-a3c9-539e2c863f68"),
                            Cost = 0m,
                            ImagePath = "/images/product12.png"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Model.UserDeliveryInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressOptional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RememberAddress")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDeliveryInfo");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Model.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Model.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Model.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.FavouriteProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Model.Cart", null)
                        .WithMany("Orders")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Model.UserDeliveryInfo", "UserDeliveryInfo")
                        .WithMany()
                        .HasForeignKey("UserDeliveryInfoId");

                    b.Navigation("UserDeliveryInfo");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.Cart", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Model.Product", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}