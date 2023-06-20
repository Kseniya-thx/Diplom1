using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Diplom1.Models
{
    public class Person
    {
        public Person(int Id, string Surname, string Name, string Otchestvo, string Telephone)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Otchestvo = Otchestvo;
            this.Telephone = Telephone;
        }

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Otchestvo { get; set; }

        public string Telephone { get; set; }

        public int? Registrationid { get; set; }
        public Registration Registration { get; set; }
    }
    
    public class Registration
    {
        public int id { get; set; }
        public string registration { get; set; }
        public ICollection<Person> Person { get; set; }
        public Registration()
        {
            Person = new List<Person>();
        }
    }
}