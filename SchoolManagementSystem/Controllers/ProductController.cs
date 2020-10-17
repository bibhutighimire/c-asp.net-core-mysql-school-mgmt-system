using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
            return View(_context.tblProduct.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productid,pname,description,pcategoryid,price,availableqty,imagefile,isavailable")] Product product)
        {
            if (ModelState.IsValid)
            {
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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View(_context.tblProduct.Where(x=>x.productid==id).FirstOrDefault());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View(_context.tblProduct.Where(x => x.productid == id).FirstOrDefault());
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("productid,pname,description,pcategoryid,price,availableqty,imagefile,isavailable")] Product product)
        {
            if (ModelState.IsValid)
            {
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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            return View(_context.tblProduct.Where(x => x.productid == id).FirstOrDefault());
        }
    }
}
