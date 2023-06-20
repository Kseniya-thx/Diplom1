using Diplom1.Components;
using Diplom1.Controllers.Filter;
using Diplom1.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Diplom1.Controllers.Filter;

namespace Diplom1.Controllers
{
    public class HeadsDepartController : Controller
    {

        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();
        private AppDBContent db = new AppDBContent();
        private readonly DbContext _context;
        public HeadsDepartController(DbContext context)
        {
            _context = context;
        }



        // GET: Depart

        [RequireBasicAuthentication]
        public ActionResult Index()
        {

            // Example of getting current username
            var user = HttpContext.Session["Username"];
            //-----------------------------------

            var headsdepart = new List<HeadsDepart>();
            var command = new MySqlCommand("select * from heads_of_depart ", _connection);
            using (var reader = command.ExecuteReader())

            {
                while (reader.Read())
                {
                    var headsdepartt = new HeadsDepart
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FullName = reader["fullname"].ToString(),

                    };

                    headsdepart.Add(headsdepartt);
                }
            }

            return View(headsdepart);
        }

      




        //public Task<ActionResult> Search(string SearchString)
        //{
        //    ViewData["Filtr"] = SearchString;
        //    var hdepat = from b in _context.Depart
        //                 select b;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        hdepat = hdepat.Where(d => d.fullname.Contains(SearchString));
        //    }
        //    return View(hdepat);
        //}

        //[HttpGet]

        //public ActionResult Create()
        //{

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,fullname")] HeadsDepart headsDepart)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.HeadsDeparts.Add(headsDepart);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(headsDepart);

        //}

        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HeadsDepart headsDepart = db.HeadsDeparts.Find(id);
        //    if (headsDepart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(headsDepart);
        //}




        //public ActionResult Edit([Bind(Include = "Id,fullname")] HeadsDepart headsDepart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(headsDepart).State = (System.Data.Entity.EntityState)EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(headsDepart);
        //}

        //[HttpGet]


        //public ActionResult Delete(int? id)
        //{

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HeadsDepart headsDepart = db.HeadsDeparts.Find(id);
        //    if (headsDepart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(headsDepart);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]


        //public ActionResult DeleteConfirmed(int id)
        //{
        //    HeadsDepart headsDepart = db.HeadsDeparts.Find(id);
        //    db.HeadsDeparts.Remove(headsDepart);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}