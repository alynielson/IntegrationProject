using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationProject.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Answers_AnswerId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Admins_AdminId",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Answers_AnswerId",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Answers_AnswerId",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Answers_AnswerId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Answers_AnswerId",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musics",
                table: "Musics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Musics",
                newName: "Music");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "Drinks",
                newName: "Drink");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "ActivityItem");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_AnswerId",
                table: "Music",
                newName: "IX_Music_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_AnswerId",
                table: "Food",
                newName: "IX_Food_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drinks_AnswerId",
                table: "Drink",
                newName: "IX_Drink_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_AnswerId",
                table: "ActivityItem",
                newName: "IX_ActivityItem_AnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Bars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Bars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Music",
                table: "Music",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drink",
                table: "Drink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityItem",
                table: "ActivityItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityItem_Answers_AnswerId",
                table: "ActivityItem",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Admins_AdminId",
                table: "Bars",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Answers_AnswerId",
                table: "Bars",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityItem_Answers_AnswerId",
                table: "ActivityItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Admins_AdminId",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Answers_AnswerId",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Answers_AnswerId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Answers_AnswerId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Music_Answers_AnswerId",
                table: "Music");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Music",
                table: "Music");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drink",
                table: "Drink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityItem",
                table: "ActivityItem");

            migrationBuilder.RenameTable(
                name: "Music",
                newName: "Musics");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "Drink",
                newName: "Drinks");

            migrationBuilder.RenameTable(
                name: "ActivityItem",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_Music_AnswerId",
                table: "Musics",
                newName: "IX_Musics_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_AnswerId",
                table: "Foods",
                newName: "IX_Foods_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drink_AnswerId",
                table: "Drinks",
                newName: "IX_Drinks_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityItem_AnswerId",
                table: "Activities",
                newName: "IX_Activities_AnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Bars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Bars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musics",
                table: "Musics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Answers_AnswerId",
                table: "Activities",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Admins_AdminId",
                table: "Bars",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Answers_AnswerId",
                table: "Bars",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Answers_AnswerId",
                table: "Drinks",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Answers_AnswerId",
                table: "Foods",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Answers_AnswerId",
                table: "Musics",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
