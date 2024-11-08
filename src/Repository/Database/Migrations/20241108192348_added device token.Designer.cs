﻿// <auto-generated />
using System;
using MedicalAPI.Repository.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241108192348_added device token")]
    partial class addeddevicetoken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.AppointmentModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("AppointmentDuration")
                        .HasColumnType("interval");

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("integer");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatientId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.MedicineModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Dosage")
                        .HasColumnType("integer");

                    b.Property<int>("FrequencyPerDay")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("integer");

                    b.Property<string>("PrescriptionModelId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PrescriptionModelId");

                    b.ToTable("MedicineModel");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.PrescriptionModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Diagnostic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.User.DoctorModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeviceToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.User.PatientModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeviceToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.AppointmentModel", b =>
                {
                    b.HasOne("MedicalAPI.Domain.Entities.User.DoctorModel", "Doctor")
                        .WithMany("DoctorAppointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedicalAPI.Domain.Entities.User.PatientModel", "Patient")
                        .WithMany("PatientAppointments")
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.MedicineModel", b =>
                {
                    b.HasOne("MedicalAPI.Domain.Entities.Entity.Documents.PrescriptionModel", null)
                        .WithMany("Medicine")
                        .HasForeignKey("PrescriptionModelId");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.PrescriptionModel", b =>
                {
                    b.HasOne("MedicalAPI.Domain.Entities.User.DoctorModel", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalAPI.Domain.Entities.User.PatientModel", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.User.PatientModel", b =>
                {
                    b.HasOne("MedicalAPI.Domain.Entities.User.DoctorModel", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.Entity.Documents.PrescriptionModel", b =>
                {
                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.User.DoctorModel", b =>
                {
                    b.Navigation("DoctorAppointments");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("MedicalAPI.Domain.Entities.User.PatientModel", b =>
                {
                    b.Navigation("PatientAppointments");
                });
#pragma warning restore 612, 618
        }
    }
}
