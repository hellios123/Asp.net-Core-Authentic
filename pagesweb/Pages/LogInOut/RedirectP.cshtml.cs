using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pagesweb.Pages.LogInOut
{
    public class RedirectPModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("LogInSignUp");
        }
    }
}