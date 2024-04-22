using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    public partial class AddSchemaRelational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "movies");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genre_id",
                table: "movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "genres",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Membershiptypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SignUpFee = table.Column<double>(type: "REAL", nullable: false),
                    DurationInMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountRate = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membershiptypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    membershiptype_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Membershiptypes_membershiptype_id",
                        column: x => x.membershiptype_id,
                        principalTable: "Membershiptypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CustomerId",
                table: "movies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_genre_id",
                table: "movies",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_membershiptype_id",
                table: "Customers",
                column: "membershiptype_id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_Customers_CustomerId",
                table: "movies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_genre_id",
                table: "movies",
                column: "genre_id",
                principalTable: "genres",
                principalColumn: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_Customers_CustomerId",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_genre_id",
                table: "movies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Membershiptypes");

            migrationBuilder.DropIndex(
                name: "IX_movies_CustomerId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_genre_id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "genre_id",
                table: "movies");

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "genres",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId",
                table: "movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "GenreId");
        }
    }
}
