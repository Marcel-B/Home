﻿// <auto-generated />
using System;
using Home.DataCrawler.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Home.DataCrawler.Migrations
{
    [DbContext(typeof(ValueContext))]
    partial class ValueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571");

            modelBuilder.Entity("Home.Domain.Entities.MeasurePoint", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChannelId");

                    b.Property<DateTimeOffset?>("Create");

                    b.Property<string>("PointName");

                    b.Property<double>("PointValue");

                    b.HasKey("Guid");

                    b.ToTable("MeasurePoints");
                });

            modelBuilder.Entity("Home.Domain.Entities.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("Created");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
