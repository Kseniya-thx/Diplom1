using Diplom1.Components;
using Diplom1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using DbContext = System.Data.Entity.DbContext;
using Diplom1.Controllers.Filter;


namespace Diplom1.Controllers
{
    public class DepartController : Controller
    {
       
        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();
     
        private AppDBContent db = new AppDBContent();
        private readonly DbContext _context;
        public DepartController(DbContext context)
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
            
            
            var depart = new List<Depart>();
            var command = new MySqlCommand("select * from departments, heads_of_depart Where departments.id = heads_of_depart", _connection);
            using (var reader = command.ExecuteReader())

            {
                while (reader.Read())
                {
                    var departt = new Depart
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name_Depart = reader["name_depart"].ToString(),
                        
                    };

                    depart.Add(departt);
                }
            }

            return View(depart);
        }

        public Task<ActionResult> Search(string SearchString)
        {
            ViewData["Filtr"] = SearchString;
            var depat = from b in _context.Depart
                        select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                depat = depat.Where(d => d.name_depart.Contains(SearchString));
            }
            return View(depat);
        }
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name_depart")] Depart depart)
        {

            if (ModelState.IsValid)
            {
                db.Departs.Add(depart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depart);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "Id,name_depart")] Depart depart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depart).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depart);
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Depart depart = db.Departs.Find(id);
            db.Departs.Remove(depart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}