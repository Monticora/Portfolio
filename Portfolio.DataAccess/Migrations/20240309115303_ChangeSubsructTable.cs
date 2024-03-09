using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubsructTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "SubcategoriesTable");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "SubcategoriesTable");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubcategoriesTable",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubcategoriesTable");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "SubcategoriesTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "SubcategoriesTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
