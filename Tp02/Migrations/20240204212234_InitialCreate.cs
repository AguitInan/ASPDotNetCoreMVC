using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tp02.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantite = table.Column<int>(type: "int", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categorie_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.id);
                    table.ForeignKey(
                        name: "FK_produit_categorie_categorie_id",
                        column: x => x.categorie_id,
                        principalTable: "categorie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categorie",
                columns: new[] { "id", "nom" },
                values: new object[] { 1, "Electronique" });

            migrationBuilder.InsertData(
                table: "categorie",
                columns: new[] { "id", "nom" },
                values: new object[] { 2, "Vêtement" });

            migrationBuilder.InsertData(
                table: "categorie",
                columns: new[] { "id", "nom" },
                values: new object[] { 3, "Cuisine" });

            migrationBuilder.InsertData(
                table: "produit",
                columns: new[] { "id", "categorie_id", "description", "image_url", "nom", "prix", "quantite" },
                values: new object[] { 1, 1, "Bose", "url_to_image", "Ecouteurs", 89.99m, 100 });

            migrationBuilder.InsertData(
                table: "produit",
                columns: new[] { "id", "categorie_id", "description", "image_url", "nom", "prix", "quantite" },
                values: new object[] { 2, 2, "Nike", "url_to_image", "Sweater", 49.99m, 50 });

            migrationBuilder.InsertData(
                table: "produit",
                columns: new[] { "id", "categorie_id", "description", "image_url", "nom", "prix", "quantite" },
                values: new object[] { 3, 3, "Pour smoothies", "url_to_image", "Blender", 29.99m, 80 });

            migrationBuilder.CreateIndex(
                name: "IX_produit_categorie_id",
                table: "produit",
                column: "categorie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "categorie");
        }
    }
}
