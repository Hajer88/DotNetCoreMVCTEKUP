using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.FirstMVC._2024.Migrations
{
    public partial class TestNRT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Membershiptypes_membershiptype_id",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "membershiptype_id",
                table: "Customers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Membershiptypes_membershiptype_id",
                table: "Customers",
                column: "membershiptype_id",
                principalTable: "Membershiptypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Membershiptypes_membershiptype_id",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "membershiptype_id",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Membershiptypes_membershiptype_id",
                table: "Customers",
                column: "membershiptype_id",
                principalTable: "Membershiptypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
