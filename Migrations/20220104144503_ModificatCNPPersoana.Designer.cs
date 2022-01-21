﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vadean_Flaviu_Proiect.Data;

namespace Vadean_Flaviu_Proiect.Migrations
{
    [DbContext(typeof(Vadean_Flaviu_ProiectContext))]
    [Migration("20220104144503_ModificatCNPPersoana")]
    partial class ModificatCNPPersoana
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.Judet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Judet");
                });

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.Localitate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("JudetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JudetID");

                    b.ToTable("Localitate");
                });

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.Persoana", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("NumePersoana")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("SectieVotareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SectieVotareID");

                    b.ToTable("Persoana");
                });

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.SectieVotare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("LocalitateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LocalitateID");

                    b.ToTable("SectieVotare");
                });

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.Localitate", b =>
                {
                    b.HasOne("Vadean_Flaviu_Proiect.Models.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.Persoana", b =>
                {
                    b.HasOne("Vadean_Flaviu_Proiect.Models.SectieVotare", "SectieVotare")
                        .WithMany()
                        .HasForeignKey("SectieVotareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vadean_Flaviu_Proiect.Models.SectieVotare", b =>
                {
                    b.HasOne("Vadean_Flaviu_Proiect.Models.Localitate", "Localitate")
                        .WithMany()
                        .HasForeignKey("LocalitateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
