using Microsoft.EntityFrameworkCore.Migrations;

namespace Aquarium.DAL.Migrations
{
    public partial class InitialModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aquariums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(nullable: true),
                    Volume = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    NameCompany = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquariums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kind = table.Column<string>(nullable: true),
                    AquaId = table.Column<int>(nullable: false),
                    AquariumId = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    NameCompany = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fishes_Aquariums_AquariumId",
                        column: x => x.AquariumId,
                        principalTable: "Aquariums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_AquariumId",
                table: "Fishes",
                column: "AquariumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fishes");

            migrationBuilder.DropTable(
                name: "Aquariums");
        }
    }
}
