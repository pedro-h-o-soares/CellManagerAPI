﻿// <auto-generated />
using System;
using CellManagerAPI.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CellManagerAPI.Infraestructure.Data.Migrations
{
    [DbContext(typeof(CellManagerContext))]
    partial class CellManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("SupervisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupervisionId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("CellId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Supervision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supervisions");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("CellId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Cell", b =>
                {
                    b.HasOne("CellManagerAPI.Domain.Models.Supervision", "Supervision")
                        .WithMany("Cells")
                        .HasForeignKey("SupervisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervision");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Member", b =>
                {
                    b.HasOne("CellManagerAPI.Domain.Models.Cell", "Cell")
                        .WithMany("Members")
                        .HasForeignKey("CellId");

                    b.Navigation("Cell");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Visitor", b =>
                {
                    b.HasOne("CellManagerAPI.Domain.Models.Cell", "Cell")
                        .WithMany("Visitors")
                        .HasForeignKey("CellId");

                    b.Navigation("Cell");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Cell", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("CellManagerAPI.Domain.Models.Supervision", b =>
                {
                    b.Navigation("Cells");
                });
#pragma warning restore 612, 618
        }
    }
}
