﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Diplom1.Components;
using Diplom1.Models;
using MySql.Data.MySqlClient;

namespace Diplom1.Controllers
{
    public class BasesController : Controller
    {
        private readonly DbContext _context;
        public BasesController(DbContext context)
        {
            _context = context;
        }

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
                greeting = "Добро пожаловать в ИАЦ!",
                Question = "Вопрос-ответ",
                Question1 = "С чего начать?",
                Answer = "1. Список ваших коллег находится в разделе Сотрудники",
                Answer2 = "2. Для просмотра вопросов можете зайти в раздел 'Часто задаваемые вопросы'",
                Answer3 = "Желаем процветания и успехов вашим проектам!"

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
                    Question = "№1",
                    Question1 = "Адрес компании",
                    Answer = "Санкт-Петербург ул. Черняховского, д. 59"
                },

                new Base
                {
                    Question = "№2",
                    Question1 = "Номер телефона отдела персонала",
                    Answer = "+7 (812) 417-41-70, доб.1128"
                },

                new Base
                {
                    Question = "№3",
                    Question1 = "Если нет нужной информации",
                    Answer = "Зайти в раздел 'Обратная связь' и задать вопрос "
                },
                new Base
                {
                    Question = "№4",
                    Question1 = "Узнать номер сотрудника",
                    Answer = "Зайти в раздел 'Сотрудники', там будет вся информация о сотрудниках"
                }


        };
           

            return View("All", basess);
        }

      


        public ActionResult AddMaterial()
        {
            return View();
        
        }

        public ActionResult EditMaterial()
        {
            return View();

        }

        public ActionResult DeleteMaterial()
        {
            return RedirectToAction("Index");

        }
    }

    
}
