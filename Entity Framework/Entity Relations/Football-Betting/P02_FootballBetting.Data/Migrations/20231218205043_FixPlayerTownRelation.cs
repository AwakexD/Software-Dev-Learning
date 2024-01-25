using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_FootballBetting.Data.Migrations
{
    public partial class FixPlayerTownRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Players_TownId",
                table: "Players",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Towns_TownId",
                table: "Players",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Towns_TownId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TownId",
                table: "Players");
        }
    }
}
