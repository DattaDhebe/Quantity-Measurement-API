﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace CommanLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommanLayer.Models.Compare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOnCreation");

                    b.Property<double>("First_Value");

                    b.Property<string>("First_Value_Unit")
                        .IsRequired();

                    b.Property<string>("MeasurementType")
                        .IsRequired();

                    b.Property<string>("Result");

                    b.Property<double>("Second_Value");

                    b.Property<string>("Second_Value_Unit")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Comparision");
                });

            modelBuilder.Entity("CommanLayer.Quantity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConversionType")
                        .IsRequired();

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<string>("MeasurementType")
                        .IsRequired();

                    b.Property<double>("Result");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("Quantities");
                });
#pragma warning restore 612, 618
        }
    }
}
