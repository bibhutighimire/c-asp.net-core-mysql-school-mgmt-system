﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ConnectionDB _context;

        public AdminController(ConnectionDB context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                return View(_context.tblAdmin.ToList());
            }
            else
                return RedirectToAction("Index", "Signin");
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id == null)
                {
                    return NotFound();
                }

                var admin = await _context.tblAdmin
                    .FirstOrDefaultAsync(m => m.adminid == id);
                if (admin == null)
                {
                    return NotFound();
                }

                return View(admin);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: Admin/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                return View();
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("adminid,firstname,lastname,dob,email,positionid,username,password")] Admin admin)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (ModelState.IsValid)
                {
                    _context.Add(admin);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(admin);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id == null)
                {
                    return NotFound();
                }

                var admin = await _context.tblAdmin.FindAsync(id);
                if (admin == null)
                {
                    return NotFound();
                }
                return View(admin);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("adminid,firstname,lastname,dob,email,positionid,username,password")] Admin admin)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id != admin.adminid)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(admin);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AdminExists(admin.adminid))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(admin);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id == null)
                {
                    return NotFound();
                }

                var admin = await _context.tblAdmin
                    .FirstOrDefaultAsync(m => m.adminid == id);
                if (admin == null)
                {
                    return NotFound();
                }

                return View(admin);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                var admin = await _context.tblAdmin.FindAsync(id);
                _context.tblAdmin.Remove(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        private bool AdminExists(int id)
        {
            return _context.tblAdmin.Any(e => e.adminid == id);
        }
    }
}
