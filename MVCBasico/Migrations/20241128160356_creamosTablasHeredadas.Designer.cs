﻿// <auto-generated />
using MVCBasico.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCBasico.Migrations
{
    [DbContext(typeof(ElectronicaDatabaseContext))]
    [Migration("20241128160356_creamosTablasHeredadas")]
    partial class creamosTablasHeredadas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCBasico.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MVCBasico.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MVCBasico.Models.Venta", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VentaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<string>("cvv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccionEnvio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailComprador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaVencimientoTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medioDePago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VentaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("MVCBasico.Models.Auricular", b =>
                {
                    b.HasBaseType("MVCBasico.Models.Producto");

                    b.Property<int>("potenciaWatts")
                        .HasColumnType("int");

                    b.ToTable("Auriculares", (string)null);
                });

            modelBuilder.Entity("MVCBasico.Models.Celular", b =>
                {
                    b.HasBaseType("MVCBasico.Models.Producto");

                    b.Property<int>("memoriaRam")
                        .HasColumnType("int");

                    b.Property<string>("procesador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Celulares", (string)null);
                });

            modelBuilder.Entity("MVCBasico.Models.Computadora", b =>
                {
                    b.HasBaseType("MVCBasico.Models.Producto");

                    b.Property<bool>("lectorDisco")
                        .HasColumnType("bit");

                    b.Property<int>("memoriaRam")
                        .HasColumnType("int");

                    b.Property<string>("procesador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Computadoras", (string)null);
                });

            modelBuilder.Entity("MVCBasico.Models.Venta", b =>
                {
                    b.HasOne("MVCBasico.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBasico.Models.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("producto");
                });

            modelBuilder.Entity("MVCBasico.Models.Auricular", b =>
                {
                    b.HasOne("MVCBasico.Models.Producto", null)
                        .WithOne()
                        .HasForeignKey("MVCBasico.Models.Auricular", "ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBasico.Models.Celular", b =>
                {
                    b.HasOne("MVCBasico.Models.Producto", null)
                        .WithOne()
                        .HasForeignKey("MVCBasico.Models.Celular", "ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBasico.Models.Computadora", b =>
                {
                    b.HasOne("MVCBasico.Models.Producto", null)
                        .WithOne()
                        .HasForeignKey("MVCBasico.Models.Computadora", "ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
