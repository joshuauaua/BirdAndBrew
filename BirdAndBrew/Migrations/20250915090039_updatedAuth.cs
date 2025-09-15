using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdAndBrew.Migrations
{
    /// <inheritdoc />
    public partial class updatedAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admins",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Admins",
                newName: "UserName");
        }
    }
}
