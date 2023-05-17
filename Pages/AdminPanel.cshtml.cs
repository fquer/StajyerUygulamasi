using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class AdminPanel : PageModel
    {
        private readonly ILogger<AdminPanel> _logger;
        private readonly ApplicationDbContext _db;

        public AdminPanel(ILogger<AdminPanel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public Intern Intern { get; set; }
        public InternSubmitted InternSubmitted { get; set; }

        public async Task<IActionResult> OnGet()
        {
            
            return Page();
        }


        [BindProperty(Name = "companyName")]
        public String postCompanyName { get; set; }

        [BindProperty(Name = "position")]
        public String postPosition { get; set; }

        [BindProperty(Name = "details")]
        public String postDetails { get; set; }
        public async Task<IActionResult> OnPost()
        {
            Intern newIntern = new Intern();
            newIntern.CompanyName = postCompanyName;
            newIntern.Position = postPosition;
            newIntern.Details = postDetails;
            newIntern.OpenTime = DateTime.Now;

            await _db.Intern.AddAsync(newIntern);
            await _db.SaveChangesAsync();
            return Page();
        }
    }
}