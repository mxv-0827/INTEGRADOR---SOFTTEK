﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_INTEGRADOR.DataAccess;

#nullable disable

namespace TP_INTEGRADOR.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TP_INTEGRADOR.Entities.Project", b =>
                {
                    b.Property<int>("CodProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodProject");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProject"), 1L, 1);

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("Direction");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("DATE")
                        .HasColumnName("LeavingDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("Name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("State");

                    b.HasKey("CodProject");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            CodProject = 1,
                            Direction = "Calle xD 1234",
                            Name = "Project number 1",
                            State = 1
                        },
                        new
                        {
                            CodProject = 2,
                            Direction = "Calle xD 5678",
                            Name = "Project number 2",
                            State = 2
                        },
                        new
                        {
                            CodProject = 3,
                            Direction = "Calle xD 9102",
                            Name = "Project number 3",
                            State = 3
                        },
                        new
                        {
                            CodProject = 4,
                            Direction = "Calle xD 3456",
                            Name = "Project number 4",
                            State = 1
                        });
                });

            modelBuilder.Entity("TP_INTEGRADOR.Entities.Service", b =>
                {
                    b.Property<int>("CodService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodService");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodService"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("Description");

                    b.Property<decimal>("HourValue")
                        .HasColumnType("DECIMAL(18,0)")
                        .HasColumnName("HourValue");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("DATE")
                        .HasColumnName("LeavingDate");

                    b.Property<bool>("State")
                        .HasColumnType("bit")
                        .HasColumnName("State");

                    b.HasKey("CodService");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            CodService = 1,
                            Description = "aaa",
                            HourValue = 80m,
                            State = true
                        },
                        new
                        {
                            CodService = 2,
                            Description = "bbb",
                            HourValue = 12m,
                            State = false
                        },
                        new
                        {
                            CodService = 3,
                            Description = "ccc",
                            HourValue = 20m,
                            State = true
                        },
                        new
                        {
                            CodService = 4,
                            Description = "ddd",
                            HourValue = 65m,
                            State = false
                        });
                });

            modelBuilder.Entity("TP_INTEGRADOR.Entities.User", b =>
                {
                    b.Property<int>("CodUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodUser");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUser"), 1L, 1);

                    b.Property<int>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("int")
                        .HasColumnName("DNI");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("DATE")
                        .HasColumnName("LeavingDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("Password");

                    b.Property<int>("UserRole")
                        .HasColumnType("int")
                        .HasColumnName("UserRole");

                    b.HasKey("CodUser");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            CodUser = 1,
                            DNI = 12345678,
                            Name = "Maxi Viand",
                            Password = "admin1234",
                            UserRole = 1
                        },
                        new
                        {
                            CodUser = 2,
                            DNI = 13245678,
                            Name = "Cris Viand",
                            Password = "admin4321",
                            UserRole = 2
                        },
                        new
                        {
                            CodUser = 3,
                            DNI = 87654321,
                            Name = "Gerardo Viand",
                            Password = "admin2468",
                            UserRole = 1
                        },
                        new
                        {
                            CodUser = 4,
                            DNI = 67891234,
                            Name = "Adriana Neporadnyj",
                            Password = "admin1357",
                            UserRole = 2
                        });
                });

            modelBuilder.Entity("TP_INTEGRADOR.Entities.Work", b =>
                {
                    b.Property<int>("CodWork")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodWork");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodWork"), 1L, 1);

                    b.Property<int>("AmountHours")
                        .HasColumnType("int")
                        .HasColumnName("AmountHours");

                    b.Property<int>("CodProject")
                        .HasColumnType("int")
                        .HasColumnName("CodProject");

                    b.Property<int>("CodService")
                        .HasColumnType("int")
                        .HasColumnName("CodService");

                    b.Property<decimal>("Cost")
                        .HasColumnType("DECIMAL(18,0)")
                        .HasColumnName("Cost");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE")
                        .HasColumnName("Date");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("DATE")
                        .HasColumnName("LeavingDate");

                    b.Property<decimal>("ValuePerHour")
                        .HasColumnType("DECIMAL(18,0)")
                        .HasColumnName("ValuePerHour");

                    b.HasKey("CodWork");

                    b.HasIndex("CodProject");

                    b.HasIndex("CodService");

                    b.ToTable("Works");

                    b.HasData(
                        new
                        {
                            CodWork = 1,
                            AmountHours = 1,
                            CodProject = 4,
                            CodService = 4,
                            Cost = 5m,
                            Date = new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6587),
                            ValuePerHour = 5m
                        },
                        new
                        {
                            CodWork = 2,
                            AmountHours = 2,
                            CodProject = 3,
                            CodService = 3,
                            Cost = 12m,
                            Date = new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6607),
                            ValuePerHour = 6m
                        },
                        new
                        {
                            CodWork = 3,
                            AmountHours = 3,
                            CodProject = 2,
                            CodService = 2,
                            Cost = 21m,
                            Date = new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6609),
                            ValuePerHour = 7m
                        },
                        new
                        {
                            CodWork = 4,
                            AmountHours = 4,
                            CodProject = 1,
                            CodService = 1,
                            Cost = 32m,
                            Date = new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6610),
                            ValuePerHour = 8m
                        });
                });

            modelBuilder.Entity("TP_INTEGRADOR.Entities.Work", b =>
                {
                    b.HasOne("TP_INTEGRADOR.Entities.Project", "Project")
                        .WithMany("Works")
                        .HasForeignKey("CodProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_INTEGRADOR.Entities.Service", "Service")
                        .WithMany("Works")
                        .HasForeignKey("CodService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TP_INTEGRADOR.Entities.Project", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("TP_INTEGRADOR.Entities.Service", b =>
                {
                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
