using Microsoft.EntityFrameworkCore.Migrations;

namespace Git.Migrations
{
    public partial class FixMissingColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReposotoryId",
                table: "Commits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReposotoryId",
                table: "Commits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
