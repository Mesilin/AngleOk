using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AngleOkContext>(options => options.UseNpgsql(connectionString: connection));
//builder.Services.AddSingleton<ITimeService, SimpleTimeService>();
//builder.Services.AddScoped<ITimeService, SimpleTimeService>(); // добавляем сервис ITimeService
builder.Services.AddTransient<ITimeService, SimpleTimeService>(); // добавляем сервис ITimeService

//builder.Services.AddMvc();//: добавляет все сервисы фреймворка MVC (в том числе сервисы для работы с аутентификацией и авторизацией, валидацией и т.д.)
//builder.Services.AddMvcCore();//: добавляет только основные сервисы фреймворка MVC,
    //  а всю дополнительную функциональность, типа аутентификацией и авторизацией, валидацией и т.д., необходимо добавлять самостоятельно
//builder.Services.AddMvcCore();//: добавляет только основные сервисы фреймворка MVC,
    //  а всю дополнительную функциональность, типа аутентификацией и авторизацией, валидацией и т.д., необходимо добавлять самостоятельно

builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();//: добавляет только те сервисы фреймворка MVC,
                                                                             //которые позволяют использовать контроллеры и представления и связанную функциональность.
                                                                             //При создании проекта по типу ASP.NET Core Web App (Model-View-Controller) используется именно этот метод

//builder.Services.AddControllers();//: позволяет использовать контроллеры, но без представлений.
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AngleOk",
        Description = "<h2>Агенство недвижимости \"Уголок\".<br>Описание методов API.</h2><h3>Приложение разработано в рамках работы над курсовым проектом по дисциплине \"Базы данных\"</h3>",
        Contact = new OpenApiContact
        {
            Name = "Евгений Месилин",
            Url = new Uri("https://github.com/Mesilin"),
            Email = "mesilin@mail.ru"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://mesilin.github.io/")
        }
    });
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "AngleOk.Web.xml");
    options.IncludeXmlComments(xmlPath);
});
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
/// <summary>
/// 
/// </summary>
public interface ITimeService
{
    /// <summary>
    /// 
    /// </summary>
    string Time { get; }
}
/// <summary>
/// 
/// </summary>
public class SimpleTimeService : ITimeService
{
    /// <summary>
    /// 
    /// </summary>
    public string Time => DateTime.Now.ToShortTimeString();
}