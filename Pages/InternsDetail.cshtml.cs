using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StajyerUygulamasi.Dto;
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
        public InternSubmitted InternSubmitted { get; set; }

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
            InternSubmitted foundedSubmittedIntern = await _db.InternSubmitted.FirstOrDefaultAsync(dbInternSubmitted => dbInternSubmitted.StajyerID.Equals(loginStajyerID) && dbInternSubmitted.InternID.Equals(internID));

            InternDto internDto = new InternDto();
            internDto.Id = intern.Id;
            internDto.Position = intern.Position;
            internDto.ApplicantsCounter = intern.ApplicantsCounter;
            internDto.Details = intern.Details;
            internDto.CompanyName = intern.CompanyName;
            internDto.OpenTime = intern.OpenTime;
            if (foundedSubmittedIntern != null)
            {
                internDto.isAplied = true;
            }
            
            ViewData["Intern"] = internDto;
            return Page();
        }

        [BindProperty(Name = "internID")]
        public int postInternID { get; set; }
        public async Task<IActionResult> OnPost()
        {
            Intern foundedIntern = await _db.Intern.FindAsync(postInternID);
            foundedIntern.ApplicantsCounter = foundedIntern.ApplicantsCounter + 1;

            InternSubmitted internSubmitted = new InternSubmitted();
            internSubmitted.SubmitTime = DateTime.Now;
            internSubmitted.InternID = postInternID;
            internSubmitted.StajyerID = (int)HttpContext.Session.GetInt32("loginStajyerID");
            await _db.InternSubmitted.AddAsync(internSubmitted);
            await _db.SaveChangesAsync();
            return RedirectToPage("InternsSubmitted");
        }

    }
}