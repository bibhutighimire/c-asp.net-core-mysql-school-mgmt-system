using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ConnectionDB _context;

        public StudentController(ConnectionDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.tblStudent.ToList());
        }
    }
}
