using MyCompany.Infrastructure;

namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� ������������ �� appsettings.json � ���������� ���������
            var configuration = builder.Configuration;
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables();

            // ����������� ������ "Project" � ������� AppConfig
            var config = configuration.GetSection("Project").Get<AppConfig>()!;

            // ��������� ������� ��� MVC � Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // ��������� ������
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // ��� ����������
            }
            else
            {
                app.UseExceptionHandler("/Error"); // ��� ����������
                app.UseHsts();
            }

            // ���������� ������������� ����������� ������
            app.UseStaticFiles();

            // ���������� �������������
            app.UseRouting();

            // ����������� ��������
            app.MapDefaultControllerRoute(); // ����������� ������� ��� ������������
            app.MapRazorPages(); // ����������� Razor Pages

            await app.RunAsync();
        }
    }
}
