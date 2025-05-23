﻿// <auto-generated />
using System;
using AutomobiliuPardavimoPrograma.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250505191032_Change_Automobilis_Change_Nuotraukos_To_List")]
    partial class Change_Automobilis_Change_Nuotraukos_To_List
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AutomobiliuPardavimoPrograma.Models.Automobilis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aprasymas")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Kaina")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("KuroTipas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Marke")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Metai")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Modelis")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nuotrauka")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PavaruDeze")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Rida")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Automobiliai");
                });

            modelBuilder.Entity("AutomobiliuPardavimoPrograma.Models.Vartotojas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ElPastas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SlaptazodisHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vardas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("YraAdmin")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Vartotojai");
                });
#pragma warning restore 612, 618
        }
    }
}
