using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AngleOkContext>(options => options.UseNpgsql(connectionString: connection));

//builder.Services.AddMvc();//: ��������� ��� ������� ���������� MVC (� ��� ����� ������� ��� ������ � ��������������� � ������������, ���������� � �.�.)

//builder.Services.AddMvcCore();//: ��������� ������ �������� ������� ���������� MVC,
//� ��� �������������� ����������������, ���� ��������������� � ������������, ���������� � �.�.,
//���������� ��������� ��������������

builder.Services.AddControllersWithViews();//: ��������� ������ �� ������� ���������� MVC,
                                           //������� ��������� ������������ ����������� � ������������� � ��������� ����������������.
                                           //��� �������� ������� �� ���� ASP.NET Core Web App (Model-View-Controller) ������������ ������ ���� �����

//builder.Services.AddControllers();//: ��������� ������������ �����������, �� ��� �������������.

var app = builder.Build();

// ������������� ������������� ��������� � �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
