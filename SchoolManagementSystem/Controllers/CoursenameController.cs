using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class CoursenameController : Controller
    {
        private readonly ConnectionDB _context;

        public CoursenameController(ConnectionDB context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Teacher> ListOfTeachers= _context.tblTeacher.ToList();
            ViewBag.Listofteacher = ListOfTeachers;
            return View(_context.tblCoursename.ToList());
        }
    }
}
