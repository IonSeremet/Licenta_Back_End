using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoServiceConnect.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoServicetoAutoServiceManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoServiceId",
                table: "AutoServiceManagers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AutoServiceManagers_AutoServiceId",
                table: "AutoServiceManagers",
                column: "AutoServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoServiceManagers_AutoServices_AutoServiceId",
                table: "AutoServiceManagers",
                column: "AutoServiceId",
                principalTable: "AutoServices",
                principalColumn: "AutoServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoServiceManagers_AutoServices_AutoServiceId",
                table: "AutoServiceManagers");

            migrationBuilder.DropIndex(
                name: "IX_AutoServiceManagers_AutoServiceId",
                table: "AutoServiceManagers");

            migrationBuilder.DropColumn(
                name: "AutoServiceId",
                table: "AutoServiceManagers");
        }
    }
}
