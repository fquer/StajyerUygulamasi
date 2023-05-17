using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class InternsSubmitted : PageModel
    {
        private readonly ILogger<InternsSubmitted> _logger;
        private readonly ApplicationDbContext _db;

        public InternsSubmitted(ILogger<InternsSubmitted> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public Intern Intern { get; set; }
        public InternSubmitted InternSubmitted { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var loginStajyerID = HttpContext.Session.GetInt32("loginStajyerID");
            if (loginStajyerID == null)
            {
                TempData["LoginMessage"] = "Oturumunuzun süresi doldu!";
                return RedirectToPage("Login");
            }
            List<InternSubmitted> internsSubmitted = await _db.InternSubmitted.Where(dbInternSubmitted => dbInternSubmitted.StajyerID.Equals(loginStajyerID)).ToListAsync();
            List<Intern> interns = await _db.Intern.Where(dbIntern => internsSubmitted.Select(submitted => submitted.InternID).Contains(dbIntern.Id)).ToListAsync();
            ViewData["InternsSubmitted"] = interns;
            ViewData["stajyerID"] = loginStajyerID;
            return Page();
        }


        [BindProperty(Name = "internID")]
        public int postInternID { get; set; }

        [BindProperty(Name = "stajyerID")]
        public int postStajyerID { get; set; }
        public async Task<IActionResult> OnPost()
        {
            Intern foundedIntern = await _db.Intern.FindAsync(postInternID);
            foundedIntern.ApplicantsCounter = foundedIntern.ApplicantsCounter - 1;

            InternSubmitted internSubmitted = await _db.InternSubmitted.FirstOrDefaultAsync(dbInternSubmitted => dbInternSubmitted.InternID == postInternID && dbInternSubmitted.StajyerID == postStajyerID);
            _db.InternSubmitted.Remove(internSubmitted);
            await _db.SaveChangesAsync();
            return RedirectToPage("InternsSubmitted");
        }
    }
}