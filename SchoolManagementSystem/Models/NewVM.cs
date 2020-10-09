using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class NewVM
    {
        public Teacher ListOfTeachers { get; set; }
        public Coursename listofcoursename { get; set; }
        public Student listofstudent { get; set; }
        public Transcript listoftranscript { get; set; }
        public MultipleCourseStudent listofmultiplecoursestudent { get; set; }


    }
}
