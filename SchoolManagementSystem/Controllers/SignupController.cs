using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Crypto.Generators;
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
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            

               
                if (TempData["lastname"] != null)
                {
                    ViewBag.lastname = TempData["lastname"].ToString();
                   // HttpContext.Session.GetString("lastname");
                }
                if (TempData["dob"] != null)
                {
                    ViewBag.dob = TempData["dob"].ToString();
                    // HttpContext.Session.GetString("dob");
                }
                if (TempData["email"] != null)
                {
                    ViewBag.email = TempData["email"].ToString();
                    // HttpContext.Session.GetString("email");
                }
                if (TempData["username"] != null)
                {
                    ViewBag.username = TempData["username"].ToString();
                  //  HttpContext.Session.GetString("username");
                }
                if (TempData["password"] != null)
                {
                    ViewBag.password = TempData["password"].ToString();
                  //  HttpContext.Session.GetString("password");
                }
                if (TempData["coursenameid"] != null)
                {
                    ViewBag.coursenameid = TempData["coursenameid"].ToString();
                   //  HttpContext.Session.GetString("coursenameid");
                }

                //var fromDatabaseEF = new SelectList(_context.tblCoursename.ToList(), "Coursename");
                //ViewData["Coursename"] = fromDatabaseEF;
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                ViewBag.Listofteacher = ListOfTeachers;
                List<Coursename> listofcoursename = _context.tblCoursename.ToList();
                ViewBag.listofcoursename = _context.tblCoursename.ToList();
                var joinedtable = from t in ListOfTeachers
                                  join c in listofcoursename on t.teacherid equals c.teacherid
                                  select new NewVM { listofcoursename = c, ListOfTeachers = t };

                return View(joinedtable);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpPost]
        public IActionResult SignUpTeacher(Teacher teacher)
        {
            

            if (
                (string.IsNullOrWhiteSpace(teacher.lastname))||
                (string.IsNullOrWhiteSpace(Convert.ToString(teacher.dob)))||
                (string.IsNullOrWhiteSpace(teacher.email))||
                (string.IsNullOrWhiteSpace(teacher.username))||
                (string.IsNullOrWhiteSpace(teacher.password))||
                (string.IsNullOrWhiteSpace(Convert.ToString(teacher.coursenameid))))
            {
               
                if (string.IsNullOrWhiteSpace(teacher.lastname))
                {
                   
                   
                    TempData["lastname"] = "Last Name can not be blank!";
                }
                if (string.IsNullOrWhiteSpace(Convert.ToString(teacher.dob)))
                {
                  
                  
                    TempData["dob"] = "Date of Birth can not be blank!";
                }
                if (string.IsNullOrWhiteSpace(teacher.email))
                {
                   
                    
                  
                    TempData["email"] = "Email can not be blank!";
                }
                if (string.IsNullOrWhiteSpace(teacher.username))
                {
                   
                    TempData["username"] = "UserName can not be blank!";
                }
                if (string.IsNullOrWhiteSpace(teacher.password))
                {
                  
                    TempData["password"] = "Password can not be blank!";
                }
                if (string.IsNullOrWhiteSpace(Convert.ToString(teacher.coursenameid))&& teacher.coursenameid==0)
                {
                   
                    TempData["coursenameid"] = "Course Name can not be blank!";
                }
                return RedirectToAction("SignupTeacher");
            }
           
            else
            {
                if (HttpContext.Session.GetString("FNAME") != null)
                {
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                    ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                    ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                    ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

                    Teacher newTeacher = new Teacher();
                    // string newcoursename = teacher.coursename;
                    List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                    //ViewBag.Listofteacher = ListOfTeachers;
                    List<Coursename> listofcoursename = _context.tblCoursename.ToList();
                    newTeacher.firstname = teacher.firstname;
                    newTeacher.lastname = teacher.lastname;
                    newTeacher.dob = teacher.dob;
                    newTeacher.email = teacher.email;
                    newTeacher.positionid = 3;
                    newTeacher.username = teacher.username;
                    newTeacher.password = teacher.password;
                    newTeacher.coursenameid = teacher.coursenameid;
                    _context.tblTeacher.Add(newTeacher);
                    _context.SaveChanges();
                    var joinedtable = from t in ListOfTeachers
                                      join c in listofcoursename on t.teacherid equals c.teacherid
                                      select new NewVM { listofcoursename = c, ListOfTeachers = t };

                    return RedirectToAction("Index", "Teacher");

                }
                else
                    return RedirectToAction("Index", "Signin");
            }
            
        }
    }
}
