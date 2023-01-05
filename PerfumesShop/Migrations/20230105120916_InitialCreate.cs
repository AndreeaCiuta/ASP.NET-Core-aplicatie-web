using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumesShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Concentratie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conctr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concentratie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parfum",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantitate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TVarf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TMijloc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TBaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: true),
                    TipID = table.Column<int>(type: "int", nullable: true),
                    ConcentratieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parfum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parfum_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Parfum_Concentratie_ConcentratieID",
                        column: x => x.ConcentratieID,
                        principalTable: "Concentratie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Parfum_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vandut",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorID = table.Column<int>(type: "int", nullable: true),
                    ParfumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vandut", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vandut_Parfum_ParfumID",
                        column: x => x.ParfumID,
                        principalTable: "Parfum",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vandut_Utilizator_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parfum_CategorieID",
                table: "Parfum",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Parfum_ConcentratieID",
                table: "Parfum",
                column: "ConcentratieID");

            migrationBuilder.CreateIndex(
                name: "IX_Parfum_TipID",
                table: "Parfum",
                column: "TipID");

            migrationBuilder.CreateIndex(
                name: "IX_Vandut_ParfumID",
                table: "Vandut",
                column: "ParfumID");

            migrationBuilder.CreateIndex(
                name: "IX_Vandut_UtilizatorID",
                table: "Vandut",
                column: "UtilizatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vandut");

            migrationBuilder.DropTable(
                name: "Parfum");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Concentratie");

            migrationBuilder.DropTable(
                name: "Tip");
        }
    }
}
