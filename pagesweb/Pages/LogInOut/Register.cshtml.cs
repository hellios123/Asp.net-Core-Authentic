using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using pagesweb.Data;
using pagesweb.Models;

namespace pagesweb.Pages.LogInOut
{
    public class RegisterModel : PageModel

    {
        [BindProperty]
        public AppIdentUser AppUser { get; set; } = new AppIdentUser();
        private readonly pagesweb.Data.AppIdentUserContext _context;
        private readonly UserManager<AppIdentUser> _userManager;


        public RegisterModel(pagesweb.Data.AppIdentUserContext context , UserManager<AppIdentUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IActionResult OnGet()
        {
            return Page();
        }

       

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           bool a= int.TryParse(AppUser.MobileOrEmail, out int n);
            var Email1 = !a ? AppUser.MobileOrEmail : string.Empty;
            AppUser.Email = Email1;
            AppUser.UserName = a ? n.ToString() : Email1;
            bool ll = _context.AppIdentUsers.Any(w => w.UserName == AppUser.UserName);
           if ( ll)
            {
                ModelState.AddModelError(string.Empty, "the Email or Number already is in use ");
                return Page();
            }

            var result = await _userManager.CreateAsync(AppUser, AppUser.Password);

            if (result.Succeeded)
            {
                _context.AppIdentUsers.Add(AppUser);
                try { _context.SaveChanges(); }
                catch(Exception e)  { Debugger.Log(4, "debug for db", e.Message ); }
                return RedirectToPage("./LogIn");
            }
            ModelState.AddModelError(string.Empty,result.Errors.First().Description);
            return Page();

        }
    }
}