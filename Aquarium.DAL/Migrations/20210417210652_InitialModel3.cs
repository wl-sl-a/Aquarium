using Microsoft.EntityFrameworkCore.Migrations;

namespace Aquarium.DAL.Migrations
{
    public partial class InitialModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fishes_Aquariums_AquariumId",
                table: "Fishes");

            migrationBuilder.DropColumn(
                name: "AquaId",
                table: "Fishes");

            migrationBuilder.AlterColumn<int>(
                name: "AquariumId",
                table: "Fishes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fishes_Aquariums_AquariumId",
                table: "Fishes",
                column: "AquariumId",
                principalTable: "Aquariums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fishes_Aquariums_AquariumId",
                table: "Fishes");

            migrationBuilder.AlterColumn<int>(
                name: "AquariumId",
                table: "Fishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AquaId",
                table: "Fishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Fishes_Aquariums_AquariumId",
                table: "Fishes",
                column: "AquariumId",
                principalTable: "Aquariums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
//dotnet ef --startup-project Aquarium/Aquarium.csproj migrations add InitialModel3 -p Aquarium.DAL/Aquarium.DAL.csproj
//dotnet ef --startup-project Aquarium/Aquarium.csproj database update