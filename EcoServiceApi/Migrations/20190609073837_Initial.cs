using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoServiceApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsDetails",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ReadingTime = table.Column<int>(nullable: false),
                    isRead = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDetails", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    isAdmin = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    DwellingType = table.Column<string>(nullable: false),
                    StageNumber = table.Column<int>(nullable: false),
                    StageAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_EventDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollutionDetails",
                columns: table => new
                {
                    PollutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollutionDetails", x => x.PollutionId);
                    table.ForeignKey(
                        name: "FK_PollutionDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNewsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    NewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNewsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNewsDetail_NewsDetails_NewsId",
                        column: x => x.NewsId,
                        principalTable: "NewsDetails",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNewsDetail_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_UserId",
                table: "EventDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PollutionDetails_UserId",
                table: "PollutionDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNewsDetail_NewsId",
                table: "UserNewsDetail",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNewsDetail_UserId",
                table: "UserNewsDetail",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "PollutionDetails");

            migrationBuilder.DropTable(
                name: "UserNewsDetail");

            migrationBuilder.DropTable(
                name: "NewsDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
