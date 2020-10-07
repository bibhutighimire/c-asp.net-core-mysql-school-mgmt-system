using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class SignupController : Controller
    {
        private readonly ConnectionDB _context;

        public SignupController(ConnectionDB context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult SignUpTeacher()
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            var fromDatabaseEF = new SelectList(_context.tblCoursename.ToList(), "Coursename");
            ViewData["Coursename"] = fromDatabaseEF;
            List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
            //ViewBag.Listofteacher = ListOfTeachers;
            List<Coursename> listofcoursename = _context.tblCoursename.ToList();
            ViewBag.listofcoursename = _context.tblCoursename.ToList();
            var joinedtable = from t in ListOfTeachers
                              join c in listofcoursename on t.teacherid equals c.teacherid
                              select new NewVM { listofcoursename = c, ListOfTeachers = t };

            return View(joinedtable);
        }
        [HttpPost]
        public IActionResult SignUpTeacher(Teacher teacher)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

            if (teacher.firstname=="")
            {
                ViewBag.firstnameblackerror("Firstname can not be blank");
            }
            Teacher t = new Teacher();
            // string newcoursename = teacher.coursename;
            t.firstname = teacher.firstname;
            t.lastname = teacher.lastname;
            t.dob = teacher.dob;
            t.email = teacher.email;
            t.positionid = 3;
            t.username = teacher.username;
            t.password = teacher.password;
            t.coursenameid = teacher.coursenameid;
            _context.tblTeacher.Add(t);
            _context.SaveChanges();
            return View();
        }
    }
}
