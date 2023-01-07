using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TirileckWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class FixUsersModdleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModdleName",
                table: "Users",
                newName: "MiddleName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Users",
                newName: "ModdleName");
        }
    }
}
