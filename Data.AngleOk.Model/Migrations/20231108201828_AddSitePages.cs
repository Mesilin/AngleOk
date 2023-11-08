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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
