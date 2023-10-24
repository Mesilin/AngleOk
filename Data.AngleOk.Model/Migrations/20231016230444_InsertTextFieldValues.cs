using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class InsertTextFieldValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

            migrationBuilder.Sql("INSERT INTO public.\"TextFields\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\")" +
                                 $"VALUES(uuid_generate_v4(), 'PageIndex', 'Главная', '{DateTime.UtcNow}', 'Содержимое страницы Главная');");

            migrationBuilder.Sql("INSERT INTO public.\"TextFields\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\")" +
                                 $"VALUES(uuid_generate_v4(), 'PageAdvertisements', 'Объявления', '{DateTime.UtcNow}', 'Содержимое страницы Объявления');");

            migrationBuilder.Sql("INSERT INTO public.\"TextFields\" (\"Id\", \"CodeWord\", \"Title\",\"DateAdded\",\"Text\")" +
                                 $"VALUES(uuid_generate_v4(), 'PageContacts', 'Контакты', '{DateTime.UtcNow}', 'Содержимое страницы Контакты');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
