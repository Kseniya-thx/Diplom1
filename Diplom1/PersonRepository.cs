using Diplom1.Components;
using Diplom1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Diplom1
{
    public class PersonRepository
    {
        public bool AddPerson(Person person)
        {
            person.Id = AddPerson(id: person.Id, surname: person.Surname, name: person.Name, otchestvo: person.Otchestvo, telephone: person.Telephone  ) ;
            return person.Id > 0;

        }

        

        public int AddPerson(int id, string name, string surname, string otchestvo, string telephone)
        {
            int Id = 0;
            using (MySqlConnection connect = new MySqlConnection(ConnectionManager.strConnect))
            {
                string sql = "Insert into 'employees' ('id', 'surename', 'name', 'otchestvo', 'telephone', )";
                using (MySqlCommand cmd = new MySqlCommand(sql, connect))
                {
                    cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = Id;
                    cmd.Parameters.Add("Surename", MySqlDbType.String).Value = surname;
                    cmd.Parameters.Add("Name", MySqlDbType.String).Value = name;
                    cmd.Parameters.Add("Otchestvo", MySqlDbType.String).Value = otchestvo;
                    cmd.Parameters.Add("Telephone", MySqlDbType.String).Value = telephone;
                    connect.Open();

                    if (cmd.ExecuteNonQuery() >= 0)
                    {
                        sql = "Select last_insert_id() as id";
                        cmd.CommandText = sql;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out id);
                    }
                }

            }
            return id;
        }

        public bool ChangePerson(Person person)

        { 
            return ChangePerson(id: person.Id, surname: person.Surname, name: person.Name, otchestvo: person.Otchestvo, telephone: person.Telephone);
        }
        public bool ChangePerson(int id, string surname, string name, string otchestvo, string telephone)
        {
            bool result = false;
            if (id > 0)
            {
                using (MySqlConnection connect = new MySqlConnection(ConnectionManager.strConnect))
                {
                    string sql = "Update 'employees' set 'Id'= @Id, 'surename'=@surename, 'name'= @name, 'otchestvo'= @otchestvo, 'telephone'= @telephone";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connect))
                    {
                        cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = id;
                        cmd.Parameters.Add("Surename", MySqlDbType.String).Value = surname;
                        cmd.Parameters.Add("Name", MySqlDbType.String).Value = name;
                        cmd.Parameters.Add("Otchestvo", MySqlDbType.String).Value = otchestvo;
                        cmd.Parameters.Add("Telephone", MySqlDbType.String).Value = telephone;
                        connect.Open();
                        result = cmd.ExecuteNonQuery() >= 0;

                    }



                }
            }
            return result;
        }

        public bool RemovePerson(Person person)
        {
            return RemovePerson(person.Id);
        }

        public bool RemovePerson(int id)
        {
            using (MySqlConnection connect = new MySqlConnection(ConnectionManager.strConnect))
            {
                string sql = "Delete from 'employeeys' Where'Id'= @Id";
                using (MySqlCommand cmd = new MySqlCommand(sql, connect))
                {
                    cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = id;
                    connect.Open();
                    return cmd.ExecuteNonQuery() >= 0;
                }
            }




        }


        //private readonly  List<Person> _person;

        //public PersonRepository()
        //{
        //    _person = new List<Person>();
        //}

        ////public async Task<Person> GetPersonAsync(int id)
        ////{
        ////    Person result = null;

        ////    using (var personContext = new PersonContext())
        ////    { 
        ////        result = await personContext.Person.
        ////    }

        ////        return result;
        ////}
        //public async Task<List<Person>> GetPersons() 
        //{
        //    return await Task.Run(() => _person);
        //}

        ////public async Task<List<Person>> GetPerson(int Id)
        ////{
        ////    return await Task.Run(() => _person.FirstOrDefault(f => f.Id == Id));
        ////}


    }
}