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
    public class PositionsController : Controller
    {
        private readonly ConnectionDB _context;

        public PositionsController(ConnectionDB context)
        {
            _context = context;
        }

        // GET: Positions
        public ActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("POSITIONID");
            ViewBag.firstname = HttpContext.Session.GetString("FNAME");
            return View(_context.tblPosition.ToList());
        }

        
    }
}
