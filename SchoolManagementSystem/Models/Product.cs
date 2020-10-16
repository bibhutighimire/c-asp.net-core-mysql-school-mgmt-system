using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Product
    {
        public int productid { get; set; }
        public string pname { get; set; }
        public string description { get; set; }
        public int pcategoryid { get; set; }
        public int price { get; set; }
        public int availableqty { get; set; }
        public string imagename { get; set; }
        [NotMapped]
        public IFormFile imagefile { get; set; }
        public bool isavailable { get; set; }
    }
}
