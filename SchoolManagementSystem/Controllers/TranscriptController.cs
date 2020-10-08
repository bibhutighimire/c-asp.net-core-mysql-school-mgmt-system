using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class TranscriptController : Controller
    {
      
            private readonly ConnectionDB _context;

            public TranscriptController(ConnectionDB context)
            {
                _context = context;
            }
            public IActionResult Index(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            var selected = _context.tblStudent.Where(x => x.studentid == id).FirstOrDefault();
            return View(selected);
        }
 
        public IActionResult ReqForTranscript(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

            var selected = _context.tblStudent.Where(x => x.studentid == id).FirstOrDefault();
            Transcript t = new Transcript();
            t.studentid = selected.studentid;
            t.status = "Incomplete";
            t.daterequested = DateTime.Now;
            _context.tblTranscript.Add(t);
            _context.SaveChanges();

            return View();
        }
        public IActionResult AllTranscriptReq()
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");

            List<Student> listofstudent = _context.tblStudent.ToList();
            //ViewBag.Listofteacher = ListOfTeachers;
            List<Transcript> listoftranscript = _context.tblTranscript.ToList();


            var joinedtable = from s in listofstudent
                              join t in listoftranscript on s.studentid equals t.studentid
                              select new NewVM { listofstudent = s, listoftranscript = t };
            //var newtable = joinedtable.ToList();

            return View(joinedtable);
        }
        public IActionResult Delete(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
            _context.Remove(selected);
           
            _context.SaveChanges();

            return RedirectToAction("AllTranscriptReq");
        }
        public IActionResult Complete(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
            selected.status = "Complete";

            _context.SaveChanges();

            return RedirectToAction("AllTranscriptReq");
        }

        public IActionResult Incomplete(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");

            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
            ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
            ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
            var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
            selected.status = "Incomplete";

            _context.SaveChanges();

            return RedirectToAction("AllTranscriptReq");
        }

    }
}
