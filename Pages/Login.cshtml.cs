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
                    return Redirect("Interns");
                }
                else {
                    return Page();
                }
            } 
            else {
                return Page();
            }
        }
    }
}