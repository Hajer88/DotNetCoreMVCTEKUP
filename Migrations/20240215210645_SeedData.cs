using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("movies", "Id", 3);
            migrationBuilder.InsertData("movies","name","TestFromMigration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
