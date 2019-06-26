using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoServiceApi.Migrations
{
    public partial class pollutionmodelchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "PollutionDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "PollutionDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PollutionDetails");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PollutionDetails");
        }
    }
}
