using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_927.API_Angular.Entity;
using Project_927.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_927.DataAccess
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) {  }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<Screenshots> Screenshots { get; set; }
        public DbSet<News> News { get; set; }
    }
}
