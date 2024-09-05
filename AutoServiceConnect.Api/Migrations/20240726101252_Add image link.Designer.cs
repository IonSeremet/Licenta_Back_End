﻿// <auto-generated />
using System;
using AutoServiceConnect.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoServiceConnect.Api.Migrations
{
    [DbContext(typeof(AutoServiceDbContext))]
    [Migration("20240726101252_Add image link")]
    partial class Addimagelink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AutoServiceId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoServiceId");

                    b.HasIndex("CarId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.AutoService", b =>
                {
                    b.Property<int>("AutoServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoServiceId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapCoordinates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutoServiceId");

                    b.ToTable("AutoServices");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.AutoServiceManager", b =>
                {
                    b.Property<int>("ServiceManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceManagerId"));

                    b.Property<int>("AutoServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ServiceManagerId");

                    b.HasIndex("AutoServiceId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AutoServiceManagers");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Automatic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasGps")
                        .HasColumnType("bit");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("SeatType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("ContactInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGoogleAccount")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Appointment", b =>
                {
                    b.HasOne("AutoServiceConnect.Api.Database.Models.AutoService", "AutoService")
                        .WithMany("Appointments")
                        .HasForeignKey("AutoServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoServiceConnect.Api.Database.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoServiceConnect.Api.Database.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoServiceConnect.Api.Database.Models.User", null)
                        .WithMany("Appointments")
                        .HasForeignKey("UserId");

                    b.Navigation("AutoService");

                    b.Navigation("Car");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.AutoServiceManager", b =>
                {
                    b.HasOne("AutoServiceConnect.Api.Database.Models.AutoService", "AutoService")
                        .WithMany()
                        .HasForeignKey("AutoServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoServiceConnect.Api.Database.Models.User", "User")
                        .WithOne("ServiceManager")
                        .HasForeignKey("AutoServiceConnect.Api.Database.Models.AutoServiceManager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Car", b =>
                {
                    b.HasOne("AutoServiceConnect.Api.Database.Models.Customer", "Owner")
                        .WithMany("OwnedCars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Customer", b =>
                {
                    b.HasOne("AutoServiceConnect.Api.Database.Models.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("AutoServiceConnect.Api.Database.Models.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.AutoService", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.Customer", b =>
                {
                    b.Navigation("OwnedCars");
                });

            modelBuilder.Entity("AutoServiceConnect.Api.Database.Models.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Customer");

                    b.Navigation("ServiceManager");
                });
#pragma warning restore 612, 618
        }
    }
}
