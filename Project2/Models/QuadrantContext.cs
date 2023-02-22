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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {   //Seed the database
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
                );

            mb.Entity<ApplicationResponse>().HasData(
                //Seed the database
                new ApplicationResponse
                {
                    TaskID = 1,
                    Task = "random",
                    DueDate = "01-01-2023",
                    Quadrant = 1,
                    CategoryID = 1,
                    Completed = true
                });
        }
    }
}
