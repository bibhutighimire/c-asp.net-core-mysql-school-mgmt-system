using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class CoursenameController : Controller
    {
        private readonly ConnectionDB _context;

        public CoursenameController(ConnectionDB context)
        {
            _context = context;
        }

        public ActionResult Index()
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
            //var myModel = new MultipleData();
            //myModel.teachers = _context.tblTeacher.ToList();
            //myModel.coursenames = _context.tblCoursename.ToList();
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
            //ViewBag.Listofteacher = ListOfTeachers;
            List<Coursename> listofcoursename = _context.tblCoursename.ToList();


            var joinedtable = from t in ListOfTeachers
                              join c in listofcoursename on t.teacherid equals c.teacherid
                              select new NewVM { listofcoursename = c, ListOfTeachers = t };
            return View(joinedtable);
        }

    }
}
