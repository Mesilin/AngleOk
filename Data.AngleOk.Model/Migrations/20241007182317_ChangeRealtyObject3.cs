using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRealtyObject3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StreetId",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealtyObject_StreetId",
                schema: "public",
                table: "RealtyObject",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyObject_Street_StreetId",
                schema: "public",
                table: "RealtyObject",
                column: "StreetId",
                principalSchema: "public",
                principalTable: "Street",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealtyObject_Street_StreetId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropIndex(
                name: "IX_RealtyObject_StreetId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "StreetId",
                schema: "public",
                table: "RealtyObject");
        }
    }
}
