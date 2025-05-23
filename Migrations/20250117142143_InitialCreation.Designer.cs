﻿// <auto-generated />
using System;
using ECFJanvier.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECFJanvier.Migrations
{
    [DbContext(typeof(ECFJanvierContext))]
    [Migration("20250117142143_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECFJanvier.Models.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Evenement");
                });

            modelBuilder.Entity("ECFJanvier.Models.EvenementParticipant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("EvenementId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId", "EvenementId");

                    b.HasIndex("EvenementId");

                    b.ToTable("EvenementParticipant");
                });

            modelBuilder.Entity("ECFJanvier.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("ECFJanvier.Models.EvenementParticipant", b =>
                {
                    b.HasOne("ECFJanvier.Models.Evenement", "Evenement")
                        .WithMany("Participants")
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECFJanvier.Models.Participant", "Participant")
                        .WithMany("Evenements")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("ECFJanvier.Models.Evenement", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("ECFJanvier.Models.Participant", b =>
                {
                    b.Navigation("Evenements");
                });
#pragma warning restore 612, 618
        }
    }
}
