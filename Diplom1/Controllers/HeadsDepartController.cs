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
    public class HeadsDepartController : Controller
    {
        public string SerchTerm { get; set; }

        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();
        // GET: Depart
        public ActionResult Index()
        {
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
    }
}