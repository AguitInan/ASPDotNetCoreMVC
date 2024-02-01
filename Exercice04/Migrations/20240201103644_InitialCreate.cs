using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice04.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marmosets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marmosets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Marmosets",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { 1, 1, "Marmoset1" });

            migrationBuilder.InsertData(
                table: "Marmosets",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { 2, 0, "Marmoset2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marmosets");
        }
    }
}
