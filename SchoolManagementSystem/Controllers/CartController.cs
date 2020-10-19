using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly ConnectionDB _context;
        private readonly IWebHostEnvironment _hostenvironment;

        public CartController(ConnectionDB context, IWebHostEnvironment hostenvironment)
        {
            _context = context;
            this._hostenvironment = hostenvironment;
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
                int ids = Convert.ToInt32(ViewBag.studentid);


                var target = _context.tblCart.Where(s => s.studentid == ids).ToList();

                int countqty = target.Sum(x => x.quantity);
                HttpContext.Session.SetString("countqty", Convert.ToString(countqty));
                ViewBag.numberofqty = HttpContext.Session.GetString("countqty");
                List<Cart> listofcart = _context.tblCart.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Product> listofproduct = _context.tblProduct.ToList();


                var joinedtable = from c in listofcart
                                  join p in listofproduct on c.productid equals p.productid
                                  select new NewVM { listofcart = c, listofproduct = p };

                int subtotal = target.Sum(x => x.total);
                HttpContext.Session.SetString("subtotal", Convert.ToString(subtotal));
                ViewBag.subtotal = HttpContext.Session.GetString("subtotal");

                var joinbyid=joinedtable.Where(s => s.listofcart.studentid == ids).ToList();
                return View(joinbyid);
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
                var target = _context.tblCart.Where(s => s.studentid == ids).ToList();
                int countqty = target.Sum(x => x.quantity);
                HttpContext.Session.SetString("countqty", Convert.ToString(countqty));
                ViewBag.numberofqty = HttpContext.Session.GetString("countqty");
                List<Cart> listofcart = _context.tblCart.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Product> listofproduct = _context.tblProduct.ToList();


                var joinedtable = from c in listofcart
                                  join p in listofproduct on c.productid equals p.productid
                                  select new NewVM { listofcart = c, listofproduct = p };

                int subtotal = target.Sum(x => x.total);
                HttpContext.Session.SetString("subtotal", Convert.ToString(subtotal));
                ViewBag.subtotal = HttpContext.Session.GetString("subtotal");

                var toremove = _context.tblCart.Where(x => x.cartid == id).FirstOrDefault();
                _context.tblCart.Remove(toremove);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult Checkout()
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
                var target = _context.tblCart.Where(s => s.studentid == ids).ToList();
                int countqty = target.Sum(x => x.quantity);
                HttpContext.Session.SetString("countqty", Convert.ToString(countqty));
                ViewBag.numberofqty = HttpContext.Session.GetString("countqty");
                List<Cart> listofcart = _context.tblCart.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Product> listofproduct = _context.tblProduct.ToList();


                var joinedtable = from c in listofcart
                                  join p in listofproduct on c.productid equals p.productid
                                  select new NewVM { listofcart = c, listofproduct = p };

                Inbox inbo = new Inbox();
                inbo.studentid = ids;

                inbo.subject = "Your order from Shopping is in process.";
                inbo.datesent = DateTime.Now;
                inbo.teacherid = Convert.ToInt32("1");
                _context.tblInbox.Add(inbo);

                _context.SaveChanges();

            var toremove = _context.tblCart.Where(x => x.studentid == ids).ToList();
                _context.tblCart.RemoveRange(toremove);
                _context.SaveChanges();
                return View();
            }
            else
                return RedirectToAction("Index", "Signin");
        }
    }
}
