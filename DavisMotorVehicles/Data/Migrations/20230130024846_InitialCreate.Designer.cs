﻿// <auto-generated />
using DavisMotorVehicles.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DavisMotorVehicles.Data.Migrations
{
    [DbContext(typeof(VehicleDatabaseContext))]
    [Migration("20230130024846_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("DavisMotorVehicles.Data.Tire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TireStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TireStatusId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Tires");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            TireStatusId = 3,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            TireStatusId = 3,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            TireStatusId = 3,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            TireStatusId = 3,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 3
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 3
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 3
                        },
                        new
                        {
                            Id = 12,
                            IsActive = true,
                            TireStatusId = 1,
                            VehicleId = 3
                        },
                        new
                        {
                            Id = 13,
                            IsActive = true,
                            TireStatusId = 2,
                            VehicleId = 4
                        },
                        new
                        {
                            Id = 14,
                            IsActive = true,
                            TireStatusId = 2,
                            VehicleId = 4
                        },
                        new
                        {
                            Id = 15,
                            IsActive = true,
                            TireStatusId = 2,
                            VehicleId = 4
                        },
                        new
                        {
                            Id = 16,
                            IsActive = true,
                            TireStatusId = 2,
                            VehicleId = 4
                        },
                        new
                        {
                            Id = 17,
                            IsActive = true,
                            TireStatusId = 2,
                            VehicleId = 6
                        },
                        new
                        {
                            Id = 18,
                            IsActive = true,
                            TireStatusId = 2,
                            VehicleId = 6
                        });
                });

            modelBuilder.Entity("DavisMotorVehicles.Data.TireStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TireStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Bad"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Fair"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Good"
                        });
                });

            modelBuilder.Entity("DavisMotorVehicles.Data.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuelLevel")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VinNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FuelLevel = 40,
                            IsActive = true,
                            Make = "Dodge",
                            Model = "Avenger",
                            VehicleTypeId = 1,
                            VinNumber = "1C3CDZBG8DN504146",
                            Year = 2013
                        },
                        new
                        {
                            Id = 2,
                            FuelLevel = 50,
                            IsActive = true,
                            Make = "Honda",
                            Model = "CRV",
                            VehicleTypeId = 1,
                            VinNumber = "5J6RM4850CL703159",
                            Year = 2017
                        },
                        new
                        {
                            Id = 3,
                            FuelLevel = 60,
                            IsActive = true,
                            Make = "Acura",
                            Model = "Integra",
                            VehicleTypeId = 1,
                            VinNumber = "JH4KA3151LC012001",
                            Year = 2018
                        },
                        new
                        {
                            Id = 4,
                            FuelLevel = 70,
                            IsActive = true,
                            Make = "Dodge",
                            Model = "Ram1500",
                            VehicleTypeId = 2,
                            VinNumber = "3B7KF23Z42M211215",
                            Year = 2011
                        },
                        new
                        {
                            Id = 5,
                            FuelLevel = 80,
                            IsActive = true,
                            Make = "Tige",
                            Model = "WakeMaster",
                            VehicleTypeId = 4,
                            VinNumber = "848DKDIEKDL888DKD",
                            Year = 2003
                        },
                        new
                        {
                            Id = 6,
                            FuelLevel = 90,
                            IsActive = true,
                            Make = "Honda",
                            Model = "Shadow",
                            VehicleTypeId = 3,
                            VinNumber = "KDEID3366DKDKDKIF",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("DavisMotorVehicles.Data.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfTires")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Car",
                            NumberOfTires = 4
                        },
                        new
                        {
                            Id = 2,
                            Name = "Truck",
                            NumberOfTires = 4
                        },
                        new
                        {
                            Id = 3,
                            Name = "Motorcycle",
                            NumberOfTires = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Boat",
                            NumberOfTires = 0
                        });
                });

            modelBuilder.Entity("DavisMotorVehicles.Data.Tire", b =>
                {
                    b.HasOne("DavisMotorVehicles.Data.TireStatus", "TireStatus")
                        .WithMany()
                        .HasForeignKey("TireStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DavisMotorVehicles.Data.Vehicle", "Vehicle")
                        .WithMany("Tires")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TireStatus");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DavisMotorVehicles.Data.Vehicle", b =>
                {
                    b.HasOne("DavisMotorVehicles.Data.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("DavisMotorVehicles.Data.Vehicle", b =>
                {
                    b.Navigation("Tires");
                });
#pragma warning restore 612, 618
        }
    }
}
