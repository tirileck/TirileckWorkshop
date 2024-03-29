﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TirileckWorkshop.Data;

#nullable disable

namespace TirileckWorkshop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230425183810_AddInitial")]
    partial class AddInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TirileckWorkshop.Data.Models.DeviceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeviceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Другое"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "ПК"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Ноутбук"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Телефон"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Планшет"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Телевизор"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Принтер"
                        });
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal?>("AllCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeviceTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SpareCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StatusDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("WorkshopId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RoleId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("WorkshopId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.Workshop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkShops");
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.Order", b =>
                {
                    b.HasOne("TirileckWorkshop.Data.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");

                    b.HasOne("TirileckWorkshop.Data.Models.Workshop", "Workshop")
                        .WithMany("Orders")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceType");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.User", b =>
                {
                    b.HasOne("TirileckWorkshop.Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TirileckWorkshop.Data.Models.Workshop", "Workshop")
                        .WithMany("Users")
                        .HasForeignKey("WorkshopId");

                    b.Navigation("Role");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("TirileckWorkshop.Data.Models.Workshop", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
