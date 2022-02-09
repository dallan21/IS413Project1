using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace IS413Project1.Models
{
    public class NewTaskContext : DbContext
    {
        //This is our constructor
        //We are calling a DbcContextOptions of type (NewTaskContext) with the variable name "Options"
        //This will also inhereite the base "options" attributes 
        public NewTaskContext(DbContextOptions<NewTaskContext> options) : base(options)
        {

        }
        //Getting the set of data of type NewTaskForm
        //This will get the information from the NewTaskForm and put in in a list named "responses"
        public DbSet<NewTaskForm> responses { get; set; }

        //doing the same thing for the categories
        public DbSet<Category> categories { get; set; }

        //On creation of the Model, create the pre-specified category numbers to the name. In order to use in the dropdown 
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category {CategoryId = 1, CategoryName = "Home"},

                new Category { CategoryId = 2, CategoryName = "School"},

                new Category { CategoryId = 3, CategoryName = "Work"},

                new Category { CategoryId = 4, CategoryName = "Church"}

                );
        }
    }
}
