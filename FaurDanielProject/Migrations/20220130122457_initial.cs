using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaurDanielProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antrenor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prenume = table.Column<string>(nullable: false),
                    nume = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Intensitate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intensitate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clasa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(nullable: false),
                    NivelID = table.Column<int>(nullable: false),
                    IntensitateID = table.Column<int>(nullable: false),
                    AntrenorID = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clasa_Antrenor_AntrenorID",
                        column: x => x.AntrenorID,
                        principalTable: "Antrenor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clasa_Intensitate_IntensitateID",
                        column: x => x.IntensitateID,
                        principalTable: "Intensitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clasa_Nivel_NivelID",
                        column: x => x.NivelID,
                        principalTable: "Nivel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasa_AntrenorID",
                table: "Clasa",
                column: "AntrenorID");

            migrationBuilder.CreateIndex(
                name: "IX_Clasa_IntensitateID",
                table: "Clasa",
                column: "IntensitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Clasa_NivelID",
                table: "Clasa",
                column: "NivelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clasa");

            migrationBuilder.DropTable(
                name: "Antrenor");

            migrationBuilder.DropTable(
                name: "Intensitate");

            migrationBuilder.DropTable(
                name: "Nivel");
        }
    }
}
