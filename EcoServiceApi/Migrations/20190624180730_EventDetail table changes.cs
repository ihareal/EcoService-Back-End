using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoServiceApi.Migrations
{
    public partial class EventDetailtablechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetail_EventDetails_EventId",
                table: "UserEventDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetail_UserDetails_UserId",
                table: "UserEventDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEventDetail",
                table: "UserEventDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EventDetails");

            migrationBuilder.RenameTable(
                name: "UserEventDetail",
                newName: "UserEventDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserEventDetail_EventId",
                table: "UserEventDetails",
                newName: "IX_UserEventDetails_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEventDetails",
                table: "UserEventDetails",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventDetails_EventDetails_EventId",
                table: "UserEventDetails",
                column: "EventId",
                principalTable: "EventDetails",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventDetails_UserDetails_UserId",
                table: "UserEventDetails",
                column: "UserId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetails_EventDetails_EventId",
                table: "UserEventDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEventDetails_UserDetails_UserId",
                table: "UserEventDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEventDetails",
                table: "UserEventDetails");

            migrationBuilder.RenameTable(
                name: "UserEventDetails",
                newName: "UserEventDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserEventDetails_EventId",
                table: "UserEventDetail",
                newName: "IX_UserEventDetail_EventId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEventDetail",
                table: "UserEventDetail",
                columns: new[] { "UserId", "EventId" });

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
    }
}
