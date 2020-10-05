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
            
               Signin s = new Signin();
            try
            {
                var record = _context.tblTeacher.Where(x => x.username.ToLower() == signin.Username.ToLower() && x.password.ToLower() == signin.Password.ToLower()).FirstOrDefault();
                if (record != null)
                {
                   // Session["positionid"]= record.positionid; 
                    ViewBag.allrecord = record;
                    ViewBag.firstname = record.firstname;
                    ViewBag.teacherid = record.teacherid;
                    int positionid = record.positionid;
                    string strpid = Convert.ToString(positionid);
                    HttpContext.Session.SetString("FNAME", record.firstname);
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
