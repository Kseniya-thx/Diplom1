using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom1.Components;
using Diplom1.Models;
using MySql.Data.MySqlClient;

namespace Diplom1.Controllers
{
    public class BasesController : Controller
    {
        // GET: Bases
        public ActionResult About()
        {
            var bases = new Base
            {
                About = "О компании",
                Info = "Государственное унитарное предприятие, работающее в области информатизации и информационного обеспечения органов государственной власти Санкт-Петербурга и других организаций, а также предоставления услуг в сфере создания и использования современных информационных и телекоммуникационных систем, средств и технологий"
            };

            return View("About", bases);
            //return new ViewResult { };
        }
        public ActionResult Index()
        {
            var bases = new Base
            {
                Question = "Вопрос-ответ",
                Question1 = "Как зовут Директора компании?",
                Answer = "Максименко Андрей Владимирович"
            };

            

            return View("Index", bases);
            //return new ViewResult { };
        }

        public ActionResult All()
        {
            var basess = new List<Base>
            {
                new Base
                {
                    Question = "Вопрос-ответ*1",
                    Question1 = "Адрес компании",
                    Answer = "Санкт-Петербург ул. Черняховского, д. 59"
                },

                new Base
                {
                    Question = "Вопрос-ответ*2",
                    Question1 = "Номер телефона отдела персонала",
                    Answer = "+7 (812) 417-41-70, доб.1128"
                },
            };

            return View("All", basess);
        }

       


    }
}
