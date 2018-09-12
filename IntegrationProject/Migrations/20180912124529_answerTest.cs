using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class answerTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drinks",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    AnswerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drink_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_AnswerId",
                table: "Drink",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.AddColumn<string>(
                name: "Drinks",
                table: "Answers",
                nullable: true);
        }
    }
}
