using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TirileckWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderDeviceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeviceTypes_DeviceTypeId",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceTypeId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeviceTypes_DeviceTypeId",
                table: "Orders",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeviceTypes_DeviceTypeId",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceTypeId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeviceTypes_DeviceTypeId",
                table: "Orders",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
