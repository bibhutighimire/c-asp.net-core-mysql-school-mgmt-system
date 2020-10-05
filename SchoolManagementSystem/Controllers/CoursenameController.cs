using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //var myModel = new MultipleData();
            //myModel.teachers = _context.tblTeacher.ToList();
            //myModel.coursenames = _context.tblCoursename.ToList();

            List<Teacher> ListOfTeachers= _context.tblTeacher.ToList();
            //ViewBag.Listofteacher = ListOfTeachers;
            List<Coursename> listofcoursename = _context.tblCoursename.ToList();

            //ViewData["jointables"] = from t in ListOfTeachers
            //                         join c in listofcoursename on t.teacherid equals c.coursenameid ;

            //                         //into table1 from c in table1.DefaultIfEmpty()
            //                         select new  { listofcoursename = c, listofteachers = t };


            //ViewData["jointables"] =  from t.firstname, c.coursename, t.coursenameid
            //                        FROM Orders
            //                        INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

            var joinedtable = from t in ListOfTeachers
                                     join c in listofcoursename on t.teacherid equals c.teacherid
                              select new NewVM{ listofcoursename = c, ListOfTeachers = t };


            return View(joinedtable);
        }
    }
}
