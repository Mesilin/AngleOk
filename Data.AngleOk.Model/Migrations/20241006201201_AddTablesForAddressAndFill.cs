using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForAddressAndFill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование"),
                    FullName = table.Column<string>(type: "text", nullable: true, comment: "Полное наименование"),
                    EnglishName = table.Column<string>(type: "text", nullable: false, comment: "Наименование на английском языке"),
                    Alpha2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false, comment: "Alpha-2 код по ISO 3166-1"),
                    Alpha3 = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, comment: "Alpha-3 код по ISO 3166-1"),
                    Iso = table.Column<int>(type: "integer", nullable: false, comment: "Iso код по ISO 3166-1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                },
                comment: "Страны");

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор страны"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование"),
                    EnglishName = table.Column<string>(type: "text", nullable: false, comment: "Наименование на английском языке")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "public",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Субъекты");

            migrationBuilder.CreateTable(
                name: "City",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор субъекта"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование"),
                    Population = table.Column<int>(type: "integer", nullable: false, comment: "Население")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Region_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "public",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Города");

            migrationBuilder.CreateTable(
                name: "Street",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Наименование"),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор города")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Street_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Улицы");

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionId",
                schema: "public",
                table: "City",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                schema: "public",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_CityId",
                schema: "public",
                table: "Street",
                column: "CityId");

			migrationBuilder.Sql(@"
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c3c5139a-9038-4fd6-9f09-048f364ee4a7'::uuid, 'Абхазия', 'Республика Абхазия', 'Abkhazia', 'AB', 'ABH', 895);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c0bca412-5516-4e43-844e-122ab23d0e9e'::uuid, 'Австралия', '', 'Australia', 'AU', 'AUS', 36);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2a37b8d8-441f-4a0b-9361-3de2496ffd01'::uuid, 'Австрия', 'Австрийская Республика', 'Austria', 'AT', 'AUT', 40);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0d8b14a8-8f72-4620-9954-b28a38243ea7'::uuid, 'Азербайджан', 'Республика Азербайджан', 'Azerbaijan', 'AZ', 'AZE', 31);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('47dd59f6-4830-4ee4-9a1f-38dbb4f69a97'::uuid, 'Албания', 'Республика Албания', 'Albania', 'AL', 'ALB', 8);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('579fc761-3e30-4080-ab5d-8f8b52d03152'::uuid, 'Алжир', 'Алжирская Народная Демократическая Республика', 'Algeria', 'DZ', 'DZA', 12);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f4f932a6-68b5-4d82-bf96-d56c74aef215'::uuid, 'Американское Самоа', '', 'American Samoa', 'AS', 'ASM', 16);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ea0d58c1-a117-4520-a404-177e20dd9777'::uuid, 'Ангилья', '', 'Anguilla', 'AI', 'AIA', 660);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b82b5dca-2a50-4fd2-97d7-b906984c5b47'::uuid, 'Ангола', 'Республика Ангола', 'Angola', 'AO', 'AGO', 24);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('82712f2d-9afd-42d8-9381-95e9fa4d4080'::uuid, 'Андорра', 'Княжество Андорра', 'Andorra', 'AD', 'AND', 20);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('57848a4a-be55-4de1-a2ca-66570465c20a'::uuid, 'Антарктида', '', 'Antarctica', 'AQ', 'ATA', 10);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1368c0f4-bf7c-4045-b390-0528c391a547'::uuid, 'Антигуа и Барбуда', '', 'Antigua and Barbuda', 'AG', 'ATG', 28);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a9afbc8f-dad4-484a-a4c2-5cbbb5d8b794'::uuid, 'Аргентина', 'Аргентинская Республика', 'Argentina', 'AR', 'ARG', 32);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ee89f356-81d6-42e3-a476-083a5767386a'::uuid, 'Армения', 'Республика Армения', 'Armenia', 'AM', 'ARM', 51);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1603bc2d-8c9c-4864-a4bf-b5b720311832'::uuid, 'Аруба', '', 'Aruba', 'AW', 'ABW', 533);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('d2f65a75-7199-4e9a-a193-2043cb1c3be1'::uuid, 'Афганистан', 'Переходное Исламское Государство Афганистан', 'Afghanistan', 'AF', 'AFG', 4);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('eb59fa30-70cb-49f5-917f-53258a94ceee'::uuid, 'Багамы', 'Содружество Багамы', 'Bahamas', 'BS', 'BHS', 44);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b7ae4c0b-fa4d-41f8-8111-9c48fc00deb2'::uuid, 'Бангладеш', 'Народная Республика Бангладеш', 'Bangladesh', 'BD', 'BGD', 50);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4e5fa944-e6f1-49c0-8df9-bb0d2e964e0a'::uuid, 'Барбадос', '', 'Barbados', 'BB', 'BRB', 52);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ba75f33a-3c3a-4fd1-9db5-a766d3cfca94'::uuid, 'Бахрейн', 'Королевство Бахрейн', 'Bahrain', 'BH', 'BHR', 48);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('31c38edf-a43e-4282-8a0c-1b78de57fa2d'::uuid, 'Беларусь', 'Республика Беларусь', 'Belarus', 'BY', 'BLR', 112);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('fd6c4e6e-2ff9-4d1c-9ce3-516b6da87c93'::uuid, 'Белиз', '', 'Belize', 'BZ', 'BLZ', 84);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f5e80b4e-15a7-448e-b02a-89eacfbc8fe3'::uuid, 'Бельгия', 'Королевство Бельгии', 'Belgium', 'BE', 'BEL', 56);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('15a608ad-a0d1-4fae-851f-c215c8ddba4a'::uuid, 'Бенин', 'Республика Бенин', 'Benin', 'BJ', 'BEN', 204);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('878e5051-2ddf-48be-9b32-7c7b10bbc8bb'::uuid, 'Бермуды', '', 'Bermuda', 'BM', 'BMU', 60);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1404009a-d8a2-4ad5-88e7-bd0398591ad1'::uuid, 'Болгария', 'Республика Болгария', 'Bulgaria', 'BG', 'BGR', 100);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('fbee80b8-e8c9-4f97-b721-fc6ee3ab98f6'::uuid, 'Боливия, Многонациональное Государство', 'Многонациональное Государство Боливия', 'Bolivia, plurinational state of', 'BO', 'BOL', 68);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ae1f797a-e183-45f7-9b18-149361e74fb6'::uuid, 'Бонайре, Саба и Синт-Эстатиус', '', 'Bonaire, Sint Eustatius and Saba', 'BQ', 'BES', 535);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c6761da3-237f-4056-94b0-011d4d2b6aed'::uuid, 'Босния и Герцеговина', '', 'Bosnia and Herzegovina', 'BA', 'BIH', 70);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('548280b5-ecad-4f53-8837-5a841abf02bb'::uuid, 'Ботсвана', 'Республика Ботсвана', 'Botswana', 'BW', 'BWA', 72);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('8bd22d53-46f4-4648-9486-ae0c14c94005'::uuid, 'Бразилия', 'Федеративная Республика Бразилия', 'Brazil', 'BR', 'BRA', 76);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f38fb59b-ac54-4387-be5d-f9ce3cec50af'::uuid, 'Британская территория в Индийском океане', '', 'British Indian Ocean Territory', 'IO', 'IOT', 86);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('5ac50580-2996-46ef-9b85-8863c718196e'::uuid, 'Бруней-Даруссалам', '', 'Brunei Darussalam', 'BN', 'BRN', 96);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('00eb6e4b-d325-485b-bc0f-833a28d01551'::uuid, 'Буркина-Фасо', '', 'Burkina Faso', 'BF', 'BFA', 854);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('5590fa7d-fd6f-4ba4-9615-bc8becc79fd1'::uuid, 'Бурунди', 'Республика Бурунди', 'Burundi', 'BI', 'BDI', 108);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('8ba82d43-ad34-4b74-a0ad-850764b9abcf'::uuid, 'Бутан', 'Королевство Бутан', 'Bhutan', 'BT', 'BTN', 64);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('91ab6ba7-9cb3-4c69-baa3-d90d0e1f4dfc'::uuid, 'Вануату', 'Республика Вануату', 'Vanuatu', 'VU', 'VUT', 548);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('36a921af-f65f-4ffa-92ea-a0f5b145bbec'::uuid, 'Венгрия', 'Венгерская Республика', 'Hungary', 'HU', 'HUN', 348);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0483af59-fb08-4c32-8b23-dab574f75a93'::uuid, 'Венесуэла Боливарианская Республика', 'Боливарийская Республика Венесуэла', 'Venezuela', 'VE', 'VEN', 862);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b7bd7c45-b6f7-4a77-a7f1-419dc63213f3'::uuid, 'Виргинские острова, Британские', 'Британские Виргинские острова', 'Virgin Islands, British', 'VG', 'VGB', 92);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0918c997-747c-499a-aa40-8f8adda15937'::uuid, 'Виргинские острова, США', 'Виргинские острова Соединенных Штатов', 'Virgin Islands, U.S.', 'VI', 'VIR', 850);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e9aedaa6-0982-4d88-8c27-349daa313c65'::uuid, 'Вьетнам', 'Социалистическая Республика Вьетнам', 'Vietnam', 'VN', 'VNM', 704);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('85d8e869-11c4-45b8-8373-bcd87633e8a0'::uuid, 'Габон', 'Габонская Республика', 'Gabon', 'GA', 'GAB', 266);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('38239283-9390-4daf-ae11-c120020a0036'::uuid, 'Гаити', 'Республика Гаити', 'Haiti', 'HT', 'HTI', 332);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('af555068-40b3-4a4b-a9e5-93e4d03421d9'::uuid, 'Гайана', 'Республика Гайана', 'Guyana', 'GY', 'GUY', 328);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('66e294db-90a1-4a8e-b38e-6deb55a98fc9'::uuid, 'Гамбия', 'Республика Гамбия', 'Gambia', 'GM', 'GMB', 270);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b6a9243a-9236-4771-af24-e47245beaadf'::uuid, 'Гана', 'Республика Гана', 'Ghana', 'GH', 'GHA', 288);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('122a225d-d13f-4adb-a9c4-9f2b794423e9'::uuid, 'Гваделупа', '', 'Guadeloupe', 'GP', 'GLP', 312);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('3a17c4e7-ba42-4fdc-83fd-60cf80de7883'::uuid, 'Гватемала', 'Республика Гватемала', 'Guatemala', 'GT', 'GTM', 320);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ec929aa4-f8f2-4c85-bf55-830258418b9c'::uuid, 'Гвинея', 'Гвинейская Республика', 'Guinea', 'GN', 'GIN', 324);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('cf3f8dcb-eff9-4db0-b406-064e82ea1613'::uuid, 'Гвинея-Бисау', 'Республика Гвинея-Бисау', 'Guinea-Bissau', 'GW', 'GNB', 624);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('285aa993-67ae-4fc9-91cd-34fa2e79c4f3'::uuid, 'Германия', 'Федеративная Республика Германия', 'Germany', 'DE', 'DEU', 276);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e3007c1a-db7b-40a4-8b1e-d6aa9c7631db'::uuid, 'Гернси', '', 'Guernsey', 'GG', 'GGY', 831);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1156ac55-3b6f-4edd-aa31-ffdb2f161fd2'::uuid, 'Гибралтар', '', 'Gibraltar', 'GI', 'GIB', 292);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a258473f-76b5-4ea6-a749-1b1ebe49e87c'::uuid, 'Гондурас', 'Республика Гондурас', 'Honduras', 'HN', 'HND', 340);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('725357c2-a441-45d6-94d6-4f02b13724d6'::uuid, 'Гонконг', 'Специальный  административный  регион Китая Гонконг', 'Hong Kong', 'HK', 'HKG', 344);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2d603393-7830-4c11-bb82-e18ccb5cc6ac'::uuid, 'Гренада', '', 'Grenada', 'GD', 'GRD', 308);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('3f642a97-14f3-4f96-91ed-adee12a188e4'::uuid, 'Гренландия', '', 'Greenland', 'GL', 'GRL', 304);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f12ad8fc-fefd-468d-b8be-7b2fe6c76baf'::uuid, 'Греция', 'Греческая Республика', 'Greece', 'GR', 'GRC', 300);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a6d4eaf8-512a-4268-b7b1-15aec43fad6d'::uuid, 'Грузия', '', 'Georgia', 'GE', 'GEO', 268);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e0c013b4-0be9-4e8d-8796-8020854d722f'::uuid, 'Гуам', '', 'Guam', 'GU', 'GUM', 316);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('36f79733-9f99-4d91-a6ac-f9e1566046cf'::uuid, 'Дания', 'Королевство Дания', 'Denmark', 'DK', 'DNK', 208);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b695cf75-36fa-43e5-a7bd-914ae73842c3'::uuid, 'Джерси', '', 'Jersey', 'JE', 'JEY', 832);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('499d8f17-c154-4adf-9855-2cd851c32edc'::uuid, 'Джибути', 'Республика Джибути', 'Djibouti', 'DJ', 'DJI', 262);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('3fcda8e1-2cdc-4a78-90c7-737e912f609e'::uuid, 'Доминика', 'Содружество Доминики', 'Dominica', 'DM', 'DMA', 212);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ec386010-ee74-4fcb-ac14-2814abe0ca80'::uuid, 'Доминиканская Республика', '', 'Dominican Republic', 'DO', 'DOM', 214);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b11d4fe3-12f3-43bb-8fd3-6f4f97a1a05c'::uuid, 'Египет', 'Арабская Республика Египет', 'Egypt', 'EG', 'EGY', 818);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e9b46542-91ed-46aa-af0f-6b9c84de1c1e'::uuid, 'Замбия', 'Республика Замбия', 'Zambia', 'ZM', 'ZMB', 894);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1cb66906-218c-4e8e-852e-cd40c97dab02'::uuid, 'Западная Сахара', '', 'Western Sahara', 'EH', 'ESH', 732);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0a4b9e95-e13c-4e4a-8df9-440bd58d59ea'::uuid, 'Зимбабве', 'Республика Зимбабве', 'Zimbabwe', 'ZW', 'ZWE', 716);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c5131dd2-adbb-4346-8fe5-f9961c739d7a'::uuid, 'Израиль', 'Государство Израиль', 'Israel', 'IL', 'ISR', 376);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('70f34032-7c84-491a-ac7b-b3b62d38351b'::uuid, 'Индия', 'Республика Индия', 'India', 'IN', 'IND', 356);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('01f56b69-15ba-4d18-9d49-ca32658a6f39'::uuid, 'Индонезия', 'Республика Индонезия', 'Indonesia', 'ID', 'IDN', 360);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e4cb3824-7226-4250-b894-f294a2f3f834'::uuid, 'Иордания', 'Иорданское Хашимитское Королевство', 'Jordan', 'JO', 'JOR', 400);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('edd7eb7f-9fa5-47e8-93d0-01f25d834b64'::uuid, 'Ирак', 'Республика Ирак', 'Iraq', 'IQ', 'IRQ', 368);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0afda9e8-d937-47b3-8dd9-08005e06ad00'::uuid, 'Иран, Исламская Республика', 'Исламская Республика Иран', 'Iran, Islamic Republic of', 'IR', 'IRN', 364);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('74555f9f-e518-43e0-bbc6-3522880ebb55'::uuid, 'Ирландия', '', 'Ireland', 'IE', 'IRL', 372);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('7614f990-5ed3-4c17-996b-a561732fca70'::uuid, 'Исландия', 'Республика Исландия', 'Iceland', 'IS', 'ISL', 352);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('fc9a06ca-de10-497e-9288-5833cccfa821'::uuid, 'Испания', 'Королевство Испания', 'Spain', 'ES', 'ESP', 724);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a528c6ba-5ee7-4fea-be5e-e71104fc2388'::uuid, 'Италия', 'Итальянская Республика', 'Italy', 'IT', 'ITA', 380);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('94957bcb-8178-4a48-90c6-19c29e578f1d'::uuid, 'Йемен', 'Йеменская Республика', 'Yemen', 'YE', 'YEM', 887);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('78ccd9c5-f2a5-49ba-9c51-4fe08ae4abcc'::uuid, 'Кабо-Верде', 'Республика Кабо-Верде', 'Cape Verde', 'CV', 'CPV', 132);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('989ac947-be81-480d-bc46-929b1e9bfee0'::uuid, 'Казахстан', 'Республика Казахстан', 'Kazakhstan', 'KZ', 'KAZ', 398);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c3bb5d3e-827d-425e-a019-de372fb00a4c'::uuid, 'Камбоджа', 'Королевство Камбоджа', 'Cambodia', 'KH', 'KHM', 116);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1d9cbb9c-ebc4-4243-872d-f9611732daac'::uuid, 'Камерун', 'Республика Камерун', 'Cameroon', 'CM', 'CMR', 120);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2febcc16-d028-4730-95e9-fa5a33ed11e9'::uuid, 'Канада', '', 'Canada', 'CA', 'CAN', 124);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2b17227b-223b-4214-9a24-a40b3923cae2'::uuid, 'Катар', 'Государство Катар', 'Qatar', 'QA', 'QAT', 634);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a7b47428-9e4f-4502-93e9-4bde79bec084'::uuid, 'Кения', 'Республика Кения', 'Kenya', 'KE', 'KEN', 404);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('cd4aa434-3700-4e38-9946-8331bb0b330b'::uuid, 'Кипр', 'Республика Кипр', 'Cyprus', 'CY', 'CYP', 196);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('58cb9e5e-840a-4029-beec-48716a5c739e'::uuid, 'Киргизия', 'Киргизская Республика', 'Kyrgyzstan', 'KG', 'KGZ', 417);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0a5ea1a7-1428-4782-9a7e-a7433bf214b1'::uuid, 'Кирибати', 'Республика Кирибати', 'Kiribati', 'KI', 'KIR', 296);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c0366ac3-b5ba-41f3-9cf2-9239d88c032e'::uuid, 'Китай', 'Китайская Народная Республика', 'China', 'CN', 'CHN', 156);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('42d063ab-0a43-44b7-b997-898393e613a3'::uuid, 'Кокосовые (Килинг) острова', '', 'Cocos (Keeling) Islands', 'CC', 'CCK', 166);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f5e7c076-5c80-499e-baf4-20eaa14da822'::uuid, 'Колумбия', 'Республика Колумбия', 'Colombia', 'CO', 'COL', 170);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('82edcbd0-d6e4-4143-b503-339c414d7440'::uuid, 'Коморы', 'Союз Коморы', 'Comoros', 'KM', 'COM', 174);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('23055ba5-8935-40fe-bc63-9a039c86d852'::uuid, 'Конго', 'Республика Конго', 'Congo', 'CG', 'COG', 178);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('585ee651-1236-411a-a0be-aa0cc0946b98'::uuid, 'Конго, Демократическая Республика', 'Демократическая Республика Конго', 'Congo, Democratic Republic of the', 'CD', 'COD', 180);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('36541e91-a1c7-4450-ab0a-540e0bcdfb90'::uuid, 'Корея, Народно-Демократическая Республика', 'Корейская Народно-Демократическая Республика', 'Korea, Democratic People''s republic of', 'KP', 'PRK', 408);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('9b0158ce-a7d9-4a21-9be3-a06c9fe095b1'::uuid, 'Корея, Республика', 'Республика Корея', 'Korea, Republic of', 'KR', 'KOR', 410);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a8bfc8df-8a83-4ec4-894f-90c422b1737f'::uuid, 'Коста-Рика', 'Республика Коста-Рика', 'Costa Rica', 'CR', 'CRI', 188);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('9b4f27c5-fb9a-4c19-bda3-a034c25009c6'::uuid, 'Кот д''Ивуар', 'Республика Кот д''Ивуар', 'Cote d''Ivoire', 'CI', 'CIV', 384);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('72faa008-167a-431f-9387-beb671dab3bc'::uuid, 'Куба', 'Республика Куба', 'Cuba', 'CU', 'CUB', 192);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('456c2c99-f998-431a-987a-b9f28a705a3c'::uuid, 'Кувейт', 'Государство Кувейт', 'Kuwait', 'KW', 'KWT', 414);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('6853e1fb-7ead-4f17-b0f3-fea5e093a70b'::uuid, 'Кюрасао', '', 'Curaçao', 'CW', 'CUW', 531);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('398b53d6-d179-4221-81b8-00564e8f9875'::uuid, 'Лаос', 'Лаосская Народно-Демократическая Республика', 'Lao People''s Democratic Republic', 'LA', 'LAO', 418);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('7addd952-bb54-4b95-9b9b-b3b45a8b650e'::uuid, 'Латвия', 'Латвийская Республика', 'Latvia', 'LV', 'LVA', 428);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0623d8a7-d48a-4492-95ef-fe24913311b5'::uuid, 'Лесото', 'Королевство Лесото', 'Lesotho', 'LS', 'LSO', 426);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('308816fa-0c1d-49a6-b466-38fb61cfccaa'::uuid, 'Ливан', 'Ливанская Республика', 'Lebanon', 'LB', 'LBN', 422);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4b4aae1f-0475-4751-a30e-fee38b241c10'::uuid, 'Ливийская Арабская Джамахирия', 'Социалистическая Народная Ливийская Арабская Джамахирия', 'Libyan Arab Jamahiriya', 'LY', 'LBY', 434);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f4abf5dc-2d14-4bfe-b14a-625dcd8fdc14'::uuid, 'Либерия', 'Республика Либерия', 'Liberia', 'LR', 'LBR', 430);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('372fcbde-f647-460b-a62e-5da7424b8172'::uuid, 'Лихтенштейн', 'Княжество Лихтенштейн', 'Liechtenstein', 'LI', 'LIE', 438);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('5606fe85-f1bd-41ac-abb7-5766acda7b7b'::uuid, 'Литва', 'Литовская Республика', 'Lithuania', 'LT', 'LTU', 440);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('599446f9-fb1c-4387-ab9a-f6bf60198086'::uuid, 'Люксембург', 'Великое Герцогство Люксембург', 'Luxembourg', 'LU', 'LUX', 442);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('8a8a0584-b473-41f7-b923-dc23db8108d7'::uuid, 'Маврикий', 'Республика Маврикий', 'Mauritius', 'MU', 'MUS', 480);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('355bcf2e-0f00-4c38-8d1d-7729b44c26d2'::uuid, 'Мавритания', 'Исламская Республика Мавритания', 'Mauritania', 'MR', 'MRT', 478);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('17b42464-a1f3-4057-941e-c1f7c0b3ad9e'::uuid, 'Мадагаскар', 'Республика Мадагаскар', 'Madagascar', 'MG', 'MDG', 450);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('754bf80d-5482-4c86-be3a-0da0a455041d'::uuid, 'Майотта', '', 'Mayotte', 'YT', 'MYT', 175);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f14baa4e-1962-48ee-8b7c-afb8f15b325d'::uuid, 'Макао', 'Специальный административный регион Китая Макао', 'Macao', 'MO', 'MAC', 446);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ea3282fc-445e-4620-991c-2a618651bc84'::uuid, 'Малави', 'Республика Малави', 'Malawi', 'MW', 'MWI', 454);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('faeb9057-c222-4c61-b9a1-2b3f68a7f1c7'::uuid, 'Малайзия', '', 'Malaysia', 'MY', 'MYS', 458);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('589cdc3d-9ba2-4bfc-a44d-66b1538284b7'::uuid, 'Мали', 'Республика Мали', 'Mali', 'ML', 'MLI', 466);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('592ba924-b171-457b-adc0-e83251465cf4'::uuid, 'Малые Тихоокеанские отдаленные острова Соединенных Штатов', '', 'United States Minor Outlying Islands', 'UM', 'UMI', 581);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ec696ba1-1358-4792-bff1-170657e8505c'::uuid, 'Мальдивы', 'Мальдивская Республика', 'Maldives', 'MV', 'MDV', 462);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('3cdee18b-47df-42b2-96d1-5b045b340974'::uuid, 'Мальта', 'Республика Мальта', 'Malta', 'MT', 'MLT', 470);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('dfe026bb-3c90-4b2a-a949-b4fc5c73f0ac'::uuid, 'Марокко', 'Королевство Марокко', 'Morocco', 'MA', 'MAR', 504);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('53f29ace-4582-45ee-b25b-c18a3d1e8912'::uuid, 'Мартиника', '', 'Martinique', 'MQ', 'MTQ', 474);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b17fac7b-df28-49f8-80de-491607b7995f'::uuid, 'Маршалловы острова', 'Республика Маршалловы острова', 'Marshall Islands', 'MH', 'MHL', 584);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b7fd581e-9145-4184-8155-de5c75cd1063'::uuid, 'Мексика', 'Мексиканские Соединенные Штаты', 'Mexico', 'MX', 'MEX', 484);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('58f3fbe1-6583-49cd-8db5-f88fc063dbc8'::uuid, 'Микронезия, Федеративные Штаты', 'Федеративные штаты Микронезии', 'Micronesia, Federated States of', 'FM', 'FSM', 583);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0e8b8c31-0ed4-4692-9a37-017dde7ad358'::uuid, 'Мозамбик', 'Республика Мозамбик', 'Mozambique', 'MZ', 'MOZ', 508);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('659a94b3-6a1c-4b3f-8714-ae511ea524d1'::uuid, 'Молдова, Республика', 'Республика Молдова', 'Moldova', 'MD', 'MDA', 498);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f11b8c72-bcc7-4ad6-802f-b960cae6b04d'::uuid, 'Монако', 'Княжество Монако', 'Monaco', 'MC', 'MCO', 492);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('abc20b95-f3f5-4906-ab60-4ca4877b0fcc'::uuid, 'Монголия', '', 'Mongolia', 'MN', 'MNG', 496);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b6ca5fea-b985-4b75-ab56-97ebc8180e23'::uuid, 'Монтсеррат', '', 'Montserrat', 'MS', 'MSR', 500);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('848257a0-0493-4b6d-aa34-f495d78a1293'::uuid, 'Мьянма', 'Союз Мьянма', 'Burma', 'MM', 'MMR', 104);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('ed4d0f1c-c487-4cc2-899f-9e6457d28fce'::uuid, 'Намибия', 'Республика Намибия', 'Namibia', 'NA', 'NAM', 516);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c497e8a3-4b53-4bd6-b007-56d74692bb43'::uuid, 'Науру', 'Республика Науру', 'Nauru', 'NR', 'NRU', 520);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('766492a6-1847-4d43-b884-785eb63eb920'::uuid, 'Непал', 'Королевство Непал', 'Nepal', 'NP', 'NPL', 524);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('824b5ae1-1eef-48f3-8367-667928f593bf'::uuid, 'Нигер', 'Республика Нигер', 'Niger', 'NE', 'NER', 562);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('68a3300d-f4c1-4d97-b988-ab1311c6bdc2'::uuid, 'Нигерия', 'Федеративная Республика Нигерия', 'Nigeria', 'NG', 'NGA', 566);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('8b4ebc1f-3e96-4b7d-973c-03e1c6293919'::uuid, 'Нидерланды', 'Королевство Нидерландов', 'Netherlands', 'NL', 'NLD', 528);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('6296a70e-fdbe-41d8-9286-c3e9b7f2392c'::uuid, 'Никарагуа', 'Республика Никарагуа', 'Nicaragua', 'NI', 'NIC', 558);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1d44cc36-2be4-4f8f-ab48-c617310c95b4'::uuid, 'Ниуэ', 'Республика Ниуэ', 'Niue', 'NU', 'NIU', 570);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4b3497e7-1922-4966-98ae-f16d061fdd31'::uuid, 'Новая Зеландия', '', 'New Zealand', 'NZ', 'NZL', 554);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('cb0b297c-0d61-4059-be28-e83586108e40'::uuid, 'Новая Каледония', '', 'New Caledonia', 'NC', 'NCL', 540);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('b41ee87e-98e7-4c09-8e7a-dfff2b65b7fc'::uuid, 'Норвегия', 'Королевство Норвегия', 'Norway', 'NO', 'NOR', 578);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4c4f3686-e8f5-4de1-b6b4-e43bde3ecd01'::uuid, 'Объединенные Арабские Эмираты', '', 'United Arab Emirates', 'AE', 'ARE', 784);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4438f9ca-9118-4911-afa8-79471357399c'::uuid, 'Оман', 'Султанат Оман', 'Oman', 'OM', 'OMN', 512);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4a5ffa7f-a660-4ec8-80e7-c50fe3638cca'::uuid, 'Остров Буве', '', 'Bouvet Island', 'BV', 'BVT', 74);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('43549c84-8da1-48b4-9dd6-7e6ac60c9a6c'::uuid, 'Остров Мэн', '', 'Isle of Man', 'IM', 'IMN', 833);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e54bb88c-345d-477d-8a20-b0055eb98739'::uuid, 'Остров Норфолк', '', 'Norfolk Island', 'NF', 'NFK', 574);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('1ca71606-d6b4-40b6-b9f7-419174312acf'::uuid, 'Остров Рождества', '', 'Christmas Island', 'CX', 'CXR', 162);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('bb19849b-abc5-4029-87cb-ddd492c4e2e1'::uuid, 'Остров Херд и острова Макдональд', '', 'Heard Island and McDonald Islands', 'HM', 'HMD', 334);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('aff3cfd1-49d0-428f-bba4-25130982c057'::uuid, 'Острова Кайман', '', 'Cayman Islands', 'KY', 'CYM', 136);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c0ab9103-fe67-43bf-9578-e6f45487bfd8'::uuid, 'Острова Кука', '', 'Cook Islands', 'CK', 'COK', 184);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('6f39a7c5-1a56-4111-9f7c-896fb1f5aaa6'::uuid, 'Острова Теркс и Кайкос', '', 'Turks and Caicos Islands', 'TC', 'TCA', 796);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('42ac0019-ea07-41c1-a58f-b83dffd2476a'::uuid, 'Пакистан', 'Исламская Республика Пакистан', 'Pakistan', 'PK', 'PAK', 586);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('9e24a3f1-6afa-4548-a8be-7711fe583dc0'::uuid, 'Палау', 'Республика Палау', 'Palau', 'PW', 'PLW', 585);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0de21334-2480-44ac-a4b0-5d55fb90571d'::uuid, 'Палестинская территория, оккупированная', 'Оккупированная Палестинская территория', 'Palestinian Territory, Occupied', 'PS', 'PSE', 275);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('88f5756a-2b54-48bd-8be3-62feed1a9ba3'::uuid, 'Панама', 'Республика Панама', 'Panama', 'PA', 'PAN', 591);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f19e984d-eca8-4a21-8cdf-cd1db043a468'::uuid, 'Папский Престол (Государство &mdash; город Ватикан)', '', 'Holy See (Vatican City State)', 'VA', 'VAT', 336);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('61217c5e-42a9-40ec-937a-aae36384be55'::uuid, 'Папуа-Новая Гвинея', '', 'Papua New Guinea', 'PG', 'PNG', 598);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('cc2e349b-e587-4718-ad68-7489213e42f9'::uuid, 'Парагвай', 'Республика Парагвай', 'Paraguay', 'PY', 'PRY', 600);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('bd2074bb-f32f-4441-a2db-c0009fe4a7d0'::uuid, 'Перу', 'Республика Перу', 'Peru', 'PE', 'PER', 604);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('8ca2cb4a-9dcb-4977-8b58-7fbf8ccc84b8'::uuid, 'Питкерн', '', 'Pitcairn', 'PN', 'PCN', 612);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e1a66dbf-49d4-4390-964c-8fd7024c0d82'::uuid, 'Польша', 'Республика Польша', 'Poland', 'PL', 'POL', 616);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('849249a8-3467-449b-bd9e-1d575975b762'::uuid, 'Португалия', 'Португальская Республика', 'Portugal', 'PT', 'PRT', 620);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('5b9745c1-874a-4e78-8150-adccfca9f8a2'::uuid, 'Пуэрто-Рико', '', 'Puerto Rico', 'PR', 'PRI', 630);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('a87cef28-abf7-46d8-a96c-1afd3202993f'::uuid, 'Республика Македония', '', 'Macedonia, The Former Yugoslav Republic Of', 'MK', 'MKD', 807);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('07911215-1192-4a8c-a47f-6ecbb49efe5e'::uuid, 'Реюньон', '', 'Reunion', 'RE', 'REU', 638);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Россия', 'Российская Федерация', 'Russian Federation', 'RU', 'RUS', 643);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('6dd97a1e-f6ea-46c9-b2ca-0809305b846c'::uuid, 'Руанда', 'Руандийская Республика', 'Rwanda', 'RW', 'RWA', 646);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f6ebe960-2521-4a94-999a-48b697d0fe42'::uuid, 'Румыния', '', 'Romania', 'RO', 'ROU', 642);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('65f38542-6dba-472b-9985-5f89528caed4'::uuid, 'Самоа', 'Независимое Государство Самоа', 'Samoa', 'WS', 'WSM', 882);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2577bf83-9d70-4d58-8e37-cb79bffec716'::uuid, 'Сан-Марино', 'Республика Сан-Марино', 'San Marino', 'SM', 'SMR', 674);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('0e5635df-5223-47f1-8e80-071c6d9b4052'::uuid, 'Сан-Томе и Принсипи', 'Демократическая Республика Сан-Томе и Принсипи', 'Sao Tome and Principe', 'ST', 'STP', 678);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2e1603ad-40f3-4696-9d5f-495ffd6396b0'::uuid, 'Саудовская Аравия', 'Королевство Саудовская Аравия', 'Saudi Arabia', 'SA', 'SAU', 682);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('bc33df50-0e94-406c-8cca-f94ca760b788'::uuid, 'Святая Елена, Остров вознесения, Тристан-да-Кунья', '', 'Saint Helena, Ascension And Tristan Da Cunha', 'SH', 'SHN', 654);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('32a960e6-5ff7-4a06-baa6-355f2343693b'::uuid, 'Северные Марианские острова', 'Содружество Северных Марианских островов', 'Northern Mariana Islands', 'MP', 'MNP', 580);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4574a5af-9c9e-4acf-ad82-54238966f4a0'::uuid, 'Сен-Бартельми', '', 'Saint Barthélemy', 'BL', 'BLM', 652);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('4055dffe-adb9-4a89-b33d-b6051c6d6469'::uuid, 'Сен-Мартен', '', 'Saint Martin (French Part)', 'MF', 'MAF', 663);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2da0745b-1c0a-46ff-89b4-78e032429b34'::uuid, 'Сенегал', 'Республика Сенегал', 'Senegal', 'SN', 'SEN', 686);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('2c9f84e4-1686-4fe4-8307-fc756bdc8690'::uuid, 'Сент-Винсент и Гренадины', '', 'Saint Vincent and the Grenadines', 'VC', 'VCT', 670);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('739934a6-838c-4248-a961-bf5c12f8ec1d'::uuid, 'Сент-Китс и Невис', '', 'Saint Kitts and Nevis', 'KN', 'KNA', 659);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('79bd82b0-d6a6-43a1-b999-6ff4a925b340'::uuid, 'Сент-Люсия', '', 'Saint Lucia', 'LC', 'LCA', 662);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e3d3687b-a1f6-4702-87cf-b05d72710582'::uuid, 'Сент-Пьер и Микелон', '', 'Saint Pierre and Miquelon', 'PM', 'SPM', 666);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('399e8b9f-9bea-4068-bd14-0fc44ebf4727'::uuid, 'Сербия', 'Республика Сербия', 'Serbia', 'RS', 'SRB', 688);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('68ba2090-c1d7-416e-8f5e-4e4f9cab0c13'::uuid, 'Сейшелы', 'Республика Сейшелы', 'Seychelles', 'SC', 'SYC', 690);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('acfd0537-a245-4e42-bb87-a0bd71d3f4a4'::uuid, 'Сингапур', 'Республика Сингапур', 'Singapore', 'SG', 'SGP', 702);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('c747c0c2-9fb0-4290-b2e0-ae4dc1775ed8'::uuid, 'Синт-Мартен', '', 'Sint Maarten', 'SX', 'SXM', 534);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('9c3e51f8-fa29-4337-afa1-48f8f583c889'::uuid, 'Сирийская Арабская Республика', '', 'Syrian Arab Republic', 'SY', 'SYR', 760);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('007e831a-2f65-4aed-8c3b-2a25c76815b8'::uuid, 'Словакия', 'Словацкая Республика', 'Slovakia', 'SK', 'SVK', 703);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e7af1955-e0f2-4cac-b0e1-b1e9e6c05028'::uuid, 'Словения', 'Республика Словения', 'Slovenia', 'SI', 'SVN', 705);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('fd6a1aca-c625-40ad-a63c-72105c4befa7'::uuid, 'Соединенное Королевство', 'Соединенное Королевство Великобритании и Северной Ирландии', 'United Kingdom', 'GB', 'GBR', 826);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('80559d13-1ef0-4938-9378-4dd456f9912f'::uuid, 'Соединенные Штаты', 'Соединенные Штаты Америки', 'United States', 'US', 'USA', 840);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('00813e70-4fe3-449a-9d13-5394cef3f58f'::uuid, 'Соломоновы острова', '', 'Solomon Islands', 'SB', 'SLB', 90);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('81eb7ef5-ad3d-4481-beff-eb9b48eef167'::uuid, 'Сомали', 'Сомалийская Республика', 'Somalia', 'SO', 'SOM', 706);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('93603c40-88b6-42ac-b1a6-1ddf9e83d5b3'::uuid, 'Судан', 'Республика Судан', 'Sudan', 'SD', 'SDN', 729);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('f7aed373-8b75-4df5-b27c-2690a48781ef'::uuid, 'Суринам', 'Республика Суринам', 'Suriname', 'SR', 'SUR', 740);
INSERT INTO public.""Country""
(""Id"", ""Name"", ""FullName"", ""EnglishName"", ""Alpha2"", ""Alpha3"", ""Iso"")
VALUES('e0082433-a9b7-44be-8491-632f41e3a161'::uuid, 'Сьерра-Леоне', 'Республика Сьерра-Леоне', 'Sierra Leone', 'SL', 'SLE', 694);
");

			migrationBuilder.Sql(@"
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3bf33437-f44b-466a-931a-d70d4ed6cbb7'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Адыгея', 'Adygeya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3d9b6e5b-f1ae-4bed-9f18-818cd494b177'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Башкортостан', 'Bashkortostan Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('e36cf4e1-50a1-4bf8-bb49-5f6764ed0438'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Бурятия', 'Buryatiya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('ee26147c-1911-4c86-9040-ec5db29b3b19'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Алтай', 'Altai');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('ad290a90-d362-4925-8fcc-92d7216ce60a'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Дагестан', 'Dagestan');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3efd159b-6ea3-41c5-9cbc-6d1f957264a5'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Ингушетия', 'Ingushetiya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('00fc3ae5-dbaf-44a0-a616-8d4a6a237946'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Кабардино-Балкарская Респ', 'Kabardino-Balkariya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3769c270-9b94-496b-9c55-a7c2ce7bd018'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Калмыкия', 'Kalmykiya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('77700edd-6915-4fb8-a2ff-e131bae93e02'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Карачаево-Черкесская Респ', 'Karachayevo-Cherkesiya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('2f4546b0-3d97-46c8-8101-51c2b2b883a1'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Карелия', 'Karelia');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('cef22aa5-dfd3-425a-8b01-787c6aa17c65'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Коми', 'Komi');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('a8539c4c-d725-4aa7-a899-9c3b08b99021'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Марий Эл', 'Mariy-El Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('d378ee47-247f-46e0-95bc-b5933e19c797'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Мордовия', 'Mordoviya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('6a48773c-8737-4de1-b463-9a804aaabf85'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Саха /Якутия/', 'Sakha');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('1368cd65-0ced-4e5c-92b9-8111cd9d2a22'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Северная Осетия - Алания', 'North Ossetia');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('112f6032-e121-4f1c-8a51-420caba06083'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Татарстан', 'Tatarstan Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('f5aa99b1-6de7-4194-a89a-f350af69fd57'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Тыва', 'Republic of Tyva');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('8b8826b3-000d-4970-9555-f729f7a1cce2'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Удмуртская Респ', 'Udmurtiya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('6190f3dc-d7cc-42b3-94d5-61290737da26'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Хакасия', 'Khakasiya Republic');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('515bea14-c68a-434f-98cd-62a834f044a7'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Чеченская Респ', 'Chechnya');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('f7055f29-4505-436e-becb-589595163426'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Чувашская Республика - Чувашия', 'Chuvashia');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('343c407f-d1b6-4da6-b2c3-842d3625ab84'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Алтайский край', 'Altai Krai');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3a04e2b2-3a2d-4ca0-8677-a1c44b2c6ea9'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Краснодарский край', 'Krasnodarskiy');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('0b3886a4-06cf-4b6a-b348-9413979ed7bc'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Красноярский край', 'Krasnoyarskiy');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('b9b2d9d2-b472-45e6-9b0b-f0f11c23cd3e'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Приморский край', 'Primorskiy (Maritime) Kray');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3a433bfe-9d14-4331-9262-621dded94a2b'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ставропольский край', 'Stavropol Kray');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('e6da54cb-3bb2-41cc-b805-701eac34c184'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Хабаровский край', 'Khabarovsk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('8be0d1b7-0eb0-47e8-8db6-02b101197aff'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Амурская обл', 'Amur Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('4a250389-eb6a-4257-89bd-b336fb27132c'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Архангельская обл', 'Arkhangelskaya');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('e4ee5dd1-36b4-461d-ac27-4cbd77e2ac3d'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Астраханская обл', 'Astrakhan');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('0bc80dbb-d556-4216-9650-f80372f3c609'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Белгородская обл', 'Belgorod Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('fde93da9-cc39-4b23-bef6-7c3c1b929e7c'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Брянская обл', 'Bryansk Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('fd62cab9-8fbf-4d49-8731-8b94a10e778e'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Владимирская обл', 'Vladimir');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('213c18ec-b0da-4a06-8412-5a546d2b3fa8'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Волгоградская обл', 'Volgograd Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('e3f2ea80-d918-4139-8423-8c2734010269'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Вологодская обл', 'Vologda');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('fc042ef6-0e96-4661-b0e5-14feff7191fe'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Воронежская обл', 'Voronezj');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('18aa01fe-b1a1-4d29-81d8-5318d5aad5dc'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ивановская обл', 'Ivanovo');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('9aa9c99a-53df-4957-b426-db8182ea48f4'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Иркутская обл', 'Irkutsk Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('5cca9afc-aef7-4bc3-addc-01a30f39181b'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Калининградская обл', 'Kaliningrad');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('24c72c2a-2a05-48fc-a270-6e3b3c123b84'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Калужская обл', 'Kaluga');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('bb024a2f-e5fd-4489-b3df-d33cf778c4b9'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Камчатский край', 'Kamchatka');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('e437cdad-fe8a-436d-8fb1-ae80f172950a'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Кемеровская область - Кузбасс', 'Kemerovo Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('123bf07d-42bc-4517-b616-d2cc607c8dab'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Кировская обл', 'Kirov');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('528ac3e4-edac-4aba-9297-244804d85560'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Костромская обл', 'Kostroma Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3b6e319d-dd5e-4bcf-84c6-97c679390fb4'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Курганская обл', 'Kurgan Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('23599a39-e337-4de6-a694-1ce5cd9a9c81'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Курская обл', 'Kursk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('cc8220e8-2413-4570-ad62-b79b3c66e92b'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ленинградская обл', 'Leningradskaya Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('c285ede7-2bd1-414f-9281-e244d59548e9'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Липецкая обл', 'Lipetsk Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('1202c04c-1787-40e4-ae28-4f7ef313cb5d'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Магаданская обл', 'Magadan Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('c66dea0d-623d-4bda-8dc5-8f8e6bdd7684'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Московская обл', 'Moscow Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('9822bcce-0d4f-432e-b423-07dc81755f64'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Мурманская обл', 'Murmansk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('7a6c49f6-4e8f-4688-a216-1b6e9065a1f3'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Нижегородская обл', 'Nizhny Novgorod Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('a9beddb4-0d2c-4341-b57e-b442d750fe88'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Новгородская обл', 'Novgorod Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('f4ccc5fe-6b21-4643-8b8f-022d90d67982'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Новосибирская обл', 'Novosibirsk Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('c9bbf773-ef24-4190-931a-48906a6d6ecc'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Омская обл', 'Omsk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3058cbb1-b96e-4c9b-929f-48bbe6c098a0'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Оренбургская обл', 'Orenburg Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('c7385033-4a38-4a2b-b738-d3def451f5ed'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Орловская обл', 'Orel Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('afd14f2c-553a-4e2d-971e-543d32d957d3'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Пензенская обл', 'Penza');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('f36afc45-dfb3-4172-8217-f0394157f13c'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Пермский край', 'Perm');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('f35dcfc9-ba95-4cc4-9074-496a5d5b1deb'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Псковская обл', 'Pskov Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('d7e8ad9a-b054-4ac3-9922-aa6be9b40ec7'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ростовская обл', 'Rostov');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('0168fa0c-aa3f-4791-a779-6093fadc19b9'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Рязанская обл', 'Ryazan Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('039d2d34-5622-4cf9-ab2c-080d60ce65a7'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Самарская обл', 'Samara Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('076068a0-faaf-4d13-abe5-4de1c0a30ce2'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Саратовская обл', 'Saratovskaya Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('cfa55534-cd5a-44cb-8f6a-ee6cff6f3d67'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Сахалинская обл', 'Sakhalin Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('0d31a4cf-8387-4835-9d70-bfb00a174a71'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Свердловская обл', 'Sverdlovsk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('762d132b-7079-43e7-94ef-4f5760e66ae3'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Смоленская обл', 'Smolensk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('ea5ee035-8074-46d4-8523-122dea321482'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Тамбовская обл', 'Tambov');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('384ebc50-612b-463a-a970-0eb87a1f5002'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Тверская обл', 'Tver Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Томская обл', 'Tomsk Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('a358311a-49b6-4525-909d-c2a6b5152a8b'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Тульская обл', 'Tula');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('8f6d7e8b-8ce4-48eb-abb5-e67b8981a526'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Тюменская обл', 'Tyumen Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('36555a2d-4b22-4887-a4a5-4ed2ac05dcde'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ульяновская обл', 'Ulyanovsk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('fbd0785a-3ba2-46b6-a420-196a7e0ef000'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Челябинская обл', 'Chelyabinsk');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('031abdc0-1a27-46eb-91d9-0d6f187983d6'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Забайкальский край', 'Transbaikal Territory');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('aea98fbc-2738-404b-9368-ac92802fbc81'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ярославская обл', 'Jaroslavl');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('d6fb63cc-9c9b-450f-ad35-122ae56aa3ee'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'г Москва', 'Moscow');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('1f94edd2-37ed-4937-9694-d29e9d4672f1'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'г Санкт-Петербург', 'St.-Petersburg');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('ec7fbda3-72ff-4c7e-94c4-caffcf06adcd'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Еврейская Аобл', 'Jewish Autonomous Oblast');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('04033a9c-d1a1-43c5-9da4-a22bb5eb2d6d'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ненецкий АО', 'Nenets');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('909e65c4-d6ad-4a19-ad83-0b365f08ed55'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ханты-Мансийский Автономный округ - Югра', 'Khanty-Mansia');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('bfa826d7-1988-4c6a-b409-da5fabbbce22'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Чукотский АО', 'Chukotka');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('50ebfe91-35a3-421a-ba73-3931ee59c91a'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Ямало-Ненецкий АО', 'Yamalo-Nenets');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('07e9112d-0678-4794-9959-a15da2c68d25'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'Респ Крым', 'Crimea');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('3d5d1dbf-a1a7-4c6c-923e-9e39f4734275'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'г Севастополь', 'Sevastopol City');
INSERT INTO public.""Region""
(""Id"", ""CountryId"", ""Name"", ""EnglishName"")
VALUES('fd3085d6-f8b1-4965-bfbb-c62b4e13605c'::uuid, '234cb59f-9c77-4ebf-91cc-55d5f566e6d2'::uuid, 'г Байконур', 'Baikonur');");

			migrationBuilder.Sql(@"
INSERT INTO public.""City""
(""Id"", ""RegionId"", ""Name"", ""Population"")
VALUES('61215e69-2935-4ba0-ba3e-bc13423ca801'::uuid, 'e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, 'Асино', 24913);
INSERT INTO public.""City""
(""Id"", ""RegionId"", ""Name"", ""Population"")
VALUES('ec615144-b9c3-4f5f-b0ff-c8c0b98fefc4'::uuid, 'e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, 'Кедровый', 1818);
INSERT INTO public.""City""
(""Id"", ""RegionId"", ""Name"", ""Population"")
VALUES('6c790a4b-9bd1-4bef-ad93-9db0992a9de9'::uuid, 'e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, 'Колпашево', 20824);
INSERT INTO public.""City""
(""Id"", ""RegionId"", ""Name"", ""Population"")
VALUES('bdf76673-e298-4d59-ba00-6c1005240fda'::uuid, 'e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, 'Северск', 106648);
INSERT INTO public.""City""
(""Id"", ""RegionId"", ""Name"", ""Population"")
VALUES('a45c9715-0cf4-4063-aaaa-ddc5bc77ae2f'::uuid, 'e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, 'Стрежевой', 39169);
INSERT INTO public.""City""
(""Id"", ""RegionId"", ""Name"", ""Population"")
VALUES('83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid, 'e4eef2bd-0ca8-4a9f-a2fe-23759a5a501f'::uuid, 'Томск', 545391);");

			migrationBuilder.Sql(@"
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('313bf3ed-4a79-4eb7-9860-ae266ff5211e'::uuid, 'Улица Айвазовского', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('45c46f20-2252-41b0-a5c4-201097bdecfc'::uuid, 'Улица Академика Сахарова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('93f1dec1-1919-4c10-a8e7-bdec22f62603'::uuid, 'Александровский проезд', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('fa36d2bf-72eb-485e-8830-5876d4dc7e77'::uuid, 'Алеутская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('78caf06d-60f2-4324-b0a1-205636a35783'::uuid, 'Алтайская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('07d26a93-82d3-4973-9c8e-c6a8639b07aa'::uuid, 'Асиновская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('aaa6bc65-613e-4433-b889-bb854ab12123'::uuid, 'Ачинская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('95fc8c8a-801a-412a-949c-a5dac784497b'::uuid, 'Улица Бакунина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('dc8e175b-2fe9-41f2-8424-d643206415f6'::uuid, 'Площадь Батенькова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('235d9daa-0e47-43ad-8427-85405efae34d'::uuid, 'Улица Беленца', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('898f93f7-409d-4768-93c2-4b411b43b799'::uuid, 'Улица Белинского', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('01f9afa0-07ab-494f-a337-03ef16509728'::uuid, 'Белозёрская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('6fedc82a-630f-46dd-9ba1-5d22ec2b1525'::uuid, 'Улица Вершинина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('19a94231-0758-4f9f-b82d-1f0e3365ed60'::uuid, 'Улица Войкова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('cf03e1c4-4efe-4e0e-bd6d-468d5a14c63f'::uuid, 'Улица Гагарина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('d05c2db3-6d89-42fd-a748-3e79a49e06c9'::uuid, 'Улица Герцена', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('3bade5c4-2993-404e-bd30-c0875ecf1a7a'::uuid, 'Улица Гоголя', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('ddc3c371-e61c-4288-adb9-51281e366612'::uuid, 'Улица Максима Горького', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('6bfc9efe-fbed-44bc-a1dd-dec75354b612'::uuid, 'Дальне-Ключевская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('717637fc-a350-464d-9560-3dced2f1d09a'::uuid, 'Улица Дзержинского', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('ccc71211-edf5-4507-bfc5-514f91da9b73'::uuid, 'Улица Елизаровых', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('ce5a6218-bf9f-4892-8361-5f3912a6b034'::uuid, 'Улица Жуковского', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('84db3e5b-93eb-49ab-9fd8-7f4dc3749991'::uuid, 'Источная улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('9b9f4e7f-4126-47d7-a520-e8a91bd60f0b'::uuid, 'Улица Карташова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('91f9edd9-9ac0-4d18-abea-de4a8ec2288d'::uuid, 'Киевская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('fd1f2152-f100-474e-a48e-29aa00396276'::uuid, 'Красноармейская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('905d8c45-c0ae-4943-8440-49ce495af0f4'::uuid, 'Улица Крылова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('22c76a10-f395-4b5c-8deb-b3bc8a24d00b'::uuid, 'Улица Кузнецова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('1bcc6e07-f917-4c36-a574-cb833adfa9fb'::uuid, 'Кузнечный взвоз', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('0b6f9fa0-f95b-424b-b6b5-c3e21af6bd13'::uuid, 'Площадь Ленина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('030fbdcd-366d-4388-8995-ab207308c29f'::uuid, 'Улица Лермонтова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('ce5dddd0-3734-4207-97b8-bb124cf6e996'::uuid, 'Улица Лыткина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('59ae80d9-dfee-4fa7-a407-f1aaeb2e69c5'::uuid, 'Улица Розы Люксембург', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('6a8e7ee0-0827-4dc1-9f38-5dc92d5eed5d'::uuid, 'Улица Карла Маркса', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('7bbd954c-b6f4-4725-9f3a-29ff4ea61557'::uuid, 'Набережная реки Томи', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('5efcde75-114d-4ae4-93b0-e2bd7c9f65a0'::uuid, 'Набережная реки Ушайки', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('cc0f4df0-454e-4778-87fe-d3132c0c713e'::uuid, 'Улица Нахимова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('c7adf4a4-33e5-4bf2-a3ed-0a26e2813013'::uuid, 'Улица Никитина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('a2420bbd-9cec-48d2-ba02-7e809eeb9488'::uuid, 'Обруб (улица)', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('34759968-c30c-4f9d-8596-955ff5090c10'::uuid, 'Октябрьская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('fe705c2a-6f0d-4d25-9eeb-09761a935230'::uuid, 'Октябрьский взвоз', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('2acb3b66-381a-4f59-9e79-9911d810186b'::uuid, 'Улица Олега Кошевого', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('2036321c-abde-46be-a25f-609620367750'::uuid, 'Большая Подгорная улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('65dbd4c0-fc7c-46ed-a808-2425b6418e6a'::uuid, 'Малая Подгорная улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('37812136-1546-4ce5-b12a-27eeb136b5c3'::uuid, 'Улица Пушкина', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('0bd66240-942f-45b5-8b07-2fe5d202c734'::uuid, 'Улица Рузского', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('82182002-8397-405c-bf71-8a7329545180'::uuid, 'Улица Свердлова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('2bbd9ffb-3532-40c6-adcf-2605c7eab60c'::uuid, 'Сибирская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('c704328f-24db-422d-a3a1-a937c76e5feb'::uuid, 'Советская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('9505c8dd-ef8b-4091-8f08-46cdffa624db'::uuid, 'Соляная площадь', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('aeeb9743-bb50-4252-a1de-6cf725303bbf'::uuid, 'Татарская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('d2b0a1ac-2dd6-4558-9353-fc4b87e3b71d'::uuid, 'Тверская улица', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('b62426b4-fc18-48f3-80e6-88991b19ecea'::uuid, 'Улица Трифонова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('c83dcb79-640c-4c26-9887-87081b2533c3'::uuid, 'Улица Усова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('f2ba7680-3b79-410b-b712-2b789a5b4e03'::uuid, 'Улица Ивана Черных', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('7d4efb24-20e4-471a-bbb6-10169e07a794'::uuid, 'Улица Шишкова', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('c2113e33-0baa-48e3-be75-14ca9c09ae07'::uuid, 'Южная площадь', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);
INSERT INTO public.""Street""
(""Id"", ""Name"", ""CityId"")
VALUES('dbdba00f-c60f-440b-82b0-93f119bd44f0'::uuid, 'Улица Яковлева', '83c21f4b-b733-4f24-ad82-ccc855ffeaa8'::uuid);");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Street",
                schema: "public");

            migrationBuilder.DropTable(
                name: "City",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "public");
        }
    }
}
