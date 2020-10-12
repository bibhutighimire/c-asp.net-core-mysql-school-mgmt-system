using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class FeeController : Controller
    {
        private readonly ConnectionDB _context;

        public FeeController(ConnectionDB context)
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
                int sid =Convert.ToInt32(ViewBag.studentid);
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                List<Student> listofstudent = _context.tblStudent.ToList();
                List<Fee> listoffee = _context.tblFee.Where(x => x.studentid == sid).ToList();
                ViewBag.listoffee = listoffee;
                decimal paidamount = listoffee.Sum(x => x.paidfee);              
                ViewBag.paidamount = Convert.ToString(paidamount);

                decimal totalfee = 5000;
                ViewBag.totalfee = Convert.ToString(totalfee);

                decimal remainintfee = totalfee - paidamount;
                ViewBag.remainintfee = Convert.ToString(remainintfee);


                var joinedtable = from f in listoffee
                                  join s in listofstudent on f.studentid equals s.studentid
                                  select new NewVM { listoffee = f, listofstudent = s };


                return View(joinedtable);

            }
            else
                return RedirectToAction("Index", "Signin");
        }

        public IActionResult PaymentPage()
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
                List<Fee> listoffee = _context.tblFee.ToList();
                ViewBag.listoffee = listoffee;
                List<Student> listofstudent = _context.tblStudent.ToList();
                ViewBag.listofstudent = listofstudent;

                var joinedtable = from f in listoffee
                                  join s in listofstudent on f.studentid equals s.studentid
                                  select new NewVM { listoffee = f, listofstudent = s };


                return View();

            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult AfterPayment(Fee fee)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                int sid = Convert.ToInt32(ViewBag.studentid);
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                List<Fee> listoffee = _context.tblFee.Where(x => x.studentid == sid).ToList();
                ViewBag.listoffee = listoffee;
                List<Student> listofstudent = _context.tblStudent.ToList();
                
                

                Fee f = new Fee();
                f.datepaid = DateTime.Now;
                f.studentid =Convert.ToInt32(ViewBag.studentid);
                f.totalfee = 5000;
                f.paidfee = fee.paidfee;
                _context.tblFee.Add(f);
                _context.SaveChanges();



                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Index", "Signin");
        }
    }
   
}



