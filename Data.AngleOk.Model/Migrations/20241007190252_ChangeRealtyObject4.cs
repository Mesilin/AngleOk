using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRealtyObject4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
UPDATE public.""RealtyObject""
SET ""CadastralNumber""='70:21:0200026:1', ""Apartment""=1, ""Building""=2, ""House""=3, ""HouseLetter""='Б', ""PostalCode""=634000, ""StreetId""='cf03e1c4-4efe-4e0e-bd6d-468d5a14c63f'::uuid
WHERE ""Id""='52feb9cc-3691-4640-8b6e-3a85e520f411'::uuid;
UPDATE public.""RealtyObject""
SET ""CadastralNumber""='70:21:0200026:2', ""Apartment""=1, ""House""=3, ""PostalCode""=634000, ""StreetId""='9b9f4e7f-4126-47d7-a520-e8a91bd60f0b'::uuid
WHERE ""Id""='cf4834a7-8cfb-4d5f-90ec-816a36f4abb3'::uuid;
UPDATE public.""RealtyObject""
SET ""CadastralNumber""='70:21:0200026:3', ""Apartment""=1, ""House""=3, ""PostalCode""=634000, ""StreetId""='ccc71211-edf5-4507-bfc5-514f91da9b73'::uuid
WHERE ""Id""='4ebab588-f2cd-4e59-b37b-5fe120ad673d'::uuid;
UPDATE public.""RealtyObject""
SET ""CadastralNumber""='70:21:0200026:3898', ""House""=146, ""HouseLetter"" = NULL, ""PostalCode""=634045, ""StreetId""='fd1f2152-f100-474e-a48e-29aa00396276'::uuid
WHERE ""Id""='6059582f-7adf-4d7f-9c98-46fbb48cd82a'::uuid;
");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
