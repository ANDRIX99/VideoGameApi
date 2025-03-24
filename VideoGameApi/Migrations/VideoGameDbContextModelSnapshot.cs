﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameApi.Controllers.Data;

#nullable disable

namespace VideoGameApi.Migrations
{
    [DbContext(typeof(VideoGameDbContext))]
    partial class VideoGameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideoGameApi.Model.Developer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("VideoGameApi.Model.Publisher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("VideoGameApi.Model.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PublisherId");

                    b.ToTable("VideoGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Platform = "Nintendo Switch",
                            Title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            Id = 2,
                            Platform = "Nintendo Switch",
                            Title = "Super Mario Odyssey"
                        },
                        new
                        {
                            Id = 3,
                            Platform = "PlayStation 4",
                            Title = "The Witcher 3: Wild Hunt"
                        },
                        new
                        {
                            Id = 4,
                            Platform = "PlayStation 4",
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 5,
                            Platform = "PlayStation 4",
                            Title = "The Last of Us Part II"
                        });
                });

            modelBuilder.Entity("VideoGameApi.Model.VideoGameDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoGameId")
                        .IsUnique();

                    b.ToTable("VideoGameDetails");
                });

            modelBuilder.Entity("VideoGameApi.Model.VideoGame", b =>
                {
                    b.HasOne("VideoGameApi.Model.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId");

                    b.HasOne("VideoGameApi.Model.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");

                    b.Navigation("Developer");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("VideoGameApi.Model.VideoGameDetails", b =>
                {
                    b.HasOne("VideoGameApi.Model.VideoGame", null)
                        .WithOne("VideoGameDetails")
                        .HasForeignKey("VideoGameApi.Model.VideoGameDetails", "VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoGameApi.Model.VideoGame", b =>
                {
                    b.Navigation("VideoGameDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
