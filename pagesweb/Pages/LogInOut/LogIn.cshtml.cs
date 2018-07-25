using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using pagesweb.Data;
using pagesweb.Models;

namespace pagesweb.Pages.LogInOut
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public LogIn login { get; set; }
        [BindProperty]
        public string IsPersist { get; set; }
        public AppIdentUserContext _context;
        private readonly UserManager<AppIdentUser> _userManager;
        private readonly SignInManager<AppIdentUser> _signInManager;
        private readonly ILogger _logger;
        public LogInModel(AppIdentUserContext context, UserManager<AppIdentUser> userManager,
          SignInManager<AppIdentUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [AllowAnonymous]
        public async Task< IActionResult >OnGet()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await _signInManager.SignOutAsync();

            // await HttpContext.SignOutAsync("NewSceme");
            return Page();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            var user = _context.AppIdentUsers.SingleOrDefault(w => (w.MobileOrEmail == login.MobileOrEmail && w.Password == login.Password));
            if (user == null) {
                ModelState.AddModelError(string.Empty,"EmailOrPassword is incorrect ");
                return Page();
            }
            #region signin
            bool a = int.TryParse(login.MobileOrEmail, out int n);

            AppIdentUser IdentUser = new AppIdentUser() {
                // = n.ToString(),
                // Email = !a ? login.MobileOrEmail : string.Empty,
                MobileOrEmail = login.MobileOrEmail,
                
                Password = login.Password
            };
            
                var result = await _signInManager.PasswordSignInAsync(IdentUser,  login.Password,Convert.ToBoolean( IsPersist), lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
               // return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                //return RedirectToAction(nameof(Lockout));
            }
            #endregion
            return RedirectToPage("../appUsers/Index");

        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");

            return RedirectToPage();
        }
    }
}