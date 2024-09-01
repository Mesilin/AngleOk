using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AngleOk.Model.Migrations
{
    /// <inheritdoc />
    public partial class InsertBasicData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Сельскохозяйственное использование');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Жилая застройка');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Общественное использование объектов капитального строительства');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Предпринимательство');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Отдых (рекреация)');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Производственная деятельность');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Транспорт');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Обеспечение обороны и безопасности');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Деятельность по особой охране и изучению природы');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Использование лесов');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Водные объекты');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Земельные участки (территории) общего пользования');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Земельные участки общего назначения');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES(uuid_generate_v4(), 'Земельные участки, входящие в состав общего имущества собственников индивидуальных жилых домов в малоэтажном жилом комплексе');

INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES(uuid_generate_v4(), 'Покупка');
INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES(uuid_generate_v4(), 'Продажа');
INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES(uuid_generate_v4(), 'Сдача в аренду');
INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES(uuid_generate_v4(), 'Съем в аренду');

INSERT INTO public.""ClientType"" (""Id"", ""ClientTypeName"") VALUES(uuid_generate_v4(), 'ФЛ');
INSERT INTO public.""ClientType"" (""Id"", ""ClientTypeName"") VALUES(uuid_generate_v4(), ' ЮЛ');

INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES(uuid_generate_v4(), 'Квартира');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES(uuid_generate_v4(), 'Дом');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES(uuid_generate_v4(), 'Дача');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES(uuid_generate_v4(), 'Земельный участок');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES(uuid_generate_v4(), 'Гараж');
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
