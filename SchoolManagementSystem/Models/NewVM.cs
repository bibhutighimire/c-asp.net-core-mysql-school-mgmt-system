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
        public Meeting listofmeeting { get; set; }
        public MeetingTime listofmeetingtime { get; set; }
        public Fee listoffee { get; set; }

        public Inbox listofinbox { get; set; }
        public ProductCategory listofproductcategory { get; set; }

        public Product listofproduct { get; set; }
        public Cart listofcart { get; set; }
        public Wallet listofwallet { get; set; }

    }
}
