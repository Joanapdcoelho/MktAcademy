﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MktAcademy.DataAccess.Data;

#nullable disable

namespace MktAcademy.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MktAcademy.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Digital Marketing"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Legislation"
                        });
                });

            modelBuilder.Entity("MktAcademy.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Marketing course 25h",
                            ListPrice = 540m,
                            Name = "Marketing",
                            Price20 = 432m,
                            Remarks = ""
                        },
                        new
                        {
                            Id = 2,
                            Description = "Marketing course 25h",
                            ListPrice = 540m,
                            Name = "Digital Marketing",
                            Price20 = 432m,
                            Remarks = ""
                        },
                        new
                        {
                            Id = 3,
                            Description = "Marketing course 25h",
                            ListPrice = 540m,
                            Name = "E-mail Marketing",
                            Price20 = 432m,
                            Remarks = ""
                        },
                        new
                        {
                            Id = 4,
                            Description = "Marketing course 25h",
                            ListPrice = 540m,
                            Name = "Social Media Marketing",
                            Price20 = 432m,
                            Remarks = ""
                        },
                        new
                        {
                            Id = 5,
                            Description = "Marketing course 25h",
                            ListPrice = 540m,
                            Name = "Legislation 2.0",
                            Price20 = 432m,
                            Remarks = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
