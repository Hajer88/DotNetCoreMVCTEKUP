using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData("movies", "Name", "TestFromMigration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
