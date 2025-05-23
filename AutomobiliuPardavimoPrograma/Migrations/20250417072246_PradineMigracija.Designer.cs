﻿// <auto-generated />
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
    [Migration("20250417072246_PradineMigracija")]
    partial class PradineMigracija
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

                    b.Property<decimal>("Kaina")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Marke")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelis")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Automobiliai");
                });
#pragma warning restore 612, 618
        }
    }
}
