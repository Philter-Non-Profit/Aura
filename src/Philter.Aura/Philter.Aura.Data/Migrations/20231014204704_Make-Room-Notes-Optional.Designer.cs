﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Philter.Aura.Data;

#nullable disable

namespace Philter.Aura.Data.Migrations
{
    [DbContext(typeof(AuraDbContext))]
    [Migration("20231014204704_Make-Room-Notes-Optional")]
    partial class MakeRoomNotesOptional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Philter.Aura.Data.Models.AuraUser", b =>
                {
                    b.Property<Guid>("AuraUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("LastLogin")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("AuraUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.House", b =>
                {
                    b.Property<int>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("AltPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MainPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("HouseId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.HouseManager", b =>
                {
                    b.Property<int>("HouseManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseManagerId"));

                    b.Property<Guid>("AuraUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.HasKey("HouseManagerId");

                    b.HasIndex("AuraUserId");

                    b.HasIndex("HouseId", "AuraUserId")
                        .IsUnique();

                    b.ToTable("HouseManagers");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("HouseId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.HouseManager", b =>
                {
                    b.HasOne("Philter.Aura.Data.Models.AuraUser", "AuraUser")
                        .WithMany("HouseManagers")
                        .HasForeignKey("AuraUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Philter.Aura.Data.Models.House", "House")
                        .WithMany("HouseManagers")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AuraUser");

                    b.Navigation("House");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.Room", b =>
                {
                    b.HasOne("Philter.Aura.Data.Models.House", "House")
                        .WithMany("Rooms")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.AuraUser", b =>
                {
                    b.Navigation("HouseManagers");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.House", b =>
                {
                    b.Navigation("HouseManagers");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
