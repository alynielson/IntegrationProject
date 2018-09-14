using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class anotheronebitesthedust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Event_EventId",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Bars_DestinationId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Origins_Event_EventId",
                table: "Origins");

            migrationBuilder.DropIndex(
                name: "IX_Origins_EventId",
                table: "Origins");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_EventId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Origins");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Destinations");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Destinations_DestinationId",
                table: "Event",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Destinations_DestinationId",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Origins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Destinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Origins_EventId",
                table: "Origins",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_EventId",
                table: "Destinations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Event_EventId",
                table: "Destinations",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Bars_DestinationId",
                table: "Event",
                column: "DestinationId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Origins_Event_EventId",
                table: "Origins",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
