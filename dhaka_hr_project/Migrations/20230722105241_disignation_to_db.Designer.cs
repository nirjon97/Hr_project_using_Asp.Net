﻿// <auto-generated />
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
    [Migration("20230722105241_disignation_to_db")]
    partial class disignation_to_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("dhaka_hr_project.Models.Department", b =>
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
