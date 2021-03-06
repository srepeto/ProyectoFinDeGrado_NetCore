// <auto-generated />
using System;
using BancoSangre.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoSangre.EntityFramework.Migrations
{
    [DbContext(typeof(BancoSangreDbContext))]
    [Migration("20210407150539_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("bancosangredb")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BancoSangre.Domain.Models.Donacion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Donantefk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Donantefk");

                    b.ToTable("donaciones", "bancosangredb");
                });

            modelBuilder.Entity("BancoSangre.Domain.Models.Donante", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Factorrh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gruposanguineo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Dni");

                    b.ToTable("donantes", "bancosangredb");
                });

            modelBuilder.Entity("BancoSangre.Domain.Models.Donacion", b =>
                {
                    b.HasOne("BancoSangre.Domain.Models.Donante", "Donante")
                        .WithMany("Donaciones")
                        .HasForeignKey("Donantefk");

                    b.Navigation("Donante");
                });

            modelBuilder.Entity("BancoSangre.Domain.Models.Donante", b =>
                {
                    b.Navigation("Donaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
