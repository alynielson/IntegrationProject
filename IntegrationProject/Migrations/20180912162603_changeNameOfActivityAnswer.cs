using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class changeNameOfActivityAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activities",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Foods",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Music",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "ActivityItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Checked = table.Column<bool>(nullable: false),
                    AnswerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityItem_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Checked = table.Column<bool>(nullable: false),
                    AnswerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Checked = table.Column<bool>(nullable: false),
                    AnswerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Music_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityItem_AnswerId",
                table: "ActivityItem",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_AnswerId",
                table: "Food",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Music_AnswerId",
                table: "Music",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityItem");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.AddColumn<string>(
                name: "Activities",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foods",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Music",
                table: "Answers",
                nullable: true);
        }
    }
}
