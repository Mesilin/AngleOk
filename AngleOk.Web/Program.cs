using AngleOk.Web.Repositories.Abstract;
using AngleOk.Web.Repositories.EntityFramework;
using AngleOk.Web.Services;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/account/login";
        options.AccessDeniedPath = "/accessdenied";
    });

    builder.Services.AddAuthorization();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false);

var config = new Config();
IConfigurationSection section = builder.Configuration.GetSection("Project");
section.Bind(config);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
var ob = new DbContextOptionsBuilder<AngleOkContext>().UseNpgsql(connection);

builder.Services.AddDbContext<AngleOkContext>(options => options.UseNpgsql(connection));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            // Перевод ошибок валидации identity на русский язык
            .AddErrorDescriber<RussianIdentityErrorDescriber>()
            .AddEntityFrameworkStores<AngleOkContext>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ru-RU");
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("ru-RU") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("ru-RU") };
});

AngleOkContext context = new AngleOkContext(ob.Options);
context.Database.Migrate();

//builder.Services.AddTransient<IPersonsRepository, EFPersonsRepository>();
builder.Services.AddTransient<IAdvertisementRepository, EFAdvertisementRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
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
//else
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/accessdenied", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Доступ запрещен");
});

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();