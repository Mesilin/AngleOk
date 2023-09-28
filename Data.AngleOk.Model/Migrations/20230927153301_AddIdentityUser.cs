using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"AspNetRoles\" (\"Id\", \"Name\", \"NormalizedName\") " +
                "VALUES('de84fe4c-2eb8-439e-bebd-ce27e84958a2', 'admin', 'ADMIN');");

            var hash = new PasswordHasher<IdentityUser>().HashPassword(null, "AngleOk");
            migrationBuilder.Sql($"INSERT INTO public.\"AspNetUsers\" " +
                "(\"Id\", \"UserName\", \"NormalizedUserName\", \"Email\", \"NormalizedEmail\", \"EmailConfirmed\", \"PasswordHash\", \"SecurityStamp\"," +
                " \"PhoneNumberConfirmed\", \"TwoFactorEnabled\", \"LockoutEnabled\", \"AccessFailedCount\") " +
                "VALUES('6fc12c6d-99e7-444b-9bed-a0a8cf6f08b4', 'admin', 'ADMIN', 'mesilin@mail.ru', 'MESILIN@MAIL.RU', true, '" + hash + "', '', " +
                "false, false, false, 999);");
            
            migrationBuilder.Sql("INSERT INTO public.\"AspNetUserRoles\" (\"UserId\", \"RoleId\") " +
                "VALUES('6fc12c6d-99e7-444b-9bed-a0a8cf6f08b4', 'de84fe4c-2eb8-439e-bebd-ce27e84958a2');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
