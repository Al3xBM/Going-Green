﻿// <auto-generated />
using System;
using FormGenerator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormGenerator.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210417123123_AddedImageURL")]
    partial class AddedImageURL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("FormGenerator.Entities.BaseProduct", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Colour")
                        .HasColumnType("TEXT");

                    b.Property<string>("Consumption")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EnergyClass")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Series")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseProduct");
                });

            modelBuilder.Entity("FormGenerator.Entities.Fridge", b =>
                {
                    b.HasBaseType("FormGenerator.Entities.BaseProduct");

                    b.Property<float>("Depth")
                        .HasColumnType("REAL");

                    b.Property<int>("Doors")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasFreezer")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Height")
                        .HasColumnType("REAL");

                    b.Property<float>("Volume")
                        .HasColumnType("REAL");

                    b.Property<float>("Width")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("Fridge");
                });

            modelBuilder.Entity("FormGenerator.Entities.Television", b =>
                {
                    b.HasBaseType("FormGenerator.Entities.BaseProduct");

                    b.Property<float>("Diagonal")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsSmart")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resolution")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Television");
                });
#pragma warning restore 612, 618
        }
    }
}
