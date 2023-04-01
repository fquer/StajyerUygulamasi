using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StajyerUygulamasi.Pages
{
    public class InternsModel : PageModel
    {
        private readonly ILogger<InternsModel> _logger;

        public InternsModel(ILogger<InternsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}