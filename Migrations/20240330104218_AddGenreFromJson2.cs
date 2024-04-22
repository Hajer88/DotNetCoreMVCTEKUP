using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    public partial class AddGenreFromJson2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "name",
                value: "Thriller");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "name",
                value: "Comedy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "name",
                value: "Test2");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "name",
                value: "Test3");
        }
    }
}
