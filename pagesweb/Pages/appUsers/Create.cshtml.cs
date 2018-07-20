using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pagesweb.Data;
using pagesweb.Models;

namespace pagesweb
{
    public class CreateModel : PageModel
    {
        private readonly AppUsersContext _context;

        public CreateModel(AppUsersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public AppUser AppUser { get; set; } = null;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            if (AppUser.FirstMidName == "stupid")
            {
                ModelState.AddModelError("AppUser.FirstMidName",
           $"The value can't  be that ");
                return Page();
            }
            _context.AppUsers.Add(AppUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}