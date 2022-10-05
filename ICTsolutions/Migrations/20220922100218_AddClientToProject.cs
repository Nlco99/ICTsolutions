using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICTsolutions.Migrations
{
    public partial class AddClientToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Client",
                table: "projects",
                newName: "ClientName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "projects",
                newName: "Client");
        }
    }
}
