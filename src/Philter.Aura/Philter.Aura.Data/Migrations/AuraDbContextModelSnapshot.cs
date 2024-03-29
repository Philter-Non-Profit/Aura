﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Philter.Aura.Data;

#nullable disable

namespace Philter.Aura.Data.Migrations
{
    [DbContext(typeof(AuraDbContext))]
    partial class AuraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Philter.Aura.Data.Models.AuraUser", b =>
                {
                    b.Property<Guid>("AuraUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("Philter.Aura.Data.Models.Message", b =>
                {
                    b.Property<long>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MessageId"));

                    b.Property<Guid?>("AuraUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageBody")
                        .IsRequired()
                        .HasMaxLength(1600)
                        .HasColumnType("nvarchar(1600)");

                    b.Property<long?>("RecipientId")
                        .HasColumnType("bigint");

                    b.HasKey("MessageId");

                    b.HasIndex("AuraUserId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.Recipient", b =>
                {
                    b.Property<long>("RecipientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RecipientId"));

                    b.Property<string>("RecipientName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("RecipientPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("RecipientId");

                    b.ToTable("Recipients");
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

            modelBuilder.Entity("Philter.Aura.Data.Models.Message", b =>
                {
                    b.HasOne("Philter.Aura.Data.Models.AuraUser", null)
                        .WithMany("Messages")
                        .HasForeignKey("AuraUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Philter.Aura.Data.Models.Recipient", null)
                        .WithMany("Messages")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);
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

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.House", b =>
                {
                    b.Navigation("HouseManagers");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Philter.Aura.Data.Models.Recipient", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
