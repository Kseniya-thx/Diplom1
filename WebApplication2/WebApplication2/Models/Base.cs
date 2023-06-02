using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Base
    {
        [Display(Name = "Номер вопроса")]
        public string Question { get; set; }
        [Display(Name = "Вопрос")]
        public string Question1 { get; set; }
        [Display(Name = "Ответ")]
        public string Answer { get; set; }
        
    }
}