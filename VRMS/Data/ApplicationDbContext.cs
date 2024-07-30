using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRMS.Data.Entities;
using VRMS.Models;

namespace VRMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        //All DB Set
        public DbSet<Vheicle> vheicles {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
