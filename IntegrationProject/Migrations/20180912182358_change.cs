using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Bars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image_Url",
                table: "Bars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Bars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Bars",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "YelpRating",
                table: "Bars",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "Bars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Image_Url",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "YelpRating",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Bars");
        }
    }
}
