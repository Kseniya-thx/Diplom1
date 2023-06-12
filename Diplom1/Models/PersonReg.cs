using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom1.Models
{
    public class PersonReg
    {
        public IEnumerable<Person> Person { get; set; }
        public SelectList Surename {get; set;}
        public SelectList Registration { get; set; }
    }
}