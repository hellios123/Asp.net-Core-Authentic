using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pagesweb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace pagesweb.Data
{
    public class AppIdentUserContext : IdentityDbContext<AppIdentUser>

    {
        public AppIdentUserContext(DbContextOptions<AppIdentUserContext> options) : base(options)
        {

        }
        public DbSet<pagesweb.Models.AppIdentUser> AppIdentUsers { get; set; }
        public DbSet<pagesweb.Models.Friend> Friends { get; set; }
       


    }
}
