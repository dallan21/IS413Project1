using System;
using System.ComponentModel.DataAnnotations;

namespace IS413Project1.Models
{
    public class NewTaskForm
    {
        //This ID will be hidden
        [Key]
        [Required]
        public int TaskId { get; set; }

        //Create the things that will be shown on the form page

        public string Task { get; set; }

        public string DueDate { get ; set; }
        [Required]
        public string Quadrant { get; set; }
        //True/False
        public bool Completed { get; set; }

        // Create the foreign key
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
