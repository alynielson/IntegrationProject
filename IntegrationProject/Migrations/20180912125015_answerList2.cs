using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class answerList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Drink",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Drink");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Drink",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "Drink",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drink",
                table: "Drink",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Drink",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "Checked",
                table: "Drink");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Drink",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Drink",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drink",
                table: "Drink",
                column: "Id");
        }
    }
}
