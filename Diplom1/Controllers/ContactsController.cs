using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom1.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index() //contacts
        {

            return View();
        }

        [HttpPost]
        public ActionResult Check(Contact contact) 
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }

            return View("Index");
        }
    }
}