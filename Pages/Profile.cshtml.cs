using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        private readonly ApplicationDbContext _db;

        public ProfileModel(ILogger<ProfileModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public About About { get; set; }
        public Skill Skill { get; set; }
        public Experience Experience { get; set; }
        public Education Education { get; set; }

        public async Task<IActionResult> setPageData()
        {
            var loginStajyerID = HttpContext.Session.GetInt32("loginStajyerID");
            if (loginStajyerID == null)
            {
                TempData["LoginMessage"] = "Oturumunuzun süresi doldu!";
                return RedirectToPage("Login");
            }
            else
            {
                var dbAbout = await _db.About.FindAsync(keyValues: HttpContext.Session.GetInt32("loginStajyerID"));
                if (dbAbout == null)
                {
                    TempData["AboutText"] = "";
                    TempData["AboutBirthDate"] = null;
                }
                else
                {
                    if (dbAbout.AboutText == null)
                    {
                        TempData["AboutText"] = "";
                    }
                    else
                    {
                        TempData["AboutText"] = dbAbout.AboutText;
                    }

                    TempData["AboutBirthDate"] = dbAbout.DateOfBirth;
                }

                var dbExperience = await _db.Experience.Where(dbExperience => dbExperience.StajyerID == HttpContext.Session.GetInt32("loginStajyerID")).ToListAsync();

                TempData["Experiences"] = dbExperience;

                var dbEducation = await _db.Education.Where(dbEducation => dbEducation.StajyerID == HttpContext.Session.GetInt32("loginStajyerID")).ToListAsync();

                TempData["Educations"] = dbEducation;

                return Page();
            }
        }

        public async Task<IActionResult> OnGet()
        {
            return await setPageData();
        }

        public async Task<IActionResult> OnPostAbout(string aboutMe, DateTime birthday)
        {
            if (aboutMe != null && birthday != null)
            {
                var dbAbout = await _db.About.FindAsync(keyValues: HttpContext.Session.GetInt32("loginStajyerID"));


                if (dbAbout != null)
                {
                    dbAbout.AboutText = aboutMe;
                    dbAbout.DateOfBirth = birthday;
                }
                else
                {
                    About newAbout = new About();
                    newAbout.AboutText = aboutMe;
                    newAbout.DateOfBirth = birthday;
                    newAbout.StajyerID = (int)HttpContext.Session.GetInt32("loginStajyerID");
                    await _db.About.AddAsync(newAbout);
                }
                await _db.SaveChangesAsync();
            }

            return await setPageData();
        }

        public async Task<IActionResult> OnPostSkill(string skill)
        {   
            if (skill != null)
            {
                Skill newSkill = new Skill();
                newSkill.SkillName = skill;
                newSkill.StajyerID = (int)HttpContext.Session.GetInt32("loginStajyerID");
                await _db.Skill.AddAsync(newSkill);
                await _db.SaveChangesAsync();
            }

            return await setPageData();
        }

        public async Task<IActionResult> OnPostExperience(string experienceCompanyName, string experiencePosition, DateTime experienceStartingDate, DateTime experienceFinishDate)
        {
            if (experienceCompanyName != null && experiencePosition != null && experienceStartingDate != null && experienceFinishDate != null)
            {
                Experience newExperience = new Experience();
                newExperience.CompanyName = experienceCompanyName;
                newExperience.Position = experiencePosition;
                newExperience.StartTime = experienceStartingDate;
                newExperience.FinishTime = experienceFinishDate;
                newExperience.StajyerID = (int)HttpContext.Session.GetInt32("loginStajyerID");
                await _db.Experience.AddAsync(newExperience);
                await _db.SaveChangesAsync();
            }

            return await setPageData();
        }

        public async Task<IActionResult> OnPostEducation(string educationSchoolName, DateTime educationStartingDate, DateTime educationFinishDate)
        {
            if (educationSchoolName != null)
            {
                Education newEducation = new Education();
                newEducation.EducationName = educationSchoolName;
                newEducation.StartTime = educationStartingDate;
                newEducation.FinishTime = educationFinishDate;
                newEducation.StajyerID = (int)HttpContext.Session.GetInt32("loginStajyerID");
                await _db.Education.AddAsync(newEducation);
                await _db.SaveChangesAsync();
            }

            return await setPageData();
        }
    }
}