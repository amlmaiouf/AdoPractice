using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdoPractice.Data;
using AdoPractice.models;

public class DetailsModel : PageModel
{
    private readonly UserDbContext _context;

    public User User { get; private set; }

    public DetailsModel(UserDbContext context)
    {
        _context = context;
    }

    public void OnGet(int id)
    {
        User = _context.Users.FirstOrDefault(u => u.ID == id);
    }
}
