using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ConnectionDB _context;
        private readonly IWebHostEnvironment _hostenvironment;

        public ProductController(ConnectionDB context, IWebHostEnvironment hostenvironment)
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

                return View(_context.tblProduct.ToList());
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpGet]
        public IActionResult Create()
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
                return View();
            }
            else
                return RedirectToAction("Index", "Signin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productid,pname,description,pcategoryid,price,availableqty,imagefile,isavailable")] Product product)
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
                string wwwRootPath = _hostenvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(product.imagefile.FileName);
                string extension = Path.GetExtension(product.imagefile.FileName);
                product.imagename = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.imagefile.CopyToAsync(fileStream);
                }


                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
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
                return View(_context.tblProduct.Where(x => x.productid == id).FirstOrDefault());
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
                var imageModel = await _context.tblProduct.FindAsync(id);

                //delete image from wwwroot/image
                var imagePath = Path.Combine(_hostenvironment.WebRootPath, "image", imageModel.imagename);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
                //delete the record
                _context.tblProduct.Remove(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
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
                return View(_context.tblProduct.Where(x => x.productid == id).FirstOrDefault());
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("productid,pname,description,pcategoryid,price,availableqty,imagefile,isavailable")] Product product)
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
                string wwwRootPath = _hostenvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(product.imagefile.FileName);
                string extension = Path.GetExtension(product.imagefile.FileName);
                product.imagename = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.imagefile.CopyToAsync(fileStream);
                }

                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpGet]
        public IActionResult Details(int? id)
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

               
                return View(_context.tblProduct.Where(x => x.productid == id).FirstOrDefault());
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public ActionResult AddToCart(Cart cart)
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
                


                var targetd = _context.tblProduct.Where(x => x.productid == cart.productid).FirstOrDefault();


                Cart c = new Cart();
                c.productid = cart.productid;
                c.quantity = cart.quantity;
                c.studentid = ids;
                c.status = "addedtocart";
                c.price = targetd.price;
                c.total = c.price* c.quantity;

                _context.tblCart.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Signin");
        }

    }

}


