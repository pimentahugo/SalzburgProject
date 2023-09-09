﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalzburgProject.Data;

#nullable disable

namespace SalzburgProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SalzburgProject.Models.ChavePix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<string>("KeyPix")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("ChavesPix");
                });

            modelBuilder.Entity("SalzburgProject.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("SalzburgProject.Models.Folga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFolga")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Folgas");
                });

            modelBuilder.Entity("SalzburgProject.Models.ChavePix", b =>
                {
                    b.HasOne("SalzburgProject.Models.Colaborador", "Colaborador")
                        .WithMany("ChavesPix")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("SalzburgProject.Models.Folga", b =>
                {
                    b.HasOne("SalzburgProject.Models.Colaborador", "Colaborador")
                        .WithMany("Folgas")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("SalzburgProject.Models.Colaborador", b =>
                {
                    b.Navigation("ChavesPix");

                    b.Navigation("Folgas");
                });
#pragma warning restore 612, 618
        }
    }
}
