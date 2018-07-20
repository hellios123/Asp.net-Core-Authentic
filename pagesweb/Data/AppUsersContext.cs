using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pagesweb.Data
{
    public class AppUsersContext : DbContext
    {
        public AppUsersContext (DbContextOptions<AppUsersContext> options)
            : base(options)
        {
        }

        public DbSet<pagesweb.Models.AppUser> AppUsers { get; set; }
        public DbSet<pagesweb.Models.Friend> Friends { get; set; }

    }
}
