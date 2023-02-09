using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Videoteka.Migrations
{
    /// <inheritdoc />
    public partial class Sve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezimeClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosKod = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorijaProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorijaProizvoda2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaProizvoda3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpisProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direktor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Glumci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodProizvoda = table.Column<double>(type: "float", nullable: false),
                    DatumIzlaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDolaskaWeb = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.ProizvodId);
                });

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
                name: "Clanovi");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Zaposlenici");
        }
    }
}
