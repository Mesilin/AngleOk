using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRealtyObject2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("83c21f4b-b733-4f24-ad82-ccc855ffeaa8"));

            migrationBuilder.CreateIndex(
                name: "IX_RealtyObject_CityId",
                schema: "public",
                table: "RealtyObject",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyObject_City_CityId",
                schema: "public",
                table: "RealtyObject",
                column: "CityId",
                principalSchema: "public",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealtyObject_City_CityId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropIndex(
                name: "IX_RealtyObject_CityId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "public",
                table: "RealtyObject");
        }
    }
}
