﻿// <auto-generated />
using EFDemo1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFDemo1.Migrations
{
    [DbContext(typeof(LMSDbContext))]
    partial class LMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("EFDemo1.Model.Assignment", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("Detail");

                    b.HasKey("Code");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("EFDemo1.Model.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseCode");

                    b.Property<int>("Credit");

                    b.Property<int>("MaxNumber");

                    b.Property<string>("Name");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFDemo1.Model.Enrolment", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<string>("CourseGrade");

                    b.Property<DateTime>("EnrolmentDate");

                    b.Property<string>("Status");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrolments");
                });

            modelBuilder.Entity("EFDemo1.Model.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Feedback");

                    b.Property<string>("Name");

                    b.Property<double>("Payroll");

                    b.HasKey("LecturerId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("EFDemo1.Model.LecturerDetail", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detail");

                    b.HasKey("LecturerId");

                    b.ToTable("LecturerDetail");
                });

            modelBuilder.Entity("EFDemo1.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreditLimited");

                    b.Property<string>("Name");

                    b.Property<int>("StudentFee");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFDemo1.Model.StudentAddress", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("PostCode");

                    b.Property<int?>("StudentId1");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentId1");

                    b.ToTable("StudentAddress");
                });

            modelBuilder.Entity("EFDemo1.Model.StudentCountry", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.HasKey("StudentId");

                    b.ToTable("StudentCountry");
                });

            modelBuilder.Entity("EFDemo1.Model.StudentDetail", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detail");

                    b.HasKey("StudentId");

                    b.ToTable("StudentDetail");
                });

            modelBuilder.Entity("EFDemo1.Model.Teaching", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("LecturerId");

                    b.HasKey("CourseId", "LecturerId");

                    b.HasIndex("LecturerId");

                    b.ToTable("Teaching");
                });

            modelBuilder.Entity("EFDemo1.Model.Assignment", b =>
                {
                    b.HasOne("EFDemo1.Model.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("EFDemo1.Model.Enrolment", b =>
                {
                    b.HasOne("EFDemo1.Model.Course", "Course")
                        .WithMany("Enrolments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFDemo1.Model.Student", "Student")
                        .WithMany("Enrolments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDemo1.Model.LecturerDetail", b =>
                {
                    b.HasOne("EFDemo1.Model.Lecturer", "Lecturer")
                        .WithOne("LecturerDetail")
                        .HasForeignKey("EFDemo1.Model.LecturerDetail", "LecturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDemo1.Model.StudentAddress", b =>
                {
                    b.HasOne("EFDemo1.Model.Student", "Student")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("StudentId1");
                });

            modelBuilder.Entity("EFDemo1.Model.StudentCountry", b =>
                {
                    b.HasOne("EFDemo1.Model.Student", "Student")
                        .WithOne("StudentCountry")
                        .HasForeignKey("EFDemo1.Model.StudentCountry", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDemo1.Model.StudentDetail", b =>
                {
                    b.HasOne("EFDemo1.Model.Student", "Student")
                        .WithOne("StudentDetail")
                        .HasForeignKey("EFDemo1.Model.StudentDetail", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDemo1.Model.Teaching", b =>
                {
                    b.HasOne("EFDemo1.Model.Course", "Course")
                        .WithMany("Teachings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFDemo1.Model.Lecturer", "Lecturer")
                        .WithMany("Teachings")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
