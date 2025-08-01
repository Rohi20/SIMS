﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIMSWeb.Data.Context;

#nullable disable

namespace SIMSWeb.Data.Migrations
{
    [DbContext(typeof(SIMSDBContext))]
    [Migration("20250801062607_MakeTeacherIdNullable")]
    partial class MakeTeacherIdNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SIMSWeb.Model.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Algebra",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Physics 101",
                            TeacherId = 2
                        });
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Enrollment", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CourseId = 1,
                            Comments = "",
                            Marks = 70.0,
                            Term = 1
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 2,
                            Comments = "",
                            Marks = 65.0,
                            Term = 1
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 2,
                            Comments = "",
                            Marks = 50.0,
                            Term = 1
                        });
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnrollmentDate = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(7020),
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            EnrollmentDate = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(7021),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "Mathematics",
                            HireDate = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(7031),
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            Department = "Physics",
                            HireDate = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(7032),
                            UserId = 4
                        });
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(6924),
                            Email = "admin@gmail.com",
                            Name = "Admin",
                            Password = "admin",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(6934),
                            Email = "keya@gmail.com",
                            Name = "Keya",
                            Password = "stud",
                            Role = "Student"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(6934),
                            Email = "tiya@gmail.com",
                            Name = "Tiya",
                            Password = "staff",
                            Role = "Teacher"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(6935),
                            Email = "nav@gmail.com",
                            Name = "Naveen",
                            Password = "staff",
                            Role = "Teacher"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 8, 1, 11, 56, 6, 696, DateTimeKind.Local).AddTicks(6936),
                            Email = "sid@gmail.com",
                            Name = "Sid",
                            Password = "stud",
                            Role = "Student"
                        });
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Course", b =>
                {
                    b.HasOne("SIMSWeb.Model.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Enrollment", b =>
                {
                    b.HasOne("SIMSWeb.Model.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SIMSWeb.Model.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Student", b =>
                {
                    b.HasOne("SIMSWeb.Model.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SIMSWeb.Model.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Teacher", b =>
                {
                    b.HasOne("SIMSWeb.Model.Models.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("SIMSWeb.Model.Models.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.Teacher", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("SIMSWeb.Model.Models.User", b =>
                {
                    b.Navigation("Student")
                        .IsRequired();

                    b.Navigation("Teacher")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
