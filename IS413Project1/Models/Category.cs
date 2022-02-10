using System;
using System.ComponentModel.DataAnnotations;

namespace IS413Project1.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        internal dynamic ToList()
        {
            throw new NotImplementedException();
        }
    }
}
