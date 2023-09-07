using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AngleOkContext>(options => options.UseNpgsql(connectionString: connection));

//builder.Services.AddMvc();//: добавляет все сервисы фреймворка MVC (в том числе сервисы для работы с аутентификацией и авторизацией, валидацией и т.д.)

//builder.Services.AddMvcCore();//: добавляет только основные сервисы фреймворка MVC,
//а всю дополнительную функциональность, типа аутентификацией и авторизацией, валидацией и т.д.,
//необходимо добавлять самостоятельно

builder.Services.AddControllersWithViews();//: добавляет только те сервисы фреймворка MVC,
                                           //которые позволяют использовать контроллеры и представления и связанную функциональность.
                                           //При создании проекта по типу ASP.NET Core Web App (Model-View-Controller) используется именно этот метод

//builder.Services.AddControllers();//: позволяет использовать контроллеры, но без представлений.

var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
