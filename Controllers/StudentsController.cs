using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Szkoła.Models;
using Szkoła.Services;

namespace Szkoła.Controllers
{
    public class StudentsController : Controller
    {
        /// <summary>
        ///     Akcja odpowiadająca za pobieranie listy uczniów. 
        /// </summary>
        /// <returns> Zwraca widok z tabelą zawierającej uczniów.  </returns>
        [HttpGet]
        [Authorize]
        [RequireHttps]
        [Route("/students")]
        public IActionResult List()
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            var students = mongo.getAll();
            return View("List", students);
        }
        
        // GET: /<controller>/
        [HttpGet]
        [Authorize]
        [RequireHttps]
        public IActionResult Create()
        {
            return View("create");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        [RequireHttps]
        public IActionResult Create(StudentsModel student)
        {
            if( ModelState.IsValid )
            {
                StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
                mongo.create(student);
            }
            return View("create", student);
        }

        [HttpGet]
        [Authorize]
        [RequireHttps]
        public IActionResult Details(string id)
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            try
            {
                var student = mongo.getById(id);
                return View("Details", student[0]);

            }
            catch (Exception e)
            {
                return View("notFoundStudent");
            }       
        }


        [HttpGet]
        [Authorize]
        [RequireHttps]
        public IActionResult Edit(string id)
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            try
            {
                var student = mongo.getById(id);
                return View("Edit", student[0]);

            }
            catch (Exception e)
            {
                return View("notFoundStudent");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentsModel student)
        {
            if (ModelState.IsValid)
            {
                StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
                mongo.edit(student);
            }
            return View("Edit", student);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(string id)
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            try
            {
                var student = mongo.getById(id);
                return View("Delete", student[0]);

            }
            catch (Exception e)
            {
                return View("notFoundStudent");
            }
        }

   

        [HttpPost]
        [Authorize]
        public IActionResult Delete(StudentsModel student)
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            try
            {
                mongo.delete(student);
                return Redirect("/students");

            }
            catch (Exception e)
            {
                return View("notFoundStudent");
            }
        }

        [HttpGet]
        public bool peselIsValid(string pesel)
        {
            return false;
        }

        [HttpGet]
        [Authorize]
        [RequireHttps]
        public JsonResult getClass(string id)
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            var student = mongo.getClass(id);
            return Json(student[0]);    
        }

        [HttpGet]
        [Authorize]
        [RequireHttps]
        public PartialViewResult getRecipientList()
        {
            StudentsServices mongo = new StudentsServices("school", "students", "mongodb://localhost:27017/");
            var students = mongo.getAll();
            return PartialView("Students/RecipientList", students);
        }
    }
}
