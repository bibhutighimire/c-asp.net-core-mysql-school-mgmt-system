using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ConnectionDB _context;

        public MeetingController(ConnectionDB context)
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
                int ids = Convert.ToInt32(ViewBag.studentid);
                int countMsg = _context.tblInbox.Count(x => x.studentid == ids);
                HttpContext.Session.SetString("countMsg", Convert.ToString(countMsg));
                ViewBag.numberofmsg = HttpContext.Session.GetString("countMsg");
                List<Meeting> listofmeeting = _context.tblMeeting.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Student> listofstudent = _context.tblStudent.ToList();
                List<MeetingTime> listofmeetingtime = _context.tblMeetingTime.ToList();
                ViewBag.listofmeetingtime = listofmeetingtime;
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                ViewBag.ListOfTeachers = ListOfTeachers;

                var joinedtable = from m in listofmeeting
                                  join s in listofstudent on m.studentid equals s.studentid
                                  join mt in listofmeetingtime on m.meetingtimeid equals mt.meetingtimeid
                                  join t in ListOfTeachers on m.teacherid equals t.teacherid
                                  orderby m.meetingid descending
                                  select new NewVM { listofstudent = s, listofmeeting = m, listofmeetingtime = mt, ListOfTeachers = t };

                return View(joinedtable);
            }
            else
                return RedirectToAction("Index", "Signin");
        }
        [HttpGet]
        public IActionResult Create()
        {

            if (TempData["duprecord"] != null)
            {
                ViewBag.duprecord = TempData["duprecord"].ToString();

            }
            if (TempData["success"] != null)
            {
                ViewBag.success = TempData["success"].ToString();

            }

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
                List<Meeting> listofmeeting = _context.tblMeeting.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Student> listofstudent = _context.tblStudent.ToList();
                List<MeetingTime> listofmeetingtime = _context.tblMeetingTime.ToList();
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                ViewBag.ListOfTeachers = ListOfTeachers;
                ViewBag.listofmeetingtime = listofmeetingtime;
                var joinedtable = from m in listofmeeting
                                  join s in listofstudent on m.studentid equals s.studentid
                                  join mt in listofmeetingtime on m.meetingtimeid equals mt.meetingtimeid
                                  join t in ListOfTeachers on m.teacherid equals t.teacherid
                                  select new NewVM { listofstudent = s, listofmeeting = m, listofmeetingtime = mt, ListOfTeachers=t };

                //var joinedtable = from m in listofmeeting
                //                  join mt in listofmeetingtime on m.meetingtimeid equals mt.meetingtimeid
                //                  select new NewVM { listofmeeting = m, listofmeetingtime = mt };


                return View(joinedtable);
            }
            else
                return RedirectToAction("Index", "Signin");
        }

        [HttpPost]
        public IActionResult AddMeeting(Meeting meeting)
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
                List<Meeting> listofmeeting = _context.tblMeeting.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Student> listofstudent = _context.tblStudent.ToList();
                List<MeetingTime> listofmeetingtime = _context.tblMeetingTime.ToList();
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                ViewBag.ListOfTeachers = ListOfTeachers;
                ViewBag.listofmeetingtime = listofmeetingtime;
                var joinedtable = from me in listofmeeting
                                  join s in listofstudent on me.studentid equals s.studentid
                                  join mt in listofmeetingtime on me.meetingtimeid equals mt.meetingtimeid
                                  join t in ListOfTeachers on me.teacherid equals t.teacherid
                                  
                                  select new NewVM { listofstudent = s, listofmeeting = me, listofmeetingtime = mt, ListOfTeachers = t };

                Meeting m = new Meeting();
                var checker = joinedtable.Where(x => x.ListOfTeachers.teacherid == meeting.teacherid && x.listofmeeting.dateofmeeting == meeting.dateofmeeting && x.listofmeetingtime.meetingtimeid == meeting.meetingtimeid).FirstOrDefault();
                if(checker==null)

                {

                    m.studentid = Convert.ToInt32(ViewBag.studentid);
                    m.requestedtime = DateTime.Now;

                    DateTime dateofmeeting = meeting.dateofmeeting.Date;
                    m.dateofmeeting = dateofmeeting;
                    m.meetingtimeid = meeting.meetingtimeid;
                    m.teacherid = meeting.teacherid;
                    m.about = meeting.about;
                    _context.Add(m);
                    _context.SaveChanges();

                   
                    TempData["success"] = "Your appointment scheduled successfully";
                    //ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
                    return RedirectToAction("Create");
                    
                    
                }
                else
                {
                    TempData["duprecord"] = "This time slot is already booked. Try Again!";
                    return RedirectToAction("Create");
                }
               
            }
            else
                return RedirectToAction("Index", "Signin");
        }

        public IActionResult TeacherMeetingReq(int id)
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
                List<Meeting> listofmeeting = _context.tblMeeting.ToList();
                //ViewBag.Listofteacher = ListOfTeachers;
                List<Student> listofstudent = _context.tblStudent.ToList();
                List<MeetingTime> listofmeetingtime = _context.tblMeetingTime.ToList();
                ViewBag.listofmeetingtime = listofmeetingtime;
                List<Teacher> ListOfTeachers = _context.tblTeacher.ToList();
                ViewBag.ListOfTeachers = ListOfTeachers;

                var joinedtable = from m in listofmeeting
                                  join s in listofstudent on m.studentid equals s.studentid
                                  join mt in listofmeetingtime on m.meetingtimeid equals mt.meetingtimeid
                                  join t in ListOfTeachers on m.teacherid equals t.teacherid
                                  orderby 
                                  
                                  m.requestedtime descending
                                  select new NewVM { listofstudent = s, listofmeeting = m, listofmeetingtime = mt, ListOfTeachers = t };
                var filteredmsgview = joinedtable.Where(x => x.ListOfTeachers.teacherid == id).ToList();
                return View(filteredmsgview);
            }
            else
                return RedirectToAction("Index", "Signin");
        }

    }
}
