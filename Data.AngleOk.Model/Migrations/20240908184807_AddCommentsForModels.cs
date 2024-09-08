using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentsForModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RealtyObjectOwner",
                schema: "public");

            migrationBuilder.AlterTable(
                name: "SteadUseKind",
                schema: "public",
                comment: "Виды разрешенного использования земли");

            migrationBuilder.AlterTable(
                name: "Stead",
                schema: "public",
                comment: "Земельные участки");

            migrationBuilder.AlterTable(
                name: "RealtyObjectKind",
                schema: "public",
                comment: "Виды объектов невижимости");

            migrationBuilder.AlterTable(
                name: "RealtyObject",
                schema: "public",
                comment: "Объекты недвижимости");

            migrationBuilder.AlterTable(
                name: "Media",
                schema: "public",
                comment: "Фото");

            migrationBuilder.AlterTable(
                name: "Flat",
                schema: "public",
                comment: "Квартиры");

            migrationBuilder.AlterTable(
                name: "Employee",
                schema: "public",
                comment: "Сотрудники агентства");

            migrationBuilder.AlterTable(
                name: "DealType",
                schema: "public",
                comment: "Типы сделок (объявлений). аренда, продажа, покупка");

            migrationBuilder.AlterTable(
                name: "ClientType",
                schema: "public",
                comment: "Типы клиентов");

            migrationBuilder.AlterTable(
                name: "Client",
                schema: "public",
                comment: "Таблица Клиенты");

            migrationBuilder.AlterTable(
                name: "Advertisement",
                schema: "public",
                comment: "Объявления");

            migrationBuilder.AlterColumn<string>(
                name: "SteadUseKindName",
                schema: "public",
                table: "SteadUseKind",
                type: "text",
                nullable: false,
                comment: "Вид разрешенного использования земли",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "SteadUseKind",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "SteadUseKindId",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор вида разрешенного использования",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор объекта недвижимости",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                schema: "public",
                table: "Stead",
                type: "numeric",
                nullable: false,
                comment: "Площадь",
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "RealtyObjectKindName",
                schema: "public",
                table: "RealtyObjectKind",
                type: "text",
                nullable: false,
                comment: "Тип объекта невижимости",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "RealtyObjectKind",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                schema: "public",
                table: "RealtyObject",
                type: "numeric",
                nullable: true,
                comment: "Долгота",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                schema: "public",
                table: "RealtyObject",
                type: "numeric",
                nullable: true,
                comment: "Широта",
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: true,
                comment: "Описание",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CadastralNumber",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: false,
                comment: "Кадастровый номер",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: false,
                comment: "Адрес",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Media",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор объекта недвижимости",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: true,
                comment: "Путь к файлу",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTitle",
                schema: "public",
                table: "Media",
                type: "boolean",
                nullable: false,
                comment: "Признак титульного фото для объекта",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: false,
                comment: "Имя файла",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: false,
                comment: "Расширение файла",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                schema: "public",
                table: "Media",
                type: "bytea",
                nullable: true,
                comment: "Двоичные данные файла",
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Media",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор фото",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfBuild",
                schema: "public",
                table: "Flat",
                type: "integer",
                nullable: false,
                comment: "Год постройки",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalArea",
                schema: "public",
                table: "Flat",
                type: "numeric",
                nullable: false,
                comment: "Общая площадь",
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "RoomCount",
                schema: "public",
                table: "Flat",
                type: "integer",
                nullable: false,
                comment: "Количество комнат",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Flat",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор объекта недвижимости",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialName",
                schema: "public",
                table: "Flat",
                type: "text",
                nullable: false,
                comment: "Материал стен",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "LiveArea",
                schema: "public",
                table: "Flat",
                type: "numeric",
                nullable: false,
                comment: "Жилая площадь",
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                schema: "public",
                table: "Flat",
                type: "integer",
                nullable: false,
                comment: "Этаж",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "CeilingHeight",
                schema: "public",
                table: "Flat",
                type: "numeric",
                nullable: false,
                comment: "Высота потолков",
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Flat",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор квартиры",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "PublicPhone",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: true,
                comment: "Телефон раб",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                comment: "Должность",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                comment: "телефон личн",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: true,
                comment: "Отчество",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                comment: "Фамилия",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "Employee",
                type: "boolean",
                nullable: false,
                comment: "Признак действующего сотрудника",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                comment: "Имя",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: true,
                comment: "Адрес электронной почты",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Employee",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор сотрудника",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "DealTypeName",
                schema: "public",
                table: "DealType",
                type: "text",
                nullable: false,
                comment: "Тип сделки",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "DealType",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "ClientTypeName",
                schema: "public",
                table: "ClientType",
                type: "text",
                nullable: false,
                comment: "Тип клиента",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: false,
                comment: "Номер телефона",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: true,
                comment: "Отчество",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: false,
                comment: "Фамилия",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: false,
                comment: "Имя",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: true,
                comment: "Адрес электронной почты",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Client",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "TargetPrice",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                comment: "Целевая цена",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                schema: "public",
                table: "Advertisement",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "Краткое описание",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: true,
                comment: "Идентификатор объекта недвижимости",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinPrice",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                comment: "Минимальная цена",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MaxPrice",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                comment: "Максимальная цена",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор контактного лица от агентства",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "Advertisement",
                type: "boolean",
                nullable: false,
                comment: "Признак активности",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "Advertisement",
                type: "text",
                nullable: false,
                comment: "Описание",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "DealTypeId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                comment: "Тип(аренда, продажа, покупка)",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор клиента",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                comment: "Идентификатор объявления",
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "SteadUseKind",
                schema: "public",
                oldComment: "Виды разрешенного использования земли");

            migrationBuilder.AlterTable(
                name: "Stead",
                schema: "public",
                oldComment: "Земельные участки");

            migrationBuilder.AlterTable(
                name: "RealtyObjectKind",
                schema: "public",
                oldComment: "Виды объектов невижимости");

            migrationBuilder.AlterTable(
                name: "RealtyObject",
                schema: "public",
                oldComment: "Объекты недвижимости");

            migrationBuilder.AlterTable(
                name: "Media",
                schema: "public",
                oldComment: "Фото");

            migrationBuilder.AlterTable(
                name: "Flat",
                schema: "public",
                oldComment: "Квартиры");

            migrationBuilder.AlterTable(
                name: "Employee",
                schema: "public",
                oldComment: "Сотрудники агентства");

            migrationBuilder.AlterTable(
                name: "DealType",
                schema: "public",
                oldComment: "Типы сделок (объявлений). аренда, продажа, покупка");

            migrationBuilder.AlterTable(
                name: "ClientType",
                schema: "public",
                oldComment: "Типы клиентов");

            migrationBuilder.AlterTable(
                name: "Client",
                schema: "public",
                oldComment: "Таблица Клиенты");

            migrationBuilder.AlterTable(
                name: "Advertisement",
                schema: "public",
                oldComment: "Объявления");

            migrationBuilder.AlterColumn<string>(
                name: "SteadUseKindName",
                schema: "public",
                table: "SteadUseKind",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Вид разрешенного использования земли");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "SteadUseKind",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "SteadUseKindId",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор вида разрешенного использования");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор объекта недвижимости");

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                schema: "public",
                table: "Stead",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Площадь");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Stead",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<string>(
                name: "RealtyObjectKindName",
                schema: "public",
                table: "RealtyObjectKind",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Тип объекта невижимости");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "RealtyObjectKind",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                schema: "public",
                table: "RealtyObject",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true,
                oldComment: "Долгота");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                schema: "public",
                table: "RealtyObject",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true,
                oldComment: "Широта");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Описание");

            migrationBuilder.AlterColumn<string>(
                name: "CadastralNumber",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Кадастровый номер");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "public",
                table: "RealtyObject",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Адрес");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "RealtyObject",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Media",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Идентификатор объекта недвижимости");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Путь к файлу");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTitle",
                schema: "public",
                table: "Media",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Признак титульного фото для объекта");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Имя файла");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "public",
                table: "Media",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Расширение файла");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                schema: "public",
                table: "Media",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true,
                oldComment: "Двоичные данные файла");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Media",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор фото");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfBuild",
                schema: "public",
                table: "Flat",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Год постройки");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalArea",
                schema: "public",
                table: "Flat",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Общая площадь");

            migrationBuilder.AlterColumn<int>(
                name: "RoomCount",
                schema: "public",
                table: "Flat",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Количество комнат");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Flat",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор объекта недвижимости");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialName",
                schema: "public",
                table: "Flat",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Материал стен");

            migrationBuilder.AlterColumn<decimal>(
                name: "LiveArea",
                schema: "public",
                table: "Flat",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Жилая площадь");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                schema: "public",
                table: "Flat",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Этаж");

            migrationBuilder.AlterColumn<decimal>(
                name: "CeilingHeight",
                schema: "public",
                table: "Flat",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComment: "Высота потолков");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Flat",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор квартиры");

            migrationBuilder.AlterColumn<string>(
                name: "PublicPhone",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Телефон раб");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Должность");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "телефон личн");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Отчество");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Фамилия");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "Employee",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Признак действующего сотрудника");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Имя");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "public",
                table: "Employee",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Адрес электронной почты");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Employee",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор сотрудника");

            migrationBuilder.AlterColumn<string>(
                name: "DealTypeName",
                schema: "public",
                table: "DealType",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Тип сделки");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "DealType",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<string>(
                name: "ClientTypeName",
                schema: "public",
                table: "ClientType",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Тип клиента");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Номер телефона");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Отчество");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Фамилия");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Имя");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "public",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Адрес электронной почты");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Client",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор");

            migrationBuilder.AlterColumn<int>(
                name: "TargetPrice",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Целевая цена");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                schema: "public",
                table: "Advertisement",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "Краткое описание");

            migrationBuilder.AlterColumn<Guid>(
                name: "RealtyObjectId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Идентификатор объекта недвижимости");

            migrationBuilder.AlterColumn<int>(
                name: "MinPrice",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Минимальная цена");

            migrationBuilder.AlterColumn<int>(
                name: "MaxPrice",
                schema: "public",
                table: "Advertisement",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Максимальная цена");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор контактного лица от агентства");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "Advertisement",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Признак активности");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "Advertisement",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Описание");

            migrationBuilder.AlterColumn<Guid>(
                name: "DealTypeId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Тип(аренда, продажа, покупка)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор клиента");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Advertisement",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Идентификатор объявления");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyObjectOwner",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    PartPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    RealtyObjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyObjectOwner", x => x.Id);
                });
        }
    }
}
