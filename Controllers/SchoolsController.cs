using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Szkoła.Models;
using Szkoła.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Szkoła.Controllers
{
    [Authorize]
    public class SchoolsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult List()
        {
            SchoolsServices mongo = new SchoolsServices("school", "school", "mongodb://localhost:27017/");
            var schools = mongo.getAll();
            return View("List", schools);
        }

        [HttpGet]
        public JsonResult ListJson()
        {
            SchoolsServices mongo = new SchoolsServices("school", "school", "mongodb://localhost:27017/");
            var schools = mongo.getAll();
            return Json(schools);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SchoolModel school)
        {
            if (school != null)
            {
                SchoolsServices mongo = new SchoolsServices("school", "school", "mongodb://localhost:27017/");
                mongo.create(school);
            }
            return View();
        }
    }
}
