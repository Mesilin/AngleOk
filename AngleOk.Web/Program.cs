using AngleOk.Web.Repositories.Abstract;
using AngleOk.Web.Repositories.EntityFramework;
using AngleOk.Web.Service;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//var confBuilder = new ConfigurationBuilder(); confBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false);
//IConfigurationRoot configuration = builder.Build();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false);

var config = new Config();
IConfigurationSection section = builder.Configuration.GetSection("Project");
section.Bind(config);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddTransient<ITimeService, SimpleTimeService>();

builder.Services.AddDbContext<AngleOkContext>(options => options.UseNpgsql(connection));
AngleOkContext context=new AngleOkContext();
context.Database.Migrate();
builder.Services.AddTransient<IPersonsRepository, EFPersonsRepository>(); // добавляем сервис ITimeService
builder.Services.AddTransient<DataManager>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{ options.User.RequireUniqueEmail = true;
options.Password.RequiredLength=6;
options.Password.RequireNonAlphanumeric=false;
options.Password.RequireLowercase=false;
options.Password.RequireUppercase=false;
options.Password.RequireDigit=false;
}).AddEntityFrameworkStores<AngleOkContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AngleOkAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

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
        Description = "<h2>Агенство недвижимости \"Уголок\".<br>Описание методов API.</h2>" +
        "<h3>Приложение разработано в рамках работы над курсовым проектом по дисциплине \"Базы данных\"</h3>",
        Contact = new OpenApiContact
        {
            Name = "Евгений Месилин",
            Url = new Uri("https://github.com/Mesilin"),
            Email = "mesilin@mail.ru"
        },
        License = new OpenApiLicense
        {
            Name = "CCA License",
            Url = new Uri("https://creativecommons.org/licenses/by/3.0/legalcode")
        }
    });
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "AngleOk.Web.xml");
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
//app.MapRazorPages();


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