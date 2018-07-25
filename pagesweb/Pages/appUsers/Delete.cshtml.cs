using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pagesweb.Data;
using pagesweb.Models;

namespace pagesweb
{
    public class DeleteModel : PageModel
    {
        private readonly AppIdentUserContext _context;

        public DeleteModel(AppIdentUserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppIdentUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppIdentUsers.FirstOrDefaultAsync(m => m.Id == id.ToString());

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppIdentUsers.FindAsync(id);

            if (AppUser != null)
            {
                _context.AppIdentUsers.Remove(AppUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
