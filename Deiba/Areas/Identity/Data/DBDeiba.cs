using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deiba.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Deiba.Models;

namespace Deiba.Data
{
   
    public class DBDeiba : IdentityDbContext<ApplicationUser>
    { 
        public DbSet<Product> Products { get; set; }
        public DbSet<Barand> Barands { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<File> Files { get; set; }
       
        public DBDeiba(DbContextOptions<DBDeiba> options)
            : base(options)
        {
        }

        public DBDeiba()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
