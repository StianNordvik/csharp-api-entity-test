﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using workshop.wwwapi.Data;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240207082951_TwelvethMigration")]
    partial class TwelvethMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("Booking")
                        .HasColumnType("date")
                        .HasColumnName("booking");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            PatientId = 1,
                            Booking = new DateTime(2024, 2, 8, 8, 29, 51, 391, DateTimeKind.Utc).AddTicks(1576)
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 2,
                            Booking = new DateTime(2024, 2, 9, 8, 29, 51, 391, DateTimeKind.Utc).AddTicks(1590)
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

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
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
