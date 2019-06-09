using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoServiceApi.Migrations
{
    public partial class Changes_New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetail_UserDetails_UserDetailUserId",
                table: "UserEventDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetail_EventDetails_UserId",
                table: "UserEventDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserEventDetail_UserDetailUserId",
                table: "UserEventDetail");

            migrationBuilder.DropColumn(
                name: "UserDetailUserId",
                table: "UserEventDetail");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventDetail_EventId",
                table: "UserEventDetail",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventDetail_EventDetails_EventId",
                table: "UserEventDetail",
                column: "EventId",
                principalTable: "EventDetails",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventDetail_UserDetails_UserId",
                table: "UserEventDetail",
                column: "UserId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetail_EventDetails_EventId",
                table: "UserEventDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetail_UserDetails_UserId",
                table: "UserEventDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserEventDetail_EventId",
                table: "UserEventDetail");

            migrationBuilder.AddColumn<int>(
                name: "UserDetailUserId",
                table: "UserEventDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEventDetail_UserDetailUserId",
                table: "UserEventDetail",
                column: "UserDetailUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventDetail_UserDetails_UserDetailUserId",
                table: "UserEventDetail",
                column: "UserDetailUserId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventDetail_EventDetails_UserId",
                table: "UserEventDetail",
                column: "UserId",
                principalTable: "EventDetails",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
