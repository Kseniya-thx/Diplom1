using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom1.Models;

namespace Diplom1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Person> person = new List<Person>();
            // Conect to Mysql.

            using (MySqlConnection con = new MySqlConnection ("server = localhost; user = root; database = knowledge_base; port = 3306;password@MYSQL "))

            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from employees", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Extrect your data
                    Person employees = new Person();
                    employees.ID = Convert.ToInt32(reader["id"]);
                    employees.Surname = reader["Фамилия"].ToString();
                    employees.Name = reader["Имя"].ToString();
                    employees.Otchestvo = reader["Отчество"].ToString();
                    employees.telephone = reader["Телефон"].ToString();

                    person.Add(employees);

                }

                reader.Close();
            }

            return View(person);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}