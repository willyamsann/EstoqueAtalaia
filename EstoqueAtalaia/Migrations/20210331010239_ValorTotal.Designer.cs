﻿// <auto-generated />
using System;
using EstoqueAtalaia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstoqueAtalaia.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210331010239_ValorTotal")]
    partial class ValorTotal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstoqueAtalaia.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("EstoqueAtalaia.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("EstoqueAtalaia.Models.OrdemDeServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aparelho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detalhes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Garantia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reclamacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ValorPeca")
                        .HasColumnType("real");

                    b.Property<float>("ValorServico")
                        .HasColumnType("real");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("OrdemDeServicos");
                });

            modelBuilder.Entity("EstoqueAtalaia.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EstoqueAtalaia.Models.ProductOutput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOutputs");
                });

            modelBuilder.Entity("EstoqueAtalaia.Models.Product", b =>
                {
                    b.HasOne("EstoqueAtalaia.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstoqueAtalaia.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstoqueAtalaia.Models.ProductOutput", b =>
                {
                    b.HasOne("EstoqueAtalaia.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
