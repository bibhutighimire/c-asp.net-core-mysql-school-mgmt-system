﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ConnectionDB _context;

        public StudentController(ConnectionDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                return View(_context.tblStudent.ToList());
            }
            else
                return RedirectToAction("Index","Signin");
            
        }

        public IActionResult ProfileStudent(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            var selectedProfile = _context.tblStudent.Where(x => x.studentid == id).FirstOrDefault();
            HttpContext.Session.SetString("FNAME", selectedProfile.firstname);
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            return View(selectedProfile);
        }

        public IActionResult ProfileAdmin(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            var selectedProfile = _context.tblAdmin.Where(x => x.adminid == id).FirstOrDefault();
            HttpContext.Session.SetString("FNAME", selectedProfile.firstname);
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            return View(selectedProfile);
        }

        public IActionResult ProfileTeacher(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            var selectedProfile = _context.tblTeacher.Where(x => x.teacherid == id).FirstOrDefault();
            ViewBag.teacherid= selectedProfile.teacherid;
            HttpContext.Session.SetString("FNAME", selectedProfile.firstname);
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");

            List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
           
            List<Coursename> listofcoursename = _context.tblCoursename.ToList();


            //var joinedtable = from t in ListOfTeachers
            //                  join c in listofcoursename on t.teacherid equals c.teacherid
            //                  select new NewVM { listofcoursename = c, ListOfTeachers = t };

            //var selected = joinedtable.Where(x => x.ListOfTeachers.teacherid == id).FirstOrDefault();
            
            return View(selectedProfile);
        }


    }
}
