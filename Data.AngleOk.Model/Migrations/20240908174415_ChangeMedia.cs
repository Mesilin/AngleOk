using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Advertisement_AdvertisementId",
                schema: "public",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyObject_Media_TitleImageId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropIndex(
                name: "IX_RealtyObject_TitleImageId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropIndex(
                name: "IX_Media_AdvertisementId",
                schema: "public",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "TitleImageId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                schema: "public",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "public",
                table: "Media");

            migrationBuilder.AddColumn<bool>(
                name: "IsTitle",
                schema: "public",
                table: "Media",
                type: "boolean",
                nullable: false,
                defaultValue: false);
            migrationBuilder.Sql(@"UPDATE public.""Media"" SET ""IsTitle""=true;");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTitle",
                schema: "public",
                table: "Media");

            migrationBuilder.AddColumn<Guid>(
                name: "TitleImageId",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdvertisementId",
                schema: "public",
                table: "Media",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealtyObject_TitleImageId",
                schema: "public",
                table: "RealtyObject",
                column: "TitleImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_AdvertisementId",
                schema: "public",
                table: "Media",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Advertisement_AdvertisementId",
                schema: "public",
                table: "Media",
                column: "AdvertisementId",
                principalSchema: "public",
                principalTable: "Advertisement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyObject_Media_TitleImageId",
                schema: "public",
                table: "RealtyObject",
                column: "TitleImageId",
                principalSchema: "public",
                principalTable: "Media",
                principalColumn: "Id");
        }
    }
}
