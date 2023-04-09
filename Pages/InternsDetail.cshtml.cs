using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class InternsDetailModel : PageModel
    {
        private readonly ILogger<InternsDetailModel> _logger;
        private readonly ApplicationDbContext _db;

        public InternsDetailModel(ILogger<InternsDetailModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public Intern Intern { get; set; }

        [BindProperty(SupportsGet = true)]
        public int internID { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var loginStajyerID = HttpContext.Session.GetInt32("loginStajyerID");
            if (loginStajyerID == null)
            {
                TempData["LoginMessage"] = "Oturumunuzun süresi doldu!";
                return RedirectToPage("Login");
            }
            if (internID == 0)
            {
                return RedirectToPage("Error");
            }
            Intern intern = await _db.Intern.FindAsync(keyValues: internID);
            ViewData["Intern"] = intern;
            return Page();
        }

        [BindProperty(Name = "internID")]
        public int postInternID { get; set; }
        public void OnPost()
        {
            Console.WriteLine(postInternID);
        }

    }
}