﻿// <auto-generated />
using System;
using HotelManagementProjectfeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementProjectfeb.Migrations
{
    [DbContext(typeof(HotelManagementDataContext))]
    partial class HotelManagementDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Bill", b =>
                {
                    b.Property<Guid>("Bill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Reservation_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Room_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("stay_dates")
                        .HasColumnType("int");

                    b.HasKey("Bill_id");

                    b.HasIndex("Reservation_id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Guest", b =>
                {
                    b.Property<Guid>("Guest_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone_number")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("reservation_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guest_id");

                    b.HasIndex("reservation_id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Inventory", b =>
                {
                    b.Property<Guid>("Inventory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Inventory_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Inventory_Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Manager", b =>
                {
                    b.Property<Guid>("manager_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("manager_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.HasKey("manager_id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Receptionist", b =>
                {
                    b.Property<Guid>("Receptionist_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Receptionist_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("reservation_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.HasKey("Receptionist_Id");

                    b.HasIndex("reservation_id");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Reservation", b =>
                {
                    b.Property<Guid>("reservation_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Check_in")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Check_out")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guest_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Receptionist_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Room_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("no_of_adults")
                        .HasColumnType("int");

                    b.Property<int>("no_of_children")
                        .HasColumnType("int");

                    b.Property<int>("no_of_nights")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("reservation_id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Room", b =>
                {
                    b.Property<Guid>("room_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Bill_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("reservation_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("room_rate")
                        .HasColumnType("float");

                    b.Property<bool>("room_status")
                        .HasColumnType("bit");

                    b.HasKey("room_id");

                    b.HasIndex("Bill_id");

                    b.HasIndex("reservation_id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.User_Roles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Users_Roles");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Bill", b =>
                {
                    b.HasOne("HotelManagementProjectfeb.Model.Domain.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("Reservation_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Guest", b =>
                {
                    b.HasOne("HotelManagementProjectfeb.Model.Domain.Reservation", null)
                        .WithMany("Guests")
                        .HasForeignKey("reservation_id");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Receptionist", b =>
                {
                    b.HasOne("HotelManagementProjectfeb.Model.Domain.Reservation", null)
                        .WithMany("Receptionists")
                        .HasForeignKey("reservation_id");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Room", b =>
                {
                    b.HasOne("HotelManagementProjectfeb.Model.Domain.Bill", null)
                        .WithMany("Rooms")
                        .HasForeignKey("Bill_id");

                    b.HasOne("HotelManagementProjectfeb.Model.Domain.Reservation", null)
                        .WithMany("Rooms")
                        .HasForeignKey("reservation_id");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.User_Roles", b =>
                {
                    b.HasOne("HotelManagementProjectfeb.Model.Domain.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagementProjectfeb.Model.Domain.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Bill", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Reservation", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("Receptionists");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("HotelManagementProjectfeb.Model.Domain.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
