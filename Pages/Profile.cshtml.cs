using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StajyerUygulamasi.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;

        public ProfileModel(ILogger<ProfileModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var loginStajyerID = HttpContext.Session.GetInt32("loginStajyerID");
            if (loginStajyerID == null)
            {
                TempData["LoginMessage"] = "Oturumunuzun süresi doldu!";
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
    }
}