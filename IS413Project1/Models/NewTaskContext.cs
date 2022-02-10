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
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
            mb.Entity<NewTaskForm>().HasData(
                new NewTaskForm
                {
                    TaskId = 1,
                    CategoryId = 2,
                    Task = "455 Homework",
                    DueDate = "	2022-02-11",
                    Quadrant = "Quadrant 3",
                    Completed = false
                },
                new NewTaskForm
                {
                    TaskId = 2,
                    CategoryId = 1,
                    Task = "Buy Groceries",
                    DueDate = "	2022-02-15",
                    Quadrant = "Quadrant 1",
                    Completed = false
                },
                new NewTaskForm
                {
                    TaskId = 3,
                    CategoryId = 2,
                    Task = "Mission 6",
                    DueDate = "2022-02-09",
                    Quadrant = "Quadrant 1",
                    Completed = false
                },
                new NewTaskForm
                {
                    TaskId = 4,
                    CategoryId = 4,
                    Task = "Prepare Talk",
                    DueDate = "2022-02-27",
                    Quadrant = "Quadrant 2",
                    Completed = false
                },
                new NewTaskForm
                {
                    TaskId = 5,
                    CategoryId = 2,
                    Task = "Study for 403 Exam",
                    DueDate = "2022-02-14",
                    Quadrant = "Quadrant 4",
                    Completed = false
                }
            );
        }
    }
}