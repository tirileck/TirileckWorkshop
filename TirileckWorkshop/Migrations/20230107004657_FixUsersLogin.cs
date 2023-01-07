using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TirileckWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class FixUsersLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
