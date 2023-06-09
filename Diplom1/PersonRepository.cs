using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Diplom1
{
    public class PersonRepository
    {

        private readonly  List<Person> _person;

        public PersonRepository()
        {
            _person = new List<Person>();
        }

        //public async Task<Person> GetPersonAsync(int id)
        //{
        //    Person result = null;

        //    using (var personContext = new PersonContext())
        //    { 
        //        result = await personContext.Person.
        //    }

        //        return result;
        //}
        public async Task<List<Person>> GetPersons() 
        {
            return await Task.Run(() => _person);
        }

        //public async Task<List<Person>> GetPerson(int Id)
        //{
        //    return await Task.Run(() => _person.FirstOrDefault(f => f.Id == Id));
        //}

       
    }
}