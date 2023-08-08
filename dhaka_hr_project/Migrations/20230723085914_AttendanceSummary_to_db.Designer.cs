﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dhaka_hr_project.Data;

#nullable disable

namespace dhaka_hr_project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230723085914_AttendanceSummary_to_db")]
    partial class AttendanceSummary_to_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dhaka_hr_project.Models.Attendance", b =>
                {
                    b.Property<string>("AttId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AttStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("InTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AttId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmpId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.AttendanceSummary", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Absent")
                        .HasColumnType("int");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Late")
                        .HasColumnType("int");

                    b.Property<int>("Present")
                        .HasColumnType("int");

                    b.Property<int>("Weekend")
                        .HasColumnType("int");

                    b.Property<int>("dtMonth")
                        .HasColumnType("int");

                    b.Property<int>("dtYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmpId");

                    b.ToTable("AttendanceSummarys");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Company", b =>
                {
                    b.Property<string>("ComId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Basic")
                        .HasColumnType("float");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("HRent")
                        .HasColumnType("float");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<double>("Medical")
                        .HasColumnType("float");

                    b.HasKey("ComId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Department", b =>
                {
                    b.Property<string>("DeptId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("DeptId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Designation", b =>
                {
                    b.Property<string>("DesigId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DesigName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("DesigId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Employee", b =>
                {
                    b.Property<string>("EmpId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("Basic")
                        .HasColumnType("float");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeptId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DesigId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<double>("Gross")
                        .HasColumnType("float");

                    b.Property<double>("HRent")
                        .HasColumnType("float");

                    b.Property<double>("Medical")
                        .HasColumnType("float");

                    b.Property<double>("Others")
                        .HasColumnType("float");

                    b.Property<string>("ShiftId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("dtJoin")
                        .HasColumnType("datetime2");

                    b.HasKey("EmpId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesigId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Shift", b =>
                {
                    b.Property<string>("ShiftId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ShiftIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShiftLate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ShiftOut")
                        .HasColumnType("datetime2");

                    b.HasKey("ShiftId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Attendance", b =>
                {
                    b.HasOne("dhaka_hr_project.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dhaka_hr_project.Models.Employee", "Emp")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Emp");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.AttendanceSummary", b =>
                {
                    b.HasOne("dhaka_hr_project.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dhaka_hr_project.Models.Employee", "Emp")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Emp");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Department", b =>
                {
                    b.HasOne("dhaka_hr_project.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Designation", b =>
                {
                    b.HasOne("dhaka_hr_project.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Employee", b =>
                {
                    b.HasOne("dhaka_hr_project.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dhaka_hr_project.Models.Department", "Dept")
                        .WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dhaka_hr_project.Models.Designation", "Desig")
                        .WithMany()
                        .HasForeignKey("DesigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dhaka_hr_project.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Dept");

                    b.Navigation("Desig");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("dhaka_hr_project.Models.Shift", b =>
                {
                    b.HasOne("dhaka_hr_project.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
