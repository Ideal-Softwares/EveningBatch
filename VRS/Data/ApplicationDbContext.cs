using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRS.Areas.Admin.Models;

namespace VRS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

    }
}
