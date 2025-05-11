using MyCompany.Infrastructure;

namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Подключаем конфигурацию из appsettings.json и переменных окружения
            var configuration = builder.Configuration;
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables();

            // Привязываем секцию "Project" к объекту AppConfig
            var config = configuration.GetSection("Project").Get<AppConfig>()!;

            // Добавляем сервисы для MVC и Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Обработка ошибок
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Для разработки
            }
            else
            {
                app.UseExceptionHandler("/Error"); // Для продакшена
                app.UseHsts();
            }

            // Подключаем использование статических файлов
            app.UseStaticFiles();

            // Подключаем маршрутизацию
            app.UseRouting();

            // Настраиваем маршруты
            app.MapDefaultControllerRoute(); // Стандартный маршрут для контроллеров
            app.MapRazorPages(); // Подключение Razor Pages

            await app.RunAsync();
        }
    }
}
