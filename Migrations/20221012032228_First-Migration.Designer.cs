﻿// <auto-generated />
using System;
using InCar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InCar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221012032228_First-Migration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InCar.Entidades.Detalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoDetalle")
                        .HasColumnType("int");

                    b.Property<int>("CodigoHistorial")
                        .HasColumnType("int");

                    b.Property<int>("CodigoProcedimiento")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("HistorialId")
                        .HasColumnType("int");

                    b.Property<int?>("ProcedimientoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistorialId");

                    b.HasIndex("ProcedimientoId");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("InCar.Entidades.Historial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<int>("CodigoVehiculo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Historial");
                });

            modelBuilder.Entity("InCar.Entidades.ImagenVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoVehiculo")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehiculoId");

                    b.ToTable("ImagenVehiculo");
                });

            modelBuilder.Entity("InCar.Entidades.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Pais")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("InCar.Entidades.Procedimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoProcedimiento")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Procedimiento");
                });

            modelBuilder.Entity("InCar.Entidades.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("InCar.Entidades.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TipoVehiculo");
                });

            modelBuilder.Entity("InCar.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoMarca")
                        .HasColumnType("int");

                    b.Property<int>("CodigoTipoVehiculo")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("FechaFabricacion")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("int");

                    b.Property<int>("Modelo")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Precio")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoVehiculoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("InCar.Models.Rol", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("InCar.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("CodigoTipoDocumento")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Movil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("InCar.Models.UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodigoRol")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("RolId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioRol");
                });

            modelBuilder.Entity("InCar.Entidades.Detalle", b =>
                {
                    b.HasOne("InCar.Entidades.Historial", "Historial")
                        .WithMany("Detalle")
                        .HasForeignKey("HistorialId");

                    b.HasOne("InCar.Entidades.Procedimiento", "Procedimiento")
                        .WithMany("Detalle")
                        .HasForeignKey("ProcedimientoId");

                    b.Navigation("Historial");

                    b.Navigation("Procedimiento");
                });

            modelBuilder.Entity("InCar.Entidades.Historial", b =>
                {
                    b.HasOne("InCar.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.HasOne("InCar.Entidades.Vehiculo", "Vehiculo")
                        .WithMany("Historial")
                        .HasForeignKey("VehiculoId");

                    b.Navigation("Usuario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("InCar.Entidades.ImagenVehiculo", b =>
                {
                    b.HasOne("InCar.Entidades.Vehiculo", "Vehiculo")
                        .WithMany("ImagenVehiculo")
                        .HasForeignKey("VehiculoId");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("InCar.Entidades.Vehiculo", b =>
                {
                    b.HasOne("InCar.Entidades.Marca", "Marca")
                        .WithMany("Vehiculo")
                        .HasForeignKey("MarcaId");

                    b.HasOne("InCar.Entidades.TipoVehiculo", "TipoVehiculo")
                        .WithMany("Vehiculo")
                        .HasForeignKey("TipoVehiculoId");

                    b.HasOne("InCar.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Marca");

                    b.Navigation("TipoVehiculo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InCar.Models.Usuario", b =>
                {
                    b.HasOne("InCar.Entidades.TipoDocumento", "TipoDocumento")
                        .WithMany("Usuario")
                        .HasForeignKey("TipoDocumentoId");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("InCar.Models.UsuarioRol", b =>
                {
                    b.HasOne("InCar.Models.Rol", "Rol")
                        .WithMany("UsuarioRol")
                        .HasForeignKey("RolId");

                    b.HasOne("InCar.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InCar.Entidades.Historial", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("InCar.Entidades.Marca", b =>
                {
                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("InCar.Entidades.Procedimiento", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("InCar.Entidades.TipoDocumento", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InCar.Entidades.TipoVehiculo", b =>
                {
                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("InCar.Entidades.Vehiculo", b =>
                {
                    b.Navigation("Historial");

                    b.Navigation("ImagenVehiculo");
                });

            modelBuilder.Entity("InCar.Models.Rol", b =>
                {
                    b.Navigation("UsuarioRol");
                });
#pragma warning restore 612, 618
        }
    }
}
