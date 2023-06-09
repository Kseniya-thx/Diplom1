using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Diplom1.Models
{
    public class Person
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Otchestvo { get; set; }

        public string Telephone { get; set; }

        public string Peronsearch { get; set; }

    }

    //public Persons() { }

    //public Persons(int Id, string Surname, string Name, string Otchestvo, string Telephone) => this.Id


}