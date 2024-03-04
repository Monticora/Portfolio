using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeytoQA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "QuestionAndAnswersTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAndAnswersTable_CategoryId",
                table: "QuestionAndAnswersTable",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAndAnswersTable_CategoriesTable_CategoryId",
                table: "QuestionAndAnswersTable",
                column: "CategoryId",
                principalTable: "CategoriesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAndAnswersTable_CategoriesTable_CategoryId",
                table: "QuestionAndAnswersTable");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAndAnswersTable_CategoryId",
                table: "QuestionAndAnswersTable");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "QuestionAndAnswersTable");
        }
    }
}
