﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project2.Models;

namespace Project2.Migrations
{
    [DbContext(typeof(QuadrantContext))]
    partial class QuadrantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Project2.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            CategoryID = 1,
                            Completed = true,
                            DueDate = "01-01-2023",
                            Quadrant = 1,
                            Task = "random"
                        });
                });

            modelBuilder.Entity("Project2.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("Project2.Models.ApplicationResponse", b =>
                {
                    b.HasOne("Project2.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
