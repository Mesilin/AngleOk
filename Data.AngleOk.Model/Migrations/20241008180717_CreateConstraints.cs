using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class CreateConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Region_Name_CountryId",
                schema: "public",
                table: "Region",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Alpha2",
                schema: "public",
                table: "Country",
                column: "Alpha2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Alpha3",
                schema: "public",
                table: "Country",
                column: "Alpha3",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_EnglishName",
                schema: "public",
                table: "Country",
                column: "EnglishName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso",
                schema: "public",
                table: "Country",
                column: "Iso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                schema: "public",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_Name_RegionId",
                schema: "public",
                table: "City",
                columns: new[] { "Name", "RegionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Region_Name_CountryId",
                schema: "public",
                table: "Region");

            migrationBuilder.DropIndex(
                name: "IX_Country_Alpha2",
                schema: "public",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_Alpha3",
                schema: "public",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_EnglishName",
                schema: "public",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_Iso",
                schema: "public",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_Name",
                schema: "public",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_City_Name_RegionId",
                schema: "public",
                table: "City");
        }
    }
}
