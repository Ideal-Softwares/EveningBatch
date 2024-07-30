using AppDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDB.DContext
{
    public class AppDbContext :DbContext
    {
        //All DB Set
        public DbSet<Student> students {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8K28S4N;Database=DbV2;Integrated Security=True;Connect Timeout=300;Encrypt=True;Trust Server Certificate=True;");
        }


    }
}
