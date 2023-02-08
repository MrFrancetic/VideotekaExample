using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Videoteka.Migrations
{
    /// <inheritdoc />
    public partial class Clan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BrojTelZaposlenika",
                table: "Zaposlenici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezimeClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlicaClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KucniBrClana = table.Column<int>(type: "int", nullable: false),
                    BrojTelClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailClana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrijavljenDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumClanarine = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.ClanId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanovi");

            migrationBuilder.AlterColumn<string>(
                name: "BrojTelZaposlenika",
                table: "Zaposlenici",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
