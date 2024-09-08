using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddSitePages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");
            migrationBuilder.Sql($"INSERT INTO public.\"TextField\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\") VALUES(uuid_generate_v4(), 'PageIndex', 'Главная', '{DateTime.UtcNow}', 'Содержимое страницы Главная');");
            migrationBuilder.Sql($"INSERT INTO public.\"TextField\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\") VALUES(uuid_generate_v4(), 'PageAdvertisements', 'Объявления', '{DateTime.UtcNow}', 'Содержимое страницы Объявления');");
            migrationBuilder.Sql($"INSERT INTO public.\"TextField\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\") VALUES(uuid_generate_v4(), 'PageContacts', 'Контакты', '{DateTime.UtcNow}', 'Содержимое страницы Контакты');");

            //migrationBuilder.Sql(
            //    "INSERT INTO public.\"AspNetUsers\"\n(\"Id\", \"UserName\", \"NormalizedUserName\", \"Email\", \"NormalizedEmail\", \"EmailConfirmed\", " +
            //    "\"PasswordHash\", \"SecurityStamp\", \"ConcurrencyStamp\", \"PhoneNumber\", \"PhoneNumberConfirmed\", " +
            //    "\"TwoFactorEnabled\", \"LockoutEnd\", \"LockoutEnabled\", \"AccessFailedCount\")\n" +
            //    "VALUES('74c2a3db-023d-4270-8c97-fb56430a5793', 'mesilin@mail.ru', 'MESILIN@MAIL.RU', 'mesilin2@mail.ru', " +
            //    "'MESILIN2@MAIL.RU', false, 'AQAAAAIAAYagAAAAEEz8FLH6vJM1iE8IAqeNTqgjx/5vAD5+jnUl+E+tG69tiazYhAhDQSD9b+3Mnv97cA==', " +
            //    "'LA2GDDI2CYLUMLSSWU4AZDOX7NO7EBUB', '35d24c7e-a440-4cc0-b2c1-b124ccbd870a', NULL, false, false, NULL, true, 0);");
            
            //users
            migrationBuilder.Sql("INSERT INTO public.\"AspNetUsers\"\r\n(\"Id\", \"UserName\", \"NormalizedUserName\", \"Email\", \"NormalizedEmail\", \"EmailConfirmed\", \"PasswordHash\", \"SecurityStamp\", \"ConcurrencyStamp\", \"PhoneNumber\", \"PhoneNumberConfirmed\", \"TwoFactorEnabled\", \"LockoutEnd\", \"LockoutEnabled\", \"AccessFailedCount\")\r\nVALUES('74c2a3db-023d-4270-8c97-fb56430a5793', 'mesilin@mail.ru', 'MESILIN@MAIL.RU', 'mesilin@mail.ru', 'MESILIN@MAIL.RU', false, 'AQAAAAIAAYagAAAAEEz8FLH6vJM1iE8IAqeNTqgjx/5vAD5+jnUl+E+tG69tiazYhAhDQSD9b+3Mnv97cA==', 'LA2GDDI2CYLUMLSSWU4AZDOX7NO7EBUB', '35d24c7e-a440-4cc0-b2c1-b124ccbd870a', NULL, false, false, NULL, true, 0);");
            migrationBuilder.Sql("INSERT INTO public.\"AspNetUsers\"\r\n(\"Id\", \"UserName\", \"NormalizedUserName\", \"Email\", \"NormalizedEmail\", \"EmailConfirmed\", \"PasswordHash\", \"SecurityStamp\", \"ConcurrencyStamp\", \"PhoneNumber\", \"PhoneNumberConfirmed\", \"TwoFactorEnabled\", \"LockoutEnd\", \"LockoutEnabled\", \"AccessFailedCount\")\r\nVALUES('0f1314c6-4b36-4429-8329-9145b55002db', 'admin@angleok.ru', 'ADMIN@ANGLEOK.RU', 'admin@angleok.ru', 'ADMIN@ANGLEOK.RU', false, 'AQAAAAIAAYagAAAAEImzWKByZ9ePUm7JaWcVqaCxlzcZ7Wow08dxGVNIJZG8gBTKCbn5aZQZ3AkxdNpwTQ==', 'SDQMJEFOLZWJUUBKCMNCHHOWQYXJKPVI', 'fe5608b5-0bc2-460a-a2ae-5bb5260cf8e9', NULL, false, false, NULL, true, 0);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
