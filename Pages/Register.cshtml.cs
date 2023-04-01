using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StajyerUygulamasi.Model;

namespace StajyerUygulamasi.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _db;

        public RegisterModel(ILogger<RegisterModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [BindProperty]
        public Stajyer Stajyer { get; set; }

        public void OnGet()
        {

        
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) {

                var isMailValid = await _db.Stajyer.FirstOrDefaultAsync(dbStajyer => dbStajyer.Email == Stajyer.Email);

                if (isMailValid == null) {
                    await _db.Stajyer.AddAsync(Stajyer);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Login");
                }
                TempData["RegisterMessage"] = "Girilen mail adresi başka bir kullanıcı tarafından kullanılıyor!";
                return Page();
            } 
            else {
                TempData["RegisterMessage"] = "Lütfen eksik bilgileri doldurunuz.";
                return Page();
            }
        }
    }
}