﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.FirstMVC._2024.Models;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240330104006_AddGenreFromJson")]
    partial class AddGenreFromJson
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CustomerMovie");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("membershiptype_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("membershiptype_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("genres");

                    b.HasData(
                        new
                        {
                            GenreId = 11,
                            name = "Test2"
                        },
                        new
                        {
                            GenreId = 12,
                            name = "Test3"
                        });
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Membershiptype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DiscountRate")
                        .HasColumnType("REAL");

                    b.Property<int>("DurationInMonth")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SignUpFee")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Membershiptypes");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("WithSubtitles")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("genre_id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("genre_id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("userModels");
                });

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.HasOne("Project.FirstMVC._2024.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.FirstMVC._2024.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Customer", b =>
                {
                    b.HasOne("Project.FirstMVC._2024.Models.Membershiptype", "Membershiptype")
                        .WithMany("Customers")
                        .HasForeignKey("membershiptype_id");

                    b.Navigation("Membershiptype");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Movie", b =>
                {
                    b.HasOne("Project.FirstMVC._2024.Models.Genre", "Genre")
                        .WithMany("movies")
                        .HasForeignKey("genre_id");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Genre", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("Project.FirstMVC._2024.Models.Membershiptype", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}