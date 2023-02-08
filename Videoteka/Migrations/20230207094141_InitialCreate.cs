using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Videoteka.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    ZaposlenikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeZaposlenika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezimeZaposlenika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelZaposlenika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailZaposlenika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PozicijaZaposlenika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacaZaposlenika = table.Column<long>(type: "bigint", nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumRodenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.ZaposlenikId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zaposlenici");
        }
    }
}
