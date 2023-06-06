using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Diplom1.Components;
using Diplom1.Models;

namespace Diplom1.Controllers
{
    //public class HomeController : Controller
    //{

    //    private readonly MySqlConnection _connection = ConnectionManager.GetConnection();

    //    public ActionResult Index()
    //    {
    //        var person = new List<Person>();
    //        var command = new MySqlCommand("select * from employees", _connection);
    //        using (var reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                var employees = new Person
    //                {
    //                    Id = Convert.ToInt32(reader["id"]),
    //                    Surname = reader["surename"].ToString(),
    //                    Name = reader["name"].ToString(),
    //                    Otchestvo = reader["otchestvo"].ToString(),
    //                    Telephone = reader["telephone"].ToString()
    //                };

    //                person.Add(employees);
    //            }
    //        }

    //        return View(person);
    //    }


    //}
}