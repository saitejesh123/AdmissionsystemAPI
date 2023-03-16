using System;
using System.ComponentModel.DataAnnotations;



namespace hellosas.Controllers.Models
{
    public class course
    {
        
        [Required]
        [Key]

        public int courseid { get; set; }


        public string coursename { get; set; }

        public int coursefees { get; set; }
    }
}
