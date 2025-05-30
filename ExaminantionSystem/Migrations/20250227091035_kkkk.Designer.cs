﻿// <auto-generated />
using System;
using ExaminantionSystem.Data;
 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250227091035_kkkk")]
    partial class kkkk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExaminationSystem.Models.AuthorizeRole", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<string>("Name").IsRequired().HasColumnType("nvarchar(max)");

                b.HasKey("ID");
                b.ToTable("AuthorizeRoles");
            });

            modelBuilder.Entity("ExaminationSystem.Models.Choice", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<bool>("IsRightAnswer").HasColumnType("bit");
                b.Property<int>("QuestionID").HasColumnType("int");
                b.Property<string>("Text").IsRequired().HasColumnType("nvarchar(max)");

                b.HasKey("ID");
                b.HasIndex("QuestionID");
                b.ToTable("Choices");
            });

            modelBuilder.Entity("ExaminationSystem.Models.Course", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<int>("CreditHours").HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<int>("InstructorID").HasColumnType("int");
                b.Property<string>("Name").IsRequired().HasColumnType("nvarchar(max)");

                b.HasKey("ID");
                b.HasIndex("InstructorID");
                b.ToTable("Courses");
            });

            modelBuilder.Entity("ExaminationSystem.Models.Exam", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<int>("CourseId").HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<int>("InstructorId").HasColumnType("int");
                b.Property<DateTime>("StartDate").HasColumnType("datetime2");
                b.Property<int>("TotalGrade").HasColumnType("int");

                b.HasKey("ID");
                b.HasIndex("CourseId");
                b.HasIndex("InstructorId");
                b.ToTable("Exams");
            });

            modelBuilder.Entity("ExaminationSystem.Models.ExamQuestion", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<int>("ExamID").HasColumnType("int");
                b.Property<int>("QuestionID").HasColumnType("int");

                b.HasKey("ID");
                b.HasIndex("ExamID");
                b.HasIndex("QuestionID");
                b.ToTable("ExamQuestion");
            });

            modelBuilder.Entity("ExaminationSystem.Models.Instructor", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<DateTime>("Birthdate").HasColumnType("datetime2");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<DateTime>("EnrollmentDate").HasColumnType("datetime2");
                b.Property<string>("FirstName").IsRequired().HasColumnType("nvarchar(max)");
                b.Property<string>("LastName").IsRequired().HasColumnType("nvarchar(max)");
                b.Property<int>("Points").HasColumnType("int");
                b.Property<int>("UserId").HasColumnType("int");

                b.HasKey("ID");
                b.HasIndex("UserId");
                b.ToTable("Instructor", "HR");
            });

            modelBuilder.Entity("ExaminationSystem.Models.Question", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<int>("Grade").HasColumnType("int");
                b.Property<string>("Text").IsRequired().HasColumnType("nvarchar(max)");

                b.HasKey("ID");
                b.ToTable("Questions");
            });

            modelBuilder.Entity("ExaminationSystem.Models.RoleFeature", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<int>("AuthorizeRoleID").HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<int>("Feature").HasColumnType("int");

                b.HasKey("ID");
                b.HasIndex("AuthorizeRoleID");
                b.ToTable("RoleFeatures");
            });

            modelBuilder.Entity("ExaminationSystem.Models.Student", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<string>("FirstName").IsRequired().HasColumnType("nvarchar(max)");
                b.Property<string>("LastName").IsRequired().HasColumnType("nvarchar(max)");

                b.HasKey("ID");
                b.ToTable("students");
            });

            modelBuilder.Entity("ExaminationSystem.Models.User", b =>
            {
                b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("int");
                b.Property<int>("AuthorizeRoleID").HasColumnType("int");
                b.Property<bool>("Deleted").HasColumnType("bit");
                b.Property<string>("Password").IsRequired().HasColumnType("nvarchar(max)");
                b.Property<string>("UserName").IsRequired().HasColumnType("nvarchar(max)");

                b.HasKey("ID");
                b.HasIndex("AuthorizeRoleID");
                b.ToTable("Users");
            });

            // Relationships
            modelBuilder.Entity("ExaminationSystem.Models.Choice", b =>
            {
                b.HasOne("ExaminationSystem.Models.Question", "Question")
                    .WithMany("Choices")
                    .HasForeignKey("QuestionID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ExaminationSystem.Models.Course", b =>
            {
                b.HasOne("ExaminationSystem.Models.Instructor", "Instructor")
                    .WithMany("Courses")
                    .HasForeignKey("InstructorID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ExaminationSystem.Models.Exam", b =>
            {
                b.HasOne("ExaminationSystem.Models.Course", "Course")
                    .WithMany("Exams")
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ExaminationSystem.Models.Instructor", "Instructor")
                    .WithMany("Exams")
                    .HasForeignKey("InstructorId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ExaminationSystem.Models.ExamQuestion", b =>
            {
                b.HasOne("ExaminationSystem.Models.Exam", "Exam")
                    .WithMany("ExamQuestions")
                    .HasForeignKey("ExamID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ExaminationSystem.Models.Question", "Question")
                    .WithMany("ExamQuestions")
                    .HasForeignKey("QuestionID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ExaminationSystem.Models.Instructor", b =>
            {
                b.HasOne("ExaminationSystem.Models.User", "User")
                    .WithMany("Instructors")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ExaminationSystem.Models.RoleFeature", b =>
            {
                b.HasOne("ExaminationSystem.Models.AuthorizeRole", "Role")
                    .WithMany("RoleFeatures")
                    .HasForeignKey("AuthorizeRoleID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ExaminationSystem.Models.User", b =>
            {
                b.HasOne("ExaminationSystem.Models.AuthorizeRole", "AuthorizeRole")
                    .WithMany("Users")
                    .HasForeignKey("AuthorizeRoleID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            // Navigation Configurations
            modelBuilder.Entity("ExaminationSystem.Models.Course", b => { b.Navigation("Exams"); });
            modelBuilder.Entity("ExaminationSystem.Models.Exam", b => { b.Navigation("ExamQuestions"); });
            modelBuilder.Entity("ExaminationSystem.Models.Instructor", b => {
                b.Navigation("Exams");
                b.Navigation("Courses");
            });
            modelBuilder.Entity("ExaminationSystem.Models.Question", b => {
                b.Navigation("Choices");
                b.Navigation("ExamQuestions");
            });
            modelBuilder.Entity("ExaminationSystem.Models.AuthorizeRole", b => {
                b.Navigation("RoleFeatures");
                b.Navigation("Users");
            });
            modelBuilder.Entity("ExaminationSystem.Models.User", b => {
                b.Navigation("Instructors");
            });

#pragma warning restore 612, 618
        }
    }
}
