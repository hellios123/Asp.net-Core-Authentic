using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    public class LogInSignUpModel : PageModel
    {
        [BindProperty]
        public LogIn login { get; set; }
        [BindProperty]
        public string IsPersist { get; set; } = "true";
        //For Register binding
        [BindProperty]
        public AppIdentUser AppUser { get; set; } = new AppIdentUser();
        //
        public AppIdentUserContext _context;
        private readonly UserManager<AppIdentUser> _userManager;
        private readonly SignInManager<AppIdentUser> _signInManager;
        private readonly ILogger _logger;
        public LogInSignUpModel(AppIdentUserContext context, UserManager<AppIdentUser> userManager,
          SignInManager<AppIdentUser> signInManager, ILogger<RegisterModel> logger
)
        {  
            _context = context;
            _userManager = userManager;
            _logger = logger;

            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await _signInManager.SignOutAsync();

            // await HttpContext.SignOutAsync("NewSceme");
            return Page();
        }
        
       
        public async Task<IActionResult> OnPostLogInAsync()
        {
           // if (!ModelState.IsValid) { return Page(); }
            var user = _context.AppIdentUsers.SingleOrDefault(w => (w.MobileOrEmail == login.MobileOrEmail && w.Password == login.Password));
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "EmailOrPassword is incorrect ");
                return Page();
            }
            #region signin
            bool a = int.TryParse(login.MobileOrEmail, out int n);
            var Email1 = !a ? login.MobileOrEmail : string.Empty;
            string num1 = !a ? string.Empty : login.MobileOrEmail;



            var result = await _signInManager.PasswordSignInAsync(user, login.Password, Convert.ToBoolean(IsPersist), lockoutOnFailure: false);
            if (result.Succeeded)
            { string sv = "Hello  " + user.FirstMidName + "  you just  logged in.";
                _logger.LogInformation("Hello"+ user.FirstMidName+"you just  logged in.");
                return RedirectToPage("../Index",new { s=sv});
            }
            /*if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return;
                    RedirectToAction(nameof(Lockout));
            }*/
            #endregion
            return Page();

            //return RedirectToPage("../appUsers/Index");

        }
        public async Task<IActionResult> OnPostRegisterAsync()
        {
           /* if (!ModelState.IsValid)
            {
                return Page();
            }*/
            bool a = int.TryParse(AppUser.MobileOrEmail, out int n);
            var Email1 = !a ? AppUser.MobileOrEmail : string.Empty;
            AppUser.Email = Email1;
            AppUser.UserName = a ? n.ToString() : Email1;
            string num1 = !a ? string.Empty : login.MobileOrEmail;
            AppUser.PhoneNumber = num1;

            bool ll = _context.AppIdentUsers.Any(w => w.UserName == AppUser.UserName);
            if (ll)
            {
                ModelState.AddModelError(string.Empty, "the Email or Number already is in use ");
                return Page();
                
            }

            var result = await _userManager.CreateAsync(AppUser, AppUser.Password);

            if (result.Succeeded)
            {
                _context.AppIdentUsers.Add(AppUser);
                _logger.LogInformation("User Is created now log in");
                try { _context.SaveChanges(); }
                catch (Exception e) { Debugger.Log(4, "debug for db", e.Message); }
                return RedirectToPage();
            }
            ModelState.AddModelError(string.Empty, result.Errors.First().Description);
            return Page();

        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");

            return RedirectToPage();
        }
    }
}