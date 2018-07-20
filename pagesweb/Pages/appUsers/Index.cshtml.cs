using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pagesweb.Data;
using pagesweb.Models;

namespace pagesweb
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly AppUsersContext _context;
        
        public IndexModel(AppUsersContext context)
        {
            _context = context;
        }

        public IList<AppUser> AppUsers { get;set; }

        public async Task OnGetAsync()
        {
            AppUsers = await _context.AppUsers.ToListAsync();
        }
    }
}
