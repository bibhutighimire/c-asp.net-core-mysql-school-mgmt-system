using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
  
    public class Position
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Position Name Required")]
        [Display(Name = "Position")]
        public string positionname { get; set; }
    }
}
