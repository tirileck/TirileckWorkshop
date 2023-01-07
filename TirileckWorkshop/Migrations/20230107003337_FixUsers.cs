using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TirileckWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class FixUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkShops_WorkshopId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "WorkshopId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkShops_WorkshopId",
                table: "Users",
                column: "WorkshopId",
                principalTable: "WorkShops",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkShops_WorkshopId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "WorkshopId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkShops_WorkshopId",
                table: "Users",
                column: "WorkshopId",
                principalTable: "WorkShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
