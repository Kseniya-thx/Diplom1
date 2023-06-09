using Diplom1.Components;
using Diplom1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplom1.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _personService;

        public PersonController()
        {
            _personService = new PersonService();
        }
     

        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();

        public  async Task<ActionResult> Index()
        {
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
                //{
                //    if (!string.IsNullOrEmpty(search))
                //    {
                //        List<Person> employees = Person.SearchPerson(search);
                //        return View(employees);
                //    }
                //}
            }

            
            return View(person);
            
            
            var persons = await _personService.GetPersons();
            
            return View(persons);

        }

        //[HttpGet]

        //public async Task<ActionResult> Index(string Personsearch)
        //{
        //    ViewData["GetPersonSearch"] = Personsearch;

        //    var employees = new MySqlCommand("select * from employees", _connection);
        //    if (!string.IsNullOrEmpty(Personsearch))
        //    {
        //        employees = employees.Where(MySqlX => MySqlX.name.Contains(Personsearch) || MySqlX.Email.Contains(Personsearch));
        //    }

        //    return View(await employees.AsNoTracking.ToListAsync());
        //}

        public ActionResult AddPerson()
        {
            return View();

        }

        public ActionResult EditPerson()
        {
            return View();

        }

        public async  Task<ActionResult> DeletePerson(int? id)
        {
            using (MySqlConnection connect = new MySqlConnection(ConnectionManager.strConnect))
            if (id != null) 
            {
                    string sql = "Delete from 'employeeys' Where'Id'= @Id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connect))
                    {
                        cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = id;
                        connect.Open();
                        return View();
                    }

                    //    Person person = await   .employees.FirstOrDefaultAsync(p => p.Id = id);
                    //if (person != null)
                    //{
                    //    db.employees.Remove(person);
                    //    await db
                    //}

                }
            return RedirectToAction("Index");

        }

    }
}