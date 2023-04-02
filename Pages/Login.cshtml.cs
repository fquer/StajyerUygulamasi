using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _db;

        public LoginModel(ILogger<LoginModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [BindProperty(Name = "email")]
        public string postEmail { get; set; }
        [BindProperty(Name = "password")]
        public string postPassword { get; set; }

        public void OnGet()
        {

        
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                var userLoginSuccess = await _db.Stajyer.FirstOrDefaultAsync(dbStajyer => dbStajyer.Email == postEmail && dbStajyer.Password == postPassword);

                if (userLoginSuccess != null) {
                    HttpContext.Session.SetInt32("loginStajyerID", userLoginSuccess.Id);
                    HttpContext.Session.SetString("loginStajyerName", userLoginSuccess.Name);
                    HttpContext.Session.SetString("loginStajyerSurname", userLoginSuccess.Surname);
                    return Redirect("Interns");
                }
                else {
                    TempData["LoginMessage"] = "Email yada parola hatalı.";
                    return Page();
                }
            } 
            else {
                TempData["LoginMessage"] = "Lütfen eksik bilgileri doldurunuz.";
                return Page();
            }
        }
    }
}