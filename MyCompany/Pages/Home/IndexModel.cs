using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyCompany.Pages.Home
{
    public class IndexModel : PageModel
    {
        // Свойство для передачи данных в представление
        public string WelcomeMessage { get; private set; } = string.Empty;

        // Метод для обработки GET-запросов
        public void OnGet()
        {
            // Логика обработки данных
            WelcomeMessage = "Добро пожаловать на наш сайт! Мы рады видеть вас.";
        }
    }
}
