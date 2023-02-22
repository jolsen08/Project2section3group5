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
        [Required]
        public string Task { get; set; }

        [DataType(DataType.Date)]
        public string DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }



    }
}
