using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class ChagneMemberToUserEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Members_MemberId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_MemberId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_ApplicationUserId",
                table: "Event",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_AspNetUsers_ApplicationUserId",
                table: "Event",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_AspNetUsers_ApplicationUserId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_ApplicationUserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_MemberId",
                table: "Event",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Members_MemberId",
                table: "Event",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
