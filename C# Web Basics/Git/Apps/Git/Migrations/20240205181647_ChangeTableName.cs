using Microsoft.EntityFrameworkCore.Migrations;

namespace Git.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Repository_RepositoryId",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Users_OwnerId",
                table: "Repository");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repository",
                table: "Repository");

            migrationBuilder.RenameTable(
                name: "Repository",
                newName: "Repositories");

            migrationBuilder.RenameIndex(
                name: "IX_Repository_OwnerId",
                table: "Repositories",
                newName: "IX_Repositories_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repositories",
                table: "Repositories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Repositories_RepositoryId",
                table: "Commits",
                column: "RepositoryId",
                principalTable: "Repositories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repositories_Users_OwnerId",
                table: "Repositories",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Repositories_RepositoryId",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_Repositories_Users_OwnerId",
                table: "Repositories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repositories",
                table: "Repositories");

            migrationBuilder.RenameTable(
                name: "Repositories",
                newName: "Repository");

            migrationBuilder.RenameIndex(
                name: "IX_Repositories_OwnerId",
                table: "Repository",
                newName: "IX_Repository_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repository",
                table: "Repository",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Repository_RepositoryId",
                table: "Commits",
                column: "RepositoryId",
                principalTable: "Repository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Users_OwnerId",
                table: "Repository",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
