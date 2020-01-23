﻿// <auto-generated />
using System;
using BillBucket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillBucket.Migrations
{
    [DbContext(typeof(BillBucketContext))]
    partial class BillBucketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BillBucket.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSiret")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("NumeroTelephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99c9d537-ea92-4d84-8b0d-584f4374f4fc"),
                            Adresse = "2 Rue du marathon",
                            Mail = "decathlon@decathlon.com",
                            Nom = "Decathlon",
                            NumeroSiret = "KFEFE4864FE8E7",
                            NumeroTelephone = "0650408090"
                        });
                });

            modelBuilder.Entity("BillBucket.Models.Facture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReglement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("IdClient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumeroFacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.ToTable("Factures");

                    b.HasData(
                        new
                        {
                            Id = new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"),
                            DateEmission = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateReglement = new DateTime(2020, 1, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Tapis de course",
                            IdClient = new Guid("99c9d537-ea92-4d84-8b0d-584f4374f4fc"),
                            NumeroFacture = 1
                        });
                });

            modelBuilder.Entity("BillBucket.Models.Prestation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdFacture")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdFacture");

                    b.ToTable("Prestations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2b043369-3b14-4022-ad57-3f564a7cc2b2"),
                            Description = "Nous dressons vos poules pour faire des oeufs carrés",
                            IdFacture = new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"),
                            Montant = 400.0,
                            Nom = "Dressage de poules"
                        },
                        new
                        {
                            Id = new Guid("01b3b566-d064-44ea-b2e6-9583100a7ad7"),
                            Description = "Nous vous fournissons l'élite",
                            IdFacture = new Guid("91772ffc-78d2-449a-bb25-c2b669806fec"),
                            Montant = 4000.0,
                            Nom = "Location de tueurs à gage"
                        });
                });

            modelBuilder.Entity("BillBucket.Models.Facture", b =>
                {
                    b.HasOne("BillBucket.Models.Client", "Client")
                        .WithMany("Factures")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BillBucket.Models.Prestation", b =>
                {
                    b.HasOne("BillBucket.Models.Facture", "Facture")
                        .WithMany("Prestations")
                        .HasForeignKey("IdFacture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
