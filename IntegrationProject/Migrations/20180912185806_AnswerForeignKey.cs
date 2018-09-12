using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class AnswerForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityItem_Answers_AnswerId",
                table: "ActivityItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Answers_AnswerId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Answers_AnswerId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Music_Answers_AnswerId",
                table: "Music");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Music",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Food",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Drink",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "ActivityItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityItem_Answers_AnswerId",
                table: "ActivityItem",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Answers_AnswerId",
                table: "Drink",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Answers_AnswerId",
                table: "Food",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Answers_AnswerId",
                table: "Music",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityItem_Answers_AnswerId",
                table: "ActivityItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Answers_AnswerId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Answers_AnswerId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Music_Answers_AnswerId",
                table: "Music");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Music",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Food",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Drink",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "ActivityItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityItem_Answers_AnswerId",
                table: "ActivityItem",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Answers_AnswerId",
                table: "Drink",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Answers_AnswerId",
                table: "Food",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Answers_AnswerId",
                table: "Music",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
