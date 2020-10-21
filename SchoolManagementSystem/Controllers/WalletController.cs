using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class WalletController : Controller
    {
        private readonly ConnectionDB _context;

        public WalletController(ConnectionDB context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AddValue()
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                int ids = Convert.ToInt32(ViewBag.studentid);
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");

                List<Student> listofstudent = _context.tblStudent.ToList();
                ViewBag.listofstudent = listofstudent;
                List<Wallet> listofwallet = _context.tblWallet.ToList();
                var joinedtable = from s in listofstudent
                                  join w in listofwallet on s.studentid equals w.studentid
                                  
                                  select new NewVM { listofwallet = w, listofstudent = s };
                return View(joinedtable);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpPost]
        public IActionResult AddValue(Wallet wallet)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                int ids = Convert.ToInt32(ViewBag.studentid);
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");

                var targetwallet = _context.tblWallet.Where(x => x.studentid == wallet.studentid).FirstOrDefault();
                targetwallet.studentid = wallet.studentid;
                targetwallet.cash = targetwallet.cash+ wallet.cash;
                _context.SaveChanges();

                Inbox inb = new Inbox();
                inb.studentid = wallet.studentid;
                inb.subject = "Your Wallet was Loaded $$$. Thanks";
                inb.datesent = DateTime.Now;
                inb.teacherid = Convert.ToInt32(ViewBag.teacherid);
                _context.tblInbox.Add(inb);
                _context.SaveChanges();
                return RedirectToAction("AddValue");
            }
            else
                return RedirectToAction("Index", "Signin");
        }
    }
}
