using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace hellosas.Controllers.Models
{
    public class admissioninfo
    {

        [Required]
        [Key]

        public int addid { get; set; }




        [ForeignKey("stdinfo")]

        public int studid { get; set; }
        public virtual stdinfo stdinfo { get; set; }    
        
        [ForeignKey("course")]

        public int courseid { get; set; }
        public virtual course course { get; set; }




    }
}
