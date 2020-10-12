using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    [Table("tblCoursename")]
    public class Coursename
    {
   
        public int coursenameid { get; set; }

        [Required(ErrorMessage = "Student ID Required")]
        public string coursename { get; set; }
      
        public int teacherid { get; set; }
        //public bool isChecked { get; set; }

     
    }
}
