﻿// <auto-generated />
using GestorEscolarAPI.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorEscolarAPI.Server.Migrations
{
    [DbContext(typeof(GestorEscolarContext))]
    partial class GestorEscolarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Grado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.Property<int>("alumnoId")
                        .HasColumnType("int");

                    b.Property<int>("materiaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("alumnoId");

                    b.HasIndex("materiaId");

                    b.ToTable("Calificaciones");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semestre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("profesorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("profesorId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Calificacion", b =>
                {
                    b.HasOne("GestorEscolarAPI.Server.Models.Alumno", "Alumno")
                        .WithMany("Calificaciones")
                        .HasForeignKey("alumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorEscolarAPI.Server.Models.Materia", "Materia")
                        .WithMany("Calificaciones")
                        .HasForeignKey("materiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Materia", b =>
                {
                    b.HasOne("GestorEscolarAPI.Server.Models.Profesor", "Profesor")
                        .WithMany("Materias")
                        .HasForeignKey("profesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Alumno", b =>
                {
                    b.Navigation("Calificaciones");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Materia", b =>
                {
                    b.Navigation("Calificaciones");
                });

            modelBuilder.Entity("GestorEscolarAPI.Server.Models.Profesor", b =>
                {
                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
