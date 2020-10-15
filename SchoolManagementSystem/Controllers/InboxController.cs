using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class InboxController : Controller
    {
        private readonly ConnectionDB _context;

        public InboxController(ConnectionDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                int id = Convert.ToInt32(ViewBag.studentid);
                int ids = Convert.ToInt32(ViewBag.studentid);
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                return View(_context.tblInbox.Where(x=>x.studentid==id).ToList());
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
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
                var target = _context.tblInbox.Where(x => x.inboxid == id).FirstOrDefault();
                _context.tblInbox.Remove(target);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Signin");
        }

    }
    
}
