using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Dictricts_DictrictId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Cities_CityId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CityId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_DictrictId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DictrictId",
                table: "Cities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DictrictId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CityId",
                table: "Countries",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DictrictId",
                table: "Cities",
                column: "DictrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Dictricts_DictrictId",
                table: "Cities",
                column: "DictrictId",
                principalTable: "Dictricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Cities_CityId",
                table: "Countries",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
