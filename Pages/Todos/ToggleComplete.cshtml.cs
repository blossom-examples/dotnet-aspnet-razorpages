using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoApp.Data;
using DemoApp.Models;

namespace DemoApp.Pages.Todos
{
    public class ToggleCompleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ToggleCompleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Todo Todo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            Todo = todo;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.IsComplete = !todo.IsComplete;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}