using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoApp.Data;
using DemoApp.Models;

namespace DemoApp.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Todo> Todos { get; set; } = new List<Todo>();

        public async Task OnGetAsync()
        {
            Todos = await _context.Todos.OrderByDescending(t => t.CreatedAt).ToListAsync();
        }
    }
}