﻿// <auto-generated />
using System;
using BpaReserve.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BpaReserve.Migrations
{
    [DbContext(typeof(BpaReserveContext))]
    partial class BpaReserveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bpa_Test_2.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaitTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Bpa_Test_2.Models.Ride", b =>
                {
                    b.Property<int>("RideID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RideImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RideName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaitTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RideID");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("Bpa_Test_2.Models.RideReservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RideID")
                        .HasColumnType("int");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RideID");

                    b.HasIndex("userID");

                    b.ToTable("RideReservation");
                });

            modelBuilder.Entity("Bpa_Test_2.Models.restaurant_reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID");

                    b.HasIndex("userID");

                    b.ToTable("restaurant_reservation");
                });

            modelBuilder.Entity("Bpa_Test_2.Models.user", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MicrosoftUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Bpa_Test_2.Models.RideReservation", b =>
                {
                    b.HasOne("Bpa_Test_2.Models.Ride", "Ride")
                        .WithMany()
                        .HasForeignKey("RideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bpa_Test_2.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("Bpa_Test_2.Models.restaurant_reservation", b =>
                {
                    b.HasOne("Bpa_Test_2.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bpa_Test_2.Models.user", "user")
                        .WithMany()
                        .HasForeignKey("userID");
                });
#pragma warning restore 612, 618
        }
    }
}
