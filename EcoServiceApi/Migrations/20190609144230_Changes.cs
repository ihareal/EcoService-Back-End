using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoServiceApi.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventDetails_UserDetails_UserId",
                table: "EventDetails");

            migrationBuilder.DropIndex(
                name: "IX_EventDetails_UserId",
                table: "EventDetails");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "UserDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserEventDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserDetailUserId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEventDetail_UserDetails_UserDetailUserId",
                        column: x => x.UserDetailUserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEventDetail_EventDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "EventDetails",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEventDetail_UserDetailUserId",
                table: "UserEventDetail",
                column: "UserDetailUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventDetail_UserId",
                table: "UserEventDetail",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventDetail");

            migrationBuilder.DropColumn(
                name: "District",
                table: "UserDetails");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_UserId",
                table: "EventDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDetails_UserDetails_UserId",
                table: "EventDetails",
                column: "UserId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
