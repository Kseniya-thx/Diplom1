using Diplom1.Components;
using Diplom1.Controllers.Filter;
using Diplom1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplom1.Controllers
{
    public class PersonController : Controller
    {

        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();
        private AppDBContent db = new AppDBContent();
        private readonly DbContext _context;
        public PersonController(DbContext context)
        {
            _context = context;
        }

        //[RequireBasicAuthentication]

        public   ActionResult Index()
        {


            // Example of getting current username
            //var user = HttpContext.Session["Username"];
            //-----------------------------------


            var person = new List<Person>();
            var command = new MySqlCommand("select * from employees", _connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employees = new Person
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Surname = reader["surename"].ToString(),
                        Name = reader["name"].ToString(),
                        Otchestvo = reader["otchestvo"].ToString(),
                        Telephone = reader["telephone"].ToString()
                    };

                    person.Add(employees);
                }
                
            }

            return View(person);

          
        }

        public Task<ActionResult> Search(string SearchString)
        {
            ViewData["Filtr"] = SearchString;
            var per = from v in _context.Person
                      select v;
            if (!String.IsNullOrEmpty(SearchString))
            {
                per = per.Where(d => d.name.Contains(SearchString));
            }
            return View(per);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,surename,name,otchestvo,telephone")] Person person)
        {

            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "id,surename,name,otchestvo,telephone")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
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