﻿// <auto-generated />
using System;
using BreweryManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BreweryManagement.Persistence.Migrations
{
    [DbContext(typeof(BreweryDb))]
    [Migration("20230309202335_linkbeerandbrewer")]
    partial class linkbeerandbrewer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BreweryManagement.Domain.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AlcoholContent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BrewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrewerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Brewer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Brewers");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Wholesaler", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("BreweryManagement.Domain.WholesalerStock", b =>
                {
                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WholesalerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BeerId", "WholesalerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("WholesalerStocks");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Beer", b =>
                {
                    b.HasOne("BreweryManagement.Domain.Brewer", "Brewer")
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewer");
                });

            modelBuilder.Entity("BreweryManagement.Domain.WholesalerStock", b =>
                {
                    b.HasOne("BreweryManagement.Domain.Beer", "Beer")
                        .WithMany("WholesalerStocks")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreweryManagement.Domain.Wholesaler", "Wholesaler")
                        .WithMany("Stocks")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Beer", b =>
                {
                    b.Navigation("WholesalerStocks");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Brewer", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("BreweryManagement.Domain.Wholesaler", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
