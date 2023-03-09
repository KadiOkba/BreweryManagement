using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class linkbeerandbrewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrewerId",
                table: "Beers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrewerId",
                table: "Beers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "Id");
        }
    }
}
