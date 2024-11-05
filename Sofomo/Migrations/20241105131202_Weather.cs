using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofomo.Migrations
{
    /// <inheritdoc />
    public partial class Weather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDto_Locations_LocationId",
                table: "WeatherDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherDto",
                table: "WeatherDto");

            migrationBuilder.RenameTable(
                name: "WeatherDto",
                newName: "Weather");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherDto_LocationId",
                table: "Weather",
                newName: "IX_Weather_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_Locations_LocationId",
                table: "Weather",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weather_Locations_LocationId",
                table: "Weather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.RenameTable(
                name: "Weather",
                newName: "WeatherDto");

            migrationBuilder.RenameIndex(
                name: "IX_Weather_LocationId",
                table: "WeatherDto",
                newName: "IX_WeatherDto_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherDto",
                table: "WeatherDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDto_Locations_LocationId",
                table: "WeatherDto",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
