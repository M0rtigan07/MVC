using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Peli",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peli", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Peli_Genero_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Genero",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peli_GeneroID",
                table: "Peli",
                column: "GeneroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peli");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
