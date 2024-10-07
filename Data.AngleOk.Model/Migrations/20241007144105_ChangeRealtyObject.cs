using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRealtyObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.AddColumn<int>(
                name: "Apartment",
                schema: "public",
                table: "RealtyObject",
                type: "integer",
                nullable: true,
                comment: "Квартира");

            migrationBuilder.AddColumn<int>(
                name: "Building",
                schema: "public",
                table: "RealtyObject",
                type: "integer",
                nullable: true,
                comment: "Корпус");

            migrationBuilder.AddColumn<int>(
                name: "House",
                schema: "public",
                table: "RealtyObject",
                type: "integer",
                nullable: true,
                comment: "Номер дома");

            migrationBuilder.AddColumn<string>(
                name: "HouseLetter",
                schema: "public",
                table: "RealtyObject",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true,
                comment: "Литера дома");

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                schema: "public",
                table: "RealtyObject",
                type: "integer",
                nullable: true,
                comment: "Почтовый индекс");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apartment",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "Building",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "House",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "HouseLetter",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Адрес");
        }
    }
}
