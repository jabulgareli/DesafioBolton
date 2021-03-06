﻿// <auto-generated />
using System;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Migrations
{
    [DbContext(typeof(BoltonContext))]
    [Migration("20200115021235_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioBolton.Bolton.Domain.Core.NFes.Aggregates.NFe", b =>
                {
                    b.Property<string>("AccessKey")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(18,6)");

                    b.HasKey("AccessKey");

                    b.ToTable("NFE");
                });

            modelBuilder.Entity("DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects.ImportProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentPage");

                    b.HasKey("Id");

                    b.ToTable("IMPORT_PROFILE");
                });
#pragma warning restore 612, 618
        }
    }
}
