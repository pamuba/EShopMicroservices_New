﻿// <auto-generated />
using System;
using EFCore_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250529052606_Book_MOD_1")]
    partial class Book_MOD_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFCore_Model.Models.Book", b =>
                {
                    b.Property<int>("IDBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("longtext");

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("IDBook");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
