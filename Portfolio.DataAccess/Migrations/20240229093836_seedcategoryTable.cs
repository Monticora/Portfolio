using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedcategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoriesTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".Net" },
                    { 2, "JS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriesTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriesTable",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
