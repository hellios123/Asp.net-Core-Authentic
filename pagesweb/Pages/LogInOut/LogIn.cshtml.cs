using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pagesweb.Data;
using pagesweb.Models;

namespace pagesweb.Pages.LogInOut
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public LogIn login { get; set; }
        public AppUsersContext _context;
        public LogInModel(AppUsersContext context)
        {
            _context = context;
        }
        
     
        public async Task< IActionResult >OnGet()
        {
            await HttpContext.SignOutAsync("NewSceme");
            return Page();
        }
        public async Task< IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            var user = _context.AppUsers.SingleOrDefault(w => (w.MobileOrEmail == login.MobileOrEmail && w.Password == login.Password));
            if (user == null) {
                ModelState.AddModelError(string.Empty,"EmailOrPassword is incorrect ");
                return Page();
            }
            // creating the claims 
            #region 1

            List<Claim> claims = new List<Claim>
      {
          new Claim(ClaimTypes.Email,login?.MobileOrEmail),
          new Claim("Password", login?.Password),
      };
            // create identity  
            ClaimsIdentity identity = new ClaimsIdentity(claims,  "cookie");
            // create principal  
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
           await  HttpContext.SignInAsync("NewSceme",principal);
            #endregion
            return RedirectToPage("../Index");

        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(
                    scheme: "NewSceme");

            return RedirectToPage();
        }
    }
}