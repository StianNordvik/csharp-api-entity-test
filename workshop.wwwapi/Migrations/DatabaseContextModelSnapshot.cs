﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using workshop.wwwapi.Data;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Appointment", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctorid");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patientid");

                    b.Property<int>("AppointmentType")
                        .HasColumnType("integer")
                        .HasColumnName("appointmenttype");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("date")
                        .HasColumnName("booking");

                    b.Property<int>("PerscriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("perscriptionid");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PerscriptionId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            PatientId = 1,
                            AppointmentType = 0,
                            Booking = new DateTime(2024, 2, 9, 13, 39, 8, 541, DateTimeKind.Utc).AddTicks(840),
                            PerscriptionId = 1
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 2,
                            AppointmentType = 1,
                            Booking = new DateTime(2024, 2, 10, 13, 39, 8, 541, DateTimeKind.Utc).AddTicks(853),
                            PerscriptionId = 2
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Doctor George"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Doctor Homer"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("notes");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.ToTable("medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ibuprofen",
                            Notes = "Maximum 3 pills per day",
                            Quantity = 15
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wondermedicine",
                            Notes = "Infinite",
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.MedicinePerscription", b =>
                {
                    b.Property<int>("MedicineId")
                        .HasColumnType("integer")
                        .HasColumnName("medicineid");

                    b.Property<int>("PerscriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("perscriptionid");

                    b.HasKey("MedicineId", "PerscriptionId");

                    b.HasIndex("PerscriptionId");

                    b.ToTable("medicineperscriptions");

                    b.HasData(
                        new
                        {
                            MedicineId = 1,
                            PerscriptionId = 1
                        },
                        new
                        {
                            MedicineId = 2,
                            PerscriptionId = 2
                        },
                        new
                        {
                            MedicineId = 1,
                            PerscriptionId = 2
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Homer Simpson"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "George Washington"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Perscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("perscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Appointment", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.DatabaseModels.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.DatabaseModels.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.DatabaseModels.Perscription", "Perscription")
                        .WithMany()
                        .HasForeignKey("PerscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Perscription");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.MedicinePerscription", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.DatabaseModels.Medicine", null)
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.DatabaseModels.Perscription", null)
                        .WithMany()
                        .HasForeignKey("PerscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.DatabaseModels.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
