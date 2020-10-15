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
            if (HttpContext.Session.GetString("FNAME") != null)
            {
                ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                ViewBag.firstname = HttpContext.Session.GetString("FNAME");
                ViewBag.teacherid = HttpContext.Session.GetString("TEACHERID");
                ViewBag.adminid = HttpContext.Session.GetString("ADMINID");
                ViewBag.studentid = HttpContext.Session.GetString("STUDENTID");
                int ids = Convert.ToInt32(ViewBag.studentid);
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                var selected = _context.tblStudent.Where(x => x.studentid == id).FirstOrDefault();
                return View(selected);
            }
            else
                return RedirectToAction("Index", "Signin");

        }

        public IActionResult ReqForTranscript(int id)
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
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                var selected = _context.tblStudent.Where(x => x.studentid == id).FirstOrDefault();
                Transcript t = new Transcript();
                t.studentid = selected.studentid;
                t.status = "Incomplete";
                t.daterequested = DateTime.Now;
                _context.tblTranscript.Add(t);
                _context.SaveChanges();

                return View();

            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult AllTranscriptReq()
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
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                List<Student> listofstudent = _context.tblStudent.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Transcript> listoftranscript = _context.tblTranscript.ToList();


                var joinedtable = from s in listofstudent
                                  join t in listoftranscript on s.studentid equals t.studentid
                                  orderby t.daterequested descending
                                  select new NewVM { listofstudent = s, listoftranscript = t };
                //var newtable = joinedtable.ToList();

                return View(joinedtable);
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
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
                _context.Remove(selected);

                _context.SaveChanges();

                return RedirectToAction("AllTranscriptReq");
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        public IActionResult Complete(int id)
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
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
                selected.status = "Complete";

                _context.SaveChanges();

                return RedirectToAction("AllTranscriptReq");
            }
            else
                return RedirectToAction("Index", "Signin");
        }

        public IActionResult Incomplete(int id)
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
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
                selected.status = "Incomplete";

                _context.SaveChanges();

                return RedirectToAction("AllTranscriptReq");
            }
            else
                return RedirectToAction("Index", "Signin");
        }

        public IActionResult Notify(int id)
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
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");

                List<Student> listofstudent = _context.tblStudent.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Transcript> listoftranscript = _context.tblTranscript.ToList();
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                List<Inbox> listofinbox = _context.tblInbox.ToList();

                var joinedtable = from i in listofinbox

                                  join s in listofstudent on i.studentid equals s.studentid
                                  join teac in ListOfTeachers on i.teacherid equals teac.teacherid
                                  //orderby t.daterequested descending
                                  select new NewVM { listofstudent = s,  ListOfTeachers = teac, listofinbox =i};


                var selectedstudent = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
                //int sid = selectedstudent.studentid;
               //var joinforinbox = joinedtable.Where(x => x.listofstudent.studentid == transcript.studentid).FirstOrDefault();
                Inbox inb = new Inbox();
                inb.studentid = selectedstudent.studentid;
                
                inb.subject = "Your Transcript is ready for pickup";
                inb.datesent = DateTime.Now.Date;
                inb.teacherid =Convert.ToInt32(ViewBag.teacherid);
                _context.tblInbox.Add(inb);

                _context.SaveChanges();
                var selected = _context.tblTranscript.Where(x => x.transcriptid == id).FirstOrDefault();
                selected.status = "Notified";

                _context.SaveChanges();

                return RedirectToAction("AllTranscriptReq");
            }
            else
                return RedirectToAction("Index", "Signin");
        }

    }
}
