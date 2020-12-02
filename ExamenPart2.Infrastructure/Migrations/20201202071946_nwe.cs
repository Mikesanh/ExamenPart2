using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenPart2.Infrastructure.Migrations
{
    public partial class nwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bought = table.Column<bool>(type: "INTEGER", nullable: false),
                    albumName = table.Column<string>(type: "TEXT", nullable: false),
                    artistName = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    genre = table.Column<string>(type: "TEXT", nullable: true),
                    score = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    albumId = table.Column<int>(type: "INTEGER", nullable: false),
                    bought = table.Column<bool>(type: "INTEGER", nullable: false),
                    songName = table.Column<string>(type: "TEXT", nullable: false),
                    artistName = table.Column<string>(type: "TEXT", nullable: false),
                    duration = table.Column<int>(type: "INTEGER", nullable: false),
                    popularity = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_albumId",
                        column: x => x.albumId,
                        principalTable: "Albums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_albumId",
                table: "Songs",
                column: "albumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
