using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class InternsModel : PageModel
    {
        private readonly ILogger<InternsModel> _logger;
        private readonly ApplicationDbContext _db;

        public InternsModel(ILogger<InternsModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public Intern Intern { get; set; }
        public IActionResult OnGet()
        {
            var loginStajyerID = HttpContext.Session.GetInt32("loginStajyerID");
            if (loginStajyerID == null)
            {
                TempData["LoginMessage"] = "Oturumunuzun süresi doldu!";
                return RedirectToPage("Login");
            }
            List<Intern> interns = _db.Intern.ToList();
            ViewData["Interns"] = interns;
            return Page();
        }

    }
}