﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lockerSystem.Models;

#nullable disable

namespace lockerSystem.Migrations
{
    [DbContext(typeof(LockerSystemContext))]
    partial class LockerSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("lockerSystem.Models.BookingLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Booking_Id")
                        .HasColumnType("int");

                    b.Property<string>("bookBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookingStatues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookingLog");
                });

            modelBuilder.Entity("lockerSystem.Models.tblBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookingStateId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LockerId")
                        .HasColumnType("int");

                    b.Property<int>("SemsterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("bokingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("colegename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("floornumer")
                        .HasColumnType("int");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rejectionReason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingStateId");

                    b.HasIndex("LockerId");

                    b.HasIndex("SemsterId");

                    b.ToTable("tblBooking");
                });

            modelBuilder.Entity("lockerSystem.Models.tblBookingState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblBookingState");
                });

            modelBuilder.Entity("lockerSystem.Models.tblBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("no")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblBuilding");
                });

            modelBuilder.Entity("lockerSystem.Models.tblFloor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("no")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("tblFloor");
                });

            modelBuilder.Entity("lockerSystem.Models.tblLocker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LockerStateId")
                        .HasColumnType("int");

                    b.Property<int>("no")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("LockerStateId");

                    b.ToTable("tblLocker");
                });

            modelBuilder.Entity("lockerSystem.Models.tblLockerState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("stateAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stateEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblLockerState");
                });

            modelBuilder.Entity("lockerSystem.Models.tblManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblManagement");
                });

            modelBuilder.Entity("lockerSystem.Models.tblPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tblPermission");
                });

            modelBuilder.Entity("lockerSystem.Models.tblRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblRole");
                });

            modelBuilder.Entity("lockerSystem.Models.tblSemster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("endSemster")
                        .HasColumnType("datetime2");

                    b.Property<string>("semsterNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("semsterNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startSemster")
                        .HasColumnType("datetime2");

                    b.Property<int?>("tblSemsterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblSemsterId");

                    b.ToTable("tblSemster");
                });

            modelBuilder.Entity("lockerSystem.Models.tblUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("lockerSystem.Models.tblBooking", b =>
                {
                    b.HasOne("lockerSystem.Models.tblBookingState", "BookingState")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lockerSystem.Models.tblLocker", "Locker")
                        .WithMany()
                        .HasForeignKey("LockerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lockerSystem.Models.tblSemster", "Semster")
                        .WithMany()
                        .HasForeignKey("SemsterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BookingState");

                    b.Navigation("Locker");

                    b.Navigation("Semster");
                });

            modelBuilder.Entity("lockerSystem.Models.tblFloor", b =>
                {
                    b.HasOne("lockerSystem.Models.tblBuilding", "Building")
                        .WithMany("Floor")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("lockerSystem.Models.tblLocker", b =>
                {
                    b.HasOne("lockerSystem.Models.tblFloor", "Floor")
                        .WithMany("Lockers")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lockerSystem.Models.tblLockerState", "LockerState")
                        .WithMany("Lockers")
                        .HasForeignKey("LockerStateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Floor");

                    b.Navigation("LockerState");
                });

            modelBuilder.Entity("lockerSystem.Models.tblPermission", b =>
                {
                    b.HasOne("lockerSystem.Models.tblRole", "Role")
                        .WithMany("Permission")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("lockerSystem.Models.tblSemster", b =>
                {
                    b.HasOne("lockerSystem.Models.tblSemster", null)
                        .WithMany("Booking")
                        .HasForeignKey("tblSemsterId");
                });

            modelBuilder.Entity("lockerSystem.Models.tblBookingState", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("lockerSystem.Models.tblBuilding", b =>
                {
                    b.Navigation("Floor");
                });

            modelBuilder.Entity("lockerSystem.Models.tblFloor", b =>
                {
                    b.Navigation("Lockers");
                });

            modelBuilder.Entity("lockerSystem.Models.tblLockerState", b =>
                {
                    b.Navigation("Lockers");
                });

            modelBuilder.Entity("lockerSystem.Models.tblRole", b =>
                {
                    b.Navigation("Permission");
                });

            modelBuilder.Entity("lockerSystem.Models.tblSemster", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}
