using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class actuallyRemoveBar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Bars_BarId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_BarId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "BarId",
                table: "Event");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_BarId",
                table: "Event",
                column: "BarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Bars_BarId",
                table: "Event",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
