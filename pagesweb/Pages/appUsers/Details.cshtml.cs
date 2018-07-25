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
    public class DetailsModel : PageModel
    {
        private readonly AppUsersContext _context;

        public DetailsModel(AppUsersContext context)
        {
            _context = context;
        }

        public AppUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppUsers.FirstOrDefaultAsync(m => m.ID == id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
