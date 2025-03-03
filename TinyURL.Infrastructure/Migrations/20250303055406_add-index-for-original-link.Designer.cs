﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TinyURL.Infrastructure.Data;

#nullable disable

namespace TinyURL.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250303055406_add-index-for-original-link")]
    partial class addindexfororiginallink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TinyURL.Domain.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OriginalURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ShortCutURLCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OriginalURL")
                        .IsUnique();

                    b.ToTable("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
