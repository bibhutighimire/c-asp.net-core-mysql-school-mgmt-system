using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class SigninController : Controller
    {
        private readonly ConnectionDB _context;

        public SigninController(ConnectionDB context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Signin signin)
        {
            
            try
            {
                var record = _context.tblTeacher.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
               
                if (record != null)
                {
                    // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = record;
                    ViewBag.firstname = record.firstname;
                    ViewBag.teacherid = record.teacherid;
                    int positionid = 3;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", record.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    HttpContext.Session.SetString("POSITIONID", strpid);
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                    //ViewData["firstname"] = record.firstname;
                    return View();
                }

                var recordstudent = _context.tblStudent.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
                if (recordstudent != null)
                {
                    // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = recordstudent;
                    ViewBag.firstname = recordstudent.firstname;
                    ViewBag.teacherid = recordstudent.studentid;
                    int positionid = 4;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", recordstudent.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    HttpContext.Session.SetString("POSITIONID", strpid);
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                    //ViewData["firstname"] = record.firstname;
                    return View();
                }

                var recordadmin = _context.tblAdmin.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
                if (recordadmin != null)
                {
                    // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = recordadmin;
                    ViewBag.firstname = recordadmin.firstname;
                    ViewBag.adminid = recordadmin.adminid;
                    int positionid = 2;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", recordadmin.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    HttpContext.Session.SetString("POSITIONID", strpid);
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                    //ViewData["firstname"] = record.firstname;
                    return View();
                }

            }
            catch
            {
                ViewBag.Message = "Wrong Username or Password";
                return View("Index", "Signin");
            }
            return RedirectToAction("Index");
            //return RedirectToAction("Home/Index");
        }
        public IActionResult Signout()
        {

            return RedirectToAction("Index");
        }
    }

    
}
