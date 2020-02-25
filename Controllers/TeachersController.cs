using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szkoła.Models;
using Szkoła.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Szkoła.Controllers
{

    public class TeachersController : Controller
    {

        private IHostingEnvironment _env;

        public TeachersController(IHostingEnvironment env)
        {
            _env = env;
        }


        [HttpGet]
        [Authorize]
        [Route("/teachers")]
        public IActionResult List()
        {
            TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
            var teachers = mongo.getAll();
            return View("List", teachers);
        }

        [HttpGet]
        [Authorize]
        public PartialViewResult getRecipientList()
        {
            TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
            var teachers = mongo.getAll();
            return PartialView("Teachers/RecipientList", teachers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["error"] = "false";
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        [RequireHttps]
        public IActionResult Create(TeacherModel teacher)
        {
            if (ModelState.IsValid)
            {
                TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
                mongo.create(teacher);
                return Redirect("/Teachers");
            }
            else
            {
                ViewData["error"] = "true";
                return View("Create", teacher);
            }
        }

        [HttpGet]
        [Authorize]
        [RequireHttps]
        public IActionResult Edit(string id)
        {
            TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
            try
            {
                var teacher = mongo.getById(id);
                return View("Edit", teacher[0]);

            }
            catch (Exception e)
            {
                return View("notFoundTeacher");
            }
        }


        [HttpPost]
        [Authorize]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(TeacherModel teacher)
        {
            if (ModelState.IsValid )
            {
                TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
                mongo.edit(teacher);

                return Redirect("/Teachers/");
            }

            ViewData["error"] = "true";
            return View( "Edit", teacher);
        }

        public IActionResult Delete(string id)
        {
            TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
            try
            {
                var teacher = mongo.getById(id);
                return View("Delete", teacher[0]);

            }
            catch (Exception e)
            {
                return View("notFoundTeacher");
            }
        }

        [HttpPost]
        public IActionResult Delete(TeacherModel teacher)
        {
            if (ModelState.IsValid)
            {
                TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
                mongo.delete(teacher);
                return Redirect("/Teachers/");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetSubjects(String id)
        {
            String[] subjects;
            TeachersServices mongo = new TeachersServices("school", "teachers", "mongodb://localhost:27017/");
            subjects = mongo.getById(id)[0].Subjects;
            return Json(subjects);
        }


        [HttpGet]
        public IActionResult FileUpload() => View();


        [HttpPost]
        public IActionResult FileUpload(IFormFile file)
        {
            String dir = _env.ContentRootPath + "/wwwroot/";

            using ( var fileStream = new FileStream( Path.Combine(dir, file.FileName) , FileMode.Create, FileAccess.Write) )
            {
                file.CopyTo(fileStream);
            }
            
            return View();
        }

    }
}
