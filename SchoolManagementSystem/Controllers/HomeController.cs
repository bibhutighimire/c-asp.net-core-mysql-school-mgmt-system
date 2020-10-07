using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");


            return View();
        }
    }
}
