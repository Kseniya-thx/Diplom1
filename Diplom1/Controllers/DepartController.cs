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
    public class DepartController : Controller
    {
        

        // GET: Person
        private readonly MySqlConnection _connection = ConnectionManager.GetConnection();
        // GET: Depart
        public ActionResult Index()
        {
            var depart = new List<Depart>();
            var command = new MySqlCommand("select * from departments", _connection);
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
        
    
  
    }
}