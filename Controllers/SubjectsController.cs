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

    [RequireHttps]
    public class SubjectsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Authorize]
        [Route("/subjects")]
        public IActionResult List()
        {
            SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
            var subjects = mongo.getAll();
            return View("List", subjects);
        }

        [HttpGet]
        [Authorize]
        public JsonResult ListJson()
        {
            SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
            return Json( mongo.getAll() );
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubjectModel subject)
        {
            if (subject.name != null)
            {
                SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
                mongo.create(subject);
                return Redirect("/Subjects/List");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(string id)
        {
            SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
            try
            {
                var subjects = mongo.getById(id);
                return View("Edit", subjects[0]);

            }
            catch (Exception e)
            {
                return View("notFoundStudent");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubjectModel subject)
        {
            if (subject.name != null)
            {
                SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
                mongo.edit(subject);
                return Redirect("/Subjects/");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Delete(string id)
        {
            SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
            try
            {
                var subjects = mongo.getById(id);
                return View("Delete", subjects[0]);

            }
            catch (Exception e)
            {
                return View("notFoundStudent");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SubjectModel subject)
        {
            SubjectsServices mongo = new SubjectsServices("school", "subjects", "mongodb://localhost:27017/");
            mongo.delete(subject);
            return Redirect("/Subjects/");
        }
    }
}
