using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class eventChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeOfEvent",
                table: "Event",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EventDetails",
                table: "Event",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "DateOfEvent",
                table: "Event",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "BarId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Bars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_BarId",
                table: "Event",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_EventId",
                table: "Bars",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Event_EventId",
                table: "Bars",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Bars_BarId",
                table: "Event",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Event_EventId",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Bars_BarId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_BarId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Bars_EventId",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BarId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Bars");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Event",
                newName: "TimeOfEvent");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Event",
                newName: "EventDetails");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Event",
                newName: "DateOfEvent");
        }
    }
}
