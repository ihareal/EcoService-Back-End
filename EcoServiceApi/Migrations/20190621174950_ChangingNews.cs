using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoServiceApi.Migrations
{
    public partial class ChangingNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingTime",
                table: "NewsDetails");

            migrationBuilder.DropColumn(
                name: "isRead",
                table: "NewsDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "NewsDetails",
                type: "DateTime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "NewsDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "NewsDetails");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "NewsDetails");

            migrationBuilder.AddColumn<int>(
                name: "ReadingTime",
                table: "NewsDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isRead",
                table: "NewsDetails",
                nullable: false,
                defaultValue: 0);
        }
    }
}
