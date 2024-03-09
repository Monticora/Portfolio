using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSubcategoryAndChangeForienfKeyOfQA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAndAnswersTable_CategoriesTable_CategoryId",
                table: "QuestionAndAnswersTable");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "QuestionAndAnswersTable",
                newName: "SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAndAnswersTable_CategoryId",
                table: "QuestionAndAnswersTable",
                newName: "IX_QuestionAndAnswersTable_SubcategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "SubcategoriesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoriesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubcategoriesTable_CategoriesTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoriesTable_CategoryId",
                table: "SubcategoriesTable",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAndAnswersTable_SubcategoriesTable_SubcategoryId",
                table: "QuestionAndAnswersTable",
                column: "SubcategoryId",
                principalTable: "SubcategoriesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAndAnswersTable_SubcategoriesTable_SubcategoryId",
                table: "QuestionAndAnswersTable");

            migrationBuilder.DropTable(
                name: "SubcategoriesTable");

            migrationBuilder.RenameColumn(
                name: "SubcategoryId",
                table: "QuestionAndAnswersTable",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAndAnswersTable_SubcategoryId",
                table: "QuestionAndAnswersTable",
                newName: "IX_QuestionAndAnswersTable_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAndAnswersTable_CategoriesTable_CategoryId",
                table: "QuestionAndAnswersTable",
                column: "CategoryId",
                principalTable: "CategoriesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
