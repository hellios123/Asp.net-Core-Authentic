using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pagesweb.Models;

namespace pagesweb.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var x = DateTime.Now;
            CookieBuilder cb=  new CookieBuilder(){ Expiration=new TimeSpan(0,30,0 ),Name="First cookie"};
           // Response.Cookies.Append("Logkey", loged.ToString(), new CookieOptions()
           // { Expires = new DateTimeOffset(new DateTime(x.Year,x.Month,x.Day,x.Hour+1,0,0))});

           // if (!loged) { 
          // return RedirectToPage("/LogInOut/LogIn");
          //  }
            //ViewData["loged"] = "You are loged in";
            return Page();
        }
    }
}
