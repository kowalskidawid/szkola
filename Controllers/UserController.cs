using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

using Szkoła.Services;
using Szkoła.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Szkoła.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Akcja pobierająca dane dotyczące wszystkich użytkowników
        /// </summary>
        /// <returns> Zwraca widok zawierający tabelę z danymi. </returns>
        [HttpGet]
        [Authorize]
        [Route("/Users")]
        [Route("/Users/List")]
        public IActionResult List()
        {
            signInServices mongo = new signInServices("school", "users", "mongodb://localhost:27017/");
            var users = mongo.getAll();
            return View("List", users);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View("Create");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        [RequireHttps]
        public IActionResult Create(signUpUserModel user)
        {
            if (ModelState.IsValid)
            {
                signUpUserServices mongo = new signUpUserServices("school", "users", "mongodb://localhost:27017/");
                mongo.create(user);
            }
            return Redirect("/users");
        }

        // GET: /<controller>/
        [HttpGet]
        [Authorize]
        public IActionResult Edit(string id)
        {
            signUpUserServices mongo = new signUpUserServices("school", "users", "mongodb://localhost:27017/");
            try
            {
                var users = mongo.getById(id);
                return View("Edit", users[0]);
            }
            catch (Exception e) {
                return View("NotFoundUser");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(signUpUserModel user)
        {
            if (ModelState.IsValid )
            {
                signUpUserServices mongo = new signUpUserServices("school", "users", "mongodb://localhost:27017/");
                mongo.edit(user);
                return Redirect("/Subjects/");
            }
            return View();
        }

        // GET: /<controller>/
        [HttpGet]
        [Authorize]
        public IActionResult Delete(string id)
        {
            signUpUserServices mongo = new signUpUserServices("school", "users", "mongodb://localhost:27017/");
            try
            {
                var users = mongo.getById(id);
                return View("Delete", users[0]);
            }
            catch (Exception e)
            {
                return View("NotFoundUser");
            }
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(signUpUserModel user)
        {
            signUpUserServices mongo = new signUpUserServices("school", "users", "mongodb://localhost:27017/");
            mongo.delete(user);
            return Redirect("/Users/");
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(signInUserModel user)
        {
            signInServices mongo = new signInServices("school", "users", "mongodb://localhost:27017/");
            List<signInUserModel> returnedUsers = mongo.signIn(user);
            if (  returnedUsers.Count == 1 )
            {
                var claims = new List<Claim>()
                {
                    new Claim( ClaimTypes.Name, user.Login ),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var userPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });
                HttpContext.SignInAsync(userPrincipal);

                HttpContext.Session.SetString("user", Json(returnedUsers[0]).ToString() );

                return Redirect("/Home/");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/home");
        }
    }
}
