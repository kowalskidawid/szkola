using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Szkoła.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        public bool Send()
        {

            return false;

        }
    }
}
