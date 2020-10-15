using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class NewsController : Controller
    {
        private readonly ConnectionDB _context;

        public NewsController(ConnectionDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            int ids = Convert.ToInt32(ViewBag.studentid);
            int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
            HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
            ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
            return View();
        }
    }
}
