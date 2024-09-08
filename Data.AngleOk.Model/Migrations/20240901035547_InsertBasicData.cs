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
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('0136c1e0-17af-4c72-b609-3788bec189d4'::uuid, 'Сельскохозяйственное использование');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('a19e25fc-9c7d-4cc0-b1fc-46a8232c18b0'::uuid, 'Жилая застройка');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('35cbabb8-80b7-440a-96a4-2f6d31f59e61'::uuid, 'Общественное использование объектов капитального строительства');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('d22cc699-8f1e-49ad-801d-edd1c0ed9faa'::uuid, 'Предпринимательство');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('db2a31f1-4fdf-492d-bef7-16e967fa6170'::uuid, 'Отдых (рекреация)');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('910e700b-2600-44e9-bea2-be8e584ea7af'::uuid, 'Производственная деятельность');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('40cd114f-c403-4a3d-9bd1-b07316746438'::uuid, 'Транспорт');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('6d42bb33-76c6-4e92-ab60-d38fad579cad'::uuid, 'Обеспечение обороны и безопасности');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('a011a493-63d0-4597-9208-36ff61fc6b88'::uuid, 'Деятельность по особой охране и изучению природы');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('3cd05439-7905-45a6-bda9-099a24d5363e'::uuid, 'Использование лесов');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('1bddf93a-f2db-4a41-b0d3-c1fc47ba986b'::uuid, 'Водные объекты');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('8da63e8f-7448-40e0-ba93-d5877022cf4b'::uuid, 'Земельные участки (территории) общего пользования');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('55befef9-88ee-42e7-92ed-6b39362d7355'::uuid, 'Земельные участки общего назначения');
INSERT INTO public.""SteadUseKind"" (""Id"", ""SteadUseKindName"") VALUES('21c0994d-8a1c-47f9-a581-5460f1aabd58'::uuid, 'Земельные участки, входящие в состав общего имущества собственников индивидуальных жилых домов в малоэтажном жилом комплексе');

INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES('ff06e058-51d9-4714-8873-c59c030e6561'::uuid, 'Покупка');
INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES('1c22c2dc-565d-4c23-bf3c-a7ca17842bfa'::uuid, 'Продажа');
INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES('81a3dacc-ea1e-4914-9fa4-ba8bbb5cf4fe'::uuid, 'Сдача в аренду');
INSERT INTO public.""DealType"" (""Id"", ""DealTypeName"") VALUES('f0173d1e-c7ac-4d86-8a15-7cd2b31e84d8'::uuid, 'Съем в аренду');

INSERT INTO public.""ClientType"" (""Id"", ""ClientTypeName"") VALUES(uuid_generate_v4(), 'ФЛ');
INSERT INTO public.""ClientType"" (""Id"", ""ClientTypeName"") VALUES(uuid_generate_v4(), ' ЮЛ');

INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES('8227be9b-8e35-4de2-9fbf-0b348f9dd8cc'::uuid, 'Квартира');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES('5e2321d3-2cba-4d67-8b09-4225e8847b2e'::uuid, 'Дом');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES('2e7f4b66-c03a-4c3b-af42-e7c3d2b65a77'::uuid, 'Дача');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES('89bef946-cda0-458e-96f9-327d6ed3af65'::uuid, 'Земельный участок');
INSERT INTO public.""RealtyObjectKind"" (""Id"", ""RealtyObjectKindName"") VALUES('3daef0bf-b7ee-45d9-a0bc-a264906801d5'::uuid, 'Гараж');

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
