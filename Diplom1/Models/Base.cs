using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Diplom1.Models
{
    public class Base
    {
        [Display(Name = "Номер вопроса")]
        public string Question { get; set; }
        [Display(Name = "Вопрос")]
        public string Question1 { get; set; }
        [Display(Name = "Ответ")]
        public string Answer { get; set; }

        public string About { get; set; }
        
        public string Info { get; set; }

        public string greeting { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public string NameMaterial { get; set; }
        public string Materil { get; set; }

    }
}