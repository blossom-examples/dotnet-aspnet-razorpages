using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Home page accessed at: {Time}", DateTime.UtcNow);
        }
    }
}