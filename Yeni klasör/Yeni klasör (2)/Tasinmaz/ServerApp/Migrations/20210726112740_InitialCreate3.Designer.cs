﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServerApp.Data;

namespace ServerApp.Migrations
{
    [DbContext(typeof(SocialContext))]
    [Migration("20210726112740_InitialCreate3")]
    partial class InitialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ServerApp.Models.Il", b =>
                {
                    b.Property<int>("IlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("IlName")
                        .HasColumnType("text");

                    b.HasKey("IlId");

                    b.ToTable("Il");
                });

            modelBuilder.Entity("ServerApp.Models.Ilce", b =>
                {
                    b.Property<int>("IlceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IlId")
                        .HasColumnType("integer");

                    b.Property<string>("IlceName")
                        .HasColumnType("text");

                    b.HasKey("IlceId");

                    b.HasIndex("IlId");

                    b.ToTable("Ilce");
                });

            modelBuilder.Entity("ServerApp.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("KullaniciName")
                        .HasColumnType("text");

                    b.Property<string>("KullaniciSurname")
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<bool>("Rol")
                        .HasColumnType("boolean");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("ServerApp.Models.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateHour")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<string>("Explanation")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("integer");

                    b.Property<bool>("ProccesType")
                        .HasColumnType("boolean");

                    b.HasKey("LogId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("ServerApp.Models.Mahalle", b =>
                {
                    b.Property<int>("MahalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IlceId")
                        .HasColumnType("integer");

                    b.Property<string>("MahalleName")
                        .HasColumnType("text");

                    b.HasKey("MahalleId");

                    b.HasIndex("IlceId");

                    b.ToTable("Mahalle");
                });

            modelBuilder.Entity("ServerApp.Models.Tasinmaz", b =>
                {
                    b.Property<int>("TasinmazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Ada")
                        .HasColumnType("integer");

                    b.Property<string>("Adres")
                        .HasColumnType("text");

                    b.Property<bool>("Is_active")
                        .HasColumnType("boolean");

                    b.Property<int>("MahalleId")
                        .HasColumnType("integer");

                    b.Property<string>("Nitelik")
                        .HasColumnType("text");

                    b.Property<int>("Parsel")
                        .HasColumnType("integer");

                    b.HasKey("TasinmazId");

                    b.HasIndex("MahalleId");

                    b.ToTable("Tasinmaz");
                });

            modelBuilder.Entity("ServerApp.Models.Ilce", b =>
                {
                    b.HasOne("ServerApp.Models.Il", "Il")
                        .WithMany()
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Il");
                });

            modelBuilder.Entity("ServerApp.Models.Log", b =>
                {
                    b.HasOne("ServerApp.Models.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("ServerApp.Models.Mahalle", b =>
                {
                    b.HasOne("ServerApp.Models.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilce");
                });

            modelBuilder.Entity("ServerApp.Models.Tasinmaz", b =>
                {
                    b.HasOne("ServerApp.Models.Mahalle", "Mahalle")
                        .WithMany()
                        .HasForeignKey("MahalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mahalle");
                });
#pragma warning restore 612, 618
        }
    }
}
