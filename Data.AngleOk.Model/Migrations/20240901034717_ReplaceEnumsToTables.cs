using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceEnumsToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Client_Id",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "SteadUseKind",
                schema: "public",
                table: "Stead");

            migrationBuilder.DropColumn(
                name: "RealtyObjectKind",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "DealType",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.AddColumn<Guid>(
                name: "SteadUseKindId",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false/*,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")*/);

            migrationBuilder.AddColumn<Guid>(
                name: "RealtyObjectKindId",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: false/*,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")*/);

            migrationBuilder.AddColumn<Guid>(
                name: "DealTypeId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false/*,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")*/);

            migrationBuilder.CreateTable(
                name: "ClientType",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientTypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DealType",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealTypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyObjectKind",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RealtyObjectKindName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyObjectKind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SteadUseKind",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SteadUseKindName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteadUseKind", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stead_SteadUseKindId",
                schema: "public",
                table: "Stead",
                column: "SteadUseKindId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyObject_RealtyObjectKindId",
                schema: "public",
                table: "RealtyObject",
                column: "RealtyObjectKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_ClientId",
                schema: "public",
                table: "Advertisement",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_DealTypeId",
                schema: "public",
                table: "Advertisement",
                column: "DealTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Client_ClientId",
                schema: "public",
                table: "Advertisement",
                column: "ClientId",
                principalSchema: "public",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_DealType_DealTypeId",
                schema: "public",
                table: "Advertisement",
                column: "DealTypeId",
                principalSchema: "public",
                principalTable: "DealType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyObject_RealtyObjectKind_RealtyObjectKindId",
                schema: "public",
                table: "RealtyObject",
                column: "RealtyObjectKindId",
                principalSchema: "public",
                principalTable: "RealtyObjectKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stead_SteadUseKind_SteadUseKindId",
                schema: "public",
                table: "Stead",
                column: "SteadUseKindId",
                principalSchema: "public",
                principalTable: "SteadUseKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Client_ClientId",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_DealType_DealTypeId",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyObject_RealtyObjectKind_RealtyObjectKindId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropForeignKey(
                name: "FK_Stead_SteadUseKind_SteadUseKindId",
                schema: "public",
                table: "Stead");

            migrationBuilder.DropTable(
                name: "ClientType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DealType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RealtyObjectKind",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SteadUseKind",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Stead_SteadUseKindId",
                schema: "public",
                table: "Stead");

            migrationBuilder.DropIndex(
                name: "IX_RealtyObject_RealtyObjectKindId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_ClientId",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_DealTypeId",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "SteadUseKindId",
                schema: "public",
                table: "Stead");

            migrationBuilder.DropColumn(
                name: "RealtyObjectKindId",
                schema: "public",
                table: "RealtyObject");

            migrationBuilder.DropColumn(
                name: "DealTypeId",
                schema: "public",
                table: "Advertisement");

            migrationBuilder.AddColumn<int>(
                name: "SteadUseKind",
                schema: "public",
                table: "Stead",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RealtyObjectKind",
                schema: "public",
                table: "RealtyObject",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DealType",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Client_Id",
                schema: "public",
                table: "Advertisement",
                column: "Id",
                principalSchema: "public",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
