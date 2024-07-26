using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoServiceConnect.Api.Migrations
{
    /// <inheritdoc />
    public partial class Refactorusersandroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoServiceManagers_AutoServices_AutoServiceId",
                table: "AutoServiceManagers");

            migrationBuilder.AlterColumn<int>(
                name: "AutoServiceId",
                table: "AutoServiceManagers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoServiceManagers_AutoServices_AutoServiceId",
                table: "AutoServiceManagers",
                column: "AutoServiceId",
                principalTable: "AutoServices",
                principalColumn: "AutoServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoServiceManagers_AutoServices_AutoServiceId",
                table: "AutoServiceManagers");

            migrationBuilder.AlterColumn<int>(
                name: "AutoServiceId",
                table: "AutoServiceManagers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoServiceManagers_AutoServices_AutoServiceId",
                table: "AutoServiceManagers",
                column: "AutoServiceId",
                principalTable: "AutoServices",
                principalColumn: "AutoServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
