using Diplom1.Components;
using Diplom1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom1.Controllers
{
    public class PersonController : Controller
    {
        public string SerchTerm { get; set; }

        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();

        public ActionResult Index()
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
            }

            return View(person);
        }
        

    }
}