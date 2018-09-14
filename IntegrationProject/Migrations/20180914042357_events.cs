using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Event_EventId",
                table: "Bars");

            migrationBuilder.DropIndex(
                name: "IX_Bars_EventId",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Bars");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_DestinationId",
                table: "Event",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OriginId",
                table: "Event",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Bars_DestinationId",
                table: "Event",
                column: "DestinationId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Origins_OriginId",
                table: "Event",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Bars_DestinationId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Origins_OriginId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_DestinationId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_OriginId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Bars",
                nullable: true);

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
        }
    }
}
