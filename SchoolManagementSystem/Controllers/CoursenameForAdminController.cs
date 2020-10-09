using System;
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
    public class CoursenameForAdminController : Controller
    {
        private readonly ConnectionDB _context;

        public CoursenameForAdminController(ConnectionDB context)
        {
            _context = context;
        }

        // GET: CoursenameForAdmin
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Coursename> listofcoursename = _context.tblCoursename.ToList();


                var joinedtable = from t in ListOfTeachers
                                  join c in listofcoursename on t.teacherid equals c.teacherid
                                  select new NewVM { listofcoursename = c, ListOfTeachers = t };


                return View(joinedtable);

            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: CoursenameForAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id == null)
                {
                    return NotFound();
                }

                var coursename = await _context.tblCoursename
                    .FirstOrDefaultAsync(m => m.coursenameid == id);
                if (coursename == null)
                {
                    return NotFound();
                }

                return View(coursename);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: CoursenameForAdmin/Create
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
                return View();
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // POST: CoursenameForAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("coursenameid,coursename,teacherid")] Coursename coursenames)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (ModelState.IsValid)
                {
                    _context.Add(coursenames);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(coursenames);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: CoursenameForAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id == null)
                {
                    return NotFound();
                }

                var coursename = await _context.tblCoursename.FindAsync(id);
                if (coursename == null)
                {
                    return NotFound();
                }
                return View(coursename);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // POST: CoursenameForAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("coursenameid,coursename,teacherid")] Coursename coursenames)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id != coursenames.coursenameid)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(coursenames);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CoursenameExists(coursenames.coursenameid))
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
                return View(coursenames);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // GET: CoursenameForAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                if (id == null)
                {
                    return NotFound();
                }

                var coursename = await _context.tblCoursename
                    .FirstOrDefaultAsync(m => m.coursenameid == id);
                if (coursename == null)
                {
                    return NotFound();
                }

                return View(coursename);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        // POST: CoursenameForAdmin/Delete/5
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
                var coursename = await _context.tblCoursename.FindAsync(id);
                _context.tblCoursename.Remove(coursename);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        private bool CoursenameExists(int id)
        {
            return _context.tblCoursename.Any(e => e.coursenameid == id);
        }

    }
}
