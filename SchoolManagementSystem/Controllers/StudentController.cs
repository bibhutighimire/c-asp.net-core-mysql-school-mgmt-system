using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                return View(_context.tblStudent.ToList());
            }
            else
                return RedirectToAction("Index", "Signin");

        }

        public IActionResult Create()
        {

            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                // List<Coursename> listofcoursename = _context.tblCoursename.ToList();
                List<Coursename> listofcoursename = _context.tblCoursename.ToList();
                ViewBag.listofcoursename = listofcoursename;
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Student> listofstudent = _context.tblStudent.ToList();
                List<MultipleCourseStudent> listofmultiplecoursestudent = _context.tblMultipleCourseStudent.ToList();
                var joinedtable = from c in listofcoursename
                                  join mcs in listofmultiplecoursestudent on c.coursenameid equals mcs.coursenameid
                                  join s in listofstudent on mcs.studentid equals s.studentid
                                  select new NewVM { listofcoursename = c, listofstudent = s, listofmultiplecoursestudent = mcs };
                return View(joinedtable);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpPost]
        public IActionResult Create(string firstname, string lastname, DateTime dob, string email, int coursename, string username, string password)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Coursename> listofcoursename = _context.tblCoursename.ToList();
                var joinedtable = from t in ListOfTeachers
                                  join c in listofcoursename on t.teacherid equals c.teacherid
                                  select new NewVM { listofcoursename = c, ListOfTeachers = t };
                Student s = new Student();
                s.firstname = firstname;
                s.lastname = lastname;
                s.positionid = 4;
                s.dob = dob;
                s.email = email;
                s.username = username;
                s.password = password;
                _context.tblStudent.Add(s);
                _context.SaveChanges();

                //MultipleCourseStudent mcs = new MultipleCourseStudent();
                //mcs.studentid = multipleCourseStudent.studentid;
                //mcs.coursenameid = multipleCourseStudent.coursenameid;
                //_context.tblMultipleCourseStudent.Add(mcs);
                //_context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult ProfileStudent(int id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                var selectedProfile = _context.tblStudent.Where(x => x.studentid == id).FirstOrDefault();
                HttpContext.Session.SetString("FNAME", selectedProfile.firstname);
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                return View(selectedProfile);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult ProfileAdmin(int id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                var selectedProfile = _context.tblAdmin.Where(x => x.adminid == id).FirstOrDefault();
                HttpContext.Session.SetString("FNAME", selectedProfile.firstname);
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                return View(selectedProfile);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult ProfileTeacher(int id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                var selectedProfile = _context.tblTeacher.Where(x => x.teacherid == id).FirstOrDefault();
                ViewBag.teacherid = selectedProfile.teacherid;
                HttpContext.Session.SetString("FNAME", selectedProfile.firstname);
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");

                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();

                List<Coursename> listofcoursename = _context.tblCoursename.ToList();


                return View(selectedProfile);
            }
            else
                return RedirectToAction("Index", "Signin");
        }

    }
}
