using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Diplom1
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;
        public PersonService()
        {
            _personRepository = new PersonRepository();
        }

        public async Task<List<Person>> GetPersons()
        {
            return await _personRepository.GetPersons();
        }
    }
}