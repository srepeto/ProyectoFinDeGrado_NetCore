using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoSangre.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bancosangredb");

            migrationBuilder.CreateTable(
                name: "donantes",
                schema: "bancosangredb",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Gruposanguineo = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Factorrh = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donantes", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "donaciones",
                schema: "bancosangredb",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    Donantefk = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donaciones_donantes_Donantefk",
                        column: x => x.Donantefk,
                        principalSchema: "bancosangredb",
                        principalTable: "donantes",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donaciones_Donantefk",
                schema: "bancosangredb",
                table: "donaciones",
                column: "Donantefk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donaciones",
                schema: "bancosangredb");

            migrationBuilder.DropTable(
                name: "donantes",
                schema: "bancosangredb");
        }
    }
}
