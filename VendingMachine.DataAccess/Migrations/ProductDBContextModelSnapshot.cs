﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendingMachine.DataAccess.EntityFrameworkRepository;

namespace VendingMachine.DataAccess.Migrations
{
    [DbContext(typeof(VendingMachineDBContext))]
    partial class ProductDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("iQuest.VendingMachine.Business.Domaine.Product", b =>
                {
                    b.Property<int>("ColumnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ColumnId");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}