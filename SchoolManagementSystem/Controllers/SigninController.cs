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
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.password = HttpContext.Session.GetString("password");
            if (TempData["bothempty"] != null)
            {
                ViewBag.bothempty = TempData["bothempty"].ToString();

            }
            if (TempData["wrongusernameorpassworderror"] != null)
            {
                ViewBag.wrongusernameorpassworderror = TempData["wrongusernameorpassworderror"].ToString();
            }

            if (TempData["usernameempty"] != null)
            {
                HttpContext.Session.GetString("password");
                ViewBag.usernameempty = TempData["usernameempty"].ToString();               
            }
            if (TempData["passwordempty"] != null)
            {
                HttpContext.Session.GetString("username");

                ViewBag.passwordempty = TempData["passwordempty"].ToString();
            }
            return View();

        }

        [HttpPost]
        public IActionResult Login(Signin signin)
        {
            ViewBag.Message = null;
            if (string.IsNullOrWhiteSpace(signin.Username) && (string.IsNullOrWhiteSpace(signin.Password)))
            {
                TempData["bothempty"] = "Username and Password  can not be blank!";
                return RedirectToAction("Index");
            }
            if (string.IsNullOrWhiteSpace(signin.Username) || (string.IsNullOrWhiteSpace(signin.Password)))
            {
               if (string.IsNullOrWhiteSpace(signin.Username)) 
                {
                   
                    HttpContext.Session.SetString("password", signin.Password);
                    ViewBag.password = HttpContext.Session.GetString("password");
                    TempData["usernameempty"] = "Username  can not be blank!";
                    return RedirectToAction("Index");
                }
                if (string.IsNullOrWhiteSpace(signin.Password))
                {
                    HttpContext.Session.SetString("username", signin.Username);
                    ViewBag.username = HttpContext.Session.GetString("username");

                    TempData["passwordempty"] = "Password  can not be blank!";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
          else
            {
                var record = _context.tblTeacher.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
               
                if (record != null)
                {
                    // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = record;
                    ViewBag.firstname = record.firstname;
                    ViewBag.teacherid = record.teacherid;
                    int tid = ViewBag.teacherid;
                    string strtid = Convert.ToString(tid);
                    int positionid = 3;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", record.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    HttpContext.Session.SetString("POSITIONID", strpid);
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                    HttpContext.Session.SetString("TEACHERID", strtid);
                    ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                    return View();
                }

                var recordstudent = _context.tblStudent.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
                if (recordstudent != null)
                {
                    // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = recordstudent;
                    ViewBag.firstname = recordstudent.firstname;
                    ViewBag.studentid = recordstudent.studentid;
                    int sid = ViewBag.studentid;
                    string strsid = Convert.ToString(sid);
                    int positionid = 4;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", recordstudent.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    HttpContext.Session.SetString("POSITIONID", strpid);
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                    HttpContext.Session.SetString("STUDENTID", strsid);
                    ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

                    int id = Convert.ToInt32(ViewBag.studentid);
                    int countMsg = _context.tblInbox.Count(x => x.studentid == id);
                    HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                    ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");

                    

                    return View();
                }

                var recordadmin = _context.tblAdmin.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
                if (recordadmin != null)
                {
                    // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = recordadmin;
                    ViewBag.firstname = recordadmin.firstname;
                    ViewBag.adminid = recordadmin.adminid;
                    int aid = ViewBag.adminid;
                    string straid = Convert.ToString(aid);
                    int positionid = 2;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", recordadmin.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                    HttpContext.Session.SetString("POSITIONID", strpid);
                    ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                    HttpContext.Session.SetString("ADMINID", straid);
                    ViewBag.adminid = HttpContext.Session.GetString("ADMINID");

                    //ViewData["firstname"] = record.firstname;
                    return View();
                }
                else
                {
                TempData["wrongusernameorpassworderror"] = " Wrong username or password";
                return RedirectToAction("Index");
                }
            }
        }
        
        public IActionResult Signout()
        {
            HttpContext.Session.Clear();
            
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.positionid = null;
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.firstname = null;
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.teacherid = null;
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.adminid = null;
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            ViewBag.studentid = null;
            


            return RedirectToAction("Index");
        }
    }

    
}
