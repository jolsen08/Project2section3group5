using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class QuadrantContext : DbContext
    {
        public QuadrantContext (DbContextOptions<QuadrantContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    TaskID = 1,
                    Task = "random",
                    DueDate = "01-01-2023",
                    Quadrant = 1,
                    Category = "Home",
                    Completed = true
                });
        }
    }
}
