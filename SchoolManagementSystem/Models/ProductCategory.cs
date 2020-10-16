using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class ProductCategory
    {
        [Key]
        public int pcategoryid { get; set; }
        public int category { get; set; }
    }
}
