using Microsoft.EntityFrameworkCore.Migrations;
using System;

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

            //var dt = DateTime.UtcNow;
            //migrationBuilder.InsertData("TextField",
            //    columns: new[]
            //    {
            //        nameof(TextField.Id), nameof(TextField.CodeWord), nameof(TextField.Title), nameof(TextField.DateAdded), nameof(TextField.Text)
            //    },
            //    values: new object[,]
            //    {
            //        {Guid.NewGuid(), "PageIndex", "Главная", dt, "Содержимое страницы Главная"},
            //        {Guid.NewGuid(), "PageAdvertisements", "Объявления", dt, "Содержимое страницы Объявления"},
            //        {Guid.NewGuid(), "PageContacts", "Контакты", dt, "Содержимое страницы Контакты"},
            //    }, schema:"public");

            migrationBuilder.Sql("INSERT INTO public.\"TextField\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\")" +
                                 $"VALUES(uuid_generate_v4(), 'PageIndex', 'Главная', '{DateTime.UtcNow}', 'Содержимое страницы Главная');");

            migrationBuilder.Sql("INSERT INTO public.\"TextField\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\")" +
                                 $"VALUES(uuid_generate_v4(), 'PageAdvertisements', 'Объявления', '{DateTime.UtcNow}', 'Содержимое страницы Объявления');");

            migrationBuilder.Sql("INSERT INTO public.\"TextField\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\")" +
                                 $"VALUES(uuid_generate_v4(), 'PageContacts', 'Контакты', '{DateTime.UtcNow}', 'Содержимое страницы Контакты');");

            migrationBuilder.Sql(
                "INSERT INTO public.\"AspNetUsers\"\n(\"Id\", \"UserName\", \"NormalizedUserName\", \"Email\", \"NormalizedEmail\", \"EmailConfirmed\", " +
                "\"PasswordHash\", \"SecurityStamp\", \"ConcurrencyStamp\", \"PhoneNumber\", \"PhoneNumberConfirmed\", " +
                "\"TwoFactorEnabled\", \"LockoutEnd\", \"LockoutEnabled\", \"AccessFailedCount\")\n" +
                "VALUES('74c2a3db-023d-4270-8c97-fb56430a5793', 'mesilin@mail.ru', 'MESILIN@MAIL.RU', 'mesilin2@mail.ru', " +
                "'MESILIN2@MAIL.RU', false, 'AQAAAAIAAYagAAAAEEz8FLH6vJM1iE8IAqeNTqgjx/5vAD5+jnUl+E+tG69tiazYhAhDQSD9b+3Mnv97cA==', " +
                "'LA2GDDI2CYLUMLSSWU4AZDOX7NO7EBUB', '35d24c7e-a440-4cc0-b2c1-b124ccbd870a', NULL, false, false, NULL, true, 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
