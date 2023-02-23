using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{   //Create the variables
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
  
        [Required(ErrorMessage = "Task is required.")]
        public string Task { get; set; }

        [DataType(DataType.Date)]
        public string DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required.")]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        /*Making sure that the CategoryID is nullable for the user.*/
        public int? CategoryID { get; set; }
        public Category Category { get; set; }



    }
}
