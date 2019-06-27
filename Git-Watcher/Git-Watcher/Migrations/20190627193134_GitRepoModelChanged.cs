using Microsoft.EntityFrameworkCore.Migrations;

namespace Git_Watcher.Migrations
{
    public partial class GitRepoModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "GitRepos",
                newName: "RepoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepoId",
                schema: "dbo",
                table: "GitRepos",
                newName: "Name");
        }
    }
}
