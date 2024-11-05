using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofomo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weather_Locations_LocationId",
                table: "Weather");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Weather",
                newName: "LocationDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Weather_LocationId",
                table: "Weather",
                newName: "IX_Weather_LocationDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_Locations_LocationDtoId",
                table: "Weather",
                column: "LocationDtoId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weather_Locations_LocationDtoId",
                table: "Weather");

            migrationBuilder.RenameColumn(
                name: "LocationDtoId",
                table: "Weather",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Weather_LocationDtoId",
                table: "Weather",
                newName: "IX_Weather_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_Locations_LocationId",
                table: "Weather",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
