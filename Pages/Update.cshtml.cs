using AdoPractice.Data;
using AdoPractice.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdoPractice.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly UserDbContext _context;

        public UpdateModel(UserDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(u => u.ID == User.ID))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToPage("/Index"); // Redirect back to the main page
        }
    }

}

