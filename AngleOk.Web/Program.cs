using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection")??"";

//builder.Services.AddRazorPages();// ��������� � ���������� ������� Razor Pages

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AngleOkContext>(options => options.UseNpgsql(connectionString: connection));
//builder.Services.AddSingleton<ITimeService, SimpleTimeService>();
//builder.Services.AddScoped<ITimeService, SimpleTimeService>(); // ��������� ������ ITimeService
builder.Services.AddTransient<ITimeService, SimpleTimeService>(); // ��������� ������ ITimeService

//builder.Services.AddMvc();//: ��������� ��� ������� ���������� MVC (� ��� ����� ������� ��� ������ � ��������������� � ������������, ���������� � �.�.)
//builder.Services.AddMvcCore();//: ��������� ������ �������� ������� ���������� MVC, � ��� �������������� ����������������, ���� ��������������� � ������������, ���������� � �.�., ���������� ��������� ��������������
builder.Services.AddControllersWithViews();//: ��������� ������ �� ������� ���������� MVC, ������� ��������� ������������ ����������� � ������������� � ��������� ����������������. ��� �������� ������� �� ���� ASP.NET Core Web App (Model-View-Controller) ������������ ������ ���� �����
//builder.Services.AddControllers();//: ��������� ������������ �����������, �� ��� �������������.

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AngleOk",
        Description = "�������� ������������ \"������\". �������� ������� API. ���������� ����������� � ������ ������ ��� �������� �������� �� ���������� \"���� ������\" ",
        Contact = new OpenApiContact
        {
            Name = "������� �������",
            Url = new Uri("https://github.com/Mesilin"),
            Email= "mesilin@mail.ru"
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

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

//app.MapRazorPages();// ��������� ��������� ������������� ��� Razor Pages

// ������������� ������������� ��������� � �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=AllUsers}");

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