using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Cart
    {
        public int cartid { get; set; }
        public int productid { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int studentid { get; set; }
        public string status { get; set; }
        public int total { get; set; }
    }
}
