using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    public partial class AddGenreFromJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "name" },
                values: new object[] { 11, "Test2" });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "name" },
                values: new object[] { 12, "Test3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 12);
        }
    }
}
