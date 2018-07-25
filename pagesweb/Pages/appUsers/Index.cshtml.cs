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
   [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AppIdentUserContext _context;
        
        public IndexModel(AppIdentUserContext context)
        {
            _context = context;
        }

        public IList<AppIdentUser> AppUsers { get;set; }

        public async Task OnGetAsync()
        {
            AppUsers = await _context.AppIdentUsers.ToListAsync();
        }
    }
}
