﻿// <auto-generated />
using System;
using AutomobiliuPardavimoPrograma.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

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

                    b.Property<string>("Nuotraukos")
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

            modelBuilder.Entity("AutomobiliuPardavimoPrograma.Models.UserPostLikes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPostLikes");
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

            modelBuilder.Entity("AutomobiliuPardavimoPrograma.Models.UserPostLikes", b =>
                {
                    b.HasOne("AutomobiliuPardavimoPrograma.Models.Automobilis", "Automobilis")
                        .WithMany("UserPostLikes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomobiliuPardavimoPrograma.Models.Vartotojas", "Vartotojas")
                        .WithMany("UserPostLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Automobilis");

                    b.Navigation("Vartotojas");
                });

            modelBuilder.Entity("AutomobiliuPardavimoPrograma.Models.Automobilis", b =>
                {
                    b.Navigation("UserPostLikes");
                });

            modelBuilder.Entity("AutomobiliuPardavimoPrograma.Models.Vartotojas", b =>
                {
                    b.Navigation("UserPostLikes");
                });
#pragma warning restore 612, 618
        }
    }
}
