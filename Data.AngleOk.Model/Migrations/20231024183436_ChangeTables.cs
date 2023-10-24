using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TextFields",
                table: "TextFields");

            migrationBuilder.RenameTable(
                name: "TextFields",
                newName: "TextField");

            migrationBuilder.AddColumn<bool>(
                name: "IsTitleImage",
                table: "Media",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Advertisement",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextField",
                table: "TextField",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TextField",
                table: "TextField");

            migrationBuilder.DropColumn(
                name: "IsTitleImage",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Advertisement");

            migrationBuilder.RenameTable(
                name: "TextField",
                newName: "TextFields");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextFields",
                table: "TextFields",
                column: "Id");
        }
    }
}
