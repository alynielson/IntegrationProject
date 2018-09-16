using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class namesOfLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Waypoints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Origins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Destinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Waypoints");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Origins");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Destinations");
        }
    }
}
