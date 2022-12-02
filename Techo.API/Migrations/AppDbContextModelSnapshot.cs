﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Techo.Data.Context;

namespace Techo.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Techo.Models.Models.Entities.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComunidadId")
                        .HasColumnType("int");

                    b.Property<bool>("EsMesaTrabajo")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaJornada")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitantesParticipantes")
                        .HasColumnType("int");

                    b.Property<int?>("VoluntarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComunidadId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("Actividad");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.ActividadAlternativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.ToTable("ActividadAlternativa");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Asistencia", b =>
                {
                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("int");

                    b.HasKey("ActividadId", "VoluntarioId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("Asistencia");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreCiudad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Comuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("NombreComuna")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("Comuna");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Comunidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComunaId")
                        .HasColumnType("int");

                    b.Property<string>("DecretoLegalizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("DensidadHombres")
                        .HasColumnType("real");

                    b.Property<float?>("DensidadMujeres")
                        .HasColumnType("real");

                    b.Property<bool>("Legalizado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComunaId");

                    b.ToTable("Comunidad");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.MesaTrabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActividadId")
                        .HasColumnType("int");

                    b.Property<string>("Compromisos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkActa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemasTratados")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.ToTable("MesaTrabajo");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreRol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Voluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("ComunidadId")
                        .HasColumnType("int");

                    b.Property<bool>("CoordinatorProfile")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComunidadId");

                    b.HasIndex("RolId");

                    b.ToTable("Voluntario");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Actividad", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Comunidad", "Comunidad")
                        .WithMany("ActividadesRegistradas")
                        .HasForeignKey("ComunidadId");

                    b.HasOne("Techo.Models.Models.Entities.Voluntario", "Voluntario")
                        .WithMany("ActividadesRegistradas")
                        .HasForeignKey("VoluntarioId");

                    b.Navigation("Comunidad");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.ActividadAlternativa", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Actividad", "Actividad")
                        .WithMany()
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Asistencia", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Actividad", "Actividad")
                        .WithMany("Asistencia")
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Techo.Models.Models.Entities.Voluntario", "Voluntario")
                        .WithMany("Asistencia")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Comuna", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Comunidad", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Comuna", "Comuna")
                        .WithMany()
                        .HasForeignKey("ComunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comuna");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.MesaTrabajo", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Actividad", "Actividad")
                        .WithMany()
                        .HasForeignKey("ActividadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actividad");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Voluntario", b =>
                {
                    b.HasOne("Techo.Models.Models.Entities.Comunidad", "Comunidad")
                        .WithMany("Voluntarios")
                        .HasForeignKey("ComunidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Techo.Models.Models.Entities.Rol", "Rol")
                        .WithMany("Voluntarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comunidad");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Actividad", b =>
                {
                    b.Navigation("Asistencia");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Comunidad", b =>
                {
                    b.Navigation("ActividadesRegistradas");

                    b.Navigation("Voluntarios");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Rol", b =>
                {
                    b.Navigation("Voluntarios");
                });

            modelBuilder.Entity("Techo.Models.Models.Entities.Voluntario", b =>
                {
                    b.Navigation("ActividadesRegistradas");

                    b.Navigation("Asistencia");
                });
#pragma warning restore 612, 618
        }
    }
}
